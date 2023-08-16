using System.Runtime.InteropServices;
namespace off
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDash.Height;
            pnlNav.Top = btnDash.Top;
            pnlNav.Left = btnDash.Left;
            btnDash.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Criar partes do dashboard, ideias: quantidade de item cadastrado no estoque, valor total do orçamento gerados.
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDash.Height;
            pnlNav.Top = btnDash.Top;
            pnlNav.Left = btnDash.Left;
            btnDash.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnEstoque.Height;
            pnlNav.Top = btnEstoque.Top;
            pnlNav.Left = btnEstoque.Left;
            btnEstoque.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Estoque";
            this.pnlFormLoader.Controls.Clear();
            frmEstoque frmDashboard_Vrb = new frmEstoque() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void BtnOrc_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BtnOrc.Height;
            pnlNav.Top = BtnOrc.Top;
            pnlNav.Left = BtnOrc.Left;
            BtnOrc.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Orçamento";
            this.pnlFormLoader.Controls.Clear();
            frmOrc frmDashboard_Vrb = new frmOrc() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConfig.Height;
            pnlNav.Top = btnConfig.Top;
            pnlNav.Left = btnConfig.Left;
            btnConfig.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Configuração";
            this.pnlFormLoader.Controls.Clear();
            frmConfig frmDashboard_Vrb = new frmConfig() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnDash_Leave(object sender, EventArgs e)
        {
            btnDash.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnEstoque_Leave(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnOrc_Leave(object sender, EventArgs e)
        {
            BtnOrc.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnConfig_Leave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCadastro.Height;
            pnlNav.Top = btnCadastro.Top;
            pnlNav.Left = btnCadastro.Left;
            btnCadastro.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Cadastro";
            this.pnlFormLoader.Controls.Clear();
            frmCadastro frmDashboard_Vrb = new frmCadastro() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnCadastro_Leave(object sender, EventArgs e)
        {
            btnCadastro.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            pnlNav.Height = iconButton2.Height;
            pnlNav.Top = iconButton2.Top;
            pnlNav.Left = iconButton2.Left;
            iconButton2.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Cadastro de Orçamento";
            this.pnlFormLoader.Controls.Clear();
            frmCadastroOrc frmDashboard_Vrb = new frmCadastroOrc() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}