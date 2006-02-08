Imports System.Net

Public Class LJPost
    Public subject As String
    Public content As String
    Public securityValue As String
    Public mood As String
    Public postToJournal As String
    Public TagList As String
End Class

Public Class LJSession
    Private m_Username As String = ""
    Private m_Password As String = ""
    Private m_Offline As Boolean = False
    Private m_colJournals As New Collection

    Public ReadOnly Property PostingJournals() As Collection
        Get
            Return m_colJournals
        End Get
    End Property

    Public Property Offline() As Boolean
        Get
            Return m_Offline
        End Get
        Set(ByVal value As Boolean)
            m_Offline = value
        End Set
    End Property

    Public Function Login(ByVal username As String, ByVal password As String) As Specialized.NameValueCollection
        ' attempts to login to LJ server
        ' returns: nameValueCollection
        ' it MUST contain: Success (FAIL|OK)
        ' it MAY contain: Message (content)

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        ' Dim challenge As String
        Dim ret As New Specialized.NameValueCollection
        Try
            ' now generate MD5 and send back
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "clear") ' FIXME
            items.Add("user", username)
            items.Add("password", password)
            items.Add("clientversion", "WinCE-PocketPoster/" & MyVersion)
            ret = mhc.SendHTTPRequest("login", items)
            If ret("Success") = "OK" Then
                Me.m_Username = username
                Me.m_Password = password
                m_colJournals = New Collection
                Me.m_colJournals.Add(m_Username) ' add user's own journal

                ' save list of journals with posting ability
                Dim sTmp As String
                sTmp = ret("access_count")
                ' try to load them...
                If IsNumeric(sTmp) Then
                    Try
                        LoadGroups(ret)
                    Catch ex As Exception
                        MsgBox("Unable to load your groups/journals. Posting only to your personal journal.")
                    End Try
                End If
            End If
            Return ret
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
            Return ret
        End Try
    End Function

    Private Sub LoadGroups(ByRef items As Specialized.NameValueCollection)
        ' load the posting access groups for this user...
        Dim iMax As Long = items("access_count")
        Dim idx As Long
        Dim sTmp As String

        For idx = 1 To iMax
            sTmp = items("access_" & idx)
            m_colJournals.Add(sTmp)
        Next
    End Sub

    Public Function Post(ByVal thePost As LJPost) As Specialized.NameValueCollection
        ' attempts to post entry to LJ server
        ' returns: nameValueCollection
        ' it MUST contain: Success (FAIL|OK)
        ' it MAY contain: Message (error)

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        ' Dim challenge As String
        Dim ret As New Specialized.NameValueCollection

        Try
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "clear") ' FIXME
            items.Add("user", Me.m_Username)
            items.Add("password", Me.m_Password)
            items.Add("subject", thePost.subject)
            items.Add("event", thePost.content)
            Select Case thePost.securityValue
                Case "Public"
                    items.Add("security", "public")
                Case "Private"
                    items.Add("security", "private")
                Case "Friends Only"
                    items.Add("security", "usemask")
                    items.Add("allowmask", "1")
                Case Else
                    items.Add("security", "public")
            End Select
            If thePost.postToJournal <> "" And thePost.postToJournal <> Me.m_Username Then items.Add("usejournal", thePost.postToJournal)
            If thePost.mood.Trim <> "" Then items.Add("prop_current_mood", thePost.mood)
            If thePost.TagList.Trim <> "" Then items.Add("prop_taglist", thePost.TagList)
            items.Add("year", DatePart(DateInterval.Year, Now()))
            items.Add("mon", DatePart(DateInterval.Month, Now()))
            items.Add("day", DatePart(DateInterval.Day, Now()))
            items.Add("hour", DatePart(DateInterval.Hour, Now()))
            items.Add("min", DatePart(DateInterval.Minute, Now()))
            ret = mhc.SendHTTPRequest("postevent", items)
            Return ret
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
            Return ret
        End Try
    End Function
End Class

