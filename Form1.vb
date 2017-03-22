Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        If txtFirstName.Text = "" Or txtLastName.Text = "" Then
            MsgBox("Insufficient information", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim insertstatus As String = DBInsert(txtFirstName.Text, txtMInitial.Text, txtLastName.Text, cboxCoyesec.Text)
        If insertstatus = "Inserted" Then
            MsgBox("Success")
        Else
            MsgBox("Error")
        End If
        txtFirstName.Text = ""
        txtMInitial.Text = ""
        txtLastName.Text = ""
        txtLastName.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        testDBConnect()
        AcceptButton = btnRegister
    End Sub
End Class
