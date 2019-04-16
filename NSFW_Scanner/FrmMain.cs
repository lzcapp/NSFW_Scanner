using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FileScanner.Properties;

namespace FileScanner
{
    public partial class FrmMain : Form {
        private static readonly PicScanner Scanner = new PicScanner();
        private bool _isPause;

        public FrmMain() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Scanner.InitiateScanner();
        }

        private void PicSearch(object sender, EventArgs e) {
            _isPause = false;
            pictureBox1.Image = Resources.pause;
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
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var index = 0; index < fileList.Count;) {
                var filePath = fileList[index];
                while (_isPause) {
                    Application.DoEvents();
                }
                llbPorn.Text = pornNum.ToString();
                llbSexy.Text = sexyNum.ToString();
                llbNorm.Text = normNum.ToString();
                picShow.ImageLocation = filePath;
                llbPicfile.Text = filePath.Split('\\')[filePath.Split('\\').Length - 1];
                var picType = "";
                var picResult = "";
                if (PicScanner.ImageCompress(filePath) == 0) {
                    var image = File.ReadAllBytes("temp.jpg");
                    picResult = Scanner.PicQuery(image);
                    picType = picResult.Split(',')[0];
                }

                try {
                    File.Delete("temp.jpg");
                } catch (Exception) {
                    // ignored
                }

                switch (picType) {
                    case "色情":
                        pornNum++;
                        listBox1.Items.Add(@"色情/" + picResult.Split(',')[1] + ": " + filePath);
                        break;
                    case "性感":
                        sexyNum++;
                        listBox1.Items.Add(@"性感/" + picResult.Split(',')[1] + ": " + filePath);
                        break;
                    case "正常":
                        normNum++;
                        listBox1.Items.Add(@"正常/" + picResult.Split(',')[1] + ": " + filePath);
                        break;
                    default:
                        nonpNum++;
                        listBox1.Items.Add(@"忽略: " + filePath);
                        break;
                }

                var portNum = Math.Round((pornNum + sexyNum) / (double) (pornNum + sexyNum + normNum + nonpNum) * 100,
                                         2);
                llbPort.Text = portNum + @"%";
                llbPorn.Text = pornNum + @"x";
                llbSexy.Text = sexyNum + @"x";
                llbNorm.Text = normNum + @"x";
                progressBar1.Value = pornNum + sexyNum + normNum + nonpNum;
                index++;
                Application.DoEvents();
            }
            _isPause = false;
            pictureBox1.Image = Resources.pause;
        }

        private void ListBox1_MouseUp(object sender, MouseEventArgs e) {
            var picPath = listBox1.SelectedItem.ToString();
            var repPath = picPath.Replace(picPath.Split(' ')[0], "");
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Button) {
                case MouseButtons.Left: 
                    FrmPic.PicPath = repPath;
                    var insFrmPic = new FrmPic();
                    insFrmPic.SetBounds(Cursor.Position.X + 30, Cursor.Position.Y - 160, insFrmPic.Width, insFrmPic.Height);
                    insFrmPic.Show();
                    break;
                case MouseButtons.Right:
                    Process.Start("Explorer.exe", "/select," + repPath);
                    break;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e) {
            if (_isPause) {
                pictureBox1.Image = Resources.pause;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                _isPause = false;
            } else {
                pictureBox1.Image = Resources.play;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                _isPause = true;
            }
        }
    }
}