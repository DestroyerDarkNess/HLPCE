' ***********************************************************************
' Author           : Elektro
' Last Modified On : 10-02-2014
' ***********************************************************************
' <copyright file="TimeMeasurer.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Usage Examples "

'Public Class TimeMeasurer_Test
'
'    ''' <summary>
'    ''' The <see cref="TimeMeasurer"/> instance that measure time intervals.
'    ''' </summary>
'    Private WithEvents Clock As New TimeMeasurer With {.UpdateInterval = 100}
'
'    Private ctrl_ElapsedTime As Control ' Control used to display the time elapsed interval.
'    Private ctrl_RemainingTime As Control ' Control used to display the time remaining interval.
'
'    Private Shadows Sub Load() Handles MyBase.Load
'
'        ctrl_ElapsedTime = LabelElapsed
'        ctrl_RemainingTime = LabelRemaining
'
'        Me.Clock.Start(60000) ' Measure 1 minute
'
'        ' Or...
'        ' Me.Clock.Stop() ' Stop temporally the time interval measurement.
'        ' Me.Clock.Resume() ' Resume a previouslly stopped time interval measurement.
'        ' Dim ClockState As TimeMeasurer.TimeMeasurerState = Me.Clock.State ' Get the state.
'
'    End Sub
'
'    ''' <summary>
'    ''' Handles the ElapsedTimeUpdated event of the Clock instance.
'    ''' </summary>
'    ''' <param name="sender">The source of the event.</param>
'    ''' <param name="e">The <see cref="TimeMeasurer.TimeMeasureEventArgs"/> instance containing the event data.</param>
'    Private Sub Clock_ElapsedTimeUpdated(ByVal sender As Object, ByVal e As TimeMeasurer.TimeMeasureEventArgs) _
'    Handles Clock.ElapsedTimeUpdated
'
'        ' Measure H:M:S:MS
'        ctrl_ElapsedTime.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:000}",
'                                              e.Hour, e.Minute, e.Second, e.Millisecond)
'
'        ' Measure H:M:S
'        ctrl_ElapsedTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
'                                              e.Hour, e.Minute, e.Second)
'
'    End Sub
'
'    ''' <summary>
'    ''' Handles the RemainingTimeUpdated event of the Clock instance.
'    ''' </summary>
'    ''' <param name="sender">The source of the event.</param>
'    ''' <param name="e">The <see cref="TimeMeasurer.TimeMeasureEventArgs"/> instance containing the event data.</param>
'    Private Sub Clock_RemainingTimeUpdated(ByVal sender As Object, ByVal e As TimeMeasurer.TimeMeasureEventArgs) _
'    Handles Clock.RemainingTimeUpdated
'
'        ' Measure H:M:S:MS
'        ctrl_RemainingTime.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:000}",
'                                                e.Hour, e.Minute, e.Second, e.Millisecond)
'
'        ' Measure H:M:S
'        ctrl_RemainingTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
'                                                e.Hour, e.Minute, e.Second + 1)
'
'    End Sub
'
'    ''' <summary>
'    ''' Handles the ElapsedTimeFinished event of the Clock instance.
'    ''' </summary>
'    ''' <param name="sender">The source of the event.</param>
'    ''' <param name="e">The <see cref="TimeMeasurer.TimeMeasureEventArgs"/> instance containing the event data.</param>
'    Private Sub Clock_ElapsedTimeFinished(ByVal sender As Object, ByVal e As TimeMeasurer.TimeMeasureEventArgs) _
'    Handles Clock.ElapsedTimeFinished
'
'        ' Measure H:M:S:MS
'        ctrl_ElapsedTime.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:000}",
'                                              e.Hour, e.Minute, e.Second, e.Millisecond)
'
'        ' Measure H:M:S
'        ctrl_ElapsedTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
'                                              e.Hour, e.Minute, e.Second)
'
'    End Sub
'
'    ''' <summary>
'    ''' Handles the RemainingTimeFinished event of the Clock instance.
'    ''' </summary>
'    ''' <param name="sender">The source of the event.</param>
'    ''' <param name="e">The <see cref="TimeMeasurer.TimeMeasureEventArgs"/> instance containing the event data.</param>
'    Private Sub Clock_RemainingTimeFinished(ByVal sender As Object, ByVal e As TimeMeasurer.TimeMeasureEventArgs) _
'    Handles Clock.RemainingTimeFinished
'
'        ' Measure H:M:S:MS
'        ctrl_RemainingTime.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:000}",
'                                                e.Hour, e.Minute, e.Second, e.Millisecond)
'
'        ' Measure H:M:S
'        ctrl_RemainingTime.Text = String.Format("{0:00}:{1:00}:{2:00}",
'                                                e.Hour, e.Minute, e.Second)
'
'    End Sub
'
'End Class

