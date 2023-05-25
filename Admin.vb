Imports System.Data.SqlClient
Public Class admin
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thank\OneDrive\Documents\supermarketvb.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub Populate()
        con.Open()
        Dim sql = "select * from adminData"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        admin_table.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into adminData values(" & admin_id.Text & ",'" & admin_name.Text & "','" & admin_pass.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        con.Close()
        Populate()
        MessageBox.Show("Admin Added Successfully")
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If admin_id.Text = "" Then
            MessageBox.Show("Select the Admin to be Deleted")
        Else
            con.Open()
            Dim query As String
            query = "delete from adminData where admin_id=" & admin_id.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Admin Deleted Successfully")
        End If
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If admin_id.Text = "" Or admin_name.Text = "" Or admin_pass.Text = "" Then
            MessageBox.Show("Missing Information")
        Else
            con.Open()
            Dim query As String
            query = "update adminData set admin_name ='" & admin_name.Text & "',admin_pass ='" & admin_pass.Text & "' where admin_id=" & admin_id.Text & ""
            Dim cmd As New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Admin Updated")
        End If
    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        admin_id.Text = ""
        admin_name.Text = ""
        admin_pass.Text = ""
    End Sub
    Private Sub Label7_Click_1(sender As Object, e As EventArgs) Handles Label7.Click
        Dim adm = New admin
        adm.Show()
        Me.Hide()
    End Sub
    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Dim cat = New Category
        cat.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim Prod = New Product
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Application.Exit()
    End Sub
End Class