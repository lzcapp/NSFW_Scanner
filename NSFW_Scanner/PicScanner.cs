using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using Baidu.Aip.ContentCensor;

namespace FileScanner {
    internal class PicScanner {
        private AntiPorn _clientAntiPorn;
        private static int _maxFileSize;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void InitiateScanner() {
            var xmlDoc = new XmlDocument();
            var xmlPath = Environment.CurrentDirectory + @"\Token.config";
            if (!File.Exists(xmlPath)) return;
            xmlDoc.Load(xmlPath);
            if (xmlDoc.DocumentElement == null) return;
            var API_KEY = xmlDoc.DocumentElement["APIKey"]?.InnerText.Trim();
            var SECRET_KEY = xmlDoc.DocumentElement["SecretKey"]?.InnerText.Trim();
            _maxFileSize = Convert.ToInt32(xmlDoc.DocumentElement["MaxSize"]?.InnerText.Trim());
            _clientAntiPorn = new AntiPorn(API_KEY, SECRET_KEY) {
                Timeout = 60000 // 超时，毫秒
            };
        }

        public string PicQuery(byte[] image) {
            try {
                var resultPorn = _clientAntiPorn.Detect(image);
                var resultType = resultPorn["conclusion"].ToString();
                return resultType;
            } catch (Exception) {
                return @"错误";
            }
        }

        public static List<string> GetFiles(string dirPath, List<string> fileList)
        {
            var d = new DirectoryInfo(dirPath);
            var fsInfos = d.GetFileSystemInfos();
            foreach (var fsInfo in fsInfos)
            {
                if (fsInfo is DirectoryInfo)
                {
                    GetFiles(fsInfo.FullName, fileList);
                }
                else
                {
                    var fileExt = fsInfo.Extension.ToLower();
                    if (fileExt != ".jpg" && fileExt != ".png" && fileExt != ".bmp" &&
                        fileExt != ".jpeg") continue;
                    var fileInfo = new FileInfo(fsInfo.FullName);
                    // if (fileInfo.Length >= _maxFileSize) continue;
                    fileList.Add(fsInfo.FullName);
                }
            }
            return fileList;
        }

        public static int ImageCompress(string imagePath) {
            var myBitmap = new Bitmap(imagePath);
            var myImageCodecInfo = GetEncoderInfo("image/jpeg");
            var myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save("temp.jpg", myImageCodecInfo, myEncoderParameters);
            var picFile = new FileInfo("temp.jpg");
            if (picFile.Length >= _maxFileSize) {
                return -1;
            }
            return 0;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            var encoders = ImageCodecInfo.GetImageEncoders();
            for(j = 0; j < encoders.Length; ++j)
            {
                if(encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /*
        public static byte[] ImageCompress(string filepath) {
            var myBitmap = new Bitmap(filepath);
            var myImageCodecInfo = GetEncoderInfo("image/jpeg");
            Encoder myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save("Shapes025.jpg", myImageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType) {
            int j;
            var encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j) {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        */
    }
}