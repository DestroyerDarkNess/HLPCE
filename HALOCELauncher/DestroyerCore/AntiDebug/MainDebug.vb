Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Security.Principal

' ***********************************************************************
' Author           : Destroyer
' Last Modified On : 01-04-2020
' Discord          : Destroyer#8328
' ***********************************************************************
' <copyright file="MainDebug.vb" company="S4Lsalsoft">
'     Copyright (c) S4Lsalsoft. All rights reserved.
' </copyright>
' ***

Namespace Destroyer.AntiDebug
    Public Class MainDebug

#Region " Properties "

        Private Shared _LogResult As String = String.Empty
        Public Shared ReadOnly Property LogResult As String
            Get
                Return _LogResult
            End Get
        End Property

#End Region

#Region " Pinvoke "

        <DllImport("Kernel32.dll", SetLastError:=False)>
        Friend Shared Function IsDebuggerPresent(
    ) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("ntdll.dll", SetLastError:=True)>
        Public Shared Function CsrGetProcessId() As Integer
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)>
        Public Shared Function OpenProcess(
                                      ByVal dwDesiredAccess As Integer,
                                      ByVal bInheritHandle As Boolean,
                                      ByVal dwProcessId As Integer) As IntPtr
        End Function

        ' Private Delegate Function pNtQueryInformationProcess(ByVal UnnamedParameter As System.IntPtr, ByVal UnnamedParameter2 As UInteger, ByVal UnnamedParameter3 As Object, ByVal UnnamedParameter4 As UInteger, ByRef UnnamedParameter5 As UInteger) As NtStatus

        Declare Function NtQueryInformationProcess Lib "ntdll.dll" ( _
   processHandle As IntPtr, processInformationClass As Integer, _
   processInformation As IntPtr, processInformationLength As Integer, _
   returnLength As IntPtr) As NtStatus

#End Region

