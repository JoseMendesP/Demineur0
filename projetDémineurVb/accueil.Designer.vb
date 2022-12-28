<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class accueil
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.nomJoueur = New System.Windows.Forms.ComboBox()
        Me.quitter = New System.Windows.Forms.Button()
        Me.jouer = New System.Windows.Forms.Button()
        Me.score = New System.Windows.Forms.Button()
        Me.nom = New System.Windows.Forms.Label()
        Me.Parametres = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'nomJoueur
        '
        Me.nomJoueur.FormattingEnabled = True
        Me.nomJoueur.Location = New System.Drawing.Point(447, 165)
        Me.nomJoueur.Margin = New System.Windows.Forms.Padding(4)
        Me.nomJoueur.Name = "nomJoueur"
        Me.nomJoueur.Size = New System.Drawing.Size(160, 24)
        Me.nomJoueur.TabIndex = 0
        '
        'quitter
        '
        Me.quitter.Location = New System.Drawing.Point(954, 480)
        Me.quitter.Margin = New System.Windows.Forms.Padding(4)
        Me.quitter.Name = "quitter"
        Me.quitter.Size = New System.Drawing.Size(100, 28)
        Me.quitter.TabIndex = 1
        Me.quitter.Text = "quitter"
        Me.quitter.UseVisualStyleBackColor = True
        '
        'jouer
        '
        Me.jouer.Location = New System.Drawing.Point(397, 258)
        Me.jouer.Margin = New System.Windows.Forms.Padding(4)
        Me.jouer.Name = "jouer"
        Me.jouer.Size = New System.Drawing.Size(253, 89)
        Me.jouer.TabIndex = 2
        Me.jouer.Text = "jouer"
        Me.jouer.UseVisualStyleBackColor = True
        '
        'score
        '
        Me.score.Location = New System.Drawing.Point(744, 289)
        Me.score.Margin = New System.Windows.Forms.Padding(4)
        Me.score.Name = "score"
        Me.score.Size = New System.Drawing.Size(100, 28)
        Me.score.TabIndex = 3
        Me.score.Text = "score"
        Me.score.UseVisualStyleBackColor = True
        '
        'nom
        '
        Me.nom.AutoSize = True
        Me.nom.Location = New System.Drawing.Point(508, 145)
        Me.nom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(35, 17)
        Me.nom.TabIndex = 4
        Me.nom.Text = "nom"
        '
        'Parametres
        '
        Me.Parametres.Location = New System.Drawing.Point(165, 289)
        Me.Parametres.Name = "Parametres"
        Me.Parametres.Size = New System.Drawing.Size(100, 28)
        Me.Parametres.TabIndex = 5
        Me.Parametres.Text = "Options"
        Me.Parametres.UseVisualStyleBackColor = True
        '
        'accueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.Parametres)
        Me.Controls.Add(Me.nom)
        Me.Controls.Add(Me.score)
        Me.Controls.Add(Me.jouer)
        Me.Controls.Add(Me.quitter)
        Me.Controls.Add(Me.nomJoueur)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "accueil"
        Me.Text = "accueil"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nomJoueur As ComboBox
    Friend WithEvents quitter As Button
    Friend WithEvents jouer As Button
    Friend WithEvents score As Button
    Friend WithEvents nom As Label
    Friend WithEvents Parametres As Button
End Class
