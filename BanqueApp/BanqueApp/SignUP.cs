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
    public partial class SignUP : Form
    {
        private Form1 _pgLogin;
        private readonly BanqueDBEntities _db;
        public SignUP(Form1 pg_login)
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
            this._pgLogin = pg_login;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var Nom = tbNom.Text;
                var Prenom = tbPrenom.Text;
                var Adresse = tbAdresse.Text;
                var Login = tbLoginSign.Text;
                var Password = tbPassSign.Text;
                var Confirm_password = tbConfirmPass.Text;
                var isValid = true;
                var errorMessages = "";

                if (string.IsNullOrWhiteSpace(Login) ||
                    string.IsNullOrWhiteSpace(Nom) ||
                    string.IsNullOrWhiteSpace(Prenom) ||
                    string.IsNullOrWhiteSpace(Password) ||
                    string.IsNullOrWhiteSpace(Confirm_password))
                {
                    isValid = false;
                    errorMessages += "Error : Please Enter missing Data. \n";
                }
                if (Confirm_password != Password)
                {
                    isValid = false;
                    errorMessages += "Error : Password and Confirmed Password doesn't match. \n";
                }

                if (isValid)
                {
                    var newUser = new User();
                    var newLogin = new Login();
                    newUser.nom = Nom;
                    newUser.prenom = Prenom;
                    newUser.adresse = Adresse;
                    newLogin.login1 = Login;
                    newLogin.password = Password;
                    _db.Login.Add(newLogin);
                    _db.SaveChanges();
                    newUser.idLogin = newLogin.id;
                    _db.User.Add(newUser);
                    _db.SaveChanges();


                    MessageBox.Show("User Added Successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this._pgLogin.Show();
                    this.Close();


                }
                else
                {
                    MessageBox.Show(errorMessages, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception RAISED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._pgLogin.Show();
            this.Close();
           
        }
    }
}
