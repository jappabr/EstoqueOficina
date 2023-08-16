using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace off
{
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Valor", "Valor");
            dataGridView1.Columns.Add("Tipo", "Tipo");
            dataGridView1.Columns["Codigo"].Width = 50;
            dataGridView1.Columns["Nome"].Width = 300;
            dataGridView1.Columns["Valor"].Width = 150;
            dataGridView1.Columns["Tipo"].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            CarregarItens();
        }
        private void CarregarItens()
        {
            // Limpar o DataGridView antes de carregar os itens
            dataGridView1.Rows.Clear();

            // Obter a lista de itens do banco de dados
            List<Item> itens = db.GetEstoqueItens();

            // Adicionar cada item ao DataGridView
            foreach (Item item in itens)
            {
                dataGridView1.Rows.Add(item.Codigo, item.Nome, item.Valor.ToString("C2"), item.Tipo);
            }

        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex % 2 == 0)
                {
                    e.CellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string buscar = textBox1.Text.Trim();

            // Verificar se o campo de busca não está vazio
            if (!string.IsNullOrEmpty(buscar))
            {
                // Realizar a busca aproximada no banco de dados com base no texto inserido no textBox1
                List<Item> itensEncontrados = db.searchItemsByName(buscar);

                // Limpar o DataGridView antes de adicionar os novos itens
                dataGridView1.Rows.Clear();

                // Adicionar os itens encontrados ao DataGridView
                foreach (Item itemEncontrado in itensEncontrados)
                {
                    dataGridView1.Rows.Add(itemEncontrado.Codigo, itemEncontrado.Nome, itemEncontrado.Valor.ToString("C2"), itemEncontrado.Tipo);
                }

                if (itensEncontrados.Count == 0)
                {
                    MessageBox.Show("Nenhum item de estoque encontrado com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Digite um nome para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
