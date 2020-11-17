Imports System.Runtime.InteropServices

Namespace Core

    Public Class Launcher

        Private Timer1 As New System.Windows.Forms.Timer With {.Interval = 100}
        Public GameProc As String = String.Empty
        Public GameDir As String = String.Empty

        Public Sub New(Optional ByVal GameDirEx As String = Nothing)
            If GameDirEx = Nothing Then
                If My.Settings.GameDefect = 0 Then
                    GameDirEx = My.Settings.GameDirCE
                ElseIf My.Settings.GameDefect = 1 Then
                    GameDirEx = My.Settings.GameDirPC
                End If
            Else
                GameDir = GameDirEx
            End If
            My.Settings.OldGameDir = GameDir
            GameProc = IO.Path.GetFileName(GameDir)
            AddHandler Timer1.Tick, AddressOf Timer1_Tick
        End Sub

        Public Sub Launch(Optional ByVal IpAdress As String = "", Optional ByVal Password As String = "")
            Dim Larguments As String = String.Empty
            Dim Arguments As String = GetArguments()
            If My.Settings.LaunchMode = 0 Then Larguments = " -window "
            If Not IpAdress = "" Then
                My.Settings.OldIPAdress = IpAdress
                Larguments += " -connect " & IpAdress & " "
            Else
                My.Settings.OldIPAdress = ""
            End If
            My.Settings.Save()
            If Not Password = "" Then
                Larguments += Arguments & " -password " & Password
            Else
                Larguments += Arguments
            End If

            If IO.File.Exists(GameDir) = True Then
                If My.Settings.MultiLauncher = True Then
                    If IO.File.Exists("Multiclient.dll") = False Then
                        MsgBox("The Multiclient.dll file was not found.")
                        Exit Sub
                    End If

                    Dim MultiClient As Boolean = Multilauncher(GameDir, Larguments)

                Else
                    Dim p As New Process
                    p.StartInfo.WorkingDirectory = (IO.Path.GetDirectoryName(GameDir))
                    p.StartInfo.FileName = IO.Path.GetFileName(GameDir)
                    p.StartInfo.Arguments = Larguments
                    p.Start()
                    p.WaitForInputIdle()
                End If

                If My.Settings.LaunchMode = 0 Then Timer1.Enabled = True
            End If
        End Sub

        <DllImport("Multiclient.dll", EntryPoint:="multi_launch", CallingConvention:=CallingConvention.StdCall)>
        Public Shared Function MlaunchEx(ByVal halodir As String, ByVal arguments As String) As Integer
        End Function

        Public Function Multilauncher(ByVal halodir As String, ByVal argument As String) As Boolean
            Dim result As Integer = MlaunchEx(halodir, argument)
            Return CBool(result)
        End Function


        Dim ProcC As Integer = 0
        Dim Procede As Boolean = False

        Private Sub Timer1_Tick(sender As Object, e As EventArgs)
            Dim procs As Process() = Process.GetProcesses()

            Dim ProcessNameEX As String = IO.Path.GetFileNameWithoutExtension(GameProc)
            Dim processcount As Integer = procs.Count
            For Each proc As Process In procs

                If proc.ProcessName = ProcessNameEX Then
                    Dim placement = GetPlacement(proc.MainWindowHandle)
                    If placement.showCmd.ToString = "Normal" Then
                        Dim FakeFullSc As Boolean = FullScreenEmulation(GameProc)
                        Procede = True
                    End If
                    If Procede = True Then
                        If placement.showCmd.ToString = "Maximized" Then
                            Dim FakeFullSc As Boolean = FullScreenEmulation(GameProc)
                            Timer1.Enabled = False
                        End If
                    End If
                End If
            Next
        End Sub

        Public Function FullScreenEmulation(ByVal ProcessName As String) As Boolean
            Try
                If ProcessName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then ProcessName = ProcessName.Remove(ProcessName.Length - ".exe".Length)
                Dim HWND As IntPtr = Process.GetProcessesByName(ProcessName).First.MainWindowHandle
                For i As Integer = 0 To 2
                    SetWindowStyle.SetWindowStyle(HWND, SetWindowStyle.WindowStyles.WS_BORDER)
                    SetWindowState.SetWindowState(HWND, SetWindowState.WindowState.Maximize)
                Next
                BringMainWindowToFront(ProcessName)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function GetArguments() As String
            Dim Arguments As String = String.Empty
            If My.Settings.LaunchMode = 1 Then Arguments += " -window "
            If My.Settings.ConsoleC = True Then Arguments += " -console "
            If My.Settings.ScreenshotC = True Then Arguments += " -screenshot "
            If My.Settings.devC = True Then Arguments += " -devmode "
            If My.Settings.SoundC = True Then Arguments += " -nosound "
            If My.Settings.VideoC = True Then Arguments += " -novideo "
            If My.Settings.GammaC = True Then Arguments += " -nogamma "
            If My.Settings.JoystickC = True Then Arguments += " -nojoystick "
            If My.Settings.SafeModeC = True Then Arguments += " -safemode "
            Return Arguments
        End Function

#Region " Set Focus "

        <System.Runtime.InteropServices.DllImport("user32.dll")>
        Private Shared Function SetForegroundWindow(ByVal hwnd As IntPtr) As Integer
        End Function

        Dim FisrsFocus As Boolean = False

        Public Sub BringMainWindowToFront(ByVal processName As String)
            If FisrsFocus = False Then
                Dim bProcess As Process = Process.GetProcessesByName(processName).FirstOrDefault()

                If bProcess IsNot Nothing Then
                    SetForegroundWindow(bProcess.MainWindowHandle)
                End If
                FisrsFocus = True
            End If
        End Sub

#End Region

#Region " Check FakeFullscreen "

        Private Shared Function GetPlacement(ByVal hwnd As IntPtr) As WINDOWPLACEMENT
            Dim placement As WINDOWPLACEMENT = New WINDOWPLACEMENT()
            placement.length = Marshal.SizeOf(placement)
            GetWindowPlacement(hwnd, placement)
            Return placement
        End Function

        <DllImport("user32.dll", SetLastError:=True)>
        Friend Shared Function GetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
        End Function

        <Serializable>
        <StructLayout(LayoutKind.Sequential)>
        Friend Structure WINDOWPLACEMENT
            Public length As Integer
            Public flags As Integer
            Public showCmd As ShowWindowCommands
            Public ptMinPosition As System.Drawing.Point
            Public ptMaxPosition As System.Drawing.Point
            Public rcNormalPosition As System.Drawing.Rectangle
        End Structure

        Friend Enum ShowWindowCommands As Integer
            Hide = 0
            Normal = 1
            Minimized = 2
            Maximized = 3
        End Enum

#End Region

    End Class

End Namespace


