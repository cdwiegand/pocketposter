Public Class Credits
    Inherits System.Windows.Forms.Form
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblRevision = New System.Windows.Forms.Label
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(0, 23)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Size = New System.Drawing.Size(240, 144)
        Me.TextBox1.Text = "Written by Christopher Donald Wiegand of Aurora, CO, USA" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "OpenNetCF framework f" & _
            "rom www.opennetcf.org/sdf/" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10)
        '
        'lblRevision
        '
        Me.lblRevision.Location = New System.Drawing.Point(0, 0)
        Me.lblRevision.Size = New System.Drawing.Size(240, 20)
        '
        'Credits
        '
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblRevision)
        Me.Controls.Add(Me.TextBox1)
        Me.Menu = Me.MainMenu1
        Me.Text = "Credits"

    End Sub

#End Region

    Private Sub Credits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
