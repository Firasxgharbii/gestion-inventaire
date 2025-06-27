namespace renaissanceproject2025
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button buttonFournisseurs;
        private System.Windows.Forms.Button buttonMateriel;
        private System.Windows.Forms.Button buttonAchat;
        private System.Windows.Forms.Button buttonFicheReception;
        private System.Windows.Forms.Button buttonSortieStock;
        private System.Windows.Forms.Button buttonHistorique;
        private System.Windows.Forms.Button buttonStatistiques;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel bottomLeftPanel;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Panel bottomRightPanel;
        private System.Windows.Forms.Button buttonRetour;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.buttonFournisseurs = new System.Windows.Forms.Button();
            this.buttonMateriel = new System.Windows.Forms.Button();
            this.buttonAchat = new System.Windows.Forms.Button();
            this.buttonFicheReception = new System.Windows.Forms.Button();
            this.buttonSortieStock = new System.Windows.Forms.Button();
            this.buttonHistorique = new System.Windows.Forms.Button();
            this.buttonStatistiques = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bottomLeftPanel = new System.Windows.Forms.Panel();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.buttonRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.topPanel.SuspendLayout();
            this.bottomLeftPanel.SuspendLayout();
            this.bottomRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.buttonFournisseurs);
            this.topPanel.Controls.Add(this.buttonMateriel);
            this.topPanel.Controls.Add(this.buttonAchat);
            this.topPanel.Controls.Add(this.buttonFicheReception);
            this.topPanel.Controls.Add(this.buttonSortieStock);
            this.topPanel.Controls.Add(this.buttonHistorique);
            this.topPanel.Controls.Add(this.buttonStatistiques);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.topPanel.Size = new System.Drawing.Size(1280, 50);
            this.topPanel.TabIndex = 0;
            // 
            // buttonFournisseurs
            // 
            this.buttonFournisseurs.Location = new System.Drawing.Point(10, 10);
            this.buttonFournisseurs.Name = "buttonFournisseurs";
            this.buttonFournisseurs.Size = new System.Drawing.Size(120, 30);
            this.buttonFournisseurs.TabIndex = 0;
            this.buttonFournisseurs.Text = "Fournisseurs";
            this.buttonFournisseurs.UseVisualStyleBackColor = true;
            this.buttonFournisseurs.Click += new System.EventHandler(this.buttonFournisseurs_Click);
            // 
            // buttonMateriel
            // 
            this.buttonMateriel.Location = new System.Drawing.Point(140, 10);
            this.buttonMateriel.Name = "buttonMateriel";
            this.buttonMateriel.Size = new System.Drawing.Size(120, 30);
            this.buttonMateriel.TabIndex = 1;
            this.buttonMateriel.Text = "Matériel";
            this.buttonMateriel.UseVisualStyleBackColor = true;
            this.buttonMateriel.Click += new System.EventHandler(this.buttonMateriel_Click);
            // 
            // buttonAchat
            // 
            this.buttonAchat.Location = new System.Drawing.Point(270, 10);
            this.buttonAchat.Name = "buttonAchat";
            this.buttonAchat.Size = new System.Drawing.Size(120, 30);
            this.buttonAchat.TabIndex = 2;
            this.buttonAchat.Text = "Achats";
            this.buttonAchat.UseVisualStyleBackColor = true;
            this.buttonAchat.Click += new System.EventHandler(this.buttonAchat_Click);
            // 
            // buttonFicheReception
            // 
            this.buttonFicheReception.Location = new System.Drawing.Point(400, 10);
            this.buttonFicheReception.Name = "buttonFicheReception";
            this.buttonFicheReception.Size = new System.Drawing.Size(120, 30);
            this.buttonFicheReception.TabIndex = 3;
            this.buttonFicheReception.Text = "Fiche Réception";
            this.buttonFicheReception.UseVisualStyleBackColor = true;
            this.buttonFicheReception.Click += new System.EventHandler(this.buttonFicheReception_Click);
            // 
            // buttonSortieStock
            // 
            this.buttonSortieStock.Location = new System.Drawing.Point(530, 10);
            this.buttonSortieStock.Name = "buttonSortieStock";
            this.buttonSortieStock.Size = new System.Drawing.Size(120, 30);
            this.buttonSortieStock.TabIndex = 4;
            this.buttonSortieStock.Text = "Sortie Stock";
            this.buttonSortieStock.UseVisualStyleBackColor = true;
            this.buttonSortieStock.Click += new System.EventHandler(this.buttonSortieStock_Click);
            // 
            // buttonHistorique
            // 
            this.buttonHistorique.Location = new System.Drawing.Point(660, 10);
            this.buttonHistorique.Name = "buttonHistorique";
            this.buttonHistorique.Size = new System.Drawing.Size(120, 30);
            this.buttonHistorique.TabIndex = 5;
            this.buttonHistorique.Text = "Historique";
            this.buttonHistorique.UseVisualStyleBackColor = true;
            this.buttonHistorique.Click += new System.EventHandler(this.buttonHistorique_Click);
            // 
            // buttonStatistiques
            // 
            this.buttonStatistiques.Location = new System.Drawing.Point(790, 10);
            this.buttonStatistiques.Name = "buttonStatistiques";
            this.buttonStatistiques.Size = new System.Drawing.Size(120, 30);
            this.buttonStatistiques.TabIndex = 6;
            this.buttonStatistiques.Text = "Statistiques";
            this.buttonStatistiques.UseVisualStyleBackColor = true;
            this.buttonStatistiques.Click += new System.EventHandler(this.buttonStatistiques_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 50);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1280, 500);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // bottomLeftPanel
            // 
            this.bottomLeftPanel.Controls.Add(this.buttonAjouter);
            this.bottomLeftPanel.Controls.Add(this.buttonModifier);
            this.bottomLeftPanel.Controls.Add(this.buttonSupprimer);
            this.bottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomLeftPanel.Location = new System.Drawing.Point(0, 550);
            this.bottomLeftPanel.Name = "bottomLeftPanel";
            this.bottomLeftPanel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.bottomLeftPanel.Size = new System.Drawing.Size(1280, 50);
            this.bottomLeftPanel.TabIndex = 8;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Location = new System.Drawing.Point(10, 10);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(100, 30);
            this.buttonAjouter.TabIndex = 0;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Location = new System.Drawing.Point(120, 10);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(100, 30);
            this.buttonModifier.TabIndex = 1;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = true;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(230, 10);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(100, 30);
            this.buttonSupprimer.TabIndex = 2;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.Controls.Add(this.buttonRetour);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRightPanel.Location = new System.Drawing.Point(0, 600);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.bottomRightPanel.Size = new System.Drawing.Size(1280, 50);
            this.bottomRightPanel.TabIndex = 9;
            // 
            // buttonRetour
            // 
            this.buttonRetour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRetour.Location = new System.Drawing.Point(1170, 10);
            this.buttonRetour.Name = "buttonRetour";
            this.buttonRetour.Size = new System.Drawing.Size(100, 30);
            this.buttonRetour.TabIndex = 0;
            this.buttonRetour.Text = "Retour";
            this.buttonRetour.UseVisualStyleBackColor = true;
            this.buttonRetour.Click += new System.EventHandler(this.buttonRetour_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 650);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.bottomLeftPanel);
            this.Controls.Add(this.bottomRightPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.Text = "Gestion de Matériel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.bottomLeftPanel.ResumeLayout(false);
            this.bottomRightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
