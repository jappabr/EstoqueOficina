using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
