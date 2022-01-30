using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanqueApp
{
    public partial class VerseMontant : Form
    {
        private readonly BanqueDBEntities _db;
        private MainWindow _mainWindow;
        private Compte _compte;
        public VerseMontant(MainWindow mainWind,Compte compte)
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
            this._mainWindow = mainWind;
            this._compte = compte;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmitVers_Click(object sender, EventArgs e)
        {
            try
            {
                var numAcount = Convert.ToInt32(tbNumAccount.Text);
                double amount = Convert.ToDouble(tbAmountVers.Text);
                double my_solde = (double)this._compte.solde;
                double plafond = (double)this._compte.plafond;
                bool isValid = true;
                var errorMessages = "";

                if(numAcount == this._compte.id)
                {
                    isValid = false;
                    errorMessages += "Vous ne pouvez pas verser a vous Meme. \n";
                }
                if(amount < 0)
                {
                    isValid = false;
                    errorMessages += "Entrez un montant POSITIF. \n";
                }
                var compteDest = _db.Compte.FirstOrDefault(q => q.id == numAcount);
                if (compteDest == null)
                {
                    isValid = false;
                    errorMessages += "Ce Num ACCOUNT n'existe PAS. \n";
                }
                if(isValid)
                {
                    if (amount <= plafond)
                    {
                        if (my_solde > amount)
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            errorMessages += "Votre Solde est insufisant. \n";
                        }

                    }
                    else
                    {
                        isValid = false;
                        errorMessages += "Vous ne pouvez pas Débiter un montant > PLAFOND. \n";

                    }
                    if(isValid)
                    {
                        var new_Solde = my_solde - amount;
                        var compte = _db.Compte.FirstOrDefault(q => q.id == this._compte.id);
                        compte.solde = (decimal)new_Solde;
                        compteDest.solde += (decimal)amount;
                        var newOp = new Operation();
                        newOp.montant = (decimal)amount;
                        newOp.libelle = "Débiter";
                        //newOp.dateOp = (DateTime)new DateTime();
                        newOp.idCompte = compte.id;
                        _db.Operation.Add(newOp);
                        _db.SaveChanges();
                        this._mainWindow.PopulateGridView();
                        MessageBox.Show("Versement effectué Avec Succée.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }else
                {
                    MessageBox.Show("Error : " + errorMessages, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            

        }
    }
}
