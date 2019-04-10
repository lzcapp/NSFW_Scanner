using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Baidu.Aip.ContentCensor;

namespace FileScanner {
    internal class PicScanner {
        private AntiPorn _clientAntiPorn;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void InitiateScanner() {
            // var APP_ID = "10025535";
            var API_KEY = ConfigurationManager.AppSettings["APIKey"];
            var SECRET_KEY = ConfigurationManager.AppSettings["SecretKey"];
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
                    if (fileExt != ".jpg" && fileExt != ".png" && fileExt != ".gif" && fileExt != ".bmp" &&
                        fileExt != ".jpeg") continue;
                    //var fileInfo = new FileInfo(fsInfo.FullName);
                    /*if (fileInfo.Length < 1000000)
                    {
                        fileList.Add(fsInfo.FullName);
                    }*/
                    fileList.Add(fsInfo.FullName);
                }
            }
            return fileList;
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