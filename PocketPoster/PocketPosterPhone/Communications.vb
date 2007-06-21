Public Class Communications
    Inherits System.Windows.Forms.Form
    Implements LJCommunicationWatcher

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.lblTitle.Text = "PocketPoster " & MyVersion
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.Menu = Me.MainMenu1
        Me.Text = "Communications"
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        '
        'InputPanel1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Size = New System.Drawing.Size(32, 34)
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.Location = New System.Drawing.Point(41, 3)
        Me.lblTitle.Size = New System.Drawing.Size(199, 34)
        Me.lblTitle.Text = "PocketPoster v0.2"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(3, 96)
        Me.lblStatus.Size = New System.Drawing.Size(234, 20)
        '
        'Communications
        '
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Text = "Communications"
    End Sub

#End Region

    Public Sub StatusUpdate(ByVal status As String) Implements LJCommunicationWatcher.StatusUpdate
        If status <> "" Then
            Me.lblStatus.Text = status
        End If
        'Me.ListBox1.Items.Add(status)
        Me.Refresh()
        Me.Focus()
    End Sub
End Class
