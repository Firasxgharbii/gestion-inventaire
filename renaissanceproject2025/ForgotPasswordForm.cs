using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();

            // Dessin d'une bordure douce autour du panel
            panel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawRectangle(pen, panel.DisplayRectangle);
                }
            };
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            this.Text = "Mot de passe oublié – Renaissance";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.DoubleBuffered = true;

            string bg = Path.Combine(Application.StartupPath, "creation.jpg");
            if (File.Exists(bg))
            {
                this.BackgroundImage = Image.FromFile(bg);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            CenterPanel();
        }

        private void CenterPanel()
        {
            if (panel != null)
            {
                panel.Location = new Point(
                    (this.ClientSize.Width - panel.Width) / 2,
                    (this.ClientSize.Height - panel.Height) / 2
                );
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var email = textBoxEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || email == "example@renaissancequebec.ca")
            {
                MessageBox.Show("Veuillez entrer une adresse électronique valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var random = new Random();
            var code = random.Next(100000, 999999).ToString();

            MessageBox.Show($"Code envoyé : {code}", "Code de vérification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var codeForm = new CodeVerificationForm(code);
            codeForm.ShowDialog();

            this.Close();
        }
    }
}
