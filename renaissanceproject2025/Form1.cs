using renaissanceproject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnexionSQL"].ConnectionString;
        private string tableActive = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ChargerTable("Fournisseur");
        }
        private void ChargerTable(string tableName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query;

                    if (tableName == "Achat")
                    {
                        query = @"
                SELECT 
                    A.Id,
                    A.NumeroPO,
                    A.DateAchat,
                    A.QuantiteAchetee,
                    F.NomFournisseur AS Fournisseur,
                    M.Nom AS NomMateriel,
                    M.Type AS TypeMateriel,
                    M.Marque,
                    M.Modele,
                    M.NumeroSerie,
                    M.DateAjout
                FROM Achat A
                LEFT JOIN AchatFournisseur AF ON A.Id = AF.AchatId
                LEFT JOIN Fournisseur F ON AF.FournisseurId = F.Id
                LEFT JOIN AchatMateriel AM ON A.Id = AM.AchatId
                LEFT JOIN Materiel M ON AM.MaterielId = M.Id";
                    }
                    else if (tableName == "FicheReception")
                    {
                        query = @"
                SELECT 
                    FR.Id,
                    FR.NumeroPO,
                    FR.QuantiteCommande,
                    FR.QuantiteRecu,
                    FR.QuantiteCommande - FR.QuantiteRecu AS QuantiteEnAttente,
                    FR.DateReception,
                    FR.DateAjout,
                    FR.Observation,
                    F.NomFournisseur AS Fournisseur,
                    M.Nom AS Materiel
                FROM FicheReception FR
                LEFT JOIN Fournisseur F ON FR.FournisseurId = F.Id
                LEFT JOIN Materiel M ON FR.MaterielId = M.Id";
                    }
                    else if (tableName == "SortieStock")
                    {
                        query = @"
                SELECT 
                    ss.Id,
                    m.Nom AS Materiel,
                    ss.QuantiteSortie,
                    ss.DateSortie,
                    ss.Raison
                FROM SortieStock ss
                JOIN Materiel m ON ss.MaterielId = m.Id";
                    }
                    else
                    {
                        query = "SELECT * FROM " + tableName;
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView2.ScrollBars = ScrollBars.Both;
                    tableActive = tableName;

                    if (dataGridView2.Columns.Contains("Id"))
                        dataGridView2.Columns["Id"].Visible = false;

                    if (tableName == "Achat")
                    {
                        if (dataGridView2.Columns.Contains("QuantiteAchetee"))
                            dataGridView2.Columns["QuantiteAchetee"].HeaderText = "Quantité achetée";
                        if (dataGridView2.Columns.Contains("NomMateriel"))
                            dataGridView2.Columns["NomMateriel"].HeaderText = "Nom";
                        if (dataGridView2.Columns.Contains("TypeMateriel"))
                            dataGridView2.Columns["TypeMateriel"].HeaderText = "Type";
                        if (dataGridView2.Columns.Contains("NumeroSerie"))
                            dataGridView2.Columns["NumeroSerie"].HeaderText = "N° Série";
                    }

                    if (tableName == "FicheReception")
                    {
                        var cols = dataGridView2.Columns;
                        if (cols.Contains("NumeroPO")) cols["NumeroPO"].Width = 120;
                        if (cols.Contains("QuantiteCommande")) cols["QuantiteCommande"].Width = 130;
                        if (cols.Contains("QuantiteRecu")) cols["QuantiteRecu"].Width = 100;
                        if (cols.Contains("QuantiteEnAttente")) cols["QuantiteEnAttente"].Width = 130;
                        if (cols.Contains("DateReception")) cols["DateReception"].Width = 120;
                        if (cols.Contains("DateAjout")) cols["DateAjout"].Width = 120;
                        if (cols.Contains("Observation")) cols["Observation"].Width = 150;
                        if (cols.Contains("Fournisseur")) cols["Fournisseur"].Width = 140;
                        if (cols.Contains("Materiel")) cols["Materiel"].Width = 140;
                    }

                    bool afficherBoutons = tableName == "Fournisseur"
                                        || tableName == "Materiel"
                                        || tableName == "Achat"
                                        || tableName == "FicheReception"
                                        || tableName == "SortieStock";

                    buttonAjouter.Visible = afficherBoutons;
                    buttonModifier.Visible = afficherBoutons;
                    buttonSupprimer.Visible = afficherBoutons;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur de chargement de la table {tableName} : {ex.Message}");
            }
        }



        private void buttonFournisseurs_Click(object sender, EventArgs e) => ChargerTable("Fournisseur");
        private void buttonMateriel_Click(object sender, EventArgs e) => ChargerTable("Materiel");
        private void buttonAchat_Click(object sender, EventArgs e) => ChargerTable("Achat");
        private void buttonFicheReception_Click(object sender, EventArgs e) => ChargerTable("FicheReception");
        private void buttonSortieStock_Click(object sender, EventArgs e) => ChargerTable("SortieStock");
        private void buttonHistorique_Click(object sender, EventArgs e) => ChargerTable("Historique");
        private void buttonStatistiques_Click(object sender, EventArgs e) => MessageBox.Show("📊 Statistiques à venir...");

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            switch (tableActive)
            {
                // ── Fournisseur ────────────────────────────────────────────────────────
                case "Fournisseur":
                    using (var formF = new AjoutFournisseurForm())
                    {
                        if (formF.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
                            INSERT INTO Fournisseur
                              (NomFournisseur, TelephoneFournisseur, AdresseFournisseur, EmailFournisseur,
                               NomContact, TelephoneContact, EmailContact, DateAjout)
                            VALUES
                              (@NomF, @TelF, @AdrF, @EmailF, @NomC, @TelC, @EmailC, GETDATE())", con))
                                {
                                    cmd.Parameters.AddWithValue("@NomF", formF.NomFournisseur);
                                    cmd.Parameters.AddWithValue("@TelF", formF.TelephoneFournisseur);
                                    cmd.Parameters.AddWithValue("@AdrF", formF.AdresseFournisseur);
                                    cmd.Parameters.AddWithValue("@EmailF", formF.EmailFournisseur);
                                    cmd.Parameters.AddWithValue("@NomC", formF.NomContact);
                                    cmd.Parameters.AddWithValue("@TelC", formF.TelephoneContact);
                                    cmd.Parameters.AddWithValue("@EmailC", formF.EmailContact);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            ChargerTable("Fournisseur");
                            MessageBox.Show("✅ Fournisseur ajouté !");
                        }
                    }
                    break;

                // ── Matériel ────────────────────────────────────────────────────────────
                case "Materiel":
                    using (var formM = new AjoutMaterielForm())
                    {
                        if (formM.ShowDialog() == DialogResult.OK)
                        {
                            ChargerTable("Materiel");
                            MessageBox.Show("✅ Matériel ajouté !");
                        }
                    }
                    break;

                // ── Achat ───────────────────────────────────────────────────────────────
                case "Achat":
                    using (var formA = new AjoutAchatForm())
                    {
                        if (formA.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();

                                // 1) Insertion principale dans Achat + récupération de l’ID
                                int achatId;
                                using (var cmd = new SqlCommand(@"
INSERT INTO Achat (NumeroPO, QuantiteAchetee, DateAchat)
OUTPUT INSERTED.Id
VALUES (@PO, @Quantite, @Date)", con))
                                {
                                    cmd.Parameters.AddWithValue("@PO", formA.NumeroPO);
                                    cmd.Parameters.AddWithValue("@Quantite", formA.QuantiteAchetee);
                                    cmd.Parameters.AddWithValue("@Date", formA.DateAchat);
                                    achatId = (int)cmd.ExecuteScalar();
                                }

                                // 2) Liaisons avec les fournisseurs
                                foreach (int fid in formA.FournisseurIds)
                                {
                                    using (var cmdF = new SqlCommand(
                                        "INSERT INTO AchatFournisseur (AchatId, FournisseurId) VALUES (@A, @F)", con))
                                    {
                                        cmdF.Parameters.AddWithValue("@A", achatId);
                                        cmdF.Parameters.AddWithValue("@F", fid);
                                        cmdF.ExecuteNonQuery();
                                    }
                                }

                                // 3) Liaisons avec les matériels
                                foreach (int mid in formA.MaterielIds)
                                {
                                    using (var cmdM = new SqlCommand(
                                        "INSERT INTO AchatMateriel (AchatId, MaterielId) VALUES (@A, @M)", con))
                                    {
                                        cmdM.Parameters.AddWithValue("@A", achatId);
                                        cmdM.Parameters.AddWithValue("@M", mid);
                                        cmdM.ExecuteNonQuery();
                                    }
                                }
                            }

                            ChargerTable("Achat");
                            MessageBox.Show("✅ Achat ajouté avec fournisseurs et matériels !");
                        }
                    }
                    break;


                // ── Fiche Réception ────────────────────────────────────────────────────
                case "FicheReception":
                    using (var formR = new AjoutFicheReceptionForm())
                    {
                        if (formR.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
                    INSERT INTO FicheReception
                        (NumeroPO, QuantiteCommande, QuantiteRecu,
                         DateAjout, DateReception,
                         Observation, FournisseurId, MaterielId)
                    VALUES
                        (@PO, @QCmd, @QRec,
                         @DAjout, @DRec,
                         @Obs, @FId, @MId)", con))
                                {
                                    cmd.Parameters.AddWithValue("@PO", formR.NumeroPO);
                                    cmd.Parameters.AddWithValue("@QCmd", formR.QuantiteCommande);
                                    cmd.Parameters.AddWithValue("@QRec", formR.QuantiteRecu);
                                    cmd.Parameters.AddWithValue("@DAjout", formR.DateAjout);         // Date d'ajout
                                    cmd.Parameters.AddWithValue("@DRec", formR.DateReception);       // Date de réception
                                    cmd.Parameters.AddWithValue("@Obs", formR.Observation ?? "");    // Observation (vide si null)
                                    cmd.Parameters.AddWithValue("@FId", formR.FournisseurId);        // Fournisseur ID
                                    cmd.Parameters.AddWithValue("@MId", formR.MaterielId);           // Matériel ID

                                    cmd.ExecuteNonQuery();
                                }

                                // Enregistrer aussi le numéro de série sélectionné dans FicheReceptionSerie s’il y en a un
                                if (!string.IsNullOrEmpty(formR.NumeroSerieSelectionne))
                                {
                                    using (var cmdSerie = new SqlCommand(@"
                        INSERT INTO FicheReceptionSerie (FicheReceptionId, MaterielSerieId)
                        SELECT IDENT_CURRENT('FicheReception'), Id
                        FROM Materiel
                        WHERE NumeroSerie = @NumSerie", con))
                                    {
                                        cmdSerie.Parameters.AddWithValue("@NumSerie", formR.NumeroSerieSelectionne);
                                        cmdSerie.ExecuteNonQuery();
                                    }
                                }
                            }

                            ChargerTable("FicheReception");
                            MessageBox.Show("✅ Fiche de réception ajoutée !");
                        }
                    }
                    break;




                // ── Sortie Stock ───────────────────────────────────────────────────────
                case "SortieStock":
                    using (var formS = new AjoutSortieStockForm())
                    {
                        if (formS.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
                            INSERT INTO SortieStock
                              (MaterielId, QuantiteSortie, DateSortie, Raison)
                            VALUES
                              (@M, @Q, @D, @R)", con))
                                {
                                    cmd.Parameters.AddWithValue("@M", formS.MaterielId);
                                    cmd.Parameters.AddWithValue("@Q", formS.Quantite);
                                    cmd.Parameters.AddWithValue("@D", formS.DateSortie);
                                    cmd.Parameters.AddWithValue("@R", formS.Raison);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            ChargerTable("SortieStock");
                            MessageBox.Show("✅ Sortie stock ajoutée !");
                        }
                    }
                    break;

                // ── Par défaut ─────────────────────────────────────────────────────────
                default:
                    MessageBox.Show(
                        $"Ajout dans la table « {tableActive} » non implémenté.",
                        "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                    break;
            }
        }







        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // 1) Vérifier qu’une ligne est sélectionnée
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une ligne à modifier.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2) Récupérer la ligne et l’ID
            var row = dataGridView2.SelectedRows[0];
            if (!dataGridView2.Columns.Contains("Id"))
            {
                MessageBox.Show(
                    "La colonne 'Id' est absente.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            // 3) En fonction de la table active
            switch (tableActive)
            {
                case "Fournisseur":
                    {
                        var formF = new AjoutFournisseurForm(new string[]
                        {
                    row.Cells["NomFournisseur"].Value?.ToString(),
                    row.Cells["TelephoneFournisseur"].Value?.ToString(),
                    row.Cells["AdresseFournisseur"].Value?.ToString(),
                    row.Cells["EmailFournisseur"].Value?.ToString(),
                    row.Cells["NomContact"].Value?.ToString(),
                    row.Cells["TelephoneContact"].Value?.ToString(),
                    row.Cells["EmailContact"].Value?.ToString(),
                        });
                        if (formF.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
UPDATE Fournisseur SET
  NomFournisseur       = @NomF,
  TelephoneFournisseur = @TelF,
  AdresseFournisseur   = @AdrF,
  EmailFournisseur     = @EmailF,
  NomContact           = @NomC,
  TelephoneContact     = @TelC,
  EmailContact         = @EmailC
WHERE Id = @Id", con))
                                {
                                    cmd.Parameters.AddWithValue("@NomF", formF.NomFournisseur);
                                    cmd.Parameters.AddWithValue("@TelF", formF.TelephoneFournisseur);
                                    cmd.Parameters.AddWithValue("@AdrF", formF.AdresseFournisseur);
                                    cmd.Parameters.AddWithValue("@EmailF", formF.EmailFournisseur);
                                    cmd.Parameters.AddWithValue("@NomC", formF.NomContact);
                                    cmd.Parameters.AddWithValue("@TelC", formF.TelephoneContact);
                                    cmd.Parameters.AddWithValue("@EmailC", formF.EmailContact);
                                    cmd.Parameters.AddWithValue("@Id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            ChargerTable("Fournisseur");
                            MessageBox.Show("✏️ Fournisseur modifié !");
                        }
                        break;
                    }

                case "Materiel":
                    {
                        var formM = new AjoutMaterielForm(
                            row.Cells["Nom"].Value?.ToString(),
                            row.Cells["Type"].Value?.ToString(),
                            row.Cells["Marque"].Value?.ToString(),
                            row.Cells["Modele"].Value?.ToString(),
                           
                            row.Cells["NumeroSerie"].Value?.ToString(),
                            row.Cells["FournisseurNom"].Value?.ToString(),
                            id
                        );
                        if (formM.ShowDialog() == DialogResult.OK)
                        {
                            ChargerTable("Materiel");
                            MessageBox.Show("✏️ Matériel modifié !");
                        }
                        break;
                    }
                case "Achat":
                    {
                        // Lecture des données
                        int achatId = Convert.ToInt32(row.Cells["Id"].Value);
                        string numeroPO = row.Cells["NumeroPO"].Value?.ToString();
                        DateTime dateAchat = Convert.ToDateTime(row.Cells["DateAchat"].Value);
                        int quantiteAchetee = Convert.ToInt32(row.Cells["QuantiteAchetee"].Value); // 🔥 Ajout ici

                        // Initialisation des listes de liaison
                        var fournisseurIds = new List<int>();
                        var materielIds = new List<int>();

                        // Vérification et lecture des ID si présents
                        if (row.DataGridView.Columns.Contains("FournisseurId") && row.Cells["FournisseurId"].Value != null)
                            fournisseurIds.Add(Convert.ToInt32(row.Cells["FournisseurId"].Value));

                        if (row.DataGridView.Columns.Contains("MaterielId") && row.Cells["MaterielId"].Value != null)
                            materielIds.Add(Convert.ToInt32(row.Cells["MaterielId"].Value));

                        // Ouverture du formulaire de modification
                        var formA = new AjoutAchatForm(
                            achatId,
                            numeroPO,
                            materielIds,
                            fournisseurIds,
                            quantiteAchetee, // ✅ Correctement positionné
                            dateAchat
                        );

                        if (formA.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();

                                // Mise à jour de la table Achat (incluant QuantiteAchetee)
                                using (var cmd = new SqlCommand(@"
UPDATE Achat SET
    NumeroPO         = @PO,
    QuantiteAchetee  = @Qte,
    DateAchat        = @Date
WHERE Id = @Id", con)) // ✅ Mise à jour ici
                                {
                                    cmd.Parameters.AddWithValue("@PO", formA.NumeroPO);
                                    cmd.Parameters.AddWithValue("@Qte", formA.QuantiteAchetee); // 🔥 Ajouté
                                    cmd.Parameters.AddWithValue("@Date", formA.DateAchat);
                                    cmd.Parameters.AddWithValue("@Id", achatId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Suppression des anciennes liaisons
                                using (var cmdSup1 = new SqlCommand("DELETE FROM AchatFournisseur WHERE AchatId = @Id", con))
                                {
                                    cmdSup1.Parameters.AddWithValue("@Id", achatId);
                                    cmdSup1.ExecuteNonQuery();
                                }

                                using (var cmdSup2 = new SqlCommand("DELETE FROM AchatMateriel WHERE AchatId = @Id", con))
                                {
                                    cmdSup2.Parameters.AddWithValue("@Id", achatId);
                                    cmdSup2.ExecuteNonQuery();
                                }

                                // Insertion des nouvelles liaisons fournisseurs
                                foreach (int fid in formA.FournisseurIds)
                                {
                                    using (var cmdF = new SqlCommand("INSERT INTO AchatFournisseur (AchatId, FournisseurId) VALUES (@A, @F)", con))
                                    {
                                        cmdF.Parameters.AddWithValue("@A", achatId);
                                        cmdF.Parameters.AddWithValue("@F", fid);
                                        cmdF.ExecuteNonQuery();
                                    }
                                }

                                // Insertion des nouvelles liaisons matériels
                                foreach (int mid in formA.MaterielIds)
                                {
                                    using (var cmdM = new SqlCommand("INSERT INTO AchatMateriel (AchatId, MaterielId) VALUES (@A, @M)", con))
                                    {
                                        cmdM.Parameters.AddWithValue("@A", achatId);
                                        cmdM.Parameters.AddWithValue("@M", mid);
                                        cmdM.ExecuteNonQuery();
                                    }
                                }
                            }

                            ChargerTable("Achat");
                            MessageBox.Show("✏️ Achat modifié !");
                        }

                        break;
                    }





                case "FicheReception":
                    {
                        // ✅ Vérification des colonnes (si chargement personnalisé)
                        bool hasFournisseurId = row.DataGridView.Columns.Contains("FournisseurId");
                        bool hasMaterielId = row.DataGridView.Columns.Contains("MaterielId");

                        int fournisseurId = hasFournisseurId && row.Cells["FournisseurId"].Value != null
                            ? Convert.ToInt32(row.Cells["FournisseurId"].Value)
                            : 0;

                        int materielId = hasMaterielId && row.Cells["MaterielId"].Value != null
                            ? Convert.ToInt32(row.Cells["MaterielId"].Value)
                            : 0;

                        var formR = new AjoutFicheReceptionForm(
                            row.Cells["NumeroPO"].Value?.ToString(),
                            Convert.ToInt32(row.Cells["QuantiteCommande"].Value),
                            Convert.ToInt32(row.Cells["QuantiteRecu"].Value),
                            Convert.ToDateTime(row.Cells["DateReception"].Value),
                           
                            row.Cells["Observation"].Value?.ToString(),
                            fournisseurId,
                            materielId,
                            id
                        );

                        if (formR.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
UPDATE FicheReception SET
    QuantiteRecu        = @QRec,
    DateReception       = @DRec,
    DatePrevueReception = @DPrev,
    Observation         = @Obs
WHERE Id = @Id", con))
                                {
                                    cmd.Parameters.AddWithValue("@QRec", formR.QuantiteRecu);
                                    cmd.Parameters.AddWithValue("@DRec", formR.DateReception);
                                   
                                    cmd.Parameters.AddWithValue("@Obs", formR.Observation ?? "");
                                    cmd.Parameters.AddWithValue("@Id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            ChargerTable("FicheReception");
                            MessageBox.Show("✏️ Fiche de réception modifiée !");
                        }

                        break;
                    }

                case "SortieStock":
                    {
                        // ✅ Récupérer le nom du matériel affiché (jointure avec Materiel)
                        string nomMateriel = row.Cells["Materiel"].Value?.ToString();

                        int materielId = -1;

                        using (var con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            using (var cmd = new SqlCommand("SELECT Id FROM Materiel WHERE Nom = @nom", con))
                            {
                                cmd.Parameters.AddWithValue("@nom", nomMateriel);
                                object result = cmd.ExecuteScalar();
                                if (result != null)
                                    materielId = Convert.ToInt32(result);
                                else
                                {
                                    MessageBox.Show("❌ Matériel introuvable dans la base de données.");
                                    return;
                                }
                            }
                        }

                        var formS = new AjoutSortieStockForm(
                            materielId,
                            Convert.ToInt32(row.Cells["QuantiteSortie"].Value),
                            Convert.ToDateTime(row.Cells["DateSortie"].Value),
                            row.Cells["Raison"].Value?.ToString()
                        );

                        if (formS.ShowDialog() == DialogResult.OK)
                        {
                            using (var con = new SqlConnection(connectionString))
                            {
                                con.Open();
                                using (var cmd = new SqlCommand(@"
UPDATE SortieStock SET
    MaterielId = @M,
    QuantiteSortie = @Q,
    DateSortie = @D,
    Raison = @R
WHERE Id = @Id", con))
                                {
                                    cmd.Parameters.AddWithValue("@M", formS.MaterielId);
                                    cmd.Parameters.AddWithValue("@Q", formS.Quantite);
                                    cmd.Parameters.AddWithValue("@D", formS.DateSortie);
                                    cmd.Parameters.AddWithValue("@R", formS.Raison ?? "");
                                    cmd.Parameters.AddWithValue("@Id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            ChargerTable("SortieStock");
                            MessageBox.Show("✅ Sortie stock modifiée !");
                        }

                        break;
                    }
            }
        }



        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // 1) Vérifier qu’une ligne est sélectionnée
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une ligne à supprimer.",
                    "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            // 2) Récupérer la ligne et l’ID
            var row = dataGridView2.SelectedRows[0];
            if (!dataGridView2.Columns.Contains("Id"))
            {
                MessageBox.Show(
                    "La colonne 'Id' est absente.",
                    "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 3) Cas spéciaux avant suppression principale
                    if (tableActive == "Achat")
                    {
                        using (var delM = new SqlCommand(
                            "DELETE FROM AchatMateriel WHERE AchatId = @Id", con))
                        {
                            delM.Parameters.AddWithValue("@Id", id);
                            delM.ExecuteNonQuery();
                        }
                        using (var delF = new SqlCommand(
                            "DELETE FROM AchatFournisseur WHERE AchatId = @Id", con))
                        {
                            delF.Parameters.AddWithValue("@Id", id);
                            delF.ExecuteNonQuery();
                        }
                    }
                    else if (tableActive == "Fournisseur")
                    {
                        using (var delFR = new SqlCommand(
                            "DELETE FROM FicheReception WHERE FournisseurId = @Id", con))
                        {
                            delFR.Parameters.AddWithValue("@Id", id);
                            delFR.ExecuteNonQuery();
                        }
                        using (var delAF = new SqlCommand(
                            "DELETE FROM AchatFournisseur WHERE FournisseurId = @Id", con))
                        {
                            delAF.Parameters.AddWithValue("@Id", id);
                            delAF.ExecuteNonQuery();
                        }
                    }
                    else if (tableActive == "Materiel")
                    {
                        using (var delAM = new SqlCommand(
                            "DELETE FROM AchatMateriel WHERE MaterielId = @Id", con))
                        {
                            delAM.Parameters.AddWithValue("@Id", id);
                            delAM.ExecuteNonQuery();
                        }
                    }
                    // FicheReception et SortieStock n'ont pas de tables de liaison externes

                    // 4) Suppression principale
                    using (var cmd = new SqlCommand(
                        $"DELETE FROM {tableActive} WHERE Id = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // 5) Rafraîchir la grille
                ChargerTable(tableActive);
                MessageBox.Show(
                    "🗑️ Enregistrement supprimé !",
                    "Suppression",
                    MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Erreur lors de la suppression : {ex.Message}",
                    "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }




        private void buttonRetour_Click(object sender, EventArgs e)
        {
            this.Hide();
            new loginForm().Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Utilisable plus tard si nécessaire
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
