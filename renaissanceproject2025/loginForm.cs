using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class loginForm : Form
    {
        private TableLayoutPanel layout;
        private Panel linksRow;
        private LinkLabel labelSignUp;
       

        public loginForm()
        {
            InitializeComponent();

            // Watermarks manuels
            textBoxUsername.Enter += RemoveUsernameWatermark;
            textBoxUsername.Leave += ApplyUsernameWatermark;
            textBoxPassword.Enter += RemovePasswordWatermark;
            textBoxPassword.Leave += ApplyPasswordWatermark;

            // Redirection lien mot de passe oublié
            labelForgotPassword.Click += LabelForgotPassword_Click;

            this.Resize += loginForm_Resize;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                var icoPath = Path.Combine(Application.StartupPath, "logo.ico");
                if (File.Exists(icoPath)) Icon = new Icon(icoPath);

                var bgPath = Path.Combine(Application.StartupPath, "renaissance2025.jpg");
                if (File.Exists(bgPath))
                {
                    BackgroundImage = Image.FromFile(bgPath);
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            CenterToScreen();
        }

        private void loginForm_Resize(object sender, EventArgs e)
        {
            if (layout != null)
            {
                layout.Left = (ClientSize.Width - layout.Width) / 2;
                layout.Top = (ClientSize.Height - layout.Height) / 2;
            }

            if (labelSignUp != null && linksRow != null)
            {
                labelSignUp.Left = linksRow.ClientSize.Width - labelSignUp.Width;
            }
        }

        private void RemoveUsernameWatermark(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Adresse électronique")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void ApplyUsernameWatermark(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                textBoxUsername.Text = "Adresse électronique";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void RemovePasswordWatermark(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Mot de passe")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void ApplyPasswordWatermark(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.Text = "Mot de passe";
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;
            try
            {
                var email = textBoxUsername.Text.Trim();
                var pwd = textBoxPassword.Text;

                if (email == "Adresse électronique" || pwd == "Mot de passe" || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!email.EndsWith("@renaissancequebec.ca", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("L'adresse doit se terminer par @renaissancequebec.ca", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cs = ConfigurationManager.ConnectionStrings["ConnexionSQL"].ConnectionString;
                using (var conn = new SqlConnection(cs))
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("SELECT MotDePasse FROM Utilisateur WHERE Email=@Email", conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        var stored = await cmd.ExecuteScalarAsync() as string;

                        if (stored == null || stored != pwd)
                        {
                            MessageBox.Show("Email ou mot de passe incorrect.", "Échec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                MessageBox.Show("Connexion réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                var dash = new Form1 { WindowState = FormWindowState.Maximized };
                dash.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonLogin.Enabled = true;
            }
        }

        private void checkBoxAfficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxAfficherMdp.Checked;
        }

        private void labelSignUp_Click(object sender, EventArgs e)
        {
            using (var rf = new RegisterForm()) rf.ShowDialog();
        }

        private void LabelForgotPassword_Click(object sender, EventArgs e)
        {
            using (var fpf = new ForgotPasswordForm()) fpf.ShowDialog();
        }
    }
}
