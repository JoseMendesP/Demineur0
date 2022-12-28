Public Class accueil
    Dim opt As Options
    Dim jeu As jeu
    Dim optDefault As Boolean = True
    Private Function nomValide(joueur As String) As Boolean
        If nomJoueur.Text.Length() < 3 Then
            Return False
        End If
        Return True
    End Function

    Private Sub accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub jouer_Click(sender As Object, e As EventArgs) Handles jouer.Click
        If (nomValide(nomJoueur.Text)) Then
            If optDefault = False Then
                jeu = New jeu(opt)
                jeu.Show(opt)
            Else
                opt = New Options()
                jeu = New jeu(opt)
                jeu.Show(opt)
            End If

        End If
    End Sub


    Private Sub quitter_Click(sender As Object, e As EventArgs) Handles quitter.Click
        If MsgBox("Etes vous sûre de vouloir quitter le jeu ?", vbQuestion + vbYesNo + vbDefaultButton2, "Quitter ?") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub nom_Click(sender As Object, e As EventArgs) Handles nom.Click

    End Sub

    Private Sub score_Click(sender As Object, e As EventArgs) Handles score.Click
    End Sub

    Private Sub Parametres_Click(sender As Object, e As EventArgs) Handles Parametres.Click
        opt = New Options()
        optDefault = False
        opt.Show()
    End Sub
End Class