using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static off.db;
using static off.Item;

namespace off
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
            comboBox1.Items.Add("Motor");
            comboBox1.Items.Add("Suspensão");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nome = textBox2.Text.ToLower();
            double valor = double.Parse(textBox4.Text);
            string tipo = comboBox1.Text;

            Item item = new Item { Nome = nome, Valor = valor, Tipo = tipo };

            Item itemBuscado = db.getItemByName(nome);

            if (itemBuscado == null)
            {
                db.InsertEstoqueItem(item);
                MessageBox.Show($"Item cadastrado com sucesso!\n Tipo: {item.Tipo}\nNome: {item.Nome}, Valor: {item.Valor.ToString("C2")}", "Cadastrado!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Item já cadastrado!");
            }

        }
    }
}
