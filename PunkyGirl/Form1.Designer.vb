<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblType = New System.Windows.Forms.LinkLabel()
        Me.lblPercent = New System.Windows.Forms.LinkLabel()
        Me.picboxSample = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.picboxSample,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblType
        '
        Me.lblType.AutoEllipsis = True
        Me.lblType.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblType.LinkArea = New System.Windows.Forms.LinkArea(0, 0)
        Me.lblType.Location = New System.Drawing.Point(47, 52)
        Me.lblType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(56, 103)
        Me.lblType.TabIndex = 4
        Me.lblType.Text = "待定"
        '
        'lblPercent
        '
        Me.lblPercent.AutoEllipsis = True
        Me.lblPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblPercent.Font = New System.Drawing.Font("黑体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblPercent.LinkArea = New System.Windows.Forms.LinkArea(0, 0)
        Me.lblPercent.Location = New System.Drawing.Point(109, 56)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(195, 89)
        Me.lblPercent.TabIndex = 5
        Me.lblPercent.Text = "99.999%  概率" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "不确定"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picboxSample
        '
        Me.picboxSample.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.picboxSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picboxSample.Image = Global.PunkyGirl.My.Resources.Resources.GreenDam2
        Me.picboxSample.InitialImage = Global.PunkyGirl.My.Resources.Resources.GreenDam2
        Me.picboxSample.Location = New System.Drawing.Point(4, 4)
        Me.picboxSample.Margin = New System.Windows.Forms.Padding(4)
        Me.picboxSample.Name = "picboxSample"
        Me.picboxSample.Size = New System.Drawing.Size(345, 507)
        Me.picboxSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxSample.TabIndex = 7
        Me.picboxSample.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(23, 372)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(80, 116)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = Global.PunkyGirl.My.Resources.Resources.PunkyGirl
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(345, 508)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PunkyGirl.My.Resources.Resources.Scan
        Me.PictureBox3.Location = New System.Drawing.Point(13, 363)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 133)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(356, 516)
        Me.Controls.Add(Me.picboxSample)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "风纪审查 · 黄图"
        CType(Me.picboxSample,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblType As LinkLabel
    Friend WithEvents lblPercent As LinkLabel
    Friend WithEvents picboxSample As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
