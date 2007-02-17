Public Class FriendsGroups
    Inherits System.Windows.Forms.Form
    Friend WithEvents lstBlock As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAllow As System.Windows.Forms.Button
    Friend WithEvents btnBlock As System.Windows.Forms.Button
    Friend WithEvents lstAllow As System.Windows.Forms.ListBox
    Friend WithEvents lblAllow As System.Windows.Forms.Label
    Friend WithEvents lblBlock As System.Windows.Forms.Label
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
        Me.lstBlock = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAllow = New System.Windows.Forms.Button
        Me.btnBlock = New System.Windows.Forms.Button
        Me.lstAllow = New System.Windows.Forms.ListBox
        Me.lblAllow = New System.Windows.Forms.Label
        Me.lblBlock = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lstBlock
        '
        Me.lstBlock.Location = New System.Drawing.Point(125, 55)
        Me.lstBlock.Name = "lstBlock"
        Me.lstBlock.Size = New System.Drawing.Size(112, 184)
        Me.lstBlock.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 32)
        Me.Label1.Text = "Select the friends groups that you want to allow to access to this posting."
        '
        'btnAllow
        '
        Me.btnAllow.Location = New System.Drawing.Point(125, 245)
        Me.btnAllow.Name = "btnAllow"
        Me.btnAllow.Size = New System.Drawing.Size(72, 20)
        Me.btnAllow.TabIndex = 4
        Me.btnAllow.Text = "<-- Allow"
        '
        'btnBlock
        '
        Me.btnBlock.Location = New System.Drawing.Point(47, 245)
        Me.btnBlock.Name = "btnBlock"
        Me.btnBlock.Size = New System.Drawing.Size(72, 20)
        Me.btnBlock.TabIndex = 3
        Me.btnBlock.Text = "Block -->"
        '
        'lstAllow
        '
        Me.lstAllow.Location = New System.Drawing.Point(4, 55)
        Me.lstAllow.Name = "lstAllow"
        Me.lstAllow.Size = New System.Drawing.Size(115, 184)
        Me.lstAllow.TabIndex = 2
        '
        'lblAllow
        '
        Me.lblAllow.Location = New System.Drawing.Point(4, 32)
        Me.lblAllow.Name = "lblAllow"
        Me.lblAllow.Size = New System.Drawing.Size(100, 20)
        Me.lblAllow.Text = "Allowed Groups"
        '
        'lblBlock
        '
        Me.lblBlock.Location = New System.Drawing.Point(137, 32)
        Me.lblBlock.Name = "lblBlock"
        Me.lblBlock.Size = New System.Drawing.Size(100, 20)
        Me.lblBlock.Text = "Available Groups"
        '
        'FriendsGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.lblBlock)
        Me.Controls.Add(Me.lblAllow)
        Me.Controls.Add(Me.lstAllow)
        Me.Controls.Add(Me.btnBlock)
        Me.Controls.Add(Me.btnAllow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstBlock)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FriendsGroups"
        Me.Text = "FriendsGroups"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property AllowedGroups() As Collection
        Get
            Dim ret As New Collection
            Dim s As String
            For Each s In Me.lstAllow.Items
                ret.Add(s)
            Next
            Return ret
        End Get
        Set(ByVal value As Collection)
            Dim s As String
            For Each s In value
                Try
                    Me.lstBlock.Items.Remove(s)
                Catch
                End Try
                Me.lstAllow.Items.Add(s)
            Next
        End Set
    End Property

    Private Sub FriendsGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResizeMe()
        ' load friends groups
        Dim s As String
        For Each s In mySession.FriendGroups.Keys
            Me.lstBlock.Items.Add(mySession.FriendGroups(s))
        Next
    End Sub

    Private Sub FriendsGroups_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizeMe()
    End Sub

    Private Sub ResizeMe()
        ' reposition/size controls
        ' ignore keyboard thingy as it's not useful on this screen..
        Const interSpacing As Integer = 10
        Dim tColWidth As Integer = (Me.Width / 2) - interSpacing
        Dim tListHeight As Integer = (Me.Height - (interSpacing * 3) - Me.Label1.Height - Me.lblAllow.Height - Me.btnAllow.Height)

        Me.Label1.Left = 0
        Me.Label1.Top = 0
        Me.Label1.Width = Me.Width

        Me.lblAllow.Left = 0
        Me.lblAllow.Top = Me.Label1.Top + Me.Label1.Height + 10
        Me.lblAllow.Width = tColWidth

        Me.lblBlock.Left = Me.lblAllow.Left + Me.lblAllow.Width + (interSpacing / 2)
        Me.lblBlock.Top = Me.lblAllow.Top
        Me.lblBlock.Width = tColWidth

        Me.lstAllow.Left = 0
        Me.lstAllow.Top = Me.lblAllow.Top + Me.lblAllow.Height + 10
        Me.lstAllow.Width = tColWidth
        Me.lstAllow.Height = tListHeight

        Me.lstBlock.Left = Me.lstAllow.Left + Me.lstAllow.Width + (interSpacing / 2)
        Me.lstBlock.Top = Me.lstAllow.Top
        Me.lstBlock.Width = tColWidth
        Me.lstBlock.Height = tListHeight

        Me.btnBlock.Left = 0
        Me.btnBlock.Top = Me.lstAllow.Top + Me.lstAllow.Height + 10
        Me.btnBlock.Width = tColWidth

        Me.btnAllow.Left = Me.btnBlock.Left + Me.btnBlock.Width + (interSpacing / 2)
        Me.btnAllow.Top = Me.btnBlock.Top
        Me.btnAllow.Width = tColWidth

    End Sub

    Private Sub btnAllow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllow.Click
        Try
            Me.lstAllow.Items.Add(Me.lstBlock.SelectedItem)
            Me.lstBlock.Items.RemoveAt(Me.lstBlock.SelectedIndex)
        Catch ex As Exception
            ' if there's nothing to remove, then don't throw an error..
        End Try
    End Sub

    Private Sub btnBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlock.Click
        Try
            Me.lstBlock.Items.Add(Me.lstAllow.SelectedItem)
            Me.lstAllow.Items.RemoveAt(Me.lstAllow.SelectedIndex)
        Catch ex As Exception
            ' if there's nothing to remove, then don't throw an error..
        End Try
    End Sub
End Class
