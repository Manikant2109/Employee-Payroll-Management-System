Imports System.Data.SqlClient
Public Class Form5
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim da1, da2, da3 As SqlDataAdapter
    Dim dt1, dt2, dt3 As DataTable
    Dim ds As DataSet
    Dim dtc As DataTableCollection
    Dim bs As New BindingSource
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manik\source\repos\WinFormsApp4\WinFormsApp4\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True")
        cn.Open()
        da1 = New SqlDataAdapter("select * from DEPARTMENT_DETAILS", cn)
        dt1 = New DataTable
        da1.Fill(dt1)
        'Insert the Default Item to DataTable.
        Dim row1 As DataRow = dt1.NewRow()
        row1(0) = 0
        row1(1) = "Please select"
        dt1.Rows.InsertAt(row1, 0)
        'Assign DataTable as DataSource.
        ComboBox1.DataSource = dt1
        ComboBox1.DisplayMember = "DEPARTMENT_NAME"
        ComboBox1.ValueMember = "DEPARTMENT_CODE"

        da2 = New SqlDataAdapter("select * from EMPLOYEE_DETAILS", cn)
        dt2 = New DataTable
        da2.Fill(dt2)
        'Insert the Default Item to DataTable.
        Dim row2 As DataRow = dt2.NewRow()
        row2(0) = 0
        dt2.Rows.InsertAt(row2, 0)
        'Assign DataTable as DataSource.
        ComboBox2.DataSource = dt2
        ComboBox2.DisplayMember = "EMPLOYEE_NAME"
        ComboBox2.ValueMember = "EMPLOYEE_CODE"

        da3 = New SqlDataAdapter("select * from EMPLOYEE_DETAILS", cn)
        dt3 = New DataTable
        da3.Fill(dt3)
        'Insert the Default Item to DataTable.
        Dim row3 As DataRow = dt3.NewRow()
        row3(0) = 0
        dt3.Rows.InsertAt(row3, 0)
        'Assign DataTable as DataSource.
        ComboBox3.DataSource = dt3
        ComboBox3.DisplayMember = "EMPLOYEE_NAME"
        ComboBox3.ValueMember = "EMPLOYEE_CODE"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        dtc = ds.Tables
        da = New SqlDataAdapter("select * from EMPLOYEE_DETAILS where DEPARTMENT_NAME = '" & ComboBox1.Text & "'", cn)
        da.Fill(ds, "EMPLOYEE_DETAILS")
        Dim view As New DataView(dtc(0))
        bs.DataSource = view
        DataGridView1.DataSource = view
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ds = New DataSet
        dtc = ds.Tables
        da = New SqlDataAdapter("select * from ATTENDANCE where EMPLOYEE_NAME = '" & ComboBox2.Text & "'and EDATE between convert(date,'" & DateTimePicker2.Value & "',103) and convert(date,'" & DateTimePicker1.Value & "',103);", cn)
        da.Fill(ds, "ATTENDANCE")
        Dim view As New DataView(dtc(0))
        bs.DataSource = view
        DataGridView1.DataSource = view
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ds = New DataSet
        dtc = ds.Tables
        da = New SqlDataAdapter("select * from PAYROLL where EMPLOYEE_NAME = '" & ComboBox3.Text & "'", cn)
        da.Fill(ds, "PAYROLL")
        Dim view As New DataView(dtc(0))
        bs.DataSource = view
        DataGridView1.DataSource = view
    End Sub
End Class