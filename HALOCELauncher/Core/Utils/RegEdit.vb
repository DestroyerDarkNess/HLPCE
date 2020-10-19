' ***********************************************************************
' Author           : Elektro
' Last Modified On : 08-30-2014
' ***********************************************************************
' <copyright file="Class1.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Usage Examples "

' -----------
' Create Key:
' -----------
' RegEdit.CreateKey("HKCU\Software\MyProgram")                        ' Creates "HKCU\Software\MyProgram"
' RegEdit.CreateKey("HKEY_CURRENT_USER\Software\MyProgram\Settings\") ' Creates "HKCU\Software\MyProgram\Settings"
'
' -----------
' Delete Key:
' -----------
' RegEdit.DeleteKey("HKLM\Software\7-zip")                ' Deletes the "7-zip" tree including subkeys
' RegEdit.DeleteKey("HKEY_LOCAL_MACHINE\Software\7-zip\") ' Deletes the "7-zip" tree including subkeys
'
' -------------
' Delete Value:
' -------------
' RegEdit.DeleteValue("HKCU\Software\7-Zip", "Lang")               ' Deletes "Lang" Value
' RegEdit.DeleteValue("HKEY_CURRENT_USER\Software\7-Zip\", "Lang") ' Deletes "Lang" Value
'
' ----------
' Get Value:
' ----------
' Dim Data As String = RegEdit.GetValue("HKCU\Software\MyProgram", "Value name"))
' Dim Data As String = RegEdit.GetValue("HKEY_CURRENT_USER\Software\MyProgram", "Value name"))
'
' ----------
' Set Value:
' ----------
' RegEdit.SetValue("HKCU\Software\MyProgram", "Value name", "Data", Microsoft.Win32.RegistryValueKind.String)               ' Create/Replace "Value Name" with "Data" as string data
' RegEdit.SetValue("HKEY_CURRENT_USER\Software\MyProgram\", "Value name", "Data", Microsoft.Win32.RegistryValueKind.String) ' Create/Replace "Value Name" with "Data" as string data
'
' -----------
' Export Key:
' -----------
' RegEdit.ExportKey("HKLM", "C:\HKLM.reg")                  ' Export entire "HKEY_LOCAL_MACHINE" Tree to "C:\HKLM.reg" file.
' RegEdit.ExportKey("HKLM\Software\7-zip\", "C:\7-zip.reg") ' Export entire "7-zip" Tree to "C:\7-zip.reg" file.
'
' ------------
' Import File:
' ------------
' RegEdit.ImportRegFile("C:\Registry_File.reg") ' Install a registry file.
'
' ------------
' Jump To Key:
' ------------
' RegEdit.JumpToKey("HKLM")                               ' Opens Regedit at "HKEY_LOCAL_MACHINE" Root.
' RegEdit.JumpToKey("HKEY_LOCAL_MACHINE\Software\7-zip\") ' Opens Regedit at "HKEY_LOCAL_MACHINE\Software\7-zip" tree.
'
' -----------
' Exist Key?:
' -----------
' MsgBox(RegEdit.ExistKey("HKCU\software") ' Checks if "Software" Key exist.

' -------------
' Exist Value?:
' -------------
' MsgBox(RegEdit.ExistValue("HKLM\software\7-zip", "Path") ' Checks if "Path" value exist.
'
' ------------
' Exist Data?:
' ------------
' MsgBox(RegEdit.ExistData("HKLM\software\7-zip", "Path") ' Checks if "Path" value have empty data.
'
' ---------
' Copy Key:
' ---------
' RegEdit.CopyKey("HKCU\Software\7-Zip", "HKCU\Software\7-zip Backup") ' Copies "HKCU\Software\7-Zip" to "HKCU\Software\7-zip Backup"
'
' -----------
' Copy Value:
' -----------
' RegEdit.CopyValue("HKLM\software\7-zip", "path", "HKLM\software\7-zip", "path_backup") ' Copies "Path" value with their data to "HKLM\software\7-zip" "path_backup".
'
' -------------------
' SetUserAccessKey:
' -------------------
' RegEdit.SetUserAccessKey("HKCU\Software\7-Zip", {RegEdit.ReginiUserAccess.Administrators_Full_Access})
' RegEdit.SetUserAccessKey("HKEY_CURRENT_USER\Software\7-Zip", {RegEdit.ReginiUserAccess.Administrators_Full_Access, RegEdit.ReginiUserAccess.Creator_Full_Access, RegEdit.ReginiUserAccess.System_Full_Access})

#End Region

#Region " Imports "

Imports Microsoft.Win32
Imports System.IO
Imports System.Text

#End Region

#Region " RegEdit "

