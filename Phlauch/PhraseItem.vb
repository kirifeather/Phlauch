Imports System.IO

Public Class PhraseItem
    Public Property Phrase As String
    Public Property ExePath As String
    Public Property Argument As String
    Public Property IconPath As String
    Public Property Description As String
    Public Property IsDefault As Boolean

    Public Overrides Function ToString() As String
        Return Phrase
    End Function
End Class
