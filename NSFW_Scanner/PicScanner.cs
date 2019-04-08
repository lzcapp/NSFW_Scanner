using System;
using System.Diagnostics.CodeAnalysis;
using Baidu.Aip.ContentCensor;

namespace FileScanner {
    internal class PicScanner {
        private AntiPorn _clientAntiPorn;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void InitiateScanner() {
            // var APP_ID = "10025535";
            const string API_KEY = "B7CAN7yIwRI78Gc2zQqVEnS2";
            const string SECRET_KEY = "Uwj9taafS7M7GRyxhEn9kpCpGojdmRQM";
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