Public Class LJHTTPWebClient

    Private Function ConvertStringToPOSTString(ByVal value As String) As String
        Dim ret As String = ""
        Dim aChar As String
        Dim iChar As Integer
        Dim hexVal As String
        For Each aChar In value
            iChar = Asc(aChar)
            If iChar >= Asc("A") And iChar <= Asc("Z") Or _
                iChar >= Asc("a") And iChar <= Asc("z") Or _
                iChar >= Asc("0") And iChar <= Asc("9") Then 'Or _
                '"$-_.+".IndexOf(aChar) > -1 Then
                ' leave alone
                ret &= aChar
            ElseIf aChar = " " Then
                ret &= "+"
            Else
                ' convert to URL encoding...
                hexVal = Hex(iChar)
                If hexVal.Length <> 2 Then hexVal = Right("0" & hexVal, 2) ' force to be 2 characters
                ret &= "%" & hexVal
            End If
        Next
        Return ret
    End Function

    Private Function ConvertPOSTStringToString(ByVal value As String) As String
        Dim ret As String = ""
        Dim idx As Long
        Dim aChar As String
        Dim tmp As String
        For idx = 0 To value.Length - 1
            aChar = value.Substring(idx, 1)
            If aChar = "+" Then
                ret &= " "
            ElseIf aChar = "%" Then ' hex-encoded value
                tmp = value.Substring(idx + 1, 2) ' FIXME buffer overflow (not really)
                If IsNumeric(tmp) Then
                    ret &= Chr(tmp)
                    idx += 2 ' skip over them
                Else
                    ret &= "%"
                End If
            Else
                ret &= aChar
            End If
        Next
        Return ret
    End Function

    Public Function convertNameValueCollectionToPOSTString(ByVal items As Specialized.NameValueCollection) As String
        Dim key As String
        Dim post As String = ""
        For Each key In items.Keys
            If post <> "" Then post &= "&"
            post &= key & "=" & ConvertStringToPOSTString(items(key))
        Next
        Return post
    End Function

    Private Function convertPOSTStringToNameValueCollection(ByVal post As String) As Specialized.NameValueCollection
        Dim keyvalueRaw As String
        Dim ret As New Specialized.NameValueCollection
        Dim items() As String = Split(post, "&")
        Dim idx As Long
        ' post = item=blah%20blahblah&item2=blah%20blahblah&item3=blah%20blahblah

        For Each keyvalueRaw In items
            ' keyvalueraw = item=blah%20blahblah
            idx = keyvalueRaw.IndexOf("=")
            If idx > -1 Then
                ' abc=def idx=4
                ret.Add(keyvalueRaw.Substring(0, idx), keyvalueRaw.Substring(idx + 1))
            End If
        Next
        Return ret
    End Function

    Private Function convertLJResponseStringToNameValueCollection(ByVal post As String) As Specialized.NameValueCollection
        ' line oriented, every other line is the key, every other value - UGH

        post = post.Replace(vbLf, vbCr).Replace(vbCr & vbCr, vbCr)
        Dim items() As String = Split(post, vbCr)
        Dim ret As New Specialized.NameValueCollection

        Dim idx As Long
        For idx = 0 To items.Length - 1 Step 2
            If idx = items.Length - 1 Then Exit For ' sometimes we get extra lines at end...
            ret.Add(items(idx), items(idx + 1))
        Next
        Return ret
    End Function

    Public Function SendHTTPRequest(ByVal method As String, Optional ByVal items As Specialized.NameValueCollection = Nothing) As Specialized.NameValueCollection
        Dim tWeb As HttpWebRequest
        Dim tResp As HttpWebResponse = Nothing
        Dim tReader As IO.StreamReader = Nothing
        Dim post As String = ""
        Dim rawResp As String
        Dim ret As Specialized.NameValueCollection

        tWeb = HttpWebRequest.Create("http://www.livejournal.com/interface/flat")
        tWeb.UserAgent = "PocketPoster/" + MyVersion

        If items Is Nothing Then items = New Specialized.NameValueCollection
        items.Remove("mode")
        items.Add("mode", method)
        post = convertNameValueCollectionToPOSTString(items)

        tWeb.Method = "POST"
        tWeb.ContentLength = post.Length
        tWeb.AllowWriteStreamBuffering = True
        tWeb.AllowAutoRedirect = True

        Dim tWriter As New IO.StreamWriter(tWeb.GetRequestStream())
        tWriter.Write(post)
        tWriter.Close()

        Try
            tResp = tWeb.GetResponse()
            tReader = New IO.StreamReader(tResp.GetResponseStream())
            rawResp = tReader.ReadToEnd()
        Catch e As Exception
            ' safe from the warnings
            If Not tReader Is Nothing Then tReader.Close()
            If Not tResp Is Nothing Then tResp.Close()
            Throw e ' throw up to parent, we just did some cleanup
        End Try

        ' convert string (tmp) to Specialized.NameValueCollection (ret)
        If tResp.ContentType = "text/plain" Then
            ret = convertLJResponseStringToNameValueCollection(rawResp)
        Else
            ret = New Specialized.NameValueCollection
            ret.Add("raw", rawResp)
        End If

        Return ret
    End Function
End Class
