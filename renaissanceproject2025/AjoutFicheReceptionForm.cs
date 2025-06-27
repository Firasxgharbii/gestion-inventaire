using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class AjoutFicheReceptionForm : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ConnexionSQL"].ConnectionString;

        private int ficheId;

        public int MaterielId { get; private set; }
        public int FournisseurId { get; private set; }
        public int QuantiteCommande { get; private set; }
        public int QuantiteRecu { get; private set; }
        public int QuantiteEnAttente { get; private set; }
        public string NumeroPO { get; private set; }
        public string Observation { get; private set; }
        public DateTime DateReception { get; private set; }
        public DateTime DateAjout { get; private set; }
        public string NumeroSerieSelectionne { get; private set; }

        public AjoutFicheReceptionForm()
        {
            InitializeComponent();
            Load += AjoutFicheReceptionForm_Load;
            buttonAnnuler.Click += (_, __) => Close();
            buttonValider.Click += ButtonValider_Click;
            comboBoxMateriel.SelectedIndexChanged += ComboBoxMateriel_SelectedIndexChanged;
        }

        public AjoutFicheReceptionForm(
            string numeroPO,
            int quantiteCommande,
            int quantiteRecu,
            DateTime dateReception,
            string observation,
            int fournisseurId,
            int materielId,
            int ficheId
        ) : this()
        {
            this.ficheId = ficheId;
            NumeroPO = numeroPO;
            QuantiteCommande = quantiteCommande;
            QuantiteRecu = quantiteRecu;
            QuantiteEnAttente = quantiteCommande - quantiteRecu;
            DateReception = dateReception;
            DateAjout = DateTime.Now;
            Observation = observation;
            FournisseurId = fournisseurId;
            MaterielId = materielId;
        }

        private void AjoutFicheReceptionForm_Load(object sender, EventArgs e)
        {
            ChargerFournisseurs();
            ChargerMateriels();
            ChargerNumeroPO();

            if (ficheId != 0)
            {
                comboBoxNumeroPO.SelectedItem = NumeroPO;
                numericQuantiteAchetee.Value = QuantiteCommande;
                numericQuantiteRecu.Value = QuantiteRecu;
                dateTimeAjout.Value = DateAjout;
                dateTimeReception.Value = DateReception;
                textBoxObservation.Text = Observation;
                comboBoxFournisseur.SelectedValue = FournisseurId;
                comboBoxMateriel.SelectedValue = MaterielId;
            }
        }

        private void ChargerFournisseurs()
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT Id, NomFournisseur FROM Fournisseur", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxFournisseur.Items.Add(
                            new ListItem(reader.GetString(1), reader.GetInt32(0))
                        );
                    }
                }
            }
        }

        private void ChargerMateriels()
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT Id, Nom FROM Materiel", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxMateriel.Items.Add(
                            new ListItem(reader.GetString(1), reader.GetInt32(0))
                        );
                    }
                }
            }
        }

        private void ChargerNumeroPO()
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT DISTINCT NumeroPO FROM Achat", con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxNumeroPO.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void ComboBoxMateriel_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxNumSerie.Items.Clear();

            if (comboBoxMateriel.SelectedItem is ListItem selected)
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SELECT NumeroSerie FROM Materiel WHERE Id = @materielId", con))
                    {
                        cmd.Parameters.AddWithValue("@materielId", selected.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string numeroSerie = reader.GetString(0);
                                checkedListBoxNumSerie.Items.Add(numeroSerie, true); // coché automatiquement
                            }
                        }
                    }
                }
            }
        }

        private void ButtonValider_Click(object sender, EventArgs e)
        {
            if (comboBoxMateriel.SelectedItem == null || comboBoxFournisseur.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un matériel et un fournisseur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MaterielId = ((ListItem)comboBoxMateriel.SelectedItem).Value;
            FournisseurId = ((ListItem)comboBoxFournisseur.SelectedItem).Value;
            QuantiteCommande = (int)numericQuantiteAchetee.Value;
            QuantiteRecu = (int)numericQuantiteRecu.Value;
            QuantiteEnAttente = QuantiteCommande - QuantiteRecu;
            NumeroPO = comboBoxNumeroPO.SelectedItem?.ToString();
            Observation = textBoxObservation.Text.Trim();
            DateReception = dateTimeReception.Value;
            DateAjout = dateTimeAjout.Value;

            var numerosCoches = checkedListBoxNumSerie.CheckedItems
                .OfType<string>()
                .ToList();

            NumeroSerieSelectionne = numerosCoches.FirstOrDefault();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
