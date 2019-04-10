Imports System.Net
Imports System.Text
Imports System.Configuration
Imports Newtonsoft.Json.Linq

Module GetOath
    Public Sub GetOathKey()
        Dim accessToken As String
        Dim oathJson As JObject
        Dim oathStr As String
        Dim reader As New AppSettingsReader
        Dim apiKey = reader.GetValue("APIKey", GetType(String))
        Dim secretKey = reader.GetValue("SecretKey", GetType(String))
        Using oathClient As New WebClient
            oathClient.Encoding = Encoding.Default
            oathStr =
                oathClient.DownloadString(
                    "https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id=" + apiKey + "&client_secret=" + secretKey)
        End Using

        oathJson = JObject.Parse(oathStr)

        accessToken = oathJson.SelectToken("access_token").ToString

        CencorPic(accessToken)
    End Sub
End Module
