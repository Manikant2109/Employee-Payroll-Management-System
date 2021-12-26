Imports System.Data.SqlClient
Public Class Form4
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dtc As DataTableCollection
    Dim bs As New BindingSource
    Dim da1 As SqlDataAdapter
    Dim ds1 As DataSet
    Dim dtc1 As DataTableCollection
    Dim bs1 As New BindingSource

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manik\source\repos\WinFormsApp4\WinFormsApp4\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True")
        cn.Open()
        ds = New DataSet
        dtc = ds.Tables
        da = New SqlDataAdapter("select * from DEPARTMENT_DETAILS", cn)
        da.Fill(ds, "DEPARTMENT_DETAILS")
        Dim view As New DataView(dtc(0))
        bs.DataSource = view
        DataGridView1.DataSource = view
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ds1 = New DataSet
        dtc1 = ds1.Tables
        da1 = New SqlDataAdapter("select * from DEPARTMENT_DETAILS", cn)
        da1.Fill(ds1, "DEPARTMENT_DETAILS")
        Dim view1 As New DataView(dtc1(0))
        bs1.DataSource = view1
        DataGridView1.DataSource = view1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form10.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        form11.show
    End Sub
End Class