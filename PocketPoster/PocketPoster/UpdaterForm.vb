Public Class UpdaterForm
    Inherits System.Windows.Forms.Form
    Implements LJCommunicationWatcher

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

    Private WithEvents m_myUpdater As New Updater

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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(33, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.Text = "Downloading update..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(33, 71)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(164, 20)
        '
        'UpdaterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.MainMenu1
        Me.Name = "UpdaterForm"
        Me.Text = "UpdaterForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub UpdaterForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Refresh() ' make sure that we're showing...
    End Sub

    Public Function Run() As Boolean
        Dim bDone As Boolean = False
        Dim s As TriState = m_myUpdater.CheckForUpdates(Me)
        Select Case s
            Case TriState.False
                bDone = True
            Case TriState.True
                ' download update...
                If MsgBox("PocketPoster " & m_myUpdater.UpdatedVersion & " is available. Do you want to download the update?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ' verify that we ARE showing.
                    ' we hide ourselves when we're doing the "update-during-login" check
                    Me.Show()
                    Me.Refresh()
                    m_myUpdater.GetUpdate(Me)
                Else
                    bDone = True
                End If
            Case TriState.UseDefault
                ' error, we already complained to them...
                bDone = True
        End Select

        If bDone = True Then
            Me.Visible = False
            Me.Close()
            Return False ' didn't run, ok to continue
        Else
            Return True ' we're running, not ok to continue
        End If
        ' otherwise we're running the async part!
    End Function

    Private Sub m_myUpdater_UpdateComplete() Handles m_myUpdater.UpdateComplete
        m_myUpdater.LaunchUpdate()
        Me.Visible = False
        Me.Close()
    End Sub

    Private Sub m_myUpdater_UpdateDownloading(ByVal progressPercent As Long) Handles m_myUpdater.UpdateDownloading
        Me.ProgressBar1.Value = progressPercent
    End Sub

    Public Sub StatusUpdate(ByVal status As String) Implements LJCommunicationWatcher.StatusUpdate
        Me.Label1.Text = status
        Me.Refresh()
    End Sub
End Class
