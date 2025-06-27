using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class loginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblLogin;
        internal System.Windows.Forms.TextBox textBoxUsername;
        internal System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxAfficherMdp;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.LinkLabel labelForgotPassword;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Load += new System.EventHandler(this.loginForm_Load);

            // Layout principal
            layout = new System.Windows.Forms.TableLayoutPanel();
            layout.ColumnCount = 1;
            layout.RowCount = 6;
            layout.AutoSize = true;
            layout.Padding = new System.Windows.Forms.Padding(20);
            layout.Anchor = System.Windows.Forms.AnchorStyles.None;
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));


            // Titre
            lblLogin = new System.Windows.Forms.Label();
            lblLogin.Text = "Connexion";
            lblLogin.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblLogin.AutoSize = true;
            lblLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            layout.Controls.Add(lblLogin, 0, 0);

            // Email
            textBoxUsername = new System.Windows.Forms.TextBox();
            textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            textBoxUsername.Width = 350;
            textBoxUsername.ForeColor = System.Drawing.Color.Gray;
            textBoxUsername.Text = "Adresse électronique";
            layout.Controls.Add(textBoxUsername, 0, 1);

            // Mot de passe
            textBoxPassword = new System.Windows.Forms.TextBox();
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            textBoxPassword.Width = 350;
            textBoxPassword.ForeColor = System.Drawing.Color.Gray;
            textBoxPassword.Text = "Mot de passe";
            textBoxPassword.UseSystemPasswordChar = false;
            layout.Controls.Add(textBoxPassword, 0, 2);

            // Checkbox mot de passe
            checkBoxAfficherMdp = new System.Windows.Forms.CheckBox();
            checkBoxAfficherMdp.Text = "Afficher le mot de passe";
            checkBoxAfficherMdp.AutoSize = true;
            checkBoxAfficherMdp.CheckedChanged += new System.EventHandler(this.checkBoxAfficherMdp_CheckedChanged);
            layout.Controls.Add(checkBoxAfficherMdp, 0, 3);

            // Bouton de connexion
            buttonLogin = new System.Windows.Forms.Button();
            buttonLogin.Text = "Se connecter";
            buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            buttonLogin.Width = 350;
            buttonLogin.Height = 45;
            buttonLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            buttonLogin.ForeColor = System.Drawing.Color.White;
            buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            layout.Controls.Add(buttonLogin, 0, 4);

            // Panel pour les liens
            linksRow = new System.Windows.Forms.Panel();
            linksRow.Width = 350;
            linksRow.Height = 24;
            linksRow.Anchor = System.Windows.Forms.AnchorStyles.None;

            labelForgotPassword = new System.Windows.Forms.LinkLabel();
            labelForgotPassword.Text = "Mot de passe oublié ?";
            labelForgotPassword.AutoSize = true;
            labelForgotPassword.Location = new System.Drawing.Point(0, 0);
        
            linksRow.Controls.Add(labelForgotPassword);

            labelSignUp = new System.Windows.Forms.LinkLabel();
            labelSignUp.Text = "Créer un compte";
            labelSignUp.AutoSize = true;
            labelSignUp.Click += new System.EventHandler(this.labelSignUp_Click);
            linksRow.Controls.Add(labelSignUp);

            layout.Controls.Add(linksRow, 0, 5);
            this.Controls.Add(layout);
        }
    }
}
