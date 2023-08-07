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
          //TODO: Calcular valor total dos orçamentos e quantidade de orçamentos criados
        }
    }
}
