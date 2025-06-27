using System;
using System.Windows.Forms;

namespace renaissanceproject2025
{
    public partial class CodeVerificationForm : Form
    {
        private string codeAttendu;

        public CodeVerificationForm(string code)
        {
            InitializeComponent();
            codeAttendu = code;
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text.Trim() == codeAttendu)
            {
                MessageBox.Show("Code valide !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Code incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
