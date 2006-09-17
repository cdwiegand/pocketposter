Public Class Login
    Inherits System.Windows.Forms.Form

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem6)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem7)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem5)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "Menu"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Login"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "Skip Login"
        '
        'MenuItem6
        '
        Me.MenuItem6.Text = "Update..."
        '
        'MenuItem7
        '
        Me.MenuItem7.Text = "Prefs"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "-"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "E&xit"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.Location = New System.Drawing.Point(41, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(199, 32)
        Me.lblTitle.Text = "PocketPoster v0.2"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(99, 55)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(119, 21)
        Me.txtUsername.TabIndex = 6
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(99, 79)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(119, 21)
        Me.txtPassword.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(142, 106)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 20)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Login"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(41, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 20)
        Me.Label4.Text = "Copyright 2006 by Chris Wiegand    "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(47, 106)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 20)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Skip Login"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 246)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 22)
        Me.StatusBar1.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(47, 132)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(171, 20)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Change Preferences"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        '
        'Login
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitle)
        Me.Menu = Me.MainMenu1
        Me.Name = "Login"
        Me.Text = "PocketPoster"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.LoginNow()
    End Sub

    Private Sub LoginNow()
        Dim ret As Specialized.NameValueCollection
        Dim frmComm As New Communications ' Form
        frmComm.Show()

        If Globals.GetSetting("UpdateCheckOnLogin") = "true" Then
            Dim tUpdater As New UpdaterForm
            frmComm.StatusUpdate("Checking for update...")
            'tUpdater.Show()
            ' hide it unless we actually download something
            ' and it shows itself in that case
            If tUpdater.Run() = True Then
                ' updater IS running, can't continue
                frmComm.Hide()
                Exit Sub
            End If
        End If
        ret = mySession.Login(Me.txtUsername.Text, Me.txtPassword.Text, frmComm)

        frmComm.Hide()
        frmComm = Nothing ' get rid of it!

        If ret("Success") = "OK" Then
            ' yay!
            mySession.Offline = False
            mySession.SaveToConfigFile() ' for future offline use
            If ret("Message") <> "" Then MsgBox(ret("Message"))
            Me.Close() ' return to our parent...
        Else
            MsgBox(ret("errmsg"))
            Me.Enabled = True
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Application.Exit()
    End Sub

    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' remember me?
        Me.txtUsername.Text = mySession.Username
        Me.txtPassword.Text = mySession.Password
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not mySession.Offline Then
            ' already logged in, leave it alone
        Else
            mySession.LoadFromConfigFile()
        End If
        Me.Close()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        If Not mySession.Offline Then
            ' already logged in, leave it alone
        Else
            mySession.LoadFromConfigFile()
        End If
        Me.Close()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        LoginNow()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Dim t As New UpdaterForm
        t.Show()
        If t.Run() = False Then MsgBox("You are up-to-date.")
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Dim t As New Prefs
        t.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim t As New Prefs
        t.ShowDialog()
    End Sub
End Class
