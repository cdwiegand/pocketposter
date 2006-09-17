Imports System.Net

Public Class LJPost
    Public postID As Long = -1 ' indicates new post
    Public subject As String = ""
    Public content As String = ""
    Public securityValue As ViewSecurityType = ViewSecurityType.AllowAll
    Public mood As String = ""
    Public music As String = ""
    Public postToJournal As String = ""
    Public TagList As String = ""
    Public dontAutoformatToHTML As Boolean = False
    Public dontEmailComments As Boolean = False
    Public backDate As Boolean = False
    Public backDateDate As Date = Nothing
    Public screenComments As CommentScreeningType = CommentScreeningType.ScreenNone
    Public pictureKeyword As String = ""
    Public currentLocation As String = ""
    Public friendGroupsAllowed As New Collection
    ' put names into friendGroupsAllowed to allow them to see IF Security == FriendGroupsOnly

    Public Enum ViewSecurityType
        AllowNone = 0 ' Private
        AllowAll = 1 ' Public
        AllowFriends = 2 ' Friends
        FriendGroupsOnly = 3 ' Friend group specified in friendGroupsAllowed
    End Enum

    Public Enum CommentScreeningType
        ScreenNone = 0 ' no one is blocked
        ScreenAnonymous = 1 ' anonymous is blocked
        ScreenNonFriends = 2 ' non-friends are blocked
        ScreenEveryone = 3 ' everyone is blocked
    End Enum
End Class

Public Interface LJCommunicationWatcher
    Sub StatusUpdate(ByVal status As String)
End Interface