''' <summary>
''' Contains registry related methods.
''' </summary>
Public Class RegEdit

#Region " Enumerations "

    ''' <summary>
    ''' Specifies an User identifier for Regini.exe command.
    ''' </summary>
    Public Enum ReginiUserAccess As Integer

        Administrators_Full_Access = 1I

        Administrators_Read_Access = 2I

        Administrators_Read_and_Write_Access = 3I

        Administrators_Read_Write_and_Delete_Access = 4I

        Administrators_Read_Write_and_Execute_Access = 20I

        Creator_Full_Access = 5I

        Creator_Read_and_Write_Access = 6I

        Interactive_User_Full_Access = 21I

        Interactive_User_Read_and_Write_Access = 22I

        Interactive_User_Read_Write_and_Delete_Access = 23I

        Power_Users_Full_Access = 11I

        Power_Users_Read_and_Write_Access = 12I

        Power_Users_Read_Write_and_Delete_Access = 13I

        System_Full_Access = 17I

        System_Operators_Full_Access = 14I

        System_Operators_Read_and_Write_Access = 15I

        System_Operators_Read_Write_and_Delete_Access = 16I

        System_Read_Access = 19I

        System_Read_and_Write_Access = 18I

        World_Full_Access = 7I

        World_Read_Access = 8I

        World_Read_and_Write_Access = 9I

        World_Read_Write_and_Delete_Access = 10I

    End Enum

#End Region

#Region " Public Methods "

#Region " Create "

    ''' <summary>
    ''' Creates a new registry key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    Public Shared Sub CreateKey(ByVal Key As String)

        Using Reg As RegistryKey = GetRoot(Key)

            Reg.CreateSubKey(GetPath(Key), RegistryKeyPermissionCheck.Default, RegistryOptions.None)

        End Using

    End Sub

#End Region

#Region " Delete "

    ''' <summary>
    ''' Deletes a registry key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    Public Shared Sub DeleteKey(ByVal Key As String)

        Using Reg As RegistryKey = GetRoot(Key)

            Reg.DeleteSubKeyTree(GetPath(Key), throwOnMissingSubKey:=False)

        End Using

    End Sub

    ''' <summary>
    ''' Delete a registry value.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="Value">Indicates the registry value.</param>
    Public Shared Sub DeleteValue(ByVal Key As String,
                                  ByVal Value As String)

        Using Reg As RegistryKey = GetRoot(Key)

            Reg.OpenSubKey(GetPath(Key), writable:=False).
                DeleteValue(Value, throwOnMissingValue:=False)

        End Using

    End Sub

#End Region

#Region " Get "

    ''' <summary>
    ''' Gets the data of a registry value.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="Value">Indicates the registry value.</param>
    ''' <returns>The registry data.</returns>
    Public Shared Function GetValue(ByVal Key As String,
                                    ByVal Value As String) As Object

        Using Reg As RegistryKey = GetRoot(Key)

            Return Reg.OpenSubKey(GetPath(Key), writable:=False).
                       GetValue(Value, defaultValue:=Nothing)

        End Using

    End Function

#End Region

#Region " Set "

    ''' <summary>
    ''' Set the data of a registry value.
    ''' If the Key or value doesn't exist it will be created.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="Value">Indicates the registry value.</param>
    ''' <param name="Data">Indicates the registry data.</param>
    ''' <param name="DataType">Indicates the type of data.</param>
    Public Shared Sub SetValue(ByVal Key As String,
                               ByVal Value As String,
                               ByVal Data As Object,
                               Optional ByVal DataType As RegistryValueKind = RegistryValueKind.Unknown)

        Using Reg As RegistryKey = GetRoot(Key)

            Select Case DataType

                Case RegistryValueKind.Unknown
                    Reg.OpenSubKey(GetPath(Key), writable:=True).
                        SetValue(Value, Data)

                Case RegistryValueKind.Binary
                    Reg.OpenSubKey(GetPath(Key), writable:=True).
                        SetValue(Value, Encoding.ASCII.GetBytes(Data), RegistryValueKind.Binary)

                Case Else
                    Reg.OpenSubKey(GetPath(Key), writable:=True).
                        SetValue(Value, Data, DataType)

            End Select

        End Using

    End Sub

#End Region

