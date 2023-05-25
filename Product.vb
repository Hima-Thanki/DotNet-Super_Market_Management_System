Imports System.Data.SqlClient
Public Class Product
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thank\OneDrive\Documents\supermarketvb.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub Populate()
        con.Open()
        Dim sql = "select * from proData"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        product_table.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub FillCombo()
        con.Open()
        Dim sql = "select * from catData"
        Dim cmd As New SqlCommand(sql, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        pro_cat.DataSource = tbl
        pro_cat.DisplayMember = "cat_name"
        pro_cat.ValueMember = "cat_name"
        con.Close()
    End Sub
    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
        FillCombo()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim Cat = New Category
        Cat.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim adm = New admin
        adm.Show()
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
    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim pro = New Product
        pro.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim query As String
        query = "insert into proData values(" & pro_id.Text & ",'" & pro_name.Text & "'," & pro_pri.Text & ",'" & pro_cat.SelectedValue.ToString() & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        con.Close()
        Populate()
        MessageBox.Show("Product Added Successfully")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If pro_id.Text = "" Then
            MessageBox.Show("Select the Product to be Deleted")
        Else
            con.Open()
            Dim query As String
            query = "delete from proData where pro_id=" & pro_id.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Product Deleted Successfully")
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If pro_id.Text = "" Or pro_name.Text = "" Or pro_pri.Text = "" Then
            MessageBox.Show("Missing Information")
        Else
            con.Open()
            Dim query As String
            query = "update proData set pro_name ='" & pro_name.Text & "',pro_pri =" & pro_pri.Text & ",pro_cat = '" & pro_cat.SelectedValue.ToString & "' where pro_id=" & pro_id.Text & ""
            Dim cmd As New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            Populate()
            MessageBox.Show("Product Updated")
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        pro_id.Text = ""
        pro_name.Text = ""
        pro_pri.Text = ""
    End Sub
End Class