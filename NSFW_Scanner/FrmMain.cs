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
            llbPath.Text = dirPath;
            var fileList = GetFiles(dirPath);
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
                        listBox1.Items.Add(filePath);
                        break;
                    case "性感":
                        sexyNum++;
                        listBox1.Items.Add(filePath);
                        break;
                    case "正常":
                        normNum++;
                        break;
                    default:
                        nonpNum++;
                        break;
                }
                var portNum = Math.Round((pornNum + sexyNum) / (double)fileList.Count * 100, 2);
                llbPort.Text = portNum + @"%";
                llbPorn.Text = pornNum + @"x";
                llbSexy.Text = sexyNum + @"x";
                llbNorm.Text = normNum + @"x";
                progressBar1.Value = pornNum + sexyNum + normNum + nonpNum;
                Application.DoEvents();
            }
        }

        private static List<string> GetFiles(string dirPath)
        {
            var fileList = new List<string>();
            var d = new DirectoryInfo(dirPath);
            var fsInfos = d.GetFileSystemInfos();
            foreach (var fsInfo in fsInfos)
            {
                if (fsInfo is DirectoryInfo)
                {
                    GetFiles(fsInfo.FullName);
                }
                else
                {
                    var fileExt = fsInfo.Extension.ToLower();
                    if (fileExt != ".jpg" && fileExt != ".png" && fileExt != ".gif" && fileExt != ".bmp" &&
                        fileExt != ".jpeg") continue;
                    var fileInfo = new FileInfo(fsInfo.FullName);
                    if (fileInfo.Length > 1000000)
                    {
                        fileList.Add(fsInfo.FullName);
                    }
                }
            }
            return fileList;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            FrmPic.PicPath = listBox1.SelectedItem.ToString();
            var insFrmPic = new FrmPic();
            insFrmPic.Show();
            Application.DoEvents();
        }
    }
}