Imports System.Data.SqlClient
Public Class Form6
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dtc As DataTableCollection
    Dim bs As New BindingSource
    Dim da1 As SqlDataAdapter
    Dim ds1 As DataSet
    Dim dtc1 As DataTableCollection
    Dim bs1 As New BindingSource
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manik\source\repos\WinFormsApp4\WinFormsApp4\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True")
        cn.Open()
        ds = New DataSet
        dtc = ds.Tables
        da = New SqlDataAdapter("select * from EMPLOYEE_DETAILS", cn)
        da.Fill(ds, "EMPLOYEE_DETAILS")
        Dim view As New DataView(dtc(0))
        bs.DataSource = view
        DataGridView1.DataSource = view
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form7.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form8.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form9.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ds1 = New DataSet
        dtc1 = ds1.Tables
        da1 = New SqlDataAdapter("select * from EMPLOYEE_DETAILS", cn)
        da1.Fill(ds1, "EMPLOYEE_DETAILS")
        Dim view1 As New DataView(dtc1(0))
        bs1.DataSource = view1
        DataGridView1.DataSource = view1
    End Sub
End Class