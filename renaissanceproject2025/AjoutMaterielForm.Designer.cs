namespace renaissanceproject2025
{
    partial class AjoutMaterielForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelMarque;
        private System.Windows.Forms.Label labelModele;
        private System.Windows.Forms.Label labelNumeroSerie;
        private System.Windows.Forms.Label labelFournisseurNom;

        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxMarque;
        private System.Windows.Forms.TextBox textBoxModele;
        private System.Windows.Forms.TextBox textBoxNumeroSerie;

        private System.Windows.Forms.CheckedListBox checkedListBoxFournisseurs;

        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.Button buttonAnnuler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelNom = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelMarque = new System.Windows.Forms.Label();
            this.labelModele = new System.Windows.Forms.Label();
            this.labelNumeroSerie = new System.Windows.Forms.Label();
            this.labelFournisseurNom = new System.Windows.Forms.Label();

            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxMarque = new System.Windows.Forms.TextBox();
            this.textBoxModele = new System.Windows.Forms.TextBox();
            this.textBoxNumeroSerie = new System.Windows.Forms.TextBox();

            this.checkedListBoxFournisseurs = new System.Windows.Forms.CheckedListBox();

            this.buttonValider = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Label + TextBox : Nom
            labelNom.Text = "Nom :";
            labelNom.Location = new System.Drawing.Point(30, 20);
            textBoxNom.Location = new System.Drawing.Point(150, 20);

            // Type
            labelType.Text = "Type :";
            labelType.Location = new System.Drawing.Point(30, 50);
            textBoxType.Location = new System.Drawing.Point(150, 50);

            // Marque
            labelMarque.Text = "Marque :";
            labelMarque.Location = new System.Drawing.Point(30, 80);
            textBoxMarque.Location = new System.Drawing.Point(150, 80);

            // Modèle
            labelModele.Text = "Modèle :";
            labelModele.Location = new System.Drawing.Point(30, 110);
            textBoxModele.Location = new System.Drawing.Point(150, 110);

            // Numéro de série
            labelNumeroSerie.Text = "Numéro de série :";
            labelNumeroSerie.Location = new System.Drawing.Point(30, 140);
            textBoxNumeroSerie.Location = new System.Drawing.Point(150, 140);

            // Fournisseur
            labelFournisseurNom.Text = "Fournisseur(s) :";
            labelFournisseurNom.Location = new System.Drawing.Point(30, 170);
            checkedListBoxFournisseurs.Location = new System.Drawing.Point(150, 170);
            checkedListBoxFournisseurs.Size = new System.Drawing.Size(200, 80);

            // Valider
            buttonValider.Text = "Valider";
            buttonValider.Location = new System.Drawing.Point(100, 270);
            buttonValider.Size = new System.Drawing.Size(90, 30);
            buttonValider.Click += new System.EventHandler(this.buttonValider_Click);

            // Annuler
            buttonAnnuler.Text = "Annuler";
            buttonAnnuler.Location = new System.Drawing.Point(200, 270);
            buttonAnnuler.Size = new System.Drawing.Size(90, 30);
            buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);

            // Ajouter les contrôles
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                labelNom, textBoxNom,
                labelType, textBoxType,
                labelMarque, textBoxMarque,
                labelModele, textBoxModele,
                labelNumeroSerie, textBoxNumeroSerie,
                labelFournisseurNom, checkedListBoxFournisseurs,
                buttonValider, buttonAnnuler
            });

            this.ClientSize = new System.Drawing.Size(400, 330);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter / Modifier un Matériel";
            this.Load += new System.EventHandler(this.AjoutMaterielForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
