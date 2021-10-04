Imports System.Data.SqlClient

Module BD
    Public Server = "LAPTOP-MQTS1TI4\SQLEXPRESS"
    Public Database = "BD_201314551"
    Public Cadena As String = "Data Source='" & Server & "'; Initial Catalog='" & Database & "'; Integrated Security=True;"
    Public Conexion As New SqlConnection
    Public estadoBD As Boolean

    Public logUser As String
    Public tipoUser, imagenUser, idUser As Integer

    Sub ConectarBD()
        If estadoBD = False Then
            Try
                Conexion.ConnectionString = Cadena
                Conexion.Open()
                estadoBD = True
                MsgBox("Base de datos conectada exitosamente")
            Catch ex As Exception
                MsgBox("No se pudo conectar a la base de datos" & vbCrLf & ex.ToString())
            End Try
        Else
            MsgBox("La base de datos ya fue conectada previamente")
        End If
    End Sub

    Sub GuardarBitacora(accion As String)
        If estadoBD = True Then
            Try
                Dim strHostName As String = Net.Dns.GetHostName()
                Dim strIPAddress As String = Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
                Dim sql = "INSERT INTO Bitacora (usuario, direccion_ip, accion) VALUES ('" & logUser & "', '" & strIPAddress & "', '" & accion & "');"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
        End If
    End Sub

    Function IniciarSesion(username As String, password As String) As Boolean
        If estadoBD = True Then
            Try
                Dim sql = "SELECT * FROM Usuario WHERE usuario='" & username & "' AND DECRYPTBYPASSPHRASE('password', contrasenia)='" & password & "';"
                Dim ds As New DataSet
                Dim Comando As New SqlDataAdapter(sql, Conexion)
                Comando.Fill(ds, "Datos")
                Dim tamaño = ds.Tables("Datos").Rows.Count
                If tamaño > 0 Then
                    idUser = ds.Tables("Datos").Rows(0).Item(0)
                    logUser = ds.Tables("Datos").Rows(0).Item(3)
                    tipoUser = ds.Tables("Datos").Rows(0).Item(4)
                    imagenUser = ds.Tables("Datos").Rows(0).Item(7)
                    Return True
                Else
                    MsgBox("No se encontro un usuario con las credenciales indicadas.")
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
            Return False
        End If
    End Function

    Friend Function Autenticar(v As Integer) As Boolean
        If v = imagenUser Then
            Return True
        Else
            Return False
        End If
    End Function

    Function registrar(nombre As String, apellido As String, user As String, pass As String, fecha As String, imagen As Object) As Boolean
        If estadoBD = True Then
            Try
                Dim sql = "INSERT INTO Usuario (nombre, apellido, usuario, tipo_usr, nacimiento, contrasenia, imagen) " & "VALUES ('" & nombre & "', '" & apellido & "', '" & user & " ', 2, '" & fecha & "', ENCRYPTBYPASSPHRASE('password', '" & pass & "'), " & imagen & ");"
                Dim Comando As New SqlCommand(sql, Conexion)
                Comando.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            MsgBox("No esta conectado a la base de datos.")
            Return False
        End If
    End Function
End Module