#Region " Exist "

    ''' <summary>
    ''' Determines whether a Key exists.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <returns><c>true</c> if key exist, <c>false</c> otherwise.</returns>
    Public Shared Function ExistKey(ByVal Key As String) As Boolean

        Dim RootKey As RegistryKey = GetRoot(Key)
        Dim KeyPath As String = GetPath(Key)

        If (RootKey Is Nothing) OrElse (String.IsNullOrEmpty(KeyPath)) Then
            Return False
        End If

        Using Reg As RegistryKey = RootKey

            Return RootKey.OpenSubKey(KeyPath, writable:=False) IsNot Nothing

        End Using

    End Function

    ''' <summary>
    ''' Determines whether a value exists.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="Value">Indicates the registry value.</param>
    ''' <returns><c>true</c> if value exist, <c>false</c> otherwise.</returns>
    Public Shared Function ExistValue(ByVal Key As String, ByVal Value As String) As Boolean

        Dim RootKey As RegistryKey = GetRoot(Key)
        Dim KeyPath As String = GetPath(Key)

        If (RootKey Is Nothing) OrElse (String.IsNullOrEmpty(KeyPath)) Then
            Return False
        End If

        Using Reg As RegistryKey = RootKey

            Return RootKey.OpenSubKey(KeyPath, writable:=False).
                           GetValue(Value, defaultValue:=Nothing) IsNot Nothing

        End Using

    End Function

    ''' <summary>
    ''' Determines whether data exists in a registry value.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="Value">Indicates the registry value.</param>
    ''' <returns><c>true</c> if data exist, <c>false</c> otherwise.</returns>
    Public Shared Function ExistData(ByVal Key As String, ByVal Value As String) As Boolean

        Dim RootKey As RegistryKey = GetRoot(Key)
        Dim KeyPath As String = GetPath(Key)

        If (RootKey Is Nothing) OrElse (String.IsNullOrEmpty(KeyPath)) Then
            Return False
        End If

        Using Reg As RegistryKey = RootKey

            Return Not String.IsNullOrEmpty(RootKey.OpenSubKey(KeyPath, writable:=False).
                                                    GetValue(Value, defaultValue:=Nothing))

        End Using

    End Function

#End Region

