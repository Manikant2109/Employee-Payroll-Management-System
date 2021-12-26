Imports System.Data.SqlClient
Public Class Form7
    Dim cn As SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dt1 As DataTable
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\manik\source\repos\WinFormsApp4\WinFormsApp4\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True")
        cn.Open()
        da = New SqlDataAdapter("select * from DEPARTMENT_DETAILS", cn)
        dt = New DataTable
        dt1 = New DataTable
        da.Fill(dt)
        'Insert the Default Item to DataTable.
        Dim row As DataRow = dt.NewRow()
        row(0) = 0
        row(1) = "Please select"
        dt.Rows.InsertAt(row, 0)
        'Assign DataTable as DataSource.
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "DEPARTMENT_CODE"
        ComboBox1.ValueMember = "DEPARTMENT_NAME"
        da.Fill(dt1)
        'Insert the Default Item to DataTable.
        Dim row1 As DataRow = dt1.NewRow()
        row1(0) = 0
        row1(1) = "Please select"
        dt1.Rows.InsertAt(row1, 0)
        'Assign DataTable as DataSource.
        ComboBox2.DataSource = dt1
        ComboBox2.DisplayMember = "DEPARTMENT_NAME"
        ComboBox2.ValueMember = "DEPARTMENT_CODE"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New SqlCommand("insert into EMPLOYEE_DETAILS([EMPLOYEE_CODE], [DEPARTMENT_CODE], [DEPARTMENT_NAME], [DESIGNATION], [EMPLOYEE_NAME], [EMPLOYEE_GENDER], [EMPLOYEE_DOB], [EMPLOYEE_BLOOD_GROUP], [EMPLOYEE_MOB_NO], [EMPLOYEE_ADDRESS], [EMPLOYEE_PF_AC_NO],  [EMPLOYEE_BANK_AC_NO]) values ('" & TextBox6.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox1.Text & "','" & ComboBox5.Text & "',convert(date,'" & DateTimePicker1.Value & "',103),'" & ComboBox4.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "')", cn)
        cmd.ExecuteNonQuery()
        MsgBox("Saved successfully ....!", MsgBoxStyle.Information)
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class