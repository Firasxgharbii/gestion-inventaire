using System;
using System.Windows.Forms;
using System.Drawing;

namespace renaissanceproject2025
{
    partial class AjoutFournisseurForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxNomF;
        private TextBox textBoxTelephoneF;
        private TextBox textBoxAdresseF;
        private TextBox textBoxEmailF;
        private TextBox textBoxNomContact;
        private TextBox textBoxTelephoneContact;
        private TextBox textBoxEmailContact;
        private Button buttonValider;
        private Button buttonAnnuler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxNomF = new System.Windows.Forms.TextBox();
            this.textBoxTelephoneF = new System.Windows.Forms.TextBox();
            this.textBoxAdresseF = new System.Windows.Forms.TextBox();
            this.textBoxEmailF = new System.Windows.Forms.TextBox();
            this.textBoxNomContact = new System.Windows.Forms.TextBox();
            this.textBoxTelephoneContact = new System.Windows.Forms.TextBox();
            this.textBoxEmailContact = new System.Windows.Forms.TextBox();
            this.buttonValider = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNomF
            // 
            this.textBoxNomF.Location = new System.Drawing.Point(30, 20);
            this.textBoxNomF.Name = "textBoxNomF";
            this.textBoxNomF.Size = new System.Drawing.Size(240, 22);
            this.textBoxNomF.TabIndex = 0;
            // 
            // textBoxTelephoneF
            // 
            this.textBoxTelephoneF.Location = new System.Drawing.Point(30, 55);
            this.textBoxTelephoneF.Name = "textBoxTelephoneF";
            this.textBoxTelephoneF.Size = new System.Drawing.Size(240, 22);
            this.textBoxTelephoneF.TabIndex = 1;
            // 
            // textBoxAdresseF
            // 
            this.textBoxAdresseF.Location = new System.Drawing.Point(30, 90);
            this.textBoxAdresseF.Name = "textBoxAdresseF";
            this.textBoxAdresseF.Size = new System.Drawing.Size(240, 22);
            this.textBoxAdresseF.TabIndex = 2;
            // 
            // textBoxEmailF
            // 
            this.textBoxEmailF.Location = new System.Drawing.Point(30, 125);
            this.textBoxEmailF.Name = "textBoxEmailF";
            this.textBoxEmailF.Size = new System.Drawing.Size(240, 22);
            this.textBoxEmailF.TabIndex = 3;
            // 
            // textBoxNomContact
            // 
            this.textBoxNomContact.Location = new System.Drawing.Point(30, 160);
            this.textBoxNomContact.Name = "textBoxNomContact";
            this.textBoxNomContact.Size = new System.Drawing.Size(240, 22);
            this.textBoxNomContact.TabIndex = 4;
            // 
            // textBoxTelephoneContact
            // 
            this.textBoxTelephoneContact.Location = new System.Drawing.Point(30, 195);
            this.textBoxTelephoneContact.Name = "textBoxTelephoneContact";
            this.textBoxTelephoneContact.Size = new System.Drawing.Size(240, 22);
            this.textBoxTelephoneContact.TabIndex = 5;
            // 
            // textBoxEmailContact
            // 
            this.textBoxEmailContact.Location = new System.Drawing.Point(30, 230);
            this.textBoxEmailContact.Name = "textBoxEmailContact";
            this.textBoxEmailContact.Size = new System.Drawing.Size(240, 22);
            this.textBoxEmailContact.TabIndex = 6;
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(30, 270);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(100, 30);
            this.buttonValider.TabIndex = 7;
            this.buttonValider.Text = "Valider";
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(170, 270);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(100, 30);
            this.buttonAnnuler.TabIndex = 8;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // AjoutFournisseurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 330);
            this.Controls.Add(this.textBoxNomF);
            this.Controls.Add(this.textBoxTelephoneF);
            this.Controls.Add(this.textBoxAdresseF);
            this.Controls.Add(this.textBoxEmailF);
            this.Controls.Add(this.textBoxNomContact);
            this.Controls.Add(this.textBoxTelephoneContact);
            this.Controls.Add(this.textBoxEmailContact);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.buttonAnnuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AjoutFournisseurForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter / Modifier un Fournisseur";
            this.Load += new System.EventHandler(this.AjoutFournisseurForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
