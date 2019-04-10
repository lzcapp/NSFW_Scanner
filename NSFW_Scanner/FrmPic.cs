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
            pictureBox1.Focus();
            Application.DoEvents();
        }

        private void PictureBox1_LostFocus(object sender, EventArgs e)
        {
            Close();
        }
    }
}
