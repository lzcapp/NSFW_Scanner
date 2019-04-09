using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileScanner
{
    public partial class FrmPic : Form
    {
        public static string PicPath;
        public FrmPic()
        {
            InitializeComponent();
        }

        private void FrmPic_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(PicPath);
            Application.DoEvents();
        }

        private void FrmPic_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
