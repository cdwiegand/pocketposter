Public Class Post
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtPost As System.Windows.Forms.TextBox
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
        Me.txtPost = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.MainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(0, 26)
        Me.txtPost.Multiline = True
        Me.txtPost.Size = New System.Drawing.Size(173, 151)
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(53, 3)
        Me.txtSubject.Size = New System.Drawing.Size(120, 24)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "Subject:"
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Post"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Quit"
        '
        'Post
        '
        Me.ClientSize = New System.Drawing.Size(176, 180)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtPost)
        Me.Menu = Me.MainMenu1
        Me.Text = "Post"

    End Sub

#End Region

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        QuitApp()
    End Sub

    Private Sub QuitApp()
        Application.Exit()
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        PostEntry()
    End Sub

    Public Sub ReloadProfile()
    End Sub

    Private Sub ResetForm()
        Me.ReloadProfile()
        Try
            Me.txtSubject.Text = ""
            Me.txtPost.Text = ""
        Finally
        End Try
    End Sub

    Private Sub PostEntry()
        Dim ret As Specialized.NameValueCollection

        ' If mySession.Offline Then
        ' If MsgBox("You are not signed in (offline). Do you want to login now?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) <> MsgBoxResult.Yes Then Exit Sub
        ' ShowLogin()
        ' If mySession.Offline Then Exit Sub ' oooookay
        ' End If
        If Me.txtSubject.Text.Trim = "" Then
            If MsgBox("The subject is missing - are you sure that you want to post?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) <> MsgBoxResult.Yes Then Exit Sub
        End If
        If Me.txtPost.Text.Trim = "" Then
            MsgBox("You must enter something to post first!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor
        Me.Enabled = False

        Dim newPost As New LJPost
        newPost.subject = Me.txtSubject.Text
        newPost.content = Me.txtPost.Text
        newPost.backDate = False
        newPost.backDateDate = Nothing
        newPost.screenComments = LJPost.CommentScreeningType.ScreenNone

        Dim frmComm As New Communications
        frmComm.Show()

        ret = mySession.Post(newPost, frmComm)
        frmComm.Hide()
        frmComm = Nothing ' get rid of it!

        If ret("Success") = "OK" Then
            ' yay!
            Cursor.Current = Cursors.Default
            MsgBox("Posted successfully.")
            Me.ResetForm()
            Me.Enabled = True
        Else
            Cursor.Current = Cursors.Default
            MsgBox(ret("errmsg"))
            Me.Enabled = True
        End If
    End Sub

    Private Sub ShowLogin()
        Dim t As New Login
        Me.Show() ' to prevent the screen refreshing back to the Today screen.
        t.ShowDialog()
        Me.ReloadProfile()
    End Sub

    Private Sub Post_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' timAutoSave is still disabled
        mySession.LoadFromConfigFile()
        ' we don't know who they are? need to first login..
        If mySession.Username = "" Then ShowLogin()
        Me.ResetForm()
    End Sub
End Class
