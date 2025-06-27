using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class AjoutAchatForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelNumeroPO;
        private ComboBox comboBoxNumeroPO;

        private Label labelMateriels;
        private CheckedListBox checkedListBoxMateriels;

        private Label labelFournisseurs;
        private CheckedListBox checkedListBoxFournisseurs;

        private Label labelQuantite;
        private TextBox textBoxQuantite;

        private Label labelDate;
        private DateTimePicker dateTimePickerAchat;

        private Label labelNumeroSerie;
        private CheckedListBox checkedListBoxNumSerie;

        internal Button buttonValider;
        internal Button buttonAnnuler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelNumeroPO = new Label();
            this.comboBoxNumeroPO = new ComboBox();
            this.labelMateriels = new Label();
            this.checkedListBoxMateriels = new CheckedListBox();
            this.labelFournisseurs = new Label();
            this.checkedListBoxFournisseurs = new CheckedListBox();
            this.labelQuantite = new Label();
            this.textBoxQuantite = new TextBox();
            this.labelDate = new Label();
            this.dateTimePickerAchat = new DateTimePicker();
            this.labelNumeroSerie = new Label();
            this.checkedListBoxNumSerie = new CheckedListBox();
            this.buttonValider = new Button();
            this.buttonAnnuler = new Button();
            this.SuspendLayout();

            // labelNumeroPO
            this.labelNumeroPO.Location = new System.Drawing.Point(20, 25);
            this.labelNumeroPO.Name = "labelNumeroPO";
            this.labelNumeroPO.Size = new System.Drawing.Size(110, 25);
            this.labelNumeroPO.Text = "Numéro PO :";

            // comboBoxNumeroPO
            this.comboBoxNumeroPO.Location = new System.Drawing.Point(140, 22);
            this.comboBoxNumeroPO.Name = "comboBoxNumeroPO";
            this.comboBoxNumeroPO.Size = new System.Drawing.Size(250, 22);
            this.comboBoxNumeroPO.DropDownStyle = ComboBoxStyle.DropDownList;

            // labelMateriels
            this.labelMateriels.Location = new System.Drawing.Point(20, 70);
            this.labelMateriels.Name = "labelMateriels";
            this.labelMateriels.Size = new System.Drawing.Size(110, 25);
            this.labelMateriels.Text = "Matériels :";

            // checkedListBoxMateriels
            this.checkedListBoxMateriels.Location = new System.Drawing.Point(140, 70);
            this.checkedListBoxMateriels.Name = "checkedListBoxMateriels";
            this.checkedListBoxMateriels.Size = new System.Drawing.Size(250, 89);

            // labelFournisseurs
            this.labelFournisseurs.Location = new System.Drawing.Point(20, 175);
            this.labelFournisseurs.Name = "labelFournisseurs";
            this.labelFournisseurs.Size = new System.Drawing.Size(110, 25);
            this.labelFournisseurs.Text = "Fournisseurs :";

            // checkedListBoxFournisseurs
            this.checkedListBoxFournisseurs.Location = new System.Drawing.Point(140, 175);
            this.checkedListBoxFournisseurs.Name = "checkedListBoxFournisseurs";
            this.checkedListBoxFournisseurs.Size = new System.Drawing.Size(250, 89);

            // labelQuantite
            this.labelQuantite.Location = new System.Drawing.Point(20, 280);
            this.labelQuantite.Name = "labelQuantite";
            this.labelQuantite.Size = new System.Drawing.Size(110, 25);
            this.labelQuantite.Text = "Quantité achetée :";

            // textBoxQuantite
            this.textBoxQuantite.Location = new System.Drawing.Point(140, 280);
            this.textBoxQuantite.Name = "textBoxQuantite";
            this.textBoxQuantite.Size = new System.Drawing.Size(120, 22);

            // labelDate
            this.labelDate.Location = new System.Drawing.Point(20, 325);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(100, 25);
            this.labelDate.Text = "Date achat :";

            // dateTimePickerAchat
            this.dateTimePickerAchat.Format = DateTimePickerFormat.Short;
            this.dateTimePickerAchat.Location = new System.Drawing.Point(140, 325);
            this.dateTimePickerAchat.Name = "dateTimePickerAchat";
            this.dateTimePickerAchat.Size = new System.Drawing.Size(250, 22);

            // labelNumeroSerie
            this.labelNumeroSerie.Location = new System.Drawing.Point(20, 365);
            this.labelNumeroSerie.Name = "labelNumeroSerie";
            this.labelNumeroSerie.Size = new System.Drawing.Size(100, 25);
            this.labelNumeroSerie.Text = "N° Série :";

            // checkedListBoxNumSerie
            this.checkedListBoxNumSerie.Location = new System.Drawing.Point(140, 365);
            this.checkedListBoxNumSerie.Name = "checkedListBoxNumSerie";
            this.checkedListBoxNumSerie.Size = new System.Drawing.Size(250, 50);

            // buttonValider
            this.buttonValider.Location = new System.Drawing.Point(95, 430);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(100, 32);
            this.buttonValider.Text = "Valider";

            // buttonAnnuler
            this.buttonAnnuler.Location = new System.Drawing.Point(225, 430);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(100, 32);
            this.buttonAnnuler.Text = "Annuler";

            // AjoutAchatForm
            this.ClientSize = new System.Drawing.Size(412, 493);
            this.Controls.Add(this.labelNumeroPO);
            this.Controls.Add(this.comboBoxNumeroPO);
            this.Controls.Add(this.labelMateriels);
            this.Controls.Add(this.checkedListBoxMateriels);
            this.Controls.Add(this.labelFournisseurs);
            this.Controls.Add(this.checkedListBoxFournisseurs);
            this.Controls.Add(this.labelQuantite);
            this.Controls.Add(this.textBoxQuantite);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePickerAchat);
            this.Controls.Add(this.labelNumeroSerie);
            this.Controls.Add(this.checkedListBoxNumSerie);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.buttonAnnuler);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(430, 530);
            this.Name = "AjoutAchatForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ajout Achat";
            this.Load += new System.EventHandler(this.AjoutAchatForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
