using renaissanceproject;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            ApplyWatermark(textBoxNom, "Nom complet", false);
            ApplyWatermark(textBoxPrenom, "Prénom", false);
            ApplyWatermark(textBoxEmail, "Adresse électronique", false);
            ApplyWatermark(textBoxPassword, "Mot de passe", true);
            ApplyWatermark(textBoxConfirm, "Confirmer le mot de passe", true);
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Créer un compte – Renaissance";

            var ico = Path.Combine(Application.StartupPath, "logo.ico");
            if (File.Exists(ico)) Icon = new Icon(ico);

            var bg = Path.Combine(Application.StartupPath, "creation.jpg");
            if (File.Exists(bg))
            {
                BackgroundImage = Image.FromFile(bg);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void ApplyWatermark(TextBox tb, string watermark, bool isPassword)
        {
            tb.ForeColor = Color.Gray;
            tb.Text = watermark;
            tb.UseSystemPasswordChar = false;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == watermark)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                    if (isPassword) tb.UseSystemPasswordChar = true;
                }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.UseSystemPasswordChar = false;
                    tb.Text = watermark;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;

            try
            {
                var nom = textBoxNom.Text.Trim();
                var prenom = textBoxPrenom.Text.Trim();
                var email = textBoxEmail.Text.Trim();
                var pwd = textBoxPassword.Text;
                var confirm = textBoxConfirm.Text;

                if (nom == "Nom complet" || prenom == "Prénom" ||
                    email == "Adresse électronique" ||
                    pwd == "Mot de passe" || confirm == "Confirmer le mot de passe" ||
                    string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd) ||
                    string.IsNullOrWhiteSpace(confirm))
                {
                    MessageBox.Show("Tous les champs sont obligatoires.", "Erreur",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!email.EndsWith("@renaissancequebec.ca", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("L’adresse doit finir par @renaissancequebec.ca", "Erreur",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (pwd != confirm)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var hashed = PasswordHelper.HashPassword(pwd);

                // ✅ Sécurité : vérification si la chaîne existe
                var csElement = ConfigurationManager.ConnectionStrings["ConnexionSQL"];
                if (csElement == null)
                {
                    MessageBox.Show("⚠️ La chaîne de connexion 'ConnexionSQL' est introuvable dans App.config.",
                                    "Erreur critique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cs = csElement.ConnectionString;

                using (var conn = new SqlConnection(cs))
                {
                    await conn.OpenAsync();

                    // Vérification d’unicité
                    using (var check = new SqlCommand("SELECT COUNT(*) FROM Utilisateur WHERE Email=@Email", conn))
                    {
                        check.Parameters.AddWithValue("@Email", email);
                        var exists = (int)await check.ExecuteScalarAsync();
                        if (exists > 0)
                        {
                            MessageBox.Show("Cette adresse email est déjà utilisée.", "Erreur",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insertion
                    using (var insert = new SqlCommand(@"
                        INSERT INTO Utilisateur (Nom, Prenom, Email, MotDePasse, DateCreation)
                        VALUES (@Nom, @Prenom, @Email, @MotDePasse, GETDATE())", conn))
                    {
                        insert.Parameters.AddWithValue("@Nom", nom);
                        insert.Parameters.AddWithValue("@Prenom", prenom);
                        insert.Parameters.AddWithValue("@Email", email);
                        insert.Parameters.AddWithValue("@MotDePasse", hashed);
                        await insert.ExecuteNonQueryAsync();
                    }
                }

                MessageBox.Show("✅ Compte créé avec succès !", "Succès",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonRegister.Enabled = true;
            }
        }
    }
}
