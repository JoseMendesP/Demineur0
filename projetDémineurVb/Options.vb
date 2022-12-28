Public Class Options
    Dim nouvelleTailleGrille As Integer = 7
    Dim nbrMines As Integer = 10
    Dim theme As String = "classic"
    Dim pause As Boolean = False
    Dim temps As Integer = 60
    Dim chrono As Boolean = True
    Private Sub setNouvelleTailleGrille()
        nouvelleTailleGrille = 7
        If RadioButton1.Checked Then
            nouvelleTailleGrille = 3
        End If
        If RadioButton2.Checked Then
            nouvelleTailleGrille = 4
        End If
        If RadioButton3.Checked Then
            nouvelleTailleGrille = 5
        End If
        If RadioButton4.Checked Then
            nouvelleTailleGrille = 6
        End If
        If RadioButton5.Checked Then
            nouvelleTailleGrille = 7
        End If
        If RadioButton5.Checked Then
            nouvelleTailleGrille = 8
        End If
        If RadioButton6.Checked Then
            nouvelleTailleGrille = 9
        End If
        If RadioButton7.Checked Then
            nouvelleTailleGrille = 10
        End If
        If RadioButton8.Checked Then
            nouvelleTailleGrille = 11
        End If
        If RadioButton9.Checked Then
            nouvelleTailleGrille = 12
        End If
        If RadioButton10.Checked Then
            nouvelleTailleGrille = 13
        End If
        If RadioButton11.Checked Then
            nouvelleTailleGrille = 14
        End If
        If RadioButton12.Checked Then
            nouvelleTailleGrille = 15
        End If
    End Sub

    Private Sub setTheme()
        If ComboBox1.Text = "dark" Or ComboBox1.Text = "classic" Or ComboBox1.Text = "blue" Or ComboBox1.Text = "pink" Then
            theme = ComboBox1.Text
        Else
            theme = "classic"
            MsgBox("Le thème choisi n'est pas valide, il a été passé à 'classic'", Title:="thème")
        End If
    End Sub
    Public Function getNbrMines() As Integer
        Return nbrMines
    End Function

    Public Function getTheme() As String
        Return theme
    End Function
    Public Function getNouvelleTailleGrille() As Integer
        Return nouvelleTailleGrille
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox2.Checked Then
            pause = True
        Else
            pause = False
        End If
        Try
            temps = Convert.ToInt32(TextBox1.Text)
        Catch
            temps = 60
            MsgBox("Il faut rentrer un entier, le chronomètre est réglé sur 60 secondes.", Title:="temps")
        End Try
        chrono = Not CheckBox1.Checked
        setTheme()
        setNbrMines()
        setNouvelleTailleGrille()
        If nbrMines > (nouvelleTailleGrille + 1) * (nouvelleTailleGrille + 1) Then
            nbrMines = 10
            MsgBox("Le nombre de mines est supérieure à la taille de la grille, il a donc été réduit à 10.", Title:="nombre de mines")
        End If
        Me.Hide()
    End Sub

    Public Function getChrono() As Boolean
        Return chrono
    End Function
    Public Function getTemps() As Integer
        Return temps
    End Function
    Public Function getPause()
        Return pause
    End Function
    Private Sub setNbrMines()
        If (TextBox2.Text <> "") Then
            Try
                nbrMines = Convert.ToInt32(TextBox2.Text)
            Catch
                nbrMines = 10
                MsgBox("Il faut rentrer un entier, le nombre de mines a été converti a 10.", Title:="nombre de mines")
            End Try
        Else
            nbrMines = 10
        End If
    End Sub

End Class