#Region " Types "

        Public Enum DebugDetectionTypes
            IsDebuggerPresent = 0
            IsDbgCsrss = 1
            Parent_Process = 2
            IsDebuggerAttached = 3
            IsDebuggerLogging = 4
            CheckProcessDebugFlags = 5
            AllScanEgines = 6
            None = 7
        End Enum

        <Flags>
        Public Enum ProcessAccessFlags As Integer
            All = &H1F0FFF
            Terminate = &H1
            CreateThread = &H2
            VirtualMemoryOperation = &H8
            VirtualMemoryRead = &H10
            VirtualMemoryWrite = &H20
            DuplicateHandle = &H40
            CreateProcess = &H80
            SetQuota = &H100
            SetInformation = &H200
            QueryInformation = &H400
            QueryLimitedInformation = &H1000
            Synchronize = &H100000
        End Enum

        Public Enum NtStatus As UInteger
            ' Success
            Success = &H0
            Wait0 = &H0
            Wait1 = &H1
            Wait2 = &H2
            Wait3 = &H3
            Wait63 = &H3F
            Abandoned = &H80
            AbandonedWait0 = &H80
            AbandonedWait1 = &H81
            AbandonedWait2 = &H82
            AbandonedWait3 = &H83
            AbandonedWait63 = &HBF
            UserApc = &HC0
            KernelApc = &H100
            Alerted = &H101
            Timeout = &H102
            Pending = &H103
            Reparse = &H104
            MoreEntries = &H105
            NotAllAssigned = &H106
            SomeNotMapped = &H107
            OpLockBreakInProgress = &H108
            VolumeMounted = &H109
            RxActCommitted = &H10A
            NotifyCleanup = &H10B
            NotifyEnumDir = &H10C
            NoQuotasForAccount = &H10D
            PrimaryTransportConnectFailed = &H10E
            PageFaultTransition = &H110
            PageFaultDemandZero = &H111
            PageFaultCopyOnWrite = &H112
            PageFaultGuardPage = &H113
            PageFaultPagingFile = &H114
            CrashDump = &H116
            ReparseObject = &H118
            NothingToTerminate = &H122
            ProcessNotInJob = &H123
            ProcessInJob = &H124
            ProcessCloned = &H129
            FileLockedWithOnlyReaders = &H12A
            FileLockedWithWriters = &H12B

            ' Informational
            Informational = &H40000000
            ObjectNameExists = &H40000000
            ThreadWasSuspended = &H40000001
            WorkingSetLimitRange = &H40000002
            ImageNotAtBase = &H40000003
            RegistryRecovered = &H40000009

            ' Warning
            Warning = &H80000000UI
            GuardPageViolation = &H80000001UI
            DatatypeMisalignment = &H80000002UI
            Breakpoint = &H80000003UI
            SingleStep = &H80000004UI
            BufferOverflow = &H80000005UI
            NoMoreFiles = &H80000006UI
            HandlesClosed = &H8000000AUI
            PartialCopy = &H8000000DUI
            DeviceBusy = &H80000011UI
            InvalidEaName = &H80000013UI
            EaListInconsistent = &H80000014UI
            NoMoreEntries = &H8000001AUI
            LongJump = &H80000026UI
            DllMightBeInsecure = &H8000002BUI

            ' Error
            [Error] = &HC0000000UI
            Unsuccessful = &HC0000001UI
            NotImplemented = &HC0000002UI
            InvalidInfoClass = &HC0000003UI
            InfoLengthMismatch = &HC0000004UI
            AccessViolation = &HC0000005UI
            InPageError = &HC0000006UI
            PagefileQuota = &HC0000007UI
            InvalidHandle = &HC0000008UI
            BadInitialStack = &HC0000009UI
            BadInitialPc = &HC000000AUI
            InvalidCid = &HC000000BUI
            TimerNotCanceled = &HC000000CUI
            InvalidParameter = &HC000000DUI
            NoSuchDevice = &HC000000EUI
            NoSuchFile = &HC000000FUI
            InvalidDeviceRequest = &HC0000010UI
            EndOfFile = &HC0000011UI
            WrongVolume = &HC0000012UI
            NoMediaInDevice = &HC0000013UI
            NoMemory = &HC0000017UI
            NotMappedView = &HC0000019UI
            UnableToFreeVm = &HC000001AUI
            UnableToDeleteSection = &HC000001BUI
            IllegalInstruction = &HC000001DUI
            AlreadyCommitted = &HC0000021UI
            AccessDenied = &HC0000022UI
            BufferTooSmall = &HC0000023UI
            ObjectTypeMismatch = &HC0000024UI
            NonContinuableException = &HC0000025UI
            BadStack = &HC0000028UI
            NotLocked = &HC000002AUI
            NotCommitted = &HC000002DUI
            InvalidParameterMix = &HC0000030UI
            ObjectNameInvalid = &HC0000033UI
            ObjectNameNotFound = &HC0000034UI
            ObjectNameCollision = &HC0000035UI
            ObjectPathInvalid = &HC0000039UI
            ObjectPathNotFound = &HC000003AUI
            ObjectPathSyntaxBad = &HC000003BUI
            DataOverrun = &HC000003CUI
            DataLate = &HC000003DUI
            DataError = &HC000003EUI
            CrcError = &HC000003FUI
            SectionTooBig = &HC0000040UI
            PortConnectionRefused = &HC0000041UI
            InvalidPortHandle = &HC0000042UI
            SharingViolation = &HC0000043UI
            QuotaExceeded = &HC0000044UI
            InvalidPageProtection = &HC0000045UI
            MutantNotOwned = &HC0000046UI
            SemaphoreLimitExceeded = &HC0000047UI
            PortAlreadySet = &HC0000048UI
            SectionNotImage = &HC0000049UI
            SuspendCountExceeded = &HC000004AUI
            ThreadIsTerminating = &HC000004BUI
            BadWorkingSetLimit = &HC000004CUI
            IncompatibleFileMap = &HC000004DUI
            SectionProtection = &HC000004EUI
            EasNotSupported = &HC000004FUI
            EaTooLarge = &HC0000050UI
            NonExistentEaEntry = &HC0000051UI
            NoEasOnFile = &HC0000052UI
            EaCorruptError = &HC0000053UI
            FileLockConflict = &HC0000054UI
            LockNotGranted = &HC0000055UI
            DeletePending = &HC0000056UI
            CtlFileNotSupported = &HC0000057UI
            UnknownRevision = &HC0000058UI
            RevisionMismatch = &HC0000059UI
            InvalidOwner = &HC000005AUI
            InvalidPrimaryGroup = &HC000005BUI
            NoImpersonationToken = &HC000005CUI
            CantDisableMandatory = &HC000005DUI
            NoLogonServers = &HC000005EUI
            NoSuchLogonSession = &HC000005FUI
            NoSuchPrivilege = &HC0000060UI
            PrivilegeNotHeld = &HC0000061UI
            InvalidAccountName = &HC0000062UI
            UserExists = &HC0000063UI
            NoSuchUser = &HC0000064UI
            GroupExists = &HC0000065UI
            NoSuchGroup = &HC0000066UI
            MemberInGroup = &HC0000067UI
            MemberNotInGroup = &HC0000068UI
            LastAdmin = &HC0000069UI
            WrongPassword = &HC000006AUI
            IllFormedPassword = &HC000006BUI
            PasswordRestriction = &HC000006CUI
            LogonFailure = &HC000006DUI
            AccountRestriction = &HC000006EUI
            InvalidLogonHours = &HC000006FUI
            InvalidWorkstation = &HC0000070UI
            PasswordExpired = &HC0000071UI
            AccountDisabled = &HC0000072UI
            NoneMapped = &HC0000073UI
            TooManyLuidsRequested = &HC0000074UI
            LuidsExhausted = &HC0000075UI
            InvalidSubAuthority = &HC0000076UI
            InvalidAcl = &HC0000077UI
            InvalidSid = &HC0000078UI
            InvalidSecurityDescr = &HC0000079UI
            ProcedureNotFound = &HC000007AUI
            InvalidImageFormat = &HC000007BUI
            NoToken = &HC000007CUI
            BadInheritanceAcl = &HC000007DUI
            RangeNotLocked = &HC000007EUI
            DiskFull = &HC000007FUI
            ServerDisabled = &HC0000080UI
            ServerNotDisabled = &HC0000081UI
            TooManyGuidsRequested = &HC0000082UI
            GuidsExhausted = &HC0000083UI
            InvalidIdAuthority = &HC0000084UI
            AgentsExhausted = &HC0000085UI
            InvalidVolumeLabel = &HC0000086UI
            SectionNotExtended = &HC0000087UI
            NotMappedData = &HC0000088UI
            ResourceDataNotFound = &HC0000089UI
            ResourceTypeNotFound = &HC000008AUI
            ResourceNameNotFound = &HC000008BUI
            ArrayBoundsExceeded = &HC000008CUI
            FloatDenormalOperand = &HC000008DUI
            FloatDivideByZero = &HC000008EUI
            FloatInexactResult = &HC000008FUI
            FloatInvalidOperation = &HC0000090UI
            FloatOverflow = &HC0000091UI
            FloatStackCheck = &HC0000092UI
            FloatUnderflow = &HC0000093UI
            IntegerDivideByZero = &HC0000094UI
            IntegerOverflow = &HC0000095UI
            PrivilegedInstruction = &HC0000096UI
            TooManyPagingFiles = &HC0000097UI
            FileInvalid = &HC0000098UI
            InstanceNotAvailable = &HC00000ABUI
            PipeNotAvailable = &HC00000ACUI
            InvalidPipeState = &HC00000ADUI
            PipeBusy = &HC00000AEUI
            IllegalFunction = &HC00000AFUI
            PipeDisconnected = &HC00000B0UI
            PipeClosing = &HC00000B1UI
            PipeConnected = &HC00000B2UI
            PipeListening = &HC00000B3UI
            InvalidReadMode = &HC00000B4UI
            IoTimeout = &HC00000B5UI
            FileForcedClosed = &HC00000B6UI
            ProfilingNotStarted = &HC00000B7UI
            ProfilingNotStopped = &HC00000B8UI
            NotSameDevice = &HC00000D4UI
            FileRenamed = &HC00000D5UI
            CantWait = &HC00000D8UI
            PipeEmpty = &HC00000D9UI
            CantTerminateSelf = &HC00000DBUI
            InternalError = &HC00000E5UI
            InvalidParameter1 = &HC00000EFUI
            InvalidParameter2 = &HC00000F0UI
            InvalidParameter3 = &HC00000F1UI
            InvalidParameter4 = &HC00000F2UI
            InvalidParameter5 = &HC00000F3UI
            InvalidParameter6 = &HC00000F4UI
            InvalidParameter7 = &HC00000F5UI
            InvalidParameter8 = &HC00000F6UI
            InvalidParameter9 = &HC00000F7UI
            InvalidParameter10 = &HC00000F8UI
            InvalidParameter11 = &HC00000F9UI
            InvalidParameter12 = &HC00000FAUI
            MappedFileSizeZero = &HC000011EUI
            TooManyOpenedFiles = &HC000011FUI
            Cancelled = &HC0000120UI
            CannotDelete = &HC0000121UI
            InvalidComputerName = &HC0000122UI
            FileDeleted = &HC0000123UI
            SpecialAccount = &HC0000124UI
            SpecialGroup = &HC0000125UI
            SpecialUser = &HC0000126UI
            MembersPrimaryGroup = &HC0000127UI
            FileClosed = &HC0000128UI
            TooManyThreads = &HC0000129UI
            ThreadNotInProcess = &HC000012AUI
            TokenAlreadyInUse = &HC000012BUI
            PagefileQuotaExceeded = &HC000012CUI
            CommitmentLimit = &HC000012DUI
            InvalidImageLeFormat = &HC000012EUI
            InvalidImageNotMz = &HC000012FUI
            InvalidImageProtect = &HC0000130UI
            InvalidImageWin16 = &HC0000131UI
            LogonServer = &HC0000132UI
            DifferenceAtDc = &HC0000133UI
            SynchronizationRequired = &HC0000134UI
            DllNotFound = &HC0000135UI
            IoPrivilegeFailed = &HC0000137UI
            OrdinalNotFound = &HC0000138UI
            EntryPointNotFound = &HC0000139UI
            ControlCExit = &HC000013AUI
            PortNotSet = &HC0000353UI
            DebuggerInactive = &HC0000354UI
            CallbackBypass = &HC0000503UI
            PortClosed = &HC0000700UI
            MessageLost = &HC0000701UI
            InvalidMessage = &HC0000702UI
            RequestCanceled = &HC0000703UI
            RecursiveDispatch = &HC0000704UI
            LpcReceiveBufferExpected = &HC0000705UI
            LpcInvalidConnectionUsage = &HC0000706UI
            LpcRequestsNotAllowed = &HC0000707UI
            ResourceInUse = &HC0000708UI
            ProcessIsProtected = &HC0000712UI
            VolumeDirty = &HC0000806UI
            FileCheckedOut = &HC0000901UI
            CheckOutRequired = &HC0000902UI
            BadFileType = &HC0000903UI
            FileTooLarge = &HC0000904UI
            FormsAuthRequired = &HC0000905UI
            VirusInfected = &HC0000906UI
            VirusDeleted = &HC0000907UI
            TransactionalConflict = &HC0190001UI
            InvalidTransaction = &HC0190002UI
            TransactionNotActive = &HC0190003UI
            TmInitializationFailed = &HC0190004UI
            RmNotActive = &HC0190005UI
            RmMetadataCorrupt = &HC0190006UI
            TransactionNotJoined = &HC0190007UI
            DirectoryNotRm = &HC0190008UI
            CouldNotResizeLog = &HC0190009UI
            TransactionsUnsupportedRemote = &HC019000AUI
            LogResizeInvalidSize = &HC019000BUI
            RemoteFileVersionMismatch = &HC019000CUI
            CrmProtocolAlreadyExists = &HC019000FUI
            TransactionPropagationFailed = &HC0190010UI
            CrmProtocolNotFound = &HC0190011UI
            TransactionSuperiorExists = &HC0190012UI
            TransactionRequestNotValid = &HC0190013UI
            TransactionNotRequested = &HC0190014UI
            TransactionAlreadyAborted = &HC0190015UI
            TransactionAlreadyCommitted = &HC0190016UI
            TransactionInvalidMarshallBuffer = &HC0190017UI
            CurrentTransactionNotValid = &HC0190018UI
            LogGrowthFailed = &HC0190019UI
            ObjectNoLongerExists = &HC0190021UI
            StreamMiniversionNotFound = &HC0190022UI
            StreamMiniversionNotValid = &HC0190023UI
            MiniversionInaccessibleFromSpecifiedTransaction = &HC0190024UI
            CantOpenMiniversionWithModifyIntent = &HC0190025UI
            CantCreateMoreStreamMiniversions = &HC0190026UI
            HandleNoLongerValid = &HC0190028UI
            NoTxfMetadata = &HC0190029UI
            LogCorruptionDetected = &HC0190030UI
            CantRecoverWithHandleOpen = &HC0190031UI
            RmDisconnected = &HC0190032UI
            EnlistmentNotSuperior = &HC0190033UI
            RecoveryNotNeeded = &HC0190034UI
            RmAlreadyStarted = &HC0190035UI
            FileIdentityNotPersistent = &HC0190036UI
            CantBreakTransactionalDependency = &HC0190037UI
            CantCrossRmBoundary = &HC0190038UI
            TxfDirNotEmpty = &HC0190039UI
            IndoubtTransactionsExist = &HC019003AUI
            TmVolatile = &HC019003BUI
            RollbackTimerExpired = &HC019003CUI
            TxfAttributeCorrupt = &HC019003DUI
            EfsNotAllowedInTransaction = &HC019003EUI
            TransactionalOpenNotAllowed = &HC019003FUI
            TransactedMappingUnsupportedRemote = &HC0190040UI
            TxfMetadataAlreadyPresent = &HC0190041UI
            TransactionScopeCallbacksNotSet = &HC0190042UI
            TransactionRequiredPromotion = &HC0190043UI
            CannotExecuteFileInTransaction = &HC0190044UI
            TransactionsNotFrozen = &HC0190045UI

            MaximumNtStatus = &HFFFFFFFFUI
        End Enum


