using System;
using System.Drawing;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class AjoutFournisseurForm : Form
    {
        public string NomFournisseur => textBoxNomF.Text;
        public string TelephoneFournisseur => textBoxTelephoneF.Text;
        public string AdresseFournisseur => textBoxAdresseF.Text;
        public string EmailFournisseur => textBoxEmailF.Text;
        public string NomContact => textBoxNomContact.Text;
        public string TelephoneContact => textBoxTelephoneContact.Text;
        public string EmailContact => textBoxEmailContact.Text;

        // 🟢 Constructeur par défaut (Ajout)
        public AjoutFournisseurForm()
        {
            InitializeComponent();
            InitialiserPlaceholders();
        }

        // 🟢 Constructeur avec valeurs existantes (Modification)
        public AjoutFournisseurForm(string[] valeursExistantes) : this()
        {
            if (valeursExistantes.Length >= 7)
            {
                textBoxNomF.Text = valeursExistantes[0];
                textBoxTelephoneF.Text = valeursExistantes[1];
                textBoxAdresseF.Text = valeursExistantes[2];
                textBoxEmailF.Text = valeursExistantes[3];
                textBoxNomContact.Text = valeursExistantes[4];
                textBoxTelephoneContact.Text = valeursExistantes[5];
                textBoxEmailContact.Text = valeursExistantes[6];

                // Enlever la couleur grise si champs remplis
                textBoxNomF.ForeColor = Color.Black;
                textBoxTelephoneF.ForeColor = Color.Black;
                textBoxAdresseF.ForeColor = Color.Black;
                textBoxEmailF.ForeColor = Color.Black;
                textBoxNomContact.ForeColor = Color.Black;
                textBoxTelephoneContact.ForeColor = Color.Black;
                textBoxEmailContact.ForeColor = Color.Black;
            }
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomF.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelephoneF.Text) ||
                string.IsNullOrWhiteSpace(textBoxAdresseF.Text))
            {
                MessageBox.Show("Veuillez remplir au moins Nom, Téléphone et Adresse.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AjoutFournisseurForm_Load(object sender, EventArgs e)
        {
            // Rien à faire ici pour l’instant
        }

        private void InitialiserPlaceholders()
        {
            SetPlaceholder(textBoxNomF, "Nom Fournisseur");
            SetPlaceholder(textBoxTelephoneF, "Téléphone");
            SetPlaceholder(textBoxAdresseF, "Adresse");
            SetPlaceholder(textBoxEmailF, "Email");
            SetPlaceholder(textBoxNomContact, "Nom du contact");
            SetPlaceholder(textBoxTelephoneContact, "Téléphone du contact");
            SetPlaceholder(textBoxEmailContact, "Email du contact");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
