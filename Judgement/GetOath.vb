Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Module GetOath
    Public Sub GetOathKey()
        Dim accessToken As String
        Dim oathJson As JObject
        Dim oathStr As String
        Using oathClient As New WebClient
            oathClient.Encoding = Encoding.Default
            oathStr =
                oathClient.DownloadString(
                    "https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id=lmbx87y4E8xah1yk5ribjiOt&client_secret=CdpKSbtMrSZ2H3xiNgWYg4amKSjNUrdE&")
        End Using

        oathJson = JObject.Parse(oathStr)

        accessToken = oathJson.SelectToken("access_token").ToString

        CencorPic(accessToken)
    End Sub
End Module
