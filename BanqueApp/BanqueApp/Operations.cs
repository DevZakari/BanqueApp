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
    public partial class Operations : Form
    {
        private readonly BanqueDBEntities _db;
        private Compte _compte;
        public Operations(Compte compte)
        {
            InitializeComponent();
            _db = new BanqueDBEntities();
            this._compte = compte;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Operations_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateTheGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ICHAAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateTheGrid()
        {
            gvOperations.Refresh();
            var records = _db.Operation
                .Select(q => new
                {
                    DateOp = q.dateOp,
                    Montant = q.montant,
                    Libelle = q.libelle,
                    Id = q.id
                })
                .ToList();
            gvOperations.DataSource = records;
            gvOperations.Columns["Id"].Visible = false;
            gvOperations.Columns["DateOp"].HeaderText = "Date Operation";
        }
    }
}
