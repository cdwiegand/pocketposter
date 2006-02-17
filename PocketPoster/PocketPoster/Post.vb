Public Class Post
    Inherits System.Windows.Forms.Form

    Public mySession As New LJSession ' yeah, I'm cheating...
    Private m_DraftFilePath As String = "" ' if we load from a draft we put the path here

    Friend WithEvents menuMenu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLoadDraft As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveDraft As System.Windows.Forms.MenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuNewPost As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLogin As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabOptions As System.Windows.Forms.TabPage
    Friend WithEvents tabContent As System.Windows.Forms.TabPage
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPost As System.Windows.Forms.TextBox
    Friend WithEvents cmbSecurity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbJournal As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMood As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTags As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents mnuPostNow As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents tabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents cmbCommentScreening As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkNoEmailComments As System.Windows.Forms.CheckBox
    Friend WithEvents chkDontAutoformat As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblPicture As System.Windows.Forms.Label
    Friend WithEvents cmbPictureKeyword As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents tbbBold As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbItalic As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbUnderline As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbLink As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbLJUser As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbImage As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbStrike As System.Windows.Forms.ToolBarButton
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Post))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuMenu = New System.Windows.Forms.MenuItem
        Me.mnuLogin = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.mnuNewPost = New System.Windows.Forms.MenuItem
        Me.mnuLoadDraft = New System.Windows.Forms.MenuItem
        Me.mnuSaveDraft = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuPostNow = New System.Windows.Forms.MenuItem
        Me.mnuClear = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabOptions = New System.Windows.Forms.TabPage
        Me.cmbPictureKeyword = New System.Windows.Forms.ComboBox
        Me.lblPicture = New System.Windows.Forms.Label
        Me.txtTags = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbMood = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbJournal = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbSecurity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabContent = New System.Windows.Forms.TabPage
        Me.txtPost = New System.Windows.Forms.TextBox
        Me.tabAdvanced = New System.Windows.Forms.TabPage
        Me.chkBackdate = New System.Windows.Forms.CheckBox
        Me.cmbCommentScreening = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkNoEmailComments = New System.Windows.Forms.CheckBox
        Me.chkDontAutoformat = New System.Windows.Forms.CheckBox
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.tbbBold = New System.Windows.Forms.ToolBarButton
        Me.tbbItalic = New System.Windows.Forms.ToolBarButton
        Me.tbbUnderline = New System.Windows.Forms.ToolBarButton
        Me.tbbLink = New System.Windows.Forms.ToolBarButton
        Me.tbbLJUser = New System.Windows.Forms.ToolBarButton
        Me.tbbImage = New System.Windows.Forms.ToolBarButton
        Me.tbbStrike = New System.Windows.Forms.ToolBarButton
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.menuMenu)
        '
        'menuMenu
        '
        Me.menuMenu.MenuItems.Add(Me.mnuLogin)
        Me.menuMenu.MenuItems.Add(Me.MenuItem11)
        Me.menuMenu.MenuItems.Add(Me.mnuNewPost)
        Me.menuMenu.MenuItems.Add(Me.mnuLoadDraft)
        Me.menuMenu.MenuItems.Add(Me.mnuSaveDraft)
        Me.menuMenu.MenuItems.Add(Me.MenuItem5)
        Me.menuMenu.MenuItems.Add(Me.mnuPostNow)
        Me.menuMenu.MenuItems.Add(Me.mnuClear)
        Me.menuMenu.MenuItems.Add(Me.MenuItem8)
        Me.menuMenu.MenuItems.Add(Me.mnuExit)
        Me.menuMenu.Text = "Menu"
        '
        'mnuLogin
        '
        Me.mnuLogin.Text = "Login..."
        '
        'MenuItem11
        '
        Me.MenuItem11.Text = "-"
        '
        'mnuNewPost
        '
        Me.mnuNewPost.Text = "New Post"
        '
        'mnuLoadDraft
        '
        Me.mnuLoadDraft.Text = "Load Draft..."
        '
        'mnuSaveDraft
        '
        Me.mnuSaveDraft.Text = "Save Draft..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "-"
        '
        'mnuPostNow
        '
        Me.mnuPostNow.Text = "Post Now"
        '
        'mnuClear
        '
        Me.mnuClear.Text = "Clear Post"
        '
        'MenuItem8
        '
        Me.MenuItem8.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Text = "Exit"
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabOptions)
        Me.TabControl1.Controls.Add(Me.tabContent)
        Me.TabControl1.Controls.Add(Me.tabAdvanced)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(240, 265)
        '
        'tabOptions
        '
        Me.tabOptions.Controls.Add(Me.cmbPictureKeyword)
        Me.tabOptions.Controls.Add(Me.lblPicture)
        Me.tabOptions.Controls.Add(Me.txtTags)
        Me.tabOptions.Controls.Add(Me.Label5)
        Me.tabOptions.Controls.Add(Me.cmbMood)
        Me.tabOptions.Controls.Add(Me.Label4)
        Me.tabOptions.Controls.Add(Me.cmbJournal)
        Me.tabOptions.Controls.Add(Me.Label3)
        Me.tabOptions.Controls.Add(Me.cmbSecurity)
        Me.tabOptions.Controls.Add(Me.Label2)
        Me.tabOptions.Controls.Add(Me.txtSubject)
        Me.tabOptions.Controls.Add(Me.Label1)
        Me.tabOptions.Location = New System.Drawing.Point(0, 0)
        Me.tabOptions.Size = New System.Drawing.Size(240, 242)
        Me.tabOptions.Text = "Options"
        '
        'cmbPictureKeyword
        '
        Me.cmbPictureKeyword.Location = New System.Drawing.Point(57, 158)
        Me.cmbPictureKeyword.Size = New System.Drawing.Size(180, 22)
        '
        'lblPicture
        '
        Me.lblPicture.Location = New System.Drawing.Point(4, 160)
        Me.lblPicture.Size = New System.Drawing.Size(100, 20)
        Me.lblPicture.Text = "Picture:"
        '
        'txtTags
        '
        Me.txtTags.Location = New System.Drawing.Point(57, 118)
        Me.txtTags.Multiline = True
        Me.txtTags.Size = New System.Drawing.Size(180, 36)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 118)
        Me.Label5.Size = New System.Drawing.Size(53, 20)
        Me.Label5.Text = "Tags:"
        '
        'cmbMood
        '
        Me.cmbMood.Items.Add("Happy")
        Me.cmbMood.Items.Add("Funny")
        Me.cmbMood.Items.Add("Sad")
        Me.cmbMood.Items.Add("Morose")
        Me.cmbMood.Items.Add("Angry")
        Me.cmbMood.Items.Add("Flippant")
        Me.cmbMood.Items.Add("Grinning")
        Me.cmbMood.Location = New System.Drawing.Point(57, 89)
        Me.cmbMood.Size = New System.Drawing.Size(180, 22)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 91)
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.Text = "Mood:"
        '
        'cmbJournal
        '
        Me.cmbJournal.Location = New System.Drawing.Point(57, 61)
        Me.cmbJournal.Size = New System.Drawing.Size(180, 22)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 63)
        Me.Label3.Size = New System.Drawing.Size(53, 20)
        Me.Label3.Text = "Journal:"
        '
        'cmbSecurity
        '
        Me.cmbSecurity.Items.Add("Public")
        Me.cmbSecurity.Items.Add("Private")
        Me.cmbSecurity.Items.Add("Friends Only")
        Me.cmbSecurity.Location = New System.Drawing.Point(57, 33)
        Me.cmbSecurity.Size = New System.Drawing.Size(180, 22)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.Text = "Security:"
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
        'tabContent
        '
        Me.tabContent.Controls.Add(Me.txtPost)
        Me.tabContent.Location = New System.Drawing.Point(0, 0)
        Me.tabContent.Size = New System.Drawing.Size(232, 239)
        Me.tabContent.Text = "Content"
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(4, 3)
        Me.txtPost.Multiline = True
        Me.txtPost.Size = New System.Drawing.Size(233, 236)
        '
        'tabAdvanced
        '
        Me.tabAdvanced.Controls.Add(Me.chkBackdate)
        Me.tabAdvanced.Controls.Add(Me.cmbCommentScreening)
        Me.tabAdvanced.Controls.Add(Me.Label6)
        Me.tabAdvanced.Controls.Add(Me.chkNoEmailComments)
        Me.tabAdvanced.Controls.Add(Me.chkDontAutoformat)
        Me.tabAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.tabAdvanced.Size = New System.Drawing.Size(232, 239)
        Me.tabAdvanced.Text = "Advanced"
        '
        'chkBackdate
        '
        Me.chkBackdate.Location = New System.Drawing.Point(3, 108)
        Me.chkBackdate.Size = New System.Drawing.Size(234, 20)
        Me.chkBackdate.Text = "Mark entry as backdated"
        '
        'cmbCommentScreening
        '
        Me.cmbCommentScreening.Items.Add("(Use user default)")
        Me.cmbCommentScreening.Items.Add("Block None")
        Me.cmbCommentScreening.Items.Add("Block Anonymous Comments")
        Me.cmbCommentScreening.Items.Add("Block Non-Friend's Comments")
        Me.cmbCommentScreening.Items.Add("Block Everyone's Comments")
        Me.cmbCommentScreening.Location = New System.Drawing.Point(3, 80)
        Me.cmbCommentScreening.Size = New System.Drawing.Size(234, 22)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 56)
        Me.Label6.Size = New System.Drawing.Size(233, 20)
        Me.Label6.Text = "Comment screening:"
        '
        'chkNoEmailComments
        '
        Me.chkNoEmailComments.Location = New System.Drawing.Point(4, 29)
        Me.chkNoEmailComments.Size = New System.Drawing.Size(233, 20)
        Me.chkNoEmailComments.Text = "Don't email comments"
        '
        'chkDontAutoformat
        '
        Me.chkDontAutoformat.Location = New System.Drawing.Point(3, 3)
        Me.chkDontAutoformat.Size = New System.Drawing.Size(234, 20)
        Me.chkDontAutoformat.Text = "Don't autoformat to HTML"
        '
        'InputPanel1
        '
        Me.ImageList1.Images.Clear()
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource6"), System.Drawing.Image))
        '
        'ToolBar2
        '
        Me.ToolBar2.Buttons.Add(Me.ToolBarButton1)
        Me.ToolBar2.Buttons.Add(Me.tbbBold)
        Me.ToolBar2.Buttons.Add(Me.tbbItalic)
        Me.ToolBar2.Buttons.Add(Me.tbbUnderline)
        Me.ToolBar2.Buttons.Add(Me.tbbStrike)
        Me.ToolBar2.Buttons.Add(Me.tbbLink)
        Me.ToolBar2.Buttons.Add(Me.tbbLJUser)
        Me.ToolBar2.Buttons.Add(Me.tbbImage)
        Me.ToolBar2.ImageList = Me.ImageList1
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbBold
        '
        Me.tbbBold.ImageIndex = 3
        '
        'tbbItalic
        '
        Me.tbbItalic.ImageIndex = 2
        '
        'tbbUnderline
        '
        Me.tbbUnderline.ImageIndex = 1
        '
        'tbbLink
        '
        Me.tbbLink.ImageIndex = 4
        '
        'tbbLJUser
        '
        Me.tbbLJUser.ImageIndex = 0
        '
        'tbbImage
        '
        Me.tbbImage.ImageIndex = 5
        '
        'tbbStrike
        '
        Me.tbbStrike.ImageIndex = 6
        '
        'Post
        '
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.TabControl1)
        Me.Menu = Me.MainMenu1
        Me.Text = "PocketPoster"

    End Sub

