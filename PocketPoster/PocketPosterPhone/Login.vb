Public Class Login
    Inherits System.Windows.Forms.Form
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.MainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Nina", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(-1, 23)
        Me.Label4.Size = New System.Drawing.Size(180, 20)
        Me.Label4.Text = "Copyright 2006 by Chris Wiegand    "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Nina", 10.0!, System.Drawing.FontStyle.Regular)
        Me.txtPassword.Location = New System.Drawing.Point(3, 119)
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(170, 23)
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Nina", 10.0!, System.Drawing.FontStyle.Regular)
        Me.txtUsername.Location = New System.Drawing.Point(3, 69)
        Me.txtUsername.Size = New System.Drawing.Size(170, 23)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Nina", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(-1, 96)
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Nina", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(-1, 47)
        Me.Label2.Size = New System.Drawing.Size(75, 19)
        Me.Label2.Text = "Username:"
        '
        'lblTitle
        '
        Me.lblTitle.Location = New System.Drawing.Point(-1, 0)
        Me.lblTitle.Size = New System.Drawing.Size(177, 23)
        Me.lblTitle.Text = "PocketPoster v1.0"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Login"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Cancel"
        '
        'Login
        '
        Me.ClientSize = New System.Drawing.Size(176, 180)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label4)
        Me.Menu = Me.MainMenu1
        Me.Text = "Login"

    End Sub

#End Region

    Private Sub LoginNow()
        Dim ret As Specialized.NameValueCollection
        Dim frmComm As New Communications ' Form
        frmComm.Show()

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

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtUsername.Text = mySession.Username
        Me.txtPassword.Text = mySession.Password
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        If Not mySession.Offline Then
            ' already logged in, leave it alone
        Else
            mySession.LoadFromConfigFile()
        End If
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        LoginNow()
    End Sub
End Class
