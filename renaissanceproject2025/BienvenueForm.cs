using renaissanceproject2025;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class BienvenueForm : Form
    {
        public BienvenueForm()
        {
            InitializeComponent();

            // Conserve la barre de titre Windows et passe en plein écran
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bienvenue – Renaissance";

            // Charge l'icône dans la barre
            var icoPath = Path.Combine(Application.StartupPath, "logo.ico");
            if (File.Exists(icoPath))
                this.Icon = new Icon(icoPath);
        }

        private void BienvenueForm_Load(object sender, EventArgs e)
        {
            // Charge l'image de fond
            var bgPath = Path.Combine(Application.StartupPath, "fond30ans.jpg");
            if (File.Exists(bgPath))
            {
                this.BackgroundImage = Image.FromFile(bgPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // Centre le bouton
            btnBienvenue.Location = new Point(
                (ClientSize.Width - btnBienvenue.Width) / 2,
                (ClientSize.Height - btnBienvenue.Height) / 2
            );
            btnBienvenue.Anchor = AnchorStyles.None;
        }

        private void btnBienvenue_Click(object sender, EventArgs e)
        {
            // Cache cette fenêtre
            this.Hide();

            // Ouvre loginForm en taille normale AVEC barre de titre
            var login = new loginForm
            {
                FormBorderStyle = FormBorderStyle.Sizable,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Connexion – Renaissance"
            };
            login.Show();
        }
    }
}
