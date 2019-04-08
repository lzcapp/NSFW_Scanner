using System.IO;
using System.Linq;
using static System.Environment;

namespace PicInfo
{
    class PicScanner
    {
        private Baidu.Aip.ContentCensor.ImageCensor _clientCencor;
        private Baidu.Aip.ContentCensor.AntiPorn _clientAntiPorn;
        private Baidu.Aip.ContentCensor.AntiTerror _clientAntiTerror;
        private Baidu.Aip.ImageClassify.ImageClassify _clientImageClass;
        public void InitiateScanner()
        {
            // var APP_ID = "10025535";
            var API_KEY = "B7CAN7yIwRI78Gc2zQqVEnS2";
            var SECRET_KEY = "Uwj9taafS7M7GRyxhEn9kpCpGojdmRQM";
            _clientAntiPorn = new Baidu.Aip.ContentCensor.AntiPorn(API_KEY, SECRET_KEY)
            {
                Timeout = 30000  // 超时，毫秒
            };
            _clientAntiTerror = new Baidu.Aip.ContentCensor.AntiTerror(API_KEY, SECRET_KEY)
            {
                Timeout = 30000  // 超时，毫秒
            };
            _clientImageClass = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY)
            {
                Timeout = 30000  // 超时，毫秒
            };
            _clientCencor = new Baidu.Aip.ContentCensor.ImageCensor(API_KEY, SECRET_KEY)
            {
                Timeout = 30000  // 超时，毫秒
            };
        }
        public string Scanner(string imgPath)
        {
            var image = File.ReadAllBytes(imgPath);
            var resultSb = new System.Text.StringBuilder();
            // resultSb.Append(resultJson.ToString());
            var resultBasic = _clientCencor.UserDefined(image);
            if (resultBasic["conclusion"].ToString() == "合规")
            {
                return "正常";
            }
            else
            {
                for (var i = 0; i < resultBasic["data"].Count(); i++)
                {
                    if (resultBasic["data"][0]["type"].ToString() == "5" || 
                        resultBasic["data"][0]["type"].ToString() == "6" ||
                        resultBasic["data"][0]["type"].ToString() == "7" ||
                        resultBasic["data"][0]["type"].ToString() == "8")
                    {
                        continue;
                    }
                    resultSb.Append(resultBasic["data"][i]["msg"]);
                    if (i != resultBasic["data"].Count() - 1)
                    {
                        resultSb.Append(NewLine);
                    }
                }
                return resultSb.ToString();
            }
        }
        public string PornScanner(string imgPath)
        {
            var image = File.ReadAllBytes(imgPath);
            var resultSb = new System.Text.StringBuilder();
            var resultPorn = _clientAntiPorn.Detect(image);
            var resultType = resultPorn["conclusion"].ToString();
            int resultTypeNum;
            switch (resultType)
            {
                case "正常":
                    resultTypeNum = 2;
                    break;
                case "性感":
                    resultTypeNum = 0;
                    break;
                case "色情":
                    resultTypeNum = 1;
                    break;
                default:
                    resultTypeNum = 2;
                    break;
            }
            var resultPr = resultPorn["result"][resultTypeNum]["probability"].ToString();
            resultSb.Append(double.Parse(resultPr) * 100 + "%  " + resultPorn["confidence_coefficient"]);
            double highest = 0;
            string resultFineType = null;
            for (var i = 0; i < resultPorn["result_fine"].Count(); i++)
            {
                var value = double.Parse(resultPorn["result_fine"][i]["probability"].ToString());
                if (!(value > highest)) continue;
                highest = value;
                resultFineType = resultPorn["result_fine"][i]["class_name"].ToString();
            }
            resultSb.Append(NewLine);
            resultSb.Append(resultFineType);
            return resultSb.ToString();
        }
        public string TerrorScanner(string imgPath)
        {
            var image = File.ReadAllBytes(imgPath);
            var resultTerror = _clientAntiTerror.Detect(image);
            double highest = 0;
            string resultFineType = null;
            for (var i = 0; i < resultTerror["result_fine"].Count(); i++)
            {
                var value = double.Parse(resultTerror["result_fine"][i]["score"].ToString());
                if (!(value > highest)) continue;
                highest = value;
                resultFineType = resultTerror["result_fine"][i]["name"].ToString();
            }
            return resultFineType;
        }
        public string ImgType(string imgPath)
        {
            var image = File.ReadAllBytes(imgPath);
            var resultSb = new System.Text.StringBuilder();
            var resultType = _clientImageClass.AdvancedGeneral(image);
            for (int i = 0; i < int.Parse(resultType["result_num"].ToString()); i++)
            {
                resultSb.Append(resultType["result"][i]["score"]);
                resultSb.Append(NewLine);
                resultSb.Append(resultType["result"][i]["root"] + "：" + resultType["result"][i]["keyword"]);
                resultSb.Append(NewLine);
            }
            return resultSb.ToString();
        }
    }
}
