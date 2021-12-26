Imports System.Data.SqlClient
Public Class Form1
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New SqlCommand("select * from ADMINISTRATOR where USERNAME='" & TextBox1.Text & "'and PASSWORD ='" & TextBox2.Text & "';", cn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            TextBox1.Clear()
            TextBox2.Clear()
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Username / Password", MsgBoxStyle.Critical)
                TextBox1.Clear()
                TextBox2.Clear()
            End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manik\source\repos\WinFormsApp4\WinFormsApp4\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True")
        cn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form18.Show()
    End Sub
End Class
