Imports System.Net
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel




Public Class MainForm

    Dim VMixError As Boolean = False
    Dim StartupTimer As Integer = 0
    Dim ShutDownTimer As Integer = 0
    Dim ComCheckTimer As Integer = 18
    Dim Addr As Integer
    Dim LiveAddr As Integer
    Dim CDir As Integer
    Dim SaveMode As Boolean
    Dim PresetLegendMode As Integer = 0
    Dim OverlayActive As Boolean
    Dim MediaOverlayActive As Boolean
    Dim CaptionIndex As Integer = 1
    Dim VmixResponse As String
    Dim VmixRecState As Boolean
    Dim VmixStreamState As Boolean
    Dim VmixRecTime As String
    Dim VmixStreamTime As String
    Dim VmixInit As Integer = 0
    Dim Gain(8) As Integer
    Dim WbLock(8) As Integer
    Dim DelayStop As Integer
    Dim DelayAddr As Integer
    Dim NextPreview As Integer
    Dim TransitionWait As Integer
    Dim PresetState(8) As Integer
    Dim CamIris(8) As Integer
    Dim CamAgc(8) As Integer
    Dim CamAEShift(8) As Integer
    Dim CamAGCLimit(8) As Integer
    Dim CamWBRed(8) As Integer
    Dim CamWBBlue(8) As Integer
    Dim CamFocusManual(8) As Integer
    Dim CamFocus(8) As Integer
    Dim ProgCloseTimer As Integer = 0
    Dim CamIgnore(8) As Boolean
    Dim PendingZoom As Integer = 0
    Dim PendingPan As Integer = 0
    Dim PendingTilt As Integer = 0
    Dim PzTimer As Integer
    Dim PzDir As Integer
    Dim PpDir As Integer
    Dim PtDir As Integer
    Dim PzAddr As Integer
    Dim PTZLive As Boolean = False
    Dim PresetLive As Boolean = False
    Dim CutLockoutTimer As Integer
    Dim CtrlKey As Boolean
    Dim CamOverride As Integer = 0
    Dim CamRec(4) As Boolean
    Dim CamRecStatusTimer As Integer = 0
    Dim CamCmdPending As Boolean = False
    Dim MediaItem As Integer
    Dim MediaPlayerWasActive As Boolean = False
    Dim MovePresetMode As Integer = 0
    Dim MovePresetFrom As Integer = 0
    Dim PresetLoadStart As Integer = 0
    Dim PresetLoadFileCount As Integer = 0
    Dim EncoderAllocation(2) As Integer
    Dim ScreenCount As Integer
    Dim StreamPending As Boolean = False
    Dim StreamPendingTime As Integer
    Dim MediaFiles(5) As String
    Dim MediaLoop(5) As Boolean
    Dim MediaMute(5) As Boolean
    Dim MediaMax As Integer = 5

    Dim TallyMode As Boolean
    Dim AutoSwap As Boolean
    Dim CamInvert(8) As Boolean
    Dim CamIP(8) As String
    Dim PresetFileName As String
    Dim PresetFilePath As String
    Dim CamStatus(8) As Boolean
    Dim Cam1Dis As Boolean
    Dim Cam2Dis As Boolean
    Dim Cam3Dis As Boolean
    Dim Cam4Dis As Boolean
    Dim Cam5Dis As Boolean

    Dim JoyX As Byte
    Dim JoyY As Byte
    Dim JoyZ As Byte
    Dim PrevJoyX As Byte
    Dim PrevJoyY As Byte
    Dim PrevJoyZ As Byte
    Dim Key(3) As Byte
    Dim REncode As Byte
    Dim EncoderA As Integer
    Dim EncoderB As Integer
    Dim JoystickActive As Boolean
    Dim PrevZoom As Byte
    Dim PrevEncode As Byte
    Dim PrevKey(3) As Byte
    Dim KeyHit As Boolean
    Dim EncChange As Boolean
    Dim LastKey As Byte
    Dim serialcount As Byte = 0
    Dim EncoderAReset As Integer
    Dim EncoderBReset As Integer
    Dim EncoderATime As Integer
    Dim EncoderBTime As Integer

    Dim SerialInBuf(32) As Byte
    Dim ControllerLedState(16) As Byte
    Dim SerialInBufPtr As Byte
    Dim ControlKeyState As Integer
    Dim PrevControlKeyState As Integer = 0
    Dim SerialTimeout As Integer = 0

    Dim PrevEncoderA As Integer
    Dim PrevEncoderB As Integer

    Dim prevmdir As Integer
    Dim prevxspeed As Integer
    Dim prevyspeed As Integer
    Dim joyconvert() As Byte = {1, 5, 8, 9, 10, 12, 13, 14, 15, 15, 16, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23, 23, 24, 24, 24, 25, 25, 25, 26, 26, 26, 27, 27, 27, 28, 28, 28, 29, 29, 29, 30, 30, 30, 31, 31, 31, 31, 32, 32, 32, 33, 33, 33, 34, 34, 34, 34, 34, 35, 35, 36, 36, 36, 36, 36, 37, 37, 37, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 41, 41, 41, 41, 42, 42, 42, 42, 43, 43, 43, 44, 44, 44, 44, 45, 45, 45, 45, 46, 46, 46, 46, 47, 47, 47, 47, 48, 48, 48, 48, 49, 49, 49, 49, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50}
    Dim zoomconvert() As Byte = {1, 7, 11, 14, 16, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 28, 29, 29, 30, 30, 31, 31, 32, 32, 33, 33, 34, 34, 34, 35, 35, 35, 36, 36, 36, 37, 37, 37, 37, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 41, 42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 43, 44, 44, 44, 44, 44, 44, 44, 45, 45, 45, 45, 45, 45, 45, 45, 46, 46, 46, 46, 46, 46, 46, 46, 46, 47, 47, 47, 47, 47, 47, 47, 47, 47, 48, 48, 48, 48, 48, 48, 48, 49, 49, 49, 49, 49, 49, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50}

    Dim alreadysending As Integer

    Dim PreloadPreset As Integer
    Dim LiveMoveSpeed As Integer = 0
    Dim ClipRemainTime As Integer

    'arrays to store preset positions
    Dim PresetCaption(128) As String
    Dim PresetXPos(64) As String
    Dim PresetYPos(64) As String
    Dim PresetZPos(64) As String
    Dim PresetContent(128) As Integer
    Dim PresetSize(128) As Integer
    Dim PresetAuto(128) As Integer
    Dim PresetFocusAuto(64) As Boolean
    Dim PresetFocus(64) As Integer
    Dim PresetIris(64) As Integer
    Dim PresetAE(64) As Integer


    Dim StreamStartTime, RecStartTime As Integer

    'this is the time in sec to move 1000 counts
    Dim PTTime() = {93.3, 62.5, 45.1, 34.1, 26.5, 21.3, 15.5, 10.7, 7.58, 5.5, 3.64, 2.86, 2.29, 1.79, 1.43}
    Dim ZTime() = {20.8, 20.7, 20.6, 20.5, 20.4, 17.5, 14.7, 11.7, 11.3, 10.9}


    Private Sub VSLog(ByVal pvMsg As String)
        If Len(mLog.Text) Then
            mLog.Text = mLog.Text & Chr(13) & Chr(10)
        End If
        mLog.Text = mLog.Text & Now & "   " & pvMsg
    End Sub


    '--------------------------------------------------------------------------------------------------------------
    ' Main form load / dispose
    '--------------------------------------------------------------------------------------------------------------
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer

        'hold down ctrl key on boot to skip camera connections 
        If My.Computer.Keyboard.CtrlKeyDown Then 'Or My.Computer.Keyboard.ShiftKeyDown Then
            ctrlkey = True
        Else
            ctrlkey = False
        End If

        'attempt to open app on the 1024x600 usb touch screen. If not found, open on the main screen as a sizeable window
        Dim scrfound = False
        ScreenCount = Screen.AllScreens.Count 'remember the screens setup in case we lose contact with the controller
        If ScreenCount > 1 Then
            For Each scr In Screen.AllScreens
                If scr.Bounds.Width = 1024 And scr.Bounds.Height = 600 Then Me.Bounds = scr.WorkingArea : scrfound = True
            Next
            'Me.Bounds = (From scr In Screen.AllScreens Where Not scr.Primary)(0).WorkingArea 'open on 2nd monitor
            'Windows.Forms.Cursor.Hide()
            Me.Cursor = Cursors.Cross
        End If
        If scrfound = False Then
            Me.Height = 600 : Me.Width = 1024 'size the same as it would be on the mini touch screen
            Me.FormBorderStyle = FormBorderStyle.Sizable 'if no 2nd monitor, open sizeable on main monitor
        End If

        gain(1) = 4 : gain(2) = 4 : gain(3) = 4 : gain(4) = 4
        wblock(1) = 0 : wblock(2) = 0 : wblock(3) = 0 : wblock(4) = 0
        addr = 2 : liveaddr = 1 : nextpreview = 2

        For i = 1 To 4 'these will be loaded from the camera settings eventually
            CamIris(i) = 0
            CamAgc(i) = 0
            CamAEShift(i) = 0
            CamAGCLimit(i) = 0
            CamWBRed(i) = 0
            CamWBBlue(i) = 20
            CamFocusManual(i) = 0
        Next i

        'For i = 0 To 128
        'joyconvert(i) = Int((Math.Log(i + 1) / (Math.Log(128))) * 50)
        'Debug.Print(joyconvert(i) & ",")
        'Next

        TallyMode = GetSetting("CCNCamControl", "Set", "Tally", False)
        AutoSwap = GetSetting("CCNCamControl", "Set", "Autoswap", True)
        PresetFilePath = GetSetting("CCNCamControl", "Set", "PresetsPath", Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\")))
        If PresetFilePath = "" Then PresetFilePath = Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\"))
        PresetFileName = GetSetting("CCNCamControl", "Set", "PresetsFile", "default.aps")
        If InStr(PresetFileName, "\") Then PresetFileName = Mid(PresetFileName, InStrRev(PresetFileName, "\") + 1)
        If PresetFileName = "" Then PresetFileName = "default.aps"
        CamInvert(1) = GetSetting("CCNCamControl", "Set", "Caminvert1", False)
        CamInvert(2) = GetSetting("CCNCamControl", "Set", "Caminvert2", False)
        CamInvert(3) = GetSetting("CCNCamControl", "Set", "Caminvert3", False)
        CamInvert(4) = GetSetting("CCNCamControl", "Set", "Caminvert4", False)

        Cam1Dis = GetSetting("CCNCamControl", "Set", "Cam1Dis", False)
        Cam2Dis = GetSetting("CCNCamControl", "Set", "Cam2Dis", False)
        Cam3Dis = GetSetting("CCNCamControl", "Set", "Cam3Dis", False)
        Cam4Dis = GetSetting("CCNCamControl", "Set", "Cam4Dis", False)
        Cam5Dis = GetSetting("CCNCamControl", "Set", "Cam5Dis", False)

        CamIP(1) = (GetSetting("CCNCamControl", "CamIP", "1", "192.168.1.91"))
        CamIP(2) = (GetSetting("CCNCamControl", "CamIP", "2", "192.168.1.92"))
        CamIP(3) = (GetSetting("CCNCamControl", "CamIP", "3", "192.168.1.93"))
        CamIP(4) = (GetSetting("CCNCamControl", "CamIP", "4", "192.168.1.94"))
        CamIP(5) = (GetSetting("CCNCamControl", "CamIP", "5", "192.168.1.95"))

        For i = 0 To MediaMax
            MediaFiles(i) = GetSetting("CCNCamControl", "MediaFiles", i, "")
            MediaLoop(i) = GetSetting("CCNCamControl", "MediaLoop", i, False)
            MediaMute(i) = GetSetting("CCNCamControl", "MediaMute", i, False)
        Next

        BtnFast.BackColor = Color.Green
        BtnLiveSlow.BackColor = Color.Green
        BtnAuxLock.BackColor = Color.Red
        SetDefaultPresets()
        'ReadPresetFile()
        ShowMode(1)
        EncoderAllocation(1) = 0 : EncoderAllocation(2) = 4
        ShowEncoderAllocations()
        SetCaptionText()
        LoadMediaList()

    End Sub

    Private Sub MainForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If SerialPort1.IsOpen Then SerialPort1.Close()
        'BackgroundWorker1.CancelAsync()
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    ' Select preset file to load (touch friendly)
    '--------------------------------------------------------------------------------------------------------------
    Sub SelectPresetFile()
        'Exit Sub
        Dim aryFi As IO.FileInfo()
        Try
            Dim di As New IO.DirectoryInfo(PresetFilePath)
            aryFi = di.GetFiles("*.aps")
        Catch
            MsgBox("Preset file error")
            Dim di As New IO.DirectoryInfo("C:\")
            aryFi = di.GetFiles("*.aps")
        End Try
        Dim fi As IO.FileInfo
        Dim btnct As Integer = 0


        PresetLoadPanel.Left = 50
        PresetLoadPanel.Height = SettingsPanel.Height - 100
        PresetLoadPanel.Width = SettingsPanel.Width - 100
        PresetLoadPanel.Top = 50
        PresetLoadClose.Left = PresetLoadPanel.Width - 25
        PresetLoadPanel.BringToFront()
        PresetLoadPanel.Visible = True

        Dim myFont As System.Drawing.Font
        myFont = New System.Drawing.Font("Arial", 14, FontStyle.Bold)

        PresetLoadFileCount = aryFi.Count

        For Each fi In aryFi
            'Console.WriteLine("File Name: {0}", fi.Name)
            'Console.WriteLine("File Full Name: {0}", fi.FullName)

            Dim new_Button As New Button
            new_Button.Name = "BtnPresetFile" + btnct.ToString()
            new_Button.Text = fi.Name
            new_Button.Width = 280
            new_Button.Height = 60
            new_Button.ForeColor = Color.Yellow
            new_Button.BackColor = Color.Gray
            new_Button.Font = myFont
            new_Button.Location = New Point(0, 1000) 'set initial position off screen so not visible
            AddHandler new_Button.Click, AddressOf PresetLoadHandler_Click
            PresetLoadPanel.Controls.Add(new_Button)
            btnct = btnct + 1
        Next

        If PresetLoadFileCount > 12 Then
            'make a next page button
            Dim new_Button As New Button
            new_Button.Name = "BtnPresetFileMore"
            new_Button.Text = "More >>"
            new_Button.Width = 120
            new_Button.Height = 60
            new_Button.ForeColor = Color.Yellow
            new_Button.BackColor = Color.Gray
            new_Button.Font = myFont
            AddHandler new_Button.Click, AddressOf PresetLoadHandler_Click
            PresetLoadPanel.Controls.Add(new_Button)
            new_Button.Location = New Point(520, 5 * 70 + 60)
        End If

        PresetLoadRedraw() 'arrange the buttons
    End Sub
    '-- draw the preset select buttons
    Sub PresetLoadRedraw()
        'only 12 will fit on a screen.
        If PresetLoadFileCount > 12 Then
            For i = 0 To PresetLoadFileCount - 1
                Dim btn As Button = Me.Controls.Find("BtnPresetFile" + i.ToString(), True)(0)
                btn.Location = New Point(40, 1000) 'put all offscreen
            Next

            Dim ct As Integer = PresetLoadFileCount - PresetLoadStart
            Dim pi As Integer
            If PresetLoadStart + 11 <= PresetLoadFileCount Then ct = 11
            For i = PresetLoadStart To PresetLoadStart + ct - 1
                Dim btn As Button = PresetLoadPanel.Controls.Find("BtnPresetFile" + i.ToString(), True)(0)
                pi = i - PresetLoadStart
                If pi < 6 Then
                    btn.Location = New Point(40, pi * 70 + 60)
                Else
                    btn.Location = New Point(360, (pi - 6) * 70 + 60)
                End If
            Next
        Else
            For i = 0 To PresetLoadFileCount - 1
                Dim btn As Button = PresetLoadPanel.Controls.Find("BtnPresetFile" + i.ToString(), True)(0)
                If i < 6 Then
                    btn.Location = New Point(40, i * 70 + 60)
                Else
                    btn.Location = New Point(360, (i - 6) * 70 + 60)
                End If
            Next
        End If
        PresetLoadPanel.Refresh()
    End Sub
    '-- close the preset select panel
    Private Sub PresetLoadClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PresetLoadClose.Click
        PresetLoadPanel.Visible = False
    End Sub
    '-- handle click of preset
    Sub PresetLoadHandler_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is Button Then
            Dim myButton As Button = CType(sender, Button)
            Dim pfname As String = myButton.Text
            If (pfname = "More >>") Then
                If (PresetLoadStart + 11 < PresetLoadFileCount) Then
                    PresetLoadStart = PresetLoadStart + 11
                Else
                    PresetLoadStart = 0
                End If
                PresetLoadRedraw()
            Else
                PresetFileName = pfname
                SaveSetting("CCNCamControl", "Set", "PresetsFile", PresetFileName)
                ReadPresetFile()

                For i = 0 To PresetLoadFileCount - 1
                    Dim btn As Button = Me.Controls.Find("BtnPresetFile" + i.ToString(), True)(0)
                    PresetLoadPanel.Controls.Remove(btn)
                Next
                PresetLoadPanel.Visible = False
            End If
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    ' My message box, open a touch friendly panel that is not modal
    '--------------------------------------------------------------------------------------------------------------
    Sub ShowMsgBox(ByVal label As String)
        MsgBoxPanel.Left = 20
        MsgBoxLabel.Text = MsgBoxLabel.Text & vbCrLf & label 'add new text to existing string, if open
        MsgBoxPanel.Height = MsgBoxLabel.Height + 50
        MsgBoxPanel.Width = MsgBoxLabel.Width + 50
        MsgBoxPanel.Top = Me.Height - 50 - MsgBoxPanel.Height
        MsgboxClose.Left = MsgBoxPanel.Width - 25
        MsgBoxPanel.BringToFront()
        MsgBoxPanel.Visible = True
        MsgBoxPanel.Refresh()
    End Sub
    '---close my message box
    Private Sub MsgboxClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MsgBoxPanel.Click, MsgboxClose.Click
        MsgBoxPanel.Visible = False
        MsgBoxLabel.Text = "" 'clear the text when closed/hidden
    End Sub

    '---Make VMix input name from address number
    Function VMixSourceName(ByVal oaddr As Integer) As String
        VMixSourceName = ""
        If oaddr = 1 Then VMixSourceName = "Cam1"
        If oaddr = 2 Then VMixSourceName = "Cam2"
        If oaddr = 3 Then VMixSourceName = "Cam3"
        If oaddr = 4 Then VMixSourceName = "Cam4"
        If oaddr = 5 Then VMixSourceName = "Cam5"
        If oaddr = 6 Then VMixSourceName = "Words"
        If oaddr = 7 Then VMixSourceName = "Mediaplayer1"
        If oaddr = 8 Then VMixSourceName = "Aux"
        If oaddr = 9 Then VMixSourceName = "Pip"
        If oaddr = 10 Then VMixSourceName = "Black"
        If oaddr = 21 Then VMixSourceName = "LeaderCaption"
        If oaddr = 22 Then VMixSourceName = "PreacherCaption"
        If oaddr = 23 Then VMixSourceName = "OtherCaption"

    End Function
    '--------------------------------------------------------------------------------------------------------------
    ' Internal network comms functions
    '--------------------------------------------------------------------------------------------------------------
    '---Getwebrequest, used to communicate with cameras and with vmix
    Private Function GetWebRequest(ByVal url As String)
        'Debug.Print(url)
        Dim request As WebRequest = WebRequest.Create(url)
        request.Timeout = 200  'timeout 200msec
        Dim resp As WebResponse = request.GetResponse()
        Dim T As String
        Using r As StreamReader = New StreamReader(resp.GetResponseStream(), Encoding.ASCII)
            T = r.ReadToEnd()
        End Using
        GetWebRequest = T
    End Function


    '---Send a vmix api command
    Private Function SendVmixCmd(ByVal cmd As String)
        Dim url As String, result As String
        url = "http://127.0.0.1:8088/api/" & cmd
        result = ""
        Try
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            If VMixError = False Then
                ShowMsgBox("VMix error")
                VMixError = True
            End If
        End Try
        If result <> "" Then VMixError = False
        Return result
    End Function

    '---Send a command to the current preview camera
    Private Function SendCamCmd(ByVal cmd As String)
        Dim url As String, result As String
        If Addr = 0 Or Addr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(Addr) = True Then Return ""
        url = "http://" & CamIP(Addr) & "/cgi-bin/aw_ptz?cmd=%23" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(Addr) = True
            ShowMsgBox("Error sending to camera " & Addr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    '---send a no-hash type command to a camera
    Private Function SendCamCmdNoHash(ByVal cmd As String, ByVal typ As String)
        Dim url As String, result As String
        If Addr = 0 Or Addr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(Addr) = True Then Return ""
        If (typ = "") Then typ = "aw_ptz" 'aw_ptz for position, aw_cam for cam settings
        url = "http://" & CamIP(Addr) & "/cgi-bin/" & typ & "?cmd=" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(Addr) = True
            ShowMsgBox("Error sending to camera " & Addr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    '---send a command to a particular camera
    Private Function SendCamCmdAddr(ByVal caddr As Integer, ByVal cmd As String)
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        url = "http://" & CamIP(caddr) & "/cgi-bin/aw_ptz?cmd=%23" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    '---send a no-hash type command to a particular camera 
    Private Function SendCamCmdAddrNoHash(ByVal caddr As Integer, ByVal cmd As String, ByVal typ As String)
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        If (typ = "") Then typ = "aw_ptz" 'aw_ptz for position, aw_cam for cam settings
        url = "http://" & CamIP(caddr) & "/cgi-bin/" & typ & "?cmd=" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    '---send a query request to a camera to get settings back (used for reading internal sd card status)
    Function SendCamQuery(ByVal caddr As Integer, ByVal cmd As String)
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        url = "http://" & CamIP(caddr) & "/cgi-bin/" & cmd
        result = ""
        Try
            'CamCmdPending = True
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    '---send a query request but don't bother with the response (used for internal card record commands)
    Public Sub SendCamQueryNoResponse(ByVal caddr As Integer, ByVal cmd As String)
        Dim webClient As New System.Net.WebClient
        Dim url As String
        url = "http://" & CamIP(caddr) & "/cgi-bin/" & cmd
        webClient.DownloadString(url)
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' Read camera states back from cameras
    '--------------------------------------------------------------------------------------------------------------
    Sub ReadbackCameraStates(ByVal ta As Integer)
        Dim op As String
        SendCamCmdAddrNoHash(ta, "XSF:1", "aw_cam") 'set scene file "MANUAL 1"
        op = SendCamCmdAddrNoHash(ta, "QSD:B1", "aw_cam") 'get WB setting
        CamWBBlue(ta) = Val("&H" & Mid(op, 8))
        op = SendCamCmdAddrNoHash(ta, "QGU", "aw_cam") 'get AGC setting
        CamAgc(ta) = (Val("&H" & Mid(op, 5)) - 8) / 3
        op = SendCamCmdAddrNoHash(ta, "QSD:69", "aw_cam") 'get AGC gain limit setting
        CamAGCLimit(ta) = Val("&H" & Mid(op, 8))
        op = SendCamCmdAddrNoHash(ta, "QSD:48", "aw_cam") 'get "contrast" setting
        CamAEShift(ta) = (Val(Mid(op, 8)) - 32) * 20 / 64
        op = SendCamCmdAddrNoHash(ta, "QRV", "aw_cam") 'get iris setting
        CamIris(ta) = Val("&H" & Mid(op, 5))
        op = SendCamCmdAddrNoHash(ta, "QRS", "aw_cam") 'get iris auto/man
        If Val("&H" & Mid(op, 5)) = 1 Then CamIris(ta) = 9999 'flag auto mode
        op = SendCamCmdAddr(ta, "D1") 'get focus auto/man
        If Val("&H" & Mid(op, 3)) = 1 Then CamFocusManual(ta) = 0 Else CamFocusManual(ta) = 1 'flag auto mode if return=1
        op = SendCamCmdAddr(ta, "GF")
        CamFocus(ta) = Val("&H" & Mid(op, 3))
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' Read user presets out of file into internal array store
    '--------------------------------------------------------------------------------------------------------------
    Sub ReadPresetFile()
        Dim TextFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser
        Try
            TextFileReader = My.Computer.FileSystem.OpenTextFieldParser(PresetFilePath & PresetFileName)
        Catch
            WritePresetFile()
            TextFileReader = My.Computer.FileSystem.OpenTextFieldParser(PresetFilePath & PresetFileName)
        End Try
        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim i As Integer
        Dim CurrentRow As String()
        Dim a As String

        i = 0
        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields() 'fields:0=name,1=x,2=y,3=z,4=Focus,5=Iris,6=AEshift
                If Not CurrentRow Is Nothing Then
                    If UBound(CurrentRow) >= 4 Then 'preset data
                        PresetCaption(i) = CurrentRow(0).ToString
                        PresetXPos(i) = CurrentRow(1).ToString
                        PresetYPos(i) = CurrentRow(2).ToString
                        PresetZPos(i) = CurrentRow(3).ToString
                        If UBound(CurrentRow) = 6 Then 'new format preset data
                            PresetFocus(i) = Convert.ToInt32(CurrentRow(4).ToString)
                            PresetIris(i) = Convert.ToInt32(CurrentRow(5).ToString)
                            PresetAE(i) = Convert.ToInt32(CurrentRow(4).ToString)
                        End If
                        If CurrentRow.GetUpperBound(0) > 3 Then 'check if we have these params or not
                            PresetContent(i) = Convert.ToInt32(CurrentRow(4).ToString)
                            PresetSize(i) = Convert.ToInt32(CurrentRow(5).ToString)
                            a = CurrentRow(6).ToString
                            If (a = "0" Or a = "False") Then PresetAuto(i) = False Else PresetAuto(i) = True
                            'PresetAuto(i) = Convert.ToBoolean(CurrentRow(6).ToString)
                        Else
                            PresetContent(i) = 0
                            PresetSize(i) = 0
                            PresetAuto(i) = False
                        End If
                        If CurrentRow.GetUpperBound(0) > 6 Then 'check if we have these params or not
                            PresetFocus(i) = Convert.ToInt32(CurrentRow(7).ToString)
                            a = CurrentRow(8).ToString
                            If (a = "0" Or a = "False") Then PresetFocusAuto(i) = False Else PresetFocusAuto(i) = True
                        Else
                            PresetFocus(i) = 0
                            PresetFocusAuto(i) = True
                        End If
                        i = i + 1
                    Else  'short row - other data
                        a = CurrentRow(0).ToString
                        If a = "Encoder" And UBound(CurrentRow) >= 2 Then
                            EncoderAllocation(1) = Convert.ToInt32(CurrentRow(1).ToString)
                            EncoderAllocation(2) = Convert.ToInt32(CurrentRow(2).ToString)
                            ShowEncoderAllocations()
                        End If
                        If a = "CamSettingStore" And UBound(CurrentRow) >= 3 Then
                            If (CurrentRow(1) = "True") Then CheckBoxSaveFocus.Checked = True Else CheckBoxSaveFocus.Checked = False
                            If (CurrentRow(2) = "True") Then CheckBoxSaveIris.Checked = True Else CheckBoxSaveIris.Checked = False
                            If (CurrentRow(3) = "True") Then CheckBoxSaveAE.Checked = True Else CheckBoxSaveAE.Checked = False
                        End If
                    End If

                End If
            Catch ex As _
            Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While
        TextFileReader.Dispose()
        'read preset names for cam5. these are stored in the registry as the presets are fixed in the camera
        For i = 0 To 15
            PresetCaption(16 * 6 + i) = GetSetting("CCNCamControl", "Preset5", i, i + 1)
        Next
        UpdatePresets()
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' Write user presets from internal array store to file
    '--------------------------------------------------------------------------------------------------------------
    Sub WritePresetFile()
        Dim file As System.IO.StreamWriter
        Dim i As Integer, j As Integer
        Dim ln As String
        Try
            file = My.Computer.FileSystem.OpenTextFileWriter(PresetFilePath & PresetFileName, False) 'false=no append
        Catch
            MsgBox("Could not write preset file " & PresetFilePath & PresetFileName)
            Return
        End Try

        For j = 0 To 3
            For i = 0 To 15
                ln = PresetCaption(i + j * 16) & "," & PresetXPos(i + j * 16) & "," & PresetYPos(i + j * 16) & "," & PresetZPos(i + j * 16)
                ln = ln & "," & PresetFocus(i + j * 16) & "," & PresetIris(i + j * 16) & "," & PresetAE(i + j * 16)
                'ln = ln & "," & PresetContent(i + j * 16) & "," & PresetSize(i + j * 16) & "," & PresetAuto(i + j * 16)
                'ln = ln & "," & PresetFocus(i + j * 16) & "," & PresetFocusAuto(i + j * 16)
                file.WriteLine(ln)
            Next i
        Next j

        'other settings
        ln = "Encoder" & "," & EncoderAllocation(1) & "," & EncoderAllocation(2)
        file.WriteLine(ln)

        ln = "CamSettingStore" & "," & CheckBoxSaveFocus.Checked & "," & CheckBoxSaveIris.Checked & "," & CheckBoxSaveAE.Checked
        file.WriteLine(ln)

        file.Close()


        'also save cam5 legends to registry
        For i = 0 To 15
            SaveSetting("CCNCamControl", "Preset5", i, PresetCaption(6 * 16 + i))
        Next
    End Sub

    '--- Set default preset caption ("1-16") and central positions
    Sub SetDefaultPresets()
        Dim i As Integer, j As Integer
        For j = 0 To 3
            For i = 0 To 15
                PresetCaption(i + j * 16) = i + 1
                PresetXPos(i + j * 16) = "8000"
                PresetYPos(i + j * 16) = "8000"
                PresetZPos(i + j * 16) = "555"
            Next i
        Next j
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' Open comm port for controller coms. This is a usb com port 
    '--------------------------------------------------------------------------------------------------------------
    Public Sub ComportOpen()
        'open com port for controller comms
        If SerialPort1.IsOpen Then SerialPort1.Close()
        SerialPort1.BaudRate = 19200
        SerialPort1.PortName = GetSetting("CCNCamControl", "Comm", "2", "COM2")
        Try
            SerialPort1.Open()
        Catch
            'TODO: if this fails then scan all the ports looking for the controller. If that fails then show status controller not connected
            'but retry the connect every 10sec
            ShowMsgBox("The controller com port " & SerialPort1.PortName & " cannot be opened.")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' Edit preset button captions directly on the buttons by moving a textbox around
    '--------------------------------------------------------------------------------------------------------------
    Sub StartEditPresetDetails(ByVal index As Integer)
        TextBoxPresetEdit.Text = PresetCaption((Addr - 1) * 16 + index - 1)
        TextBoxPresetEdit.Visible = True
        Dim btnx = ((index - 1) Mod 4)
        Dim btny = Int(((index - 1) / 4))
        TextBoxPresetEdit.Top = BtnPreset1.Top + BtnPreset1.Height * btny + 8
        TextBoxPresetEdit.Left = BtnPreset1.Left + BtnPreset1.Width * btnx + 8
        TextBoxPresetEdit.SelectAll()
        TextBoxPresetEdit.Focus()
    End Sub

    '---end preset caption edit
    Sub EndEditPresetDetails()
        If PresetLegendMode = 999 Then 'we were waiting for a preset button to be selected. Just exit edit mode
            BtnEditPreset.BackColor = Color.White
            PresetLegendMode = 0
            Exit Sub
        End If
        If TextBoxPresetEdit.Visible = False Then
            Exit Sub 'another action may have already run this routine
        End If
        If (PresetLegendMode <> 0) Then PresetCaption((Addr - 1) * 16 + PresetLegendMode - 1) = TextBoxPresetEdit.Text
        BtnEditPreset.BackColor = Color.White
        PresetLegendMode = 0
        TextBoxPresetEdit.Visible = False
        WritePresetFile()
        setactive()
    End Sub

    '---handle user clicking somewhere else while editing caption
    Private Sub TextBoxPresetEdit_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxPresetEdit.Leave
        EndEditPresetDetails() 'user clicks on another control
    End Sub
    Private Sub PresetPanel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PresetPanel.Click
        If PresetLegendMode <> 0 Then EndEditPresetDetails() 'user clicks on the panel
    End Sub
    Private Sub TextBoxPresetEdit_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBoxPresetEdit.KeyDown
        If e.KeyCode = Keys.Enter And e.Modifiers = 0 Then EndEditPresetDetails() 'user presses enter after typing
    End Sub


    '--------------------------------------------------------------------------------------------------------------
    ' Click on a preset button (may be recall, save, edit, move)
    '--------------------------------------------------------------------------------------------------------------
    Private Sub BtnPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreset1.Click, BtnPreset2.Click, BtnPreset3.Click, BtnPreset4.Click, BtnPreset5.Click, BtnPreset6.Click, BtnPreset7.Click, BtnPreset8.Click, BtnPreset9.Click, BtnPreset10.Click, BtnPreset11.Click, BtnPreset12.Click, BtnPreset13.Click, BtnPreset14.Click, BtnPreset15.Click, BtnPreset16.Click
        Dim op As String
        Dim cu As String
        Dim index As Integer
        Dim ad As Integer
        Dim cz As Integer, pz As Integer, cx As Integer, px As Integer, cy As Integer, py As Integer, tdiff1 As Integer, tdiff2 As Integer
        Dim zt As Integer
        Dim zsec
        Dim xt, yt
        Dim i As Integer
        index = Val(Mid(sender.name, 10))

        '---move a preset-----------------------------------------------------------------
        If MovePresetMode <> 0 Then 'we are moving a preset
            If MovePresetMode = 1 Then 'select preset to move
                MovePresetFrom = index
                MovePresetMode = 2
                CType(PresetPanel.Controls.Find("BtnPreset" & MovePresetFrom, False)(0), CCNCamcontrol.MyButton).BackColor = Color.Orange
                For i = 1 To 16
                    If i <> index Then CType(PresetPanel.Controls.Find("BtnPreset" & i, False)(0), CCNCamcontrol.MyButton).ForeColor = Color.Red
                Next
                Exit Sub
            End If
            If MovePresetMode = 2 Then 'select where its going
                If PresetLive = False Then ad = Addr Else ad = LiveAddr
                'swap caption
                Dim tmp
                tmp = PresetCaption((ad - 1) * 16 + (MovePresetFrom - 1)) : PresetCaption((ad - 1) * 16 + (MovePresetFrom - 1)) = PresetCaption((ad - 1) * 16 + (index - 1)) : PresetCaption((ad - 1) * 16 + (index - 1)) = tmp
                tmp = PresetContent((ad - 1) * 16 + MovePresetFrom - 1) : PresetContent((ad - 1) * 16 + MovePresetFrom - 1) = PresetContent((ad - 1) * 16 + index - 1) : PresetContent((ad - 1) * 16 + index - 1) = tmp
                tmp = PresetSize((ad - 1) * 16 + MovePresetFrom - 1) : PresetSize((ad - 1) * 16 + MovePresetFrom - 1) = PresetSize((ad - 1) * 16 + index - 1) : PresetSize((ad - 1) * 16 + index - 1) = tmp
                tmp = PresetAuto((ad - 1) * 16 + MovePresetFrom - 1) : PresetAuto((ad - 1) * 16 + MovePresetFrom - 1) = PresetAuto((ad - 1) * 16 + index - 1) : PresetAuto((ad - 1) * 16 + index - 1) = tmp
                'swap positions
                tmp = PresetZPos((ad - 1) * 16 + MovePresetFrom - 1) : PresetZPos((ad - 1) * 16 + MovePresetFrom - 1) = PresetZPos((ad - 1) * 16 + index - 1) : PresetZPos((ad - 1) * 16 + index - 1) = tmp
                tmp = PresetXPos((ad - 1) * 16 + MovePresetFrom - 1) : PresetXPos((ad - 1) * 16 + MovePresetFrom - 1) = PresetXPos((ad - 1) * 16 + index - 1) : PresetXPos((ad - 1) * 16 + index - 1) = tmp
                tmp = PresetYPos((ad - 1) * 16 + MovePresetFrom - 1) : PresetYPos((ad - 1) * 16 + MovePresetFrom - 1) = PresetYPos((ad - 1) * 16 + index - 1) : PresetYPos((ad - 1) * 16 + index - 1) = tmp
                tmp = PresetFocusAuto((ad - 1) * 16 + MovePresetFrom - 1) : PresetFocusAuto((ad - 1) * 16 + MovePresetFrom - 1) = PresetFocusAuto((ad - 1) * 16 + index - 1) : PresetFocusAuto((ad - 1) * 16 + index - 1) = tmp
                WritePresetFile()
                MovePresetMode = 0
                BtnMovePreset.ForeColor = Color.Black
                For i = 1 To 16
                    CType(PresetPanel.Controls.Find("BtnPreset" & i, False)(0), CCNCamcontrol.MyButton).ForeColor = Color.Black
                Next
                UpdatePresets()
                Exit Sub
            End If

        End If

        If SaveMode = False Then
            If PresetLegendMode = 0 Then
                '---recall a preset--------------------------------------
                If PreloadPreset = 0 Then
                    '---Recall a preset either live or preview
                    If (Addr = 5) Then
                        If index < 11 Then
                            SendCamCmd("R0" & index - 1) 'recall preset on camera for cam5
                            PresetState(Addr) = 2 ^ (index - 1)
                            UpdatePresets() 'show presets for new cam
                        End If
                    End If
                    If ((PresetLive = False) And (Addr < 5)) Or ((PresetLive = True) And (LiveAddr < 5)) Then 'recall preset
                        'SendCamCmd("UPVS250")
                        If (Addr = LiveAddr) Or PresetLive = True Then 'live preset recall. attempt to go there slowly
                            ad = LiveAddr
                            cu = SendCamCmdAddr(ad, "GZ") 'get current zoom pos
                            cz = Val("&H" & Mid(cu, 3)) 'the current zoom pos in decimal
                            pz = Val("&H" & PresetZPos((ad - 1) * 16 + index - 1)) 'the new zoom pos in decimal
                            'If cz < pz Then SendCamCmdAddr(ad, "Z51") Else SendCamCmdAddr(ad, "Z49")
                            If cz < pz Then PzDir = 1 Else PzDir = -1
                            zt = (cz - pz) '/ (&HFFF - &H555) 'calc zoom time using the time for full range zoom
                            If (zt < 0) Then zt = -zt
                            'zt = Int(zt * 50)
                            If zt = 0 And cz <> pz Then zt = 1
                            'If (zt > 20) Then zt = 20
                            If LiveMoveSpeed = 0 Then
                                zsec = ZTime(0) * zt / 1000 'slow - zoom speed 1
                                zt = 1
                            Else
                                zsec = ZTime(9) * zt / 1000 'fast - zoom speed 9
                                zt = 9
                            End If
                            If PzDir = -1 And zt <> 0 Then zt = 50 - zt Else zt = 50 + zt
                            SendCamCmdAddr(ad, "Z" & Format("00", zt))
                            PzAddr = ad
                            PendingZoom = pz 'the timer interrupt will end this when we get there

                            op = SendCamCmdAddr(ad, "APC") 'get current pt position
                            op = Mid(op, 4)
                            cx = Convert.ToInt32(Mid(op, 1, 4), 16)
                            px = Convert.ToInt32(PresetXPos((ad - 1) * 16 + index - 1), 16)
                            xt = (cx - px)  'distance for the pan movement
                            If xt < 0 Then xt = -xt
                            xt = xt / 1000
                            cy = Convert.ToInt32(Mid(op, 5, 4), 16)
                            py = Convert.ToInt32(PresetYPos((ad - 1) * 16 + index - 1), 16)
                            yt = (cy - py)   'distance for the tilt movement
                            If yt < 0 Then yt = -yt
                            yt = yt / 1000
                            mLog.Text = "x:" & cx - px & " xt:" & xt & " y:" & cy - py & " yt:" & yt & vbCrLf
                            mLog.Text = mLog.Text & "z:" & cz - pz & " zt:" & zsec & vbCrLf


                            'here we need to do a calc to see what is going to reach the end first
                            'probably speeding up the p/t so it ends with the zoom will be sufficient
                            'also check if the cam adjusts the p/t speeds so they both finish at the same time

                            'cu = "030" 'preset move speed - slow if on live as well
                            'cu = String.Format("{0:X2}", Int(30 * yt))
                            'cu = cu & "0"
                            'SendCamCmdAddr(ad, "APS" & PresetXPos((ad - 1) * 16 + index - 1) & PresetYPos((ad - 1) * 16 + index - 1) & cu) 'last 3 set speed 1D=max 0-1-2 = slow med fast
                            If cx < px Then PpDir = 1 Else PpDir = -1
                            If cy < py Then PtDir = 1 Else PtDir = -1
                            'xt = Int(xt * 200) : yt = Int(yt * 200)
                            If (zsec < 8) Then zsec = 8 'try different speeds till the move is just faster than the zoom move
                            For i = 0 To 14
                                If (PTTime(i) * xt) < zsec Then Exit For
                            Next
                            If i <> 0 Then 'check which is nearer, the one we chose or the previous one
                                tdiff1 = Math.Abs((PTTime(i) * xt) - zsec)
                                tdiff2 = Math.Abs((PTTime(i - 1) * xt) - zsec)
                                If tdiff2 < tdiff1 Then i = i - 1
                            End If
                            xt = i + 1
                            For i = 0 To 14
                                If (PTTime(i) * yt) < zsec Then Exit For
                            Next
                            If i <> 0 Then 'check which is nearer, the one we chose or the previous one
                                tdiff1 = Math.Abs((PTTime(i) * yt) - zsec)
                                tdiff2 = Math.Abs((PTTime(i - 1) * yt) - zsec)
                                If tdiff2 < tdiff1 Then i = i - 1
                            End If
                            yt = i + 1
                            'If xt > 15 Then xt = 15
                            'xt = 1
                            'If yt > 15 Then yt = 15
                            'yt = 5
                            If xt = 0 And cx <> px Then xt = 1
                            If yt = 0 And cy <> py Then yt = 1
                            If PpDir = 1 Then xt = 50 - xt Else xt = 50 + xt
                            If PtDir = 1 Then yt = 50 - yt Else yt = 50 + yt
                            mLog.Text = mLog.Text & "Speeds x:" & xt & " y:" & yt & " z:" & zt
                            SendCamCmdAddr(ad, "PTS" & Format("00", xt) & Format("00", yt))
                            If xt <> 0 Then PendingPan = px
                            If yt <> 0 Then PendingTilt = py
                            PresetState(ad) = 2 ^ (index - 1)
                            BtnLive.BackColor = Color.White : PresetLive = False
                        Else
                            cu = "101" 'preview cam move - move at fast speed (not max speed as that is quite noisy)
                            SendCamCmd("AXZ" & PresetZPos((Addr - 1) * 16 + index - 1))
                            SendCamCmd("APS" & PresetXPos((Addr - 1) * 16 + index - 1) & PresetYPos((Addr - 1) * 16 + index - 1) & cu) 'last 3 set speed 1D=max 0-1-2 = slow med fast
                            PresetState(Addr) = 2 ^ (index - 1)
                        End If
                        UpdatePresets() 'show presets for new cam

                    End If
                Else 'preload preset mode
                    If (Addr <= 4) Then
                        'If (PreloadPreset <> 0) Then
                        PreloadPreset = index
                        UpdatePresets()
                        CDir = 0
                        SetLiveMoveIndicators()
                        'End If
                    End If
                End If
            Else 'edit preset details
                cu = "0"
                PresetLegendMode = index
                StartEditPresetDetails(index)
            End If
        Else
            'save current preset position
            If (Addr <= 4) Then
                op = SendCamCmd("GZ") 'get current zoom position
                op = Mid(op, 3)
                PresetZPos((Addr - 1) * 16 + index - 1) = op
                op = SendCamCmd("APC") 'get current pt position
                op = Mid(op, 4)
                PresetXPos((Addr - 1) * 16 + index - 1) = Mid(op, 1, 4)
                PresetYPos((Addr - 1) * 16 + index - 1) = Mid(op, 5, 4)
                op = SendCamCmd("D1") 'get current autofocus state
                op = Mid(op, 3)
                If (op = "0") Then
                    op = SendCamCmd("GF") 'get current focus position
                    op = Mid(op, 3)
                    PresetFocus((Addr - 1) * 16 + index - 1) = op
                Else
                    PresetFocus((Addr - 1) * 16 + index - 1) = 9999
                End If
                op = SendCamCmdAddrNoHash(Addr, "QSD:48", "aw_cam") 'get "contrast" setting
                PresetAE((Addr - 1) * 16 + index - 1) = (Val(Mid(op, 8)) - 32) * 20 / 64
                op = SendCamCmdAddrNoHash(Addr, "QRV", "aw_cam") 'get iris setting
                PresetIris((Addr - 1) * 16 + index - 1) = Val("&H" & Mid(op, 5))

                If PresetCaption((Addr - 1) * 16 + index - 1) = Convert.ToString(index) Then 'automatically ask for legend if the legend is just the initial number
                    PresetLegendMode = index
                    StartEditPresetDetails(index)
                End If
                PresetState(Addr) = 2 ^ (index - 1)
                setactive()
            ElseIf Addr = 5 Then
                If index < 11 Then
                    SendCamCmd("M0" & index - 1) 'store preset on camera for cam5
                    If PresetCaption((Addr - 1) * 16 + index - 1) = Convert.ToString(index) Then 'automatically ask for legend if the legend is just the initial number
                        StartEditPresetDetails(index)
                    End If
                    PresetState(Addr) = 2 ^ (index - 1)
                    setactive()
                End If
            End If
            SaveMode = 0
            WritePresetFile()
            BtnPresetSave.BackColor = Color.White

        End If
    End Sub

    '---Update the camera settings values on the cam details screen
    Sub ShowCamValues()
        Dim ad As Integer
        If (PTZLive = False) Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If CamIris(ad) <> 9999 Then TextBoxIris.Text = CamIris(ad) Else TextBoxIris.Text = "Auto"
        If (CamAgc(ad) <= &H38) Then TextBoxAgc.Text = CamAgc(ad) * 3 & "dB" Else TextBoxAgc.Text = "Auto"
        TextBoxAeShift.Text = CamAEShift(ad)
        TextBoxAgcLimit.Text = CamAGCLimit(ad) * 6 & "dB"
        TextBox8.Text = CamWBRed(ad)
        TextBoxWB.Text = 2400 + CamWBBlue(ad) * 100

        If CamFocusManual(ad) = 0 Then
            BtnFocusAuto.BackColor = Color.Red : BtnFocusLock.BackColor = Color.White
            TextBoxFocus.Text = "Auto"
        Else
            BtnFocusAuto.BackColor = Color.White : BtnFocusLock.BackColor = Color.Red
            TextBoxFocus.Text = CamFocus(ad)
        End If
        EncoderAReset = 1 : EncoderBReset = 1
        PrevEncoderA = 0
        PrevEncoderB = 0
        ShowEncoderValues()
    End Sub
    '-----------------------------------------------------
    ' Set Leds on input controller buttons to preview / program state
    ' ControllerLedState(0..13) sets colour bit0=red bit1=green bit2=blue
    '-----------------------------------------------------
    Sub SetControllerLedState(ByVal op)
        ControllerLedState(op - 1) = 0
        If Addr = op Then ControllerLedState(op - 1) = ControllerLedState(op - 1) + 2 'green
        If LiveAddr = op Then ControllerLedState(op - 1) = ControllerLedState(op - 1) + 1 'red
    End Sub

    '-----------------------------------------------------
    ' Set active outputs and update button colours
    '-----------------------------------------------------
    Sub setactive()

        BtnCam1.BackColor = Color.White
        BtnCam2.BackColor = Color.White
        BtnCam3.BackColor = Color.White
        BtnCam4.BackColor = Color.White
        BtnCam5.BackColor = Color.White
        BtnInp1.BackColor = Color.White
        BtnInp2.BackColor = Color.White
        BtnInp3.BackColor = Color.White
        BtnInp4.BackColor = Color.White
        BtnInp5.BackColor = Color.White
        If Addr = LiveAddr Then
            If Addr = 1 Then BtnCam1.BackColor = Color.Yellow
            If Addr = 2 Then BtnCam2.BackColor = Color.Yellow
            If Addr = 3 Then BtnCam3.BackColor = Color.Yellow
            If Addr = 4 Then BtnCam4.BackColor = Color.Yellow
            If Addr = 5 Then BtnCam5.BackColor = Color.Yellow
            If Addr = 6 Then BtnInp1.BackColor = Color.Yellow
            If Addr = 7 Then BtnInp2.BackColor = Color.Yellow
            If Addr = 8 Then BtnInp3.BackColor = Color.Yellow
            If Addr = 9 Then BtnInp4.BackColor = Color.Yellow
            If Addr = 10 Then BtnInp5.BackColor = Color.Yellow
        Else
            If Addr = 1 Then BtnCam1.BackColor = Color.Green
            If Addr = 2 Then BtnCam2.BackColor = Color.Green
            If Addr = 3 Then BtnCam3.BackColor = Color.Green
            If Addr = 4 Then BtnCam4.BackColor = Color.Green
            If Addr = 5 Then BtnCam5.BackColor = Color.Green
            If Addr = 6 Then BtnInp1.BackColor = Color.Green
            If Addr = 7 Then BtnInp2.BackColor = Color.Green
            If Addr = 8 Then BtnInp3.BackColor = Color.Green
            If Addr = 9 Then BtnInp4.BackColor = Color.Green
            If Addr = 10 Then BtnInp5.BackColor = Color.Green
            If LiveAddr = 1 Then BtnCam1.BackColor = Color.Red
            If LiveAddr = 2 Then BtnCam2.BackColor = Color.Red
            If LiveAddr = 3 Then BtnCam3.BackColor = Color.Red
            If LiveAddr = 4 Then BtnCam4.BackColor = Color.Red
            If LiveAddr = 5 Then BtnCam5.BackColor = Color.Red
            If LiveAddr = 6 Then BtnInp1.BackColor = Color.Red
            If LiveAddr = 7 Then BtnInp2.BackColor = Color.Red
            If LiveAddr = 8 Then BtnInp3.BackColor = Color.Red
            If LiveAddr = 9 Then BtnInp4.BackColor = Color.Red
            If LiveAddr = 10 Then BtnInp5.BackColor = Color.Red
        End If
        'controller button LEDs
        For i = 1 To 10
            SetControllerLedState(i)
        Next
        'tally lights on cams
        If TallyMode Then
            SendCamCmdAddr(NextPreview, "DA0")
            SendCamCmdAddr(LiveAddr, "DA1")
        End If
        If TransitionWait = 0 Then
            If Addr <= 5 Then SendVmixCmd("?Function=PreviewInput&Input=" & VMixSourceName(Addr))
        End If

        'cam settings
        If (Addr <= 5) Then
            ShowCamValues()
            'load preset button captions
            UpdatePresets()
        End If

        'turn off live control
        BtnLivePTZ.BackColor = Color.White
        PTZLive = False


    End Sub

    '---Update legends and lit states of preset buttons to show presets for current preview cam
    Sub UpdatePresets()
        Dim ad As Integer

        If PresetLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then 'for non-cam inputs just show 1-16 legends
            BtnPreset1.Text = "1" : BtnPreset1.BackColor = Color.White
            BtnPreset2.Text = "2" : BtnPreset2.BackColor = Color.White
            BtnPreset3.Text = "3" : BtnPreset3.BackColor = Color.White
            BtnPreset4.Text = "4" : BtnPreset4.BackColor = Color.White
            BtnPreset5.Text = "5" : BtnPreset5.BackColor = Color.White
            BtnPreset6.Text = "6" : BtnPreset6.BackColor = Color.White
            BtnPreset7.Text = "7" : BtnPreset7.BackColor = Color.White
            BtnPreset8.Text = "8" : BtnPreset8.BackColor = Color.White
            BtnPreset9.Text = "9" : BtnPreset9.BackColor = Color.White
            BtnPreset10.Text = "10" : BtnPreset10.BackColor = Color.White
            BtnPreset11.Text = "11" : BtnPreset11.BackColor = Color.White
            BtnPreset12.Text = "12" : BtnPreset12.BackColor = Color.White
            BtnPreset13.Text = "13" : BtnPreset13.BackColor = Color.White
            BtnPreset14.Text = "14" : BtnPreset14.BackColor = Color.White
            BtnPreset15.Text = "15" : BtnPreset15.BackColor = Color.White
            BtnPreset16.Text = "16" : BtnPreset16.BackColor = Color.White
            Exit Sub
        End If

        BtnPreset1.Text = PresetCaption((ad - 1) * 16 + 0) : BtnPreset1.BackColor = Color.White
        BtnPreset2.Text = PresetCaption((ad - 1) * 16 + 1) : BtnPreset2.BackColor = Color.White
        BtnPreset3.Text = PresetCaption((ad - 1) * 16 + 2) : BtnPreset3.BackColor = Color.White
        BtnPreset4.Text = PresetCaption((ad - 1) * 16 + 3) : BtnPreset4.BackColor = Color.White
        BtnPreset5.Text = PresetCaption((ad - 1) * 16 + 4) : BtnPreset5.BackColor = Color.White
        BtnPreset6.Text = PresetCaption((ad - 1) * 16 + 5) : BtnPreset6.BackColor = Color.White
        BtnPreset7.Text = PresetCaption((ad - 1) * 16 + 6) : BtnPreset7.BackColor = Color.White
        BtnPreset8.Text = PresetCaption((ad - 1) * 16 + 7) : BtnPreset8.BackColor = Color.White
        BtnPreset9.Text = PresetCaption((ad - 1) * 16 + 8) : BtnPreset9.BackColor = Color.White
        BtnPreset10.Text = PresetCaption((ad - 1) * 16 + 9) : BtnPreset10.BackColor = Color.White
        If Addr <> 5 Then
            BtnPreset11.Text = PresetCaption((ad - 1) * 16 + 10) : BtnPreset11.BackColor = Color.White
            BtnPreset12.Text = PresetCaption((ad - 1) * 16 + 11) : BtnPreset12.BackColor = Color.White
            BtnPreset13.Text = PresetCaption((ad - 1) * 16 + 12) : BtnPreset13.BackColor = Color.White
            BtnPreset14.Text = PresetCaption((ad - 1) * 16 + 13) : BtnPreset14.BackColor = Color.White
            BtnPreset15.Text = PresetCaption((ad - 1) * 16 + 14) : BtnPreset15.BackColor = Color.White
            BtnPreset16.Text = PresetCaption((ad - 1) * 16 + 15) : BtnPreset16.BackColor = Color.White
        Else 'these presets not available on he2
            BtnPreset11.Text = "" : BtnPreset11.BackColor = Color.White
            BtnPreset12.Text = "" : BtnPreset12.BackColor = Color.White
            BtnPreset13.Text = "" : BtnPreset13.BackColor = Color.White
            BtnPreset14.Text = "" : BtnPreset14.BackColor = Color.White
            BtnPreset15.Text = "" : BtnPreset15.BackColor = Color.White
            BtnPreset16.Text = "" : BtnPreset16.BackColor = Color.White
        End If


        If ad <= 5 Then
            If (PresetState(ad) And 1) <> 0 Then BtnPreset1.BackColor = Color.Green
            If (PresetState(ad) And 2) <> 0 Then BtnPreset2.BackColor = Color.Green
            If (PresetState(ad) And 4) <> 0 Then BtnPreset3.BackColor = Color.Green
            If (PresetState(ad) And 8) <> 0 Then BtnPreset4.BackColor = Color.Green
            If (PresetState(ad) And 16) <> 0 Then BtnPreset5.BackColor = Color.Green
            If (PresetState(ad) And 32) <> 0 Then BtnPreset6.BackColor = Color.Green
            If (PresetState(ad) And 64) <> 0 Then BtnPreset7.BackColor = Color.Green
            If (PresetState(ad) And 128) <> 0 Then BtnPreset8.BackColor = Color.Green
            If (PresetState(ad) And &H100) <> 0 Then BtnPreset9.BackColor = Color.Green
            If (PresetState(ad) And &H200) <> 0 Then BtnPreset10.BackColor = Color.Green
            If (PresetState(ad) And &H400) <> 0 Then BtnPreset11.BackColor = Color.Green
            If (PresetState(ad) And &H800) <> 0 Then BtnPreset12.BackColor = Color.Green
            If (PresetState(ad) And &H1000) <> 0 Then BtnPreset13.BackColor = Color.Green
            If (PresetState(ad) And &H2000) <> 0 Then BtnPreset14.BackColor = Color.Green
            If (PresetState(ad) And &H4000) <> 0 Then BtnPreset15.BackColor = Color.Green
            If (PresetState(ad) And &H8000) <> 0 Then BtnPreset16.BackColor = Color.Green
        End If

        If PreloadPreset > 0 And PreloadPreset < 99 And PresetLive = False Then
            If PreloadPreset = 1 Then BtnPreset1.BackColor = Color.Orange
            If PreloadPreset = 2 Then BtnPreset2.BackColor = Color.Orange
            If PreloadPreset = 3 Then BtnPreset3.BackColor = Color.Orange
            If PreloadPreset = 4 Then BtnPreset4.BackColor = Color.Orange
            If PreloadPreset = 5 Then BtnPreset5.BackColor = Color.Orange
            If PreloadPreset = 6 Then BtnPreset6.BackColor = Color.Orange
            If PreloadPreset = 7 Then BtnPreset7.BackColor = Color.Orange
            If PreloadPreset = 8 Then BtnPreset8.BackColor = Color.Orange
            If PreloadPreset = 9 Then BtnPreset9.BackColor = Color.Orange
            If PreloadPreset = 10 Then BtnPreset10.BackColor = Color.Orange
            If PreloadPreset = 11 Then BtnPreset11.BackColor = Color.Orange
            If PreloadPreset = 12 Then BtnPreset12.BackColor = Color.Orange
            If PreloadPreset = 13 Then BtnPreset13.BackColor = Color.Orange
            If PreloadPreset = 14 Then BtnPreset14.BackColor = Color.Orange
            If PreloadPreset = 15 Then BtnPreset15.BackColor = Color.Orange
            If PreloadPreset = 16 Then BtnPreset16.BackColor = Color.Orange
        End If

    End Sub

    '---Handle click on one of the cam1-5 buttons. These touchbuttons aren't used but we call this function when the controller buttons are pressed
    Private Sub BtnCam1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCam1.Click, BtnCam2.Click, BtnCam3.Click, BtnCam4.Click, BtnCam5.Click
        Dim index As Integer
        index = Val(Mid(sender.name, 7))

        'cancel any preloads
        PreloadPreset = 0
        CDir = 0
        SetLiveMoveIndicators()
        UpdatePresets()

        Addr = index
        BtnLive.BackColor = Color.White : PresetLive = False
        BtnLivePTZ.BackColor = Color.White : PTZLive = False
        setactive()

    End Sub

    Private Sub HandleTransitionAudio()
        If Addr = 7 And MediaMute(MediaItem) Then 'if cutting to mediaplayer and the clip is to replace main audio
            SendVmixCmd("?Function=SetVolumeFade&Input=Mix%20Audio%20Input&Value=0,1000") 'fade main audio
        End If
        If Addr = 10 Then 'if cutting to black, fade out main audio
            SendVmixCmd("?Function=SetVolumeFade&Input=Mix%20Audio%20Input&Value=0,1000") 'fade main audio
        End If
        If LiveAddr = 7 Then 'cutting away from mediaplayer
            MediaPlayerWasActive = True 'set this flag which will move mediaplayer onto next item after a delay
            If MediaMute(MediaItem) Then SendVmixCmd("?Function=SetVolumeFade&Input=Mix%20Audio%20Input&Value=100,1000") 'if we muted main audio, restore it
        End If
        If LiveAddr = 10 Then 'if cutting away from black, restore main audio
            SendVmixCmd("?Function=SetVolumeFade&Input=Mix%20Audio%20Input&Value=100,1000") 'fade main audio
        End If
    End Sub

    '---Click the cut button. This function is called when the controller cut button is pressed
    Private Sub BtnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCut.Click
        If CutLockoutTimer > 0 Then Exit Sub
        HandleTransitionAudio()

        NextPreview = LiveAddr
        'If addr <> nextpreview Then addr = nextpreview
        LiveAddr = Addr
        StartLiveMove()
        SendVmixCmd("?Function=Fade&Duration=10") '10ms fade =cut

        'If AutoSwap Then addr = nextpreview
        If AutoSwap Then TransitionWait = 5

        setactive()
        CutLockoutTimer = 8
        DelayStop = 8

    End Sub

    '---click the fade button. This function is called when the controller fade button is pressed
    Private Sub BtnTransition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransition.Click
        If CutLockoutTimer > 0 Then Exit Sub

        HandleTransitionAudio()

        NextPreview = LiveAddr
        LiveAddr = Addr
        StartLiveMove()
        Dim ft As Double
        Double.TryParse(TextBox1.Text, ft) 'fade time textbox
        If (ft <> 0) Then ft = ft * 1000 : Else ft = 500
        SendVmixCmd("?Function=Fade&Duration=" & ft)
        If AutoSwap Then TransitionWait = 5 + Val(TextBox1.Text) * 10

        setactive()
        CutLockoutTimer = TransitionWait
        DelayStop = TransitionWait
    End Sub

    '---Click the preset save button
    Private Sub BtnPresetSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPresetSave.Click
        If SaveMode = False Then
            BtnPresetSave.BackColor = Color.Red
            SaveMode = True
        Else
            BtnPresetSave.BackColor = Color.White
            SaveMode = False
        End If
    End Sub

    '---Click the preset move button
    Private Sub BtnMovePreset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMovePreset.Click
        If (MovePresetMode = 0) Then
            MovePresetMode = 1
            BtnMovePreset.BackColor = Color.Red
        Else
            MovePresetMode = 0
            BtnMovePreset.BackColor = Color.White
        End If
    End Sub

    '---Click the preset edit button
    Private Sub BtnEditPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditPreset.Click
        If PresetLegendMode = 0 Then
            BtnEditPreset.BackColor = Color.Red
            PresetLegendMode = 999
        Else
            EndEditPresetDetails()
        End If
    End Sub


    '---Click the all stop button
    Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop.Click
        SendCamCmdAddr(1, "PTS5050")
        SendCamCmdAddr(1, "Z50")
        SendCamCmdAddr(2, "PTS5050")
        SendCamCmdAddr(2, "Z50")
        SendCamCmdAddr(3, "PTS5050")
        SendCamCmdAddr(3, "Z50")
        SendCamCmdAddr(4, "PTS5050")
        SendCamCmdAddr(4, "Z50")
        PendingZoom = 0 : PendingPan = 0 : PendingTilt = 0
    End Sub

    '---Click the preset slow zoom in button
    Private Sub BtnSlowIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlowIn.Click
        If PresetLive = False Then
            CDir = CDir Xor &H20
            If (CDir And &H20) Then CDir = CDir And Not &H40 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If CDir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(LiveAddr, "Z51")
            Else
                SendCamCmdAddr(LiveAddr, "Z60")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If

    End Sub

    '---Click the preset slow zoom out button
    Private Sub BtnSlowOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlowOut.Click
        If PresetLive = False Then
            CDir = CDir Xor &H40
            If (CDir And &H40) Then CDir = CDir And Not &H20 'cancel zoom in if zoom out set
            SetLiveMoveIndicators()
            If CDir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(LiveAddr, "Z49")
            Else
                SendCamCmdAddr(LiveAddr, "Z40")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub

    '---Click the slow pan left button
    Private Sub BtnSlowPanL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSlowPanL.Click
        If PresetLive = False Then
            CDir = CDir Xor &H2
            If (CDir And &H2) Then CDir = CDir And Not &H4 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If CDir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(LiveAddr, "PTS4800")
            Else
                SendCamCmdAddr(LiveAddr, "PTS4500")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub

    '---Click the slow pan right button
    Private Sub BtnSlowPanR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSlowPanR.Click
        If PresetLive = False Then
            CDir = CDir Xor &H4
            If (CDir And &H4) Then CDir = CDir And Not &H2 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If CDir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(LiveAddr, "PTS5200")
            Else
                SendCamCmdAddr(LiveAddr, "PTS5500")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub

    '---Click on one of the non-cam input buttons. We call this function when a controller button is clicked
    Private Sub BtnInp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInp1.Click, BtnInp2.Click, BtnInp3.Click, BtnInp4.Click, BtnInp5.Click
        Dim index = Val(Mid(sender.name, 7))
        Addr = index + 5
        SendVmixCmd("?Function=PreviewInput&Input=" & VMixSourceName(Addr))
        setactive()
    End Sub

    '---"light up" the buttons to show live moves or zooms
    Sub SetLiveMoveIndicators()
        If CDir And &H2 Then BtnSlowPanL.BackColor = Color.Orange Else BtnSlowPanL.BackColor = Color.White
        If CDir And &H4 Then BtnSlowPanR.BackColor = Color.Orange Else BtnSlowPanR.BackColor = Color.White
        If CDir And &H20 Then BtnSlowIn.BackColor = Color.Orange Else BtnSlowIn.BackColor = Color.White
        If CDir And &H40 Then BtnSlowOut.BackColor = Color.Orange Else BtnSlowOut.BackColor = Color.White
        If CDir = 0 And PreloadPreset = 0 Then BtnPreload.BackColor = Color.White
    End Sub

    '---Start a live move as configured on the preset buttons
    Sub StartLiveMove()
        Dim ps As String, ts As String
        Dim ncdir As Integer = 0
        If PreloadPreset <> 0 And PreloadPreset < 99 Then
            ts = PreloadPreset
            PreloadPreset = 0
            If ts = 1 Then BtnPreset_Click(BtnPreset1, Nothing)
            If ts = 2 Then BtnPreset_Click(BtnPreset2, Nothing)
            If ts = 3 Then BtnPreset_Click(BtnPreset3, Nothing)
            If ts = 4 Then BtnPreset_Click(BtnPreset4, Nothing)
            If ts = 5 Then BtnPreset_Click(BtnPreset5, Nothing)
            If ts = 6 Then BtnPreset_Click(BtnPreset6, Nothing)
            If ts = 7 Then BtnPreset_Click(BtnPreset7, Nothing)
            If ts = 8 Then BtnPreset_Click(BtnPreset8, Nothing)
            If ts = 9 Then BtnPreset_Click(BtnPreset9, Nothing)
            If ts = 10 Then BtnPreset_Click(BtnPreset10, Nothing)
            If ts = 11 Then BtnPreset_Click(BtnPreset11, Nothing)
            If ts = 12 Then BtnPreset_Click(BtnPreset12, Nothing)
            If ts = 13 Then BtnPreset_Click(BtnPreset13, Nothing)
            If ts = 14 Then BtnPreset_Click(BtnPreset14, Nothing)
            If ts = 15 Then BtnPreset_Click(BtnPreset15, Nothing)
            If ts = 16 Then BtnPreset_Click(BtnPreset16, Nothing)
            BtnPreload.BackColor = Color.White
            Exit Sub
        End If
        If CDir = 0 Then Exit Sub
        'set slow zoom speed
        'If (cdir And &H1E) <> 0 Then
        'If cdir And &H20 Then SendCamCmd("Z60")
        'If cdir And &H40 Then SendCamCmd("Z40")
        'Else
        If LiveMoveSpeed = 0 Then
            If CDir And &H20 Then SendCamCmd("Z51")
            If CDir And &H40 Then SendCamCmd("Z49")
        Else
            If CDir And &H20 Then SendCamCmd("Z60")
            If CDir And &H40 Then SendCamCmd("Z40")
        End If
        'End If

        'output the direction command
        If CamInvert(Addr) Then  'inverted camera
            If (CDir And 2) <> 0 Then ncdir = ncdir Or 4
            If (CDir And 4) <> 0 Then ncdir = ncdir Or 2
            If (CDir And 8) <> 0 Then ncdir = ncdir Or 16
            If (CDir And 16) <> 0 Then ncdir = ncdir Or 8
            CDir = ncdir
        End If
        ps = "50" : ts = "50"
        If (CDir And 2) <> 0 Then ps = "55"
        If (CDir And 4) <> 0 Then ps = "45"
        If (CDir And 8) <> 0 Then ts = "55"
        If (CDir And 16) <> 0 Then ts = "45"
        SendCamCmd("PTS" & ps & ts)

        CDir = 0
        SetLiveMoveIndicators()
        BtnPreload.BackColor = Color.White : PreloadPreset = 0

    End Sub

    '---Click the words overlay button. We call this when the controller button is pressed
    Private Sub BtnOverlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOverlay.Click
        If OverlayActive = False Then
            OverlayActive = True
            SendVmixCmd("?Function=OverlayInput1In&Input=OpenLP")
        Else
            OverlayActive = False
            SendVmixCmd("?Function=OverlayInput1Out&Input=OpenLP")
        End If
        If (OverlayActive = True) Then BtnOverlay.BackColor = Color.Red Else BtnOverlay.BackColor = Color.White
        If (OverlayActive = True) Then ControllerLedState(10) = 1 Else ControllerLedState(10) = 0
    End Sub

    '---Click the caption overlay button. We call this function when the controller button is pressed
    Private Sub BtnMediaOverlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMediaOverlay.Click

        If MediaOverlayActive = False Then
            'media overlay was not previously active
            SendVmixCmd("?Function=OverlayInput2In&Input=" & VMixSourceName(CaptionIndex + 20))
            MediaOverlayActive = True
        Else
            SendVmixCmd("?Function=OverlayInput2Out&Input=" & VMixSourceName(CaptionIndex + 20))
            MediaOverlayActive = False
        End If
        If (MediaOverlayActive = True) Then BtnMediaOverlay.BackColor = Color.Red Else BtnMediaOverlay.BackColor = Color.White
        If (MediaOverlayActive = True) Then ControllerLedState(11) = 1 Else ControllerLedState(11) = 0
    End Sub

    '---show a selection rectangle around the currently selected caption
    Sub CapRectangle(ByVal tb As Object)
        Dim l = tb.Left - 2 : Dim r = tb.Left + tb.Width + 2
        Dim t = tb.Top - 2 : Dim b = tb.Top + tb.Height + 2
        LineShapeCapL.X1 = l : LineShapeCapL.X2 = l : LineShapeCapT.X1 = l : LineShapeCapB.X1 = l
        LineShapeCapR.X1 = r : LineShapeCapR.X2 = r : LineShapeCapT.X2 = r : LineShapeCapB.X2 = r
        LineShapeCapL.Y1 = t : LineShapeCapR.Y1 = t : LineShapeCapT.Y1 = t : LineShapeCapT.Y2 = t
        LineShapeCapL.Y2 = b : LineShapeCapR.Y2 = b : LineShapeCapB.Y1 = b : LineShapeCapB.Y2 = b
    End Sub

    '---send the captions to vmix
    Private Sub SetCaptionText()
        If CaptionIndex = 1 Then CapRectangle(TextLeaderName)
        If CaptionIndex = 2 Then CapRectangle(TextPreacherName)
        If CaptionIndex = 3 Then CapRectangle(TextCaptionOther)
        Dim cap = System.Uri.EscapeDataString(TextLeaderName.Text)
        SendVmixCmd("?Function=SetText&Input=LeaderCaption&SelectedName=Name.Text&Value=" & cap)
        cap = System.Uri.EscapeDataString(TextPreacherName.Text)
        SendVmixCmd("?Function=SetText&Input=PreacherCaption&SelectedName=Name.Text&Value=" & cap)
        cap = System.Uri.EscapeDataString(TextCaptionOther.Text)
        SendVmixCmd("?Function=SetText&Input=OtherCaption&SelectedName=Name.Text&Value=" & cap)
    End Sub

    '---change caption selection to previous one
    Private Sub BtnCapPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCPrev.Click
        If (CaptionIndex > 1) Then CaptionIndex = CaptionIndex - 1
        SetCaptionText()
    End Sub

    '---change caption selection to next one
    Private Sub BtnCapNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCNxt.Click
        If (CaptionIndex < 3) Then CaptionIndex = CaptionIndex + 1
        SetCaptionText()
    End Sub

    '---update vmix if the caption has been edited and loses focus (** this is not working)
    Private Sub TextLeaderName_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        SetCaptionText()
    End Sub
    Private Sub TextPreacherName_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        SetCaptionText()
    End Sub
    Private Sub TextCaptionOther_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        SetCaptionText()
    End Sub

    '---Load mediaplayer listbox
    Private Sub LoadMediaList()
        Dim shortfile As String
        ListBoxMedia.Items.Clear()
        For i = 0 To MediaMax - 1
            If Len(MediaFiles(i)) > 0 Then
                If InStr(MediaFiles(i), "\") <> 0 Then
                    shortfile = Mid(MediaFiles(i), InStrRev(MediaFiles(i), "\") + 1)
                Else
                    shortfile = MediaFiles(i)
                End If
                ListBoxMedia.Items.Add(shortfile)
            End If
        Next
        MediaItem = 0
        If ListBoxMedia.Items.Count <> 0 Then ListBoxMedia.SelectedIndex = MediaItem
        'SetMediaItem(MediaFiles(MediaItem), MediaLoop(MediaItem))
    End Sub

    '---Send mediaplayer item to vmix
    Private Sub SetCurrentMediaItem()
        'vmix can't set a single video item by API so we use a list input with single item which can be set
        SendVmixCmd("?Function=ListRemoveAll&Input=" & VMixSourceName(7))
        SendVmixCmd("?Function=ListAdd&Input=" & VMixSourceName(7) & "&Value=" & MediaFiles(MediaItem))
        If MediaLoop(MediaItem) Then SendVmixCmd("?Function=LoopOn&Input=" & VMixSourceName(7)) : Else SendVmixCmd("?Function=LoopOff&Input=" & VMixSourceName(7))
    End Sub

    '---Select previous mediaplayer item
    Private Sub BtnMPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMPrev.Click
        If ListBoxMedia.Items.Count = 0 Then Exit Sub
        If MediaItem > 0 Then
            MediaItem = MediaItem - 1
            ListBoxMedia.SelectedIndex = MediaItem
            SetCurrentMediaItem()
        End If
    End Sub

    '---Select next mediaplayer item
    Private Sub BtnMNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMNext.Click
        If ListBoxMedia.Items.Count = 0 Then Exit Sub
        If MediaItem < ListBoxMedia.Items.Count - 1 Then
            MediaItem = MediaItem + 1
            ListBoxMedia.SelectedIndex = MediaItem
            SetCurrentMediaItem()
        End If
    End Sub

    '---if user clicks on the listbox set it back to where we think it should be
    Private Sub ListBoxMedia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxMedia.SelectedIndexChanged
        ListBoxMedia.SelectedIndex = MediaItem
    End Sub

    '-------------------------------------------------------------------------------------------------
    ' Camera manual settings
    '
    '-------------------------------------------------------------------------------------------------

    Sub SetIris(ad As Integer, v As Integer)
        Dim op As String
        If ad > 5 Then Exit Sub
        If ad <> 5 Then op = SendCamCmdAddrNoHash(ad, "QRV", "aw_cam") 'get iris setting

        If v <> 9999 Then 'not auto mode
            If CamIris(ad) = 9999 Then 'if was auto previously
                mLog.Text = SendCamCmdAddrNoHash(ad, "ORS:0", "aw_cam") 'man iris
                MyButtonAutoIris.BackColor = Color.White
                If ad <> 5 Then
                    If CamIgnore(ad) = True Then
                        v = &H1FF
                    Else
                        op = SendCamCmdAddrNoHash(ad, "QRV", "aw_cam") 'get actual iris setting
                        v = Val("&H" & Mid(op, 5))
                    End If
                Else
                    v = &H555 'cam5 can't read iris state
                End If
            End If
        Else
            mLog.Text = SendCamCmdAddrNoHash(ad, "ORS:1", "aw_cam") 'auto iris
            CamIris(ad) = 9999 'flag auto
            TextBoxIris.Text = "Auto"
            ShowEncoderValues()
            MyButtonAutoIris.BackColor = Color.Red
            Exit Sub
        End If

        CamIris(ad) = v
        If ad <> 5 Then
            If (CamIris(ad) < 0) Then CamIris(ad) = 0
            If (CamIris(ad) > &H3FF) Then CamIris(ad) = &H3FF
            mLog.Text = mLog.Text & SendCamCmdAddrNoHash(ad, "ORV:" & String.Format("{0:X3}", CamIris(ad)), "aw_cam")
        Else
            If (CamIris(ad) < &H555) Then CamIris(ad) = &H555
            If (CamIris(ad) > &HFFF) Then CamIris(ad) = &HFFF
            mLog.Text = mLog.Text & SendCamCmdAddrNoHash(ad, "%23AXI" & String.Format("{0:X3}", CamIris(ad)), "aw_ptz")
        End If
        TextBoxIris.Text = CamIris(ad)
        ShowEncoderValues()
    End Sub

    Private Sub BtnIrisDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIrisDown.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            CamIris(ad) = CamIris(ad) - 10
        Else
            CamIris(ad) = CamIris(ad) - 64
        End If
        SetIris(ad, CamIris(ad))
    End Sub

    Private Sub BtnIrisUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIrisUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            CamIris(ad) = CamIris(ad) + 10
        Else
            CamIris(ad) = CamIris(ad) + 64
        End If
        SetIris(ad, CamIris(ad))
    End Sub

    Private Sub BtnIrisAuto()
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If CamIris(ad) = 9999 Then 'iris was in auto mode
            SetIris(ad, 9998)
        Else
            SetIris(ad, 9999)
        End If
    End Sub

    Private Sub BtnIrisAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAutoIris.Click
        BtnIrisAuto()
    End Sub
    Sub SetAGC(ad As Integer, v As Integer)
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub

        If v <> 9999 Then 'not auto mode
            If CamAgc(ad) = 128 Then 'if was auto previously
                MyButtonAutoAgc.BackColor = Color.White
                v = 16
            End If
            If v > 16 Then v = 16
            If v < 0 Then v = 0
            CamAgc(ad) = v
        Else
            CamAgc(ad) = 128 'flag auto
            MyButtonAutoAgc.BackColor = Color.Red
        End If

        If (CamAgc(ad) <= 16) Then
            TextBoxAgc.Text = CamAgc(ad) * 3 & "dB"
            mLog.Text = mLog.Text & SendCamCmdAddrNoHash(ad, "OGU:" & String.Format("{0:X2}", CamAgc(ad) * 3 + 8), "aw_cam")
        Else
            TextBoxAgc.Text = "Auto"
            mLog.Text = mLog.Text & SendCamCmdAddrNoHash(ad, "OGU:" & String.Format("{0:X2}", 128), "aw_cam")
        End If
        ShowEncoderValues()
    End Sub
    Private Sub BtnAGCDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAGCDown.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        'op = SendCamCmdAddrNoHash(ad, "QGU") 'get gain setting
        'mLog.Text = op
        'CamAgc(ad) = Val("&H" & Mid(op, 5))
        CamAgc(ad) = CamAgc(ad) - 1
        SetAGC(ad, CamAgc(ad))
    End Sub

    Private Sub BtnAGCUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAGCUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        'op = SendCamCmdAddrNoHash(ad, "QGU") 'get gain setting
        'mLog.Text = op
        'CamAgc(ad) = Val("&H" & Mid(op, 5))
        CamAgc(ad) = CamAgc(ad) + 1
        SetAGC(ad, CamAgc(ad))
    End Sub

    Private Sub BtnAgcAuto()
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        If CamAgc(ad) = 128 Then
            CamAgc(ad) = 16
            SetAGC(ad, CamAgc(ad))
        Else
            CamAgc(ad) = 128
            SetAGC(ad, CamAgc(ad))
        End If
    End Sub

    Private Sub BtnAgcAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAutoAgc.Click
        BtnAgcAuto()
    End Sub
    Sub SetAGCLimit(ad As Integer, v As Integer)
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        If (v < 1) Then v = 1
        If (v > 8) Then v = 8
        CamAGCLimit(ad) = v
        mLog.Text = SendCamCmdAddrNoHash(ad, "OSD:69:" & String.Format("{0:X2}", CamAGCLimit(ad)), "aw_cam")
        TextBoxAgcLimit.Text = CamAGCLimit(ad) * 6 & "dB"
        ShowEncoderValues()
    End Sub
    Private Sub BtnGainDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGainDown.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        CamAGCLimit(ad) = CamAGCLimit(ad) - 1
        SetAGCLimit(ad, CamAGCLimit(ad))
    End Sub

    Private Sub BtnGainUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGainUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        CamAGCLimit(ad) = CamAGCLimit(ad) + 1
        SetAGCLimit(ad, CamAGCLimit(ad))
    End Sub

    Sub SetAEShift(ad As Integer, v As Integer)
        If ad > 5 Then Exit Sub
        If (v < -10) Then v = -10
        If (v > 10) Then v = 10
        CamAEShift(ad) = v
        mLog.Text = SendCamCmdAddrNoHash(ad, "OSD:48:" & Format((10 + CamAEShift(ad)) * 64 / 20, "00"), "aw_cam") 'gain is -10 to +10 but number is 0-64
        TextBoxAeShift.Text = CamAEShift(ad)
        ShowEncoderValues()
    End Sub
    Private Sub BtnAEShiftDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAEShiftDn.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        CamAEShift(ad) = CamAEShift(ad) - 1
        SetAEShift(ad, CamAEShift(ad))
    End Sub

    Private Sub BtnAEShiftUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAEShiftUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        CamAEShift(ad) = CamAEShift(ad) + 1
        SetAEShift(ad, CamAEShift(ad))
    End Sub

    Sub SetWbDescription(ad As Integer, wb As Integer)
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            TextBoxWB.Text = 2400 + CamWBBlue(ad) * 100
        Else
            If CamWBBlue(ad) = 1 Then TextBoxWB.Text = "A"
            If CamWBBlue(ad) = 2 Then TextBoxWB.Text = "B"
            If CamWBBlue(ad) = 3 Then TextBoxWB.Text = "Auto"
            If CamWBBlue(ad) = 4 Then TextBoxWB.Text = "3200"
            If CamWBBlue(ad) = 5 Then TextBoxWB.Text = "5600"
            If CamWBBlue(ad) = 6 Then TextBoxWB.Text = "4500"
            If CamWBBlue(ad) = 7 Then TextBoxWB.Text = "6000"
            If CamWBBlue(ad) = 8 Then TextBoxWB.Text = "2800"
        End If
    End Sub
    Private Sub BtnWbBlueDn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWbBlueDn.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            mLog.Text = SendCamCmdAddrNoHash(ad, "OAW:9", "aw_cam")
            If CamWBBlue(ad) > 0 Then CamWBBlue(ad) = CamWBBlue(ad) - 1
            mLog.Text = mLog.Text + SendCamCmdNoHash("OSD:B1:" & String.Format("{0:X3}", CamWBBlue(ad)), "aw_cam")
        Else
            If CamWBBlue(ad) > 1 Then CamWBBlue(ad) = CamWBBlue(ad) - 1
            mLog.Text = mLog.Text + SendCamCmdNoHash("OAW:" & CamWBBlue(ad), "aw_cam")
        End If
        SetWbDescription(ad, CamWBBlue(ad))
        MyButtonAutoWB.BackColor = Color.White
    End Sub

    Private Sub BtnWbBlueUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWbBlueUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            mLog.Text = SendCamCmdAddrNoHash(ad, "OAW:9", "aw_cam")
            If CamWBBlue(ad) < &H4B Then CamWBBlue(ad) = CamWBBlue(ad) + 1
            mLog.Text = mLog.Text + SendCamCmdNoHash("OSD:B1:" & String.Format("{0:X3}", CamWBBlue(ad)), "aw_cam")
        Else
            If CamWBBlue(ad) < 8 Then CamWBBlue(ad) = CamWBBlue(ad) + 1
            mLog.Text = mLog.Text + SendCamCmdNoHash("OAW:" & CamWBBlue(ad), "aw_cam")
        End If
        SetWbDescription(ad, CamWBBlue(ad))
        MyButtonAutoWB.BackColor = Color.White
    End Sub
    Private Sub BtnWBAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAutoWB.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If MyButtonAutoWB.BackColor = Color.Red Then
            If ad <> 5 Then
                mLog.Text = SendCamCmdAddrNoHash(ad, "OAW:9", "aw_cam")
                mLog.Text = mLog.Text + SendCamCmdNoHash("OSD:B1:" & String.Format("{0:X3}", CamWBBlue(ad)), "aw_cam")
            Else
                mLog.Text = mLog.Text + SendCamCmdNoHash("OAW:" & CamWBBlue(ad), "aw_cam")
            End If
            SetWbDescription(ad, CamWBBlue(ad))
            MyButtonAutoWB.BackColor = Color.White
        Else
            mLog.Text = SendCamCmdAddrNoHash(ad, "OAW:0", "aw_cam")
            TextBoxWB.Text = "Auto"
            MyButtonAutoWB.BackColor = Color.Red
        End If
    End Sub
    Sub SetFocus(ad As Integer, v As Integer)
        If ad > 5 Then Exit Sub
        If (v < &H555) Then v = &H555
        If (v > &HFFF) Then v = &HFFF
        If CamFocusManual(ad) = 0 Then 'if was in auto mode set to manual
            SendCamCmdAddr(ad, "D10")
            CamFocusManual(ad) = 1
            BtnFocusAuto.BackColor = Color.White : BtnFocusLock.BackColor = Color.Red
        End If
        CamFocus(ad) = v
        'axf sets absolute focus position 555-FFF
        mLog.Text = SendCamCmdAddr(ad, "AXF" & String.Format("{0:X2}", CamFocus(ad))) '&h555-&hFFF
        TextBoxFocus.Text = CamFocus(ad)
        ShowEncoderValues()
    End Sub

    Private Sub BtnFocusSetAuto()
        Dim ad As Integer
        If (PTZLive = True) Then ad = LiveAddr Else ad = Addr
        If ad > 5 Then Exit Sub
        SendCamCmdAddr(ad, "D11")
        CamFocusManual(ad) = 0
        TextBoxFocus.Text = "Auto"
        BtnFocusAuto.BackColor = Color.Red : BtnFocusLock.BackColor = Color.White
        ShowEncoderValues()
    End Sub

    Private Sub BtnFocusSetLock()
        Dim ad As Integer
        Dim op As String
        If (PTZLive = True) Then ad = LiveAddr Else ad = Addr
        If ad > 5 Then Exit Sub
        SendCamCmdAddr(ad, "D10")
        CamFocusManual(ad) = 1
        op = SendCamCmdAddr(ad, "GF")
        CamFocus(ad) = Val("&H" & Mid(op, 3))
        TextBoxFocus.Text = CamFocus(ad)
        BtnFocusAuto.BackColor = Color.White : BtnFocusLock.BackColor = Color.Red
        ShowEncoderValues()
    End Sub

    Private Sub BtnFocusAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFocusAuto.Click
        BtnFocusSetAuto()
    End Sub

    Private Sub BtnFocusLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFocusLock.Click
        BtnFocusSetLock()
    End Sub

    Private Sub BtnFocusUp_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnFocusUp.Click
        Dim ad As Integer
        If (PTZLive = True) Then ad = LiveAddr Else ad = Addr
        If ad > 5 Then Exit Sub
        CamFocus(ad) = CamFocus(ad) + 10
        SetFocus(ad, CamFocus(ad))
    End Sub

    Private Sub BtnFocusDn_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnFocusDn.Click
        Dim ad As Integer
        If (PTZLive = True) Then ad = LiveAddr Else ad = Addr
        If ad > 5 Then Exit Sub
        CamFocus(ad) = CamFocus(ad) - 10
        SetFocus(ad, CamFocus(ad))
    End Sub

    '---Program shut down button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.ForeColor = Color.Red Then
            ShutDownTimer = 1
        Else
            Button1.ForeColor = Color.Red
            ProgCloseTimer = 100
        End If
    End Sub


    '--------------------------------------------------------------------------------------------------------------
    ' Emergency camera movement controls on touchscreen
    '--------------------------------------------------------------------------------------------------------------
    Private Sub CamFullTele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonFullTele.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z99") 'max speed zoom tele
    End Sub

    Private Sub CamFullWide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonFullWide.Click
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z01") 'max speed zoom wide
    End Sub


    Private Sub CamTele_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamTele.MouseDown
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If BtnFast.BackColor = Color.Green Then
            mLog.Text = SendCamCmdAddr(ad, "Z95") 'zoom med tele
        Else
            mLog.Text = SendCamCmdAddr(ad, "Z55") 'zoom med tele
        End If
    End Sub
    Private Sub CamTele_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamTele.MouseUp
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z50") 'zoom stop
    End Sub

    Private Sub CamWide_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamWide.MouseDown
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        If BtnFast.BackColor = Color.Green Then
            mLog.Text = SendCamCmdAddr(ad, "Z05") 'zoom med wide
        Else
            mLog.Text = SendCamCmdAddr(ad, "Z45") 'zoom med wide
        End If
    End Sub
    Private Sub CamWide_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamWide.MouseUp
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z50") 'zoom stop
    End Sub

    Private Sub MyButtonCamUL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamUL.MouseDown, MyButtonCamU.MouseDown, MyButtonCamUR.MouseDown, MyButtonCamL.MouseDown, MyButtonCamR.MouseDown, MyButtonCamDL.MouseDown, MyButtonCamD.MouseDown, MyButtonCamDR.MouseDown
        Dim index As String
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        index = (Mid(sender.name, 12))
        Dim xsp As String, ysp As String, xpos As Integer, ypos As Integer, spd As Integer
        If index = "UL" Then xpos = -1 : ypos = -1
        If index = "U" Then xpos = 0 : ypos = -1
        If index = "UR" Then xpos = 1 : ypos = -1
        If index = "L" Then xpos = -1 : ypos = 0
        If index = "R" Then xpos = 1 : ypos = 0
        If index = "DL" Then xpos = -1 : ypos = 1
        If index = "D" Then xpos = 0 : ypos = 1
        If index = "DR" Then xpos = 1 : ypos = 1
        If CamInvert(ad) Then xpos = -xpos : ypos = -ypos
        xsp = "50" : ysp = "50"
        If BtnFast.BackColor = Color.Green Then spd = 25 Else spd = 10
        If (xpos < 0) Then xsp = Val(xsp) - spd
        If (xpos > 0) Then xsp = Val(xsp) + spd
        If (ypos < 0) Then ysp = Val(ysp) + spd
        If (ypos > 0) Then ysp = Val(ysp) - spd
        mLog.Text = SendCamCmdAddr(ad, "PTS" & xsp & ysp) 'pan tilt at speed
        'Label7.Text = xpos & " " & ypos

    End Sub

    Private Sub MyButtonCamUL_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamUL.MouseUp, MyButtonCamU.MouseUp, MyButtonCamUR.MouseUp, MyButtonCamL.MouseUp, MyButtonCamR.MouseUp, MyButtonCamDL.MouseUp, MyButtonCamD.MouseUp, MyButtonCamDR.MouseUp
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "PTS5050") 'pt stop
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' More preset control buttons
    '--------------------------------------------------------------------------------------------------------------
    Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
        BtnFast.BackColor = Color.Green
        BtnSlow.BackColor = Color.White
    End Sub

    Private Sub BtnSlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlow.Click
        BtnFast.BackColor = Color.White
        BtnSlow.BackColor = Color.Green
    End Sub

    '---Live move button. Executes the current preset move now
    Private Sub BtnLive_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLive.Click
        If PresetLive = False Then
            BtnLive.BackColor = Color.Green
            PresetLive = True
            BtnPreload.BackColor = Color.White
            PreloadPreset = 0
        Else
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
        UpdatePresets()
    End Sub

    '---Joystick live button. Makes joystick and other cam controls operate live cam instead of preset
    Private Sub BtnLivePTZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLivePTZ.Click
        If PTZLive = False Then
            BtnLivePTZ.BackColor = Color.Green
            PTZLive = True
        Else
            BtnLivePTZ.BackColor = Color.White
            PTZLive = False
        End If
        ShowCamValues()
    End Sub

    '---Preload button, for live moves
    Private Sub BtnPreload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreload.Click
        If PreloadPreset = 0 Then
            BtnPreload.BackColor = Color.Orange
            PreloadPreset = 99
            BtnLive.BackColor = Color.White
            PresetLive = False
        Else
            BtnPreload.BackColor = Color.White
            PreloadPreset = 0
            'cdir = 0
            SetLiveMoveIndicators()
            UpdatePresets()
        End If
    End Sub


    Sub PresetClick(ByVal c As Integer)
        If c = 1 Then BtnPreset_Click(BtnPreset1, Nothing)
        If c = 2 Then BtnPreset_Click(BtnPreset2, Nothing)
        If c = 3 Then BtnPreset_Click(BtnPreset3, Nothing)
        If c = 4 Then BtnPreset_Click(BtnPreset4, Nothing)
        If c = 5 Then BtnPreset_Click(BtnPreset5, Nothing)
        If c = 6 Then BtnPreset_Click(BtnPreset6, Nothing)
        If c = 7 Then BtnPreset_Click(BtnPreset7, Nothing)
        If c = 8 Then BtnPreset_Click(BtnPreset8, Nothing)
        If c = 9 Then BtnPreset_Click(BtnPreset9, Nothing)
        If c = 10 Then BtnPreset_Click(BtnPreset10, Nothing)
        If c = 11 Then BtnPreset_Click(BtnPreset11, Nothing)
        If c = 12 Then BtnPreset_Click(BtnPreset12, Nothing)
        If c = 13 Then BtnPreset_Click(BtnPreset13, Nothing)
        If c = 14 Then BtnPreset_Click(BtnPreset14, Nothing)
        If c = 15 Then BtnPreset_Click(BtnPreset15, Nothing)
        If c = 16 Then BtnPreset_Click(BtnPreset16, Nothing)
    End Sub



    Private Sub BtnLiveSlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLiveSlow.Click
        BtnLiveSlow.BackColor = Color.Green
        BtnLiveFast.BackColor = Color.White
        LiveMoveSpeed = 0
    End Sub

    Private Sub BtnLiveFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLiveFast.Click
        BtnLiveSlow.BackColor = Color.White
        BtnLiveFast.BackColor = Color.Green
        LiveMoveSpeed = 1
    End Sub




    '---Not sure what this does
    Private Sub OverrideBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverrideBtn.Click
        If CamOverride <> 0 Then
            OverrideBtn.BackColor = Color.White
            CamOverride = 0
        End If
    End Sub


    '---Show rec status of cameras recording onto their internal cards
    Function CamRecStatus(ByVal inp As String, ByVal cam As Integer)
        Dim str As String
        Dim op As String
        op = ""
        str = Mid(inp, InStr(inp, "rec=") + 4, 2) 'rec state
        If (cam = 1) Then
            If str = "on" Then
                CamRec(1) = True : BtnCam1Rec.BackColor = Color.Red
            Else
                CamRec(1) = False : BtnCam1Rec.BackColor = Color.White
            End If
        End If
        If (cam = 2) Then
            If str = "on" Then
                CamRec(2) = True : BtnCam2Rec.BackColor = Color.Red
            Else
                CamRec(2) = False : BtnCam2Rec.BackColor = Color.White
            End If
        End If
        If (cam = 3) Then
            If str = "on" Then
                CamRec(3) = True : BtnCam3Rec.BackColor = Color.Red
            Else
                CamRec(3) = False : BtnCam3Rec.BackColor = Color.White
            End If
        End If
        If (cam = 4) Then
            If str = "on" Then
                CamRec(4) = True : BtnCam4Rec.BackColor = Color.Red
            Else
                CamRec(4) = False : BtnCam4Rec.BackColor = Color.White
            End If
        End If
        str = Mid(inp, InStr(inp, "sd_insert=") + 10, 2) 'sd insert state
        If str <> "on" Then
            CamRecStatus = "No SD card"
            Exit Function
        End If
        str = Mid(inp, InStr(inp, "sd_error=") + 9, 2) 'sd error state
        If str <> "of" Then
            CamRecStatus = "SD card error"
            Exit Function
        End If
        op = Mid(inp, InStr(inp, "rec_counter=") + 12, 8) & vbCrLf 'rec counter
        str = Mid(inp, InStr(inp, "sd_rem=") + 7) & vbCrLf 'sd remain
        str = Mid(str, 1, InStr(str, Chr(13)) - 1)
        op = op + str
        str = Mid(inp, InStr(inp, "sd_org=") + 7) & vbCrLf 'sd total
        str = Mid(str, 1, InStr(str, Chr(13)) - 1)
        op = op + " of " + str + "GB"
        CamRecStatus = op
    End Function

    '---Send start/stop record commands to cameras
    Private Sub BtnCam1Rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCam1Rec.Click
        If CamRec(1) Then
            SendCamQueryNoResponse(1, "sdctrl?save=end")
        Else
            SendCamQueryNoResponse(1, "sdctrl?save=start")
            CamRec(1) = True
        End If
        'TextBoxCam1Rec.Text = CamRecStatus(SendCamQuery(1, "get_state"), 1)
        'rec = off
        'rec_counter=00:00:00
        'ftp_send = off
        'play = off
        'del_file = off
        'download = off
        'sd_format = off
        'sd_insert=on
        'sd_repair = off
        'sd_error = off
        'sd_rem = 0.0
        'sd_org = 29.8
    End Sub

    Private Sub BtnCam2Rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCam2Rec.Click
        If CamRec(2) Then
            SendCamQueryNoResponse(2, "sdctrl?save=end")
        Else
            SendCamQueryNoResponse(2, "sdctrl?save=start")
            CamRec(2) = True
        End If
    End Sub

    Private Sub BtnCam3Rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCam3Rec.Click
        If CamRec(3) Then
            SendCamQueryNoResponse(3, "sdctrl?save=end")
        Else
            SendCamQueryNoResponse(3, "sdctrl?save=start")
            CamRec(3) = True
        End If
    End Sub

    Private Sub BtnCam4Rec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCam4Rec.Click
        'TextBoxCam4Rec.Text = CamRecStatus(SendCamQuery(4, "get_state"), 4)
        If CamRec(4) Then
            SendCamQueryNoResponse(4, "sdctrl?save=end")
        Else
            SendCamQueryNoResponse(4, "sdctrl?save=start")
            CamRec(4) = True
        End If
    End Sub



    '---Broadcast button---------------------
    Private Sub BtnOBSBroadcast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOBSBroadcast.Click
        If StreamPending = False Then 'don't allow button click while pending. The stream can take time to start
            If VmixStreamState = False Then StreamStartTime = Now.TimeOfDay.TotalSeconds : StreamPending = True : StreamPendingTime = 0 : BtnOBSBroadcast.BackColor = Color.Orange
            SendVmixCmd("?Function=StartStopStreaming")
        End If

    End Sub

    '---Record button
    Private Sub BtnOBSRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOBSRecord.Click
        If VmixRecState = False Then RecStartTime = Now.TimeOfDay.TotalSeconds
        SendVmixCmd("?Function=StartStopRecording")
    End Sub


    '---extract json value in a slightly dodgy way (used for obs status)
    Function jsonValue(ByVal json As String, name As String)
        Dim p As Integer, v As Integer
        jsonValue = ""
        p = InStr(json, name)
        If p = 0 Then Exit Function
        json = Mid(json, p + Len(name))
        v = InStr(json, ":")
        If p = 0 Then Exit Function
        json = Mid(json, v + 1)
        p = InStr(json, ",") : If (p = 0) Then p = InStr(json, "}") : If p = 0 Then p = Len(json)
        jsonValue = Mid(json, 1, p - 1)
    End Function

    '---extract value from xml (used to parse vmix status return)
    Function xmlValue(xml As String, name As String)
        Dim p As Integer, v As String
        xmlValue = ""
        p = InStr(xml, "<" & name)
        If p = 0 Then Exit Function
        xml = Mid(xml, p + Len(name))
        v = Mid(xml, InStr(xml, ">") + 1)
        xmlValue = Strings.Left(v, InStr(v, "<") - 1)
    End Function

    '---process the vmix record / stream status
    Sub ProcessStatus(VmixResponse As String)
        Dim RecState As String = ""
        Dim StreamState As String = ""
        Dim SceneState As String = ""


        If (Len(VmixResponse) > 20) Then
            If VmixInit = 0 Then  '--flag that we have seen vmix response. This is used on first start to check vmix is in a valid state (audio on etc)
                VmixInit = 1
            End If
            RecState = xmlValue(VmixResponse, "recording")
            If RecState = "" Or RecState = "false" Then VmixRecState = False Else VmixRecState = True
            If VmixRecState = True And BtnOBSRecord.BackColor <> Color.Red Then BtnOBSRecord.BackColor = Color.Red
            If VmixRecState = False And BtnOBSRecord.BackColor = Color.Red Then BtnOBSRecord.BackColor = Color.White
            If VmixRecState = True Then
                Dim t As Integer = Now.TimeOfDay.TotalSeconds - RecStartTime
                Dim hr As Integer = Math.Floor(t / 3600)
                Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                Dim sec As Integer = t Mod 60
                VmixRecTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
            Else
                VmixRecTime = "..."
            End If
            TextBoxOBSRecTime.Text = VmixRecTime
            StreamState = xmlValue(VmixResponse, "streaming")
            If StreamState = "" Or StreamState = "false" Then
                VmixStreamState = False
            Else
                If VmixStreamState = False Then 'previously not streaming - just starting. Clear the streampending flag
                    If StreamPending Then StreamPending = False : StreamStartTime = Now.TimeOfDay.TotalSeconds
                End If
                VmixStreamState = True
            End If
            If VmixStreamState = True And BtnOBSBroadcast.BackColor <> Color.Red Then BtnOBSBroadcast.BackColor = Color.Red
            If VmixStreamState = False And BtnOBSBroadcast.BackColor = Color.Red Then BtnOBSBroadcast.BackColor = Color.White
            If StreamState = True Then
                Dim t As Integer
                t = Now.TimeOfDay.TotalSeconds - StreamStartTime
                Dim hr As Integer = Math.Floor(t / 3600)
                Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                Dim sec As Integer = t Mod 60
                VmixStreamTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
            Else
                If Not StreamPending Then VmixStreamTime = "..." Else VmixStreamTime = "Starting..."
            End If
            TextBoxOBSBroadcastTime.Text = VmixStreamTime
        End If


    End Sub



    '#########################################################################################################################################################################
    ' SERIAL PORT (PTZ controller)
    '#########################################################################################################################################################################

    'send the button led states to the controller
    Private Sub SendSerial()
        Dim b(32) As Byte
        b(0) = 2  'start
        b(1) = 128 + ControllerLedState(0) + 8 * ControllerLedState(1)
        b(2) = 128 + ControllerLedState(2) + 8 * ControllerLedState(3)
        b(3) = 128 + ControllerLedState(4) + 8 * ControllerLedState(5)
        b(4) = 128 + ControllerLedState(6) + 8 * ControllerLedState(7)
        b(5) = 128 + ControllerLedState(8) + 8 * ControllerLedState(9)
        b(6) = 128 + ControllerLedState(10) + 8 * ControllerLedState(11)
        b(7) = 128 + ControllerLedState(12) + 8 * ControllerLedState(13)
        b(8) = 128 + ControllerLedState(14)
        b(9) = 128 + EncoderAReset + 2 * EncoderBReset 'encoder reset bits 0..1
        b(10) = 3  'end
        SerialPort1.Write(b, 0, 11)
    End Sub

    'receive joystick and button presses from controller
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim x As Byte, k As Byte, newserial As Byte
        Dim ad As Integer
        Dim op As String
        CheckForIllegalCrossThreadCalls = False 'naughty but allows us to write diagnostics to textbox on form
        If SerialPort1.IsOpen = False Then Exit Sub

        newserial = 0
        While SerialPort1.BytesToRead > 0
            x = SerialPort1.ReadByte
            If (x = 2) Then
                SerialInBufPtr = 0
            ElseIf (x = 3) Then
                newserial = 1
                SerialTimeout = 20
                Exit While
            ElseIf (x = &H57) Then
                'TextBox2.Text = "ACK!"
            Else
                If (SerialInBufPtr < 32) Then
                    SerialInBuf(SerialInBufPtr) = x And 127
                    SerialInBufPtr = SerialInBufPtr + 1
                End If
            End If
        End While

        If newserial = 1 And StartupTimer > 50 Then
            ControlKeyState = SerialInBuf(0) + (SerialInBuf(1) * 128) + (SerialInBuf(2) * 512)
            EncoderA = SerialInBuf(3) + (SerialInBuf(4) * 128) + (SerialInBuf(5) * 512)
            If EncoderA > 32767 Then EncoderA = EncoderA - 65536
            If EncoderA = 0 Then EncoderAReset = 0
            EncoderB = SerialInBuf(6) + (SerialInBuf(7) * 128) + (SerialInBuf(8) * 512)
            If EncoderB > 32767 Then EncoderB = EncoderB - 65536
            If EncoderB = 0 Then EncoderBReset = 0
            JoyX = SerialInBuf(9) + (SerialInBuf(12) And 64) * 2
            JoyY = SerialInBuf(10) + (SerialInBuf(12) And 32) * 4
            JoyZ = SerialInBuf(11) + (SerialInBuf(12) And 16) * 8
            SendSerial() 'send back the button illumination info

            If (ControlKeyState <> PrevControlKeyState) Then
                If (ControlKeyState > PrevControlKeyState) Then
                    KeyHit = True
                    ad = ControlKeyState Xor PrevControlKeyState
                    For k = 0 To 15
                        If (ad And (2 ^ k)) Then LastKey = k + 1
                    Next
                End If
                PrevControlKeyState = ControlKeyState

                If KeyHit Then 'handle button presses
                    If LastKey = 1 Then BtnCam1.PerformClick()
                    If LastKey = 2 Then BtnCam2.PerformClick()
                    If LastKey = 3 Then BtnCam3.PerformClick()
                    If LastKey = 4 Then BtnCam4.PerformClick()
                    If LastKey = 5 Then BtnCam5.PerformClick() 'cam5

                    If LastKey = 6 Then BtnInp1.PerformClick() 'words
                    If LastKey = 7 Then BtnInp2.PerformClick() 'media
                    If LastKey = 8 Then BtnInp3.PerformClick() 'aux
                    If LastKey = 9 Then BtnInp4.PerformClick() 'pip
                    If LastKey = 10 Then BtnInp5.PerformClick() 'black

                    If LastKey = 11 Then BtnOverlay.PerformClick()
                    If LastKey = 12 Then BtnMediaOverlay.PerformClick()
                    If LastKey = 13 Then BtnTransition.PerformClick()
                    If LastKey = 14 Then BtnCut.PerformClick()
                    If LastKey = 15 Then EncoderClick(1)
                    If LastKey = 16 Then EncoderClick(2)
                    KeyHit = False
                End If

            End If

            'handle encoder rotation
            If EncoderA <> PrevEncoderA And EncoderAReset = 0 Then
                If (alreadysending = 0) Then 'this stops us sending a bunch of commands too quickly
                    SetEncoderValue(1, EncoderA - PrevEncoderA, EncoderATime)
                    'TextEncAStatus.Text = EncoderA
                    PrevEncoderA = EncoderA 'only send prev value when we actually send
                    alreadysending = 2 'in 100ms sets how long we wait before sending another
                End If
                EncoderATime = 0  'reset the change timer
            End If

            If EncoderB <> PrevEncoderB And EncoderBReset = 0 Then
                If (alreadysending = 0) Then 'this stops us sending a bunch of commands too quickly
                    SetEncoderValue(2, EncoderB - PrevEncoderB, EncoderBTime)
                    PrevEncoderB = EncoderB
                    alreadysending = 2
                End If
                EncoderBTime = 0  'reset the change timer
            End If


            'check for joystick being operated
            'we will define a dead band at the centre of the joystick
            Dim JoyDB As Byte = 8 'deadband of joystick (not currently used)
            'If JoyX < (128 - JoyDB) Or JoyX > (128 + JoyDB) Or JoyY < (128 - JoyDB) Or JoyY > (128 + JoyDB) Or JoyZ < (128 - JoyDB) Or JoyZ > (128 + JoyDB) Then

            Dim xpos As Integer, ypos As Integer, zpos As Integer, zoom As Boolean = False
            If PTZLive = False Then ad = Addr Else ad = LiveAddr
            If (CamOverride > 0) Then ad = CamOverride 'override the selected camera from the buttons
            If (ad <= 5) Then
                xpos = 255 - JoyX
                ypos = JoyY
                zpos = JoyZ

                If CamInvert(ad) Then xpos = 255 - xpos : ypos = 255 - ypos
                'JoyZ = zpos - JoyDB : JoyX = xpos - JoyDB : JoyY = ypos - JoyDB
                'JoyZ = 1 + Int(JoyZ * 99 / (255 - JoyDB * 2))
                If (zpos >= 128) Then JoyZ = 100 - zoomconvert(255 - zpos) Else JoyZ = zoomconvert(zpos)
                If (JoyZ <> PrevJoyZ) Then
                    If (alreadysending = 0) Then 'this function is reentrant. We need to make sure we are not already sending something from a previous command.
                        op = Format(JoyZ, "00")
                        alreadysending = 2
                        SendCamCmdAddr(ad, "Z" & op)
                        PrevJoyZ = JoyZ 'only store the prev value if we actually send the new value
                        'alreadysending = False
                    End If
                End If
                'JoyX = 1 + Int(JoyX * 99 / (255 - JoyDB * 2)) : JoyY = 1 + Int(JoyY * 99 / (255 - JoyDB * 2))
                If (xpos >= 128) Then JoyX = 100 - joyconvert(255 - xpos) Else JoyX = joyconvert(xpos)
                If (ypos >= 128) Then JoyY = 100 - joyconvert(255 - ypos) Else JoyY = joyconvert(ypos)
                If (JoyX <> PrevJoyX) Or (JoyY <> PrevJoyY) Then
                    If alreadysending = 0 Then
                        op = Format(JoyX, "00") & Format(JoyY, "00")
                        alreadysending = 2
                        SendCamCmdAddr(ad, "PTS" & op)
                        PrevJoyX = JoyX : PrevJoyY = JoyY
                        'alreadysending = False
                    End If
                End If

            End If
        End If

    End Sub



    '#########################################################################################################################################################################
    ' TIMERS
    '#########################################################################################################################################################################

    '---Timer 1 = 100ms used for all system timing functions
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ta As Integer
        Dim op As String
        Dim px As Integer, py As Integer

        If (alreadysending > 0) Then alreadysending = alreadysending - 1 'timer for sending to cameras

        'timer to autoconnect on startup
        If (StartupTimer < 100) Then StartupTimer = StartupTimer + 1
        If StartupTimer = 69 Then GroupBox1.Hide()
        If StartupTimer = 99 Then MsgBoxPanel.Visible = False
        If (StartupTimer = 5) Then 'open com ports
            Timer1.Enabled = False
            If GetSetting("CCNCamControl", "Set", "Askprofile", True) = True Then
                SelectPresetFile()
            End If
            GroupBox1.Show()
            GroupBox1.Left = 100 : GroupBox1.Top = 100

            'if ctrl key held on boot - emergency startup mode
            If CtrlKey Then Label22.Text = "EMERGENCY STARTUP MODE" & vbCrLf Else Label22.Text = ""
            Label22.Text = Label22.Text & "Profile: " & PresetFileName & vbCrLf
            Label22.Text = Label22.Text & "Opening com port..."
            ComportOpen()
            If (SerialPort1.IsOpen) Then
                Label22.Text = Label22.Text & "Done" & vbCrLf
            Else
                Label22.Text = Label22.Text & "Fail" & vbCrLf
            End If
            GroupBox1.Refresh()

            Timer1.Enabled = True
        End If
        If (StartupTimer = 10) Then 'connect to vmix
            SendVmixCmd("?Function=PreviewInput&Input=" & VMixSourceName(2))
            NextPreview = 2
            TransitionWait = 2 'will set preview to 2
            SetCaptionText()
            SetCurrentMediaItem()
        End If
        If (StartupTimer = 15) Then
            Timer1.Enabled = False
            For ta = 1 To 4
                SendCamCmdAddr(ta, "O1") 'power on command
            Next
            Timer1.Enabled = True

        End If
        If (StartupTimer = 30) Then 'get/set camera defaults
            Timer1.Enabled = False
            For ta = 1 To 4

                Label22.Text = Label22.Text & "Initialise Camera " & ta & "..."
                GroupBox1.Refresh()
                ReadbackCameraStates(ta)
                If (CamIgnore(ta) = False) Then Label22.Text = Label22.Text & "Done" & vbCrLf Else Label22.Text = Label22.Text & "Fail" & vbCrLf
                If (CtrlKey = False) Then
                    'temporarily don't move the cameras on power up
                    'SendCamCmdAddr(ta, "APC80008000")
                    'SendCamCmdAddr(ta, "AXZ555")
                End If
            Next
            Label22.Text = Label22.Text & "Initialise Camera 5..." 'send power on command to he2 and check we get a response
            GroupBox1.Refresh()
            If Cam5Dis = False Then
                If SendCamQuery(5, "aw_ptz?cmd=%23O1&res=1") <> "" Then CamIgnore(5) = False Else CamIgnore(5) = True
                If CamIgnore(5) = False Then Label22.Text = Label22.Text & "Done" & vbCrLf Else Label22.Text = Label22.Text & "Fail" & vbCrLf
            Else
                Label22.Text = Label22.Text & "Ignore" & vbCrLf
                CamIgnore(5) = True
            End If
            Label22.Text = Label22.Text & "Waiting for cameras to come out of standby..."
            Timer1.Enabled = True
            ShowCamValues()
            'also, get cam card info
            TextBoxCam1Rec.Text = CamRecStatus(SendCamQuery(1, "get_state"), 1)
            TextBoxCam2Rec.Text = CamRecStatus(SendCamQuery(2, "get_state"), 2)
            TextBoxCam3Rec.Text = CamRecStatus(SendCamQuery(3, "get_state"), 3)
            TextBoxCam4Rec.Text = CamRecStatus(SendCamQuery(4, "get_state"), 4)

        End If

        'check for disabled cams and show on buttons
        ComCheckTimer = ComCheckTimer + 1
        If (ComCheckTimer > 20) Then
            ComCheckTimer = 0
            If Cam1Dis Then 'user disabled
                CamIgnore(1) = True
                'BtnCam1.Enabled = False 'lock out the button
                BtnCam1.Text = "CAM1 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(1) Then BtnCam1.Text = "CAM1 com-fail" Else BtnCam1.Text = "CAM1"
            End If

            If Cam2Dis Then 'user disabled
                CamIgnore(2) = True
                'BtnCam2.Enabled = False 'lock out the button
                BtnCam2.Text = "CAM2 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(2) Then BtnCam2.Text = "CAM2 com-fail" Else BtnCam2.Text = "CAM2"
            End If

            If Cam3Dis Then 'user disabled
                CamIgnore(3) = True
                'BtnCam3.Enabled = False 'lock out the button
                BtnCam3.Text = "CAM3 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(3) Then BtnCam3.Text = "CAM3 com-fail" Else BtnCam3.Text = "CAM3"
            End If

            If Cam4Dis Then 'user disabled
                CamIgnore(4) = True
                'BtnCam4.Enabled = False 'lock out the button
                BtnCam4.Text = "CAM4 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(4) Then BtnCam4.Text = "CAM4 com-fail" Else BtnCam4.Text = "CAM4"
            End If

            If Cam5Dis Then 'user disabled
                CamIgnore(5) = True
                'BtnCam5.Enabled = False 'lock out the button
                BtnCam5.Text = "CAM5 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(5) Then BtnCam5.Text = "CAM5 com-fail" Else BtnCam5.Text = "CAM5"
            End If
        End If

        'timer to stop cam movements once cam is off air
        'If DelayStop > 0 And liveaddr <> DelayAddr Then
        If DelayStop > 0 Then
            DelayStop = DelayStop - 1
            If DelayStop = 0 Then 'we will stop everything except the live cam, just in case
                If LiveAddr <> 1 And Addr <> 1 Then
                    SendCamCmdAddr(1, "PTS5050")
                    SendCamCmdAddr(1, "Z50")
                End If
                If LiveAddr <> 2 And Addr <> 2 Then
                    SendCamCmdAddr(2, "PTS5050")
                    SendCamCmdAddr(2, "Z50")
                End If
                If LiveAddr <> 3 And Addr <> 3 Then
                    SendCamCmdAddr(3, "PTS5050")
                    SendCamCmdAddr(3, "Z50")
                End If
                If LiveAddr <> 4 And Addr <> 4 Then
                    SendCamCmdAddr(4, "PTS5050")
                    SendCamCmdAddr(4, "Z50")
                End If
                'PendingZoom = 0 : PendingPan = 0 : PendingTilt = 0
            End If
        End If

        'timer to change preview after transition
        If TransitionWait > 0 Then
            TransitionWait = TransitionWait - 1
            If TransitionWait = 0 Then
                Addr = NextPreview
                setactive()
                If MediaPlayerWasActive Then 'if we just transitioned away from media player, go to the next clip
                    MediaPlayerWasActive = False
                    BtnMNext.PerformClick()
                End If
            End If
        End If

        'timer to check for double presses of cut and fade, and also check that the live/prev cams match what we think they are
        If CutLockoutTimer > 0 Then
            CutLockoutTimer = CutLockoutTimer - 1
        End If

        'pending zoom - check if reached desired pos or no longer live
        If PendingZoom <> 0 Or PendingPan <> 0 Or PendingTilt <> 0 Then
            If (LiveAddr <> PzAddr) And DelayStop = 0 Then
                SendCamCmdAddr(PzAddr, "Z50")
                SendCamCmdAddr(PzAddr, "PTS5050")
                PendingZoom = 0 'cam is no longer live, we can stop
                PendingPan = 0
                PendingTilt = 0
            End If
            PzTimer = PzTimer + 1
            If PzTimer >= 3 And CamCmdPending = False Then 'don't do it too often
                PzTimer = 0

                CamCmdPending = True 'in case this routine re-enters before we finish
                op = SendCamCmdAddr(PzAddr, "GZ") 'get zoom position
                ta = Val("&H" & Mid(op, 3))

                op = SendCamCmdAddr(PzAddr, "APC") 'get current pt position
                op = Mid(op, 4)
                px = Convert.ToInt32(Mid(op, 1, 4), 16)
                py = Convert.ToInt32(Mid(op, 5, 4), 16)
                CamCmdPending = False

                '----zoom is currently active
                If PendingZoom <> 0 Then
                    mLog.Text = "Z:" & ta & ">" & PendingZoom
                    If PzDir = -1 Then
                        'If (ta < PendingZoom) Then SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0
                        If (ta <= PendingZoom) Then
                            SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0
                            If Math.Abs(px - PendingPan) < 100 And Math.Abs(py - PendingTilt) < 100 Then
                                SendCamCmdAddr(PzAddr, "PTS5050") : PendingPan = 0 : PendingTilt = 0 'stop pt only if small distance still to go
                            End If
                        End If
                    Else
                        'If (ta > PendingZoom) Then SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0
                        If (ta >= PendingZoom) Then
                            SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0
                            If Math.Abs(px - PendingPan) < 100 And Math.Abs(py - PendingTilt) < 100 Then
                                SendCamCmdAddr(PzAddr, "PTS5050") : PendingPan = 0 : PendingTilt = 0 'stop pt only if small distance still to go
                            End If
                        End If
                    End If
                End If
                '----pan/tilt is currently active
                If PendingPan <> 0 Or PendingTilt <> 0 Then
                    If PendingZoom = 0 Then mLog.Text = "Z:STOP"
                    mLog.Text = mLog.Text & vbCrLf & "P:" & px & ">" & PendingPan
                    mLog.Text = mLog.Text & vbCrLf & "T:" & py & ">" & PendingTilt
                    If PendingPan <> 0 Then
                        If PpDir = -1 Then
                            If (px <= PendingPan) Then
                                SendCamCmdAddr(PzAddr, "P50") : PendingPan = 0
                                If Math.Abs(ta - PendingZoom) < 100 And Math.Abs(py - PendingTilt) < 100 Then
                                    SendCamCmdAddr(PzAddr, "T50") : PendingTilt = 0 'stop t only if small distance still to go
                                    SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0 'stop z only if small distance still to go
                                End If
                            End If
                        Else
                            If (px >= PendingPan) Then
                                SendCamCmdAddr(PzAddr, "P50") : PendingPan = 0
                                If Math.Abs(ta - PendingZoom) < 100 And Math.Abs(py - PendingTilt) < 100 Then
                                    SendCamCmdAddr(PzAddr, "T50") : PendingTilt = 0 'stop t only if small distance still to go
                                    SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0 'stop z only if small distance still to go
                                End If
                            End If
                        End If

                    End If
                    If PendingTilt <> 0 Then
                        If PtDir = -1 Then
                            If (py <= PendingTilt) Then
                                SendCamCmdAddr(PzAddr, "T50") : PendingTilt = 0
                                If Math.Abs(ta - PendingZoom) < 100 And Math.Abs(px - PendingPan) < 100 Then
                                    SendCamCmdAddr(PzAddr, "P50") : PendingPan = 0 'stop t only if small distance still to go
                                    SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0 'stop z only if small distance still to go
                                End If
                            End If

                        Else
                            If (py >= PendingTilt) Then
                                SendCamCmdAddr(PzAddr, "T50") : PendingTilt = 0
                                If Math.Abs(ta - PendingZoom) < 100 And Math.Abs(px - PendingPan) < 100 Then
                                    SendCamCmdAddr(PzAddr, "P50") : PendingPan = 0 'stop t only if small distance still to go
                                    SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0 'stop z only if small distance still to go
                                End If
                            End If

                        End If
                        'If (PendingPan = 0 Or PendingTilt = 0) And PendingZoom <> 0 And Math.Abs(ta - PendingZoom) < 100 Then
                        '    SendCamCmdAddr(PzAddr, "Z50") : PendingZoom = 0
                        '    SendCamCmdAddr(PzAddr, "PTS5050") : PendingPan = 0 : PendingTilt = 0
                        'End If
                        'If PendingZoom = 0 And Math.Abs(py - PendingTilt) < 100 Then
                        '    SendCamCmdAddr(PzAddr, "T50") : PendingTilt = 0
                        'End If
                    End If

                End If

            End If
        End If

        'check for serial port full buffer - if this happens the serial int will stop firing so empty the buffer
        If (SerialTimeout > 0) Then
            SerialTimeout = SerialTimeout - 1
            If SerialTimeout = 0 And SerialPort1.IsOpen Then
                SerialPort1.DiscardInBuffer()
            End If
        End If

        'rotary encoder speed timers
        If EncoderATime < 100 Then EncoderATime = EncoderATime + 1
        If EncoderBTime < 100 Then EncoderBTime = EncoderBTime + 1

        'program close safety timer
        If (ProgCloseTimer > 0) Then
            ProgCloseTimer = ProgCloseTimer - 1
            If (ProgCloseTimer = 0) Then Button1.ForeColor = Color.Black
        End If
        LabelProfile.Text = PresetFileName

        'cam shutdown timer on prog close
        If (ShutDownTimer > 0) Then
            ShutDownTimer = ShutDownTimer + 1
        End If
        If (ShutDownTimer = 2) And GetSetting("CCNCamControl", "Set", "CamStandby", True) = True Then 'put cams into standby
            Timer1.Enabled = False
            GroupBox1.Show()
            GroupBox1.Left = 100 : GroupBox1.Top = 100
            ShowMsgBox("Closing down cameras... wait")
            SendCamCmdAddr(1, "O0")
            SendCamCmdAddr(2, "O0")
            SendCamCmdAddr(3, "O0")
            SendCamCmdAddr(4, "O0")
            SendCamCmdAddr(5, "O0")
            GroupBox1.Refresh()
            Timer1.Enabled = True
        End If
        If ShutDownTimer = 30 Then ShowMsgBox("Exit application...") : StoreSetupScreen()
        If ShutDownTimer = 50 Then Application.Exit()


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'ticks every 1 sec
        'check vmix status 
        Dim stat = SendVmixCmd("")
        ProcessStatus(stat)

        If StreamPending Then 'timer to holdoff streaming button presses while vmix is getting the stream going
            StreamPendingTime = StreamPendingTime + 1
            If (StreamPendingTime > 15) Then StreamPending = False : BtnOBSBroadcast.BackColor = Color.White
        End If

        If VmixInit = 1 Then 'flag for first startup with vmix. This is initially 0 then gets set to 1 when we get a valid response from vmix
            SendVmixCmd("?Function=SetVolumeFade&Input=Mix%20Audio%20Input&Value=100,1000") 'ensure audio is turned up
            SendVmixCmd("?Function=AudioOn&Input=Mix%20Audio%20Input") 'ensure audio is not muted
            VmixInit = 2 'set this so we don't do this again
        End If

        'check if cameras recording
        CamRecStatusTimer = CamRecStatusTimer + 1
        If CamRecStatusTimer > 60 Then CamRecStatusTimer = 0
        If CamRec(1) Or CamRecStatusTimer = 60 Then TextBoxCam1Rec.Text = CamRecStatus(SendCamQuery(1, "get_state"), 1)
        If CamRec(2) Or CamRecStatusTimer = 60 Then TextBoxCam2Rec.Text = CamRecStatus(SendCamQuery(2, "get_state"), 2)
        If CamRec(3) Or CamRecStatusTimer = 60 Then TextBoxCam3Rec.Text = CamRecStatus(SendCamQuery(3, "get_state"), 3)
        If CamRec(4) Or CamRecStatusTimer = 60 Then TextBoxCam4Rec.Text = CamRecStatus(SendCamQuery(4, "get_state"), 4)

        'check for change of windows screen setup / loss of connection to controller
        If Screen.AllScreens.Count <> ScreenCount Then
            ScreenCount = Screen.AllScreens.Count
            Dim scrfound = False
            If Screen.AllScreens.Count > 1 Then
                For Each scr In Screen.AllScreens
                    If scr.Bounds.Width = 1024 And scr.Bounds.Height = 600 Then
                        Me.FormBorderStyle = FormBorderStyle.None
                        Me.Bounds = scr.WorkingArea
                        scrfound = True
                    End If
                Next
                'Me.Bounds = (From scr In Screen.AllScreens Where Not scr.Primary)(0).WorkingArea 'open on 2nd monitor
                'Windows.Forms.Cursor.Hide()
                Me.Cursor = Cursors.Cross
            End If
            If scrfound = False Then
                Me.Height = 600 : Me.Width = 1024 'size the same as it would be on the mini touch screen
                Me.FormBorderStyle = FormBorderStyle.Sizable 'if no 2nd monitor, open sizeable on main monitor
            End If
        End If

        'checking if touch is allocated to the right screen...
        'https://stackoverflow.com/questions/29215016/how-to-tell-touchscreens-from-regular-ones
        'Dim tabletDevicen As System.Windows.Input.Tablet.TabletDeviceCollection
        'For Each tabletDevice In System.Windows.Input.Tablet.TabletDevices
        'Only detect if it Is a touch Screen 
        'If (tabletDevice.Type == TabletDeviceType.Touch) Then
        'Return True;
        'Next

        'setting touch on the right screen
        'search->control panel
        'tablet pc settings
        'setup
        ' or: rundll32.exe shell32.dll,Control_RunDLL tabletpc.cpl @1


    End Sub


    '----------------------------------------------------------
    ' display mode buttons
    ' show the appropriate frame with controls
    '----------------------------------------------------------
    Sub ShowMode(mode)
        ModeBtnPresets.BackColor = Color.White
        ModeBtnCam.BackColor = Color.White
        ModeBtnSettings.BackColor = Color.White
        If (mode = 1) Then
            ModeBtnPresets.BackColor = Color.Red
            PresetPanel.Visible = True
            PresetPanel.Top = 0 : PresetPanel.Left = 120
            CamPanel.Visible = False
            SettingsPanel.Visible = False
            LineShapeMode1.Y2 = 0
            LineShapeMode2.Y1 = 110
            LineShapeMode3.Y1 = 110 : LineShapeMode3.Y2 = 110
            LineShapeMode4.Y1 = 110 : LineShapeMode4.Y2 = 110
        End If
        If (mode = 2) Then
            ModeBtnCam.BackColor = Color.Red
            PresetPanel.Visible = False
            CamPanel.Visible = True
            CamPanel.Top = 0 : CamPanel.Left = 120
            SettingsPanel.Visible = False
            LineShapeMode1.Y2 = 110
            LineShapeMode2.Y1 = 220
            LineShapeMode3.Y1 = 110 : LineShapeMode3.Y2 = 110
            LineShapeMode4.Y1 = 220 : LineShapeMode4.Y2 = 220
        End If
        If (mode = 3) Then
            ModeBtnSettings.BackColor = Color.Red
            PresetPanel.Visible = False
            CamPanel.Visible = False
            UpdateSetupScreen() 'load the current status
            SettingsPanel.Visible = True
            SettingsPanel.Top = 0 : SettingsPanel.Left = 120
            LineShapeMode1.Y2 = 220
            LineShapeMode2.Y1 = 330
            LineShapeMode3.Y1 = 220 : LineShapeMode3.Y2 = 220
            LineShapeMode4.Y1 = 330 : LineShapeMode4.Y2 = 330
        End If
    End Sub
    Private Sub ModeBtnPresets_Click(sender As Object, e As EventArgs) Handles ModeBtnPresets.Click
        ShowMode(1)
    End Sub
    Private Sub ModeBtnCam_Click(sender As Object, e As EventArgs) Handles ModeBtnCam.Click
        ShowMode(2)
    End Sub
    Private Sub ModeBtnSettings_Click(sender As Object, e As EventArgs) Handles ModeBtnSettings.Click
        ShowMode(3)
    End Sub



    '----------------------------------------------------------
    ' encoders
    ' click on encoder status area to change encoder allocation
    '----------------------------------------------------------
    Sub ShowEncoderAllocations()
        Select Case EncoderAllocation(1)
            Case 0 : LabelEncA.Text = "Focus"
            Case 1 : LabelEncA.Text = "Iris"
            Case 2 : LabelEncA.Text = "AGC"
            Case 3 : LabelEncA.Text = "AGC Limit"
            Case 4 : LabelEncA.Text = "AE Shift"
        End Select
        Select Case EncoderAllocation(2)
            Case 0 : LabelEncB.Text = "Focus"
            Case 1 : LabelEncB.Text = "Iris"
            Case 2 : LabelEncB.Text = "AGC"
            Case 3 : LabelEncB.Text = "AGC Limit"
            Case 4 : LabelEncB.Text = "AE Shift"
        End Select
    End Sub
    Sub ShowEncoderValues()
        Dim ad
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If (ad < 6) Then LabelEncStatus.Text = "CAM" & ad Else LabelEncStatus.Text = "---"
        Dim v As Double = 0
        Select Case EncoderAllocation(1)
            Case 0 : TextEncAStatus.Text = TextBoxFocus.Text : v = (EncoderValue(TextEncAStatus.Text) - 1365) / 2730 'min focus is 0x555 (1365) max is 0xFFF (4095)
            Case 1 : TextEncAStatus.Text = TextBoxIris.Text : v = (EncoderValue(TextEncAStatus.Text) - 1365) / 2730
            Case 2 : TextEncAStatus.Text = TextBoxAgc.Text : v = EncoderValue(TextEncAStatus.Text) / 48 'agc is 0 to 48db
            Case 3 : TextEncAStatus.Text = TextBoxAgcLimit.Text : v = (EncoderValue(TextEncAStatus.Text) - 6) / 48 'agc limit is 6 to 48db
            Case 4 : TextEncAStatus.Text = TextBoxAeShift.Text : v = (EncoderValue(TextEncAStatus.Text) + 10) / 20
        End Select
        If v < 0 Then v = 0 : If v > 1 Then v = 1
        If TextEncAStatus.Text = "Auto" Then DrawEncoderKnob(1, -1) Else DrawEncoderKnob(1, v)
        Select Case EncoderAllocation(2)
            Case 0 : TextEncBStatus.Text = TextBoxFocus.Text : v = (EncoderValue(TextEncBStatus.Text) - 1365) / 2730
            Case 1 : TextEncBStatus.Text = TextBoxIris.Text : v = (EncoderValue(TextEncBStatus.Text) - 1365) / 2730
            Case 2 : TextEncBStatus.Text = TextBoxAgc.Text : v = EncoderValue(TextEncBStatus.Text) / 48 'agc is 0 to 48db
            Case 3 : TextEncBStatus.Text = TextBoxAgcLimit.Text : v = (EncoderValue(TextEncBStatus.Text) - 6) / 48 'agc limit is 6 to 48db
            Case 4 : TextEncBStatus.Text = TextBoxAeShift.Text : v = (EncoderValue(TextEncBStatus.Text) + 10) / 20
        End Select
        If v < 0 Then v = 0 : If v > 1 Then v = 1
        If TextEncBStatus.Text = "Auto" Then DrawEncoderKnob(2, -1) Else DrawEncoderKnob(2, v)
        If TextEncAStatus.Text = "Auto" Then ControllerLedState(14) = ControllerLedState(14) Or 1 Else ControllerLedState(14) = ControllerLedState(14) And 254
        If TextEncBStatus.Text = "Auto" Then ControllerLedState(14) = ControllerLedState(14) Or 2 Else ControllerLedState(14) = ControllerLedState(14) And 253
    End Sub
    Function EncoderValue(txt) 'return 0 if the text field is not numeric (will be 'Auto')
        If IsNumeric(txt) Then
            EncoderValue = CInt(txt)
        Else
            If InStr(txt, "dB") <> 0 Then
                EncoderValue = CInt(Strings.Left(txt, InStr(txt, "dB") - 1))
            Else
                EncoderValue = 0
            End If
        End If
    End Function
    Private Sub DrawEncoderKnob(num, v)
        Dim g As Graphics
        Dim px As Single = PictureBox1.Width
        Dim py As Single = PictureBox1.Height
        If num = 1 Then
            g = PictureBox1.CreateGraphics
        Else
            g = PictureBox2.CreateGraphics
        End If
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.FillEllipse(Brushes.Black, New Rectangle(1, 1, px - 3, py - 3))
        Dim p As New Pen(Brushes.White)
        p.Width = 1
        g.DrawEllipse(p, New Rectangle(1, 1, px - 3, py - 3))
        'now draw the tick based on 0-1 value
        Dim ang As Double
        If v <> -1 Then '-1 is auto. if not auto, show typical volume knob with 0 down to the left and max down to the right
            ang = -v * 340
            ang = ang - 10
        Else 'if auto just show straight down
            ang = 0
        End If
        ang = ang * Math.PI / 180
        Dim mx As Single = px / 2 - 1
        Dim my As Single = py / 2 - 1
        Dim ex As Single = mx + (mx - 3) * Math.Sin(ang)
        Dim ey As Single = my + (my - 3) * Math.Cos(ang)
        p.Width = 4
        g.DrawLine(p, mx, my, ex, ey)

        'g.DrawEllipse(Brushes.White, New Rectangle(0, 0, 40, 40))
    End Sub
    Sub SetEncoderAllocation(num)
        PanelEncSelect.Left = 740 'move onto the screen
        PanelEncSelect.Top = 7
        PanelEncSelect.Visible = True
        ButtonEncFocus.BackColor = SystemColors.ButtonFace
        ButtonEncIris.BackColor = SystemColors.ButtonFace
        ButtonEncAgc.BackColor = SystemColors.ButtonFace
        ButtonEncAgcLimit.BackColor = SystemColors.ButtonFace
        ButtonEncAeShift.BackColor = SystemColors.ButtonFace
        Select Case EncoderAllocation(num)
            Case 0 : ButtonEncFocus.BackColor = Color.YellowGreen
            Case 1 : ButtonEncIris.BackColor = Color.YellowGreen
            Case 2 : ButtonEncAgc.BackColor = Color.YellowGreen
            Case 3 : ButtonEncAgcLimit.BackColor = Color.YellowGreen
            Case 4 : ButtonEncAeShift.BackColor = Color.YellowGreen
        End Select
        LabelEnc.Text = num
    End Sub
    Sub SetEncoderValue(enc As Integer, v As Integer, sp As Integer)
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        'Label30.Text = sp & ">" & v
        If (EncoderAllocation(enc) < 2) Then 'for focus and iris, use the speed of the encoder to jump larger amounts for higher speeds
            If (sp <= 1) Then 'fastest
                If (v < 4) Then v = v * 5 : Else v = v * 10
            ElseIf (sp = 2) Then
                v = v * 2
            End If
        End If
        'Label30.Text = Label30.Text & " = " & v
        Select Case EncoderAllocation(enc)
            Case 0 : SetFocus(ad, v + CamFocus(ad))
            Case 1 : SetIris(ad, v + CamIris(ad))
            Case 2 : SetAGC(ad, v + CamAgc(ad))
            Case 3 : SetAGCLimit(ad, v + CamAGCLimit(ad))
            Case 4 : SetAEShift(ad, v + CamAEShift(ad))
        End Select
    End Sub
    Sub EncoderClick(enc As Integer)
        Dim ad As Integer
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        Select Case EncoderAllocation(enc)
            Case 0 : If (BtnFocusAuto.BackColor = Color.White) Then BtnFocusSetAuto() Else BtnFocusSetLock()
            Case 1 : If (MyButtonAutoIris.BackColor = Color.White) Then BtnIrisAuto() Else SetIris(ad, CamIris(ad))
            Case 2 : If (MyButtonAutoAgc.BackColor = Color.White) Then BtnAgcAuto() Else SetAGC(ad, CamAgc(ad))
            Case 3 : SetAGCLimit(ad, 1)
            Case 4 : SetAEShift(ad, 0)
        End Select
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        SetEncoderAllocation(1)
    End Sub
    Private Sub TextEncAStatus_Click(sender As Object, e As EventArgs) Handles TextEncAStatus.Click
        SetEncoderAllocation(1)
    End Sub
    Private Sub LabelEncA_Click(sender As Object, e As EventArgs) Handles LabelEncA.Click
        SetEncoderAllocation(1)
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        SetEncoderAllocation(2)
    End Sub
    Private Sub TextEncBStatus_Click(sender As Object, e As EventArgs) Handles TextEncBStatus.Click
        SetEncoderAllocation(2)
    End Sub
    Private Sub LabelEncB_Click(sender As Object, e As EventArgs) Handles LabelEncB.Click
        SetEncoderAllocation(2)
    End Sub
    Private Sub ButtonEncFocus_Click(sender As Object, e As EventArgs) Handles ButtonEncFocus.Click, ButtonEncIris.Click, ButtonEncAgc.Click, ButtonEncAgcLimit.Click, ButtonEncAeShift.Click
        PanelEncSelect.Visible = False 'off the screen
        Dim num = CInt(LabelEnc.Text)
        Select Case sender.name
            Case "ButtonEncFocus" : EncoderAllocation(num) = 0
            Case "ButtonEncIris" : EncoderAllocation(num) = 1
            Case "ButtonEncAgc" : EncoderAllocation(num) = 2
            Case "ButtonEncAgcLimit" : EncoderAllocation(num) = 3
            Case "ButtonEncAeShift" : EncoderAllocation(num) = 4
        End Select
        ShowEncoderAllocations()
        ShowEncoderValues()
        WritePresetFile()
    End Sub


    '----------------------------------------------------------
    ' Setup screen functions
    ' 
    '----------------------------------------------------------

    Sub UpdateCameraLinkStatus()
        CamStatus(1) = CamIgnore(1)
        CamStatus(2) = CamIgnore(2)
        CamStatus(3) = CamIgnore(3)
        CamStatus(4) = CamIgnore(4)
        CamStatus(5) = CamIgnore(5)

        If CamStatus(1) = True Then LblCamStatus1.Text = "FAIL" Else LblCamStatus1.Text = "OK"
        If CamStatus(2) = True Then LblCamStatus2.Text = "FAIL" Else LblCamStatus2.Text = "OK"
        If CamStatus(3) = True Then LblCamStatus3.Text = "FAIL" Else LblCamStatus3.Text = "OK"
        If CamStatus(4) = True Then LblCamStatus4.Text = "FAIL" Else LblCamStatus4.Text = "OK"
        If CamStatus(5) = True Then LblCamStatus5.Text = "FAIL" Else LblCamStatus5.Text = "OK"
    End Sub

    '---Populate setup screen with current values
    Sub UpdateSetupScreen()
        Dim i As Integer
        ComboBoxSetupComport.Items.Clear() 'make sure we don't add multiples of the same comport
        For Each s In SerialPort.GetPortNames()
            ComboBoxSetupComport.Items.Add(s)
        Next s
        TextBoxIPCam1.Text = (GetSetting("CCNCamControl", "CamIP", "1", "192.168.1.91"))
        TextBoxIPCam2.Text = (GetSetting("CCNCamControl", "CamIP", "2", "192.168.1.92"))
        TextBoxIPCam3.Text = (GetSetting("CCNCamControl", "CamIP", "3", "192.168.1.93"))
        TextBoxIPCam4.Text = (GetSetting("CCNCamControl", "CamIP", "4", "192.168.1.94"))
        TextBoxIPCam5.Text = (GetSetting("CCNCamControl", "CamIP", "5", "192.168.1.95"))

        TextBoxPresetFilename.Text = PresetFileName
        TextBoxPresetFolder.Text = PresetFilePath
        i = ComboBoxSetupComport.FindString(GetSetting("CCNCamControl", "Comm", "2", "COM2"))
        ComboBoxSetupComport.SelectedIndex = i

        If TallyMode Then CheckBoxTally.Checked = True
        If AutoSwap Then CheckBoxAutoSwap.Checked = True
        If GetSetting("CCNCamControl", "Set", "Askprofile", True) = True Then CheckBoxProfile.Checked = True
        If GetSetting("CCNCamControl", "Set", "CamStandby", True) = True Then CheckBoxStandby.Checked = True

        If GetSetting("CCNCamControl", "Set", "Cam1Dis", False) = True Then CheckBoxCam1Dis.Checked = True Else CheckBoxCam1Dis.Checked = False
        If GetSetting("CCNCamControl", "Set", "Cam2Dis", False) = True Then CheckBoxCam2Dis.Checked = True Else CheckBoxCam2Dis.Checked = False
        If GetSetting("CCNCamControl", "Set", "Cam3Dis", False) = True Then CheckBoxCam3Dis.Checked = True Else CheckBoxCam3Dis.Checked = False
        If GetSetting("CCNCamControl", "Set", "Cam4Dis", False) = True Then CheckBoxCam4Dis.Checked = True Else CheckBoxCam4Dis.Checked = False
        If GetSetting("CCNCamControl", "Set", "Cam5Dis", False) = True Then CheckBoxCam5Dis.Checked = True Else CheckBoxCam5Dis.Checked = False

        If GetSetting("CCNCamControl", "Set", "SaveFocus", False) = True Then CheckBoxSaveFocus.Checked = True Else CheckBoxSaveFocus.Checked = False
        If GetSetting("CCNCamControl", "Set", "SaveIris", False) = True Then CheckBoxSaveIris.Checked = True Else CheckBoxSaveIris.Checked = False
        If GetSetting("CCNCamControl", "Set", "SaveAE", False) = True Then CheckBoxSaveAE.Checked = True Else CheckBoxSaveAE.Checked = False

        If CamInvert(1) Then CheckBoxInvert1.Checked = True
        If CamInvert(2) Then CheckBoxInvert2.Checked = True
        If CamInvert(3) Then CheckBoxInvert3.Checked = True
        If CamInvert(4) Then CheckBoxInvert4.Checked = True

        Media1TextBox.Text = MediaFiles(0)
        Media2TextBox.Text = MediaFiles(1)
        Media3TextBox.Text = MediaFiles(2)
        Media4TextBox.Text = MediaFiles(3)
        Media5TextBox.Text = MediaFiles(4)
        If MediaLoop(0) Then Media1LoopCheckBox.Checked = True Else Media1LoopCheckBox.Checked = False
        If MediaLoop(1) Then Media2LoopCheckBox.Checked = True Else Media2LoopCheckBox.Checked = False
        If MediaLoop(2) Then Media3LoopCheckBox.Checked = True Else Media3LoopCheckBox.Checked = False
        If MediaLoop(3) Then Media4LoopCheckBox.Checked = True Else Media4LoopCheckBox.Checked = False
        If MediaLoop(4) Then Media5LoopCheckBox.Checked = True Else Media5LoopCheckBox.Checked = False
        If MediaMute(0) Then Media1MuteCheckBox.Checked = True Else Media1MuteCheckBox.Checked = False
        If MediaMute(1) Then Media2MuteCheckBox.Checked = True Else Media2MuteCheckBox.Checked = False
        If MediaMute(2) Then Media3MuteCheckBox.Checked = True Else Media3MuteCheckBox.Checked = False
        If MediaMute(3) Then Media4MuteCheckBox.Checked = True Else Media4MuteCheckBox.Checked = False
        If MediaMute(4) Then Media5MuteCheckBox.Checked = True Else Media5MuteCheckBox.Checked = False

        UpdateCameraLinkStatus()
    End Sub

    '----Update globals / registry with edited values
    Sub StoreSetupScreen()
        SaveSetting("CCNCamControl", "CamIP", "1", TextBoxIPCam1.Text)
        SaveSetting("CCNCamControl", "CamIP", "2", TextBoxIPCam2.Text)
        SaveSetting("CCNCamControl", "CamIP", "3", TextBoxIPCam3.Text)
        SaveSetting("CCNCamControl", "CamIP", "4", TextBoxIPCam4.Text)
        SaveSetting("CCNCamControl", "CamIP", "5", TextBoxIPCam5.Text)

        SaveSetting("CCNCamControl", "Set", "Tally", CheckBoxTally.Checked)
        SaveSetting("CCNCamControl", "Set", "Autoswap", CheckBoxAutoSwap.Checked)
        SaveSetting("CCNCamControl", "Set", "CamStandby", CheckBoxStandby.Checked)
        SaveSetting("CCNCamControl", "Set", "Askprofile", CheckBoxProfile.Checked)
        SaveSetting("CCNCamControl", "Set", "Caminvert1", CheckBoxInvert1.Checked)
        SaveSetting("CCNCamControl", "Set", "Caminvert2", CheckBoxInvert2.Checked)
        SaveSetting("CCNCamControl", "Set", "Caminvert3", CheckBoxInvert3.Checked)
        SaveSetting("CCNCamControl", "Set", "Caminvert4", CheckBoxInvert4.Checked)
        SaveSetting("CCNCamControl", "Set", "PresetsFile", TextBoxPresetFilename.Text)
        SaveSetting("CCNCamControl", "Set", "PresetsPath", TextBoxPresetFolder.Text)

        SaveSetting("CCNCamControl", "Set", "SaveFocus", CheckBoxSaveFocus.Checked)
        SaveSetting("CCNCamControl", "Set", "SaveIris", CheckBoxSaveIris.Checked)
        SaveSetting("CCNCamControl", "Set", "SaveAE", CheckBoxSaveAE.Checked)

        SaveSetting("CCNCamControl", "Set", "Cam1Dis", CheckBoxCam1Dis.Checked)
        SaveSetting("CCNCamControl", "Set", "Cam2Dis", CheckBoxCam2Dis.Checked)
        SaveSetting("CCNCamControl", "Set", "Cam3Dis", CheckBoxCam3Dis.Checked)
        SaveSetting("CCNCamControl", "Set", "Cam4Dis", CheckBoxCam4Dis.Checked)
        SaveSetting("CCNCamControl", "Set", "Cam5Dis", CheckBoxCam5Dis.Checked)

        PresetFileName = TextBoxPresetFilename.Text
        CamIP(1) = TextBoxIPCam1.Text
        CamIP(2) = TextBoxIPCam2.Text
        CamIP(3) = TextBoxIPCam3.Text
        CamIP(4) = TextBoxIPCam4.Text
        CamIP(5) = TextBoxIPCam5.Text

        'ReadPresetFile()
        If CheckBoxCam1Dis.Checked Then Cam1Dis = True Else Cam1Dis = False
        If CheckBoxCam2Dis.Checked Then Cam2Dis = True Else Cam2Dis = False
        If CheckBoxCam3Dis.Checked Then Cam3Dis = True Else Cam3Dis = False
        If CheckBoxCam4Dis.Checked Then Cam4Dis = True Else Cam4Dis = False
        If CheckBoxCam5Dis.Checked Then Cam5Dis = True Else Cam5Dis = False

        MediaFiles(0) = Media1TextBox.Text
        MediaFiles(1) = Media2TextBox.Text
        MediaFiles(2) = Media3TextBox.Text
        MediaFiles(3) = Media4TextBox.Text
        MediaFiles(4) = Media5TextBox.Text
        MediaLoop(0) = Media1LoopCheckBox.Checked
        MediaLoop(1) = Media2LoopCheckBox.Checked
        MediaLoop(2) = Media3LoopCheckBox.Checked
        MediaLoop(3) = Media4LoopCheckBox.Checked
        MediaLoop(4) = Media5LoopCheckBox.Checked
        MediaMute(0) = Media1MuteCheckBox.Checked
        MediaMute(1) = Media2MuteCheckBox.Checked
        MediaMute(2) = Media3MuteCheckBox.Checked
        MediaMute(3) = Media4MuteCheckBox.Checked
        MediaMute(4) = Media5MuteCheckBox.Checked

        For i = 0 To MediaMax
            SaveSetting("CCNCamControl", "MediaFiles", i, MediaFiles(i))
            SaveSetting("CCNCamControl", "MediaLoop", i, MediaLoop(i))
            SaveSetting("CCNCamControl", "MediaMute", i, MediaMute(i))
        Next

    End Sub

    '----update when control loses focus
    Sub SetupLostFocus() Handles TextBoxIPCam1.LostFocus, TextBoxIPCam2.LostFocus, TextBoxIPCam3.LostFocus, TextBoxIPCam4.LostFocus,
        TextBoxIPCam5.LostFocus, CheckBoxCam1Dis.Click, CheckBoxCam2Dis.Click, CheckBoxCam3Dis.Click, CheckBoxCam4Dis.Click, CheckBoxCam5Dis.Click,
        CheckBoxTally.Click, CheckBoxAutoSwap.Click, CheckBoxStandby.Click, CheckBoxProfile.Click, CheckBoxInvert1.Click, CheckBoxInvert2.Click, CheckBoxInvert3.Click, CheckBoxInvert4.Click,
        CheckBoxSaveFocus.Click, CheckBoxSaveIris.Click, CheckBoxSaveAE.Click, TextBoxPresetFilename.LostFocus, TextBoxPresetFolder.LostFocus

        StoreSetupScreen()
    End Sub
    Private Sub ComboBoxComport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxSetupComport.SelectedIndexChanged
        SaveSetting("CCNCamControl", "Comm", "2", ComboBoxSetupComport.SelectedItem)
        ComportOpen()
    End Sub

    '----Camera OSD buttons
    Sub SendOsdCmd(cmd As String)
        Dim ad
        If PTZLive = False Then ad = Addr Else ad = LiveAddr
        If ad > 5 Then Exit Sub
        SendCamQueryNoResponse(ad, "aw_cam?cmd=" & cmd & "&res=1")
    End Sub
    Private Sub ButtonOsdMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupMenu.Click
        SendOsdCmd("DUS: 0")
    End Sub

    Private Sub ButtonOSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupOsd.Click
        SendOsdCmd("DUS:1")
    End Sub

    Private Sub ButtonOsdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupEnter.Click
        SendOsdCmd("DIT")
    End Sub

    Private Sub ButtonOsdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupUp.Click
        SendOsdCmd("DUP")
    End Sub

    Private Sub ButtonOsdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupDown.Click
        SendOsdCmd("DDW")
    End Sub

    '----Setup file folder select
    Private Sub SetupFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupFilenameBrowse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Select presets file"
        fd.InitialDirectory = PresetFilePath
        fd.Filter = "Presets files (*.aps)|*.aps|All files (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            PresetFileName = fd.SafeFileName 'this is the filename without the path
            TextBoxPresetFilename.Text = PresetFileName
            ReadPresetFile()
        End If
    End Sub

    Private Sub SetupFolder_Click(sender As System.Object, e As System.EventArgs) Handles BtnSetupFolderBrowse.Click

        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.MyComputer
        dialog.SelectedPath = PresetFilePath
        dialog.Description = "Select folder for presets file"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PresetFilePath = dialog.SelectedPath & "\"
            TextBoxPresetFolder.Text = PresetFilePath
        End If
    End Sub

    Private Sub BtnSetupSaveNew_Click(sender As Object, e As EventArgs) Handles BtnSetupSaveNew.Click
        If TextBoxPresetNewFile.Text = "" Then ShowMsgBox("Enter a filename for the new preset file.")
        TextBoxPresetNewFile.Text = StrConv(TextBoxPresetNewFile.Text, VbStrConv.Lowercase)
        If Not InStr(TextBoxPresetNewFile.Text, ".apr") Then
            TextBoxPresetNewFile.Text = TextBoxPresetNewFile.Text & ".apr"
        End If
        PresetFileName = TextBoxPresetNewFile.Text
        WritePresetFile()
    End Sub

    '--- Retry cams. If cam is not detected, it is set to ignore, to avoid delays when waiting for response
    Private Sub ButtonRetryCam_Click(sender As Object, e As EventArgs) Handles ButtonRetryCam.Click
        CamIgnore(1) = False
        CamIgnore(2) = False
        CamIgnore(3) = False
        CamIgnore(4) = False
        Dim ta As Integer
        For ta = 1 To 4
            SendCamCmdAddr(ta, "O1") 'power on command
        Next
        UpdateCameraLinkStatus()
        CamCmdPending = False
        If Cam1Dis = False Then ReadbackCameraStates(1)
        UpdateCameraLinkStatus()
        If Cam2Dis = False Then ReadbackCameraStates(2)
        UpdateCameraLinkStatus()
        If Cam3Dis = False Then ReadbackCameraStates(3)
        UpdateCameraLinkStatus()
        If Cam4Dis = False Then ReadbackCameraStates(4)
        UpdateCameraLinkStatus()
        If Cam5Dis = False Then
            If SendCamQuery(5, "aw_ptz?cmd=%23O1&res=1") <> "" Then CamIgnore(5) = False Else CamIgnore(5) = True
        End If
        UpdateCameraLinkStatus()
    End Sub

    '-- Open the Windows Touch Screen utility (if touch is detected on the wrong monitor)
    Private Sub ButtonTouchscreen_Click(sender As Object, e As EventArgs) Handles ButtonTouchscreen.Click
        Shell("explorer.exe shell:::{80F3F1D5-FECA-45F3-BC32-752C152E456E}")
    End Sub

    '--- Show / hide the media setup dialog
    Private Sub BtnMediaSetup_Click(sender As Object, e As EventArgs) Handles BtnMediaSetup.Click
        MediaFilePanel.Left = 120
        MediaFilePanel.Top = 60
        MediaFilePanel.Visible = True
    End Sub

    Private Sub MediaFileClose_Click(sender As Object, e As EventArgs) Handles MediaFileClose.Click
        StoreSetupScreen()
        MediaFilePanel.Visible = False
        LoadMediaList()
        MediaItem = 0
        SetCurrentMediaItem()
    End Sub

    '--- Browse for mediaplayer files
    Private Sub BtnMedia1Browse_Click(sender As Object, e As EventArgs) Handles BtnMedia1Browse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        If fd.ShowDialog() = DialogResult.OK Then Media1TextBox.Text = fd.FileName
    End Sub
    Private Sub BtnMedia2Browse_Click(sender As Object, e As EventArgs) Handles BtnMedia2Browse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        If fd.ShowDialog() = DialogResult.OK Then Media2TextBox.Text = fd.FileName
    End Sub
    Private Sub BtnMedia3Browse_Click(sender As Object, e As EventArgs) Handles BtnMedia3Browse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        If fd.ShowDialog() = DialogResult.OK Then Media3TextBox.Text = fd.FileName
    End Sub
    Private Sub BtnMedia4Browse_Click(sender As Object, e As EventArgs) Handles BtnMedia4Browse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        If fd.ShowDialog() = DialogResult.OK Then Media4TextBox.Text = fd.FileName
    End Sub
    Private Sub BtnMedia5Browse_Click(sender As Object, e As EventArgs) Handles BtnMedia5Browse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        If fd.ShowDialog() = DialogResult.OK Then Media5TextBox.Text = fd.FileName
    End Sub



End Class
