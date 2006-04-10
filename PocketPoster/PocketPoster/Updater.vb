Imports System.net
Imports System.Runtime.InteropServices
Imports System.Text

Class SHELLEXECUTEEX
    Public cbSize As UInt32
    Public fMask As UInt32
    Public hwnd As IntPtr
    Public lpVerb As IntPtr
    Public lpFile As IntPtr
    Public lpParameters As IntPtr
    Public lpDirectory As IntPtr

    Public nShow As Integer
    Public hInstApp As IntPtr
    ' Optional members
    Public lpIDList As IntPtr
    Public lpClass As IntPtr
    Public hkeyClass As IntPtr
    Public dwHotKey As UInt32
    Public hIcon As IntPtr
    Public hProcess As IntPtr

    <DllImport("coredll")> Public Shared Function LocalAlloc(ByVal flags As Integer, ByVal size As Integer) As IntPtr

    End Function
    <DllImport("coredll")> Public Shared Function ShellExecuteEx(ByVal ex As SHELLEXECUTEEX) As Integer

    End Function
    <DllImport("coredll")> Public Shared Sub LocalFree(ByVal ptr As IntPtr)

    End Sub

End Class 'SHELLEXECUTEEX


Public Class Updater
    Dim m_req As HttpWebRequest
    Dim m_resp As HttpWebResponse
    Dim m_file As IO.FileStream
    Private m_URL As String = "" ' url of update, if applicable
    Private m_maxFileSize As Long = 0
    Private m_dataBufferArrayExample As New Byte ' don't use me, just array.create after me
    Private m_dataBuffer As Byte()
    Private m_blockSize As Integer = 1024 ' bytes, 1K

    Public Event UpdateDownloading(ByVal progressPercent As Long)
    Public Event UpdateComplete()
    ' thrown when either update downloaded complete or no update can be downloaded (invalid URL, etc..)

    Public Function CheckForUpdates(Optional ByRef theWatcher As LJCommunicationWatcher = Nothing) As TriState
        ' throws UseDefault if error
        ' returns URL for update if any, blank or nothing if no update
        ' check for an updated version from the website
        Dim xmlDoc As New Xml.XmlDocument
        Dim webRevision As String

        Try
            If Not theWatcher Is Nothing Then theWatcher.StatusUpdate("Checking for update...")
            xmlDoc.Load("http://pocketposter.sourceforge.net/version.xml")
            webRevision = xmlDoc.GetElementsByTagName("revision")(0).InnerText
            ' update available?
            If CLng(webRevision) > Globals.MyRevision Then
                m_URL = xmlDoc.GetElementsByTagName("url")(0).InnerText
                Return TriState.True
            End If
        Catch e As Exception
            MsgBox("Unable to get update. " & e.Message, MsgBoxStyle.Critical)
            Return TriState.UseDefault
        End Try
        Return TriState.False
    End Function

    Public Sub GetUpdate(Optional ByRef theWatcher As LJCommunicationWatcher = Nothing)
        If m_URL = "" Then Exit Sub
        If Not theWatcher Is Nothing Then theWatcher.StatusUpdate("Downloading update...")
        m_req = HttpWebRequest.Create(m_URL)
        m_req.BeginGetResponse(New AsyncCallback(AddressOf GetUpdate_Starting), Nothing)
    End Sub

    Private Sub GetUpdate_Starting(ByVal ia As IAsyncResult)
        Try
            m_resp = m_req.EndGetResponse(ia)
        Catch ex As Exception
            MsgBox("Unable to get update. " & ex.Message, MsgBoxStyle.Critical)
            RaiseEvent UpdateComplete() ' not really, but anyways
            Exit Sub
        End Try
        ' setup buffer
        m_maxFileSize = m_resp.ContentLength
        m_dataBuffer = System.Array.CreateInstance(m_dataBufferArrayExample.GetType, m_blockSize)
        ' open file
        m_file = IO.File.OpenWrite(GetUpdate_LocalFileName())
        ' get first data
        m_resp.GetResponseStream().BeginRead(m_dataBuffer, 0, m_blockSize, New AsyncCallback(AddressOf GetUpdate_InProgress), Nothing)
    End Sub

    Private Function GetUpdate_LocalFileName() As String
        Return IO.Path.Combine(Globals.GetAppPath(), "download.cab")
    End Function

    Private Sub GetUpdate_InProgress(ByVal ia As IAsyncResult)
        ' get bytes and count then
        Dim iCount As Integer = m_resp.GetResponseStream().EndRead(ia)

        ' write to file
        m_file.Write(m_dataBuffer, 0, iCount)

        If m_maxFileSize > 0 Then
            RaiseEvent UpdateDownloading(m_file.Position / m_maxFileSize * 100)
        Else
            RaiseEvent UpdateDownloading(50) ' unable to tell, for some reason
        End If

        If iCount > 0 Then
            ' we still have work to do!
            m_resp.GetResponseStream().BeginRead(m_dataBuffer, 0, m_blockSize, New AsyncCallback(AddressOf GetUpdate_InProgress), Nothing)
        Else
            m_file.Close()
            ' launch update!
            RaiseEvent UpdateComplete()
        End If

    End Sub

    Public Sub LaunchUpdate()
        Dim docname As String = GetUpdate_LocalFileName()
        Dim nSize As Integer = docname.Length * 2 + 2
        Dim pData As IntPtr = SHELLEXECUTEEX.LocalAlloc(&H40, nSize)
        Marshal.Copy(Encoding.Unicode.GetBytes(docname), 0, pData, nSize - 2)

        Dim see As New SHELLEXECUTEEX()
        see.cbSize = Convert.ToUInt32(60)
        see.dwHotKey = Convert.ToUInt32(0)
        see.fMask = Convert.ToUInt32(0)
        see.hIcon = IntPtr.Zero
        see.hInstApp = IntPtr.Zero
        see.hProcess = IntPtr.Zero
        see.lpClass = IntPtr.Zero
        see.lpDirectory = IntPtr.Zero
        see.lpIDList = IntPtr.Zero
        see.lpParameters = IntPtr.Zero
        see.lpVerb = IntPtr.Zero
        see.nShow = 0
        see.lpFile = pData

        SHELLEXECUTEEX.ShellExecuteEx(see)

        SHELLEXECUTEEX.LocalFree(pData)

        Application.Exit() ' die die die
    End Sub
End Class
