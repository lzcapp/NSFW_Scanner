Imports System.ComponentModel

Public Class frmMonitor
    Dim path, patharc As String
    Dim norm, sexy, porn, coun As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            path = FindProcessPath()
            If patharc <> path Then
                imgPath = path
                patharc = path
                GetOathKey()
                coun += 1
                'If pot = True Then
                'TextBox1.Text += vbCrLf + resultArr(0) + " " + resultArr(1) + " " + resultArr(2) + vbCrLf + "-----------------------------" + vbCrLf
                'Else
                TextBox1.Text += path + vbCrLf + resultArr(0) + " " + resultArr(1) + " " + resultArr(2) + vbCrLf +
                                 "-----------------------------" + vbCrLf
                'End If
                Select Case resultArr(1)
                    Case "正常"
                        norm += 1
                        If norm < 10 Then
                            lnkNorm1.Text = "0" + norm.ToString()
                        Else
                            lnkNorm1.Text = norm.ToString()
                        End If
                        lnkNormDot.Visible = True
                        lnkSexyDot.Visible = False
                        lnkPornDot.Visible = False
                    Case "性感"
                        sexy += 1
                        If sexy < 10 Then
                            lnkSexy1.Text = "0" + sexy.ToString()
                        Else
                            lnkSexy1.Text = sexy.ToString()
                        End If
                        lnkNormDot.Visible = False
                        lnkSexyDot.Visible = True
                        lnkPornDot.Visible = False
                    Case "色情"
                        porn += 1
                        If porn < 10 Then
                            lnkPorn1.Text = "0" + porn.ToString()
                        Else
                            lnkPorn1.Text = porn.ToString()
                        End If
                        lnkNormDot.Visible = False
                        lnkSexyDot.Visible = False
                        lnkPornDot.Visible = True
                End Select

                lnkNorm2.Text = (Math.Round((norm/coun), 2)*100).ToString() + "%"
                lnkSexy2.Text = (Math.Round((sexy/coun), 2)*100).ToString() + "%"
                lnkPorn2.Text = (Math.Round((porn/coun), 2)*100).ToString() + "%"
            End If
        Catch
        End Try
    End Sub

    Private Sub frmMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        patharc = "NULL"
        coun = 0
        norm = 0
        sexy = 0
        porn = 0
        Timer1.Enabled = True
        LinkLabel1.Text = "ON"
    End Sub

    Private Sub frmMonitor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Enabled = False
        LinkLabel1.Text = "OFF"
        TextBox1.Text = ""
        frmMain.Show()
    End Sub

    Private Sub LinkLabel5_Click(sender As Object, e As EventArgs) Handles LinkLabel5.Click
        If LinkLabel1.Text = "OFF"
            LinkLabel1.Text = "ON"
            Timer1.Enabled = True
        Else
            LinkLabel1.Text = "OFF"
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub LinkLabel2_Click(sender As Object, e As EventArgs) Handles LinkLabel2.Click
        If LinkLabel2.Text = "<" Then
            Me.Size = New Size(195, Me.Height)
            LinkLabel2.Text = ">"
        ElseIf LinkLabel2.Text = ">" Then
            Me.Size = New Size(409, Me.Height)
            LinkLabel2.Text = "<"
        End If
    End Sub
End Class