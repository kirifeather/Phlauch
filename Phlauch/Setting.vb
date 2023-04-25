''' <summary>
''' 設定の保持、ファイルへの書き出し、読み出し
''' </summary>
<Serializable()>
Public Class Setting
    Public Property Phrases As New List(Of PhraseItem)

    Private Shared lockObj As New Object
    ''' <summary>
    ''' 設定の読み出し
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Load() As Setting
        Try
            SyncLock lockObj
                Using fs As New IO.FileStream("Setting.xml", IO.FileMode.Open)
                    fs.Position = 0
                    Dim xs As New Xml.Serialization.XmlSerializer(GetType(Setting))
                    Dim instance As Setting = DirectCast(xs.Deserialize(fs), Setting)
                    fs.Close()
                    Return instance
                End Using
            End SyncLock
        Catch ex As System.IO.FileNotFoundException
            Dim instance = New Setting
            instance.Initialize()
            Return instance
        Catch ex As Exception
            MessageBox.Show("設定ファイルを開けませんでした", "Load Settings", MessageBoxButtons.OK)
            Dim instance = New Setting
            instance.Initialize()
            Return instance
        End Try
    End Function
    ''' <summary>
    ''' 設定の書き出し
    ''' </summary>
    Public Sub Save()
        Dim cnt As Integer = 0
        Dim err As Boolean = False
        Dim fileName As String = "Setting.xml"
        Dim Instance = Me
        Do
            err = False
            cnt += 1
            Try
                SyncLock lockObj
                    Using fs As New IO.FileStream(fileName, IO.FileMode.Create)
                        fs.Position = 0
                        Dim xs As New Xml.Serialization.XmlSerializer(GetType(Setting))
                        xs.Serialize(fs, Instance)
                        fs.Flush()
                        fs.Close()
                    End Using
                    Dim fi As New IO.FileInfo(fileName)
                    If fi.Length = 0 Then
                        If cnt > 3 Then
                            Throw New Exception
                            Exit Sub
                        End If
                        Threading.Thread.Sleep(1000)
                        err = True
                    End If
                End SyncLock
            Catch ex As Exception
                '検証エラー or 書き込みエラー
                If cnt > 3 Then
                    'リトライオーバー
                    MessageBox.Show("設定を保存できませんでした", "Save Settings", MessageBoxButtons.OK)
                    Exit Sub
                End If
                'リトライ
                Threading.Thread.Sleep(1000)
                err = True
            End Try
        Loop While err
    End Sub
    ''' <summary>
    ''' 設定の初期化
    ''' </summary>
    Public Sub Initialize()
        Phrases.Add(New PhraseItem() With {.IsDefault = True, .Phrase = "Setting", .Description = "設定画面を開く"})
        Phrases.Add(New PhraseItem() With {.IsDefault = True, .Phrase = "Exit", .Description = "アプリを終了する"})
    End Sub
End Class
