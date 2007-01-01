Public Class Prefs
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLJURL As System.Windows.Forms.TextBox
    Friend WithEvents chkForUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBrowser As System.Windows.Forms.ComboBox
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLJURL = New System.Windows.Forms.TextBox
        Me.chkForUpdates = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBrowser = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 20)
        Me.Label1.Text = "LiveJournal server:"
        '
        'txtLJURL
        '
        Me.txtLJURL.Location = New System.Drawing.Point(45, 22)
        Me.txtLJURL.Name = "txtLJURL"
        Me.txtLJURL.Size = New System.Drawing.Size(187, 21)
        Me.txtLJURL.TabIndex = 2
        '
        'chkForUpdates
        '
        Me.chkForUpdates.Location = New System.Drawing.Point(3, 50)
        Me.chkForUpdates.Name = "chkForUpdates"
        Me.chkForUpdates.Size = New System.Drawing.Size(234, 20)
        Me.chkForUpdates.TabIndex = 1
        Me.chkForUpdates.Text = "Check for updates every login/post"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.Text = "http://"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.Text = "Web Browser:"
        '
        'cmbBrowser
        '
        Me.cmbBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbBrowser.Items.Add("Internet Explorer")
        Me.cmbBrowser.Items.Add("Minimo")
        Me.cmbBrowser.Location = New System.Drawing.Point(4, 101)
        Me.cmbBrowser.Name = "cmbBrowser"
        Me.cmbBrowser.Size = New System.Drawing.Size(228, 22)
        Me.cmbBrowser.TabIndex = 10
        '
        'Prefs
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.cmbBrowser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkForUpdates)
        Me.Controls.Add(Me.txtLJURL)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "Prefs"
        Me.Text = "Prefs"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Prefs_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Globals.SetSetting("LiveJournalServerURL", Me.txtLJURL.Text)
        Globals.SetSetting("BrowserName", Me.cmbBrowser.Text)
        Globals.SetSetting("UpdateCheckOnLogin", IIf(Me.chkForUpdates.Checked, "true", "false"))
    End Sub

    Private Sub Prefs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtLJURL.Text = Globals.GetSetting("LiveJournalServerURL")
        If Me.txtLJURL.Text = "" Then Me.txtLJURL.Text = "http://www.livejournal.com"
        Me.cmbBrowser.Text = Globals.GetSetting("BrowserName")
        If Me.cmbBrowser.Text = "" Then Me.cmbBrowser.Text = "Internet Explorer"
        Me.chkForUpdates.Checked = IIf(Globals.GetSetting("UpdateCheckOnLogin") = "true", True, False)
    End Sub
End Class
