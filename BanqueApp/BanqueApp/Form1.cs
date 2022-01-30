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
    public partial class Form1 : Form
    {
        private readonly BanqueDBEntities _db;
        public Form1()
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var login = tbLogin.Text.Trim();
                var password = tbPass.Text;
                var isValid = true;

                if(string.IsNullOrWhiteSpace(login) 
                    || string.IsNullOrWhiteSpace(password))
                {
                    isValid = false;
                    MessageBox.Show("Please Enter missing Data.", "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(isValid)
                {
                    var log_record = _db.Login.FirstOrDefault(q => q.login1 == login && q.password == password);
                    if (log_record == null)
                    {
                        MessageBox.Show("Wrong Credentials.", "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var user = _db.User.FirstOrDefault(q => q.idLogin == log_record.id);

                        if (user == null)
                        {
                            MessageBox.Show("Wrong Credentials.", "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var mainWindow = new MainWindow(user);
                            mainWindow.Show();
                            this.Hide();
                        }
                    }
                }
                
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
          

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var signup = new SignUP(this);
            signup.Show();
            this.Hide();
            

        }
    }
}
