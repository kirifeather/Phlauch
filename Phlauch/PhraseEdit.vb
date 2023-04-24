Public Class PhraseEdit
    Public target As PhraseItem

    Private Sub PhraseEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If target IsNot Nothing Then
            With target
                Phrase.Text = .Phrase
                Description.Text = .Description
                ExePath.Text = .ExePath
                ArgumentString.Text = .Argument
                IconPath.Text = .IconPath
            End With
        Else
            target = New PhraseItem
        End If
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        With target
            .Phrase = Trim(Phrase.Text)
            .Description = Trim(Description.Text)
            .ExePath = Trim(ExePath.Text)
            .Argument = Trim(ArgumentString.Text)
            .IconPath = Trim(IconPath.Text)
        End With
    End Sub
End Class