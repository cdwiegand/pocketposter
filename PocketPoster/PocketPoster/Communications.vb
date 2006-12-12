Public Class Communications
    Inherits System.Windows.Forms.Form
    Implements LJCommunicationWatcher

    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Communications))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'InputPanel1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.Location = New System.Drawing.Point(38, 3)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(199, 32)
        Me.lblTitle.Text = "PocketPoster v0.2"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(3, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(234, 20)
        '
        'Communications
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "Communications"
        Me.Text = "Communications"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub Communications_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyResize()
    End Sub

    Private Sub Communications_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        MyResize()
    End Sub

    Private Sub InputPanel1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputPanel1.EnabledChanged
        MyResize()
    End Sub

    Private Sub MyResize()
        ' shift things around...
        'If Me.InputPanel1.VisibleDesktop.Height > Me.Height Then
        '    Me.ListBox1.Height = Me.Height
        'Else
        '    Me.ListBox1.Height = Me.InputPanel1.VisibleDesktop.Height
        'End If
        'If Me.InputPanel1.VisibleDesktop.Width > Me.Width Then
        '    Me.ListBox1.Width = Me.Width
        'Else
        '    Me.ListBox1.Width = Me.InputPanel1.VisibleDesktop.Width
        'End If

    End Sub

    Public Sub StatusUpdate(ByVal status As String) Implements LJCommunicationWatcher.StatusUpdate
        If status <> "" Then
            Me.lblStatus.Text = status
        End If
        'Me.ListBox1.Items.Add(status)
        Me.Refresh()
        Me.Focus()
    End Sub
End Class
