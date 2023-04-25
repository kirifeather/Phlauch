
''' <summary>
''' フレーズの構成要素
''' </summary>
Public Class PhraseItem
    Public Property Phrase As String
    Public Property ExePath As String
    Public Property Argument As String
    Public Property IconPath As String
    Public Property Description As String
    Public Property IsDefault As Boolean
    ''' <summary>
    ''' フレーズ一覧での表示用
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return Phrase
    End Function
End Class
