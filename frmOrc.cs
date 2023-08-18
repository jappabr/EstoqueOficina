using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic.ApplicationServices;

namespace off
{
    public partial class frmOrc : Form
    {

        public frmOrc()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nome Cliente", "Nome Cliente");
            dataGridView1.Columns.Add("Valor Total", "Valor Total");
            dataGridView1.Columns["Codigo"].Width = 50;
            dataGridView1.Columns["Nome Cliente"].Width = 450;
            dataGridView1.Columns["Valor Total"].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            CarregarItens();
            double totalOrcamento = db.CalcularTotalOrcamentos();
            label1.Text = totalOrcamento.ToString("C2");

        }
        private void CarregarItens()
        {
            // Limpar o DataGridView antes de carregar os itens
            dataGridView1.Rows.Clear();

            // Obter a lista de itens do banco de dados
            List<OrcamentoItem> itens = db.GetOrcamentoItens();

            // Adicionar cada item ao DataGridView
            foreach (OrcamentoItem item in itens)
            {
                dataGridView1.Rows.Add(item.Codigo, item.NomeCliente, item.ValorTotal.ToString("C2"));
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
            string buscar = textBox1.Text.Trim(); // Remover espaços em branco no início e no fim do texto

            // Verificar se o campo de busca não está vazio
            if (!string.IsNullOrEmpty(buscar))
            {
                // Realizar a busca aproximada no banco de dados com base no texto inserido no textBox1
                List<OrcamentoItem> itensEncontrados = db.searchOrcamentoItemsByName(buscar);

                // Limpar o DataGridView antes de adicionar os novos itens
                dataGridView1.Rows.Clear();

                // Adicionar os itens encontrados ao DataGridView
                foreach (OrcamentoItem itemEncontrado in itensEncontrados)
                {
                    dataGridView1.Rows.Add(itemEncontrado.Codigo, itemEncontrado.NomeCliente, itemEncontrado.ValorTotal.ToString("C2"));
                }

                if (itensEncontrados.Count == 0)
                {
                    MessageBox.Show("Nenhum item encontrado com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Digite um nome para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
