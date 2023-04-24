<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhraseEdit
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        IconPath = New TextBox()
        Label5 = New Label()
        ArgumentString = New TextBox()
        Label4 = New Label()
        Description = New TextBox()
        Label3 = New Label()
        ExePath = New TextBox()
        Label2 = New Label()
        Phrase = New TextBox()
        Label1 = New Label()
        ButtonOK = New Button()
        ButtonCancel = New Button()
        SuspendLayout()
        ' 
        ' IconPath
        ' 
        IconPath.Location = New Point(86, 141)
        IconPath.Name = "IconPath"
        IconPath.Size = New Size(170, 23)
        IconPath.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 144)
        Label5.Name = "Label5"
        Label5.Size = New Size(61, 15)
        Label5.TabIndex = 8
        Label5.Text = "アイコンパス"
        ' 
        ' ArgumentString
        ' 
        ArgumentString.Location = New Point(86, 112)
        ArgumentString.Name = "ArgumentString"
        ArgumentString.Size = New Size(170, 23)
        ArgumentString.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 115)
        Label4.Name = "Label4"
        Label4.Size = New Size(31, 15)
        Label4.TabIndex = 6
        Label4.Text = "引数"
        ' 
        ' Description
        ' 
        Description.Location = New Point(86, 42)
        Description.Name = "Description"
        Description.Size = New Size(170, 23)
        Description.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 15)
        Label3.TabIndex = 2
        Label3.Text = "表示名"
        ' 
        ' ExePath
        ' 
        ExePath.Location = New Point(86, 83)
        ExePath.Name = "ExePath"
        ExePath.Size = New Size(170, 23)
        ExePath.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 86)
        Label2.Name = "Label2"
        Label2.Size = New Size(68, 15)
        Label2.TabIndex = 4
        Label2.Text = "呼び出しパス"
        ' 
        ' Phrase
        ' 
        Phrase.Location = New Point(86, 13)
        Phrase.Name = "Phrase"
        Phrase.Size = New Size(170, 23)
        Phrase.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 0
        Label1.Text = "フレーズ"
        ' 
        ' ButtonOK
        ' 
        ButtonOK.DialogResult = DialogResult.OK
        ButtonOK.Location = New Point(46, 185)
        ButtonOK.Name = "ButtonOK"
        ButtonOK.Size = New Size(75, 23)
        ButtonOK.TabIndex = 10
        ButtonOK.Text = "&OK"
        ButtonOK.UseVisualStyleBackColor = True
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.DialogResult = DialogResult.Cancel
        ButtonCancel.Location = New Point(161, 185)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 23)
        ButtonCancel.TabIndex = 11
        ButtonCancel.Text = "&Cancel"
        ButtonCancel.UseVisualStyleBackColor = True
        ' 
        ' PhraseEdit
        ' 
        AcceptButton = ButtonOK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = ButtonCancel
        ClientSize = New Size(278, 222)
        Controls.Add(ButtonCancel)
        Controls.Add(ButtonOK)
        Controls.Add(IconPath)
        Controls.Add(Label5)
        Controls.Add(ArgumentString)
        Controls.Add(Label4)
        Controls.Add(Description)
        Controls.Add(Label3)
        Controls.Add(ExePath)
        Controls.Add(Label2)
        Controls.Add(Phrase)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "PhraseEdit"
        Text = "フレーズ編集"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents IconPath As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ArgumentString As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Description As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ExePath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Phrase As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonOK As Button
    Friend WithEvents ButtonCancel As Button
End Class
