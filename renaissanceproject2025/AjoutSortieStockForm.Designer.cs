using System.Windows.Forms;

namespace renaissanceproject2025
{
    partial class AjoutSortieStockForm
    {
        private System.ComponentModel.IContainer components = null;
        internal Label lblMateriel;
        internal ComboBox comboMateriel;
        internal Label lblQuantite;
        internal NumericUpDown nudQuantite;
        internal Label lblDate;
        internal DateTimePicker dtpDate;
        internal Label lblRaison;
        internal TextBox txtRaison;
        internal Button btnOk;
        internal Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMateriel = new System.Windows.Forms.Label();
            this.comboMateriel = new System.Windows.Forms.ComboBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.nudQuantite = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblRaison = new System.Windows.Forms.Label();
            this.txtRaison = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMateriel
            // 
            this.lblMateriel.AutoSize = true;
            this.lblMateriel.Location = new System.Drawing.Point(12, 15);
            this.lblMateriel.Name = "lblMateriel";
            this.lblMateriel.Size = new System.Drawing.Size(61, 16);
            this.lblMateriel.TabIndex = 0;
            this.lblMateriel.Text = "Matériel :";
            // 
            // comboMateriel
            // 
            this.comboMateriel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMateriel.Location = new System.Drawing.Point(100, 12);
            this.comboMateriel.Name = "comboMateriel";
            this.comboMateriel.Size = new System.Drawing.Size(200, 24);
            this.comboMateriel.TabIndex = 1;
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(12, 50);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(62, 16);
            this.lblQuantite.TabIndex = 2;
            this.lblQuantite.Text = "Quantité :";
            // 
            // nudQuantite
            // 
            this.nudQuantite.Location = new System.Drawing.Point(100, 48);
            this.nudQuantite.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQuantite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantite.Name = "nudQuantite";
            this.nudQuantite.Size = new System.Drawing.Size(80, 22);
            this.nudQuantite.TabIndex = 3;
            this.nudQuantite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 85);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(100, 82);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 5;
            // 
            // lblRaison
            // 
            this.lblRaison.AutoSize = true;
            this.lblRaison.Location = new System.Drawing.Point(12, 120);
            this.lblRaison.Name = "lblRaison";
            this.lblRaison.Size = new System.Drawing.Size(56, 16);
            this.lblRaison.TabIndex = 6;
            this.lblRaison.Text = "Raison :";
            // 
            // txtRaison
            // 
            this.txtRaison.Location = new System.Drawing.Point(100, 117);
            this.txtRaison.Multiline = true;
            this.txtRaison.Name = "txtRaison";
            this.txtRaison.Size = new System.Drawing.Size(200, 60);
            this.txtRaison.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(100, 190);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(220, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AjoutSortieStockForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.lblMateriel);
            this.Controls.Add(this.comboMateriel);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.nudQuantite);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblRaison);
            this.Controls.Add(this.txtRaison);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AjoutSortieStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajout Sortie Stock";
            //this.Load += new System.EventHandler(this.AjoutSortieStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
