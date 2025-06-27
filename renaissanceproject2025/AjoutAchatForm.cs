using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class AjoutAchatForm : Form
    {
        private readonly string _cs = ConfigurationManager
            .ConnectionStrings["ConnexionSQL"].ConnectionString;

        private readonly int? _existingId;
        private readonly List<int> _existingMatIds;
        private readonly List<int> _existingFouIds;
        private readonly int? _existingQuantite;
        private readonly DateTime? _existingDate;

        public string NumeroPO { get; private set; }
        public int QuantiteAchetee { get; private set; }
        public DateTime DateAchat { get; private set; }

        public List<int> MaterielIds => checkedListBoxMateriels.CheckedItems
                                              .Cast<ListItem>().Select(i => i.Value).ToList();

        public List<int> FournisseurIds => checkedListBoxFournisseurs.CheckedItems
                                              .Cast<ListItem>().Select(i => i.Value).ToList();

        public List<string> NumerosSerie => checkedListBoxNumSerie.CheckedItems
                                                .Cast<string>().ToList();

        public AjoutAchatForm()
        {
            InitializeComponent();
            Load += AjoutAchatForm_Load;
            buttonAnnuler.Click += (_, __) => Close();

            checkedListBoxFournisseurs.ItemCheck += CheckedListBoxFournisseurs_ItemCheck;
            checkedListBoxMateriels.ItemCheck += CheckedListBoxMateriels_ItemCheck;
        }

        public AjoutAchatForm(int achatId,
                              string numeroPO,
                              IEnumerable<int> matIds,
                              IEnumerable<int> fouIds,
                              int quantiteAchetee,
                              DateTime dateAchat) : this()
        {
            _existingId = achatId;
            comboBoxNumeroPO.Text = numeroPO;
            _existingMatIds = matIds.ToList();
            _existingFouIds = fouIds.ToList();
            _existingQuantite = quantiteAchetee;
            _existingDate = dateAchat;
        }

        private void AjoutAchatForm_Load(object sender, EventArgs e)
        {
            if (_existingQuantite.HasValue)
                textBoxQuantite.Text = _existingQuantite.Value.ToString();

            if (_existingDate.HasValue)
                dateTimePickerAchat.Value = _existingDate.Value;

            ChargerPO();
            ChargerMateriels();
            ChargerFournisseurs();
            ChargerNumerosSerie();

            if (_existingMatIds != null)
            {
                for (int i = 0; i < checkedListBoxMateriels.Items.Count; i++)
                {
                    if (_existingMatIds.Contains(((ListItem)checkedListBoxMateriels.Items[i]).Value))
                        checkedListBoxMateriels.SetItemChecked(i, true);
                }
            }

            if (_existingFouIds != null)
            {
                for (int i = 0; i < checkedListBoxFournisseurs.Items.Count; i++)
                {
                    if (_existingFouIds.Contains(((ListItem)checkedListBoxFournisseurs.Items[i]).Value))
                        checkedListBoxFournisseurs.SetItemChecked(i, true);
                }
            }

            buttonValider.Click += buttonValider_Click;
        }

        private void ChargerPO()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT NumeroPO FROM Achat", con))
                {
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            comboBoxNumeroPO.Items.Add(rdr.GetString(0));
                        }
                    }
                }
            }
        }

        private void ChargerMateriels()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nom FROM Materiel", con))
                {
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            checkedListBoxMateriels.Items.Add(
                                new ListItem(rdr.GetString(1), rdr.GetInt32(0))
                            );
                        }
                    }
                }
            }
        }

        private void ChargerFournisseurs()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, NomFournisseur FROM Fournisseur", con))
                {
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            checkedListBoxFournisseurs.Items.Add(
                                new ListItem(rdr.GetString(1), rdr.GetInt32(0))
                            );
                        }
                    }
                }
            }
        }

        private void ChargerNumerosSerie()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT NumeroSerie FROM Materiel", con))
                {
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            checkedListBoxNumSerie.Items.Add(rdr.GetString(0));
                        }
                    }
                }
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxNumeroPO.Text)
                || !int.TryParse(textBoxQuantite.Text, out var qte)
                || checkedListBoxMateriels.CheckedItems.Count == 0
                || checkedListBoxFournisseurs.CheckedItems.Count == 0)
            {
                MessageBox.Show("Tous les champs sont obligatoires.",
                                "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NumeroPO = comboBoxNumeroPO.Text.Trim();
            QuantiteAchetee = qte;
            DateAchat = dateTimePickerAchat.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CheckedListBoxFournisseurs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBoxFournisseurs.Items.Count; i++)
                {
                    if (i != e.Index)
                        checkedListBoxFournisseurs.SetItemChecked(i, false);
                }
            }
        }

        private void CheckedListBoxMateriels_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBoxMateriels.Items.Count; i++)
                {
                    if (i != e.Index)
                        checkedListBoxMateriels.SetItemChecked(i, false);
                }
            }
        }

        private void AjoutAchatForm_Load_1(object sender, EventArgs e) { }
    }
}
