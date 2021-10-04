Public Class Registro
    Dim imagen = 0
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        imagen = 1
        Label6.Text = "Imagen escogida: Naipe de espadas"
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        imagen = 2
        Label6.Text = "Imagen escogida: Naipe de diamantes"

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        imagen = 3
        Label6.Text = "Imagen escogida: Naipe de corazones"

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        imagen = 4
        Label6.Text = "Imagen escogida: Naipe de treboles"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LimpiarCampos()
    End Sub

    Sub LimpiarCampos()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        imagen = 0
        Label6.Text = "Imagen escogida: "
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nombre, apellido, user, pass, fecha As String
        nombre = TextBox1.Text
        apellido = TextBox2.Text
        user = TextBox3.Text
        pass = TextBox4.Text
        fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        If nombre IsNot "" And apellido IsNot "" And user IsNot "" And pass IsNot "" And fecha IsNot "" And imagen > 0 Then
            Dim valor As Boolean
            valor = BD.registrar(nombre, apellido, user, pass, fecha, imagen)
            If valor = True Then
                LimpiarCampos()
                logUser = user
                MsgBox("Se registro el cliente exitosamente, redirigiendo al login")
                BD.GuardarBitacora("Se creo el cliente en el sistema.")
                logUser = ""
                Me.Hide()
                Form1.Show()
            End If
        Else
            MsgBox("No se han seleccionado todos los campos")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
        LimpiarCampos()
    End Sub

    Private Sub SalirDeLaAplicaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirDeLaAplicaciónToolStripMenuItem.Click
        If MsgBox("¿Desea salir del programa?", MsgBoxStyle.Information + vbYesNo) = vbYes Then
            Application.Exit()
        Else
            MsgBox("Se cancelo la operacion")
        End If
    End Sub
    Private Sub ConectarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConectarBaseDeDatosToolStripMenuItem.Click
        BD.ConectarBD()
    End Sub

End Class