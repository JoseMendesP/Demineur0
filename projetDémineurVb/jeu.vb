Public Class jeu
    Private dernierCoupJoue As Integer
    Dim grille As grille
    Dim minuteur As chronometre
    Dim minute As Boolean
    Dim compteur As drapeau
    Public Sub New(opt As Options)
        InitializeComponent()
        Me.WindowState = WindowState.Maximized
        If (opt.getTheme = "blue") Then
            Me.BackColor = Color.Blue
        End If
        If (opt.getTheme = "dark") Then
            Me.BackColor = Color.DarkGray
        End If
        If (opt.getTheme = "pink") Then
            Me.BackColor = Color.Pink
        End If

        demineur.setJeu(Me)
        minute = opt.getChrono
        grille = New grille(opt)
        For i = 0 To opt.getNouvelleTailleGrille
            For j = 0 To opt.getNouvelleTailleGrille
                Me.Controls.Add(grille.getCase(i, j))
            Next
        Next
        Dim abandonner As abandonner = New abandonner()
        Me.Controls.Add(abandonner)
        If minute Then
            minuteur = New chronometre(opt)
            minuteur.Start()
            Me.Controls.Add(minuteur.getMinuteur())
        End If

        If opt.getPause = True Then
            Dim pause As Pause = New Pause()
            Me.Controls.Add(pause)
        End If
        compteur = New drapeau()
        Me.Controls.Add(compteur)
    End Sub

    Public Sub perdu()
        If minute Then
            minuteur.Stop()
        End If
        grille.decouvreTout()
        If MsgBox("Vous avez perdu !", Title:="Fin de partie") Then
            Me.Close()
        End If
    End Sub

    Public Sub actualise()
        For k = 0 To 4
            For i = 0 To grille.getLength

                For j = 0 To grille.getLength
                    If grille.getCase(i, j).estDecouvert() Then
                        grille.getCase(i, j).decouvrirCase(i, j, grille)

                    End If
                Next
            Next
        Next
        If minute Then
            dernierCoupJoue = minuteur.getTemps()
        End If
        If (grille.estGagnee) Then
            If minute Then
                minuteur.Stop()
            End If
            If MsgBox("Gagné ! en " + minuteur.getTemps().ToString + " secondes", Title:="Fin de partie !") Then
                Me.Close()
            End If
        End If
    End Sub

    Public Sub actualiseDrapeau()
        compteur.actualise()
    End Sub
    Public Sub finDePartie()
        Dim score As Integer = grille.getNbrCasesDecouvertes()
        grille.decouvreTout()
        MsgBox("Le temps est écoulé !" & Environment.NewLine() & "Case(s) découverte(s) : '" & score & "'" & Environment.NewLine() & "Mine(s) marquée(s) : " & grille.getNbrMinesMarquees() & Environment.NewLine() & "en " & 60 - dernierCoupJoue & " seconde(s).", Title:="Fin de partie !")
    End Sub

    Public Sub pause()
        minuteur.setPause()
    End Sub

    Public Sub reprend()
        minuteur.setPause()
    End Sub

    Public Function getBackColor() As Color
        Return Me.BackColor
    End Function
End Class