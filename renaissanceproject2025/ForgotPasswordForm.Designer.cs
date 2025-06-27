using System.Drawing;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class ForgotPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel;
        private Label labelTitle;
        internal TextBox textBoxEmail;
        private Button buttonSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new Panel();
            this.labelTitle = new Label();
            this.textBoxEmail = new TextBox();
            this.buttonSend = new Button();

            // === Form ===
            this.ClientSize = new Size(1024, 768);
            this.Load += new System.EventHandler(this.ForgotPasswordForm_Load);
            this.Resize += (s, e) => CenterPanel();

            // === Panel ===
            this.panel.Size = new Size(500, 250);
            this.panel.BackColor = Color.FromArgb(245, 245, 245);

            // === Label Title ===
            this.labelTitle.Text = "Réinitialiser le mot de passe";
            this.labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.Black;
            this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.labelTitle.Size = new Size(460, 40);
            this.labelTitle.Location = new Point(20, 20);

            // === TextBox Email ===
            this.textBoxEmail.Font = new Font("Segoe UI", 11F);
            this.textBoxEmail.Size = new Size(460, 30);
            this.textBoxEmail.Location = new Point(20, 80);
            this.textBoxEmail.ForeColor = Color.Gray;
            this.textBoxEmail.Text = "example@renaissancequebec.ca";

            this.textBoxEmail.Enter += (s, e) =>
            {
                if (textBoxEmail.Text == "example@renaissancequebec.ca")
                {
                    textBoxEmail.Text = "";
                    textBoxEmail.ForeColor = Color.Black;
                }
            };
            this.textBoxEmail.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {
                    textBoxEmail.Text = "example@renaissancequebec.ca";
                    textBoxEmail.ForeColor = Color.Gray;
                }
            };

            // === Button Send ===
            this.buttonSend.Text = "Envoyer";
            this.buttonSend.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.buttonSend.Size = new Size(460, 40);
            this.buttonSend.Location = new Point(20, 140);
            this.buttonSend.BackColor = Color.FromArgb(0, 120, 215);
            this.buttonSend.ForeColor = Color.White;
            this.buttonSend.FlatStyle = FlatStyle.Flat;
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);

            // Ajouter au panel
            this.panel.Controls.Add(labelTitle);
            this.panel.Controls.Add(textBoxEmail);
            this.panel.Controls.Add(buttonSend);

            // Ajouter au formulaire
            this.Controls.Add(panel);
        }
    }
}
