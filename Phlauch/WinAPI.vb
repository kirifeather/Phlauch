Imports System.Runtime.InteropServices
Imports System.Threading

Module WinAPI
    Private Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer,
        ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Private Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    Private Declare Function GlobalAddAtom Lib "kernel32" Alias "GlobalAddAtomA" (ByVal lpString As String) As Integer
    Private Declare Function GlobalDeleteAtom Lib "kernel32" (ByVal nAtom As Integer) As Integer

    ' register a global hot key
    Public Function RegisterGlobalHotKey(ByVal hotkeyValue As Integer, ByVal modifiers As Integer, ByVal targetForm As Form) As Integer
        Dim hotkeyID As Integer = 0
        Try
            ' use the GlobalAddAtom API to get a unique ID (as suggested by MSDN docs)
            Static count As Integer = 0
            count += 1
            Dim atomName As String = Thread.CurrentThread.ManagedThreadId.ToString("X8") & targetForm.Name & count.ToString()
            hotkeyID = GlobalAddAtom(atomName)
            If hotkeyID = 0 Then
                Throw New Exception("Unable to generate unique hotkey ID. Error code: " &
                   Marshal.GetLastWin32Error().ToString)
            End If

            ' register the hotkey, throw if any error
            If RegisterHotKey(targetForm.Handle, hotkeyID, modifiers, hotkeyValue) = 0 Then
                Throw New Exception("Unable to register hotkey. Error code: " &
                   Marshal.GetLastWin32Error.ToString)
            End If
            Return hotkeyID
        Catch ex As Exception
            ' clean up if hotkey registration failed
            UnregisterGlobalHotKey(hotkeyID, targetForm)
            Return 0
        End Try
    End Function

    ' unregister a global hotkey
    Public Sub UnregisterGlobalHotKey(ByVal hotkeyID As Integer, ByVal targetForm As Form)
        If hotkeyID <> 0 Then
            UnregisterHotKey(targetForm.Handle, hotkeyID)
            ' clean up the atom list
            GlobalDeleteAtom(hotkeyID)
            hotkeyID = 0
        End If
    End Sub
End Module
