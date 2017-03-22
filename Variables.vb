Imports MySql.Data.MySqlClient
Module Variables
    Public MySQLConn As New MySqlConnection
    Public connstring As String = "server=localhost;username=root;password=root;database=sampaguita"
    Public comm As New MySqlCommand

    Public reader As MySqlDataReader
    Public Function DBInsert(ByVal fname As String, ByVal minitial As String, ByVal lname As String, ByVal coyesec As String)
        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If

        MySQLConn.ConnectionString = connstring
        Try
            MySQLConn.Open()
            comm = New MySqlCommand("INSERT INTO studentlist VALUES(@fname, @minitial, @lname, @coyesec)", MySQLConn)
            comm.Parameters.AddWithValue("@fname", fname)
            comm.Parameters.AddWithValue("@minitial", minitial)
            comm.Parameters.AddWithValue("@lname", lname)
            comm.Parameters.AddWithValue("@coyesec", coyesec)


            comm.ExecuteNonQuery()
            MySQLConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MySQLConn.Dispose()
        End Try
        Return "Inserted"
    End Function
    Public Sub testDBConnect()
        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If
        MySQLConn.ConnectionString = connstring
        Try
            MySQLConn.Open()
            MySQLConn.Close()
        Catch ex As Exception
            MsgBox("Unable to connect to the database. Aborting")
        Finally
            MySQLConn.Dispose()
        End Try
    End Sub
End Module
