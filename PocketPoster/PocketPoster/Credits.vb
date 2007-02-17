Public Class Credits
    Inherits System.Windows.Forms.Form
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
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
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(240, 268)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Written by Christopher Donald Wiegand of Aurora, CO, USA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon from wylddevil." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bug reports: canisrufus, wylddevil." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Credits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.TextBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Credits"
        Me.Text = "Credits"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Credits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' prepend the revision string
        Me.TextBox1.Text = "PocketPoster revision " & Globals.MyRevision & vbCrLf & vbCrLf & Me.TextBox1.Text
        Me.lblRevision.Text = "Build " & System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build
    End Sub
End Class
