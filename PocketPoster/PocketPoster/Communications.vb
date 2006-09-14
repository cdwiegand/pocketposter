Public Class Communications
    Inherits System.Windows.Forms.Form
    Implements LJCommunicationWatcher

    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(240, 268)
        Me.ListBox1.TabIndex = 0
        '
        'InputPanel1
        '
        '
        'Communications
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox1)
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
        If Me.InputPanel1.VisibleDesktop.Height > Me.Height Then
            Me.ListBox1.Height = Me.Height
        Else
            Me.ListBox1.Height = Me.InputPanel1.VisibleDesktop.Height
        End If
        If Me.InputPanel1.VisibleDesktop.Width > Me.Width Then
            Me.ListBox1.Width = Me.Width
        Else
            Me.ListBox1.Width = Me.InputPanel1.VisibleDesktop.Width
        End If

    End Sub

    Public Sub StatusUpdate(ByVal status As String) Implements LJCommunicationWatcher.StatusUpdate
        Me.ListBox1.Items.Add(status)
        Me.Refresh()
        Me.Focus()
    End Sub
End Class
