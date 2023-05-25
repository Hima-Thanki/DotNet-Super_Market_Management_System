Imports System.Data.SqlClient
Public Class Login
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thank\OneDrive\Documents\supermarketvb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If uid.Text = "" Then
            MessageBox.Show("Enter Admin ID")
        ElseIf upass.Text = "" Then
            MessageBox.Show("Enter Password")
        Else
            con.Open()
            Dim query = "select * from adminData where admin_name ='" & uid.Text & "'and admin_pass= '" & upass.Text & "'"
            cmd = New SqlCommand(query, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MessageBox.Show("Wrong Admin Name Or Password")
            Else
                Dim Prod = New admin
                Prod.Show()
                Me.Hide()
            End If
            con.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sel = New Selling
        sel.Show()
        Me.Hide()
    End Sub

End Class