Public Class LJUser
    Inherits System.Windows.Forms.Form
    Friend WithEvents lstFriends As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLJUser As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Public Property LJUser() As String
        Get
            Dim sTmp As String = Me.txtLJUser.Text
            If sTmp.IndexOf(" ") > 0 Then
                Return sTmp.Split(" ")(0)
            Else
                Return sTmp
            End If
        End Get
        Set(ByVal value As String)
            Me.txtLJUser.Text = value
        End Set
    End Property

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
        Me.lstFriends = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLJUser = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        '
        'lstFriends
        '
        Me.lstFriends.Location = New System.Drawing.Point(4, 70)
        Me.lstFriends.Size = New System.Drawing.Size(233, 100)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Size = New System.Drawing.Size(233, 35)
        Me.Label1.Text = "Enter the LJ username or select a friend from the list below."
        '
        'txtLJUser
        '
        Me.txtLJUser.Location = New System.Drawing.Point(4, 43)
        Me.txtLJUser.Size = New System.Drawing.Size(233, 21)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(87, 176)
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.Text = "Cancel"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(165, 176)
        Me.Button2.Size = New System.Drawing.Size(72, 20)
        Me.Button2.Text = "OK"
        '
        'LJUser
        '
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtLJUser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstFriends)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Friends"

    End Sub

#End Region

    Private Sub Friends_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dr As DataRow
        For Each dr In mySession.Friends.Rows
            Me.lstFriends.Items.Add(dr("username") & " - " & dr("Fullname"))
        Next
    End Sub

    Private Sub lstFriends_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFriends.SelectedIndexChanged
        Me.txtLJUser.Text = CStr(Me.lstFriends.SelectedItem).Split(" ")(0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LJUser = ""
        Me.Close() ' cancelled
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
