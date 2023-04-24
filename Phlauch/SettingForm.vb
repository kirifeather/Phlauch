﻿Imports System.Globalization

Public Class SettingForm
    Public Property _setting As Setting

    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sorted = New SortedList(Of String, PhraseItem)
        For Each x In _setting.Phrases
            sorted.Add(x.Phrase, x)
        Next
        For Each x In sorted
            PhraseList.Items.Add(x.Value)
        Next
    End Sub

    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        Dim dlg = New PhraseEdit
        If dlg.ShowDialog = DialogResult.OK Then
            PhraseList.Items.Add(dlg.target)
        End If
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Dim dlg = New PhraseEdit
        If PhraseList.SelectedItem Is Nothing Then Exit Sub
        Dim itm = DirectCast(PhraseList.SelectedItem, PhraseItem)
        If itm.IsDefault Then Exit Sub
        Dim target = New PhraseItem With {.Phrase = itm.Phrase, .Description = itm.Description, .ExePath = itm.ExePath, .Argument = itm.Argument, .IconPath = itm.IconPath}
        dlg.target = target
        If dlg.ShowDialog = DialogResult.OK Then
            PhraseList.Items.RemoveAt(PhraseList.SelectedIndex)
            PhraseList.Items.Add(dlg.target)
        End If
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If PhraseList.SelectedItem Is Nothing Then Exit Sub
        If DirectCast(PhraseList.SelectedItem, PhraseItem).IsDefault Then Exit Sub
        PhraseList.Items.RemoveAt(PhraseList.SelectedIndex)
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        _setting.Phrases.Clear()
        Dim sorted = New SortedList(Of String, PhraseItem)
        For Each x In PhraseList.Items
            Dim p = DirectCast(x, PhraseItem)
            sorted.Add(p.Phrase, p)
        Next
        _setting.Phrases.AddRange(sorted.Values)
    End Sub
End Class