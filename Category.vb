Imports System.Data.SqlClient
Public Class Category
    ReadOnly con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thank\OneDrive\Documents\supermarketvb.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub Populate()
        con.Open()
        Dim sql = "select * from catData"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        category_table.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub
    Private Sub Label7_Click_1(sender As Object, e As EventArgs) Handles Label7.Click
        Dim adm = New admin
        adm.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into catData values(" & cat_id.Text & ",'" & cat_name.Text & "','" & cat_des.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        con.Close()
        Populate()
        MessageBox.Show("Category Added Successfully")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If cat_id.Text = "" Then
            MessageBox.Show("Select the Category to be Deleted")
        Else
            con.Open()
            Dim query As String
            query = "delete from catData where cat_id=" & cat_id.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Category Deleted Successfully")
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If cat_id.Text = "" Or cat_name.Text = "" Or cat_des.Text = "" Then
            MessageBox.Show("Missing Information")
        Else
            con.Open()
            Dim query As String
            query = "update catData set cat_name ='" & cat_name.Text & "',cat_des ='" & cat_des.Text & "' where cat_id=" & cat_id.Text & ""
            Dim cmd As New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Category Updated")
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        cat_id.Text = ""
        cat_name.Text = ""
        cat_des.Text = ""
    End Sub
End Class