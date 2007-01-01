Public Class PostTags

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        addtag(Me.ComboBox1.Text)
    End Sub

    Private Sub AddTag(ByVal value As String)
        Dim colTags As String() = Me.txtTags.Text.Split(",")
        If Array.IndexOf(colTags, value) = -1 Then
            If Me.txtTags.Text <> "" Then Me.txtTags.Text += ","
            Me.txtTags.Text &= value
        End If
    End Sub

    Public Property Tags() As String
        Get
            Return Me.txtTags.Text
        End Get
        Set(ByVal value As String)
            Me.txtTags.Text = value
        End Set
    End Property

    Private Sub PostTags_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' okay, if we logged in, populate list of tags...
        Dim s As String
        Me.ComboBox1.Items.Clear()
        For Each s In mySession.Tags
            Me.ComboBox1.Items.Add(s)
        Next
    End Sub
End Class