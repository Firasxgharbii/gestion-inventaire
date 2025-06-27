using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class AjoutSortieStockForm : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ConnexionSQL"].ConnectionString;

        public int MaterielId => (int)comboMateriel.SelectedValue;
        public int Quantite => (int)nudQuantite.Value;
        public DateTime DateSortie => dtpDate.Value;
        public string Raison => txtRaison.Text.Trim();

        public AjoutSortieStockForm()
        {
            InitializeComponent();
            LoadMateriels();
        }

        public AjoutSortieStockForm(int materielId, int quantite, DateTime dateSortie, string raison)
            : this()
        {
            this.Load += (s, e) =>
            {
                comboMateriel.SelectedValue = materielId;
                nudQuantite.Value = quantite;
                dtpDate.Value = dateSortie;
                txtRaison.Text = raison;
            };
        }

        private void LoadMateriels()
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                using (var da = new SqlDataAdapter("SELECT Id, Nom FROM Materiel", con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    comboMateriel.DataSource = dt;
                    comboMateriel.DisplayMember = "Nom";
                    comboMateriel.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des matériels : " + ex.Message);
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (comboMateriel.SelectedValue == null || nudQuantite.Value <= 0 || string.IsNullOrWhiteSpace(txtRaison.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs correctement.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
