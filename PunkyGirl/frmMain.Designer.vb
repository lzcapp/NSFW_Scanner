<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 51)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "人力检查"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(150, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 51)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "AI监控"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 76)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "风纪审查"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
