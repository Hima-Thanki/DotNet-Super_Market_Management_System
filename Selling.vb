Imports System.Data.SqlClient
Public Class Selling
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thank\OneDrive\Documents\supermarketvb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim i = 0, gt = 0, dis = 0
    Private Sub FillCombo()
        con.Open()
        Dim sql = "select * from proData"
        Dim cmd As New SqlCommand(sql, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        adapter.Fill(tbl)
        pname.DataSource = tbl
        pname.DisplayMember = "pro_name"
        pname.ValueMember = "pro_name"
        con.Close()
    End Sub
    Dim price = 0
    Private Sub FetchPrice()
        con.Open()
        Dim sql = "select * from proData where pro_name='" & pname.SelectedValue.ToString & "'"
        Dim cmd As New SqlCommand(sql, con)
        Dim Rdr As SqlDataReader
        Dim tbl As New DataTable()
        Rdr = cmd.ExecuteReader()
        While Rdr.Read
            price = Rdr(2)
            pprice.Text = price
        End While
        con.Close()
    End Sub
    Private Sub Selling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCombo()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("Gmart", New Font("Sans-serifs", 30), Brushes.DarkGreen, 350, 60)
        e.Graphics.DrawString("-------------------  Your Bill  --------------------", New Font("Century Gothic", 18), Brushes.DarkOrchid, 200, 200)
        Dim bm As New Bitmap(Me.bill_table.Width, Me.bill_table.Height)
        bill_table.DrawToBitmap(bm, New Rectangle(0, 0, 700, 600))
        e.Graphics.DrawImage(bm, 150, 250)
        e.Graphics.DrawString("Total Amount : " + gt.ToString, New Font("Century Gothic", 24), Brushes.MidnightBlue, 250, 550)
        e.Graphics.DrawString("--------------------- Thank You For Buying In Amart ---------------------", New Font("Century Gothic", 16), Brushes.MidnightBlue, 100, 700)
    End Sub
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim log = New Login
        log.Show()
        Me.Hide()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintPreviewDialog1.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pname.Text = ""
        pprice.Text = ""
        pquntity.Text = ""
    End Sub

    Private Sub Pname_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles pname.SelectionChangeCommitted
        FetchPrice()
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If pquntity.Text = "" Then
            MessageBox.Show("Enter the Quantity")
        ElseIf price = 0 Then
            MessageBox.Show("Select the Product")
        Else
            Dim rnum As Integer = bill_table.Rows.Add()
            i += 1
            bill_table.Rows.Item(rnum).Cells("column1").Value = i
            bill_table.Rows.Item(rnum).Cells("column2").Value = pname.SelectedValue.ToString()
            bill_table.Rows.Item(rnum).Cells("column3").Value = price
            bill_table.Rows.Item(rnum).Cells("column4").Value = pquntity.Text
            bill_table.Rows.Item(rnum).Cells("column5").Value = price * Integer.Parse(pquntity.Text)
            gt += price * Integer.Parse(pquntity.Text)
            grdtot.Text = "Rs - " + gt.ToString()
        End If
    End Sub
    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Application.Exit()
    End Sub
End Class