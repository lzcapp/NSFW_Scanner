Public Class frmMain
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmMonitor.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Hide()
    End Sub
End Class