Public Class LJSession
    Private m_Username As String = ""
    Private m_Password As String = ""
    Private m_Offline As Boolean = True ' default until we log in
    Private m_colJournals As New Collection
    Private m_colPictureKeywords As New Collection
    Private m_colFriends As New Data.DataTable
    Private m_colMoods As New ArrayList
    Private m_colFriendGroups As New Specialized.NameValueCollection

    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(ByVal value As String)
            m_Username = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            m_Password = value
        End Set
    End Property

    Public ReadOnly Property Friends() As Data.DataTable
        Get
            Return m_colFriends
        End Get
    End Property

    Public ReadOnly Property FriendGroups() As Specialized.NameValueCollection
        Get
            Return m_colFriendGroups
        End Get
    End Property

    Public ReadOnly Property Moods() As ArrayList
        Get
            Return m_colMoods
        End Get
    End Property

    Public ReadOnly Property PostingJournals() As Collection
        Get
            Return m_colJournals
        End Get
    End Property

    Public ReadOnly Property PictureKeywords() As Collection
        Get
            Return m_colPictureKeywords
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

    Public Function Login(ByVal username As String, ByVal password As String, Optional ByRef commWatcher As LJCommunicationWatcher = Nothing) As Specialized.NameValueCollection
        ' attempts to login to LJ server
        ' returns: nameValueCollection
        ' it MUST contain: Success (FAIL|OK)
        ' it MAY contain: Message (content)

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        ' Dim challenge As String
        Dim ret As New Specialized.NameValueCollection
        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Generating request...")

        Try
            ' now generate MD5 and send back
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "clear") ' FIXME
            items.Add("user", username)
            items.Add("password", password)
            items.Add("clientversion", "WinCE-PocketPoster/" & MyVersion)
            items.Add("getpickws", "1") ' get picture keywords now
            items.Add("getmoods", "0") ' get moods now
            If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Sending request...")
            ret = mhc.SendHTTPRequest("login", items)
            If ret("Success") = "OK" Then
                If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response...")

                Me.m_Username = username
                Me.m_Password = password

                ' save list of journals with posting ability
                Dim sTmp As String
                sTmp = ret("access_count")
                ' try to load them...
                If IsNumeric(sTmp) Then
                    Try
                        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response (groups)...")
                        LoadGroups(ret)
                    Catch ex As Exception
                        MsgBox("Unable to load your groups/journals. Posting only to your personal journal.")
                    End Try
                End If

                ' save list of moods
                sTmp = ret("mood_count")
                ' try to load them...
                If IsNumeric(sTmp) Then
                    Try
                        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response (moods)...")
                        LoadMoods(ret)
                    Catch ex As Exception
                        ' hmm... notify user ?? think about it. --cdw
                    End Try
                End If

                ' save list of picture keywords
                sTmp = ret("pickw_count")
                ' try to load them...
                If IsNumeric(sTmp) Then
                    Try
                        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response (pictures)...")
                        LoadPictureKeywords(ret)
                    Catch ex As Exception
                        ' hmm... notify user ?? think about it. --cdw
                    End Try
                End If

                ' load friends
                If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response (friends)...")
                Me.GetFriends()

                ' load friend groups
                sTmp = ret("frgrp_maxnum")
                ' try to load them...
                ' NOTE: maxnum is the MAXIMUM, not the count!! might be missing holes!!
                If IsNumeric(sTmp) Then
                    Try
                        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response (friend groups)...")
                        LoadFriendGroups(ret)
                    Catch ex As Exception
                        ' hmm... notify user ?? think about it. --cdw
                    End Try
                End If

                ' hey, save this to the configuration, in case we're offline next time...
                If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Saving offline information...")
                SaveToConfigFile()
            End If
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
        End Try

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("")
        Return ret
    End Function

    Public Sub LoadFromConfigFile()
        ' load some offline-useful stuff from the config file...
        Dim dr As Data.DataRow
        Dim xmlBranch As Xml.XmlElement
        Dim xmlLeaf As Xml.XmlElement

        Globals.LoadConfig()

        Me.m_Offline = True ' by default

        xmlBranch = Globals.GetXMLBranch("username")
        Me.m_Username = xmlBranch.InnerText
        xmlBranch = Globals.GetXMLBranch("password")
        Me.m_Password = xmlBranch.InnerText

        ' pre v99 update: if no username, try loading from globals
        If Me.m_Username = "" Then
            Me.m_Username = Globals.GetSetting("username")
            Me.m_Password = Globals.GetSetting("password")
        End If

        ' journals we can post to...
        Me.m_colJournals = New Collection
        xmlBranch = Globals.GetXMLBranch("journals")
        For Each xmlLeaf In xmlBranch.GetElementsByTagName("journal")
            Me.m_colJournals.Add(xmlLeaf.InnerText)
        Next

        ' friends we have
        InitializeFriendsTable()
        xmlBranch = Globals.GetXMLBranch("friends")
        For Each xmlLeaf In xmlBranch.GetElementsByTagName("friend")
            dr = Me.m_colFriends.NewRow
            dr("UserName") = xmlLeaf.GetAttribute("UserName")
            dr("FullName") = xmlLeaf.InnerText
            Me.m_colFriends.Rows.Add(dr)
        Next

        ' moods we have
        Me.m_colMoods = New ArrayList
        xmlBranch = Globals.GetXMLBranch("moods")
        For Each xmlLeaf In xmlBranch.GetElementsByTagName("mood")
            Me.m_colMoods.Add(xmlLeaf.InnerText)
        Next

        ' friend groups we have
        Me.m_colFriendGroups = New Specialized.NameValueCollection
        xmlBranch = Globals.GetXMLBranch("friendgroups")
        For Each xmlLeaf In xmlBranch.GetElementsByTagName("friendgroup")
            Me.m_colFriendGroups.Add(xmlLeaf.GetAttribute("id"), xmlLeaf.InnerText)
        Next

        ' picture keywords we have
        Me.m_colPictureKeywords = New Collection
        xmlBranch = Globals.GetXMLBranch("picturekeywords")
        For Each xmlLeaf In xmlBranch.GetElementsByTagName("picturekeyword")
            Me.m_colPictureKeywords.Add(xmlLeaf.InnerText)
        Next
    End Sub

    Public Sub SaveToConfigFile()
        ' save some offline-useful stuff to the config file...
        Dim s As String
        Dim dr As Data.DataRow
        Dim xmlBranch As Xml.XmlElement
        Dim xmlLeaf As Xml.XmlElement

        Globals.LoadConfig()

        xmlBranch = Globals.GetXMLBranch("username")
        xmlBranch.InnerText = Me.m_Username
        xmlBranch = Globals.GetXMLBranch("password")
        xmlBranch.InnerText = Me.m_Username

        ' journals we can post to...
        xmlBranch = Globals.GetXMLBranch("journals")
        xmlBranch.RemoveAll() ' clean out
        For Each s In Me.m_colJournals
            xmlLeaf = xmlBranch.OwnerDocument.CreateElement("journal")
            xmlLeaf.InnerText = s
            xmlBranch.AppendChild(xmlLeaf)
        Next

        ' friends we have
        xmlBranch = Globals.GetXMLBranch("friends")
        xmlBranch.RemoveAll() ' clean out
        For Each dr In Me.m_colFriends.Rows
            xmlLeaf = xmlBranch.OwnerDocument.CreateElement("friend")
            xmlLeaf.InnerText = dr("FullName")
            xmlLeaf.SetAttribute("UserName", dr("UserName"))
            xmlBranch.AppendChild(xmlLeaf)
        Next

        ' moods we have defined
        xmlBranch = Globals.GetXMLBranch("moods")
        xmlBranch.RemoveAll() ' clean out
        For Each s In Me.m_colMoods
            xmlLeaf = xmlBranch.OwnerDocument.CreateElement("mood")
            xmlLeaf.InnerText = s
            xmlBranch.AppendChild(xmlLeaf)
        Next

        ' friend groups we have defined
        xmlBranch = Globals.GetXMLBranch("friendgroups")
        xmlBranch.RemoveAll() ' clean out
        For Each s In Me.m_colFriendGroups
            xmlLeaf = xmlBranch.OwnerDocument.CreateElement("friendgroup")
            xmlLeaf.InnerText = Me.m_colFriendGroups(s) ' Name
            xmlLeaf.SetAttribute("id", s) ' LJ ID
            xmlBranch.AppendChild(xmlLeaf)
        Next

        ' picture keywords
        xmlBranch = Globals.GetXMLBranch("picturekeywords")
        xmlBranch.RemoveAll() ' clean out
        For Each s In Me.m_colPictureKeywords
            xmlLeaf = xmlBranch.OwnerDocument.CreateElement("picturekeyword")
            xmlLeaf.InnerText = s
            xmlBranch.AppendChild(xmlLeaf)
        Next

        Globals.saveconfig()
    End Sub

    Private Sub LoadGroups(ByRef items As Specialized.NameValueCollection)
        ' load the groups for this user...
        Dim iMax As Long = items("access_count")
        Dim idx As Long
        Dim sTmp As String

        ' clear existing ones
        m_colJournals = New Collection
        Me.m_colJournals.Add(m_Username) ' add user's own journal

        For idx = 1 To iMax
            sTmp = items("access_" & idx)
            If sTmp <> "" Then m_colJournals.Add(sTmp)
        Next
    End Sub

    Private Sub LoadMoods(ByRef items As Specialized.NameValueCollection)
        ' load the moods for this user...
        Dim iMax As Long = items("mood_count")
        Dim idx As Long
        Dim sTmp As String

        ' clear existing ones
        m_colMoods = New ArrayList

        For idx = 1 To iMax
            sTmp = items("mood_" & idx & "_name")
            If sTmp <> "" Then m_colMoods.Add(sTmp)
        Next
        m_colMoods.Sort()
    End Sub

    Private Sub LoadPictureKeywords(ByRef items As Specialized.NameValueCollection)
        ' load the keywords for this user...
        Dim iMax As Long = items("pickw_count")
        Dim idx As Long
        Dim sTmp As String

        ' clear existing ones!!
        m_colPictureKeywords = New Collection
        For idx = 1 To iMax
            sTmp = items("pickw_" & idx)
            If sTmp <> "" Then m_colPictureKeywords.Add(sTmp)
        Next
    End Sub

    Private Sub LoadFriendGroups(ByRef items As Specialized.NameValueCollection)
        ' load the friend groups for this user...
        Dim iMax As Long = items("frgrp_maxnum") ' MAX, not count!!
        Dim idx As Long
        Dim sTmp As String

        ' clear existing ones!
        m_colFriendGroups = New Specialized.NameValueCollection
        For idx = 1 To iMax
            sTmp = items("frgrp_" & idx & "_name")
            If sTmp <> "" Then m_colFriendGroups.Add(idx, sTmp)
        Next
    End Sub

    Public Function Post(ByVal thePost As LJPost, Optional ByRef commWatcher As LJCommunicationWatcher = Nothing) As Specialized.NameValueCollection
        ' attempts to post entry to LJ server
        ' returns: nameValueCollection
        ' it MUST contain: Success (FAIL|OK)
        ' it MAY contain: Message (error)

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        ' Dim challenge As String
        Dim ret As New Specialized.NameValueCollection

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Generating request...")
        Try
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "clear")
            items.Add("user", Me.m_Username)
            items.Add("password", Me.m_Password)
            items.Add("subject", thePost.subject)
            items.Add("event", thePost.content)
            Select Case thePost.securityValue
                Case LJPost.ViewSecurityType.AllowAll
                    items.Add("security", "public")
                Case LJPost.ViewSecurityType.AllowNone
                    items.Add("security", "private")
                Case LJPost.ViewSecurityType.AllowFriends
                    items.Add("security", "usemask")
                    items.Add("allowmask", "1")
                Case LJPost.ViewSecurityType.FriendGroupsOnly
                    ' okay, some work ahead of us...
                    items.Add("security", "usemask")
                    items.Add("allowmask", GetBitsForAllowedFriendGroups(thePost.friendGroupsAllowed))
                Case Else
                    items.Add("security", "public")
            End Select
            If thePost.postToJournal <> "" And thePost.postToJournal <> Me.m_Username Then items.Add("usejournal", thePost.postToJournal)
            If thePost.mood.Trim <> "" Then items.Add("prop_current_mood", thePost.mood)
            If thePost.dontAutoformatToHTML = True Then items.Add("prop_opt_preformatted", "1")
            If thePost.dontEmailComments = True Then items.Add("prop_opt_noemail", "1")
            If thePost.TagList.Trim <> "" Then items.Add("prop_taglist", thePost.TagList)
            If thePost.pictureKeyword <> "" Then items.Add("prop_picture_keyword", thePost.pictureKeyword)
            If thePost.currentLocation <> "" Then items.Add("prop_current_location", thePost.currentLocation)
            If thePost.music <> "" Then items.Add("prop_current_music", thePost.music)
            If thePost.backDate = True Then
                items.Add("prop_opt_backdated", "1")
                items.Add("year", thePost.backDateDate.Year)
                items.Add("mon", thePost.backDateDate.Month)
                items.Add("day", thePost.backDateDate.Day)
                items.Add("hour", thePost.backDateDate.Hour)
                items.Add("min", thePost.backDateDate.Minute)
            Else
                items.Add("year", DatePart(DateInterval.Year, Now()))
                items.Add("mon", DatePart(DateInterval.Month, Now()))
                items.Add("day", DatePart(DateInterval.Day, Now()))
                items.Add("hour", DatePart(DateInterval.Hour, Now()))
                items.Add("min", DatePart(DateInterval.Minute, Now()))
            End If
            Select Case thePost.screenComments
                Case LJPost.CommentScreeningType.ScreenNonFriends
                    items.Add("prop_opt_screening", "F")
                Case LJPost.CommentScreeningType.ScreenAnonymous
                    items.Add("prop_opt_screening", "R")
                Case LJPost.CommentScreeningType.ScreenEveryone
                    items.Add("prop_opt_screening", "A")
                    items.Add("prop_opt_nocomments", "1")
                Case LJPost.CommentScreeningType.ScreenNone
                    items.Add("prop_opt_screening", "N")
            End Select

            If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Sending request...")
            ret = mhc.SendHTTPRequest("postevent", items)
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
        End Try

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("")
        Return ret
    End Function

    Public Function GetPostList(Optional ByVal journalToUse As String = "", Optional ByRef commWatcher As LJCommunicationWatcher = Nothing) As Collection
        ' attempts to get a list of recent posts
        ' returns: nameValueCollection
        ' it MUST contain: Success (FAIL|OK)

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        Dim ret2 As New Collection
        Dim ret As New Specialized.NameValueCollection
        Dim sTmp As String
        Dim sTmp2 As String
        Dim sTmp3 As String

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Generating request...")
        Try
            ' now generate MD5 and send back
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "getevents")
            items.Add("user", Me.m_Username)
            items.Add("password", Me.m_Password)
            items.Add("selecttype", "lastn")
            items.Add("howmany", 20)
            items.Add("clientversion", "WinCE-PocketPoster/" & MyVersion)
            If journalToUse <> "" Then items.Add("usejournal", journalToUse) ' journal to edit
            If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Sending request...")
            ret = mhc.SendHTTPRequest("login", items)
            If ret("Success") = "OK" Then
                If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response...")
                ' load list
                sTmp = ret("events_count")
                ' try to load them...
                If IsNumeric(sTmp) Then
                    Dim idx As Long
                    For idx = 1 To CInt(sTmp)
                        Dim tPost As New LJPost
                        ret2.Add(tPost)
                        tPost.postID = ret("events_" & idx & "_itemid")
                        tPost.content = ret("events_" & idx & "_event")
                        tPost.postToJournal = ret("events_" & idx & "_poster")
                        tPost.subject = ret("events_" & idx & "_subject")
                        ' tpost.friendGroupsAllowed FIXME
                        'events_n_allowmask()
                        ' tpost.securityValue
                        'events_n_security()
                        ' tpost.???
                        'events_n_eventtime()

                        For Each sTmp2 In ret.AllKeys ' key
                            sTmp3 = "prop_" & idx & "_value" ' for getting value
                            If sTmp2 = "prop_" & idx & "_name" Then
                                If ret(sTmp2) = "current_mood" Then tPost.mood = ret(sTmp3)
                                If ret(sTmp2) = "picture_keyword" Then tPost.pictureKeyword = ret(sTmp3)
                            End If
                        Next
                    Next
                End If


            End If
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
        End Try

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("")
        Return ret2
    End Function

    Private Function GetBitsForAllowedFriendGroups(ByRef colAllowedGroups As Collection) As String
        ' returns a "bit" string for each allowed group based on the LJ GetFriendsGroup list and functionality
        ' (also see PostEvent)
        ' quick way to generate 32 0s
        Dim ret As String = Space(32).Replace(Space(1), "0")
        Dim sFriendGroupID As String
        Dim sAllowedFriendGroupName As String
        Dim bThisOneAllowed As Boolean
        For Each sFriendGroupID In Me.m_colFriendGroups.Keys
            bThisOneAllowed = False
            For Each sAllowedFriendGroupName In colAllowedGroups
                If sAllowedFriendGroupName = Me.m_colFriendGroups(sFriendGroupID) Then bThisOneAllowed = True
            Next
            'ret = ret.Substring(0, sFriendGroupID - 1) & IIf(bThisOneAllowed, "1", "0") & ret.Substring(sFriendGroupID + 1)
            ret = SetCharInString(ret, sFriendGroupID, IIf(bThisOneAllowed, "1", "0"))
        Next
        Return ret
    End Function

    Private Shared Function SetCharInString(ByVal origString As String, ByVal index As Integer, ByVal replaceWithChar As String) As String
        ' index is zero based
        Dim ret As String = ""
        If index > 0 Then ret = origString.Substring(0, index)
        ret = ret & replaceWithChar
        If index < origString.Length - 1 Then ret = ret & origString.Substring(index + 1)
        Return ret
    End Function

    Private Function GetFriends(Optional ByRef commWatcher As LJCommunicationWatcher = Nothing) As Specialized.NameValueCollection
        ' attempts to get friends from the LJ server
        ' returns: nameValueCollection - see CSP from LiveJournal for details
        ' it MUST contain: Success (FAIL|OK)
        ' it MAY contain: Friends list

        Dim mhc As New LJHTTPWebClient
        Dim items As Specialized.NameValueCollection
        ' Dim challenge As String
        Dim ret As New Specialized.NameValueCollection
        Dim friendCount As Long
        Dim idx As Long
        Dim dr As DataRow

        Me.InitializeFriendsTable()
        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Generating request...")
        Try
            ' now generate MD5 and send back
            items = New Specialized.NameValueCollection
            items.Add("auth_method", "clear") ' FIXME
            items.Add("user", Me.m_Username)
            items.Add("password", Me.m_Password)
            items.Add("clientversion", "WinCE-PocketPoster/" & MyVersion)
            If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Sending request...")
            ret = mhc.SendHTTPRequest("getfriends", items)
            If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("Parsing response...")

            friendCount = ret("friend_count")
            If friendCount > 0 Then
                For idx = 1 To friendCount
                    dr = Me.m_colFriends.NewRow
                    Me.m_colFriends.Rows.Add(dr)
                    dr("LJ_Tmp_Number") = idx
                    dr("UserName") = ret("friend_" & idx & "_user")
                    dr("FullName") = ret("friend_" & idx & "_name")
                Next
            End If
        Catch e As Exception
            ret.Add("Success", "FAIL")
            ret.Add("errmsg", ".Net error: " & e.Message)
        End Try

        If Not commWatcher Is Nothing Then commWatcher.StatusUpdate("")
        Return ret
    End Function

    Private Sub InitializeFriendsTable()
        m_colFriends = New Data.DataTable
        m_colFriends.Columns.Add("LJ_Tmp_Number", Type.GetType("System.String")) ' used in the friend_X_name where this field is X
        m_colFriends.Columns.Add("UserName", Type.GetType("System.String"))
        m_colFriends.Columns.Add("FullName", Type.GetType("System.String"))
    End Sub

    Public Sub New()
        ' initialize m_colFriends
        InitializeFriendsTable()
    End Sub
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

    Private Function convertNameValueCollectionToPOSTString(ByVal items As Specialized.NameValueCollection) As String
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

    Public Function SendHTTPRequest(ByVal method As String, ByVal items As Specialized.NameValueCollection) As Specialized.NameValueCollection
        Dim tWeb As HttpWebRequest
        Dim tResp As HttpWebResponse = Nothing
        Dim tReader As IO.StreamReader = Nothing
        Dim post As String = ""
        Dim rawResp As String
        Dim ret As Specialized.NameValueCollection

        tWeb = HttpWebRequest.Create("http://" & Globals.GetSetting("LiveJournalServerURL") & "/interface/flat")
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
