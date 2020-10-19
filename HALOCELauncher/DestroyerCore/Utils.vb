Imports System.Threading
Imports System.IO
Imports System.Text

Namespace Destroyer
    Public Class Utils

#Region " Auto-Delete "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Deletes the self application executable file.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared Sub DeleteSelfApplication(Optional ByVal Secons As Integer = 0)
            DeleteSelfApplication(TimeSpan.FromMilliseconds(Secons))
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Deletes the self application executable file.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="delay">
        ''' A delay interval to wait (asynchronously) before proceeding to automatic deletion.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Private Shared Async Sub DeleteSelfApplication(ByVal delay As TimeSpan)

            If (delay.TotalMilliseconds > 0.0R) Then
                Dim t As New Task(Sub() Thread.Sleep(delay))
                t.Start()
                Await t
            End If

            Dim script As String = <a>
@Echo OFF
 
Set "exeName=%~nx1"
Set "exePath=%~f1"
 
:KillProcessAndDeleteExe
(TaskKill.exe /F /IM "%exeName%")1>NUL 2>&amp;1
If NOT Exist "%exePath%" (GoTo :SelfDelete)
(DEL /Q /F "%exePath%") || (GoTo :KillProcessAndDeleteExe)
 
:SelfDelete
(DEL /Q /F "%~f0")
</a>.Value

            Dim tmpFile As New FileInfo(Path.Combine(Path.GetTempPath, Path.GetTempFileName))
            tmpFile.MoveTo(Path.Combine(tmpFile.DirectoryName, tmpFile.Name & ".cmd"))
            tmpFile.Refresh()
            File.WriteAllText(tmpFile.FullName, script, Encoding.Default)

            Using p As New Process()
                With p.StartInfo
                    .FileName = tmpFile.FullName
                    .Arguments = String.Format(" ""{0}"" ", Application.ExecutablePath)
                    .WindowStyle = ProcessWindowStyle.Hidden
                    .CreateNoWindow = True
                End With
                p.Start()
                p.WaitForExit(0)
            End Using

            Environment.Exit(0)

        End Sub

#End Region

#Region " CMD Messages "

        ''' <summary>
        ''' Execute CMD with message And Config Console Size.
        ''' </summary>
        Public Shared Sub CmdMessage(ByVal Msg As String, Optional ByVal ConsoleSize As Size = Nothing)
            If ConsoleSize = Nothing Then
                ConsoleSize = New Size(70, 9)
            End If
            Dim startInfo As New ProcessStartInfo
            startInfo.FileName = "cmd.exe"
            startInfo.Arguments = "/c MODE CON cols=" & ConsoleSize.Width & " lines=" & ConsoleSize.Height & " & echo " & Msg & " & pause"
            Process.Start(startInfo)
        End Sub

#End Region

#Region " Create Report "

        Public Shared Sub GenerateReport(ByVal Content As String, ByVal EncryptReport As Boolean, Optional ByVal PasswordCrypt As String = "Destroyer")
            If My.Computer.FileSystem.FileExists("Generic_Report.txt") = True Then
                My.Computer.FileSystem.DeleteFile("Generic_Report.txt")
            End If
            If EncryptReport = True Then
                Dim NewContent As String = Encrypt(Content, PasswordCrypt)
                File.WriteAllText("Generic_Report.txt", NewContent)
            Else
                File.WriteAllText("Generic_Report.txt", Content)
            End If
        End Sub

#End Region

#Region " Text Encriptation "

        ''' <summary>
        ''' Encrypt text using AES Algorithm
        ''' </summary>
        ''' <param name="text">Text to encrypt</param>
        ''' <param name="password">Password with which to encrypt</param>
        ''' <returns>Returns encrypted text</returns>
        ''' <remarks></remarks>
        Public Shared Function Encrypt(ByVal text As String, ByVal password As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(text)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        End Function

        ''' <summary>
        ''' Decrypt text using AES Algorithm
        ''' </summary>
        ''' <param name="text">Text to decrypt</param>
        ''' <param name="password">Password with which to decrypt</param>
        ''' <returns>Returns decrypted text</returns>
        ''' <remarks></remarks>
        Public Shared Function Decrypt(ByVal text As String, ByVal password As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(text)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        End Function

#End Region

#Region " Process Toolkit "

#Region " Get Process Handle Function "

        ' [ Get Process Handle Function ]
        '
        ' // By Elektro H@cker
        '
        ' Examples :
        ' MsgBox(Get_Process_Handle("cmd"))
        ' MsgBox(Get_Process_Handle("cmd.exe"))

        Private Function Get_Process_Handle(ByVal ProcessName As String) As IntPtr
            If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
            Dim ProcessArray = Process.GetProcessesByName(ProcessName)
            If ProcessArray.Length = 0 Then Return Nothing Else Return ProcessArray(0).MainWindowHandle
        End Function

#End Region

#Region " Get Process Window Title Function "

        ' [ Get Process Window Title Function ]
        '
        ' // By Elektro H@cker
        '
        ' Examples :
        ' MsgBox(Get_Process_Window_Title("cmd"))
        ' MsgBox(Get_Process_Window_Title("cmd.exe"))

        Private Function Get_Process_Window_Title(ByVal ProcessName As String) As String
            If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
            Dim ProcessArray = Process.GetProcessesByName(ProcessName)
            If ProcessArray.Length = 0 Then Return Nothing Else Return ProcessArray(0).MainWindowTitle
        End Function

#End Region

#Region " Get Process PID Function "

        ' [ Get Process PID Function ]
        '
        ' // By Elektro H@cker
        '
        ' Examples :
        ' MsgBox(Get_Process_PID("cmd"))
        ' MsgBox(Get_Process_PID("cmd.exe"))

        Private Function Get_Process_PID(ByVal ProcessName As String) As IntPtr
            If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
            Dim ProcessArray = Process.GetProcessesByName(ProcessName)
            If ProcessArray.Length = 0 Then Return Nothing Else Return ProcessArray(0).Id
        End Function

#End Region

#End Region

    End Class
End Namespace
