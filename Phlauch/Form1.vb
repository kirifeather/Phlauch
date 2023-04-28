Imports System.IO
''' <summary>
''' メイン画面
''' </summary>
Public Class Form1
    Private WithEvents _globalHotkey As GlobalHotkey
    Private _setting As Setting
    Private Const AppName As String = "Phlauch"
    Private Const SettingPhrase As String = "Setting"
    Private Const ExitPhrase As String = "Exit"
    ''' <summary>
    ''' グローバルホットキー処理の準備
    ''' </summary>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        _globalHotkey = New GlobalHotkey(Me)    'ハンドル作成前に呼び出す
    End Sub
    ''' <summary>
    ''' グローバルホットキーによる表示/非表示切り替え
    ''' </summary>
    ''' <param name="sender">イベント発生元インスタンス(GlobalHotkey)</param>
    ''' <param name="e">ホットキーに対応するKeyEventArgs</param>
    Private Sub HookGlobalHotkey_HotkeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _globalHotkey.HotkeyPressed
        If Me.WindowState = FormWindowState.Normal AndAlso Me.Visible Then
            Me.Visible = False
        ElseIf Form.ActiveForm Is Nothing Then
            Me.Visible = True
            Me.Phrase.Text = ""
            Me.Activate()
            Me.BringToFront()
            Me.Phrase.Focus()
        End If
    End Sub
    ''' <summary>
    ''' 起動時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _setting = Setting.Load
        _globalHotkey.UnregisterAllOriginalHotkey()
        '_globalHotkey.RegisterOriginalHotkey(Keys.IMEConvert, 28, GlobalHotkey.ModKeys.None)
        _globalHotkey.RegisterOriginalHotkey(Keys.CapsLock, 240, GlobalHotkey.ModKeys.None)
        Label1.Text = AppName

        InitializePhrases()
        PictureBox1.Image = PictureBox1.InitialImage
    End Sub
    ''' <summary>
    ''' フレーズ入力欄のオートコンプリート候補の再設定
    ''' </summary>
    Private Sub InitializePhrases()
        Me.Phrase.AutoCompleteCustomSource.Clear()

        For Each x In _setting.Phrases
            Me.Phrase.AutoCompleteCustomSource.Add(x.Phrase)
        Next
    End Sub
    ''' <summary>
    ''' フレーズに応じたプロセスを実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Dim words = Split(Trim(Me.Phrase.Text), " ", 2, CompareMethod.Binary)
        Me.Phrase.Text = ""
        Label1.Text = AppName
        Dim settingFlag = False
        For Each x In _setting.Phrases
            If String.Equals(words(0), x.Phrase, StringComparison.OrdinalIgnoreCase) Then
                If x.IsDefault Then
                    '初期登録コマンドの実行
                    Select Case x.Phrase
                        Case SettingPhrase
                            settingFlag = True
                        Case ExitPhrase
                            Me.Close()
                    End Select
                Else
                    'ユーザー登録コマンドの実行
                    Dim prc = New System.Diagnostics.ProcessStartInfo()
                    prc.FileName = x.ExePath
                    If words.Length > 1 Then
                        prc.Arguments = x.Argument & " " & words(1)
                    Else
                        prc.Arguments = x.Argument
                    End If
                    prc.UseShellExecute = True
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
        'フレーズ列挙操作中のアイテム変更を避けるため最後に処理
        If settingFlag Then
            EditSetting()
        End If
    End Sub
    ''' <summary>
    ''' 設定画面の表示と設定の保存
    ''' </summary>
    Private Sub EditSetting()
        Using dlg = New SettingForm
            dlg._setting = Me._setting
            If dlg.ShowDialog = DialogResult.OK Then
                _setting.Save()
                InitializePhrases()
            End If
        End Using
    End Sub
    ''' <summary>
    ''' Escボタンによる非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Phrase.Text = ""
        Me.Visible = False
    End Sub
    ''' <summary>
    ''' フレーズ入力中の処理。アイコンや表示文言の変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Phrase_TextChanged(sender As Object, e As EventArgs) Handles Phrase.TextChanged
        Dim words = Split(Trim(Me.Phrase.Text), " ", 2, CompareMethod.Binary)
        For Each x In _setting.Phrases
            If String.Equals(words(0), x.Phrase, StringComparison.OrdinalIgnoreCase) Then
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
            Label1.Text = AppName
            PictureBox1.Image = PictureBox1.InitialImage
        Else
            Label1.Text = ""
            PictureBox1.Image = Nothing
        End If
    End Sub
    ''' <summary>
    ''' 表示時に画面の表示域に収まっていなければ真ん中へ移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            If Not IsOnScreen() Then
                Dim rect = System.Windows.Forms.Screen.GetBounds(Me)
                Me.Left = rect.Left + rect.Width / 2 - Me.Width / 2
                Me.Top = rect.Top + rect.Height / 2 - Me.Height / 2
            End If
        End If
    End Sub
    ''' <summary>
    ''' 起動時のフォームを非表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Visible = False
        Me.Opacity = 100
    End Sub
    ''' <summary>
    ''' 画面の表示域に収まっているか判定
    ''' </summary>
    ''' <returns></returns>
    Private Function IsOnScreen()
        For Each s In System.Windows.Forms.Screen.AllScreens
            If s.WorkingArea.Contains(New Rectangle(Me.Location, Me.Size)) Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' タスクトレイアイコンクリックにより表示/非表示切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        HookGlobalHotkey_HotkeyPressed(Nothing, Nothing)
    End Sub
    ''' <summary>
    ''' 終了時処理。グローバルホットキーの登録解除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        _globalHotkey.UnregisterAllOriginalHotkey()
        _globalHotkey.Dispose()
    End Sub
    ''' <summary>
    ''' Tabキーで補完確定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Phrase_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Phrase.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If Phrase.Text <> "" AndAlso Phrase.SelectedText <> "" Then
                Phrase.Text += " "
                Phrase.SelectionStart = Phrase.Text.Length
                e.IsInputKey = True
            End If
        End If
    End Sub
End Class
