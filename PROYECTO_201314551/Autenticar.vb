Public Class Autenticar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("¿Desea salir del programa?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
            Me.Close()
        Else
            MsgBox("Se cancelo la operacion")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("¿Desea cerrar su sesión actual?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
            Me.Hide()
            Form1.Show()
            idUser = 0
            tipoUser = 0
            imagenUser = 0
            logUser = ""
        Else
            MsgBox("Se cancelo la operacion")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim valor As Boolean
        valor = BD.Autenticar(1)
        If valor = True Then
            MsgBox("Acceso garantizado, bienvenido usuario.")
            BD.GuardarBitacora("El usuario inicio sesion.")
            Me.Hide()
            Cliente.Show()
        Else
            MsgBox("Imagen incorrecta")
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim valor As Boolean
        valor = BD.Autenticar(2)
        If valor = True Then
            MsgBox("Acceso garantizado, bienvenido usuario.")
            BD.GuardarBitacora("El usuario inicio sesion.")
            Me.Hide()
            Cliente.Show()
        Else
            MsgBox("Imagen incorrecta")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim valor As Boolean
        valor = BD.Autenticar(3)
        If valor = True Then
            MsgBox("Acceso garantizado, bienvenido usuario.")
            BD.GuardarBitacora("El usuario inicio sesion.")
            Me.Hide()
            Cliente.Show()
        Else
            MsgBox("Imagen incorrecta")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim valor As Boolean
        valor = BD.Autenticar(4)
        If valor = True Then
            MsgBox("Acceso garantizado, bienvenido usuario.")
            BD.GuardarBitacora("El usuario inicio sesion.")
            Me.Hide()
            Cliente.Show()
        Else
            MsgBox("Imagen incorrecta")
        End If
    End Sub
End Class