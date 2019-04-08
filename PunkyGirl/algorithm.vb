Imports System.Drawing.Imaging
Imports System.IO

Module Algorithm
    Public imgPath As String

    Public Function ImgBase64()
        Dim imgBitmap = New Bitmap(imgPath)
        Form1.PictureBox2.Image = imgBitmap
        Dim memStream = New MemoryStream
        imgBitmap.Save(memStream, ImageFormat.Jpeg)
        Dim arr = New Byte((memStream.Length) - 1) {}
        memStream.Position = 0
        memStream.Read(arr, 0, CType(memStream.Length, Integer))
        memStream.Close()
        Return Convert.ToBase64String(arr)
    End Function
End Module
