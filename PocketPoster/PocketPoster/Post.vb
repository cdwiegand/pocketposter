Public Class Post
    Inherits System.Windows.Forms.Form
    Public mySession As New LJSession ' yeah, I'm cheating...
    Private m_DraftFilePath As String = "" ' if we load from a draft we put the path here

    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPost = New System.Windows.Forms.TextBox
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem10)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem11)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem5)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem6)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem7)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem8)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem9)
        Me.MenuItem1.Text = "File"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "New Post"
        '
        'MenuItem3
        '
        Me.MenuItem3.Text = "Load Draft..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Save Draft..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "-"
        '
        'MenuItem6
        '
        Me.MenuItem6.Text = "Cancel Entry"
        '
        'MenuItem7
        '
        Me.MenuItem7.Text = "Post Entry"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Text files|*.txt"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Text files|*.txt"
        '
        'MenuItem8
        '
        Me.MenuItem8.Text = "-"
        '
        'MenuItem9
        '
        Me.MenuItem9.Text = "Exit"
        '
        'MenuItem10
        '
        Me.MenuItem10.Text = "Login..."
        '
        'MenuItem11
        '
        Me.MenuItem11.Text = "-"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(240, 265)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtSubject)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Size = New System.Drawing.Size(240, 242)
        Me.TabPage1.Text = "Options"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtPost)
        Me.TabPage2.Location = New System.Drawing.Point(0, 0)
        Me.TabPage2.Size = New System.Drawing.Size(240, 242)
        Me.TabPage2.Text = "Content"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(57, 6)
        Me.txtSubject.Size = New System.Drawing.Size(180, 21)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "Subject:"
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(4, 3)
        Me.txtPost.Multiline = True
        Me.txtPost.Size = New System.Drawing.Size(233, 236)
        '
        'Post
        '
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.TabControl1)
        Me.Menu = Me.MainMenu1
        Me.Text = "PocketPoster"

    End Sub

#End Region

    Public Sub LoadDraft()
        If Me.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim tFile As IO.StreamReader
        m_DraftFilePath = Me.OpenFileDialog1.FileName
        tFile = IO.File.OpenText(m_DraftFilePath)
        Me.txtSubject.Text = tFile.ReadLine()
        Me.txtPost.Text = tFile.ReadToEnd()
        tFile.Close()
    End Sub

    Private Sub SaveDraft()
        If Me.SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        m_DraftFilePath = Me.SaveFileDialog1.FileName
        Dim tFile As IO.StreamWriter
        tFile = IO.File.CreateText(m_DraftFilePath)
        tFile.WriteLine(Me.txtSubject.Text)
        tFile.Write(Me.txtPost.Text)
        tFile.Close()
        Me.Close()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        LoadDraft()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        SaveDraft()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        If Me.txtPost.Text <> "" Or Me.txtSubject.Text <> "" Then
            If MsgBox("You appear to have started a post - are you sure that you want to clear?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then Exit Sub
        End If
        Me.txtPost.Text = ""
        Me.txtSubject.Text = ""
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        CancelEntry()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        If mySession.Offline Then
            If MsgBox("You are not signed in (offline). Do you want to login now?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) <> MsgBoxResult.Yes Then Exit Sub
            ShowLogin()
            If mySession.Offline Then Exit Sub ' oooookay
        End If
        PostEntry()
    End Sub

    Private Sub CancelEntry()
        If Me.txtPost.Text <> "" Then
            If MsgBox("Do you want to save this as a draft?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then Me.SaveDraft()
        End If
        Me.txtSubject.Text = ""
        Me.txtPost.Text = ""
    End Sub

    Private Sub PostEntry()
        Dim ret As Specialized.NameValueCollection

        If Me.txtSubject.Text.Trim = "" Then
            If MsgBox("The subject is missing - are you sure that you want to post?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) <> MsgBoxResult.Yes Then Exit Sub
        End If
        If Me.txtPost.Text.Trim = "" Then
            MsgBox("You must enter something to post first!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Me.Enabled = False
        ret = mySession.Post(Me.txtSubject.Text, Me.txtPost.Text)
        If ret("Success") = "OK" Then
            ' yay!

            If m_DraftFilePath <> "" Then ' if we loaded from a draft
                If MsgBox("Do you want to delete the draft of this post?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Try
                        IO.File.Delete(m_DraftFilePath)
                    Catch ex As Exception
                        MsgBox("Unable to delete the draft!" + vbCrLf + vbCrLf + ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                    End Try
                End If
            End If
            Me.Close()
        Else
            MsgBox(ret("errmsg"))
            Me.Enabled = True
        End If
    End Sub

    Private Sub Post_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ' shift things around...
        Me.TabControl1.Height = Me.Height
        Me.TabControl1.Width = Me.Width

        Me.txtPost.Height = Me.TabPage2.Height - (Me.txtPost.Left * 2)
        Me.txtPost.Width = Me.TabPage2.Width - (Me.txtPost.Top * 2)

        Me.txtSubject.Width = Me.Width - (Me.txtSubject.Left * 1.2) ' just a hack, ugly
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        ShowLogin()
    End Sub

    Private Sub ShowLogin()
        Dim t As New Login
        t.mySession = Me.mySession
        t.ShowDialog()
    End Sub

    Private Sub Post_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowLogin()
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        If Me.txtSubject.Text <> "" Or Me.txtPost.Text <> "" Then
            If MsgBox("Are you sure that you want to quit without saving?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) <> MsgBoxResult.Yes Then Exit Sub
        End If
        Application.Exit()
    End Sub
End Class
