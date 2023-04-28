<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Phrase = New TextBox()
        NotifyIcon1 = New NotifyIcon(components)
        ButtonOk = New Button()
        ButtonCancel = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), Image)
        PictureBox1.Location = New Point(4, 4)
        PictureBox1.Margin = New Padding(0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(32, 32)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.Location = New Point(41, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(123, 15)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Phrase
        ' 
        Phrase.AcceptsTab = True
        Phrase.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Phrase.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Phrase.AutoCompleteSource = AutoCompleteSource.CustomSource
        Phrase.ImeMode = ImeMode.Disable
        Phrase.Location = New Point(41, 15)
        Phrase.Name = "Phrase"
        Phrase.Size = New Size(123, 23)
        Phrase.TabIndex = 2
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = "Phlauch"
        NotifyIcon1.Visible = True
        ' 
        ' ButtonOk
        ' 
        ButtonOk.DialogResult = DialogResult.OK
        ButtonOk.Location = New Point(49, 44)
        ButtonOk.Name = "ButtonOk"
        ButtonOk.Size = New Size(75, 23)
        ButtonOk.TabIndex = 3
        ButtonOk.TabStop = False
        ButtonOk.Text = "Button1"
        ButtonOk.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.DialogResult = DialogResult.Cancel
        ButtonCancel.Location = New Point(132, 43)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 23)
        ButtonCancel.TabIndex = 4
        ButtonCancel.TabStop = False
        ButtonCancel.Text = "Button1"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AcceptButton = ButtonOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = ButtonCancel
        ClientSize = New Size(166, 41)
        ControlBox = False
        Controls.Add(ButtonCancel)
        Controls.Add(ButtonOk)
        Controls.Add(Phrase)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Form1"
        Opacity = 0R
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Phrase As TextBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ButtonOk As Button
    Friend WithEvents ButtonCancel As Button
End Class
