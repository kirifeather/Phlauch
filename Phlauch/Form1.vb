Imports System.IO
Imports System.Resources

Public Class Form1
    Private WithEvents _globalHotkey As GlobalHotkey
    Private _setting As Setting

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        _globalHotkey = New GlobalHotkey(Me)
        _setting = Setting.Load
    End Sub

    Private Sub HookGlobalHotkey_HotkeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _globalHotkey.HotkeyPressed
        If Me.WindowState = FormWindowState.Normal AndAlso Me.Visible Then
            Me.Visible = False
        ElseIf Form.ActiveForm Is Nothing Then
            Me.Visible = True
            Me.Activate()
            Me.BringToFront()
            Me.Phrase.Focus()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _globalHotkey.UnregisterAllOriginalHotkey()
        '_globalHotkey.RegisterOriginalHotkey(Keys.IMEConvert, 28, GlobalHotkey.ModKeys.None)
        _globalHotkey.RegisterOriginalHotkey(Keys.CapsLock, 240, GlobalHotkey.ModKeys.None)
        Label1.Text = "Phlauch"

        InitializePhrases()
        PictureBox1.Image = PictureBox1.InitialImage
    End Sub

    Private Sub InitializePhrases()
        Me.Phrase.AutoCompleteCustomSource.Clear()

        For Each x In _setting.Phrases
            Me.Phrase.AutoCompleteCustomSource.Add(x.Phrase)
        Next
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Dim word = Trim(Me.Phrase.Text)
        Me.Phrase.Text = ""
        Label1.Text = "Phlauch"
        For i = 0 To _setting.Phrases.Count - 1
            Dim x = _setting.Phrases(i)
            If String.Equals(word, x.Phrase, StringComparison.OrdinalIgnoreCase) Then
                If x.IsDefault Then
                    Select Case x.Phrase
                        Case "Setting"
                            EditSetting()
                        Case "Exit"
                            Me.Close()
                    End Select
                Else
                    Dim prc = New System.Diagnostics.ProcessStartInfo()
                    prc.FileName = x.ExePath
                    prc.Arguments = x.Argument
                    Try
                        Process.Start(prc)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try
                End If
                Me.Visible = False
                Exit For
            End If
        Next
    End Sub

    Private Sub EditSetting()
        Using dlg = New SettingForm
            dlg._setting = Me._setting
            If dlg.ShowDialog = DialogResult.OK Then
                _setting.Save()
                InitializePhrases()
            End If
        End Using
    End Sub
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Phrase.Text = ""
        Me.Visible = False
    End Sub

    Private Sub Phrase_TextChanged(sender As Object, e As EventArgs) Handles Phrase.TextChanged
        Dim word = Trim(Me.Phrase.Text)
        For Each x In _setting.Phrases
            If String.Equals(word, x.Phrase, StringComparison.OrdinalIgnoreCase) Then
                Label1.Text = x.Description
                Dim icoPath = If(Path.Exists(x.IconPath), x.IconPath, x.ExePath)
                If Not Path.Exists(icoPath) Then Exit Sub
                Dim ic = System.Drawing.Icon.ExtractAssociatedIcon(icoPath)
                Dim bmp = ic.ToBitmap
                PictureBox1.Image = bmp
                Exit Sub
            End If
        Next
        If Phrase.Text = "" Then
            Label1.Text = "Phlauch"
            PictureBox1.Image = PictureBox1.InitialImage
        Else
            Label1.Text = ""
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            If Not IsOnScreen() Then
                Dim rect = System.Windows.Forms.Screen.GetBounds(Me)
                Me.Left = rect.Left + rect.Width / 2 - Me.Width / 2
                Me.Top = rect.Top + rect.Height / 2 - Me.Height / 2
            End If
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Visible = False
        Me.Opacity = 100
    End Sub

    Private Function IsOnScreen()
        For Each s In System.Windows.Forms.Screen.AllScreens
            If s.WorkingArea.Contains(New Rectangle(Me.Location, Me.Size)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        HookGlobalHotkey_HotkeyPressed(Nothing, Nothing)
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        _globalHotkey.UnregisterAllOriginalHotkey()
    End Sub
End Class
