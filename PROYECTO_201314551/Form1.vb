Public Class Form1
    Private Sub ConectarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConectarBaseDeDatosToolStripMenuItem.Click
        BD.ConectarBD()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim user, pass As String
        Dim valido As Boolean
        user = TextBox1.Text
        pass = TextBox2.Text
        valido = BD.IniciarSesion(user, pass)
        If valido = True Then
            If tipoUser = 1 Then
                MsgBox("Acceso del usuario administrador")
                BD.GuardarBitacora("El usuario inicio sesión")
                Administrador.Show()
                Me.Hide()
            ElseIf tipoUser = 2 Then
                MsgBox("Debera de autenticarse con un siguiente paso")
                Autenticar.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Registro.Show()
    End Sub

    Private Sub SalirDeLaAplicaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirDeLaAplicaciónToolStripMenuItem.Click
        If MsgBox("¿Desea salir del programa?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
            Application.Exit()
        Else
            MsgBox("Se cancelo la operacion")
        End If
    End Sub
End Class
