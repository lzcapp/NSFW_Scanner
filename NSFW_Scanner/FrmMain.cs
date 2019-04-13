using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileScanner
{
    public partial class FrmMain : Form {
        private static readonly PicScanner Scanner = new PicScanner();

        public FrmMain() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Scanner.InitiateScanner();
        }

        private void PicSearch(object sender, EventArgs e) {
            var pornNum = 0;
            var sexyNum = 0;
            var normNum = 0;
            var nonpNum = 0;
            listBox1.Items.Clear();
            var dialog = new FolderBrowserDialog {
                Description = @"Please choose the folder path:"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var dirPath = dialog.SelectedPath;
            llbPath.Text = dirPath + @"\...";
            var fileList = new List<string>();
            llbPicfile.Text = @"Start Fecthing Sub-folders and files.";
            fileList = PicScanner.GetFiles(dirPath, fileList);
            llbPicfile.Text = @"Start Scanning.";
            progressBar1.Maximum = fileList.Count;
            foreach (var filePath in fileList)
            {
                llbPorn.Text = pornNum.ToString();
                llbSexy.Text = sexyNum.ToString();
                llbNorm.Text = normNum.ToString();
                picShow.ImageLocation = filePath;
                llbPicfile.Text = filePath.Split('\\')[filePath.Split('\\').Length - 1];
                var image = File.ReadAllBytes(filePath);
                var picType = Scanner.PicQuery(image);
                switch (picType)
                {
                    case "色情":
                        pornNum++;
                        listBox1.Items.Add(@"Porn: " + filePath);
                        break;
                    case "性感":
                        sexyNum++;
                        listBox1.Items.Add(@"Sexy: " + filePath);
                        break;
                    case "正常":
                        normNum++;
                        break;
                    default:
                        nonpNum++;
                        break;
                }
                var portNum = Math.Round((pornNum + sexyNum) / (double)(pornNum + sexyNum + normNum + nonpNum) * 100, 2);
                llbPort.Text = portNum + @"%";
                llbPorn.Text = pornNum + @"x";
                llbSexy.Text = sexyNum + @"x";
                llbNorm.Text = normNum + @"x";
                progressBar1.Value = pornNum + sexyNum + normNum + nonpNum;
                Application.DoEvents();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var picPath = listBox1.SelectedItem.ToString();
            string repPath;
            switch (picPath[0]) {
                case 'S':
                    repPath = picPath.Replace("Sexy: ", "");
                    break;
                case 'P':
                    repPath = picPath.Replace("Porn: ", "");
                    break;
                default:
                    repPath = picPath;
                    break;
            }
            FrmPic.PicPath = repPath;
            var insFrmPic = new FrmPic();
            insFrmPic.SetBounds(Cursor.Position.X + 30, Cursor.Position.Y - 160, insFrmPic.Width, insFrmPic.Height);
            insFrmPic.Show();
            Application.DoEvents();
        }
    }
}