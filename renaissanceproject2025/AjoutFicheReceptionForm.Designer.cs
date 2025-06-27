using System;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class AjoutFicheReceptionForm
    {
        private System.ComponentModel.IContainer components = null;

        internal Label labelNumeroPO;
        internal ComboBox comboBoxNumeroPO;
        internal Label labelQuantiteAchetee;
        internal NumericUpDown numericQuantiteAchetee;
        internal Label labelQuantiteRecu;
        internal NumericUpDown numericQuantiteRecu;
        internal Label labelDateReception;
        internal DateTimePicker dateTimeReception;
        internal Label labelDateAjout;
        internal DateTimePicker dateTimeAjout;
        internal Label labelFournisseur;
        internal ComboBox comboBoxFournisseur;
        internal Label labelMateriel;
        internal ComboBox comboBoxMateriel;
        internal Label labelNumeroSerie;
        internal CheckedListBox checkedListBoxNumSerie;
        internal Label labelObservation;
        internal TextBox textBoxObservation;
        internal Button buttonValider;
        internal Button buttonAnnuler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelNumeroPO = new Label();
            this.comboBoxNumeroPO = new ComboBox();
            this.labelQuantiteAchetee = new Label();
            this.numericQuantiteAchetee = new NumericUpDown();
            this.labelQuantiteRecu = new Label();
            this.numericQuantiteRecu = new NumericUpDown();
            this.labelDateReception = new Label();
            this.dateTimeReception = new DateTimePicker();
            this.labelDateAjout = new Label();
            this.dateTimeAjout = new DateTimePicker();
            this.labelFournisseur = new Label();
            this.comboBoxFournisseur = new ComboBox();
            this.labelMateriel = new Label();
            this.comboBoxMateriel = new ComboBox();
            this.labelNumeroSerie = new Label();
            this.checkedListBoxNumSerie = new CheckedListBox();
            this.labelObservation = new Label();
            this.textBoxObservation = new TextBox();
            this.buttonValider = new Button();
            this.buttonAnnuler = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantiteAchetee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantiteRecu)).BeginInit();
            this.SuspendLayout();

            int y = 15, dy = 35;

            this.labelNumeroPO.AutoSize = true;
            this.labelNumeroPO.Location = new System.Drawing.Point(20, y);
            this.labelNumeroPO.Text = "Numéro PO :";
            this.Controls.Add(this.labelNumeroPO);

            this.comboBoxNumeroPO.Location = new System.Drawing.Point(140, y);
            this.comboBoxNumeroPO.Width = 200;
            this.comboBoxNumeroPO.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(this.comboBoxNumeroPO);
            y += dy;

            this.labelQuantiteAchetee.AutoSize = true;
            this.labelQuantiteAchetee.Location = new System.Drawing.Point(20, y);
            this.labelQuantiteAchetee.Text = "Qté achetée :";
            this.Controls.Add(this.labelQuantiteAchetee);

            this.numericQuantiteAchetee.Location = new System.Drawing.Point(140, y);
            this.numericQuantiteAchetee.Minimum = 0;
            this.numericQuantiteAchetee.Maximum = 1000000;
            this.Controls.Add(this.numericQuantiteAchetee);
            y += dy;

            this.labelQuantiteRecu.AutoSize = true;
            this.labelQuantiteRecu.Location = new System.Drawing.Point(20, y);
            this.labelQuantiteRecu.Text = "Qté reçue :";
            this.Controls.Add(this.labelQuantiteRecu);

            this.numericQuantiteRecu.Location = new System.Drawing.Point(140, y);
            this.numericQuantiteRecu.Minimum = 0;
            this.numericQuantiteRecu.Maximum = 1000000;
            this.Controls.Add(this.numericQuantiteRecu);
            y += dy;

            this.labelDateReception.AutoSize = true;
            this.labelDateReception.Location = new System.Drawing.Point(20, y);
            this.labelDateReception.Text = "Date réception :";
            this.Controls.Add(this.labelDateReception);

            this.dateTimeReception.Format = DateTimePickerFormat.Short;
            this.dateTimeReception.Location = new System.Drawing.Point(140, y);
            this.Controls.Add(this.dateTimeReception);
            y += dy;

            this.labelDateAjout.AutoSize = true;
            this.labelDateAjout.Location = new System.Drawing.Point(20, y);
            this.labelDateAjout.Text = "Date ajout :";
            this.Controls.Add(this.labelDateAjout);

            this.dateTimeAjout.Format = DateTimePickerFormat.Short;
            this.dateTimeAjout.Location = new System.Drawing.Point(140, y);
            this.Controls.Add(this.dateTimeAjout);
            y += dy;

            this.labelFournisseur.AutoSize = true;
            this.labelFournisseur.Location = new System.Drawing.Point(20, y);
            this.labelFournisseur.Text = "Fournisseur :";
            this.Controls.Add(this.labelFournisseur);

            this.comboBoxFournisseur.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxFournisseur.Location = new System.Drawing.Point(140, y);
            this.comboBoxFournisseur.Width = 200;
            this.Controls.Add(this.comboBoxFournisseur);
            y += dy;

            this.labelMateriel.AutoSize = true;
            this.labelMateriel.Location = new System.Drawing.Point(20, y);
            this.labelMateriel.Text = "Matériel :";
            this.Controls.Add(this.labelMateriel);

            this.comboBoxMateriel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxMateriel.Location = new System.Drawing.Point(140, y);
            this.comboBoxMateriel.Width = 200;
            this.Controls.Add(this.comboBoxMateriel);
            y += dy;

            this.labelNumeroSerie.AutoSize = true;
            this.labelNumeroSerie.Location = new System.Drawing.Point(20, y);
            this.labelNumeroSerie.Text = "N° Série :";
            this.Controls.Add(this.labelNumeroSerie);

            this.checkedListBoxNumSerie.Location = new System.Drawing.Point(140, y);
            this.checkedListBoxNumSerie.Width = 200;
            this.checkedListBoxNumSerie.Height = 60;
            this.Controls.Add(this.checkedListBoxNumSerie);
            y += dy + 30;

            this.labelObservation.AutoSize = true;
            this.labelObservation.Location = new System.Drawing.Point(20, y);
            this.labelObservation.Text = "Observation :";
            this.Controls.Add(this.labelObservation);

            this.textBoxObservation.Location = new System.Drawing.Point(140, y);
            this.textBoxObservation.Width = 200;
            this.textBoxObservation.Height = 60;
            this.textBoxObservation.Multiline = true;
            this.Controls.Add(this.textBoxObservation);
            y += dy + 30;

            this.buttonValider.Text = "Valider";
            this.buttonValider.Location = new System.Drawing.Point(80, y);
            this.buttonValider.Size = new System.Drawing.Size(90, 30);
            this.Controls.Add(this.buttonValider);

            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.Location = new System.Drawing.Point(200, y);
            this.buttonAnnuler.Size = new System.Drawing.Size(90, 30);
            this.Controls.Add(this.buttonAnnuler);

            this.ClientSize = new System.Drawing.Size(380, y + 70);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ajouter / Modifier Fiche de Réception";
            this.Load += new EventHandler(this.AjoutFicheReceptionForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantiteAchetee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantiteRecu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
