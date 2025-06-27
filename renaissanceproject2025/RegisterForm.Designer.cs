using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class RegisterForm
    {
        private IContainer components = null;
        private TableLayoutPanel layout;
        private Label lblTitle;
        internal TextBox textBoxNom;
        internal TextBox textBoxPrenom;
        internal TextBox textBoxEmail;
        internal TextBox textBoxPassword;
        internal TextBox textBoxConfirm;
        private Button buttonRegister;
        private Panel containerPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.layout = new TableLayoutPanel();
            this.lblTitle = new Label();
            this.textBoxNom = new TextBox();
            this.textBoxPrenom = new TextBox();
            this.textBoxEmail = new TextBox();
            this.textBoxPassword = new TextBox();
            this.textBoxConfirm = new TextBox();
            this.buttonRegister = new Button();
            this.containerPanel = new Panel();

            // RegisterForm
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Créer un compte – Renaissance";
            this.Load += RegisterForm_Load;
            this.BackColor = Color.FromArgb(4, 41, 68);

            // containerPanel
            this.containerPanel.BackColor = Color.White;
            this.containerPanel.Size = new Size(400, 400);
            this.containerPanel.Location = new Point((this.ClientSize.Width - 400) / 2, (this.ClientSize.Height - 400) / 2);
            this.containerPanel.Anchor = AnchorStyles.None;
            this.containerPanel.Padding = new Padding(20);
            this.containerPanel.BorderStyle = BorderStyle.FixedSingle;

            // layout
            this.layout.Dock = DockStyle.Fill;
            this.layout.ColumnCount = 1;
            this.layout.RowCount = 7;
            this.layout.RowStyles.Clear();
            for (int i = 0; i < 7; i++)
                this.layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // lblTitle
            this.lblTitle.Text = "Créer un compte";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.layout.Controls.Add(this.lblTitle, 0, 0);

            // Styles pour les TextBoxes
            Font inputFont = new Font("Segoe UI", 11F);
            Color inputBack = Color.White;

            this.textBoxNom = CreateInputBox("Nom complet", inputFont, inputBack);
            this.textBoxPrenom = CreateInputBox("Prénom", inputFont, inputBack);
            this.textBoxEmail = CreateInputBox("Adresse électronique", inputFont, inputBack);
            this.textBoxPassword = CreateInputBox("Mot de passe", inputFont, inputBack);
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxConfirm = CreateInputBox("Confirmer le mot de passe", inputFont, inputBack);
            this.textBoxConfirm.UseSystemPasswordChar = true;

            this.layout.Controls.Add(this.textBoxNom, 0, 1);
            this.layout.Controls.Add(this.textBoxPrenom, 0, 2);
            this.layout.Controls.Add(this.textBoxEmail, 0, 3);
            this.layout.Controls.Add(this.textBoxPassword, 0, 4);
            this.layout.Controls.Add(this.textBoxConfirm, 0, 5);

            // buttonRegister
            this.buttonRegister.Text = "Créer le compte";
            this.buttonRegister.Font = new Font("Segoe UI Semibold", 12F);
            this.buttonRegister.Height = 40;
            this.buttonRegister.Dock = DockStyle.Fill;
            this.buttonRegister.BackColor = Color.FromArgb(0, 120, 215);
            this.buttonRegister.ForeColor = Color.White;
            this.buttonRegister.FlatStyle = FlatStyle.Flat;
            this.buttonRegister.FlatAppearance.BorderSize = 0;
            this.buttonRegister.Click += buttonRegister_Click;
            this.layout.Controls.Add(this.buttonRegister, 0, 6);

            // Ajout layout dans containerPanel
            this.containerPanel.Controls.Add(this.layout);
            this.Controls.Add(this.containerPanel);
        }

        private TextBox CreateInputBox(string placeholder, Font font, Color backColor)
        {
            var box = new TextBox();
            box.Text = placeholder;
            box.Font = font;
            box.Dock = DockStyle.Fill;
            box.Margin = new Padding(0, 5, 0, 5);
            box.ForeColor = Color.Gray;
            box.BackColor = backColor;
            box.Enter += (s, e) =>
            {
                if (box.Text == placeholder)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                }
            };
            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = placeholder;
                    box.ForeColor = Color.Gray;
                }
            };
            return box;
        }
    }
}