#End Region

#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports System.ComponentModel

#End Region

''' <summary>
''' Measure a time interval.
''' This can be used as a chronometer or countdown timer.
''' </summary>
Public NotInheritable Class TimeMeasurer

#Region " Objects "

    ''' <summary>
    ''' <see cref="Stopwatch"/> instance to retrieve the elapsed time.
    ''' </summary>
    Private TimeElapsed As Stopwatch

    ''' <summary>
    ''' <see cref="TimeSpan"/> instance to retrieve the remaining time.
    ''' </summary>
    Private TimeRemaining As TimeSpan

    ''' <summary>
    ''' <see cref="Timer"/> instance that updates the elapsed and remaining times and raises the events.
    ''' </summary>
    Private WithEvents MeasureTimer As Timer

    ''' <summary>
    ''' Indicates wheter the <see cref="TimeMeasurer"/> instance has finished to measure intervals.
    ''' </summary>
    Private IsFinished As Boolean

#End Region

#Region " Properties "

    ''' <summary>
    ''' Gets the current state of this <see cref="TimeMeasurer"/> instance.
    ''' </summary>
    ''' <value>The update interval.</value>
    Public ReadOnly Property State As TimeMeasurerState
        Get
            If Me.IsFinished Then
                Return TimeMeasurerState.Finished

            ElseIf (Me.TimeElapsed Is Nothing) OrElse Not (Me.TimeElapsed.IsRunning) Then
                Return TimeMeasurerState.Stopped

            Else
                Return TimeMeasurerState.Running

            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the update interval.
    ''' </summary>
    ''' <value>The update interval.</value>
    Public Property UpdateInterval As Integer
        Get
            Return Me._UpdateInterval
        End Get
        Set(ByVal value As Integer)
            Me._UpdateInterval = value
            If Me.MeasureTimer IsNot Nothing Then
                Me.MeasureTimer.Interval = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' The update interval
    ''' </summary>
    Private _UpdateInterval As Integer = 100I

#End Region

#Region " Enumerations "

    ''' <summary>
    ''' Specifies the current state of a <see cref="TimeMeasurer"/> instance.
    ''' </summary>
    <Description("Enum used as return value of 'State' property.")>
    Public Enum TimeMeasurerState As Integer

        ''' <summary>
        ''' The <see cref="TimeMeasurer"/> instance is running and measuring time intervals.
        ''' </summary>
        Running = 0I

        ''' <summary>
        ''' The <see cref="TimeMeasurer"/> instance is temporally stopped, waiting to resume.
        ''' </summary>
        Stopped = 1I

        ''' <summary>
        ''' The <see cref="TimeMeasurer"/> instance has finished to measure the time intervals.
        ''' </summary>
        Finished = 2I

    End Enum

#End Region

#Region " Events "

    ''' <summary>
    ''' Occurs when the elapsed time updates.
    ''' </summary>
    Public Event ElapsedTimeUpdated(ByVal sender As Object, ByVal e As TimeMeasureEventArgs)

    ''' <summary>
    ''' Occurs when the remaining time updates.
    ''' </summary>
    Public Event RemainingTimeUpdated(ByVal sender As Object, ByVal e As TimeMeasureEventArgs)

    ''' <summary>
    ''' Occurs when the elapsed time finishes.
    ''' </summary>
    Public Event ElapsedTimeFinished(ByVal sender As Object, ByVal e As TimeMeasureEventArgs)

    ''' <summary>
    ''' Occurs when the elapsed time finishes.
    ''' </summary>
    Public Event RemainingTimeFinished(ByVal sender As Object, ByVal e As TimeMeasureEventArgs)

    ''' <summary>
    ''' Contains the <see cref="TimeMeasureEventArgs"/> arguments.
    ''' </summary>
    Public Class TimeMeasureEventArgs : Inherits EventArgs

        ''' <summary>
        ''' Gets or sets the hour.
        ''' </summary>
        ''' <value>The hour.</value>
        Public Property Hour As Double

        ''' <summary>
        ''' Gets or sets the minute.
        ''' </summary>
        ''' <value>The minute.</value>
        Public Property Minute As Double

        ''' <summary>
        ''' Gets or sets the Second.
        ''' </summary>
        ''' <value>The Second.</value>
        Public Property Second As Double

        ''' <summary>
        ''' Gets or sets the Millisecond.
        ''' </summary>
        ''' <value>The Millisecond.</value>
        Public Property Millisecond As Double

    End Class

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Starts the time interval measurement from zero.
    ''' </summary>
    ''' <param name="Milliseconds">Indicates the time interval to measure, in milliseconds.</param>
    Public Sub Start(ByVal Milliseconds As Double)

        If Milliseconds > (TimeSpan.MaxValue.TotalMilliseconds - 1001.0R) Then
            Throw New ArgumentOutOfRangeException("Milliseconds",
                                                  String.Format("The value can't be greater than {0}",
                                                                CStr(TimeSpan.MaxValue.TotalMilliseconds - 1001.0R)))
        End If

        Me.TimeElapsed = New Stopwatch
        Me.TimeRemaining = TimeSpan.FromMilliseconds(Milliseconds)
        Me.MeasureTimer = New Timer With
           {
             .Tag = Milliseconds,
             .Interval = Me.UpdateInterval,
             .Enabled = True
           }

        Me.TimeElapsed.Start()
        Me.MeasureTimer.Start()

    End Sub

    ''' <summary>
    ''' Stops the time interval measurement.
    ''' </summary>
    Public Sub [Stop]()

        If (Me.MeasureTimer Is Nothing) OrElse Not (Me.TimeElapsed.IsRunning) Then
            Throw New Exception("TimeMeasurer is not running.")

        Else
            Me.MeasureTimer.Stop()
            Me.TimeElapsed.Stop()

        End If

    End Sub

    ''' <summary>
    ''' Resumes the time interval measurement.
    ''' </summary>
    Public Sub [Resume]()

        If (Me.MeasureTimer Is Nothing) OrElse (Me.TimeElapsed.IsRunning) Then
            Throw New Exception("TimeMeasurer is not stopped.")

        Else
            Me.MeasureTimer.Start()
            Me.TimeElapsed.Start()

        End If

    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Stops Time intervals and resets the elapsed and remaining time to zero.
    ''' </summary>
    Private Sub Reset()

        Me.MeasureTimer.Stop()
        Me.TimeElapsed.Reset()

    End Sub

#End Region

#Region " Event Handlers "

    ''' <summary>
    ''' Handles the Tick event of the MeasureTimer control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub MeasureTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MeasureTimer.Tick

        Dim TimeDifference As TimeSpan = (Me.TimeRemaining - Me.TimeElapsed.Elapsed)
        Dim ElapsedArgs As New TimeMeasureEventArgs
        Dim RemainingArgs As New TimeMeasureEventArgs

        If (TimeDifference.TotalMilliseconds <= 0.0R) _
        OrElse (Me.TimeElapsed.ElapsedMilliseconds > DirectCast(Me.MeasureTimer.Tag, Double)) Then

            Dim TotalTime As TimeSpan = TimeSpan.FromMilliseconds(DirectCast(Me.MeasureTimer.Tag, Double))

            With ElapsedArgs
                .Hour = TotalTime.Hours
                .Minute = TotalTime.Minutes
                .Second = TotalTime.Seconds
                .Millisecond = TotalTime.Milliseconds
            End With

            With RemainingArgs
                .Hour = 0.0R
                .Minute = 0.0R
                .Second = 0.0R
                .Millisecond = 0.0R
            End With

            Me.Reset()
            Me.IsFinished = True
            RaiseEvent ElapsedTimeFinished(Me.TimeElapsed, ElapsedArgs)
            RaiseEvent RemainingTimeFinished(TimeDifference, RemainingArgs)

        Else

            With ElapsedArgs
                .Hour = TimeElapsed.Elapsed.Hours
                .Minute = TimeElapsed.Elapsed.Minutes
                .Second = TimeElapsed.Elapsed.Seconds
                .Millisecond = TimeElapsed.Elapsed.Milliseconds
            End With

            With RemainingArgs
                .Hour = Math.Floor(TimeDifference.TotalHours) Mod TimeSpan.MaxValue.TotalMilliseconds
                .Minute = Math.Floor(TimeDifference.TotalMinutes) Mod 60.0R
                .Second = Math.Floor(TimeDifference.TotalSeconds) Mod 60.0R
                .Millisecond = Math.Floor(TimeDifference.TotalMilliseconds Mod 1000.0R)
            End With

            RaiseEvent ElapsedTimeUpdated(Me.TimeElapsed, ElapsedArgs)
            RaiseEvent RemainingTimeUpdated(TimeDifference, RemainingArgs)

        End If

    End Sub

#End Region

End Class