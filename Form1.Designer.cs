namespace off
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            btnConfig = new FontAwesome.Sharp.IconButton();
            BtnOrc = new FontAwesome.Sharp.IconButton();
            btnEstoque = new FontAwesome.Sharp.IconButton();
            btnDash = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            label1 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            pnlNav = new Panel();
            panel3 = new Panel();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            pnlFormLoader = new Panel();
            lblTitle = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(btnConfig);
            panel1.Controls.Add(BtnOrc);
            panel1.Controls.Add(btnEstoque);
            panel1.Controls.Add(btnDash);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(187, 773);
            panel1.TabIndex = 0;
            // 
            // iconButton2
            // 
            iconButton2.Dock = DockStyle.Top;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.ForeColor = Color.FromArgb(0, 126, 249);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            iconButton2.IconColor = Color.FromArgb(0, 126, 249);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 23;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(0, 264);
            iconButton2.Name = "iconButton2";
            iconButton2.RightToLeft = RightToLeft.No;
            iconButton2.Size = new Size(187, 40);
            iconButton2.TabIndex = 8;
            iconButton2.Text = "Cadastro de Orçamentos";
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // btnConfig
            // 
            btnConfig.Dock = DockStyle.Bottom;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.ForeColor = Color.FromArgb(0, 126, 249);
            btnConfig.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnConfig.IconColor = Color.FromArgb(0, 126, 249);
            btnConfig.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfig.IconSize = 23;
            btnConfig.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfig.Location = new Point(0, 733);
            btnConfig.Name = "btnConfig";
            btnConfig.RightToLeft = RightToLeft.No;
            btnConfig.Size = new Size(187, 40);
            btnConfig.TabIndex = 6;
            btnConfig.Text = "Configuração";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            btnConfig.Leave += btnConfig_Leave;
            // 
            // BtnOrc
            // 
            BtnOrc.Dock = DockStyle.Top;
            BtnOrc.FlatAppearance.BorderSize = 0;
            BtnOrc.FlatStyle = FlatStyle.Flat;
            BtnOrc.ForeColor = Color.FromArgb(0, 126, 249);
            BtnOrc.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            BtnOrc.IconColor = Color.FromArgb(0, 126, 249);
            BtnOrc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnOrc.IconSize = 23;
            BtnOrc.ImageAlign = ContentAlignment.MiddleLeft;
            BtnOrc.Location = new Point(0, 224);
            BtnOrc.Name = "BtnOrc";
            BtnOrc.RightToLeft = RightToLeft.No;
            BtnOrc.Size = new Size(187, 40);
            BtnOrc.TabIndex = 4;
            BtnOrc.Text = "Orçamento";
            BtnOrc.UseVisualStyleBackColor = true;
            BtnOrc.Click += BtnOrc_Click;
            BtnOrc.Leave += BtnOrc_Leave;
            // 
            // btnEstoque
            // 
            btnEstoque.Dock = DockStyle.Top;
            btnEstoque.FlatAppearance.BorderSize = 0;
            btnEstoque.FlatStyle = FlatStyle.Flat;
            btnEstoque.ForeColor = Color.FromArgb(0, 126, 249);
            btnEstoque.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            btnEstoque.IconColor = Color.FromArgb(0, 126, 249);
            btnEstoque.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstoque.IconSize = 23;
            btnEstoque.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstoque.Location = new Point(0, 184);
            btnEstoque.Name = "btnEstoque";
            btnEstoque.RightToLeft = RightToLeft.No;
            btnEstoque.Size = new Size(187, 40);
            btnEstoque.TabIndex = 3;
            btnEstoque.Text = "Estoque";
            btnEstoque.UseVisualStyleBackColor = true;
            btnEstoque.Click += btnEstoque_Click;
            btnEstoque.Leave += btnEstoque_Leave;
            // 
            // btnDash
            // 
            btnDash.Dock = DockStyle.Top;
            btnDash.FlatAppearance.BorderSize = 0;
            btnDash.FlatStyle = FlatStyle.Flat;
            btnDash.ForeColor = Color.FromArgb(0, 126, 249);
            btnDash.IconChar = FontAwesome.Sharp.IconChar.House;
            btnDash.IconColor = Color.FromArgb(0, 126, 249);
            btnDash.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDash.IconSize = 23;
            btnDash.ImageAlign = ContentAlignment.MiddleLeft;
            btnDash.Location = new Point(0, 144);
            btnDash.Name = "btnDash";
            btnDash.RightToLeft = RightToLeft.No;
            btnDash.Size = new Size(187, 40);
            btnDash.TabIndex = 2;
            btnDash.Text = "Dashboard";
            btnDash.UseVisualStyleBackColor = true;
            btnDash.Click += btnDash_Click;
            btnDash.Leave += btnDash_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(iconButton1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(187, 144);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 126, 249);
            label1.Location = new Point(41, 79);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "Estoqcar";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Car;
            iconButton1.IconColor = Color.FromArgb(0, 126, 249);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(41, 12);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(83, 92);
            iconButton1.TabIndex = 2;
            iconButton1.Text = "\r\n";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            pnlNav.Location = new Point(0, 193);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 100);
            pnlNav.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(iconButton4);
            panel3.Controls.Add(iconButton3);
            panel3.Controls.Add(pnlFormLoader);
            panel3.Controls.Add(lblTitle);
            panel3.Location = new Point(183, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1381, 770);
            panel3.TabIndex = 2;
            // 
            // iconButton4
            // 
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.ForeColor = Color.FromArgb(46, 51, 73);
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.CloudDownload;
            iconButton4.IconColor = Color.RoyalBlue;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.Location = new Point(1326, -3);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(23, 23);
            iconButton4.TabIndex = 11;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // iconButton3
            // 
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.ForeColor = Color.FromArgb(46, 51, 73);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.CloudUploadAlt;
            iconButton3.IconColor = Color.Red;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(1355, -3);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(23, 23);
            iconButton3.TabIndex = 10;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // pnlFormLoader
            // 
            pnlFormLoader.Dock = DockStyle.Bottom;
            pnlFormLoader.Location = new Point(0, 65);
            pnlFormLoader.Name = "pnlFormLoader";
            pnlFormLoader.Size = new Size(1381, 705);
            pnlFormLoader.TabIndex = 9;
            pnlFormLoader.Paint += pnlFormLoader_Paint;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(158, 161, 176);
            lblTitle.Location = new Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 33);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Dashboard";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1562, 773);
            Controls.Add(panel3);
            Controls.Add(pnlNav);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnDash;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnConfig;
        private FontAwesome.Sharp.IconButton BtnOrc;
        private FontAwesome.Sharp.IconButton btnEstoque;
        private Panel pnlNav;
        private Panel panel3;
        private Label lblTitle;
        private Panel pnlFormLoader;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
    }
}