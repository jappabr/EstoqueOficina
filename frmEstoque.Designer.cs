namespace off
{
    partial class frmEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            btnAdd = new Button();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(46, 51, 73);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 360);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1028, 325);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(699, 288);
            button1.Name = "button1";
            button1.Size = new Size(89, 23);
            button1.TabIndex = 1;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(59, 289);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(624, 23);
            textBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(158, 161, 176);
            label5.Location = new Point(59, 40);
            label5.Name = "label5";
            label5.Size = new Size(12, 16);
            label5.TabIndex = 21;
            label5.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(158, 161, 176);
            label3.Location = new Point(59, 14);
            label3.Name = "label3";
            label3.Size = new Size(56, 16);
            label3.TabIndex = 20;
            label3.Text = "Código:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1085, 40);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(203, 23);
            comboBox1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(158, 161, 176);
            label1.Location = new Point(1253, 14);
            label1.Name = "label1";
            label1.Size = new Size(35, 16);
            label1.TabIndex = 18;
            label1.Text = "Tipo";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1213, 194);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Cadastrar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(59, 195);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(208, 23);
            textBox4.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(158, 161, 176);
            label4.Location = new Point(59, 176);
            label4.Name = "label4";
            label4.Size = new Size(44, 16);
            label4.TabIndex = 15;
            label4.Text = "Preço";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(59, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(1229, 23);
            textBox2.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(158, 161, 176);
            label2.Location = new Point(59, 81);
            label2.Name = "label2";
            label2.Size = new Size(45, 16);
            label2.TabIndex = 13;
            label2.Text = "Nome";
            // 
            // frmEstoque
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1381, 705);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEstoque";
            Text = "frmEstoque";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private Label label5;
        private Label label3;
        private ComboBox comboBox1;
        private Label label1;
        private Button btnAdd;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox2;
        private Label label2;
    }
}