#Region " Copy "

    ''' <summary>
    ''' Copy a key tree to another location on the registry.
    ''' </summary>
    ''' <param name="OldKey">Indicates the registry key to be copied from.</param>
    ''' <param name="NewKey">Indicates the registry key to be pasted from.</param>
    Public Shared Sub CopyKey(ByVal OldKey As String,
                              ByVal NewKey As String)

        Using OldReg As RegistryKey = GetRoot(OldKey).OpenSubKey(GetPath(OldKey), writable:=False)

            CreateKey(NewKey)

            Using NewReg As RegistryKey = GetRoot(NewKey).OpenSubKey(GetPath(NewKey), writable:=True)

                CopySubKeys(OldReg, NewReg)

            End Using ' NewReg

        End Using ' OldReg

    End Sub

    ''' <summary>
    ''' Copies a value with their data to another location on the registry.
    ''' If the Key don't exist it will be created automatically.
    ''' </summary>
    ''' <param name="OldKey">Indicates the registry key to be copied from.</param>
    ''' <param name="OldValue">Indicates the registry value to be copied from.</param>
    ''' <param name="NewKey">Indicates the registry key to be pasted from.</param>
    ''' <param name="NewValue">Indicates the registry value to be pasted from.</param>
    Public Shared Sub CopyValue(ByVal OldKey As String,
                                ByVal OldValue As String,
                                ByVal NewKey As String,
                                ByVal NewValue As String)

        CreateKey(Key:=NewKey)
        SetValue(Key:=NewKey, Value:=NewValue, Data:=GetValue(OldKey, OldValue), DataType:=RegistryValueKind.Unknown)

    End Sub

#End Region

#Region " Process dependant methods "

    ''' <summary>
    ''' Opens Regedit process and jumps at the specified key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    Public Shared Sub JumpToKey(ByVal Key As String)

        Using Reg As RegistryKey = GetRoot(Key)

            SetValue(Key:="HKCU\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit",
                     Value:="LastKey",
                     Data:=String.Format("{0}\{1}", Reg.Name, GetPath(Key)),
                     DataType:=RegistryValueKind.String)

        End Using

        Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Regedit.exe"))

    End Sub

    ''' <summary>
    ''' Imports a registry file.
    ''' </summary>
    ''' <param name="RegFile">The registry file to import.</param>
    ''' <returns><c>true</c> if operation succeeds, <c>false</c> otherwise.</returns>
    Public Shared Function ImportRegFile(ByVal RegFile As String) As Boolean

        Using proc As New Process With {
            .StartInfo = New ProcessStartInfo() With {
                  .FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Reg.exe"),
                  .Arguments = String.Format("Import ""{0}""", RegFile),
                  .CreateNoWindow = True,
                  .WindowStyle = ProcessWindowStyle.Hidden,
                  .UseShellExecute = False
                }
            }

            proc.Start()
            proc.WaitForExit()

            Return Not CBool(proc.ExitCode)

        End Using

    End Function

    ''' <summary>
    ''' Exports a key to a registry file.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="OutputFile">Indicates the output file.</param>
    ''' <returns><c>true</c> if operation succeeds, <c>false</c> otherwise.</returns>
    Public Shared Function ExportKey(ByVal Key As String, ByVal OutputFile As String) As Boolean

        Using Reg As RegistryKey = GetRoot(Key)

            Using proc As New Process With {
                    .StartInfo = New ProcessStartInfo() With {
                          .FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Reg.exe"),
                          .Arguments = String.Format("Export ""{0}\{1}"" ""{2}"" /y", Reg.Name, GetPath(Key), OutputFile),
                          .CreateNoWindow = True,
                          .WindowStyle = ProcessWindowStyle.Hidden,
                          .UseShellExecute = False
                        }
                    }

                proc.Start()
                proc.WaitForExit()

                Return Not CBool(proc.ExitCode)

            End Using

        End Using

    End Function

    ''' <summary>
    ''' Modifies the user permissions of a registry key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <param name="UserAccess">Indicates the user-access.</param>
    ''' <returns><c>true</c> if operation succeeds, <c>false</c> otherwise.</returns>
    Public Shared Function SetUserAccessKey(ByVal Key As String, ByVal UserAccess() As ReginiUserAccess) As Boolean

        Dim tmpFile As String = Path.Combine(Path.GetTempPath(), "Regini.ini")

        Dim PermissionString As String =
            String.Format("[{0}]",
                          String.Join(" "c, UserAccess.Cast(Of Integer)))

        Using TextFile As New StreamWriter(path:=tmpFile, append:=False, encoding:=Encoding.Default)

            Using Reg As RegistryKey = GetRoot(Key)

                TextFile.WriteLine(String.Format("""{0}\{1}"" {2}", Reg.Name, GetPath(Key), PermissionString))

            End Using ' Reg

        End Using ' TextFile

        Using proc As New Process With {
            .StartInfo = New ProcessStartInfo() With {
                   .FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Regini.exe"),
                   .Arguments = ControlChars.Quote & tmpFile & ControlChars.Quote,
                   .CreateNoWindow = True,
                   .WindowStyle = ProcessWindowStyle.Hidden,
                   .UseShellExecute = False
                }
            }

            proc.Start()
            proc.WaitForExit()

            Return Not CBool(proc.ExitCode)

        End Using

    End Function

#End Region

#End Region

#Region " Private Methods "

#Region " Get "

    ''' <summary>
    ''' Gets the registry root of a key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <returns>The registry root.</returns>
    Private Shared Function GetRoot(ByVal Key As String) As RegistryKey

        Select Case Key.ToUpper.Split("\").First

            Case "HKCR", "HKEY_CLASSES_ROOT"
                Return Registry.ClassesRoot

            Case "HKCC", "HKEY_CURRENT_CONFIG"
                Return Registry.CurrentConfig

            Case "HKCU", "HKEY_CURRENT_USER"
                Return Registry.CurrentUser

            Case "HKLM", "HKEY_LOCAL_MACHINE"
                Return Registry.LocalMachine

            Case "HKEY_PERFORMANCE_DATA"
                Return Registry.PerformanceData

            Case Else
                Return Nothing

        End Select

    End Function

    ''' <summary>
    ''' Returns the registry path of a key.
    ''' </summary>
    ''' <param name="Key">Indicates the registry key.</param>
    ''' <returns>The registry path.</returns>
    Private Shared Function GetPath(ByVal Key As String) As String

        If String.IsNullOrEmpty(Key) Then
            Return String.Empty
        End If

        Dim KeyPath As String = Key.Substring(Key.IndexOf("\"c) + 1I)

        If KeyPath.EndsWith("\"c) Then
            KeyPath = KeyPath.Substring(0I, KeyPath.LastIndexOf("\"c))
        End If

        Return KeyPath

    End Function

#End Region

#Region " Copy "

    ''' <summary>
    ''' Copies the sub-keys of the specified registry key.
    ''' </summary>
    ''' <param name="OldKey">Indicates the old key.</param>
    ''' <param name="NewKey">Indicates the new key.</param>
    Private Shared Sub CopySubKeys(ByVal OldKey As RegistryKey, ByVal NewKey As RegistryKey)

        ' Copy Values
        For Each Value As String In OldKey.GetValueNames()

            NewKey.SetValue(Value, OldKey.GetValue(Value))

        Next Value

        ' Copy Subkeys
        For Each SubKey As String In OldKey.GetSubKeyNames()

            CreateKey(String.Format("{0}\{1}", NewKey.Name, SubKey))
            CopySubKeys(OldKey.OpenSubKey(SubKey, writable:=False), NewKey.OpenSubKey(SubKey, writable:=True))

        Next SubKey

    End Sub

#End Region

#End Region

End Class

#End Region