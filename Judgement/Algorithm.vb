Imports System.Drawing.Imaging
Imports System.IO

Module Algorithm
    Public ImgPath As String

    Public Function ImgBase64()
        Dim imgBitmap = New Bitmap(imgPath)
        frmMain.PictureBox2.Image = imgBitmap
        Dim memStream = New MemoryStream
        imgBitmap.Save(memStream, ImageFormat.Jpeg)
        Dim arr = New Byte((memStream.Length) - 1) {}
        memStream.Position = 0
        memStream.Read(arr, 0, CType(memStream.Length, Integer))
        memStream.Close()
        Return Convert.ToBase64String(arr)
    End Function
End Module
