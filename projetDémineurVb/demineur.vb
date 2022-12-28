Module demineur
    Dim jeu As jeu
    Dim cptDrapeau As Integer
    Public Sub setJeu(game As jeu)
        jeu = game
    End Sub

    Public Function getCptDrapeau() As Integer
        Return cptDrapeau
    End Function
    Public Class grille
        Dim taillegrille As Integer = 7
        Dim nbrMines As Integer = 10
        Dim nbrCases As Integer = (taillegrille + 1) * (taillegrille + 1)
        Dim grille(,) As bouton
        Dim nbrMinesMarquees As Integer

        Public Sub New(opt As Options)
            taillegrille = opt.getNouvelleTailleGrille()
            nbrMines = opt.getNbrMines()
            cptDrapeau = nbrMines
            nbrCases = (taillegrille + 1) * (taillegrille + 1)
            Dim coordonneesMines = New Boolean(taillegrille, taillegrille) {}
            For i = 1 To nbrMines
                Dim coordonnesX As Integer = Rnd() * taillegrille
                Dim coordonnesY As Integer = Rnd() * taillegrille
                If coordonneesMines(coordonnesX, coordonnesY) Then
                    i -= 1
                End If
                coordonneesMines(coordonnesX, coordonnesY) = True
            Next
            nbrMinesMarquees = 0
            grille = New bouton(taillegrille, taillegrille) {}
            For i = 0 To taillegrille
                For j = 0 To taillegrille
                    Dim bou As bouton = New bouton(i, j, opt)
                    grille(i, j) = bou
                    If coordonneesMines(i, j) = True Then
                        grille(i, j).setMine()
                    End If
                Next j
            Next i
        End Sub

        Public Function getNbrMinesMarquees() As Integer
            Return nbrMinesMarquees
        End Function

        Public Function getNbrMines() As Integer
            Return nbrMines
        End Function

        Public Function getNbrCases() As Integer
            Return nbrCases
        End Function
        Public Function getLength() As Integer
            Return taillegrille
        End Function

        Public Function getCase(i As Integer, j As Integer) As bouton
            Return grille(i, j)
        End Function

        Public Sub decouvreTout()
            For i = 0 To taillegrille
                For j = 0 To taillegrille
                    If Not getCase(i, j).estMarque Then
                        grille(i, j).decouvrirCase(i, j, Me)
                    Else
                        If Me.getCase(i, j).estMine Then
                            nbrMinesMarquees = nbrMinesMarquees + 1
                        End If
                    End If
                Next
            Next
        End Sub

        Public Sub decouvrirAutourCase(positionX As Integer, positionY As Integer)
            If positionX > 0 And positionY > 0 Then
                If Not getCase(positionX - 1, positionY - 1).estDecouvert And Not getCase(positionX - 1, positionY - 1).estMine() And Not getCase(positionX - 1, positionY - 1).estMarque() Then
                    getCase(positionX - 1, positionY - 1).decouvrirCase(positionX, positionY, Me)

                End If

            End If
            If positionX < taillegrille And positionY < taillegrille Then
                If Not getCase(positionX + 1, positionY + 1).estDecouvert() And Not getCase(positionX + 1, positionY + 1).estMine() And Not getCase(positionX + 1, positionY + 1).estMarque() Then
                    getCase(positionX + 1, positionY + 1).decouvrirCase(positionX, positionY, Me)

                End If
            End If
            If positionX > 0 Then
                If Not getCase(positionX - 1, positionY).estDecouvert() And Not getCase(positionX - 1, positionY).estMine() And Not getCase(positionX - 1, positionY).estMarque() Then
                    getCase(positionX - 1, positionY).decouvrirCase(positionX - 1, positionY, Me)

                End If

            End If
            If positionX < taillegrille Then
                If Not getCase(positionX + 1, positionY).estDecouvert() And Not getCase(positionX + 1, positionY).estMine() And Not getCase(positionX + 1, positionY).estMarque() Then
                    getCase(positionX + 1, positionY).decouvrirCase(positionX + 1, positionY, Me)

                End If
                If positionY < taillegrille Then
                    If Not getCase(positionX, positionY + 1).estDecouvert() And Not getCase(positionX, positionY + 1).estMine() And Not getCase(positionX, positionY + 1).estMarque() Then
                        getCase(positionX, positionY + 1).decouvrirCase(positionX, positionY + 1, Me)
                    End If
                End If
            End If
            If positionY > 0 Then
                If Not getCase(positionX, positionY - 1).estDecouvert() And Not getCase(positionX, positionY - 1).estMine() And Not getCase(positionX, positionY - 1).estMarque() Then
                    getCase(positionX, positionY - 1).decouvrirCase(positionX, positionY - 1, Me)
                End If
            End If
            If positionY > 0 And positionX < taillegrille Then
                If Not getCase(positionX + 1, positionY - 1).estDecouvert() And Not getCase(positionX + 1, positionY - 1).estMine() And Not getCase(positionX + 1, positionY - 1).estMarque() Then
                    getCase(positionX + 1, positionY - 1).decouvrirCase(positionX + 1, positionY - 1, Me)
                End If
            End If
            If positionY < taillegrille - 1 And positionX > 0 Then
                If Not getCase(positionX - 1, positionY + 1).estDecouvert() And Not getCase(positionX - 1, positionY + 1).estMine() And Not getCase(positionX - 1, positionY + 1).estMarque() Then
                    getCase(positionX - 1, positionY + 1).decouvrirCase(positionX - 1, positionY + 1, Me)
                End If

            End If


        End Sub
        Public Function detecterMines(x As Integer, y As Integer) As Integer
            Dim cpt As Integer = 0
            If x > 0 And y > 0 Then
                If (grille(x - 1, y - 1).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            If (x < taillegrille And y < taillegrille) Then
                If (grille(x + 1, y + 1).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            If (x > 0) Then
                If (grille(x - 1, y).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            If (x < taillegrille) Then
                If (grille(x + 1, y).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            If y < taillegrille Then
                If (grille(x, y + 1).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            If (y > 0) Then
                If (grille(x, y - 1).estMine()) Then
                    cpt = cpt + 1
                End If
                If (x < taillegrille) Then
                    If (grille(x + 1, y - 1).estMine()) Then
                        cpt = cpt + 1
                    End If
                End If
            End If
            If (y < taillegrille And x > 0) Then
                If (grille(x - 1, y + 1).estMine()) Then
                    cpt = cpt + 1
                End If
            End If
            Return cpt
        End Function

        Public Function getNbrCasesDecouvertes() As Integer
            Dim nbrCasesDecouvertes As Integer = 0
            For Each bouton As bouton In grille
                If bouton.estDecouvert() Then
                    nbrCasesDecouvertes = nbrCasesDecouvertes + 1
                End If
            Next
            Return nbrCasesDecouvertes
        End Function
        Public Function estGagnee() As Boolean
            If (nbrCases - getNbrCasesDecouvertes() = nbrMines) Then
                Return True
            End If
            Return False
        End Function
    End Class


    Public Class abandonner : Inherits Button
        Dim abandonner As Button
        Dim taillePolice As Integer = 8
        Dim police As String = "Arial"
        Public Sub New()
            Me.Font = New Font(police, taillePolice)
            Me.Size = New Size(100, 40)
            Me.Location = New Point(My.Computer.Screen.Bounds.Width - 150, My.Computer.Screen.Bounds.Height - 150)
            Me.Text = "abandonner"
        End Sub

        Sub on_click() Handles Me.Click
            If MsgBox("Etes vous sure de vouloir abandonner ?", vbYesNo, Title:="Quitter") = MsgBoxResult.Yes Then
                jeu.Close()
            End If
        End Sub

    End Class

    Public Class Pause : Inherits Button
        Dim pause As Button
        Dim taillePolice As Integer = 8
        Dim police As String = "Arial"
        Public Sub New()
            Me.Font = New Font(police, taillePolice)
            Me.Size = New Size(100, 40)
            Me.Location = New Point(My.Computer.Screen.Bounds.Width - 250, My.Computer.Screen.Bounds.Height - 150)
            Me.Text = "pause"
        End Sub

        Sub on_click() Handles Me.Click
            jeu.pause()
            MsgBox("Appuyer sur 'OK' pour reprendre la partie", Title:="Pause")
            If vbOK Then
                jeu.reprend()
            End If
        End Sub

    End Class

    Public Class bouton : Inherits Button
        Dim minesAutour As Integer
        Dim decouvert As Boolean
        Dim drapeau As Boolean
        Dim mine As Boolean
        Dim couleurMine As Color
        Dim couleurVide As Color
        Dim couleurMarquee As Color
        Dim tailleText As Integer = 9
        Dim tailleBouton As Integer = 50



        Public Sub New(i As Integer, j As Integer, opt As Options)
            If (opt.getTheme = "classic") Then
                couleurMine = Color.Black
                couleurVide = Color.Yellow
                couleurMarquee = Color.Blue
            End If
            If (opt.getTheme = "pink") Then
                couleurMine = Color.Red
                couleurVide = Color.Brown
                couleurMarquee = Color.Violet
            End If
            If (opt.getTheme = "blue") Then
                couleurMine = Color.Red
                couleurVide = Color.Orange
                couleurMarquee = Color.Yellow
            End If
            If (opt.getTheme = "dark") Then
                couleurMine = Color.White
                couleurVide = Color.DarkBlue
                couleurMarquee = Color.Violet
            End If
            drapeau = False
            Me.Font = New Font("Arial", tailleText)
            If jeu.getBackColor = Color.DarkGray Then
                Me.ForeColor = Color.White
            End If
            decouvert = False
            Me.Size = New Size(tailleBouton, tailleBouton)
            Me.Location = New Point(j * tailleBouton, +i * tailleBouton)
        End Sub



        Public Sub decouvrirCase(x As Integer, y As Integer, grille As grille)
            If grille.getCase(x, y).estMine() = True Then
                Me.BackColor = couleurMine
                Me.decouvert = True
            Else
                Me.BackColor = couleurVide
                Me.decouvert = True
            End If
            If Not grille.getCase(x, y).estMine() Then
                minesAutour = grille.detecterMines(x, y)
                If Not minesAutour = 0 Then
                    Me.Text = minesAutour
                Else
                    grille.decouvrirAutourCase(x, y)
                End If
            End If
        End Sub

        Public Function estMarque() As Boolean
            Return drapeau
        End Function

        Private Sub bouton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            If e.Button = MouseButtons.Left And Not decouvert And Not drapeau Then
                If mine = True Then
                    jeu.perdu()
                Else
                    Me.decouvert = True
                    jeu.actualise()
                End If
            End If
            If e.Button = MouseButtons.Right And Not decouvert Then
                If Not estMarque() Then
                    Me.BackColor = couleurMarquee
                    drapeau = True
                    cptDrapeau -= 1
                    jeu.actualiseDrapeau()
                Else
                    drapeau = False
                    Me.BackColor = jeu.getBackColor()
                    cptDrapeau += 1
                    jeu.actualiseDrapeau()
                End If


            End If
        End Sub





        Public Function estMine() As Boolean
            Return mine
        End Function

        Public Function estDecouvert() As Boolean
            Return decouvert

        End Function

        Public Function getMinesAutour() As Integer
            Return minesAutour
        End Function

        Public Sub setMine()
            mine = True
        End Sub

    End Class

    Public Class chronometre : Inherits Timer
        Dim chrono As Timer
        Dim temps As Integer
        Dim minuteur As Label
        Dim pause As Boolean

        Public Sub New(opt As Options)
            pause = False
            Me.Interval = 1000
            chrono = New Timer()
            temps = opt.getTemps()
            minuteur = New Label()
            minuteur.Location = New Point(My.Computer.Screen.Bounds.Width - 150, My.Computer.Screen.Bounds.Height - 250)
        End Sub
        Private Sub actualisation() Handles Me.Tick
            If pause = False Then
                temps = temps - 1
                minuteur.Text = temps
                If temps = 0 Then
                    Me.Dispose()
                    jeu.finDePartie()
                End If
            End If

        End Sub

        Public Sub setPause()
            If pause = False Then
                pause = True
            Else
                pause = False
            End If
        End Sub
        Public Function getMinuteur()
            Return minuteur
        End Function

        Public Function getTemps()
            Return temps
        End Function

    End Class

    Public Class drapeau : Inherits Label
        Public Sub New()
            Me.Location = New Point(My.Computer.Screen.Bounds.Width - 250, 20)
            Me.Width = 10000
            Me.Text = "nombre de drapeaux : " + Convert.ToString(cptDrapeau)
        End Sub

        Public Sub actualise()
            Me.Text = "nombre de drapeaux : " + cptDrapeau.ToString
        End Sub
    End Class

End Module
