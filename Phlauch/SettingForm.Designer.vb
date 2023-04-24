<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        ButtonDelete = New Button()
        ButtonEdit = New Button()
        ButtonNew = New Button()
        PhraseList = New ListBox()
        ButtonSave = New Button()
        ButtonClose = New Button()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Location = New Point(12, 12)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(361, 391)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(ButtonDelete)
        TabPage1.Controls.Add(ButtonEdit)
        TabPage1.Controls.Add(ButtonNew)
        TabPage1.Controls.Add(PhraseList)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(353, 363)
        TabPage1.TabIndex = 0
        TabPage1.Text = "フレーズ"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' ButtonDelete
        ' 
        ButtonDelete.Location = New Point(238, 131)
        ButtonDelete.Name = "ButtonDelete"
        ButtonDelete.Size = New Size(100, 23)
        ButtonDelete.TabIndex = 3
        ButtonDelete.Text = "削除(&D)"
        ButtonDelete.UseVisualStyleBackColor = True
        ' 
        ' ButtonEdit
        ' 
        ButtonEdit.Location = New Point(238, 72)
        ButtonEdit.Name = "ButtonEdit"
        ButtonEdit.Size = New Size(100, 23)
        ButtonEdit.TabIndex = 2
        ButtonEdit.Text = "編集(&E)"
        ButtonEdit.UseVisualStyleBackColor = True
        ' 
        ' ButtonNew
        ' 
        ButtonNew.Location = New Point(238, 22)
        ButtonNew.Name = "ButtonNew"
        ButtonNew.Size = New Size(100, 23)
        ButtonNew.TabIndex = 1
        ButtonNew.Text = "新規追加(&N)"
        ButtonNew.UseVisualStyleBackColor = True
        ' 
        ' PhraseList
        ' 
        PhraseList.FormattingEnabled = True
        PhraseList.ItemHeight = 15
        PhraseList.Location = New Point(6, 6)
        PhraseList.Name = "PhraseList"
        PhraseList.Size = New Size(214, 349)
        PhraseList.TabIndex = 0
        ' 
        ' ButtonSave
        ' 
        ButtonSave.DialogResult = DialogResult.OK
        ButtonSave.Location = New Point(62, 407)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(75, 23)
        ButtonSave.TabIndex = 1
        ButtonSave.Text = "保存(&S)"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonClose
        ' 
        ButtonClose.DialogResult = DialogResult.Cancel
        ButtonClose.Location = New Point(231, 407)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(75, 23)
        ButtonClose.TabIndex = 2
        ButtonClose.Text = "閉じる"
        ButtonClose.UseVisualStyleBackColor = True
        ' 
        ' SettingForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = ButtonClose
        ClientSize = New Size(389, 440)
        Controls.Add(ButtonClose)
        Controls.Add(ButtonSave)
        Controls.Add(TabControl1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "SettingForm"
        Text = "設定"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PhraseList As ListBox
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ButtonNew As Button
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonClose As Button
End Class
