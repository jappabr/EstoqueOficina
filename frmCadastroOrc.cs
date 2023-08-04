using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace off
{
    public partial class frmCadastroOrc : Form
    {
        public frmCadastroOrc()
        {
            InitializeComponent();
            dataGridView2.Columns.Add("Codigo", "Código");
            dataGridView2.Columns.Add("Nome", "Nome");
            dataGridView2.Columns.Add("Valor", "Valor");

            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Valor", "Valor");

            List<Item> itens = db.GetEstoqueItens();

            foreach (Item item in itens)
            {
                dataGridView1.Rows.Add(item.Codigo, item.Nome, item.Valor, item.Tipo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int codigo = Convert.ToInt32(selectedRow.Cells["Codigo"].Value);
                string nome = selectedRow.Cells["Nome"].Value.ToString();
                double valor = Convert.ToDouble(selectedRow.Cells["Valor"].Value);

                // Adicionar o item ao DataGridView do orçamento
                dataGridView2.Rows.Add(codigo, nome, valor);

                // Calcular o total do orçamento
                CalcularTotalOrcamento();
            }

        }
        private void CalcularTotalOrcamento()
        {
            double total = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                double valor = Convert.ToDouble(row.Cells["Valor"].Value);
                total += valor;
            }
            double valorMao = double.Parse(textBox2.Text);
            total += valorMao;
            // Exibir o total no TextBox ou Label correspondente
            label6.Text = total.ToString("C2");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out double valor))
            {
                MessageBox.Show("Valor inválido. Insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado é um dígito numérico, ponto decimal ou tecla de controle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignora o caractere
            }

            // Permite apenas um ponto decimal
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
