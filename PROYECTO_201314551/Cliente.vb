Public Class Cliente
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Esta funcionalidad estara disponible en la siguiente fase")
        Me.Hide()
        Prestados.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Esta funcionalidad estara disponible en la siguiente fase")
        Me.Hide()
        Prestar.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Esta funcionalidad estara disponible en la siguiente fase")
        Me.Hide()
        Perfil.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
End Class