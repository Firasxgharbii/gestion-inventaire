using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class CodeVerificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelInstruction;
        private TextBox textBoxCode;
        private Button buttonValider;
        private Panel panel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel = new Panel();
            this.labelInstruction = new Label();
            this.textBoxCode = new TextBox();
            this.buttonValider = new Button();

            // === Form ===
            this.Text = "Vérification du code – Renaissance";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1024, 768);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.DoubleBuffered = true;

            // Icône
            string icoPath = Path.Combine(Application.StartupPath, "logo.ico");
            if (File.Exists(icoPath))
                this.Icon = new Icon(icoPath);

            // Background image
            string bgPath = Path.Combine(Application.StartupPath, "creation.jpg");
            if (File.Exists(bgPath))
            {
                this.BackgroundImage = Image.FromFile(bgPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // === Panel ===
            this.panel.Size = new Size(500, 250);
            this.panel.BackColor = Color.FromArgb(245, 245, 245);
            this.panel.Anchor = AnchorStyles.None;

            // === Label ===
            this.labelInstruction.Text = "Entrez le code envoyé par le système :";
            this.labelInstruction.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.labelInstruction.TextAlign = ContentAlignment.MiddleCenter;
            this.labelInstruction.Size = new Size(460, 40);
            this.labelInstruction.Location = new Point(20, 20);

            // === TextBox ===
            this.textBoxCode.Font = new Font("Segoe UI", 12F);
            this.textBoxCode.Size = new Size(460, 30);
            this.textBoxCode.Location = new Point(20, 80);

            // === Button ===
            this.buttonValider.Text = "Valider";
            this.buttonValider.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.buttonValider.Size = new Size(460, 40);
            this.buttonValider.Location = new Point(20, 140);
            this.buttonValider.BackColor = Color.FromArgb(0, 120, 215);
            this.buttonValider.ForeColor = Color.White;
            this.buttonValider.FlatStyle = FlatStyle.Flat;
            this.buttonValider.FlatAppearance.BorderSize = 0;
            this.buttonValider.Click += new EventHandler(this.buttonValider_Click);

            // Ajout au panel
            this.panel.Controls.Add(labelInstruction);
            this.panel.Controls.Add(textBoxCode);
            this.panel.Controls.Add(buttonValider);

            // Ajout au formulaire
            this.Controls.Add(panel);

            // Centrage dynamique
            this.Load += (s, e) => CenterPanel();
            this.Resize += (s, e) => CenterPanel();
        }

        private void CenterPanel()
        {
            panel.Location = new Point(
                (this.ClientSize.Width - panel.Width) / 2,
                (this.ClientSize.Height - panel.Height) / 2
            );
        }
    }
}
