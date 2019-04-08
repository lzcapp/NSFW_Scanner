Imports System.Management

Module FindProcess
    Public Function FindProcessPath()
        If Process.GetProcessesByName("Honeyview").Length > 0 Then
            Dim item As Process = Process.GetProcessesByName("Honeyview")(0)
            Dim query As String = String.Format("SELECT CommandLine FROM Win32_Process WHERE ProcessId = {0}", item.Id)
            Dim searcher = New ManagementObjectSearcher(query)
            Dim retObjectCollection As ManagementObjectCollection = searcher.[Get]()
            Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator =
                    retObjectCollection.GetEnumerator()
            While enumerator.MoveNext()
                Dim retObject = CType(enumerator.Current, ManagementObject)
                Dim path As String
                path = Split(Split(retObject("CommandLine"), """ """)(1), """")(0)
                Return path
            End While
            'ElseIf Process.GetProcessesByName("PotPlayer").Length > 0 Then
            '    pot = True
            '    Dim memory As Image = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            '    Dim g As Graphics = Graphics.FromImage(memory)
            '    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top, 0, 0, New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            '    Form1.PictureBox2.Image = memory
            '    Dim memStream As MemoryStream = New MemoryStream
            '    memory.Save(memStream, Imaging.ImageFormat.Jpeg)
            '    Dim arr() As Byte = New Byte((memStream.Length) - 1) {}
            '    memStream.Position = 0
            '    memStream.Read(arr, 0, CType(memStream.Length, Integer))
            '    memStream.Close()
            '    Return Convert.ToBase64String(arr)
        End If
        Return 0
    End Function
End Module
