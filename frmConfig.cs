using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace off
{
    public partial class frmConfig : Form
    {
        private string selectedFolderPath = "";

        public frmConfig()
        {
            InitializeComponent();

            // Exibe o último dado cadastrado no TextBox1, se houver
            string lastSelectedFolderPath = db.GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(lastSelectedFolderPath))
            {
                textBox1.Text = lastSelectedFolderPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Selecionar Pasta";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Exibir o caminho da pasta selecionada no TextBox
                    textBox1.Text = selectedFolderPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Salvar a string do TextBox1 no banco de dados
            db.UpdateSelectedFolderPath(textBox1.Text);

            MessageBox.Show("Caminho da pasta salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
