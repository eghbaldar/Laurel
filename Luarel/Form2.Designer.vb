<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLoadPoster = New System.Windows.Forms.Button()
        Me.btnAddTextAndExport = New System.Windows.Forms.Button()
        Me.picPoster = New System.Windows.Forms.PictureBox()
        CType(Me.picPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadPoster
        '
        Me.btnLoadPoster.Location = New System.Drawing.Point(109, 48)
        Me.btnLoadPoster.Name = "btnLoadPoster"
        Me.btnLoadPoster.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadPoster.TabIndex = 0
        Me.btnLoadPoster.Text = "Button1"
        Me.btnLoadPoster.UseVisualStyleBackColor = True
        '
        'btnAddTextAndExport
        '
        Me.btnAddTextAndExport.Location = New System.Drawing.Point(199, 48)
        Me.btnAddTextAndExport.Name = "btnAddTextAndExport"
        Me.btnAddTextAndExport.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTextAndExport.TabIndex = 1
        Me.btnAddTextAndExport.Text = "Button2"
        Me.btnAddTextAndExport.UseVisualStyleBackColor = True
        '
        'picPoster
        '
        Me.picPoster.Location = New System.Drawing.Point(343, 34)
        Me.picPoster.Name = "picPoster"
        Me.picPoster.Size = New System.Drawing.Size(205, 286)
        Me.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPoster.TabIndex = 2
        Me.picPoster.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.picPoster)
        Me.Controls.Add(Me.btnAddTextAndExport)
        Me.Controls.Add(Me.btnLoadPoster)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.picPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLoadPoster As Button
    Friend WithEvents btnAddTextAndExport As Button
    Friend WithEvents picPoster As PictureBox
End Class
