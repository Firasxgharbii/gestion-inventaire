using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class AjoutMaterielForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnexionSQL"].ConnectionString;
        private readonly int? materielId;
        private readonly bool isModification;

        public AjoutMaterielForm(
            string nom = "",
            string type = "",
            string marque = "",
            string modele = "",
            string numeroSerie = "",
            string fournisseurNom = "",
            int? id = null)
        {
            InitializeComponent();

            textBoxNom.Text = nom;
            textBoxType.Text = type;
            textBoxMarque.Text = marque;
            textBoxModele.Text = modele;
            textBoxNumeroSerie.Text = numeroSerie;

            materielId = id;
            isModification = id.HasValue;
        }

        private void AjoutMaterielForm_Load(object sender, EventArgs e)
        {
            textBoxNom.Focus();
            LoadFournisseurs();
        }

        private void LoadFournisseurs()
        {
            checkedListBoxFournisseurs.Items.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DISTINCT NomFournisseur FROM Fournisseur ORDER BY NomFournisseur";
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkedListBoxFournisseurs.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            string nom = textBoxNom.Text.Trim();
            string type = textBoxType.Text.Trim();
            string marque = textBoxMarque.Text.Trim();
            string modele = textBoxModele.Text.Trim();
            string numeroSerie = textBoxNumeroSerie.Text.Trim();
            string fournisseurNom = string.Join(", ", checkedListBoxFournisseurs.CheckedItems.Cast<string>());

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(marque) || string.IsNullOrWhiteSpace(modele) ||
                string.IsNullOrWhiteSpace(numeroSerie))
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query;

                    if (isModification)
                    {
                        query = @"
                            UPDATE Materiel SET
                                Nom = @Nom,
                                Type = @Type,
                                Marque = @Marque,
                                Modele = @Modele,
                                NumeroSerie = @NumeroSerie,
                                FournisseurNom = @FournisseurNom
                            WHERE Id = @Id";
                    }
                    else
                    {
                        query = @"
                            INSERT INTO Materiel
                                (Nom, Type, Marque, Modele, NumeroSerie, FournisseurNom, DateAjout)
                            VALUES
                                (@Nom, @Type, @Marque, @Modele, @NumeroSerie, @FournisseurNom, GETDATE())";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Marque", marque);
                        cmd.Parameters.AddWithValue("@Modele", modele);
                        cmd.Parameters.AddWithValue("@NumeroSerie", numeroSerie);
                        cmd.Parameters.AddWithValue("@FournisseurNom", fournisseurNom);

                        if (isModification)
                            cmd.Parameters.AddWithValue("@Id", materielId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(isModification ? "✅ Matériel modifié avec succès !" : "✅ Matériel ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Erreur lors de l'enregistrement du matériel :\n" + ex.Message, "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
