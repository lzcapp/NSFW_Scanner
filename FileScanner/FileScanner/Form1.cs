using System;
using System.IO;
using System.Windows.Forms;

namespace FileScanner {
    public partial class Form1 : Form {
        private readonly PicScanner _scanner = new PicScanner();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            _scanner.InitiateScanner();
        }

        private void PicSearch(object sender, EventArgs e) {
            var pornNum = 0;
            var sexyNum = 0;
            var normNum = 0;
            var notpNum = 0;
            llbPorn.Text = pornNum.ToString();
            llbSexy.Text = sexyNum.ToString();
            llbNorm.Text = normNum.ToString();
            var dialog = new FolderBrowserDialog {
                Description = @"Please choose the folder path:"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var dirPath = dialog.SelectedPath;
            llbPath.Text = dirPath;
            var dirInfo = new DirectoryInfo(dirPath);
            var files = dirInfo.GetFileSystemInfos();
            progressBar1.Maximum = files.Length;
            foreach (var file in files) {
                if (file is DirectoryInfo) {
                    notpNum++;
                    progressBar1.Value = pornNum + sexyNum + normNum + notpNum;
                    continue;
                }
                var strFileExt = file.Extension.ToLower();
                if (strFileExt != ".jpg" &&
                    strFileExt != ".png" &&
                    strFileExt != ".gif" &&
                    strFileExt != ".bmp" &&
                    strFileExt != ".jpeg") {
                    notpNum++;
                    progressBar1.Value = pornNum + sexyNum + normNum + notpNum;
                    continue;
                }

                picShow.ImageLocation = file.FullName;
                llbPicfile.Text = file.FullName.Split('\\')[file.FullName.Split('\\').Length - 1];
                var fileInfo = new FileInfo(file.FullName);
                if (fileInfo.Length > 1000000) {
                    //image = PicScanner.ImageCompress(file.FullName);
                    notpNum++;
                    progressBar1.Value = pornNum + sexyNum + normNum + notpNum;
                    continue;
                }

                var image = File.ReadAllBytes(file.FullName);
                var picType = _scanner.PicQuery(image);
                switch (picType) {
                    case "色情":
                        pornNum++;
                        break;
                    case "性感":
                        sexyNum++;
                        break;
                    case "正常":
                        normNum++;
                        break;
                    default:
                        notpNum++;
                        break;
                }

                var portNum = Math.Round((pornNum + sexyNum) / (double) (pornNum + sexyNum + normNum) * 100, 2);
                llbPort.Text = portNum + @"%";
                llbPorn.Text = pornNum + @"x";
                llbSexy.Text = sexyNum + @"x";
                llbNorm.Text = normNum + @"x";
                progressBar1.Value = pornNum + sexyNum + normNum + notpNum;
                Application.DoEvents();
            }
        }
    }
}