using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PicInfo
{
    public partial class Form1 : Form
    {
        private readonly PicScanner _scanner = new PicScanner();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _scanner.InitiateScanner();
            pic.AllowDrop = true;
        }
        private void Pic_DragDrop(object sender, DragEventArgs e)
        {
            llbPr.Text = "";
            llbOk.Text = "";
            string fileName = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Length > 4000000)
            {
                MessageBox.Show(@"请选择小于4Mb的文件", @"PicScanner: Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pic.Image = Image.FromFile(fileName);
            pic.ImageLocation = fileName;
            var resultType = _scanner.Scanner(fileName);
            if (resultType == "正常" || resultType == "")
            {
                llbOk.Text = @"正常";
                llbOk.Visible = true;
                llbPr.Visible = false;
            }
            else if (resultType.IndexOf("色情", StringComparison.Ordinal) != -1)
            {
                llbOk.Visible = false;
                llbPr.Visible = true;
                llbPr.Text = _scanner.PornScanner(fileName);
            }
            else if (resultType.IndexOf("性感", StringComparison.Ordinal) != -1)
            {
                llbOk.Text = @"性感";
                llbPr.Text = _scanner.PornScanner(fileName);
            }
            else if (resultType.IndexOf("暴恐", StringComparison.Ordinal) != -1)
            {
                llbOk.Text = @"暴恐";
                llbPr.Text = _scanner.TerrorScanner(fileName);
            }
            else if (resultType.IndexOf("恶心", StringComparison.Ordinal) != -1)
            {
                llbOk.Text = @"恶心";
            }
            else if (resultType.IndexOf("政治", StringComparison.Ordinal) != -1)
            {
                llbOk.Text = @"政治";
            }
            llbType.Text = _scanner.ImgType(fileName);
            llbPr.LinkArea = new LinkArea(0, 0);
            llbOk.LinkArea = new LinkArea(0, 0);
            llbType.LinkArea = new LinkArea(0, 0);
        }
        private void Pic_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }
    }
}
