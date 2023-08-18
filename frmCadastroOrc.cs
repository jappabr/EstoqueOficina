using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace off
{
    public partial class frmCadastroOrc : Form
    {
        private string selectedFolderPath = db.GetSelectedFolderPath();
        private int sequencialCodigo = 1;
        public frmCadastroOrc()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView2.CellFormatting += dataGridView1_CellFormatting;

            dataGridView2.Columns.Add("Codigo", "Código");
            dataGridView2.Columns.Add("Item", "Item");
            dataGridView2.Columns.Add("Valor", "Valor");

            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Item", "Item");
            dataGridView1.Columns.Add("Valor", "Valor");



            // Configurar o tamanho das colunas do DataGridView2 (Orçamento)
            dataGridView2.Columns["Codigo"].Width = 50;
            dataGridView2.Columns["Item"].Width = 700;
            dataGridView2.Columns["Valor"].Width = 192;

            // Configurar o tamanho das colunas do DataGridView1 (Estoque)
            dataGridView1.Columns["Codigo"].Width = 50;
            dataGridView1.Columns["Item"].Width = 700;
            dataGridView1.Columns["Valor"].Width = 192;

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
                int codigo = sequencialCodigo; // Usar o sequencial como código
                string item = selectedRow.Cells["Item"].Value.ToString();
                double valor = Convert.ToDouble(selectedRow.Cells["Valor"].Value);

                // Adicionar o item ao DataGridView do orçamento com um sequencial de código
                dataGridView2.Rows.Add(codigo, item, valor);
                sequencialCodigo++; // Incrementar o sequencial
            }
            CalcularTotalOrcamento();
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

            GerarPDF(nomeArquivoPDF, nomeCliente, "445.772.358-46", "11 975198127", totalOrcamento);

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
                sequencialCodigo--; // Decrementar o sequencial
                // Recalcular o total do orçamento após remover o item
                CalcularTotalOrcamento();
            }
        }
        private void GerarPDF(string nomeArquivoPDF, string nomeCliente, string cpfCliente, string telefoneCliente, double totalOrcamento)
        {
            string caminhoCompleto = Path.Combine(selectedFolderPath, nomeArquivoPDF);

            // Configurar o documento PDF
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoCompleto, FileMode.Create));
            doc.Open();

            // Adicionar o título ao documento
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph title = new Paragraph("OFICINA DO KAIO", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(new Paragraph(Environment.NewLine));

            // Dados de contato
            iTextSharp.text.Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            Paragraph contactInfo = new Paragraph("Telefone: (XX) XXXX-XXXX | CNPJ: XX.XXX.XXX/XXXX-XX | " + DateTime.Now.ToString("dd/MM/yyyy"), smallFont);
            contactInfo.Alignment = Element.ALIGN_CENTER;
            doc.Add(contactInfo);
            doc.Add(new Paragraph(Environment.NewLine));

            // Linha com os dados do cliente
            LineSeparator lineSeparator = new LineSeparator();
            doc.Add(lineSeparator);
            doc.Add(new Paragraph(Environment.NewLine));

            // Título CLIENTE
            iTextSharp.text.Font clientTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            Paragraph clientTitle = new Paragraph("CLIENTE", clientTitleFont);
            clientTitle.Alignment = Element.ALIGN_LEFT;
            doc.Add(clientTitle);
            doc.Add(new Paragraph(Environment.NewLine));

            // Dados do cliente
            iTextSharp.text.Font clientDataFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph clientData = new Paragraph($"Nome: {nomeCliente}\nCPF: {cpfCliente}\nTelefone: {telefoneCliente}", clientDataFont);
            clientData.Alignment = Element.ALIGN_LEFT;
            doc.Add(clientData);
            doc.Add(new Paragraph(Environment.NewLine));

            // Adicionar uma linha de separação entre cliente e orçamento
            doc.Add(new LineSeparator());
            doc.Add(new Paragraph(Environment.NewLine));

            // Adicionar os dados do orçamento ao documento...
            doc.Add(new Paragraph("Itens do Orçamento:", clientDataFont));
            doc.Add(new Paragraph(Environment.NewLine));

            // Adicionar os itens da DataGridView2 ao documento (exceto o último item)
            iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                string item = dataGridView2.Rows[i].Cells["Item"].Value?.ToString();
                string valor = dataGridView2.Rows[i].Cells["Valor"].Value?.ToString();

                // Exibir o item e valor na mesma linha
                string linhaItemValor = $"Item: {item} - Valor: {valor:C2}";
                doc.Add(new Paragraph(linhaItemValor, normalFont));
            }

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

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotalOrcamento();
        }
    }

}
