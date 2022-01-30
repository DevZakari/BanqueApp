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
    public partial class TypeOperation : Form
    {
        private readonly BanqueDBEntities _db;
        private char _typeOP;
        private Compte _compte;
        private MainWindow _mainWindow;
        public TypeOperation(MainWindow mainWindow, Compte c, char typeOp)
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
            this._typeOP = typeOp;
            this._compte = c;
            this._mainWindow = mainWindow;

            if(typeOp == 'C')
            {
                tbTypeOperation.Text = "Operation : Créditer";
            }
            else
            {
                tbTypeOperation.Text = "Operation : Débiter";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                double amount = Convert.ToDouble(tbAmount.Text);
                double my_solde = (double)this._compte.solde;
                double plafond = (double)this._compte.plafond;
                var isValid = true;
                var errorMessages = "";
                var successfulMessage = "";

                if (string.IsNullOrWhiteSpace(tbAmount.Text))
                {
                    isValid = false;
                    errorMessages += "Error : Please Enter missing Data. \n";
                }


                switch (this._typeOP)
                {
                    case 'C':
                        
                        if (amount < 0)
                        {
                            isValid = false;
                            errorMessages += "Vous ne puvez pas créditer un montant négatif.\n";
                        }else
                        {

                            var new_Solde = my_solde + amount;
                            var compte = _db.Compte.FirstOrDefault(q => q.id == this._compte.id);
                            compte.solde = (decimal)new_Solde;

                            var newOp = new Operation();
                            newOp.montant = (decimal)amount;
                            newOp.libelle = "Créditer";
                           // newOp.dateOp = (DateTime)new DateTime();
                            newOp.idCompte = compte.id;
                            _db.Operation.Add(newOp);
                            successfulMessage = "Votre Crédit Successful. ";
                           
                        }
                        break;
                    case 'D':
                        if( amount <= plafond)
                        {
                            if(my_solde > amount)
                            {
                                var new_Solde = my_solde - amount;
                                var compte = _db.Compte.FirstOrDefault(q => q.id == this._compte.id);
                                compte.solde = (decimal)new_Solde;

                                var newOp = new Operation();
                                newOp.montant = (decimal)amount;
                                newOp.libelle = "Débiter";
                                //newOp.dateOp = (DateTime)new DateTime();
                                newOp.idCompte = compte.id;
                                _db.Operation.Add(newOp);
                                successfulMessage = "Votre Débit Successful. ";
                            }else
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
                        break;
                    default:
                        break;
                }

                if(isValid)
                {
                    _db.SaveChanges();
                    MessageBox.Show(successfulMessage, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this._mainWindow.PopulateGridView();
                    this.Close();
                    
                }else
                {
                    MessageBox.Show(errorMessages, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
          
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message , "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
