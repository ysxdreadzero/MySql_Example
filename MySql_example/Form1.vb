Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As New MySqlConnection
    Public Sub connect()
        Dim DatabaseName As String = "zerodsig_clogger"
        Dim server As String = "164.160.91.27"
        Dim userName As String = "zerodsig_clogger"
        Dim password As String = "zerodsig_"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; SSL Mode=None", server, userName, password, DatabaseName)
        Try
            conn.Open()

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
        Catch ex As Exception
        End Try
        Dim cmd As New MySqlCommand(String.Format("INSERT INTO `users` (`email`, `password`) VALUES ('test@test.co.za', 'test')"))
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
End Class
