Imports System.IO

Public Class FrmMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picboxSample.AllowDrop = True
    End Sub

    Private Sub PicboxSample_DragDrop(sender As Object, e As DragEventArgs) Handles picboxSample.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ImgPath = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
            Dim f = New FileInfo(ImgPath)
            If (f.Length < 4000000) Then
                GetOathKey()
                picboxSample.Visible = False
                picboxSample.Enabled = False
                picboxSample.Dispose()
                PictureBox2.AllowDrop = True
            Else
                MsgBox("图片文件需小于4MB。", MsgBoxStyle.OkOnly, "PunkyGirl: Waring")
            End If
        End If
    End Sub

    Private Shared Sub PicboxSample_DragEnter(sender As Object, e As DragEventArgs) Handles picboxSample.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Shared Sub PictureBox2_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            ImgPath = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
            Dim f = New FileInfo(ImgPath)
            If (f.Length < 4000000) Then
                GetOathKey()
            Else
                MsgBox("图片文件需小于4MB。", MsgBoxStyle.OkOnly, "PunkyGirl: Waring")
            End If
        End If
    End Sub

    Private Shared Sub PictureBox2_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
End Class
