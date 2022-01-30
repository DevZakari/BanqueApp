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
    public partial class MainWindow : Form
    {
        private readonly BanqueDBEntities _db;
        private User _user;

        public MainWindow(User user )
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
            this._user = user;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGridView();
                statusLogin.Text = " Logged as : " + this._user.Login;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void PopulateGridView()
        {
            gvComptes.Refresh();
            var comptes = _db.User
                .Join(_db.Compte,
                user_u => user_u.id, // primary key
                user_c => user_c.idUser, // foriegn key
                (user_u, user_c) => new {
                    U_u = user_u,
                    U_c = user_c,
                    NumC = user_c.id,
                    Solde = user_c.solde
                }) // Selection 
                .Where(q => q.U_u.id == this._user.id).ToList();


            gvComptes.DataSource = comptes;
            gvComptes.Columns["U_c"].Visible = false;
            gvComptes.Columns["U_u"].Visible = false;
            gvComptes.Columns["NumC"].HeaderText = "Num Account";

            gvComptes.Columns["Solde"].HeaderText = "SOLDE en DH";
        }

        private void btnCrediter_Click(object sender, EventArgs e)
        {

            try
            {
                var id = (int)gvComptes.SelectedRows[0].Cells["NumC"].Value;
                var compteSelected = _db.Compte.FirstOrDefault(q => q.id == id);
                char type = 'C';
                var newOperation = new TypeOperation(this, compteSelected,type);
                newOperation.MdiParent = this.MdiParent;
                newOperation.ShowDialog();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\nYou haven't selected a ROW", "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDebiter_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvComptes.SelectedRows[0].Cells["NumC"].Value;
                var compteSelected = _db.Compte.FirstOrDefault(q => q.id == id);
                char type = 'D';
                var newOperation = new TypeOperation(this, compteSelected, type);
                newOperation.MdiParent = this.MdiParent;
                newOperation.ShowDialog();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\nYou haven't selected a ROW", "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvComptes.SelectedRows[0].Cells["NumC"].Value;
                var compteSelected = _db.Compte.FirstOrDefault(q => q.id == id);

                var pg_verser = new VerseMontant(this,compteSelected);
                pg_verser.MdiParent = this.MdiParent;
                pg_verser.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnOperations_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvComptes.SelectedRows[0].Cells["NumC"].Value;
                var compteSelected = _db.Compte.FirstOrDefault(q => q.id == id);

                var operations = new Operations(compteSelected);
                operations.MdiParent = this.MdiParent;
                operations.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
