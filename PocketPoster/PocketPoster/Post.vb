Public Class Post
    Inherits System.Windows.Forms.Form

    Private m_DraftFilePath As String = "" ' if we load from a draft we put the path here
    Private m_AllowedGroups As New Collection

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
    Friend WithEvents tabContent As System.Windows.Forms.TabPage
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolBar2 As System.Windows.Forms.ToolBar
    Friend WithEvents tbbBold As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbItalic As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbUnderline As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbLink As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbLJUser As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbImage As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents timAutoSave As System.Windows.Forms.Timer
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents tabOptions As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbPictureKeyword As System.Windows.Forms.ComboBox
    Friend WithEvents lblPicture As System.Windows.Forms.Label
    Friend WithEvents txtMusic As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMood As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbJournal As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSecurity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateBackdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPost As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTags As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuPostNow = New System.Windows.Forms.MenuItem
        Me.mnuClear = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.mnuExit = New System.Windows.Forms.MenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabContent = New System.Windows.Forms.TabPage
        Me.txtPost = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabOptions = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtTags = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbPictureKeyword = New System.Windows.Forms.ComboBox
        Me.lblPicture = New System.Windows.Forms.Label
        Me.txtMusic = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbMood = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbJournal = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbSecurity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tabAdvanced = New System.Windows.Forms.TabPage
        Me.dateBackdate = New System.Windows.Forms.DateTimePicker
        Me.chkBackdate = New System.Windows.Forms.CheckBox
        Me.cmbCommentScreening = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkNoEmailComments = New System.Windows.Forms.CheckBox
        Me.chkDontAutoformat = New System.Windows.Forms.CheckBox
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.ToolBar2 = New System.Windows.Forms.ToolBar
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.tbbBold = New System.Windows.Forms.ToolBarButton
        Me.tbbItalic = New System.Windows.Forms.ToolBarButton
        Me.tbbUnderline = New System.Windows.Forms.ToolBarButton
        Me.tbbLink = New System.Windows.Forms.ToolBarButton
        Me.tbbLJUser = New System.Windows.Forms.ToolBarButton
        Me.tbbImage = New System.Windows.Forms.ToolBarButton
        Me.timAutoSave = New System.Windows.Forms.Timer
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.TabControl1.SuspendLayout()
        Me.tabContent.SuspendLayout()
        Me.tabOptions.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.menuMenu)
        Me.MainMenu1.MenuItems.Add(Me.mnuPostNow)
        '
        'menuMenu
        '
        Me.menuMenu.MenuItems.Add(Me.mnuLogin)
        Me.menuMenu.MenuItems.Add(Me.MenuItem11)
        Me.menuMenu.MenuItems.Add(Me.mnuNewPost)
        Me.menuMenu.MenuItems.Add(Me.mnuLoadDraft)
        Me.menuMenu.MenuItems.Add(Me.mnuSaveDraft)
        Me.menuMenu.MenuItems.Add(Me.MenuItem3)
        Me.menuMenu.MenuItems.Add(Me.MenuItem5)
        Me.menuMenu.MenuItems.Add(Me.mnuClear)
        Me.menuMenu.MenuItems.Add(Me.MenuItem2)
        Me.menuMenu.MenuItems.Add(Me.MenuItem4)
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
        'MenuItem3
        '
        Me.MenuItem3.Text = "Save As Default"
        '
        'MenuItem5
        '
        Me.MenuItem5.Text = "-"
        '
        'mnuPostNow
        '
        Me.mnuPostNow.Text = "Post"
        '
        'mnuClear
        '
        Me.mnuClear.Text = "Clear Post"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Friends Page"
        '
        'MenuItem4
        '
        Me.MenuItem4.Text = "Preferences"
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
        Me.OpenFileDialog1.Filter = "Journal saves|*.jrnl|Text files|*.txt|All files|*.*"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Journal saves|*.jrnl"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabContent)
        Me.TabControl1.Controls.Add(Me.tabOptions)
        Me.TabControl1.Controls.Add(Me.tabAdvanced)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(240, 268)
        Me.TabControl1.TabIndex = 2
        '
        'tabContent
        '
        Me.tabContent.Controls.Add(Me.txtPost)
        Me.tabContent.Controls.Add(Me.txtSubject)
        Me.tabContent.Controls.Add(Me.Label1)
        Me.tabContent.Location = New System.Drawing.Point(0, 0)
        Me.tabContent.Name = "tabContent"
        Me.tabContent.Size = New System.Drawing.Size(240, 245)
        Me.tabContent.Text = "Content"
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(4, 26)
        Me.txtPost.Multiline = True
        Me.txtPost.Name = "txtPost"
        Me.txtPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPost.Size = New System.Drawing.Size(233, 159)
        Me.txtPost.TabIndex = 19
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(57, 3)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(180, 21)
        Me.txtSubject.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.Text = "Subject:"
        '
        'tabOptions
        '
        Me.tabOptions.Controls.Add(Me.Panel2)
        Me.tabOptions.Location = New System.Drawing.Point(0, 0)
        Me.tabOptions.Name = "tabOptions"
        Me.tabOptions.Size = New System.Drawing.Size(232, 242)
        Me.tabOptions.Text = "Options"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.txtTags)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtLocation)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbPictureKeyword)
        Me.Panel2.Controls.Add(Me.lblPicture)
        Me.Panel2.Controls.Add(Me.txtMusic)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbMood)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbJournal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbSecurity)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 242)
        '
        'txtTags
        '
        Me.txtTags.Location = New System.Drawing.Point(57, 113)
        Me.txtTags.Multiline = True
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(180, 20)
        Me.txtTags.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(3, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 20)
        Me.Label8.Text = "Tags:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(57, 86)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(180, 21)
        Me.txtLocation.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.Text = "Location:"
        '
        'cmbPictureKeyword
        '
        Me.cmbPictureKeyword.Location = New System.Drawing.Point(57, 58)
        Me.cmbPictureKeyword.Name = "cmbPictureKeyword"
        Me.cmbPictureKeyword.Size = New System.Drawing.Size(180, 22)
        Me.cmbPictureKeyword.TabIndex = 14
        '
        'lblPicture
        '
        Me.lblPicture.Location = New System.Drawing.Point(4, 58)
        Me.lblPicture.Name = "lblPicture"
        Me.lblPicture.Size = New System.Drawing.Size(100, 20)
        Me.lblPicture.Text = "Picture:"
        '
        'txtMusic
        '
        Me.txtMusic.Location = New System.Drawing.Point(57, 32)
        Me.txtMusic.Multiline = True
        Me.txtMusic.Name = "txtMusic"
        Me.txtMusic.Size = New System.Drawing.Size(180, 20)
        Me.txtMusic.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 20)
        Me.Label5.Text = "Music:"
        '
        'cmbMood
        '
        Me.cmbMood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMood.Items.Add("Happy")
        Me.cmbMood.Items.Add("Funny")
        Me.cmbMood.Items.Add("Sad")
        Me.cmbMood.Items.Add("Morose")
        Me.cmbMood.Items.Add("Angry")
        Me.cmbMood.Items.Add("Flippant")
        Me.cmbMood.Items.Add("Grinning")
        Me.cmbMood.Location = New System.Drawing.Point(57, 3)
        Me.cmbMood.Name = "cmbMood"
        Me.cmbMood.Size = New System.Drawing.Size(180, 22)
        Me.cmbMood.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.Text = "Mood:"
        '
        'cmbJournal
        '
        Me.cmbJournal.Location = New System.Drawing.Point(57, 167)
        Me.cmbJournal.Name = "cmbJournal"
        Me.cmbJournal.Size = New System.Drawing.Size(180, 22)
        Me.cmbJournal.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 20)
        Me.Label3.Text = "Journal:"
        '
        'cmbSecurity
        '
        Me.cmbSecurity.Items.Add("Public")
        Me.cmbSecurity.Items.Add("Private")
        Me.cmbSecurity.Items.Add("Friends Only")
        Me.cmbSecurity.Items.Add("Friend Groups...")
        Me.cmbSecurity.Location = New System.Drawing.Point(57, 139)
        Me.cmbSecurity.Name = "cmbSecurity"
        Me.cmbSecurity.Size = New System.Drawing.Size(180, 22)
        Me.cmbSecurity.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.Text = "Security:"
        '
        'tabAdvanced
        '
        Me.tabAdvanced.Controls.Add(Me.dateBackdate)
        Me.tabAdvanced.Controls.Add(Me.chkBackdate)
        Me.tabAdvanced.Controls.Add(Me.cmbCommentScreening)
        Me.tabAdvanced.Controls.Add(Me.Label6)
        Me.tabAdvanced.Controls.Add(Me.chkNoEmailComments)
        Me.tabAdvanced.Controls.Add(Me.chkDontAutoformat)
        Me.tabAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.tabAdvanced.Name = "tabAdvanced"
        Me.tabAdvanced.Size = New System.Drawing.Size(232, 242)
        Me.tabAdvanced.Text = "Advanced"
        '
        'dateBackdate
        '
        Me.dateBackdate.CustomFormat = "d MMM, yyyy h:mm tt"
        Me.dateBackdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateBackdate.Location = New System.Drawing.Point(26, 130)
        Me.dateBackdate.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.dateBackdate.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dateBackdate.Name = "dateBackdate"
        Me.dateBackdate.Size = New System.Drawing.Size(211, 22)
        Me.dateBackdate.TabIndex = 5
        Me.dateBackdate.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'chkBackdate
        '
        Me.chkBackdate.Location = New System.Drawing.Point(3, 103)
        Me.chkBackdate.Name = "chkBackdate"
        Me.chkBackdate.Size = New System.Drawing.Size(234, 20)
        Me.chkBackdate.TabIndex = 0
        Me.chkBackdate.Text = "Mark entry as backdated"
        '
        'cmbCommentScreening
        '
        Me.cmbCommentScreening.Items.Add("(Use user default)")
        Me.cmbCommentScreening.Items.Add("Block None")
        Me.cmbCommentScreening.Items.Add("Block Anonymous Comments")
        Me.cmbCommentScreening.Items.Add("Block Non-Friend's Comments")
        Me.cmbCommentScreening.Items.Add("Block Everyone's Comments")
        Me.cmbCommentScreening.Location = New System.Drawing.Point(7, 75)
        Me.cmbCommentScreening.Name = "cmbCommentScreening"
        Me.cmbCommentScreening.Size = New System.Drawing.Size(230, 22)
        Me.cmbCommentScreening.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(230, 20)
        Me.Label6.Text = "Comment screening:"
        '
        'chkNoEmailComments
        '
        Me.chkNoEmailComments.Location = New System.Drawing.Point(3, 29)
        Me.chkNoEmailComments.Name = "chkNoEmailComments"
        Me.chkNoEmailComments.Size = New System.Drawing.Size(233, 20)
        Me.chkNoEmailComments.TabIndex = 3
        Me.chkNoEmailComments.Text = "Don't email comments"
        '
        'chkDontAutoformat
        '
        Me.chkDontAutoformat.Location = New System.Drawing.Point(3, 3)
        Me.chkDontAutoformat.Name = "chkDontAutoformat"
        Me.chkDontAutoformat.Size = New System.Drawing.Size(234, 20)
        Me.chkDontAutoformat.TabIndex = 4
        Me.chkDontAutoformat.Text = "Don't autoformat to HTML"
        Me.ImageList1.Images.Clear()
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource6"), System.Drawing.Icon))
        '
        'InputPanel1
        '
        '
        'ToolBar2
        '
        Me.ToolBar2.Buttons.Add(Me.ToolBarButton1)
        Me.ToolBar2.Buttons.Add(Me.tbbBold)
        Me.ToolBar2.Buttons.Add(Me.tbbItalic)
        Me.ToolBar2.Buttons.Add(Me.tbbUnderline)
        Me.ToolBar2.Buttons.Add(Me.tbbLink)
        Me.ToolBar2.Buttons.Add(Me.tbbLJUser)
        Me.ToolBar2.Buttons.Add(Me.tbbImage)
        Me.ToolBar2.ImageList = Me.ImageList1
        Me.ToolBar2.Name = "ToolBar2"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbBold
        '
        Me.tbbBold.ImageIndex = 0
        '
        'tbbItalic
        '
        Me.tbbItalic.ImageIndex = 1
        '
        'tbbUnderline
        '
        Me.tbbUnderline.ImageIndex = 2
        '
        'tbbLink
        '
        Me.tbbLink.ImageIndex = 3
        '
        'tbbLJUser
        '
        Me.tbbLJUser.ImageIndex = 4
        '
        'tbbImage
        '
        Me.tbbImage.ImageIndex = 5
        '
        'timAutoSave
        '
        Me.timAutoSave.Interval = 30000
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Edit"
        '
        'Post
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ToolBar2)
        Me.Controls.Add(Me.TabControl1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Post"
        Me.Text = "PocketPoster"
        Me.TabControl1.ResumeLayout(False)
        Me.tabContent.ResumeLayout(False)
        Me.tabOptions.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tabAdvanced.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub LoadDraft(ByVal requestedLoadType As SaveType)
        Select Case requestedLoadType
            Case SaveType.autoSave
                m_DraftFilePath = IO.Path.Combine(Globals.GetAppPath(), "autosave.jrnl")
            Case SaveType.defaultSave
                m_DraftFilePath = IO.Path.Combine(Globals.GetAppPath(), "default.jrnl")
            Case SaveType.userSave
                If Me.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
                m_DraftFilePath = Me.OpenFileDialog1.FileName
        End Select

        Dim xmlDoc As New Xml.XmlDocument
        Try
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
                    Case "music"
                        Me.txtMusic.Text = xmlElem.InnerText
                    Case "content"
                        Me.txtPost.Text = xmlElem.InnerText
                    Case "currentLocation"
                        Me.txtLocation.Text = xmlElem.InnerText
                    Case "picturekw"
                        Me.cmbPictureKeyword.Text = xmlElem.InnerText
                    Case "commentscreening"
                        Me.cmbCommentScreening.Text = xmlElem.InnerText
                    Case "noemailcomments"
                        Me.chkNoEmailComments.Checked = IIf(xmlElem.InnerText.Trim.ToLower = "true", True, False)
                    Case "noautoformat"
                        Me.chkDontAutoformat.Checked = IIf(xmlElem.InnerText.Trim.ToLower = "true", True, False)
                    Case "backdate"
                        If xmlElem.InnerText = "true" Then
                            ' backdated from v98 or earlier... check the box but use 1/1/1980 for date
                            Me.chkBackdate.Checked = True
                            Me.dateBackdate.Value = #1/1/1980#
                        ElseIf xmlElem.InnerText = "false" Then
                            ' not backdated from v98 or earlier, ignore
                        Else
                            Me.chkBackdate.Checked = True
                            Me.dateBackdate.Value = xmlElem.InnerText
                        End If
                End Select
            Next
        Catch e3 As Exception
            If requestedLoadType = SaveType.userSave Then MsgBox(e3.Message)
        End Try
    End Sub

    Public Enum SaveType
        autoSave = 1
        defaultSave = 2
        userSave = 3
    End Enum

    Private Function SaveDraft(ByVal requestedSaveType As SaveType) As Boolean
        Select Case requestedSaveType
            Case SaveType.autoSave
                m_DraftFilePath = IO.Path.Combine(Globals.GetAppPath(), "autosave.jrnl")
            Case SaveType.defaultSave
                m_DraftFilePath = IO.Path.Combine(Globals.GetAppPath(), "default.jrnl")
            Case SaveType.userSave
                If Me.SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return False ' FAILED
                m_DraftFilePath = Me.SaveFileDialog1.FileName ' mark as saving draft...
        End Select
        Try

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

            xmlElem = xmlDoc.CreateElement("music")
            xmlElem.InnerText = Me.txtMusic.Text
            xmlDoc.FirstChild.AppendChild(xmlElem)

            xmlElem = xmlDoc.CreateElement("currentLocation")
            xmlElem.InnerText = Me.txtLocation.Text
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

            If Me.chkBackdate.Checked Then
                xmlElem = xmlDoc.CreateElement("backdate")
                xmlElem.InnerText = Me.dateBackdate.Value
                xmlDoc.FirstChild.AppendChild(xmlElem)
            End If

            xmlDoc.Save(m_DraftFilePath)
        Catch e3 As Exception
            If requestedSaveType = SaveType.userSave Then MsgBox(e3.Message)
            Return False ' FAILED
        End Try
        Return True
    End Function

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadDraft.Click
        LoadDraft(SaveType.userSave)
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveDraft.Click
        SaveDraft(SaveType.userSave)
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

    Private Function CancelEntry(Optional ByVal autoSave As Boolean = False) As Microsoft.VisualBasic.MsgBoxResult
        ' If Me.txtPost.Text <> "" Or Me.txtSubject.Text <> "" Then
        If autoSave Then
            If Me.SaveDraft(SaveType.autoSave) Then
                ResetForm()
                Return MsgBoxResult.Yes
            Else
                Return MsgBoxResult.Cancel
            End If
        Else
            Select Case MsgBox("You may have started a post - do you want to save it as a draft?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question)
                Case MsgBoxResult.Cancel
                    Return MsgBoxResult.Cancel
                Case MsgBoxResult.Yes
                    If Me.SaveDraft(SaveType.userSave) Then
                        ResetForm()
                        Return MsgBoxResult.Yes
                    Else
                        Return MsgBoxResult.Cancel
                    End If
                Case MsgBoxResult.No
                    ResetForm()
                    Return MsgBoxResult.No
            End Select
        End If
    End Function

    Private Sub ResetForm()
        Me.timAutoSave.Enabled = True ' enable it, we may be just initializing the form for the first actual user user

        Me.ReloadProfile()
        Me.TabControl1.SelectedIndex = 0
        Try
            Me.txtSubject.Text = ""
            Me.txtPost.Text = ""
            If Me.cmbSecurity.Items.Count > 0 Then Me.cmbSecurity.SelectedIndex = 0
            Me.cmbMood.Text = ""
            Me.txtMusic.Text = ""
            Me.txtTags.Text = ""
            Me.txtLocation.Text = ""
            If Me.cmbJournal.Items.Count > 0 Then Me.cmbJournal.SelectedIndex = 0
            If Me.cmbPictureKeyword.Items.Count > 0 Then Me.cmbPictureKeyword.SelectedIndex = 0

            Me.chkDontAutoformat.Checked = False
            Me.chkNoEmailComments.Checked = False
            If Me.cmbCommentScreening.Items.Count > 0 Then Me.cmbCommentScreening.SelectedIndex = 0 ' use default one
            Me.chkBackdate.Checked = False
            Me.dateBackdate.Value = #1/1/2000#
        Finally
            Me.LoadDraft(SaveType.defaultSave) ' load defaults from there, if possible/saved
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
        Select Case Me.cmbSecurity.Text
            Case "Private"
                newPost.securityValue = LJPost.ViewSecurityType.AllowNone
            Case "Public"
                newPost.securityValue = LJPost.ViewSecurityType.AllowAll
            Case "Friends Only"
                newPost.securityValue = LJPost.ViewSecurityType.AllowFriends
            Case "Friend Groups..."
                newPost.securityValue = LJPost.ViewSecurityType.FriendGroupsOnly
                newPost.friendGroupsAllowed = Me.m_AllowedGroups
        End Select
        newPost.mood = Me.cmbMood.Text
        newPost.postToJournal = Me.cmbJournal.Text
        newPost.TagList = Me.txtTags.Text
        newPost.music = Me.txtMusic.Text
        newPost.dontAutoformatToHTML = Me.chkDontAutoformat.Checked
        newPost.dontEmailComments = Me.chkNoEmailComments.Checked
        If Me.chkBackdate.Checked Then
            newPost.backDate = True
            newPost.backDateDate = Me.dateBackdate.Value
        Else
            newPost.backDate = False
            newPost.backDateDate = Nothing
        End If
        newPost.currentLocation = Me.txtLocation.Text
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

        Dim frmComm As New Communications
        frmComm.Show()

        If Globals.GetSetting("UpdateCheckOnLogin") = "true" Then
            Dim tUpdater As New UpdaterForm
            frmComm.StatusUpdate("Checking for update...")
            'tUpdater.Show()
            ' hide it unless we actually download something
            ' and it shows itself in that case
            If tUpdater.Run() = True Then
                SaveDraft(SaveType.autoSave)
                Exit Sub ' do NOT post, going to update first!
            End If
        End If

        ret = mySession.Post(newPost, frmComm)
        frmComm.Hide()
        frmComm = Nothing ' get rid of it!

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

        Me.txtSubject.Width = Me.tabContent.Width - Me.txtSubject.Left
        Me.txtPost.Height = Me.tabContent.Height - Me.txtPost.Top - 2
        Me.txtPost.Width = Me.tabContent.Width - Me.txtPost.Left - 2
    End Sub

    Private Sub ShowLogin()
        Dim t As New Login
        t.ShowDialog()
        Me.Show()
        Me.ReloadProfile()
    End Sub

    Public Sub ReloadProfile()
        ' reloads the settings from the user's profile, updating the possible selections
        Dim s As String

        '' okay, if we logged in, populate list of journals...
        Me.cmbJournal.Items.Clear()
        For Each s In mySession.PostingJournals
            Me.cmbJournal.Items.Add(s)
        Next
        If Me.cmbJournal.Items.Count > 0 Then Me.cmbJournal.SelectedIndex = 0 ' pre-select first one (user's private journal)

        '' okay, if we logged in, populate list of moods...
        Me.cmbMood.Items.Clear()
        Me.cmbMood.Items.Add("") ' for "default"
        For Each s In mySession.Moods
            Me.cmbMood.Items.Add(s)
        Next
        ' will always happen, but just in case that changes..
        If Me.cmbMood.Items.Count > 0 Then Me.cmbMood.SelectedIndex = 0 ' pre-select first one (user's private journal)

        ' okay, if we logged in, populate list of userpics...
        Me.cmbPictureKeyword.Items.Clear()
        Me.cmbPictureKeyword.Items.Add("") ' for "default"
        For Each s In mySession.PictureKeywords
            Me.cmbPictureKeyword.Items.Add(s)
        Next
        ' will always happen, but just in case that changes..
        If Me.cmbPictureKeyword.Items.Count > 0 Then Me.cmbPictureKeyword.SelectedIndex = 0 ' clear and use the default for the user
    End Sub

    Private Sub Post_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' timAutoSave is still disabled
        mySession.LoadFromConfigFile()
        ' we don't know who they are? need to first login..
        If mySession.Username = "" Then ShowLogin()
        ' resetForm enables timAutoSave
        Me.ResetForm()
        Me.LoadDraft(SaveType.autoSave)
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Dim tmp As Microsoft.VisualBasic.MsgBoxResult
        tmp = Me.CancelEntry(True)
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
            'ElseIf e.Button.Equals(Me.tbbStrike) Then
            '    sTmp = Me.txtPost.Text.Substring(0, Me.txtPost.SelectionStart)
            '    sTmp += "<strike>"
            '    sTmp += Me.txtPost.SelectedText
            '    sTmp += "</strike>"
            '    sTmp += Me.txtPost.Text.Substring(Me.txtPost.SelectionStart + Me.txtPost.SelectionLength)
            '    Me.txtPost.Text = sTmp
            '    ' reselect appropriate area
            '    Me.txtPost.Select(selStart, selLength + 8 + 9) ' <strike> </strike>
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
            Dim tLJUser As New LJUser
            tLJUser.ShowDialog()
            sTmp2 = tLJUser.LJUser
            ' sTmp2 = InputBox("Please enter/paste the LJ username.")
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

    Private Sub timAutoSave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timAutoSave.Tick
        ' Autosave the current draft
        SaveDraft(SaveType.autoSave) ' marks it as an autosave
    End Sub

    Private Sub cmbSecurity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cmbSecurity.Text = "Friend Groups..." Then
            'MsgBox("Sorry, this functionality isn't quite working right at this time.")
            'Exit Sub

            Dim t As New FriendsGroups
            t.AllowedGroups = m_AllowedGroups
            t.ShowDialog()
            m_AllowedGroups = t.AllowedGroups
        End If
    End Sub

    Private Sub MenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Me.SaveDraft(SaveType.defaultSave)
    End Sub

    Private Sub MenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Diagnostics.Process.Start("iexplore", Globals.GetSetting("LiveJournalServerURL") & "/~" & mySession.Username & "/friends")
    End Sub

    Private Sub MenuItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim t As New Prefs
        t.ShowDialog()
    End Sub

    Private Sub chkBackdate_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackdate.CheckStateChanged
        If Me.chkBackdate.Checked And Me.dateBackdate.Value = #1/1/1980# Then Me.dateBackdate.Value = Now
    End Sub
End Class
