Public Class Login
    Inherits System.Windows.Forms.Form

    Public mySession As LJSession ' yeah, I'm cheating

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
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
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkRemember = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "E&xit"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.Location = New System.Drawing.Point(18, 15)
        Me.lblTitle.Size = New System.Drawing.Size(201, 32)
        Me.lblTitle.Text = "PocketPoster v0.2"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 70)
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 94)
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(100, 70)
        Me.txtUsername.Size = New System.Drawing.Size(119, 21)
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(100, 94)
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(119, 21)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(100, 148)
        Me.Button1.Size = New System.Drawing.Size(119, 20)
        Me.Button1.Text = "Login"
        '
        'chkRemember
        '
        Me.chkRemember.Location = New System.Drawing.Point(100, 122)
        Me.chkRemember.Size = New System.Drawing.Size(119, 20)
        Me.chkRemember.Text = "Remember Me"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(0, 47)
        Me.Label4.Size = New System.Drawing.Size(240, 20)
        Me.Label4.Text = "Copyright 2006 by Chris Wiegand"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(100, 174)
        Me.Button2.Size = New System.Drawing.Size(119, 20)
        Me.Button2.Text = "Skip Login"
        '
        'Login
        '
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkRemember)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitle)
        Me.Menu = Me.MainMenu1
        Me.Text = "PocketPoster"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' should we remember?
        ' FIXME

        Dim ret As Specialized.NameValueCollection
        Me.Enabled = False

        ret = mySession.Login(Me.txtUsername.Text, Me.txtPassword.Text)
        If ret("Success") = "OK" Then
            ' yay!
            mySession.Offline = False
            ' if message, show first
            If Me.chkRemember.Checked Then
                Globals.SaveSetting("username", Me.txtUsername.Text)
                Globals.SaveSetting("password", Me.txtPassword.Text)
            End If
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
        Dim s As String
        s = Globals.ReadSetting("username")
        If s <> "" Then
            Me.txtUsername.Text = s
            Me.chkRemember.Checked = True
        End If

        s = Globals.ReadSetting("password")
        If s <> "" Then
            Me.txtPassword.Text = s
            Me.chkRemember.Checked = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        mySession.Offline = True
        Me.Close()
    End Sub
End Class
