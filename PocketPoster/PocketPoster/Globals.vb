Imports System.net

Module Globals

    Public MyVersion As String = "1.0"
    Public MyRevision As Long = 101

    Public mySession As New LJSession ' yeah, I'm cheating...
    Private m_SettingsXML As Xml.XmlDocument = Nothing

    Friend Sub LaunchWeb(ByVal url As String)
        If url.StartsWith("http://") Or url.StartsWith("https://") Then
        Else
            url = "http://" & url
        End If

        Select Case Globals.GetSetting("BrowserName")
            Case "", "Internet Explorer"
                System.Diagnostics.Process.Start("iexplore.exe", url)
            Case "Minimo"
                System.Diagnostics.Process.Start("/Program Files/Minimo/minimo.exe", url)
            Case Else
                System.Diagnostics.Process.Start(Globals.GetSetting("BrowserName"), url)
        End Select
    End Sub

    Private Function ConfPath() As String
        Return System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase + ".config"
    End Function

    Public Function GetAppPath() As String
        Dim s As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
        s = s.Substring(0, s.LastIndexOf("\"))
        Return s
    End Function

    Public Sub ReportError(ByRef e As Exception)
        ' save exception and all relevant data to a file to send...
        Dim xmlDoc As New Xml.XmlDocument
        Dim sGUID As String = New Guid().ToString

        ' initialize document and root element <error />
        xmlDoc.AppendChild(xmlDoc.CreateAttribute("error"))

        QuickXMLAddTag(xmlDoc.FirstChild, "dateTime", Now.ToUniversalTime.ToString)

        ' report exception
        AddErrorToReport(e, xmlDoc.FirstChild)

        xmlDoc.Save(sGUID & ".error")

        MsgBox("An error has occured. " & e.Message & vbCrLf & "Please find the file " & sGUID & ".error.")
    End Sub

    Private Function QuickXMLAddTag(ByRef xmlParentTag As Xml.XmlElement, ByVal Name As String, Optional ByVal Value As String = Nothing) As Xml.XmlElement
        Dim xmlTag As Xml.XmlElement
        Dim xmlDoc As Xml.XmlDocument = xmlParentTag.OwnerDocument
        xmlTag = xmlDoc.CreateElement(Name)
        If Not Value Is Nothing Then xmlTag.InnerText = Value
        xmlParentTag.AppendChild(xmlTag)
        Return xmlTag ' for further manipulation, if desired
    End Function

    Private Sub AddErrorToReport(ByRef e As Exception, ByRef xmlParentTag As Xml.XmlElement)
        Dim xmlException As Xml.XmlElement

        xmlException = QuickXMLAddTag(xmlParentTag, "exception")

        QuickXMLAddTag(xmlException, "message", e.Message)

        ' recurse, if necessary
        If Not e.InnerException Is Nothing Then AddErrorToReport(e.InnerException, xmlParentTag)
    End Sub

    Public Function GetXMLBranch(ByVal key As String) As Xml.XmlElement
        Dim oNodes As Xml.XmlNodeList
        Dim oTag As Xml.XmlElement

        LoadConfig()

        oNodes = m_SettingsXML.GetElementsByTagName(key)
        If oNodes.Count >= 1 Then
            Return oNodes(0)
        Else
            oTag = m_SettingsXML.CreateElement(key)
            m_SettingsXML.FirstChild.AppendChild(oTag)
            Return oTag
        End If
    End Function

    Public Function GetSetting(ByVal Key As String) As String
        Dim oNodes As Xml.XmlNodeList
        Dim oTag As Xml.XmlElement

        LoadConfig()

        oNodes = m_SettingsXML.GetElementsByTagName(Key)
        If oNodes.Count >= 1 Then
            oTag = oNodes(0)
            Return oTag.InnerText
        End If

        Return ""
    End Function

    Public Sub LoadConfig()
        Dim s As String

        ' quick check for old settings file...
        ' probably safe to remove by 1 July 2006
        If IO.File.Exists("\pocketposter_conf.xml") Then
            IO.File.Move("\pocketposter_conf.xml", ConfPath())
        End If
        ' end quick check

        If m_SettingsXML Is Nothing Then
            ' if not yet loaded, load/create
            m_SettingsXML = New Xml.XmlDocument
            If IO.File.Exists(ConfPath()) Then
                m_SettingsXML.Load(ConfPath())
            Else
                m_SettingsXML.AppendChild(m_SettingsXML.CreateElement("root"))
                ' create initial xml layout
            End If

            ' set defaults if necessary
            s = Globals.GetSetting("LiveJournalServerURL")
            If s = "" Then Globals.SetSetting("LiveJournalServerURL", "www.livejournal.com")
            s = Globals.GetSetting("UpdateCheckOnLogin")
            If s = "" Then Globals.SetSetting("UpdateCheckOnLogin", "true")
        End If
    End Sub

    Public Sub SaveConfig()
        m_SettingsXML.Save(ConfPath())
    End Sub

    Public Sub SetSetting(ByVal key As String, ByVal value As String)
        Dim oNodes As Xml.XmlNodeList
        Dim oTag As Xml.XmlElement

        LoadConfig()

        oNodes = m_SettingsXML.GetElementsByTagName(key)
        If oNodes.Count >= 1 Then
            For Each oTag In oNodes
                oTag.InnerText = value
            Next
        Else
            oTag = m_SettingsXML.CreateElement(key)
            oTag.InnerText = value
            m_SettingsXML.FirstChild.AppendChild(oTag)
        End If

        Globals.SaveConfig()
    End Sub

End Module