#End Region

    Public Sub LoadDraft()
        If Me.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        m_DraftFilePath = Me.OpenFileDialog1.FileName

        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load(m_DraftFilePath)

        Dim xmlElem As Xml.XmlElement
        For Each xmlElem In xmlDoc.FirstChild.ChildNodes
            Select Case xmlElem.Name.ToLower
                Case "subject"
                    Me.txtSubject.Text = xmlElem.InnerText
                Case "security"
                    Me.cmbSecurity.Text = xmlElem.InnerText
                Case "journal"
                    Me.cmbJournal.Text = xmlElem.InnerText
                Case "mood"
                    Me.cmbMood.Text = xmlElem.InnerText
                Case "content"
                    Me.txtPost.Text = xmlElem.InnerText
                Case "picturekw"
                    Me.cmbPictureKeyword.Text = xmlElem.InnerText
                Case "commentscreening"
                    Me.cmbCommentScreening.Text = xmlElem.InnerText
                Case "noemailcomments"
                    Me.chkNoEmailComments.Checked = IIf(xmlElem.InnerText.Trim.ToLower = "true", True, False)
                Case "noautoformat"
                    Me.chkDontAutoformat.Checked = IIf(xmlElem.InnerText.Trim.ToLower = "true", True, False)
                Case "backdate"
                    Me.chkBackdate.Checked = IIf(xmlElem.InnerText.Trim.ToLower = "true", True, False)
            End Select
        Next
    End Sub

    Private Function SaveDraft() As Boolean
        If Me.SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return False ' FAILED
        Try
            m_DraftFilePath = Me.SaveFileDialog1.FileName

            Dim xmlDoc As New System.Xml.XmlDocument
            Dim xmlElem As System.Xml.XmlElement

            xmlElem = xmlDoc.CreateElement("draft")
            xmlDoc.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("subject")
            xmlElem.InnerText = Me.txtSubject.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("security")
            xmlElem.InnerText = Me.cmbSecurity.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("journal")
            xmlElem.InnerText = Me.cmbJournal.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("mood")
            xmlElem.InnerText = Me.cmbMood.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("content")
            xmlElem.InnerText = Me.txtPost.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("picturekw")
            xmlElem.InnerText = Me.cmbPictureKeyword.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("commentscreening")
            xmlElem.InnerText = Me.cmbCommentScreening.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("noemailcomments")
            xmlElem.InnerText = IIf(Me.chkNoEmailComments.Checked, "true", "false")
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("noautoformat")
            xmlElem.InnerText = IIf(Me.chkDontAutoformat.Checked, "true", "false")
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("backdate")
            xmlElem.InnerText = IIf(Me.chkBackdate.Checked, "true", "false")
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlDoc.Save(m_DraftFilePath)
        Catch e3 As Exception
            MsgBox(e3.Message)
            Return False ' FAILED
        End Try
        Return True
    End Function

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadDraft.Click
        LoadDraft()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveDraft.Click
        SaveDraft()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewPost.Click
        CancelEntry()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mySession.Offline Then
            If MsgBox("You are not signed in (offline). Do you want to login now?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) <> MsgBoxResult.Yes Then Exit Sub
            ShowLogin()
            If mySession.Offline Then Exit Sub ' oooookay
        End If
        PostEntry()
    End Sub

    Private Function CancelEntry() As Microsoft.VisualBasic.MsgBoxResult
        If Me.txtPost.Text <> "" Or Me.txtSubject.Text <> "" Then
            Select Case MsgBox("You appear to have started a post - do you want to save it as a draft?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
                Case MsgBoxResult.Cancel
                    Return MsgBoxResult.Cancel
                Case MsgBoxResult.Yes
                    If Me.SaveDraft() Then
                        ResetForm()
                        Return MsgBoxResult.Yes
                    Else
                        Return MsgBoxResult.Cancel
                    End If
                Case MsgBoxResult.No
                    ResetForm()
                    Return MsgBoxResult.No
            End Select
        Else
            Return MsgBoxResult.Ignore ' there was nothing, so return that...
        End If
    End Function

    Private Sub ResetForm()
        Me.TabControl1.SelectedIndex = 0

        Me.txtSubject.Text = ""
        Me.txtPost.Text = ""
        Me.cmbSecurity.Text = ""
        Me.cmbMood.Text = ""
        Me.cmbJournal.Text = ""
        Me.cmbPictureKeyword.SelectedIndex = 0

        Me.chkDontAutoformat.Checked = False
        Me.chkNoEmailComments.Checked = False
        Me.cmbCommentScreening.SelectedIndex = 0 ' use default one
        Me.chkBackdate.Checked = False
    End Sub

    Private Sub PostEntry()
        Dim ret As Specialized.NameValueCollection

        If mySession.Offline Then
            If MsgBox("You are not signed in (offline). Do you want to login now?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) <> MsgBoxResult.Yes Then Exit Sub
            ShowLogin()
            If mySession.Offline Then Exit Sub ' oooookay
        End If
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
        newPost.securityValue = Me.cmbSecurity.Text
        newPost.mood = Me.cmbMood.Text
        newPost.postToJournal = Me.cmbJournal.Text
        newPost.TagList = Me.txtTags.Text
        newPost.dontAutoformatToHTML = Me.chkDontAutoformat.Checked
        newPost.dontEmailComments = Me.chkNoEmailComments.Checked
        newPost.backDate = Me.chkBackdate.Checked
        newPost.pictureKeyword = Me.cmbPictureKeyword.Text
        Select Case Me.cmbCommentScreening.Text
            Case "Block None"
                newPost.screenComments = LJPost.CommentScreeningType.ScreenNone
            Case "Block Anonymous Comments"
                newPost.screenComments = LJPost.CommentScreeningType.ScreenAnonymous
            Case "Block Non-Friend's Comments"
                newPost.screenComments = LJPost.CommentScreeningType.ScreenNonFriends
            Case "Block Everyone's Comments"
                newPost.screenComments = LJPost.CommentScreeningType.ScreenEveryone
        End Select

        ret = mySession.Post(newPost)

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

    Private Sub Post_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        MyResize()
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogin.Click
        ShowLogin()
    End Sub

    Private Sub InputPanel1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputPanel1.EnabledChanged
        ' fire off MyResize event to adjust everything...
        MyResize()
    End Sub

    Private Sub MyResize()
        ' shift things around...
        If Me.InputPanel1.VisibleDesktop.Height > Me.Height Then
            Me.TabControl1.Height = Me.Height
        Else
            Me.TabControl1.Height = Me.InputPanel1.VisibleDesktop.Height
        End If
        If Me.InputPanel1.VisibleDesktop.Width > Me.Width Then
            Me.TabControl1.Width = Me.Width
        Else
            Me.TabControl1.Width = Me.InputPanel1.VisibleDesktop.Width
        End If

        Me.txtPost.Height = Me.tabContent.Height - (Me.txtPost.Left * 2)
        Me.txtPost.Width = Me.tabContent.Width - (Me.txtPost.Top * 2)

        Dim innerTabWidth As Long = Me.tabOptions.Width - (Me.txtSubject.Left * 1.2) ' just a hack, ugly
        Me.txtSubject.Width = innerTabWidth
        Me.cmbJournal.Width = innerTabWidth
        Me.cmbMood.Width = innerTabWidth
        Me.cmbSecurity.Width = innerTabWidth
        Me.txtTags.Width = innerTabWidth
        Me.cmbPictureKeyword.Width = innerTabWidth

        Me.chkBackdate.Width = innerTabWidth
        Me.chkDontAutoformat.Width = innerTabWidth
        Me.cmbCommentScreening.Width = innerTabWidth
        Me.chkNoEmailComments.Width = innerTabWidth
    End Sub

    Private Sub ShowLogin()
        Dim t As New Login
        Dim s As String
        t.mySession = Me.mySession
        t.ShowDialog()

        If Not mySession.Offline Then
            ' okay, if we logged in, populate list of journals...
            Me.cmbJournal.Items.Clear()
            For Each s In mySession.PostingJournals
                Me.cmbJournal.Items.Add(s)
            Next
            Me.cmbJournal.SelectedIndex = 0 ' pre-select first one (user's private journal)

            ' okay, if we logged in, populate list of userpics...
            Me.cmbPictureKeyword.Items.Clear()
            Me.cmbPictureKeyword.Items.Add("") ' for "default"
            For Each s In mySession.PictureKeywords
                Me.cmbPictureKeyword.Items.Add(s)
            Next
            Me.cmbPictureKeyword.SelectedIndex = 0 ' clear and use the default for the user
        End If
    End Sub

    Private Sub Post_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowLogin()
        Me.ResetForm()
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Dim tmp As Microsoft.VisualBasic.MsgBoxResult
        tmp = Me.CancelEntry()
        If tmp = MsgBoxResult.Cancel Then Exit Sub
        Application.Exit()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CancelEntry()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PostEntry()
    End Sub

    Private Sub MenuItem7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClear.Click
        CancelEntry()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPostNow.Click
        PostEntry()
    End Sub

    Private Sub ToolBar2_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar2.ButtonClick
        Dim sTmp As String ' stores the temporary text
        Dim sTmp2 As String ' stores the inputbox response (if any)
        Dim selStart As Long = Me.txtPost.SelectionStart
        Dim selLength As Long = Me.txtPost.SelectionLength

        If e.Button.Equals(Me.tbbBold) Then
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += "<b>"
            sTmp += Me.txtPost.SelectedText
            sTmp += "</b>"
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + 3 + 4) ' <b> </b>
        ElseIf e.Button.Equals(Me.tbbItalic) Then
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += "<i>"
            sTmp += Me.txtPost.SelectedText
            sTmp += "</i>"
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + 3 + 4) ' <i> </i>
        ElseIf e.Button.Equals(Me.tbbUnderline) Then
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += "<u>"
            sTmp += Me.txtPost.SelectedText
            sTmp += "</u>"
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + 3 + 4) ' <u> </u>
        ElseIf e.Button.Equals(Me.tbbStrike) Then
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += "<strike>"
            sTmp += Me.txtPost.SelectedText
            sTmp += "</strike>"
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + 8 + 9) ' <strike> </strike>
        ElseIf e.Button.Equals(Me.tbbLink) Then
            sTmp2 = InputBox("Please enter/paste the URL.")
            If sTmp2 = "" Then Exit Sub ' cancelled
            sTmp2 = "<a href=""" & sTmp2 & """>" ' surround it
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += sTmp2
            sTmp += Me.txtPost.SelectedText
            sTmp += "</a>"
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + sTmp2.Length + 4) ' <a href="..."> </a>
        ElseIf e.Button.Equals(Me.tbbLJUser) Then
            sTmp2 = InputBox("Please enter/paste the LJ username.")
            If sTmp2 = "" Then Exit Sub ' cancelled
            sTmp2 = "<lj user=""" & sTmp2 & """>"
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += sTmp2
            sTmp += Me.txtPost.SelectedText
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + sTmp2.Length) ' <lj user="...">
        ElseIf e.Button.Equals(Me.tbbImage) Then
            sTmp2 = InputBox("Please enter/paste the image URL.")
            If sTmp2 = "" Then Exit Sub ' cancelled
            sTmp2 = "<img src=""" & sTmp2 & """>"
            sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            sTmp += sTmp2
            sTmp += Me.txtPost.SelectedText
            sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            Me.txtPost.Text = sTmp
            ' reselect appropriate area
            Me.txtPost.Select(selStart, selLength + sTmp2.Length) ' <img src="...">

        End If
    End Sub

End Class
