using iTextSharp.text;
using iTextSharp.text.pdf;

namespace off
{
    public partial class frmCadastroOrc : Form
    {
        private string selectedFolderPath = db.GetSelectedFolderPath();
        public frmCadastroOrc()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView2.CellFormatting += dataGridView1_CellFormatting;

            dataGridView2.Columns.Add("Codigo", "Código");
            dataGridView2.Columns.Add("Nome", "Nome");
            dataGridView2.Columns.Add("Valor", "Valor");

            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Valor", "Valor");



            // Configurar o tamanho das colunas do DataGridView2 (Orçamento)
            dataGridView2.Columns["Codigo"].Width = 50;
            dataGridView2.Columns["Nome"].Width = 400;
            dataGridView2.Columns["Valor"].Width = 80;

            // Configurar o tamanho das colunas do DataGridView1 (Estoque)
            dataGridView1.Columns["Codigo"].Width = 50;
            dataGridView1.Columns["Nome"].Width = 400;
            dataGridView1.Columns["Valor"].Width = 80;

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
        private double CalcularTotalOrcamento()
        {
            double total = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                double valor = Convert.ToDouble(row.Cells["Valor"].Value);
                total += valor;
            }
            // Exibir o total no TextBox ou Label correspondente
            label6.Text = total.ToString("C2");
            return total;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica se há itens no DataGridView do orçamento
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("O orçamento está vazio. Adicione itens antes de salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Coleta informações do orçamento
            string nomeCliente = textBox1.Text;
            double valorTotal = double.Parse(label6.Text, System.Globalization.NumberStyles.Currency);
            DateTime data = DateTime.Now;

            // Cria um objeto OrcamentoItem com os dados do orçamento
            OrcamentoItem orcamentoItem = new OrcamentoItem
            {
                NomeCliente = nomeCliente,
                ValorTotal = valorTotal,
                Data = data
            };

            // Insere o orçamento no banco de dados
            db.InsertOrcamentoItem(orcamentoItem);

            double totalOrcamento = CalcularTotalOrcamento();
            string nomeArquivoPDF = $"{nomeCliente}_{DateTime.Now:dd.MM.yyyy}.pdf";

            GerarPDF(nomeArquivoPDF, nomeCliente, totalOrcamento);

            // Limpa o DataGridView do orçamento e recalcula o total
            dataGridView2.Rows.Clear();
            textBox1.Text = "";
            CalcularTotalOrcamento();

            // Exibe uma mensagem de sucesso
            MessageBox.Show("Orçamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                dataGridView2.Rows.Remove(selectedRow);
                // Recalcular o total do orçamento após remover o item
                CalcularTotalOrcamento();
            }
        }
        private void GerarPDF(string nomeArquivoPDF, string nomeCliente, double totalOrcamento)
        {
            string caminhoCompleto = Path.Combine(selectedFolderPath, nomeArquivoPDF);
            // Configurar o documento PDF
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoCompleto, FileMode.Create));
            doc.Open();

            // Adicionar o título ao documento
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            doc.Add(new Paragraph("OFICINA DO KAIO", titleFont));
            doc.Add(new Paragraph(Environment.NewLine));

            // Adicionar os dados do orçamento ao documento
            iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            doc.Add(new Paragraph($"Nome do Cliente: {nomeCliente}", normalFont));
            doc.Add(new Paragraph(Environment.NewLine));
            doc.Add(new Paragraph("Itens do Orçamento:", normalFont));
            doc.Add(new Paragraph(Environment.NewLine));

            // Adicionar os itens da DataGridView2 ao documento
            PdfPTable table = new PdfPTable(dataGridView2.Columns.Count - 1); // Remover a coluna do código
            for (int i = 1; i < dataGridView2.Columns.Count; i++) // Começar a partir da segunda coluna (ignorar a coluna do código)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataGridView2.Columns[i].HeaderText, normalFont));
                table.AddCell(cell);
            }
            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView2.Columns.Count; j++) // Começar a partir da segunda coluna (ignorar a coluna do código)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataGridView2[j, i].Value?.ToString(), normalFont));
                    table.AddCell(cell);
                }
            }

            doc.Add(table);

            // Adicionar o total do orçamento ao documento
            doc.Add(new Paragraph(Environment.NewLine));
            doc.Add(new Paragraph($"Total do Orçamento: {totalOrcamento:C2}", normalFont));

            // Fechar o documento
            doc.Close();

            MessageBox.Show("PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
