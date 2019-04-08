Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Module CensorPic
    Public resultArr(3) As String
    Public pot As Boolean
    'Public PicStr As String

    Public Function CencorPic(accessToken As String)
        Dim webClient As New WebClient()
        Dim postVars As New NameValueCollection()
        'URL
        Dim url1 As String = "https://aip.baidubce.com/rest/2.0/antiporn/v1/detect?access_token=" + accessToken

        Dim imgCode As String

        'If pot = False Then
        imgCode = ImgBase64()
        'Else
        'imgCode = imgPath
        'End If

        postVars.Add("image", imgCode)

        webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        '请求URL和参数
        Dim byRemoteInfo As Byte() = webClient.UploadValues(url1, "POST", postVars)
        '获取返回信息
        Dim sRemoteInfo As String = Encoding.UTF8.GetString(byRemoteInfo)
        '这是获取返回信息

        Dim resultJson As JObject

        resultJson = JObject.Parse(sRemoteInfo)
        resultArr(0) = resultJson.SelectToken("confidence_coefficient").ToString()
        resultArr(1) = resultJson.SelectToken("conclusion").ToString()

        Dim i As Integer

        Select Case resultArr(1)
            Case "色情"
                i = 0
                Form1.lblType.ForeColor = Color.Red
            Case "性感"
                i = 1
                Form1.lblType.ForeColor = Color.Orange
            Case "正常"
                i = 2
                Form1.lblType.ForeColor = Color.Green
        End Select

        resultArr(2) = Math.Round(resultJson.SelectToken("result")(i).SelectToken("probability").ToString()*100, 3)

        Form1.lblType.Text = resultArr(1)
        Form1.lblPercent.Text = resultArr(2) + "% 概率" + vbCrLf + resultArr(0)
        Return 0
    End Function
End Module
