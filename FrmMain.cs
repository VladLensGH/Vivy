using System.Runtime.InteropServices;

namespace Vivy
{
    public partial class FrmMain : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
 (
 int nLeftRect,
 int nTopRect,
 int nRightRect,
 int nBottomRect,
 int nWidthEllipse,
 int nHeightEllipse

);
        public FrmMain()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin dlgLogin = new FrmLogin();
            DialogResult r = dlgLogin.ShowDialog();
        }
    }
}