#End Region

#Region " Public Methods "

        Public Shared Function Debugger_Check(ByVal DebugTypeFunction As DebugDetectionTypes) As Boolean
            Select Case DebugTypeFunction
                Case DebugDetectionTypes.IsDebuggerPresent : Return IsDebuggerPresent()
                Case DebugDetectionTypes.IsDebuggerAttached : Return IsDebuggerAttached()
                Case DebugDetectionTypes.IsDebuggerLogging : Return IsDebuggerLogging()
                Case DebugDetectionTypes.IsDbgCsrss : Return False 'IsDbgCsrss()
                Case DebugDetectionTypes.Parent_Process : Return Parent_Process()
                Case DebugDetectionTypes.CheckProcessDebugFlags : If CheckProcessDebugFlags() = False Then : Return True : Else : Return False : End If
                Case DebugDetectionTypes.AllScanEgines : Return AllScan()
            End Select
            Return False
        End Function

        Private Shared Function AllScan() As Boolean
            If IsDebuggerPresent() = True Then
                _LogResult = "Debugger Presence Detected." & vbNewLine
                Return True
            End If
            'If IsDbgCsrss() = True Then
            'Return True
            'End If
            If CheckProcessDebugFlags() = False Then
                _LogResult = "CheckProcessDebugFlags = inverse of EPROCESS->NoDebugInherit so (!TRUE == FALSE)" & vbNewLine
                Return True
            End If

            If IsDebuggerAttached() = True Then
                _LogResult = "Attached debugger detected." & vbNewLine
                Return True
            End If
            If IsDebuggerLogging() = True Then
                _LogResult = "Logging debugger detected." & vbNewLine
                Return True
            End If
            If Parent_Process() = True Then
                _LogResult = "The parent Process is not the one indicated." & vbNewLine
                Return True
            End If

            Return False
        End Function



        ' CheckProcessDebugFlags will return true if 
        ' the EPROCESS->NoDebugInherit is == FALSE, 
        ' the reason we check for false is because 
        ' the NtQueryProcessInformation function returns the
        ' inverse of EPROCESS->NoDebugInherit so (!TRUE == FALSE)
        Public Shared Function CheckProcessDebugFlags(Optional ByVal CheckH0NtStatus As Boolean = False) As Boolean
            ' Much easier in ASM but C/C++ looks so much better

            Dim hProc As IntPtr = OpenProcess(CType(&H1F0FFF, ProcessAccessFlags), False, Process.GetCurrentProcess().Id)

            Dim NoDebugInherit As Integer = 0
            Dim Status As New NtStatus()

            ' Get NtQueryInformationProcess
            ' Dim NtQIP As pNtQueryInformationProcess = AddressOf NtQueryInformationProcess
            'GetCurrentProcess() c++

            Status = NtQueryInformationProcess(hProc, &H1F, NoDebugInherit, 4, Nothing)

            If CheckH0NtStatus = True Then
                If Status <> &H0 Then
                    _LogResult = "CheckProcessDebugFlags [Status = " & Status.ToString & "]" & vbNewLine
                    Return False
                End If
            End If

            If NoDebugInherit = False Then
                Return True
            Else
                _LogResult = "CheckProcessDebugFlags [NoDebugInherit = " & NoDebugInherit.ToString & "]" & vbNewLine
                Return False
            End If
        End Function



        Public Shared Function IsDebuggerAttached() As Boolean
            Return Debugger.IsAttached
        End Function

        Public Shared Function IsDebuggerLogging() As Boolean
            Return Debugger.IsLogging
        End Function

        Public Shared Sub DebuggerBreak()
            Debugger.Break()
        End Sub

        '////////////////////////////////////////////////////////////////////////
        'Administrator privileges are required for this Function.
        Const PROCESS_ALL_ACCESS = &H1F0FFF
        Public Shared Function IsDbgCsrss() As Boolean
            If IsAdministrator = True Then
                Return CBool(OpenProcess(PROCESS_ALL_ACCESS, 0, CsrGetProcessId))
            End If
            Return False
        End Function
        'Administrator privileges are required for this Function.
        '////////////////////////////////////////////////////////////////////////

        Public Shared Function Parent_Process(Optional ByVal ProcessName As String = "explorer.exe") As Boolean
            If ProcessName.ToLower.EndsWith(".exe") Then ProcessName = ProcessName.Substring(0, ProcessName.Length - 4)
            Dim myId = Process.GetCurrentProcess().Id
            Dim query = String.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId)
            Dim search = New ManagementObjectSearcher("root\CIMV2", query)
            Dim results = search.[Get]().GetEnumerator()
            results.MoveNext()
            Dim queryObj = results.Current
            Dim parentId = CUInt(queryObj("ParentProcessId"))
            Dim parent = Process.GetProcessById(CInt(parentId))
            Dim ParentProcessName As String = parent.ProcessName
            If LCase(ParentProcessName) = LCase(ProcessName) Then
                Return False
            Else
                _LogResult = "The process : " & ParentProcessName & ".exe" & " I am trying to run / debug the program." & vbNewLine
                Return True
            End If
        End Function

        Public Shared ReadOnly Property IsAdministrator As Boolean
            Get
                Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
            End Get
        End Property

#End Region

    End Class
End Namespace

