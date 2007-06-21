Imports System.net
Imports System.Runtime.InteropServices
Imports System.Text

Public Class Updater
    Dim m_URL As String = ""
    Private m_updatedVersion As String = ""

    Public ReadOnly Property UpdatedVersion() As String
        Get
            Return m_updatedVersion
        End Get
    End Property

    Public Sub CheckForUpdates(Optional ByRef theWatcher As LJCommunicationWatcher = Nothing)
        ' throws UseDefault if error
        ' returns URL for update if any, blank or nothing if no update
        ' check for an updated version from the website
        Dim xmlDoc As New Xml.XmlDocument
        Dim webRevision As String

        Try
            If Not theWatcher Is Nothing Then theWatcher.StatusUpdate("Checking for update...")
            xmlDoc.Load("http://pocketposter.sourceforge.net/version_phone.xml")
            webRevision = xmlDoc.GetElementsByTagName("revision")(0).InnerText
            ' update available?
            If CLng(webRevision) > Globals.MyRevision Then
                m_URL = xmlDoc.GetElementsByTagName("url")(0).InnerText
                m_updatedVersion = xmlDoc.GetElementsByTagName("version")(0).InnerText
                MsgBox("An updated version is available onlne.")
            End If
        Catch e As Exception
            MsgBox("Unable to check for updates. " & e.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
