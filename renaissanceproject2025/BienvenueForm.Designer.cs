using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class BienvenueForm
    {
        private IContainer components = null;
        private Button btnBienvenue;

        /// <summary>Nettoyage des ressources utilisées.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>Initialisation du Designer WinForms</summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.btnBienvenue = new Button();

            // 
            // btnBienvenue
            // 
            this.btnBienvenue.Name = "btnBienvenue";
            this.btnBienvenue.Text = "Bienvenue";
            this.btnBienvenue.Size = new Size(140, 40);
            this.btnBienvenue.UseVisualStyleBackColor = true;
            this.btnBienvenue.Click += new EventHandler(this.btnBienvenue_Click);

            // 
            // BienvenueForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1024, 768);
            this.Controls.Add(this.btnBienvenue);
            this.Name = "BienvenueForm";
            this.Load += new EventHandler(this.BienvenueForm_Load);
            this.ResumeLayout(false);
        }
    }
}
