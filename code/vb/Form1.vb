Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports WebSocket4Net




Public Class MainForm

    Dim VMixMode As Boolean = True
    Dim VMixError As Boolean = False
    Const BUFSIZE As Integer = 256
    Dim _serialPort As New SerialPort
    Dim buffer(BUFSIZE) As Byte
    Dim BufPutIndex As Integer = 0
    Dim BufGetIndex As Integer = 0
    Dim BufCount As Integer = 0
    Dim startuptimer As Integer = 0
    Dim ShutDownTimer As Integer = 0
    Dim ComCheckTimer As Integer = 18
    Dim addr As Integer
    Dim inpaddr As Integer
    Dim liveaddr As Integer
    Dim gotrx As Integer
    Dim kc As Integer
    Dim cdir As Integer
    Dim savemode As Boolean
    Dim PresetLegendMode As Integer = 0
    Dim atemconnect As Boolean = False
    Dim camconnect As Boolean
    Dim overlayactive As Boolean
    Dim mediaoverlayactive As Boolean
    Dim CaptionIndex As Integer = 1
    Dim VISMacrosConnection As New System.Net.Sockets.TcpClient()
    Dim ServerNetworkStream As NetworkStream
    Dim websocket As WebSocket4Net.WebSocket
    Dim OBSResponse As String
    Dim OBSRecState As Boolean
    Dim OBSStreamState As Boolean
    Dim OBSRecTime As String
    Dim OBSStreamTime As String
    Dim gain(8) As Integer
    Dim wblock(8) As Integer
    Dim DelayStop As Integer
    Dim DelayAddr As Integer
    Dim nextpreview As Integer
    Dim transitionwait As Integer
    Dim presetstate(8) As Integer
    Dim CamIris(8) As Integer
    Dim CamAgc(8) As Integer
    Dim CamAEShift(8) As Integer
    Dim CamAGCLimit(8) As Integer
    Dim CamWBRed(8) As Integer
    Dim CamWBBlue(8) As Integer
    Dim CamFocusManual(8) As Integer
    Dim CamFocus(8) As Integer
    Dim ProgCloseTimer As Integer = 0
    Dim OverlayWasActive As Integer = 0
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
    Dim AutoSongMode As Boolean = False
    Dim AutoSongPreload As Boolean = False
    Dim PrevAutoSongShot As Integer
    Dim AutoSpeechMode As Boolean = False
    Dim PrevAutoSpeech As Boolean = False
    Dim SingleAutoShot As Integer = 0
    Dim AutoPreset As Integer = 0
    Dim AutoWait As Integer = 0
    Dim CutLockoutTimer As Integer
    Dim ctrlkey As Boolean
    Dim CamOverride As Integer = 0
    Dim AudioFade As Integer
    Dim AudioLevel As Integer
    Dim MediaLevel As Integer
    Dim MediaNext As Boolean
    Dim PlayerAutoPause As Boolean
    Dim PlayerAutoNext As Boolean
    Dim PlayerLoop As Boolean
    Dim TieAux3 As Boolean = True
    Dim CurrentAux3 As Integer
    Dim PrevAux3 As Integer = 0
    Dim CamRec(4) As Boolean
    Dim CamRecStatusTimer As Integer = 0
    Dim CamCmdPending As Boolean = False
    Dim PipAddr As Integer = 0 'the input showing pip
    Dim MediaItem As Integer
    Dim MediaPlayerWasActive As Boolean = False
    Dim WebsocketID As Integer
    Dim Websocketwait As Boolean
    Dim WebsocketReinitTimer As Integer = 0
    Dim MovePresetMode As Integer = 0
    Dim MovePresetFrom As Integer = 0
    Dim PresetLoadStart As Integer = 0
    Dim PresetLoadFileCount As Integer = 0
    Dim EncoderAllocation(2) As Integer
    Dim WebsocketTimeout As Boolean = False
    Dim ScreenCount As Integer
    Dim StreamPending As Boolean = False
    Dim StreamPendingTime As Integer

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

    Dim LuaReturn As String
    Dim PipLive As Boolean

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

        OpenWebSocket()

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

        Globals.TallyMode = GetSetting("Atemswitcher", "Set", "Tally", False)
        Globals.AutoSwap = GetSetting("Atemswitcher", "Set", "Autoswap", True)
        Globals.PresetFilePath = GetSetting("Atemswitcher", "Set", "PresetsPath", Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\")))
        If Globals.PresetFilePath = "" Then Globals.PresetFilePath = Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\"))
        Globals.PresetFileName = GetSetting("Atemswitcher", "Set", "PresetsFile", "default.aps")
        If InStr(Globals.PresetFileName, "\") Then Globals.PresetFileName = Mid(Globals.PresetFileName, InStrRev(Globals.PresetFileName, "\") + 1)
        If Globals.PresetFileName = "" Then Globals.PresetFileName = "default.aps"
        Globals.CamInvert(1) = GetSetting("Atemswitcher", "Set", "Caminvert1", False)
        Globals.CamInvert(2) = GetSetting("Atemswitcher", "Set", "Caminvert2", False)
        Globals.CamInvert(3) = GetSetting("Atemswitcher", "Set", "Caminvert3", False)
        Globals.CamInvert(4) = GetSetting("Atemswitcher", "Set", "Caminvert4", False)

        Globals.Cam1Dis = GetSetting("Atemswitcher", "Set", "Cam1Dis", False)
        Globals.Cam2Dis = GetSetting("Atemswitcher", "Set", "Cam2Dis", False)
        Globals.Cam3Dis = GetSetting("Atemswitcher", "Set", "Cam3Dis", False)
        Globals.Cam4Dis = GetSetting("Atemswitcher", "Set", "Cam4Dis", False)
        Globals.Cam5Dis = GetSetting("Atemswitcher", "Set", "Cam5Dis", False)

        Globals.CamIP(1) = (GetSetting("Atemswitcher", "CamIP", "1", "192.168.1.91"))
        Globals.CamIP(2) = (GetSetting("Atemswitcher", "CamIP", "2", "192.168.1.92"))
        Globals.CamIP(3) = (GetSetting("Atemswitcher", "CamIP", "3", "192.168.1.93"))
        Globals.CamIP(4) = (GetSetting("Atemswitcher", "CamIP", "4", "192.168.1.94"))
        Globals.CamIP(5) = (GetSetting("Atemswitcher", "CamIP", "5", "192.168.1.95"))

        Globals.Cliptime(1) = (GetSetting("Atemswitcher", "Cliptime", "1", "60"))
        Globals.Cliptime(2) = (GetSetting("Atemswitcher", "Cliptime", "2", "60"))
        Globals.Cliptime(3) = (GetSetting("Atemswitcher", "Cliptime", "3", "60"))
        Globals.Cliptime(4) = (GetSetting("Atemswitcher", "Cliptime", "4", "60"))

        BtnFast.BackColor = Color.Green
        BtnLiveSlow.BackColor = Color.Green
        BtnAuxLock.BackColor = Color.Red
        SetDefaultPresets()
        'ReadPresetFile()
        ShowMode(1)
        EncoderAllocation(1) = 0 : EncoderAllocation(2) = 4
        ShowEncoderAllocations()
        SetCaptionText()

        'Process.Start("C:\atem_vb\VideoMessage\VideoMessage\bin\Debug\videomessage.exe")

    End Sub

    Private Sub MainForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If _serialPort.IsOpen Then _serialPort.Close()
        If SerialPort1.IsOpen Then SerialPort1.Close()
        'BackgroundWorker1.CancelAsync()
    End Sub

    '---Select preset file to load (touch friendly)
    Sub SelectPresetFile()
        'Exit Sub
        Dim aryFi As IO.FileInfo()
        Try
            Dim di As New IO.DirectoryInfo(Globals.PresetFilePath)
            aryFi = di.GetFiles("*.aps")
        Catch
            MsgBox("Preset file error")
            Dim di As New IO.DirectoryInfo("C:\")
            aryFi = di.GetFiles("*.aps")
        End Try
        Dim fi As IO.FileInfo
        Dim btnct As Integer = 0
        Dim i As Integer


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
    Private Sub PresetLoadClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PresetLoadClose.Click
        PresetLoadPanel.Visible = False
    End Sub
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
                Globals.PresetFileName = pfname
                SaveSetting("Atemswitcher", "Set", "PresetsFile", Globals.PresetFileName)
                ReadPresetFile()

                For i = 0 To PresetLoadFileCount - 1
                    Dim btn As Button = Me.Controls.Find("BtnPresetFile" + i.ToString(), True)(0)
                    PresetLoadPanel.Controls.Remove(btn)
                Next
                PresetLoadPanel.Visible = False
            End If
        End If
    End Sub

    '---my message box
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
    Private Sub MsgboxClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MsgBoxPanel.Click, MsgboxClose.Click
        MsgBoxPanel.Visible = False
        MsgBoxLabel.Text = "" 'clear the text when closed/hidden
    End Sub

    '---Make OBS scene name from addr
    Function ObsSourceName(ByVal oaddr As Integer) As String
        ObsSourceName = ""
        If oaddr = 1 Then ObsSourceName = "Cam1"
        If oaddr = 2 Then ObsSourceName = "Cam2"
        If oaddr = 3 Then ObsSourceName = "Cam3"
        If oaddr = 4 Then ObsSourceName = "Cam4"
        If oaddr = 5 Then ObsSourceName = "Cam5"
        If oaddr = 6 Then ObsSourceName = "Words"
        If oaddr = 7 Then ObsSourceName = "Mediaplayer1"
        If oaddr = 8 Then ObsSourceName = "Aux"
        If oaddr = 9 Then ObsSourceName = "Pip"
        If oaddr = 10 Then ObsSourceName = "Black"
        If oaddr = 21 Then ObsSourceName = "LeaderCaption"
        If oaddr = 22 Then ObsSourceName = "PreacherCaption"
        If oaddr = 23 Then ObsSourceName = "OtherCaption"

    End Function

    Private Sub OpenWebSocket()
        websocket = New WebSocket4Net.WebSocket("ws://localhost:4444/")
        'AddHandler websocket.Opened, Sub(s, e) socketOpened(s, e)
        'AddHandler websocket.Error, Sub(s, e) SocketError(s, e)
        'AddHandler websocket.Closed, Sub(s, e) socketClosed(s, e)
        AddHandler websocket.MessageReceived, Sub(s, ev) socketMessage(s, ev)
        AddHandler websocket.DataReceived, Sub(s, ev) socketDataReceived(s, ev)
        websocket.Open()

        WebsocketReinitTimer = 10
    End Sub

    Private Sub WebsocketSendAndWait(ByVal msg As String)
        If WebsocketTimeout = True Then Exit Sub
        Dim t As Integer = Now.TimeOfDay.TotalSeconds
        msg = Replace(msg, "TEST1", "WS" & WebsocketID)
        Websocketwait = True
        websocket.Send(msg)
        While Websocketwait
            Application.DoEvents()
            If (Now.TimeOfDay.TotalSeconds - t) > 5 Then
                ShowMsgBox("Can't connect to OBS")
                WebsocketTimeout = True
                Exit Sub
            End If
        End While
    End Sub

    Private Function GetWebRequest(ByVal url As String)
        Debug.Print(url)
        Dim request As WebRequest = WebRequest.Create(url)
        request.Timeout = 200
        Dim resp As WebResponse = request.GetResponse()
        Dim T As String
        Using r As StreamReader = New StreamReader(resp.GetResponseStream(), Encoding.ASCII)
            T = r.ReadToEnd()
        End Using
        GetWebRequest = T
    End Function

    Private Sub ReadMediaSources()
        ListBoxMedia.Items.Clear()
        websocket.Send("{""request-type"":""GetSceneList"",""message-id"":""GETSCENE""}")
    End Sub
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

    Private Function SendCamCmd(ByVal cmd As String)
        'Dim webClient As New System.Net.WebClient
        Dim url As String, result As String
        If addr = 0 Or addr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(addr) = True Then Return ""
        url = "http://" & Globals.CamIP(addr) & "/cgi-bin/aw_ptz?cmd=%23" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            'result = webClient.DownloadString(url)
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(addr) = True
            ShowMsgBox("Error sending to camera " & addr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    Private Function SendCamCmdNoHash(ByVal cmd As String, ByVal typ As String)
        'Dim webClient As New System.Net.WebClient
        Dim url As String, result As String
        If addr = 0 Or addr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(addr) = True Then Return ""
        If (typ = "") Then typ = "aw_ptz" 'aw_ptz for position, aw_cam for cam settings
        url = "http://" & Globals.CamIP(addr) & "/cgi-bin/" & typ & "?cmd=" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            'result = webClient.DownloadString(url)
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(addr) = True
            ShowMsgBox("Error sending to camera " & addr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    Private Function SendCamCmdAddr(ByVal caddr As Integer, ByVal cmd As String)
        'Dim webClient As New System.Net.WebClient
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        url = "http://" & Globals.CamIP(caddr) & "/cgi-bin/aw_ptz?cmd=%23" & cmd & "&res=1"
        result = ""
        Try
            'CamCmdPending = True
            'result = webClient.DownloadString(url)
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function
    Private Function SendCamCmdAddrNoHash(ByVal caddr As Integer, ByVal cmd As String, ByVal typ As String)
        'Dim webClient As New System.Net.WebClient
        'Dim webClient As New WebClientEx
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        'cmd = Replace(cmd, ":", "%3A")
        If (typ = "") Then typ = "aw_ptz" 'aw_ptz for position, aw_cam for cam settings
        url = "http://" & Globals.CamIP(caddr) & "/cgi-bin/" & typ & "?cmd=" & cmd & "&res=1"
        result = ""
        'webClient.Timeout = 500
        Try
            'CamCmdPending = True
            'result = webClient.DownloadString(url)
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    Function SendCamQuery(ByVal caddr As Integer, ByVal cmd As String)
        'Dim webClient As New System.Net.WebClient
        Dim url As String, result As String
        If caddr = 0 Or caddr > 5 Then Return ""
        'If CamCmdPending = True Then Return ""
        If CamIgnore(caddr) = True Then Return ""
        url = "http://" & Globals.CamIP(caddr) & "/cgi-bin/" & cmd
        result = ""
        Try
            'CamCmdPending = True
            'result = webClient.DownloadString(url)
            result = GetWebRequest(url)
        Catch ex As System.Net.WebException
            CamIgnore(caddr) = True
            ShowMsgBox("Error sending to camera " & caddr & " (" & ex.Message & ")")
        End Try
        'CamCmdPending = False
        Return result
    End Function

    Public Sub SendCamQueryNoResponse(ByVal caddr As Integer, ByVal cmd As String)
        Dim webClient As New System.Net.WebClient
        Dim url As String
        url = "http://" & Globals.CamIP(caddr) & "/cgi-bin/" & cmd
        webClient.DownloadString(url)
    End Sub


    '----------------------Read camera states back from cameras-----------------------------------------------------
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

    '----------------------Read presets back from file-----------------------------------------------------
    Sub ReadPresetFile()
        Dim TextFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser
        Try
            TextFileReader = My.Computer.FileSystem.OpenTextFieldParser(Globals.PresetFilePath & Globals.PresetFileName)
        Catch
            WritePresetFile()
            TextFileReader = My.Computer.FileSystem.OpenTextFieldParser(Globals.PresetFilePath & Globals.PresetFileName)
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
            Catch ex As  _
            Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While
        TextFileReader.Dispose()
        'read preset names for cam5. these are stored in the registry as the presets are fixed in the camera
        For i = 0 To 15
            PresetCaption(16 * 6 + i) = GetSetting("Atemswitcher", "Preset5", i, i + 1)
        Next
        UpdatePresets()
    End Sub

    Sub WritePresetFile()
        Dim file As System.IO.StreamWriter
        Dim i As Integer, j As Integer
        Dim ln As String
        Try
            file = My.Computer.FileSystem.OpenTextFileWriter(Globals.PresetFilePath & Globals.PresetFileName, False) 'false=no append
        Catch
            MsgBox("Could not write preset file " & Globals.PresetFilePath & Globals.PresetFileName)
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
            SaveSetting("Atemswitcher", "Preset5", i, PresetCaption(6 * 16 + i))
        Next
    End Sub

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

    Public Sub ComportOpen()
        'open com port for controller comms
        If SerialPort1.IsOpen Then SerialPort1.Close()
        SerialPort1.BaudRate = 19200
        SerialPort1.PortName = GetSetting("Atemswitcher", "Comm", "2", "COM2")
        Try
            SerialPort1.Open()
        Catch
            'TODO: if this fails then scan all the ports looking for the controller. If that fails then show status controller not connected
            'but retry the connect every 10sec
            ShowMsgBox("The controller com port " & SerialPort1.PortName & " cannot be opened.")
            'MsgBox("The controller com port " & SerialPort1.PortName & " cannot be opened.")
        End Try
    End Sub

    '---------------------------------------------------------------------------------
    'edit preset button caption

    Sub StartEditPresetDetails(ByVal index As Integer)
        TextBoxPresetEdit.Text = PresetCaption((addr - 1) * 16 + index - 1)
        TextBoxPresetEdit.Visible = True
        Dim btnx = ((index - 1) Mod 4)
        Dim btny = Int(((index - 1) / 4))
        TextBoxPresetEdit.Top = BtnPreset1.Top + BtnPreset1.Height * btny + 8
        TextBoxPresetEdit.Left = BtnPreset1.Left + BtnPreset1.Width * btnx + 8
        TextBoxPresetEdit.SelectAll()
        TextBoxPresetEdit.Focus()
    End Sub
    Sub EndEditPresetDetails()
        If PresetLegendMode = 999 Then 'we were waiting for a preset button to be selected. Just exit edit mode
            BtnEditPreset.BackColor = Color.White
            PresetLegendMode = 0
            Exit Sub
        End If
        If TextBoxPresetEdit.Visible = False Then
            Exit Sub 'another action may have already run this routine
        End If
        If (PresetLegendMode <> 0) Then PresetCaption((addr - 1) * 16 + PresetLegendMode - 1) = TextBoxPresetEdit.Text
        BtnEditPreset.BackColor = Color.White
        PresetLegendMode = 0
        TextBoxPresetEdit.Visible = False
        WritePresetFile()
        setactive()
    End Sub
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
    'Click on a preset button (may be recall, save or edit)
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
                If PresetLive = False Then ad = addr Else ad = liveaddr
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

        If savemode = False Then
            If PresetLegendMode = 0 Then
                'If AutoSongPreload = True And AutoPreset = 0 Then 'if in autosongmode and it has picked a preload, but user is picking a different preset, cancel the preload
                'If AutoPreset = 1 Then 'if last shot was autoselected, then disable transitions if user picks another preset
                'BtnPreload.BackColor = Color.White
                'PreloadPreset = 0
                'cdir = 0
                'SetLiveMoveIndicators()
                'UpdatePresets()
                'AutoSongPreload = False
                'End If
                AutoPreset = 0
                If PreloadPreset = 0 Then
                    '---Recall a preset either live or preview
                    If (addr = 5) Then
                        If index < 11 Then
                            SendCamCmd("R0" & index - 1) 'recall preset on camera for cam5
                            presetstate(addr) = 2 ^ (index - 1)
                            UpdatePresets() 'show presets for new cam
                        End If
                    End If
                    If ((PresetLive = False) And (addr < 5)) Or ((PresetLive = True) And (liveaddr < 5)) Then 'recall preset
                        'SendCamCmd("UPVS250")
                        If (addr = liveaddr) Or PresetLive = True Then 'live preset recall. attempt to go there slowly
                            ad = liveaddr
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
                            presetstate(ad) = 2 ^ (index - 1)
                            BtnLive.BackColor = Color.White : PresetLive = False
                        Else
                            cu = "101" 'preview cam move - move at fast speed (not max speed as that is quite noisy)
                            SendCamCmd("AXZ" & PresetZPos((addr - 1) * 16 + index - 1))
                            SendCamCmd("APS" & PresetXPos((addr - 1) * 16 + index - 1) & PresetYPos((addr - 1) * 16 + index - 1) & cu) 'last 3 set speed 1D=max 0-1-2 = slow med fast
                            presetstate(addr) = 2 ^ (index - 1)
                            PrevAutoSongShot = index
                        End If
                        UpdatePresets() 'show presets for new cam

                    End If
                Else 'preload preset mode
                    If (addr <= 4) Then
                        'If (PreloadPreset <> 0) Then
                        AutoSongPreload = False
                        PreloadPreset = index
                        UpdatePresets()
                        cdir = 0
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
            If (addr <= 4) Then
                op = SendCamCmd("GZ") 'get current zoom position
                op = Mid(op, 3)
                PresetZPos((addr - 1) * 16 + index - 1) = op
                op = SendCamCmd("APC") 'get current pt position
                op = Mid(op, 4)
                PresetXPos((addr - 1) * 16 + index - 1) = Mid(op, 1, 4)
                PresetYPos((addr - 1) * 16 + index - 1) = Mid(op, 5, 4)
                op = SendCamCmd("D1") 'get current autofocus state
                op = Mid(op, 3)
                If (op = "0") Then
                    op = SendCamCmd("GF") 'get current focus position
                    op = Mid(op, 3)
                    PresetFocus((addr - 1) * 16 + index - 1) = op
                Else
                    PresetFocus((addr - 1) * 16 + index - 1) = 9999
                End If
                op = SendCamCmdAddrNoHash(addr, "QSD:48", "aw_cam") 'get "contrast" setting
                PresetAE((addr - 1) * 16 + index - 1) = (Val(Mid(op, 8)) - 32) * 20 / 64
                op = SendCamCmdAddrNoHash(addr, "QRV", "aw_cam") 'get iris setting
                PresetIris((addr - 1) * 16 + index - 1) = Val("&H" & Mid(op, 5))

                If PresetCaption((addr - 1) * 16 + index - 1) = Convert.ToString(index) Then 'automatically ask for legend if the legend is just the initial number
                    PresetLegendMode = index
                    StartEditPresetDetails(index)
                End If
                presetstate(addr) = 2 ^ (index - 1)
                setactive()
            ElseIf addr = 5 Then
                If index < 11 Then
                    SendCamCmd("M0" & index - 1) 'store preset on camera for cam5
                    If PresetCaption((addr - 1) * 16 + index - 1) = Convert.ToString(index) Then 'automatically ask for legend if the legend is just the initial number
                        StartEditPresetDetails(index)
                    End If
                    presetstate(addr) = 2 ^ (index - 1)
                    setactive()
                End If
            End If
            savemode = 0
            WritePresetFile()
            BtnPresetSave.BackColor = Color.White

            End If
        'If _serialPort.IsOpen Then _serialPort.Write(buffer, 0, 7)
    End Sub

    Sub ShowCamValues()
        Dim ad As Integer
        If (PTZLive = False) Then ad = addr Else ad = liveaddr
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
    ' Set Leds on controller buttons
    ' ControllerLedState(0..13) sets colour bit0=red bit1=green bit2=blue
    '-----------------------------------------------------
    Sub SetControllerLedState(ByVal op)
        ControllerLedState(op - 1) = 0
        If addr = op Then ControllerLedState(op - 1) = ControllerLedState(op - 1) + 2 'green
        If liveaddr = op Then ControllerLedState(op - 1) = ControllerLedState(op - 1) + 1 'red
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
        If addr = liveaddr Then
            If addr = 1 Then BtnCam1.BackColor = Color.Yellow
            If addr = 2 Then BtnCam2.BackColor = Color.Yellow
            If addr = 3 Then BtnCam3.BackColor = Color.Yellow
            If addr = 4 Then BtnCam4.BackColor = Color.Yellow
            If addr = 5 Then BtnCam5.BackColor = Color.Yellow
            If addr = 6 Then BtnInp1.BackColor = Color.Yellow
            If addr = 7 Then BtnInp2.BackColor = Color.Yellow
            If addr = 8 Then BtnInp3.BackColor = Color.Yellow
            If addr = 9 Then BtnInp4.BackColor = Color.Yellow
            If addr = 10 Then BtnInp5.BackColor = Color.Yellow
        Else
            If addr = 1 Then BtnCam1.BackColor = Color.Green
            If addr = 2 Then BtnCam2.BackColor = Color.Green
            If addr = 3 Then BtnCam3.BackColor = Color.Green
            If addr = 4 Then BtnCam4.BackColor = Color.Green
            If addr = 5 Then BtnCam5.BackColor = Color.Green
            If addr = 6 Then BtnInp1.BackColor = Color.Green
            If addr = 7 Then BtnInp2.BackColor = Color.Green
            If addr = 8 Then BtnInp3.BackColor = Color.Green
            If addr = 9 Then BtnInp4.BackColor = Color.Green
            If addr = 10 Then BtnInp5.BackColor = Color.Green
            If liveaddr = 1 Then BtnCam1.BackColor = Color.Red
            If liveaddr = 2 Then BtnCam2.BackColor = Color.Red
            If liveaddr = 3 Then BtnCam3.BackColor = Color.Red
            If liveaddr = 4 Then BtnCam4.BackColor = Color.Red
            If liveaddr = 5 Then BtnCam5.BackColor = Color.Red
            If liveaddr = 6 Then BtnInp1.BackColor = Color.Red
            If liveaddr = 7 Then BtnInp2.BackColor = Color.Red
            If liveaddr = 8 Then BtnInp3.BackColor = Color.Red
            If liveaddr = 9 Then BtnInp4.BackColor = Color.Red
            If liveaddr = 10 Then BtnInp5.BackColor = Color.Red
        End If
        'controller button LEDs
        For i = 1 To 10
            SetControllerLedState(i)
        Next
        'tally
        If Globals.TallyMode Then
            SendCamCmdAddr(nextpreview, "DA0")
            SendCamCmdAddr(liveaddr, "DA1")
        End If
        'atem
        'If addr = 1 Then ExecuteLua("ATEMMixerMESetPreviewInput( 1,1," & Globals.AtemChannel(1) & " )") ' SDI1
        'If addr = 2 Then ExecuteLua("ATEMMixerMESetPreviewInput( 1,1," & Globals.AtemChannel(2) & " )") ' SDI2
        'If addr = 3 Then ExecuteLua("ATEMMixerMESetPreviewInput( 1,1," & Globals.AtemChannel(3) & " )") ' SDI3
        'If addr = 4 Then ExecuteLua("ATEMMixerMESetPreviewInput( 1,1," & Globals.AtemChannel(4) & " )") ' SDI4
        'obs
        If transitionwait = 0 Then
            If Not VMixMode Then
                If addr = 1 Then websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam1"",""message-id"":""TEST1""}")
                If addr = 2 Then websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam2"",""message-id"":""TEST1""}")
                If addr = 3 Then websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam3"",""message-id"":""TEST1""}")
                If addr = 4 Then websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam4"",""message-id"":""TEST1""}")
                If addr = 5 Then websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam5"",""message-id"":""TEST1""}")
            Else
                If addr <= 5 Then SendVmixCmd("?Function=PreviewInput&Input=" & ObsSourceName(addr))
            End If

        End If

        'cam settings
        If (addr <= 5) Then
            ShowCamValues()
            'load preset button captions
            UpdatePresets()
        End If

        'disable overlay if words are selected
        If (OverlayWasActive) Then BtnOverlay_Click(BtnOverlay, Nothing) : OverlayWasActive = 0
        'If (liveaddr = 6 And overlayactive) Then BtnOverlay_Click(BtnOverlay, Nothing) : OverlayWasActive = 1

        'turn off live control
        BtnLivePTZ.BackColor = Color.White
        PTZLive = False


    End Sub

    Sub UpdatePresets()
        Dim ad As Integer

        If PresetLive = False Then ad = addr Else ad = liveaddr
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
        If addr <> 5 Then
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
            If (presetstate(ad) And 1) <> 0 Then BtnPreset1.BackColor = Color.Green
            If (presetstate(ad) And 2) <> 0 Then BtnPreset2.BackColor = Color.Green
            If (presetstate(ad) And 4) <> 0 Then BtnPreset3.BackColor = Color.Green
            If (presetstate(ad) And 8) <> 0 Then BtnPreset4.BackColor = Color.Green
            If (presetstate(ad) And 16) <> 0 Then BtnPreset5.BackColor = Color.Green
            If (presetstate(ad) And 32) <> 0 Then BtnPreset6.BackColor = Color.Green
            If (presetstate(ad) And 64) <> 0 Then BtnPreset7.BackColor = Color.Green
            If (presetstate(ad) And 128) <> 0 Then BtnPreset8.BackColor = Color.Green
            If (presetstate(ad) And &H100) <> 0 Then BtnPreset9.BackColor = Color.Green
            If (presetstate(ad) And &H200) <> 0 Then BtnPreset10.BackColor = Color.Green
            If (presetstate(ad) And &H400) <> 0 Then BtnPreset11.BackColor = Color.Green
            If (presetstate(ad) And &H800) <> 0 Then BtnPreset12.BackColor = Color.Green
            If (presetstate(ad) And &H1000) <> 0 Then BtnPreset13.BackColor = Color.Green
            If (presetstate(ad) And &H2000) <> 0 Then BtnPreset14.BackColor = Color.Green
            If (presetstate(ad) And &H4000) <> 0 Then BtnPreset15.BackColor = Color.Green
            If (presetstate(ad) And &H8000) <> 0 Then BtnPreset16.BackColor = Color.Green
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

    Private Sub BtnCam1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCam1.Click, BtnCam2.Click, BtnCam3.Click, BtnCam4.Click, BtnCam5.Click
        Dim index As Integer
        index = Val(Mid(sender.name, 7))

        'If _serialPort.IsOpen Then _serialPort.Write(buffer, 0, 7)

        'cancel any preloads
        PreloadPreset = 0
        cdir = 0
        SetLiveMoveIndicators()
        UpdatePresets()

        addr = index
        BtnLive.BackColor = Color.White : PresetLive = False
        BtnLivePTZ.BackColor = Color.White : PTZLive = False
        setactive()

    End Sub

    Private Sub BtnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCut.Click
        If CutLockoutTimer > 0 Then Exit Sub
        If addr = 5 Then 'if we are cutting to black - mute audio out
            AudioFade = -1 ': AudioLevel = 0
        End If
        If liveaddr = 5 And addr <> 8 Then 'cutting away from black - restore audio
            AudioFade = 1
        End If
        If liveaddr = 8 Then MediaPlayerWasActive = True 'if cutting to mediaplayer then remember we were on it
        nextpreview = liveaddr
        'If addr <> nextpreview Then addr = nextpreview
        liveaddr = addr
        If (ObsSourceName(addr) <> "") And Not VMixMode Then
            If (overlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(addr) & """,""source"":""OpenLP"",""render"":true,""message-id"":""TEST1""}")
            If (mediaoverlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(addr) & """,""source"":""Caption"",""render"":true,""message-id"":""TEST1""}")
        End If
        StartLiveMove()
        'ExecuteLua("ATEMMixerMECut( 1,1 )")
        If Not VMixMode Then
            websocket.Send("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Cut"" } ,""message-id"":""TEST1""}")
        Else
            SendVmixCmd("?Function=Fade&Duration=10")
        End If

        'If Globals.AutoSwap Then addr = nextpreview
        If Globals.AutoSwap Then transitionwait = 5

        If (ObsSourceName(nextpreview) <> "") And Not VMixMode Then
            If (overlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(nextpreview) & """,""source"":""OpenLP"",""render"":false,""message-id"":""TEST1""}")
            If (mediaoverlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(nextpreview) & """,""source"":""Caption"",""render"":false,""message-id"":""TEST1""}")
        End If

        setactive()
        If AutoSongMode = True Or AutoSpeechMode = True Then AutoWait = 6
        CutLockoutTimer = 8
        DelayStop = 8
        AutoPreset = 0

    End Sub

    Private Sub BtnTransition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransition.Click
        If CutLockoutTimer > 0 Then Exit Sub

        If liveaddr = 8 Then MediaPlayerWasActive = True 'if cutting to mediaplayer then remember we were on it
        nextpreview = liveaddr
        liveaddr = addr
        If (ObsSourceName(addr) <> "") And Not VMixMode Then
            If (overlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(addr) & """,""source"":""OpenLP"",""render"":true,""message-id"":""TEST1""}")
            If (mediaoverlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(addr) & """,""source"":""Caption"",""render"":true,""message-id"":""TEST1""}")
        End If
        StartLiveMove()
        'ExecuteLua("ATEMMixerMEAutoTransition( 1,1 )")
        Dim ft As Double
        Double.TryParse(TextBox1.Text, ft)
        If Not VMixMode Then
            websocket.Send("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
        Else
            SendVmixCmd("?Function=Fade&Duration=500")
        End If
        If Globals.AutoSwap Then transitionwait = 5 + Val(TextBox1.Text) * 10

        If (ObsSourceName(nextpreview) <> "") And Not VMixMode Then
            If (overlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(nextpreview) & """,""source"":""OpenLP"",""render"":false,""message-id"":""TEST1""}")
            If (mediaoverlayactive) Then websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(nextpreview) & """,""source"":""Caption"",""render"":false,""message-id"":""TEST1""}")
        End If

        setactive()
        If AutoSongMode = True Or AutoSpeechMode = True Then AutoWait = transitionwait + 2
        CutLockoutTimer = transitionwait
        DelayStop = transitionwait
        AutoPreset = 0
    End Sub

    Private Sub BtnPresetSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPresetSave.Click
        If savemode = False Then
            BtnPresetSave.BackColor = Color.Red
            savemode = True
        Else
            BtnPresetSave.BackColor = Color.White
            savemode = False
        End If
    End Sub

    Private Sub BtnMovePreset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMovePreset.Click
        If (MovePresetMode = 0) Then
            MovePresetMode = 1
            BtnMovePreset.BackColor = Color.Red
        Else
            MovePresetMode = 0
            BtnMovePreset.BackColor = Color.White
        End If
    End Sub

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


    Private Sub BtnSlowIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlowIn.Click
        If PresetLive = False Then
            cdir = cdir Xor &H20
            If (cdir And &H20) Then cdir = cdir And Not &H40 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If cdir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(liveaddr, "Z51")
            Else
                SendCamCmdAddr(liveaddr, "Z60")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If

    End Sub

    Private Sub BtnSlowOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlowOut.Click
        If PresetLive = False Then
            cdir = cdir Xor &H40
            If (cdir And &H40) Then cdir = cdir And Not &H20 'cancel zoom in if zoom out set
            SetLiveMoveIndicators()
            If cdir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(liveaddr, "Z49")
            Else
                SendCamCmdAddr(liveaddr, "Z40")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub
    Private Sub BtnSlowPanL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSlowPanL.Click
        If PresetLive = False Then
            cdir = cdir Xor &H2
            If (cdir And &H2) Then cdir = cdir And Not &H4 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If cdir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(liveaddr, "PTS4800")
            Else
                SendCamCmdAddr(liveaddr, "PTS4500")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub

    Private Sub BtnSlowPanR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSlowPanR.Click
        If PresetLive = False Then
            cdir = cdir Xor &H4
            If (cdir And &H4) Then cdir = cdir And Not &H2 'cancel zoom out if zoom in set
            SetLiveMoveIndicators()
            If cdir <> 0 Then
                BtnPreload.BackColor = Color.Orange : PreloadPreset = 99
            Else
                BtnPreload.BackColor = Color.White : PreloadPreset = 0
            End If
            'PreloadPreset = 0 'if we set fixed zoom, cancel preset preload
            UpdatePresets()
        Else
            If LiveMoveSpeed = 0 Then
                SendCamCmdAddr(liveaddr, "PTS5200")
            Else
                SendCamCmdAddr(liveaddr, "PTS5500")
            End If
            BtnLive.BackColor = Color.White
            PresetLive = False
        End If
    End Sub


    Private Sub BtnInp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInp1.Click, BtnInp2.Click, BtnInp3.Click, BtnInp4.Click, BtnInp5.Click
        Dim index = Val(Mid(sender.name, 7))
        Dim obssource = ObsSourceName(index)
        addr = index + 5
        If Not VMixMode Then
            websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
        Else
            SendVmixCmd("?Function=PreviewInput&Input=" & ObsSourceName(addr))
        End If
        setactive()
    End Sub

    Sub SetLiveMoveIndicators()
        If cdir And &H2 Then BtnSlowPanL.BackColor = Color.Orange Else BtnSlowPanL.BackColor = Color.White
        If cdir And &H4 Then BtnSlowPanR.BackColor = Color.Orange Else BtnSlowPanR.BackColor = Color.White
        If cdir And &H20 Then BtnSlowIn.BackColor = Color.Orange Else BtnSlowIn.BackColor = Color.White
        If cdir And &H40 Then BtnSlowOut.BackColor = Color.Orange Else BtnSlowOut.BackColor = Color.White
        If cdir = 0 And PreloadPreset = 0 Then BtnPreload.BackColor = Color.White
    End Sub

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
        If cdir = 0 Then Exit Sub
        'set slow zoom speed
        'If (cdir And &H1E) <> 0 Then
        'If cdir And &H20 Then SendCamCmd("Z60")
        'If cdir And &H40 Then SendCamCmd("Z40")
        'Else
        If LiveMoveSpeed = 0 Then
            If cdir And &H20 Then SendCamCmd("Z51")
            If cdir And &H40 Then SendCamCmd("Z49")
        Else
            If cdir And &H20 Then SendCamCmd("Z60")
            If cdir And &H40 Then SendCamCmd("Z40")
        End If
        'End If
        'If _serialPort.IsOpen Then _serialPort.Write(buffer, 0, 7)
        'Threading.Thread.Sleep(20)
        'output the direction command
        If Globals.CamInvert(addr) Then  'inverted camera
            If (cdir And 2) <> 0 Then ncdir = ncdir Or 4
            If (cdir And 4) <> 0 Then ncdir = ncdir Or 2
            If (cdir And 8) <> 0 Then ncdir = ncdir Or 16
            If (cdir And 16) <> 0 Then ncdir = ncdir Or 8
            cdir = ncdir
        End If
        ps = "50" : ts = "50"
        If (cdir And 2) <> 0 Then ps = "55"
        If (cdir And 4) <> 0 Then ps = "45"
        If (cdir And 8) <> 0 Then ts = "55"
        If (cdir And 16) <> 0 Then ts = "45"
        SendCamCmd("PTS" & ps & ts)
        'If _serialPort.IsOpen Then _serialPort.Write(buffer, 0, 7)
        cdir = 0
        SetLiveMoveIndicators()
        BtnPreload.BackColor = Color.White : PreloadPreset = 0

    End Sub

    Private Sub BtnOverlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOverlay.Click
        'ExecuteLua("ATEMMixerDSKExecuteAutoTransition( 1,1 )") ' dsk 1
        Dim ft As Double
        Double.TryParse(TextBox2.Text, ft)
        'Words overlay. Set preview = current output with overlay in opposite state, start fade
        'At end of fade set preview back to user preview
        If overlayactive = False Then
            overlayactive = True
            If Not VMixMode Then
                If ObsSourceName(liveaddr) <> "" Then
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""source"":""OpenLP"",""render"":true,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
                End If
            Else
                SendVmixCmd("?Function=OverlayInput1In&Input=OpenLP")
            End If
        Else
            overlayactive = False
            If Not VMixMode Then
                If ObsSourceName(liveaddr) <> "" Then
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""source"":""OpenLP"",""render"":false,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
                End If
            Else
                SendVmixCmd("?Function=OverlayInput1Out&Input=OpenLP")
            End If
        End If
            If (overlayactive = True) Then BtnOverlay.BackColor = Color.Red Else BtnOverlay.BackColor = Color.White
        If (overlayactive = True) Then ControllerLedState(10) = 1 Else ControllerLedState(10) = 0
    End Sub

    Private Sub BtnMediaOverlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMediaOverlay.Click
        'ExecuteLua("ATEMMixerDSKExecuteAutoTransition( 1,2 )") ' dsk 1
        Dim ft As Double
        Double.TryParse(TextBox2.Text, ft)

        If mediaoverlayactive = False Then
            'media overlay was not previously active
            'swap preview source to current source and add the overlay
            If Not VMixMode Then
                If ObsSourceName(liveaddr) <> "" Then
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""source"":""Caption"",""render"":true,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
                End If
            Else
                SendVmixCmd("?Function=OverlayInput2In&Input=" & ObsSourceName(CaptionIndex + 20))
            End If

            ' websocket.Send("{""request-type"":""SetSourceFilterVisibility"",""sourceName"":""Caption"",""filterName"":""Color Correction"",""filterEnabled"":false,""message-id"":""TEST1""}")
            'websocket.Send("{""request-type"":""SetSourceRender"",""source"":""Caption"",""render"":true,""message-id"":""TEST1""}")
            mediaoverlayactive = True
        Else
            If Not VMixMode Then
                If ObsSourceName(liveaddr) <> "" Then
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""source"":""Caption"",""render"":false,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
                    WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
                End If
            Else
                SendVmixCmd("?Function=OverlayInput2Out&Input=" & ObsSourceName(CaptionIndex + 20))
            End If

            'websocket.Send("{""request-type"":""SetSourceFilterVisibility"",""sourceName"":""Caption"",""filterName"":""Color Correction"",""filterEnabled"":true,""message-id"":""TEST1""}")
            'websocket.Send("{""request-type"":""SetSourceRender"",""source"":""Caption"",""render"":false,""message-id"":""TEST1""}")
            mediaoverlayactive = False
        End If


        If (mediaoverlayactive = True) Then BtnMediaOverlay.BackColor = Color.Red Else BtnMediaOverlay.BackColor = Color.White
        If (mediaoverlayactive = True) Then ControllerLedState(11) = 1 Else ControllerLedState(11) = 0
    End Sub
    Sub CapRectangle(ByVal tb As Object)
        Dim l = tb.Left - 2 : Dim r = tb.Left + tb.Width + 2
        Dim t = tb.Top - 2 : Dim b = tb.Top + tb.Height + 2
        LineShapeCapL.X1 = l : LineShapeCapL.X2 = l : LineShapeCapT.X1 = l : LineShapeCapB.X1 = l
        LineShapeCapR.X1 = r : LineShapeCapR.X2 = r : LineShapeCapT.X2 = r : LineShapeCapB.X2 = r
        LineShapeCapL.Y1 = t : LineShapeCapR.Y1 = t : LineShapeCapT.Y1 = t : LineShapeCapT.Y2 = t
        LineShapeCapL.Y2 = b : LineShapeCapR.Y2 = b : LineShapeCapB.Y1 = b : LineShapeCapB.Y2 = b
    End Sub
    Private Sub SetCaptionText()
        If CaptionIndex = 1 Then
            CapRectangle(TextLeaderName)
            If Not VMixMode Then
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leader"",""text"":""Leader"",""message-id"":""TEST1""}")
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":""" & TextLeaderName.Text & """,""message-id"":""TEST1""}")
            End If
        End If
        If CaptionIndex = 2 Then
            CapRectangle(TextPreacherName)
            If Not VMixMode Then
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leader"",""text"":""Preacher"",""message-id"":""TEST1""}")
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":""   " & TextPreacherName.Text & """,""message-id"":""TEST1""}")
            End If

        End If
        If CaptionIndex = 3 Then
            CapRectangle(TextCaptionOther)
            If Not VMixMode Then
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leader"",""text"":""" & TextCaptionOther.Text & """,""message-id"":""TEST1""}")
                WebsocketSendAndWait("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":"""",""message-id"":""TEST1""}")
            End If
        End If
        If VMixMode Then
            Dim cap = WebUtility.HtmlEncode(TextLeaderName.Text)
            SendVmixCmd("?Function=SetText&Input=LeaderCaption&SelectedName=Name.Text&Value=" & cap)
            cap = WebUtility.HtmlEncode(TextPreacherName.Text)
            SendVmixCmd("?Function=SetText&Input=PreacherCaption&SelectedName=Name.Text&Value=" & cap)
            cap = WebUtility.HtmlEncode(TextCaptionOther.Text)
            SendVmixCmd("?Function=SetText&Input=OtherCaption&SelectedName=Name.Text&Value=" & cap)
        End If
    End Sub

    Private Sub BtnCapPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCPrev.Click
        If (CaptionIndex > 1) Then CaptionIndex = CaptionIndex - 1
        SetCaptionText()
        'ExecuteLua("ATEMMixerMPSetCaptionIndex(1,2," & CaptionIndex & ")")
    End Sub

    Private Sub BtnCapNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCNxt.Click
        If (CaptionIndex < 3) Then CaptionIndex = CaptionIndex + 1
        SetCaptionText()
        'ExecuteLua("ATEMMixerMPSetCaptionIndex(1,2," & CaptionIndex & ")")
    End Sub

    Private Sub TextLeaderName_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If Not VMixMode Then
            If CaptionIndex = 1 Then websocket.Send("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":""    " & TextLeaderName.Text & """,""message-id"":""TEST1""}")
        Else
            SetCaptionText()
        End If
    End Sub
    Private Sub TextPreacherName_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If Not VMixMode Then
            If CaptionIndex = 2 Then websocket.Send("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":""    " & TextPreacherName.Text & """,""message-id"":""TEST1""}")
        Else
        SetCaptionText()
        End If
    End Sub
    Private Sub TextCaptionOther_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If Not VMixMode Then
            If CaptionIndex = 3 Then websocket.Send("{""request-type"":""SetTextGDIPlusProperties"",""source"":""Leadername"",""text"":""    " & TextCaptionOther.Text & """,""message-id"":""TEST1""}")
        Else
        SetCaptionText()
        End If
    End Sub

    Private Sub BtnMPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMPrev.Click
        'websocket.Send("{""request-type"":""SetCurrentScene"",""scene-name"":""Mixer output"",""message-id"":""TEST1""}")
        If ListBoxMedia.Items.Count = 0 Then Exit Sub
        If MediaItem > 0 Then
            ListBoxMedia.Items.Item(MediaItem) = Replace(ListBoxMedia.Items.Item(MediaItem), "*", "")
            WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & ListBoxMedia.Items.Item(MediaItem) & """,""render"":false,""message-id"":""TEST1""}")
            MediaItem = MediaItem - 1
            WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & ListBoxMedia.Items.Item(MediaItem) & """,""render"":true,""message-id"":""TEST1""}")
            ListBoxMedia.Items.Item(MediaItem) = ListBoxMedia.Items.Item(MediaItem) & "*"
        End If
    End Sub
    Private Sub BtnMNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMNext.Click
        'websocket.Send("{""request-type"":""SetCurrentScene"",""scene-name"":""Loop"",""message-id"":""TEST1""}")
        If ListBoxMedia.Items.Count = 0 Then Exit Sub
        If MediaItem < ListBoxMedia.Items.Count - 1 Then
            ListBoxMedia.Items.Item(MediaItem) = Replace(ListBoxMedia.Items.Item(MediaItem), "*", "")
            WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & ListBoxMedia.Items.Item(MediaItem) & """,""render"":false,""message-id"":""TEST1""}")
            MediaItem = MediaItem + 1
            WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & ListBoxMedia.Items.Item(MediaItem) & """,""render"":true,""message-id"":""TEST1""}")
            ListBoxMedia.Items.Item(MediaItem) = ListBoxMedia.Items.Item(MediaItem) & "*"
        End If
    End Sub

    Private Sub TextBoxPipSrc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPipSrc.Click
        Select Case TextBoxPipSrc.Text
            'Case "CAM1" : TextBoxPipSrc.Text = "CAM2" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,7)")
            'Case "CAM2" : TextBoxPipSrc.Text = "CAM3" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,8")
            'Case "CAM3" : TextBoxPipSrc.Text = "CAM4" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,9)")
            'Case "CAM4" : TextBoxPipSrc.Text = "CAM5" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,4)")
            'Case "CAM5" : TextBoxPipSrc.Text = "Words" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,2)")
            'Case "Words" : TextBoxPipSrc.Text = "CAM1" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,6)")
            'Case Else : TextBoxPipSrc.Text = "Words" : ExecuteLua("ATEMMixerMEKeySetFillSource(1,1,1,2)")
        End Select
    End Sub


    Private Sub BtnPip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPip.Click

        If (BtnPip.BackColor = Color.Red) Then
            'pip is currently active
            BtnPip.BackColor = Color.White
            'If PipLive = True Then ExecuteLua("ATEMMixerMEKeySetOnAir(1,1,1,""FALSE"")")
            'ExecuteLua("ATEMMixerMESetNextTransitionLayers(1,1,""BACKGROUND"")")
            WebsocketSendAndWait("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(PipAddr) & """,""source"":""Pip"",""render"":false,""message-id"":""TEST1""}")
            If (PipAddr = liveaddr) Then 'if pip is currently active on live output, we need to do a transition to get it off
                Dim ft As Double
                Double.TryParse(TextBox1.Text, ft)
                WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(liveaddr) & """,""message-id"":""TEST1""}")
                WebsocketSendAndWait("{""request-type"":""TransitionToProgram"",""with-transition"": { ""name"":""Fade"", ""duration"":" & ft * 800 & " } ,""message-id"":""TEST1""}")
                WebsocketSendAndWait("{""request-type"":""SetPreviewScene"",""scene-name"":""" & ObsSourceName(addr) & """,""message-id"":""TEST1""}")
                'set preview back to what it should be
            End If
            PipAddr = 0
            PipLive = False
        Else
            'pip is not active
            BtnPip.BackColor = Color.Red
            'ExecuteLua("ATEMMixerMEKeySetOnAir(1,1,1,""TRUE"")")
            'ExecuteLua("ATEMMixerMESetNextTransitionLayers(1,1,""BACKGROUND, KEY1"")")
            PipAddr = addr
            websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""" & ObsSourceName(addr) & """,""source"":""Pip"",""render"":true,""message-id"":""TEST1""}")
        End If
    End Sub

    Private Sub BtnEditPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditPreset.Click
        If PresetLegendMode = 0 Then
            BtnEditPreset.BackColor = Color.Red
            PresetLegendMode = 999
        Else
            EndEditPresetDetails()
        End If
    End Sub

    Private Sub CheckBoxCU_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        setactive()
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        If ad <> 5 Then
            CamIris(ad) = CamIris(ad) + 10
        Else
            CamIris(ad) = CamIris(ad) + 64
        End If
        SetIris(ad, CamIris(ad))
    End Sub
    Private Sub BtnIrisAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAutoIris.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        If CamIris(ad) = 9999 Then 'iris was in auto mode
            SetIris(ad, 9998)
        Else
            SetIris(ad, 9999)
        End If
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        'op = SendCamCmdAddrNoHash(ad, "QGU") 'get gain setting
        'mLog.Text = op
        'CamAgc(ad) = Val("&H" & Mid(op, 5))
        CamAgc(ad) = CamAgc(ad) + 1
        SetAGC(ad, CamAgc(ad))
    End Sub
    Private Sub BtnAgcAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonAutoAgc.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad = 5 Then Return 'not provided on this camera
        If ad > 5 Then Exit Sub
        CamAGCLimit(ad) = CamAGCLimit(ad) - 1
        SetAGCLimit(ad, CamAGCLimit(ad))
    End Sub

    Private Sub BtnGainUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGainUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        CamAEShift(ad) = CamAEShift(ad) - 1
        SetAEShift(ad, CamAEShift(ad))
    End Sub

    Private Sub BtnAEShiftUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAEShiftUp.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
    Private Sub BtnFocusAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFocusAuto.Click
        Dim ad As Integer
        If (PTZLive = True) Then ad = liveaddr Else ad = addr
        If ad > 5 Then Exit Sub
        SendCamCmdAddr(ad, "D11")
        CamFocusManual(ad) = 0
        TextBoxFocus.Text = "Auto"
        BtnFocusAuto.BackColor = Color.Red : BtnFocusLock.BackColor = Color.White
        ShowEncoderValues()
    End Sub

    Private Sub BtnFocusLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFocusLock.Click
        Dim ad As Integer
        Dim op As String
        If (PTZLive = True) Then ad = liveaddr Else ad = addr
        If ad > 5 Then Exit Sub
        SendCamCmdAddr(ad, "D10")
        CamFocusManual(ad) = 1
        op = SendCamCmdAddr(ad, "GF")
        CamFocus(ad) = Val("&H" & Mid(op, 3))
        TextBoxFocus.Text = CamFocus(ad)
        BtnFocusAuto.BackColor = Color.White : BtnFocusLock.BackColor = Color.Red
        ShowEncoderValues()
    End Sub

    Private Sub BtnFocusUp_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnFocusUp.Click
        Dim ad As Integer
        If (PTZLive = True) Then ad = liveaddr Else ad = addr
        If ad > 5 Then Exit Sub
        CamFocus(ad) = CamFocus(ad) + 10
        SetFocus(ad, CamFocus(ad))
    End Sub

    Private Sub BtnFocusDn_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnFocusDn.Click
        Dim ad As Integer
        If (PTZLive = True) Then ad = liveaddr Else ad = addr
        If ad > 5 Then Exit Sub
        CamFocus(ad) = CamFocus(ad) - 10
        SetFocus(ad, CamFocus(ad))
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.ForeColor = Color.Red Then
            ShutDownTimer = 1
        Else
            Button1.ForeColor = Color.Red
            ProgCloseTimer = 100
        End If
    End Sub

    Private Sub CamFullTele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonFullTele.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z99") 'max speed zoom tele
    End Sub

    Private Sub CamFullWide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButtonFullWide.Click
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z01") 'max speed zoom wide
    End Sub


    Private Sub CamTele_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamTele.MouseDown
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        If BtnFast.BackColor = Color.Green Then
            mLog.Text = SendCamCmdAddr(ad, "Z95") 'zoom med tele
        Else
            mLog.Text = SendCamCmdAddr(ad, "Z55") 'zoom med tele
        End If
    End Sub
    Private Sub CamTele_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamTele.MouseUp
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z50") 'zoom stop
    End Sub

    Private Sub CamWide_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamWide.MouseDown
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        If BtnFast.BackColor = Color.Green Then
            mLog.Text = SendCamCmdAddr(ad, "Z05") 'zoom med wide
        Else
            mLog.Text = SendCamCmdAddr(ad, "Z45") 'zoom med wide
        End If
    End Sub
    Private Sub CamWide_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamWide.MouseUp
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "Z50") 'zoom stop
    End Sub

    Private Sub MyButtonCamUL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyButtonCamUL.MouseDown, MyButtonCamU.MouseDown, MyButtonCamUR.MouseDown, MyButtonCamL.MouseDown, MyButtonCamR.MouseDown, MyButtonCamDL.MouseDown, MyButtonCamD.MouseDown, MyButtonCamDR.MouseDown
        Dim index As String
        Dim ad As Integer
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If Globals.CamInvert(ad) Then xpos = -xpos : ypos = -ypos
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        mLog.Text = SendCamCmdAddr(ad, "PTS5050") 'pt stop
    End Sub

    Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
        BtnFast.BackColor = Color.Green
        BtnSlow.BackColor = Color.White
    End Sub

    Private Sub BtnSlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlow.Click
        BtnFast.BackColor = Color.White
        BtnSlow.BackColor = Color.Green
    End Sub


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
        AutoPreset = 0
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





    Private Sub OverrideBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverrideBtn.Click
        If CamOverride <> 0 Then
            OverrideBtn.BackColor = Color.White
            CamOverride = 0
        End If
    End Sub

    Private Sub BtnAuxLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAuxLock.Click
        If BtnAuxLock.BackColor = Color.Red Then
            BtnAuxLock.BackColor = Color.White
        Else
            BtnAuxLock.BackColor = Color.Red
        End If
    End Sub
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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form4.Show() 'the sd card file download form
    End Sub



    Private Sub BtnOBSIdent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'websocket.Send("{""request-type"":""SetCurrentScene"",""scene-name"":""Ident video"",""message-id"":""TEST1""}")
        'BtnMPrev.BackColor = Color.White
        'BtnOBSamintro.BackColor = Color.White
        'BtnOBSpmintro.BackColor = Color.White
        'BtnOBSIdent.BackColor = Color.Green
        'BtnMNext.BackColor = Color.White
        'If TieAux3 And PrevAux3 = 0 Then
        'PrevAux3 = CurrentAux3 'remember what it was set to
        'SetAux3(4) 'set foldback output to show OBS preview
        'End If

        'ClipRemainTime = Globals.Cliptime(3)
    End Sub



    Private Sub BtnOBSBroadcast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOBSBroadcast.Click
        'Dim ct As Integer
        'OBSResponse = ""
        'websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""OBSSTATE""}")
        'ct = 0
        'While OBSResponse = "" And ct < 1000000 : ct = ct + 1 : End While
        If Not VMixMode Then
            If OBSStreamState = False Then
                'BtnOBSBroadcast.BackColor = Color.Red
                websocket.Send("{""request-type"":""StartStopStreaming"",""message-id"":""OBSSET""}")
                StreamStartTime = Now.TimeOfDay.TotalSeconds
            Else
                'BtnOBSBroadcast.BackColor = Color.White
                websocket.Send("{""request-type"":""StartStopStreaming"",""message-id"":""OBSSET""}")
            End If
            websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""OBSSTATE""}")
        Else
            If StreamPending = False Then 'don't allow button click while pending
                If OBSStreamState = False Then StreamStartTime = Now.TimeOfDay.TotalSeconds : StreamPending = True : StreamPendingTime = 0 : BtnOBSBroadcast.BackColor = Color.Orange
                SendVmixCmd("?Function=StartStopStreaming")
            End If
        End If

    End Sub
    Sub GetOBSState()
        Dim ct As Integer
        OBSResponse = ""
        websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""TEST1""}")
        ct = 0
        While OBSResponse = "" And ct < 1000000 : ct = ct + 1 : End While

    End Sub
    Private Sub BtnOBSRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOBSRecord.Click
        'websocket.Send("{""request-type"":""StartRecording"",""message-id"":""TEST1""}")
        'Dim ct As Integer
        'OBSResponse = ""
        'websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""OBSSTATE""}")
        'ct = 0
        'While OBSResponse = "" And ct < 1000000 : ct = ct + 1 : End While
        If Not VMixMode Then
            If OBSRecState = False Then
                'BtnOBSRecord.BackColor = Color.Red
                websocket.Send("{""request-type"":""StartStopRecording"",""message-id"":""OBSSET""}")
                RecStartTime = Now.TimeOfDay.TotalSeconds
            Else
                'BtnOBSRecord.BackColor = Color.White
                websocket.Send("{""request-type"":""StartStopRecording"",""message-id"":""OBSSET""}")
            End If
            websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""OBSSTATE""}")
            'websocket.Send("{""request-type"":""SetHeartbeat"",""message-id"":""OBSHB""}")
            'websocket.Send("{""request-type"":""StartRecording"",""message-id"":""TEST""}")
        Else
            If OBSRecState = False Then RecStartTime = Now.TimeOfDay.TotalSeconds
            SendVmixCmd("?Function=StartStopRecording")
        End If
    End Sub


    Sub socketDataReceived(ByVal ss As Object, ByVal e As WebSocket4Net.DataReceivedEventArgs)
        Dim str As String
        str = Encoding.ASCII.GetString(e.Data)
        MsgBox("Got OBS message! " & str)
    End Sub

    'Sub socketOpened(ByVal s As Object, ByVal e As EventArgs)
    '    websocket.Send("{""ticks_history"":""R_50"",""end"":""latest"",""count"":10}")
    'End Sub

    'Sub socketClosed(ByVal s As Object, ByVal e As EventArgs)

    'End Sub

    'Sub socketError(ByVal s As Object, ByVal e As SuperSocket.ClientEngine.ErrorEventArgs)

    'End Sub

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

    Function xmlValue(xml As String, name As String)
        Dim p As Integer, v As String
        xmlValue = ""
        p = InStr(xml, "<" & name)
        If p = 0 Then Exit Function
        xml = Mid(xml, p + Len(name))
        v = Mid(xml, InStr(xml, ">") + 1)
        xmlValue = Strings.Left(v, InStr(v, "<") - 1)
    End Function

    Sub ProcessStatus(OBSResponse As String)
        Dim RecState As String = ""
        Dim StreamState As String = ""
        Dim SceneState As String = ""
        Dim litem As String
        Dim p As Integer, q As Integer, ct As Integer

        If Not VMixMode Then
            If InStr(OBSResponse, "OBSSTATE") <> 0 Then 'if this is a response to obs rec/stream status message
                RecState = jsonValue(OBSResponse, """recording""")
                If RecState = "" Or RecState = "false" Then OBSRecState = False Else OBSRecState = True
                If OBSRecState = True And BtnOBSRecord.BackColor <> Color.Red Then BtnOBSRecord.BackColor = Color.Red
                If OBSRecState = False And BtnOBSRecord.BackColor = Color.Red Then BtnOBSRecord.BackColor = Color.White
                StreamState = jsonValue(OBSResponse, """streaming""")
                If StreamState = "" Or StreamState = "false" Then OBSStreamState = False Else OBSStreamState = True
                If OBSStreamState = True And BtnOBSBroadcast.BackColor <> Color.Red Then BtnOBSBroadcast.BackColor = Color.Red
                If OBSStreamState = False And BtnOBSBroadcast.BackColor = Color.Red Then BtnOBSBroadcast.BackColor = Color.White
                If jsonValue(OBSResponse, """stream-timecode""") <> "" Then
                    'OBSStreamTime = Mid(OBSResponse, InStr(OBSResponse, "stream-timecode") + 19, 8)
                    Dim t As Integer = Now.TimeOfDay.TotalSeconds - StreamStartTime
                    Dim hr As Integer = Math.Floor(t / 3600)
                    Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                    Dim sec As Integer = t Mod 60
                    OBSStreamTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
                Else
                    OBSStreamTime = "..."
                End If
                TextBoxOBSBroadcastTime.Text = OBSStreamTime
                If jsonValue(OBSResponse, """rec-timecode""") <> "" Then
                    'OBSRecTime = Mid(OBSResponse, InStr(OBSResponse, "rec-timecode") + 16, 8)
                    Dim t As Integer = Now.TimeOfDay.TotalSeconds - RecStartTime
                    Dim hr As Integer = Math.Floor(t / 3600)
                    Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                    Dim sec As Integer = t Mod 60
                    OBSRecTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
                Else
                    OBSRecTime = "..."
                End If
                TextBoxOBSRecTime.Text = OBSRecTime
                'End If
            ElseIf jsonValue(OBSResponse, """OBSSCENE""") <> "" Then 'response as we are playing a clip. Watch out for it ending.
                If jsonValue(OBSResponse, """name""") <> "" Then
                    SceneState = jsonValue(OBSResponse, """name""")
                End If
            ElseIf InStr(OBSResponse, "PreviewSceneChanged") Then 'user has changed the preview scene on OBS
                'Dim scenename As String
                'scenename = Mid(OBSResponse, InStr(OBSResponse, "scene-name") + 14)
                'scenename = Mid(scenename, 1, InStr(scenename, """") - 1)
                'If (scenename = "Cam1") Then addr = 1 : setactive()
                'If (scenename = "Cam2") Then addr = 2 : setactive()
                'If (scenename = "Cam3") Then addr = 3 : setactive()
            ElseIf jsonValue(OBSResponse, """GETSCENE""") <> "" Then 'response to get scene list, used to populate media list
                SceneState = Mid(OBSResponse, InStr(OBSResponse, "Mediaplayer1"))
                SceneState = Mid(SceneState, InStr(SceneState, """sources"":") + 10)
                If InStr(SceneState, """sources"":") <> 0 Then SceneState = Mid(SceneState, 1, InStr(SceneState, """sources"":") - 40) 'if other scenes after this one, remove them
                Debug.Print(SceneState)
                p = 1 : ct = 0
                While p <> 0
                    p = InStr(SceneState, """name""")
                    If p <> 0 Then
                        litem = jsonValue(SceneState, """name""") 'Mid(SceneState, p + 9, q - p - 9)
                        litem = Replace(litem, """", "")
                        SceneState = Mid(SceneState, p + 9)
                        If ct = 0 Then
                            websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & litem & """,""render"":true,""message-id"":""TEST1""}")
                            litem = litem & "*"
                        Else
                            websocket.Send("{""request-type"":""SetSceneItemRender"",""scene-name"":""Mediaplayer1"",""source"":""" & litem & """,""render"":false,""message-id"":""TEST1""}")
                        End If
                        ListBoxMedia.Invoke(Sub() ListBoxMedia.Items.Add(litem))
                        ct = ct + 1
                    End If
                End While
            ElseIf jsonValue(OBSResponse, """WS" & WebsocketID & """") <> "" Then
                Websocketwait = False
                WebsocketID = WebsocketID + 1
            Else
                Debug.Print(OBSResponse)
            End If
        Else 'vmixmode
            If (Len(OBSResponse) > 20) Then
                RecState = xmlValue(OBSResponse, "recording")
                If RecState = "" Or RecState = "false" Then OBSRecState = False Else OBSRecState = True
                If OBSRecState = True And BtnOBSRecord.BackColor <> Color.Red Then BtnOBSRecord.BackColor = Color.Red
                If OBSRecState = False And BtnOBSRecord.BackColor = Color.Red Then BtnOBSRecord.BackColor = Color.White
                If OBSRecState = True Then
                    Dim t As Integer = Now.TimeOfDay.TotalSeconds - RecStartTime
                    Dim hr As Integer = Math.Floor(t / 3600)
                    Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                    Dim sec As Integer = t Mod 60
                    OBSRecTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
                Else
                    OBSRecTime = "..."
                End If
                TextBoxOBSRecTime.Text = OBSRecTime
                StreamState = xmlValue(OBSResponse, "streaming")
                If StreamState = "" Or StreamState = "false" Then
                    OBSStreamState = False
                Else
                    If OBSStreamState = False Then 'previously not streaming - just starting. Clear the streampending flag
                        If StreamPending Then StreamPending = False : StreamStartTime = Now.TimeOfDay.TotalSeconds
                    End If
                    OBSStreamState = True
                End If
                If OBSStreamState = True And BtnOBSBroadcast.BackColor <> Color.Red Then BtnOBSBroadcast.BackColor = Color.Red
                If OBSStreamState = False And BtnOBSBroadcast.BackColor = Color.Red Then BtnOBSBroadcast.BackColor = Color.White
                If StreamState = True Then
                    'OBSStreamTime = Mid(OBSResponse, InStr(OBSResponse, "stream-timecode") + 19, 8)
                    Dim t As Integer
                    t = Now.TimeOfDay.TotalSeconds - StreamStartTime
                    Dim hr As Integer = Math.Floor(t / 3600)
                    Dim min As Integer = (Math.Floor(t / 60)) Mod 60
                    Dim sec As Integer = t Mod 60
                    OBSStreamTime = hr.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
                Else
                    If Not StreamPending Then OBSStreamTime = "..." Else OBSStreamTime = "Starting..."
                End If
                TextBoxOBSBroadcastTime.Text = OBSStreamTime
            End If
            End If

    End Sub

    Sub socketMessage(ByVal s As Object, ByVal e As WebSocket4Net.MessageReceivedEventArgs)
        ProcessStatus(e.Message)
        'MsgBox(e.Message)
    End Sub

    '#########################################################################################################################################################################
    ' SERIAL PORT (PTZ controller)
    '#########################################################################################################################################################################
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

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim x As Byte, k As Byte, newserial As Byte
        Dim ad As Integer
        Dim op As String
        CheckForIllegalCrossThreadCalls = False 'allows us to write diagnostics to textbox on form
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

        If newserial = 1 And startuptimer > 50 Then
            ControlKeyState = SerialInBuf(0) + (SerialInBuf(1) * 128) + (SerialInBuf(2) * 512)
            EncoderA = SerialInBuf(3) + (SerialInBuf(4) * 128) + (SerialInBuf(5) * 512)
            If EncoderA > 32767 Then EncoderA = EncoderA - 65536
            If EncoderA = 0 Then EncoderAReset = 0
            EncoderB = SerialInBuf(6) + (SerialInBuf(7) * 128) + (SerialInBuf(8) * 512)
            If EncoderB > 32767 Then EncoderB = EncoderB - 65536
            If EncoderB = 0 Then EncoderBReset = 0
            JoyX = SerialInBuf(9) + (SerialInBuf(12) And 64) * 2
            'TextLeaderName.Text = JoyX
            'If (JoyX > 208) Then JoyX = 208
            'JoyX = JoyX * 255 / 208
            JoyY = SerialInBuf(10) + (SerialInBuf(12) And 32) * 4
            'TextPreacherName.Text = JoyY
            'If (JoyY > 202) Then JoyY = 202
            'JoyY = JoyY * 255 / 202
            JoyZ = SerialInBuf(11) + (SerialInBuf(12) And 16) * 8
            'TextCaptionOther.Text = JoyZ
            'JoyZ = JoyZ * 255 / 194
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

                If KeyHit Then
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
            Dim JoyDB As Byte = 8 'deadband of joystick
            'If JoyX < (128 - JoyDB) Or JoyX > (128 + JoyDB) Or JoyY < (128 - JoyDB) Or JoyY > (128 + JoyDB) Or JoyZ < (128 - JoyDB) Or JoyZ > (128 + JoyDB) Then

            Dim xpos As Integer, ypos As Integer, zpos As Integer, zoom As Boolean = False
            If PTZLive = False Then ad = addr Else ad = liveaddr
            If (CamOverride > 0) Then ad = CamOverride 'override the selected camera from the buttons
            If (ad < 5) Or ad = 7 Then
                xpos = 255 - JoyX
                ypos = JoyY
                zpos = JoyZ
                'If (xpos > 128 - JoyDB) And (xpos < 128 + JoyDB) Then
                'xpos = 128
                'Else
                'If (xpos < 128 - JoyDB) Then
                'xpos = xpos + JoyDB
                'Else
                'xpos = xpos - JoyDB
                'End If
                'End If
                'If (ypos > 128 - JoyDB) And (ypos < 128 + JoyDB) Then
                'ypos = 128
                'Else
                'If (ypos < 128 - JoyDB) Then
                '    ypos = ypos + JoyDB
                'Else
                'ypos = ypos - JoyDB
                'End If
                'End If
                'If (zpos > 128 - JoyDB) And (zpos < 128 + JoyDB) Then
                'zpos = 128
                'Else
                'If (zpos < 128 - JoyDB) Then
                'zpos = zpos + JoyDB
                'Else
                'zpos = zpos - JoyDB
                'End If
                'End If
                If Globals.CamInvert(ad) Then xpos = 255 - xpos : ypos = 255 - ypos
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


        Exit Sub

        While SerialPort1.BytesToRead > 0
            x = SerialPort1.ReadByte
            If (x = 255) Then
                serialcount = serialcount + 1
                'If serialcount >= 6 Then 'serial data thinning so we don't overwhelm the cameras
                If 1 Then
                    serialcount = 0
                    SerialInBufPtr = 0
                    JoyX = SerialInBuf(1)
                    JoyY = SerialInBuf(2)
                    JoyZ = SerialInBuf(3)
                    Key(0) = SerialInBuf(4)
                    Key(1) = SerialInBuf(5)
                    Key(2) = SerialInBuf(6)
                    REncode = SerialInBuf(7)
                    'diagnostic
                    'TextBox10.Text = SerialInBuf(1) & vbCrLf & SerialInBuf(2) & vbCrLf & SerialInBuf(3)
                    'TextBox11.Text = SerialInBuf(4) & vbCrLf & SerialInBuf(5) & vbCrLf & SerialInBuf(6) & vbCrLf & SerialInBuf(7)
                    'check for keypress
                    If PrevKey(0) <> Key(0) Or PrevKey(1) <> Key(1) Or PrevKey(2) <> Key(2) Then
                        If Key(0) > PrevKey(0) Then
                            KeyHit = True
                            x = Key(0) Xor PrevKey(0)
                            For k = 0 To 7
                                If (x And (2 ^ k)) <> 0 Then LastKey = k
                            Next k
                        End If
                        PrevKey(0) = Key(0)
                        If Key(1) > PrevKey(1) Then
                            KeyHit = True
                            x = Key(1) Xor PrevKey(1)
                            For k = 0 To 7
                                If (x And (2 ^ k)) <> 0 Then LastKey = k + 8
                            Next k
                        End If
                        PrevKey(1) = Key(1)
                        If Key(2) > PrevKey(2) Then
                            KeyHit = True
                            x = Key(2) Xor PrevKey(2)
                            For k = 0 To 7
                                If (x And (2 ^ k)) <> 0 Then LastKey = k + 16
                            Next k
                        End If
                        PrevKey(2) = Key(2)
                    End If
                    'check for encoder change
                    If REncode <> PrevEncode Then EncChange = True

                    'if 1-4 keypress then override cam operation
                    If (KeyHit) Then
                        mLog.Text = LastKey
                        KeyHit = False
                        If (LastKey = 11) Then
                            If (CamOverride <> 1) Then
                                'SerialPort1.Write(Chr(&HFF) & Chr(&H1) & Chr(&H0) & Chr(&H0) & Chr(&H0) & Chr(&H0) & Chr(&H0))
                                'SerialPort1.Write(Chr(&HFF) & Chr(&HFF) & Chr(&HFF))
                                CamOverride = 1
                                OverrideBtn.BackColor = Color.Orange
                            Else
                                CamOverride = 0
                                'SerialPort1.Write(Chr(&HFF) & Chr(&HAA) & Chr(&HAA))
                                'SerialPort1.Write(Chr(&HFF) & Chr(&H0) & Chr(&H0) & Chr(&H0) & Chr(&H0))
                                OverrideBtn.BackColor = Color.White
                            End If
                        End If
                        If (LastKey = 12) Then
                            If (CamOverride <> 2) Then
                                'SerialPort1.Write(&HFF & &H2 & &H0 & &H0)
                                'SerialPort1.Write(&HFF & &HAA & &HAA)
                                CamOverride = 2
                                OverrideBtn.BackColor = Color.Orange
                            Else
                                CamOverride = 0
                                OverrideBtn.BackColor = Color.White
                            End If
                        End If
                        If (LastKey = 13) Then
                            If (CamOverride <> 3) Then
                                'SerialPort1.Write(&HFF & &H4 & &H0)
                                CamOverride = 3
                                OverrideBtn.BackColor = Color.Orange
                            Else
                                CamOverride = 0
                                OverrideBtn.BackColor = Color.White
                            End If
                        End If
                        If (LastKey = 14) Then
                            If (CamOverride <> 4) Then
                                'SerialPort1.Write(&HFF & &H8 & &H0)
                                CamOverride = 4
                                OverrideBtn.BackColor = Color.Orange
                            Else
                                CamOverride = 0
                                OverrideBtn.BackColor = Color.White
                            End If
                        End If
                        If (LastKey = 15) Then
                            CamOverride = 0
                            OverrideBtn.BackColor = Color.White
                        End If
                    End If

                    'check for joystick being operated
                    'we will define a dead band at the centre of the joystick
                    Dim JoyDB As Byte = 8 'deadband of joystick
                    'If JoyX < (128 - JoyDB) Or JoyX > (128 + JoyDB) Or JoyY < (128 - JoyDB) Or JoyY > (128 + JoyDB) Or JoyZ < (128 - JoyDB) Or JoyZ > (128 + JoyDB) Then

                    Dim xpos As Integer, ypos As Integer, zpos As Integer, zoom As Boolean = False
                    If PTZLive = False Then ad = addr Else ad = liveaddr
                    If (CamOverride > 0) Then ad = CamOverride 'override the selected camera from the buttons
                    If (ad < 5) Or ad = 7 Then
                        xpos = JoyX
                        ypos = JoyY
                        zpos = 255 - JoyZ
                        'If (xpos > 128 - JoyDB) And (xpos < 128 + JoyDB) Then
                        'xpos = 128
                        'Else
                        'If (xpos < 128 - JoyDB) Then
                        'xpos = xpos + JoyDB
                        'Else
                        'xpos = xpos - JoyDB
                        'End If
                        'End If
                        'If (ypos > 128 - JoyDB) And (ypos < 128 + JoyDB) Then
                        'ypos = 128
                        'Else
                        'If (ypos < 128 - JoyDB) Then
                        '    ypos = ypos + JoyDB
                        'Else
                        'ypos = ypos - JoyDB
                        'End If
                        'End If
                        'If (zpos > 128 - JoyDB) And (zpos < 128 + JoyDB) Then
                        'zpos = 128
                        'Else
                        'If (zpos < 128 - JoyDB) Then
                        'zpos = zpos + JoyDB
                        'Else
                        'zpos = zpos - JoyDB
                        'End If
                        'End If
                        If Globals.CamInvert(ad) Then xpos = 255 - xpos : ypos = 255 - ypos
                        'JoyZ = zpos - JoyDB : JoyX = xpos - JoyDB : JoyY = ypos - JoyDB
                        'JoyZ = 1 + Int(JoyZ * 99 / (255 - JoyDB * 2))
                        If (zpos >= 128) Then JoyZ = 100 - zoomconvert(255 - zpos) Else JoyZ = zoomconvert(zpos)
                        If (JoyZ <> PrevJoyZ) Then
                            If (alreadysending = False) Then 'this function is reentrant. We need to make sure we are not already sending something from a previous command.
                                op = Format(JoyZ, "00")
                                alreadysending = True
                                SendCamCmdAddr(ad, "Z" & op)
                                PrevJoyZ = JoyZ 'only store the prev value if we actually send the new value
                                alreadysending = False
                            End If
                        End If
                        'JoyX = 1 + Int(JoyX * 99 / (255 - JoyDB * 2)) : JoyY = 1 + Int(JoyY * 99 / (255 - JoyDB * 2))
                        If (xpos >= 128) Then JoyX = 100 - joyconvert(255 - xpos) Else JoyX = joyconvert(xpos)
                        If (ypos >= 128) Then JoyY = 100 - joyconvert(255 - ypos) Else JoyY = joyconvert(ypos)
                        If (JoyX <> PrevJoyX) Or (JoyY <> PrevJoyY) Then
                            If alreadysending = False Then
                                op = Format(JoyX, "00") & Format(JoyY, "00")
                                alreadysending = True
                                SendCamCmdAddr(ad, "PTS" & op)
                                PrevJoyX = JoyX : PrevJoyY = JoyY
                                alreadysending = False
                            End If
                        End If
                        'mLog.Text = JoyX & ":" & JoyY & ":" & JoyZ
                    End If
                End If
            End If
            SerialInBuf(SerialInBufPtr) = x
            If SerialInBufPtr < 16 Then SerialInBufPtr = SerialInBufPtr + 1
        End While
    End Sub



    '#########################################################################################################################################################################
    ' TIMERS
    '#########################################################################################################################################################################

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ta As Integer
        Dim aux As Integer
        Dim op As String
        Dim px As Integer, py As Integer

        'timer to wait for camera serial bytes
        If (gotrx > 0) Then gotrx = gotrx - 1

        If (alreadysending > 0) Then alreadysending = alreadysending - 1

        'timer to autoconnect on startup
        If (startuptimer < 100) Then startuptimer = startuptimer + 1
        If startuptimer = 69 Then GroupBox1.Hide()
        If startuptimer = 99 Then MsgBoxPanel.Visible = False
        If (startuptimer = 5) Then 'open com ports
            Timer1.Enabled = False
            If GetSetting("Atemswitcher", "Set", "Askprofile", True) = True Then
                SelectPresetFile()
                'Dim fd As OpenFileDialog = New OpenFileDialog()

                'fd.Title = "Select presets file"
                'fd.InitialDirectory = Globals.PresetFilePath
                'fd.FileName = Globals.PresetFileName
                'fd.Filter = "Presets files (*.aps)|*.aps|All files (*.*)|*.*"
                'fd.FilterIndex = 1
                'fd.RestoreDirectory = True

                'If fd.ShowDialog() = DialogResult.OK Then
                ' Globals.PresetFileName = Mid(fd.FileName, InStrRev(fd.FileName, "\") + 1) 'this is the filename without the path
                ' Globals.PresetFilePath = Mid(fd.FileName, 1, InStrRev(fd.FileName, "\")) 'this is the filename without the path
                ' SaveSetting("Atemswitcher", "Set", "PresetsFile", Globals.PresetFileName)
                ' ReadPresetFile()
                'End If
            End If
            GroupBox1.Show()
            GroupBox1.Left = 100 : GroupBox1.Top = 100
            If ctrlkey Then Label22.Text = "EMERGENCY STARTUP MODE" & vbCrLf Else Label22.Text = ""
            Label22.Text = Label22.Text & "Profile: " & Globals.PresetFileName & vbCrLf
            Label22.Text = Label22.Text & "Opening com port..."
            ComportOpen()
            If (SerialPort1.IsOpen) Then
                Label22.Text = Label22.Text & "Done" & vbCrLf
            Else
                Label22.Text = Label22.Text & "Fail" & vbCrLf
            End If
            GroupBox1.Refresh()
            'also make sure OBS is in the right profile
            websocket.Send("{""request-type"":""SetCurrentProfile"",""profile-name"":""SJN Youtube live"",""message-id"":""TEST1""}")
            'and open the multiviewer
            'websocket.Send("{""request-type"":""OpenProjector"",""type"":""Multiview"",""monitor"":-1,""message-id"":""TEST1""}")

            Timer1.Enabled = True
        End If
        If (startuptimer = 10) Then 'connect to atem
            websocket.Send("{""request-type"":""SetCurrentScene"",""scene-name"":""Cam1"",""message-id"":""TEST1""}")
            'websocket.Send("{""request-type"":""SetPreviewScene"",""scene-name"":""Cam2"",""message-id"":""TEST1""}")
            'setactive()
            nextpreview = 2
            transitionwait = 2 'will set preview to 2
            SetCaptionText()
            '        Timer1.Enabled = False
            '        Label22.Text = Label22.Text & "Connecting to Atem..."
            '        bConnect_Click(Nothing, Nothing)
            '        If (atemconnect = True) Then Label22.Text = Label22.Text & "Done" & vbCrLf Else Label22.Text = Label22.Text & "Fail" & vbCrLf
            '        GroupBox1.Refresh()
            '        Timer1.Enabled = True
            ReadMediaSources()
        End If
        If (startuptimer = 15) Then
            Timer1.Enabled = False
            'If atemconnect = False Then CamIgnore(1) = True : CamIgnore(2) = True : CamIgnore(3) = True : CamIgnore(4) = True 'if atem connect fails, don't try to connect cameras
            For ta = 1 To 4
                SendCamCmdAddr(ta, "O1") 'power on command
            Next
            Timer1.Enabled = True

        End If
        If (startuptimer = 30) Then 'get/set camera defaults
            Timer1.Enabled = False
            For ta = 1 To 4

                Label22.Text = Label22.Text & "Initialise Camera " & ta & "..."
                GroupBox1.Refresh()
                ReadbackCameraStates(ta)
                If (CamIgnore(ta) = False) Then Label22.Text = Label22.Text & "Done" & vbCrLf Else Label22.Text = Label22.Text & "Fail" & vbCrLf
                If (ctrlkey = False) Then
                    'temporarily don't move the cameras on power up
                    'SendCamCmdAddr(ta, "APC80008000")
                    'SendCamCmdAddr(ta, "AXZ555")
                End If
            Next
            Label22.Text = Label22.Text & "Initialise Camera 5..." 'send power on command to he2 and check we get a response
            GroupBox1.Refresh()
            If Globals.Cam5Dis = False Then
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
            If Globals.Cam1Dis Then 'user disabled
                CamIgnore(1) = True
                'BtnCam1.Enabled = False 'lock out the button
                BtnCam1.Text = "CAM1 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(1) Then BtnCam1.Text = "CAM1 com-fail" Else BtnCam1.Text = "CAM1"
            End If

            If Globals.Cam2Dis Then 'user disabled
                CamIgnore(2) = True
                'BtnCam2.Enabled = False 'lock out the button
                BtnCam2.Text = "CAM2 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(2) Then BtnCam2.Text = "CAM2 com-fail" Else BtnCam2.Text = "CAM2"
            End If

            If Globals.Cam3Dis Then 'user disabled
                CamIgnore(3) = True
                'BtnCam3.Enabled = False 'lock out the button
                BtnCam3.Text = "CAM3 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(3) Then BtnCam3.Text = "CAM3 com-fail" Else BtnCam3.Text = "CAM3"
            End If

            If Globals.Cam4Dis Then 'user disabled
                CamIgnore(4) = True
                'BtnCam4.Enabled = False 'lock out the button
                BtnCam4.Text = "CAM4 Disabled"
            Else 'not user disabled but check for comm loss
                If CamIgnore(4) Then BtnCam4.Text = "CAM4 com-fail" Else BtnCam4.Text = "CAM4"
            End If

            If Globals.Cam5Dis Then 'user disabled
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
                If liveaddr <> 1 And addr <> 1 Then
                    SendCamCmdAddr(1, "PTS5050")
                    SendCamCmdAddr(1, "Z50")
                End If
                If liveaddr <> 2 And addr <> 2 Then
                    SendCamCmdAddr(2, "PTS5050")
                    SendCamCmdAddr(2, "Z50")
                End If
                If liveaddr <> 3 And addr <> 3 Then
                    SendCamCmdAddr(3, "PTS5050")
                    SendCamCmdAddr(3, "Z50")
                End If
                If liveaddr <> 4 And addr <> 4 Then
                    SendCamCmdAddr(4, "PTS5050")
                    SendCamCmdAddr(4, "Z50")
                End If
                'PendingZoom = 0 : PendingPan = 0 : PendingTilt = 0
            End If
        End If

        'timer to change preview after transition
        If transitionwait > 0 Then
            transitionwait = transitionwait - 1
            If transitionwait = 0 Then
                addr = nextpreview
                setactive()
                If MediaPlayerWasActive Then 'if we just transitioned away from media player, go to the next clip
                    MediaPlayerWasActive = False
                    BtnMNext.PerformClick()
                End If
            End If
        End If

        If WebsocketReinitTimer > 0 Then
            WebsocketReinitTimer = WebsocketReinitTimer - 1
        End If

        'timer to check for double presses of cut and fade, and also check that the live/prev cams match what we think they are
        If CutLockoutTimer > 0 Then
            CutLockoutTimer = CutLockoutTimer - 1
            If CutLockoutTimer = 0 Then
                'check that the preview and main outs are correct
                'If liveaddr >= 1 And liveaddr <= 4 Then
                'RequestLua("ATEMMixerMEGetProgramInput(1,1)") 'read prog input back from atem (comes back as <response>INTEGER:6</response>)
                'px = InStr(LuaReturn, "INTEGER:")
                'If (px <> 0) Then py = Val(Mid(LuaReturn, px + 8, 1))
                'If py <> liveaddr + 5 Then
                ''error!!! the live cam setting is wrong
                'ExecuteLua("ATEMMixerMESetProgramInput( 1,1," & liveaddr + 5 & " )")
                'Dim objWriter As New System.IO.StreamWriter("vblog.txt", True)
                'objWriter.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & " " & "AtemLive:" & py - 5 & " VBLive:" & liveaddr)
                'objWriter.Close()
                'End If
                'End If

            End If
        End If

        'pending zoom - check if reached desired pos or no longer live
        If PendingZoom <> 0 Or PendingPan <> 0 Or PendingTilt <> 0 Then
            If (liveaddr <> PzAddr) And DelayStop = 0 Then
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

        'check for serial port full buffer - if this happens the serial int will stop firing
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
        LabelProfile.Text = Globals.PresetFileName

        'cam shutdown timer on prog close
        If (ShutDownTimer > 0) Then
            ShutDownTimer = ShutDownTimer + 1
        End If
        If (ShutDownTimer = 2) And GetSetting("Atemswitcher", "Set", "CamStandby", True) = True Then 'put cams into standby
            Timer1.Enabled = False
            GroupBox1.Show()
            GroupBox1.Left = 100 : GroupBox1.Top = 100
            Label22.Text = "Closing down cameras..." & vbCrLf
            SendCamCmdAddr(1, "O0")
            SendCamCmdAddr(2, "O0")
            SendCamCmdAddr(3, "O0")
            SendCamCmdAddr(4, "O0")
            SendCamCmdAddr(5, "O0")
            'SendCamCmdAddr(1, "APC8000FFFF") 'central position lens fully down
            'SendCamCmdAddr(2, "APC8000FFFF")
            'SendCamCmdAddr(3, "APC8000FFFF")
            'SendCamCmdAddr(4, "APC8000FFFF")
            GroupBox1.Refresh()
            Timer1.Enabled = True
        End If
        If ShutDownTimer = 30 Then Label22.Text = Label22.Text & "Exit application..." & vbCrLf
        If ShutDownTimer = 50 Then Application.Exit()


    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'ticks every 1 sec
        'check OBS status (returns in websocket handler routine elsewhere)
        If Not VMixMode Then
            websocket.Send("{""request-type"":""GetStreamingStatus"",""message-id"":""OBSSTATE""}")
        Else
            Dim stat = SendVmixCmd("")
            ProcessStatus(stat)

            If StreamPending Then
                StreamPendingTime = StreamPendingTime + 1
                If (StreamPendingTime > 15) Then StreamPending = False : BtnOBSBroadcast.BackColor = Color.White
            End If
        End If

        'check if cameras recording
        CamRecStatusTimer = CamRecStatusTimer + 1
        If CamRecStatusTimer > 60 Then CamRecStatusTimer = 0
        If CamRec(1) Or CamRecStatusTimer = 60 Then TextBoxCam1Rec.Text = CamRecStatus(SendCamQuery(1, "get_state"), 1)
        If CamRec(2) Or CamRecStatusTimer = 60 Then TextBoxCam2Rec.Text = CamRecStatus(SendCamQuery(2, "get_state"), 2)
        If CamRec(3) Or CamRecStatusTimer = 60 Then TextBoxCam3Rec.Text = CamRecStatus(SendCamQuery(3, "get_state"), 3)
        If CamRec(4) Or CamRecStatusTimer = 60 Then TextBoxCam4Rec.Text = CamRecStatus(SendCamQuery(4, "get_state"), 4)

        'check for change of screens / loss of connection to controller
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If (ad < 6) Then LabelEncStatus.Text = "CAM" & ad Else LabelEncStatus.Text = "---"
        Select Case EncoderAllocation(1)
            Case 0 : TextEncAStatus.Text = TextBoxFocus.Text
            Case 1 : TextEncAStatus.Text = TextBoxIris.Text
            Case 2 : TextEncAStatus.Text = TextBoxAgc.Text
            Case 3 : TextEncAStatus.Text = TextBoxAgcLimit.Text
            Case 4 : TextEncAStatus.Text = TextBoxAeShift.Text
        End Select
        Select Case EncoderAllocation(2)
            Case 0 : TextEncBStatus.Text = TextBoxFocus.Text
            Case 1 : TextEncBStatus.Text = TextBoxIris.Text
            Case 2 : TextEncBStatus.Text = TextBoxAgc.Text
            Case 3 : TextEncBStatus.Text = TextBoxAgcLimit.Text
            Case 4 : TextEncBStatus.Text = TextBoxAeShift.Text
        End Select
        If TextEncAStatus.Text = "Auto" Then ControllerLedState(14) = ControllerLedState(14) Or 1 Else ControllerLedState(14) = ControllerLedState(14) And 254
        If TextEncBStatus.Text = "Auto" Then ControllerLedState(14) = ControllerLedState(14) Or 2 Else ControllerLedState(14) = ControllerLedState(14) And 253
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
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
        If PTZLive = False Then ad = addr Else ad = liveaddr
        If ad > 5 Then Exit Sub
        Select Case EncoderAllocation(enc)
            Case 0 : If (BtnFocusAuto.BackColor = Color.White) Then BtnFocusAuto.PerformClick() Else BtnFocusLock.PerformClick()
            Case 1 : If (MyButtonAutoIris.BackColor = Color.White) Then MyButtonAutoIris.PerformClick() Else SetIris(ad, CamIris(ad))
            Case 2 : If (MyButtonAutoAgc.BackColor = Color.White) Then MyButtonAutoAgc.PerformClick() Else SetAGC(ad, CamAgc(ad))
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
        Globals.CamStatus(1) = CamIgnore(1)
        Globals.CamStatus(2) = CamIgnore(2)
        Globals.CamStatus(3) = CamIgnore(3)
        Globals.CamStatus(4) = CamIgnore(4)
        Globals.CamStatus(5) = CamIgnore(5)

        If Globals.CamStatus(1) = True Then LblCamStatus1.Text = "FAIL" Else LblCamStatus1.Text = "OK"
        If Globals.CamStatus(2) = True Then LblCamStatus2.Text = "FAIL" Else LblCamStatus2.Text = "OK"
        If Globals.CamStatus(3) = True Then LblCamStatus3.Text = "FAIL" Else LblCamStatus3.Text = "OK"
        If Globals.CamStatus(4) = True Then LblCamStatus4.Text = "FAIL" Else LblCamStatus4.Text = "OK"
        If Globals.CamStatus(5) = True Then LblCamStatus5.Text = "FAIL" Else LblCamStatus5.Text = "OK"
    End Sub

    '---Populate setup screen with current values
    Sub UpdateSetupScreen()
        Dim i As Integer
        ComboBoxSetupComport.Items.Clear() 'make sure we don't add multiples of the same comport
        For Each s In SerialPort.GetPortNames()
            ComboBoxSetupComport.Items.Add(s)
        Next s
        TextBoxIPCam1.Text = (GetSetting("Atemswitcher", "CamIP", "1", "192.168.1.91"))
        TextBoxIPCam2.Text = (GetSetting("Atemswitcher", "CamIP", "2", "192.168.1.92"))
        TextBoxIPCam3.Text = (GetSetting("Atemswitcher", "CamIP", "3", "192.168.1.93"))
        TextBoxIPCam4.Text = (GetSetting("Atemswitcher", "CamIP", "4", "192.168.1.94"))
        TextBoxIPCam5.Text = (GetSetting("Atemswitcher", "CamIP", "5", "192.168.1.95"))

        TextBoxPresetFilename.Text = Globals.PresetFileName
        TextBoxPresetFolder.Text = Globals.PresetFilePath
        i = ComboBoxSetupComport.FindString(GetSetting("Atemswitcher", "Comm", "2", "COM2"))
        ComboBoxSetupComport.SelectedIndex = i

        If Globals.TallyMode Then CheckBoxTally.Checked = True
        If Globals.AutoSwap Then CheckBoxAutoSwap.Checked = True
        If GetSetting("Atemswitcher", "Set", "Askprofile", True) = True Then CheckBoxProfile.Checked = True
        If GetSetting("Atemswitcher", "Set", "CamStandby", True) = True Then CheckBoxStandby.Checked = True

        If GetSetting("Atemswitcher", "Set", "Cam1Dis", False) = True Then CheckBoxCam1Dis.Checked = True Else CheckBoxCam1Dis.Checked = False
        If GetSetting("Atemswitcher", "Set", "Cam2Dis", False) = True Then CheckBoxCam2Dis.Checked = True Else CheckBoxCam2Dis.Checked = False
        If GetSetting("Atemswitcher", "Set", "Cam3Dis", False) = True Then CheckBoxCam3Dis.Checked = True Else CheckBoxCam3Dis.Checked = False
        If GetSetting("Atemswitcher", "Set", "Cam4Dis", False) = True Then CheckBoxCam4Dis.Checked = True Else CheckBoxCam4Dis.Checked = False
        If GetSetting("Atemswitcher", "Set", "Cam5Dis", False) = True Then CheckBoxCam5Dis.Checked = True Else CheckBoxCam5Dis.Checked = False

        If GetSetting("Atemswitcher", "Set", "SaveFocus", False) = True Then CheckBoxSaveFocus.Checked = True Else CheckBoxSaveFocus.Checked = False
        If GetSetting("Atemswitcher", "Set", "SaveIris", False) = True Then CheckBoxSaveIris.Checked = True Else CheckBoxSaveIris.Checked = False
        If GetSetting("Atemswitcher", "Set", "SaveAE", False) = True Then CheckBoxSaveAE.Checked = True Else CheckBoxSaveAE.Checked = False

        If Globals.CamInvert(1) Then CheckBoxInvert1.Checked = True
        If Globals.CamInvert(2) Then CheckBoxInvert2.Checked = True
        If Globals.CamInvert(3) Then CheckBoxInvert3.Checked = True
        If Globals.CamInvert(4) Then CheckBoxInvert4.Checked = True

        UpdateCameraLinkStatus()
    End Sub

    '----Update globals / registry with edited values
    Sub StoreSetupScreen()
        SaveSetting("Atemswitcher", "CamIP", "1", TextBoxIPCam1.Text)
        SaveSetting("Atemswitcher", "CamIP", "2", TextBoxIPCam2.Text)
        SaveSetting("Atemswitcher", "CamIP", "3", TextBoxIPCam3.Text)
        SaveSetting("Atemswitcher", "CamIP", "4", TextBoxIPCam4.Text)
        SaveSetting("Atemswitcher", "CamIP", "5", TextBoxIPCam5.Text)

        SaveSetting("Atemswitcher", "Set", "Tally", CheckBoxTally.Checked)
        SaveSetting("Atemswitcher", "Set", "Autoswap", CheckBoxAutoSwap.Checked)
        SaveSetting("Atemswitcher", "Set", "CamStandby", CheckBoxStandby.Checked)
        SaveSetting("Atemswitcher", "Set", "Askprofile", CheckBoxProfile.Checked)
        SaveSetting("Atemswitcher", "Set", "Caminvert1", CheckBoxInvert1.Checked)
        SaveSetting("Atemswitcher", "Set", "Caminvert2", CheckBoxInvert2.Checked)
        SaveSetting("Atemswitcher", "Set", "Caminvert3", CheckBoxInvert3.Checked)
        SaveSetting("Atemswitcher", "Set", "Caminvert4", CheckBoxInvert4.Checked)
        SaveSetting("Atemswitcher", "Set", "PresetsFile", TextBoxPresetFilename.Text)
        SaveSetting("Atemswitcher", "Set", "PresetsPath", TextBoxPresetFolder.Text)

        SaveSetting("Atemswitcher", "Set", "SaveFocus", CheckBoxSaveFocus.Checked)
        SaveSetting("Atemswitcher", "Set", "SaveIris", CheckBoxSaveIris.Checked)
        SaveSetting("Atemswitcher", "Set", "SaveAE", CheckBoxSaveAE.Checked)

        SaveSetting("Atemswitcher", "Set", "Cam1Dis", CheckBoxCam1Dis.Checked)
        SaveSetting("Atemswitcher", "Set", "Cam2Dis", CheckBoxCam2Dis.Checked)
        SaveSetting("Atemswitcher", "Set", "Cam3Dis", CheckBoxCam3Dis.Checked)
        SaveSetting("Atemswitcher", "Set", "Cam4Dis", CheckBoxCam4Dis.Checked)
        SaveSetting("Atemswitcher", "Set", "Cam5Dis", CheckBoxCam5Dis.Checked)

        Globals.PresetFileName = TextBoxPresetFilename.Text
        Globals.CamIP(1) = TextBoxIPCam1.Text
        Globals.CamIP(2) = TextBoxIPCam2.Text
        Globals.CamIP(3) = TextBoxIPCam3.Text
        Globals.CamIP(4) = TextBoxIPCam4.Text
        Globals.CamIP(5) = TextBoxIPCam5.Text

        'ReadPresetFile()
        If CheckBoxCam1Dis.Checked Then Globals.Cam1Dis = True Else Globals.Cam1Dis = False
        If CheckBoxCam2Dis.Checked Then Globals.Cam2Dis = True Else Globals.Cam2Dis = False
        If CheckBoxCam3Dis.Checked Then Globals.Cam3Dis = True Else Globals.Cam3Dis = False
        If CheckBoxCam4Dis.Checked Then Globals.Cam4Dis = True Else Globals.Cam4Dis = False
        If CheckBoxCam5Dis.Checked Then Globals.Cam5Dis = True Else Globals.Cam5Dis = False
    End Sub

    '----update when control loses focus
    Sub SetupLostFocus() Handles TextBoxIPCam1.LostFocus, TextBoxIPCam2.LostFocus, TextBoxIPCam3.LostFocus, TextBoxIPCam4.LostFocus, _
        TextBoxIPCam5.LostFocus, CheckBoxCam1Dis.Click, CheckBoxCam2Dis.Click, CheckBoxCam3Dis.Click, CheckBoxCam4Dis.Click, CheckBoxCam5Dis.Click, _
        CheckBoxTally.Click, CheckBoxAutoSwap.Click, CheckBoxStandby.Click, CheckBoxProfile.Click, CheckBoxInvert1.Click, CheckBoxInvert2.Click, CheckBoxInvert3.Click, CheckBoxInvert4.Click, _
        CheckBoxSaveFocus.Click, CheckBoxSaveIris.Click, CheckBoxSaveAE.Click, TextBoxPresetFilename.LostFocus, TextBoxPresetFolder.LostFocus

        StoreSetupScreen()
    End Sub
    Private Sub ComboBoxComport_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxSetupComport.SelectedIndexChanged
        SaveSetting("Atemswitcher", "Comm", "2", ComboBoxSetupComport.SelectedItem)
        ComportOpen()
    End Sub

    '----Camera OSD buttons
    Sub SendOsdCmd(cmd As String)
        Dim ad
        If PTZLive = False Then ad = addr Else ad = liveaddr
        SendCamQueryNoResponse(ad, "aw_cam?cmd=" & cmd & "&res=1")
    End Sub
    Private Sub ButtonOsdMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetupMenu.Click
        SendOsdCmd("DUS:0")
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
        fd.InitialDirectory = Globals.PresetFilePath
        fd.Filter = "Presets files (*.aps)|*.aps|All files (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            Globals.PresetFileName = fd.SafeFileName 'this is the filename without the path
            TextBoxPresetFilename.Text = Globals.PresetFileName
            ReadPresetFile()
        End If
    End Sub

    Private Sub SetupFolder_Click(sender As System.Object, e As System.EventArgs) Handles BtnSetupFolderBrowse.Click

        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.MyComputer
        dialog.SelectedPath = Globals.PresetFilePath
        dialog.Description = "Select folder for presets file"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Globals.PresetFilePath = dialog.SelectedPath & "\"
            TextBoxPresetFolder.Text = Globals.PresetFilePath
        End If
    End Sub

    Private Sub BtnSetupSaveNew_Click(sender As Object, e As EventArgs) Handles BtnSetupSaveNew.Click
        If TextBoxPresetNewFile.Text = "" Then ShowMsgBox("Enter a filename for the new preset file.")
        TextBoxPresetNewFile.Text = StrConv(TextBoxPresetNewFile.Text, VbStrConv.Lowercase)
        If Not InStr(TextBoxPresetNewFile.Text, ".apr") Then
            TextBoxPresetNewFile.Text = TextBoxPresetNewFile.Text & ".apr"
        End If
        Globals.PresetFileName = TextBoxPresetNewFile.Text
        WritePresetFile()
    End Sub

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
        If Globals.Cam1Dis = False Then ReadbackCameraStates(1)
        UpdateCameraLinkStatus()
        If Globals.Cam2Dis = False Then ReadbackCameraStates(2)
        UpdateCameraLinkStatus()
        If Globals.Cam3Dis = False Then ReadbackCameraStates(3)
        UpdateCameraLinkStatus()
        If Globals.Cam4Dis = False Then ReadbackCameraStates(4)
        UpdateCameraLinkStatus()
        If Globals.Cam5Dis = False Then
            If SendCamQuery(5, "aw_ptz?cmd=%23O1&res=1") <> "" Then CamIgnore(5) = False Else CamIgnore(5) = True
        End If
        UpdateCameraLinkStatus()
    End Sub

    Private Sub ButtonTouchscreen_Click(sender As Object, e As EventArgs) Handles ButtonTouchscreen.Click
        Shell("explorer.exe shell:::{80F3F1D5-FECA-45F3-BC32-752C152E456E}")
    End Sub


    Private Sub ButtonRetryOBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRetryOBS.Click
        websocket.Close()   'try reconnecting to OBS
        WebsocketTimeout = False
        OpenWebSocket()
        While WebsocketReinitTimer > 0
            Application.DoEvents()
        End While
        ReadMediaSources()
    End Sub


End Class
