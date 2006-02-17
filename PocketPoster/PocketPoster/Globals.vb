Module Globals

    Public MyVersion As String = "0.7"

    Private m_SettingsXML As Xml.XmlDocument = Nothing

    Private Function ConfPath() As String
        Return System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase + ".config"
    End Function

    Public Function ReadSetting(ByVal Key As String) As String
        Dim oNodes As Xml.XmlNodeList
        Dim oTag As Xml.XmlElement

        LoadXMLDocument()

        oNodes = m_SettingsXML.GetElementsByTagName(Key)
        If oNodes.Count >= 1 Then
            oTag = oNodes(0)
            Return oTag.InnerText
        End If

        Return ""
    End Function

    Private Sub LoadXMLDocument()
        ' quick check for old settings file...
        ' probably safe to remove by 1 July 2006
        If IO.File.Exists("\pocketposter_conf.xml") Then
            IO.File.Move("\pocketposter_conf.xml", ConfPath())
        End If
        ' end quick check

        If m_SettingsXML Is Nothing Then
            m_SettingsXML = New Xml.XmlDocument
            If IO.File.Exists(ConfPath()) Then
                m_SettingsXML.Load(ConfPath())
            Else
                m_SettingsXML.AppendChild(m_SettingsXML.CreateElement("root"))
                ' create initial xml layout
            End If
        End If
    End Sub

    Private Sub SaveXMLDocument()
        m_SettingsXML.Save(ConfPath())
    End Sub

    Public Sub SaveSetting(ByVal key As String, ByVal value As String)
        Dim oNodes As Xml.XmlNodeList
        Dim oTag As Xml.XmlElement

        LoadXMLDocument()

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

        SaveXMLDocument()
    End Sub
End Module
