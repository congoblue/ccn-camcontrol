<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.eVISMacrosAppHost = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.mLog = New System.Windows.Forms.TextBox()
        Me.chkLogMessages = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBoxIris = New System.Windows.Forms.TextBox()
        Me.BtnIrisDown = New System.Windows.Forms.Button()
        Me.TextBoxAgc = New System.Windows.Forms.TextBox()
        Me.TextBoxAeShift = New System.Windows.Forms.TextBox()
        Me.TextBoxAgcLimit = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBoxWB = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ButtonSetup = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape11 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape10 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape9 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape8 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.BtnIrisUp = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BtnAGCDown = New System.Windows.Forms.Button()
        Me.BtnAGCUp = New System.Windows.Forms.Button()
        Me.BtnGainDown = New System.Windows.Forms.Button()
        Me.BtnGainUp = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnAEShiftDn = New System.Windows.Forms.Button()
        Me.BtnAEShiftUp = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BtnWbBlueUp = New System.Windows.Forms.Button()
        Me.BtnWbBlueDn = New System.Windows.Forms.Button()
        Me.BtnWbRedUp = New System.Windows.Forms.Button()
        Me.BtnWbRedDn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BtnFocusUp = New System.Windows.Forms.Button()
        Me.BtnFocusDn = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LabelProfile = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TextPlayerTime = New System.Windows.Forms.TextBox()
        Me.TextBoxCam1Rec = New System.Windows.Forms.TextBox()
        Me.TextBoxCam2Rec = New System.Windows.Forms.TextBox()
        Me.TextBoxCam3Rec = New System.Windows.Forms.TextBox()
        Me.TextBoxCam4Rec = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextBoxPipSrc = New System.Windows.Forms.TextBox()
        Me.ButtonRetryOBS = New System.Windows.Forms.Button()
        Me.PresetPanel = New System.Windows.Forms.Panel()
        Me.BtnCNxt = New CCNCamcontrol.MyButton()
        Me.BtnCPrev = New CCNCamcontrol.MyButton()
        Me.BtnSlowPanL = New CCNCamcontrol.MyButton()
        Me.BtnStop = New CCNCamcontrol.MyButton()
        Me.BtnSlowPanR = New CCNCamcontrol.MyButton()
        Me.TextBoxPresetEdit = New System.Windows.Forms.TextBox()
        Me.BtnMovePreset = New CCNCamcontrol.MyButton()
        Me.BtnEditPreset = New CCNCamcontrol.MyButton()
        Me.BtnPresetSave = New CCNCamcontrol.MyButton()
        Me.LabelCap3 = New System.Windows.Forms.Label()
        Me.TextCaptionOther = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.LabelCap2 = New System.Windows.Forms.Label()
        Me.LabelCap1 = New System.Windows.Forms.Label()
        Me.TextPreacherName = New System.Windows.Forms.TextBox()
        Me.TextLeaderName = New System.Windows.Forms.TextBox()
        Me.ListBoxMedia = New System.Windows.Forms.ListBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BtnMNext = New CCNCamcontrol.MyButton()
        Me.BtnMPrev = New CCNCamcontrol.MyButton()
        Me.BtnLiveFast = New CCNCamcontrol.MyButton()
        Me.BtnSlowIn = New CCNCamcontrol.MyButton()
        Me.BtnSlowOut = New CCNCamcontrol.MyButton()
        Me.BtnLive = New CCNCamcontrol.MyButton()
        Me.BtnLivePTZ = New CCNCamcontrol.MyButton()
        Me.BtnPreload = New CCNCamcontrol.MyButton()
        Me.BtnLiveSlow = New CCNCamcontrol.MyButton()
        Me.BtnPreset9 = New CCNCamcontrol.MyButton()
        Me.BtnPreset1 = New CCNCamcontrol.MyButton()
        Me.BtnPreset2 = New CCNCamcontrol.MyButton()
        Me.BtnPreset3 = New CCNCamcontrol.MyButton()
        Me.BtnPreset4 = New CCNCamcontrol.MyButton()
        Me.BtnPreset5 = New CCNCamcontrol.MyButton()
        Me.BtnPreset6 = New CCNCamcontrol.MyButton()
        Me.BtnPreset7 = New CCNCamcontrol.MyButton()
        Me.BtnPreset8 = New CCNCamcontrol.MyButton()
        Me.BtnPreset10 = New CCNCamcontrol.MyButton()
        Me.BtnPreset11 = New CCNCamcontrol.MyButton()
        Me.BtnPreset12 = New CCNCamcontrol.MyButton()
        Me.BtnPreset13 = New CCNCamcontrol.MyButton()
        Me.BtnPreset14 = New CCNCamcontrol.MyButton()
        Me.BtnPreset15 = New CCNCamcontrol.MyButton()
        Me.BtnPreset16 = New CCNCamcontrol.MyButton()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShapeCapR = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeCapL = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeCapB = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeCapT = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ModeBtnSettings = New CCNCamcontrol.MyButton()
        Me.ModeBtnCam = New CCNCamcontrol.MyButton()
        Me.ModeBtnPresets = New CCNCamcontrol.MyButton()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShapeMode4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeMode3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeMode2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShapeMode1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.CamPanel = New System.Windows.Forms.Panel()
        Me.MyButtonAutoWB = New CCNCamcontrol.MyButton()
        Me.MyButtonAutoAgc = New CCNCamcontrol.MyButton()
        Me.MyButtonAutoIris = New CCNCamcontrol.MyButton()
        Me.TextBoxFocus = New System.Windows.Forms.TextBox()
        Me.MyButtonFullTele = New CCNCamcontrol.MyButton()
        Me.MyButtonFullWide = New CCNCamcontrol.MyButton()
        Me.MyButtonCamTele = New CCNCamcontrol.MyButton()
        Me.MyButtonCamWide = New CCNCamcontrol.MyButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.BtnCam4Rec = New CCNCamcontrol.MyButton()
        Me.BtnCam3Rec = New CCNCamcontrol.MyButton()
        Me.BtnCam2Rec = New CCNCamcontrol.MyButton()
        Me.BtnCam1Rec = New CCNCamcontrol.MyButton()
        Me.BtnFocusLock = New CCNCamcontrol.MyButton()
        Me.BtnFocusAuto = New CCNCamcontrol.MyButton()
        Me.BtnSlow = New CCNCamcontrol.MyButton()
        Me.BtnFast = New CCNCamcontrol.MyButton()
        Me.MyButtonCamDR = New CCNCamcontrol.MyButton()
        Me.MyButtonCamD = New CCNCamcontrol.MyButton()
        Me.MyButtonCamDL = New CCNCamcontrol.MyButton()
        Me.MyButtonCamR = New CCNCamcontrol.MyButton()
        Me.MyButtonCamL = New CCNCamcontrol.MyButton()
        Me.MyButtonCamUR = New CCNCamcontrol.MyButton()
        Me.MyButtonCamU = New CCNCamcontrol.MyButton()
        Me.MyButtonCamUL = New CCNCamcontrol.MyButton()
        Me.OverrideBtn = New CCNCamcontrol.MyButton()
        Me.SettingsPanel = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.ButtonTouchscreen = New System.Windows.Forms.Button()
        Me.CheckBoxSaveAE = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSaveIris = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSaveFocus = New System.Windows.Forms.CheckBox()
        Me.ButtonRetryCam = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.BtnSetupSaveNew = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBoxPresetNewFile = New System.Windows.Forms.TextBox()
        Me.CheckBoxCam4Dis = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCam3Dis = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCam2Dis = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCam1Dis = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxCam5Dis = New System.Windows.Forms.CheckBox()
        Me.BtnSetupOsd = New System.Windows.Forms.Button()
        Me.BtnSetupDown = New System.Windows.Forms.Button()
        Me.BtnSetupUp = New System.Windows.Forms.Button()
        Me.BtnSetupEnter = New System.Windows.Forms.Button()
        Me.BtnSetupMenu = New System.Windows.Forms.Button()
        Me.LblCamStatus5 = New System.Windows.Forms.Label()
        Me.TextBoxIPCam5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBoxStandby = New System.Windows.Forms.CheckBox()
        Me.CheckBoxProfile = New System.Windows.Forms.CheckBox()
        Me.BtnSetupFolderBrowse = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxPresetFolder = New System.Windows.Forms.TextBox()
        Me.LblCamStatus4 = New System.Windows.Forms.Label()
        Me.LblCamStatus3 = New System.Windows.Forms.Label()
        Me.LblCamStatus2 = New System.Windows.Forms.Label()
        Me.LblCamStatus1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BtnSetupFilenameBrowse = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TextBoxPresetFilename = New System.Windows.Forms.TextBox()
        Me.TextBoxIPCam4 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBoxIPCam3 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TextBoxIPCam2 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextBoxIPCam1 = New System.Windows.Forms.TextBox()
        Me.CheckBoxAutoSwap = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTally = New System.Windows.Forms.CheckBox()
        Me.CheckBoxInvert4 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxInvert3 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxInvert2 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxInvert1 = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ComboBoxSetupComport = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.StatPanel = New System.Windows.Forms.Panel()
        Me.TextBoxOBSRecTime = New System.Windows.Forms.TextBox()
        Me.BtnOBSRecord = New CCNCamcontrol.MyButton()
        Me.BtnOBSBroadcast = New CCNCamcontrol.MyButton()
        Me.TextBoxOBSBroadcastTime = New System.Windows.Forms.TextBox()
        Me.LabelEncB = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextEncBStatus = New System.Windows.Forms.TextBox()
        Me.LabelEncA = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextEncAStatus = New System.Windows.Forms.TextBox()
        Me.LabelEncStatus = New System.Windows.Forms.Label()
        Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape12 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.MsgBoxPanel = New System.Windows.Forms.Panel()
        Me.MsgBoxLabel = New System.Windows.Forms.Label()
        Me.MsgboxClose = New System.Windows.Forms.Label()
        Me.PresetLoadPanel = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PresetLoadClose = New System.Windows.Forms.Label()
        Me.PanelEncSelect = New System.Windows.Forms.Panel()
        Me.LabelEnc = New System.Windows.Forms.Label()
        Me.ButtonEncAeShift = New System.Windows.Forms.Button()
        Me.ButtonEncAgcLimit = New System.Windows.Forms.Button()
        Me.ButtonEncAgc = New System.Windows.Forms.Button()
        Me.ButtonEncIris = New System.Windows.Forms.Button()
        Me.ButtonEncFocus = New System.Windows.Forms.Button()
        Me.BtnInp1 = New CCNCamcontrol.MyButton()
        Me.BtnInp4 = New CCNCamcontrol.MyButton()
        Me.AuxSel12 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn12 = New CCNCamcontrol.MyButton()
        Me.BtnPip = New CCNCamcontrol.MyButton()
        Me.Aux3Btn11 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn10 = New CCNCamcontrol.MyButton()
        Me.Auxsel11 = New CCNCamcontrol.MyButton()
        Me.Auxsel10 = New CCNCamcontrol.MyButton()
        Me.BtnAuxLock = New CCNCamcontrol.MyButton()
        Me.AuxSel9 = New CCNCamcontrol.MyButton()
        Me.Auxsel8 = New CCNCamcontrol.MyButton()
        Me.Auxsel7 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn9 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn8 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn7 = New CCNCamcontrol.MyButton()
        Me.Auxsel3 = New CCNCamcontrol.MyButton()
        Me.Auxsel2 = New CCNCamcontrol.MyButton()
        Me.Auxsel1 = New CCNCamcontrol.MyButton()
        Me.BtnMediaOverlay = New CCNCamcontrol.MyButton()
        Me.BtnOverlay = New CCNCamcontrol.MyButton()
        Me.BtnTransition = New CCNCamcontrol.MyButton()
        Me.BtnCut = New CCNCamcontrol.MyButton()
        Me.BtnInp3 = New CCNCamcontrol.MyButton()
        Me.BtnCam5 = New CCNCamcontrol.MyButton()
        Me.BtnInp2 = New CCNCamcontrol.MyButton()
        Me.BtnInp5 = New CCNCamcontrol.MyButton()
        Me.BtnCam4 = New CCNCamcontrol.MyButton()
        Me.BtnCam3 = New CCNCamcontrol.MyButton()
        Me.BtnCam2 = New CCNCamcontrol.MyButton()
        Me.BtnCam1 = New CCNCamcontrol.MyButton()
        Me.Auxsel4 = New CCNCamcontrol.MyButton()
        Me.Auxsel5 = New CCNCamcontrol.MyButton()
        Me.Auxsel6 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn3 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn2 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn1 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn4 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn5 = New CCNCamcontrol.MyButton()
        Me.Aux3Btn6 = New CCNCamcontrol.MyButton()
        Me.GroupBox1.SuspendLayout()
        Me.PresetPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CamPanel.SuspendLayout()
        Me.SettingsPanel.SuspendLayout()
        Me.StatPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MsgBoxPanel.SuspendLayout()
        Me.PresetLoadPanel.SuspendLayout()
        Me.PanelEncSelect.SuspendLayout()
        Me.SuspendLayout()
        '
        'eVISMacrosAppHost
        '
        Me.eVISMacrosAppHost.Location = New System.Drawing.Point(164, 426)
        Me.eVISMacrosAppHost.Name = "eVISMacrosAppHost"
        Me.eVISMacrosAppHost.Size = New System.Drawing.Size(141, 20)
        Me.eVISMacrosAppHost.TabIndex = 0
        Me.eVISMacrosAppHost.Text = "localhost"
        Me.eVISMacrosAppHost.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP Address of VIS Macros Application Computer"
        Me.Label1.Visible = False
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(16, 348)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(90, 21)
        Me.bConnect.TabIndex = 2
        Me.bConnect.Text = "Connect"
        Me.bConnect.UseVisualStyleBackColor = True
        Me.bConnect.Visible = False
        '
        'mLog
        '
        Me.mLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mLog.Location = New System.Drawing.Point(11, 195)
        Me.mLog.Multiline = True
        Me.mLog.Name = "mLog"
        Me.mLog.Size = New System.Drawing.Size(97, 93)
        Me.mLog.TabIndex = 4
        Me.mLog.Text = "Log window"
        '
        'chkLogMessages
        '
        Me.chkLogMessages.AutoSize = True
        Me.chkLogMessages.Checked = True
        Me.chkLogMessages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLogMessages.ForeColor = System.Drawing.Color.White
        Me.chkLogMessages.Location = New System.Drawing.Point(11, 291)
        Me.chkLogMessages.Name = "chkLogMessages"
        Me.chkLogMessages.Size = New System.Drawing.Size(95, 17)
        Me.chkLogMessages.TabIndex = 44
        Me.chkLogMessages.Text = "Log Messages"
        Me.chkLogMessages.UseVisualStyleBackColor = True
        Me.chkLogMessages.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(158, 229)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(76, 25)
        Me.TextBox1.TabIndex = 87
        Me.TextBox1.Text = "1.0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Black
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Yellow
        Me.TextBox2.Location = New System.Drawing.Point(1104, 874)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(62, 25)
        Me.TextBox2.TabIndex = 89
        Me.TextBox2.Text = "1.0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxIris
        '
        Me.TextBoxIris.BackColor = System.Drawing.Color.Black
        Me.TextBoxIris.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIris.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIris.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIris.Location = New System.Drawing.Point(395, 93)
        Me.TextBoxIris.Name = "TextBoxIris"
        Me.TextBoxIris.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxIris.TabIndex = 113
        Me.TextBoxIris.Text = "17"
        Me.TextBoxIris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnIrisDown
        '
        Me.BtnIrisDown.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnIrisDown.Location = New System.Drawing.Point(395, 128)
        Me.BtnIrisDown.Name = "BtnIrisDown"
        Me.BtnIrisDown.Size = New System.Drawing.Size(60, 40)
        Me.BtnIrisDown.TabIndex = 114
        Me.BtnIrisDown.Text = "q"
        Me.BtnIrisDown.UseVisualStyleBackColor = True
        '
        'TextBoxAgc
        '
        Me.TextBoxAgc.BackColor = System.Drawing.Color.Black
        Me.TextBoxAgc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAgc.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAgc.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxAgc.Location = New System.Drawing.Point(461, 93)
        Me.TextBoxAgc.Name = "TextBoxAgc"
        Me.TextBoxAgc.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxAgc.TabIndex = 116
        Me.TextBoxAgc.Text = "8"
        Me.TextBoxAgc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxAeShift
        '
        Me.TextBoxAeShift.BackColor = System.Drawing.Color.Black
        Me.TextBoxAeShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAeShift.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAeShift.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxAeShift.Location = New System.Drawing.Point(593, 93)
        Me.TextBoxAeShift.Name = "TextBoxAeShift"
        Me.TextBoxAeShift.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxAeShift.TabIndex = 119
        Me.TextBoxAeShift.Text = "6"
        Me.TextBoxAeShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxAgcLimit
        '
        Me.TextBoxAgcLimit.BackColor = System.Drawing.Color.Black
        Me.TextBoxAgcLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAgcLimit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAgcLimit.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxAgcLimit.Location = New System.Drawing.Point(527, 93)
        Me.TextBoxAgcLimit.Name = "TextBoxAgcLimit"
        Me.TextBoxAgcLimit.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxAgcLimit.TabIndex = 122
        Me.TextBoxAgcLimit.Text = "10"
        Me.TextBoxAgcLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.Black
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ForeColor = System.Drawing.Color.Yellow
        Me.TextBox8.Location = New System.Drawing.Point(702, 496)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(46, 29)
        Me.TextBox8.TabIndex = 127
        Me.TextBox8.Text = "190"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox8.Visible = False
        '
        'TextBoxWB
        '
        Me.TextBoxWB.BackColor = System.Drawing.Color.Black
        Me.TextBoxWB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxWB.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWB.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxWB.Location = New System.Drawing.Point(660, 93)
        Me.TextBoxWB.Name = "TextBoxWB"
        Me.TextBoxWB.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxWB.TabIndex = 129
        Me.TextBoxWB.Text = "190"
        Me.TextBoxWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(40, 846)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 16)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "Next Source select"
        '
        'SerialPort1
        '
        '
        'ButtonSetup
        '
        Me.ButtonSetup.Font = New System.Drawing.Font("Webdings", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ButtonSetup.Location = New System.Drawing.Point(39, 44)
        Me.ButtonSetup.Name = "ButtonSetup"
        Me.ButtonSetup.Size = New System.Drawing.Size(46, 42)
        Me.ButtonSetup.TabIndex = 164
        Me.ButtonSetup.Text = "@"
        Me.ButtonSetup.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(40, 576)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 16)
        Me.Label15.TabIndex = 165
        Me.Label15.Text = "Projector out (Aux2)"
        Me.Label15.Visible = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape11, Me.LineShape10, Me.LineShape9, Me.LineShape3, Me.LineShape8, Me.LineShape5, Me.LineShape4})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1626, 1100)
        Me.ShapeContainer1.TabIndex = 184
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape11
        '
        Me.LineShape11.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape11.Name = "LineShape11"
        Me.LineShape11.X1 = 671
        Me.LineShape11.X2 = 863
        Me.LineShape11.Y1 = 383
        Me.LineShape11.Y2 = 383
        '
        'LineShape10
        '
        Me.LineShape10.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape10.Name = "LineShape10"
        Me.LineShape10.X1 = 670
        Me.LineShape10.X2 = 862
        Me.LineShape10.Y1 = 226
        Me.LineShape10.Y2 = 226
        '
        'LineShape9
        '
        Me.LineShape9.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape9.Name = "LineShape9"
        Me.LineShape9.X1 = 671
        Me.LineShape9.X2 = 863
        Me.LineShape9.Y1 = 69
        Me.LineShape9.Y2 = 69
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.Visible = False
        Me.LineShape3.X1 = 75
        Me.LineShape3.X2 = 933
        Me.LineShape3.Y1 = 585
        Me.LineShape3.Y2 = 585
        '
        'LineShape8
        '
        Me.LineShape8.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape8.Name = "LineShape8"
        Me.LineShape8.X1 = 164
        Me.LineShape8.X2 = 575
        Me.LineShape8.Y1 = 68
        Me.LineShape8.Y2 = 68
        '
        'LineShape5
        '
        Me.LineShape5.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 1109
        Me.LineShape5.X2 = 1240
        Me.LineShape5.Y1 = 853
        Me.LineShape5.Y2 = 853
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 54
        Me.LineShape4.X2 = 735
        Me.LineShape4.Y1 = 855
        Me.LineShape4.Y2 = 855
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Location = New System.Drawing.Point(1105, 846)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 16)
        Me.Label16.TabIndex = 185
        Me.Label16.Text = "Overlay"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(45, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 186
        Me.Label17.Text = "Setup"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(128, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 16)
        Me.Label18.TabIndex = 187
        Me.Label18.Text = "Camera controls"
        '
        'BtnIrisUp
        '
        Me.BtnIrisUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnIrisUp.Location = New System.Drawing.Point(395, 47)
        Me.BtnIrisUp.Name = "BtnIrisUp"
        Me.BtnIrisUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnIrisUp.TabIndex = 188
        Me.BtnIrisUp.Text = "p"
        Me.BtnIrisUp.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Yellow
        Me.Label19.Location = New System.Drawing.Point(407, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 20)
        Me.Label19.TabIndex = 189
        Me.Label19.Text = "Iris"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(471, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 20)
        Me.Label20.TabIndex = 190
        Me.Label20.Text = "AGC"
        '
        'BtnAGCDown
        '
        Me.BtnAGCDown.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnAGCDown.Location = New System.Drawing.Point(461, 128)
        Me.BtnAGCDown.Name = "BtnAGCDown"
        Me.BtnAGCDown.Size = New System.Drawing.Size(60, 40)
        Me.BtnAGCDown.TabIndex = 191
        Me.BtnAGCDown.Text = "q"
        Me.BtnAGCDown.UseVisualStyleBackColor = True
        '
        'BtnAGCUp
        '
        Me.BtnAGCUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnAGCUp.Location = New System.Drawing.Point(461, 47)
        Me.BtnAGCUp.Name = "BtnAGCUp"
        Me.BtnAGCUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnAGCUp.TabIndex = 192
        Me.BtnAGCUp.Text = "p"
        Me.BtnAGCUp.UseVisualStyleBackColor = True
        '
        'BtnGainDown
        '
        Me.BtnGainDown.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnGainDown.Location = New System.Drawing.Point(527, 128)
        Me.BtnGainDown.Name = "BtnGainDown"
        Me.BtnGainDown.Size = New System.Drawing.Size(60, 40)
        Me.BtnGainDown.TabIndex = 193
        Me.BtnGainDown.Text = "q"
        Me.BtnGainDown.UseVisualStyleBackColor = True
        '
        'BtnGainUp
        '
        Me.BtnGainUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnGainUp.Location = New System.Drawing.Point(527, 47)
        Me.BtnGainUp.Name = "BtnGainUp"
        Me.BtnGainUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnGainUp.TabIndex = 194
        Me.BtnGainUp.Text = "p"
        Me.BtnGainUp.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(520, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 195
        Me.Label8.Text = "AGC Limit"
        '
        'BtnAEShiftDn
        '
        Me.BtnAEShiftDn.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnAEShiftDn.Location = New System.Drawing.Point(593, 128)
        Me.BtnAEShiftDn.Name = "BtnAEShiftDn"
        Me.BtnAEShiftDn.Size = New System.Drawing.Size(60, 40)
        Me.BtnAEShiftDn.TabIndex = 196
        Me.BtnAEShiftDn.Text = "q"
        Me.BtnAEShiftDn.UseVisualStyleBackColor = True
        '
        'BtnAEShiftUp
        '
        Me.BtnAEShiftUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnAEShiftUp.Location = New System.Drawing.Point(593, 47)
        Me.BtnAEShiftUp.Name = "BtnAEShiftUp"
        Me.BtnAEShiftUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnAEShiftUp.TabIndex = 197
        Me.BtnAEShiftUp.Text = "p"
        Me.BtnAEShiftUp.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(593, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 20)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "AE Shift"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Yellow
        Me.Label21.Location = New System.Drawing.Point(592, 177)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 20)
        Me.Label21.TabIndex = 202
        Me.Label21.Text = "-10 - +10"
        '
        'BtnWbBlueUp
        '
        Me.BtnWbBlueUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnWbBlueUp.Location = New System.Drawing.Point(660, 47)
        Me.BtnWbBlueUp.Name = "BtnWbBlueUp"
        Me.BtnWbBlueUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnWbBlueUp.TabIndex = 206
        Me.BtnWbBlueUp.Text = "p"
        Me.BtnWbBlueUp.UseVisualStyleBackColor = True
        '
        'BtnWbBlueDn
        '
        Me.BtnWbBlueDn.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnWbBlueDn.Location = New System.Drawing.Point(660, 128)
        Me.BtnWbBlueDn.Name = "BtnWbBlueDn"
        Me.BtnWbBlueDn.Size = New System.Drawing.Size(60, 40)
        Me.BtnWbBlueDn.TabIndex = 205
        Me.BtnWbBlueDn.Text = "q"
        Me.BtnWbBlueDn.UseVisualStyleBackColor = True
        '
        'BtnWbRedUp
        '
        Me.BtnWbRedUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnWbRedUp.Location = New System.Drawing.Point(702, 466)
        Me.BtnWbRedUp.Name = "BtnWbRedUp"
        Me.BtnWbRedUp.Size = New System.Drawing.Size(50, 35)
        Me.BtnWbRedUp.TabIndex = 204
        Me.BtnWbRedUp.Text = "p"
        Me.BtnWbRedUp.UseVisualStyleBackColor = True
        Me.BtnWbRedUp.Visible = False
        '
        'BtnWbRedDn
        '
        Me.BtnWbRedDn.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnWbRedDn.Location = New System.Drawing.Point(702, 526)
        Me.BtnWbRedDn.Name = "BtnWbRedDn"
        Me.BtnWbRedDn.Size = New System.Drawing.Size(50, 35)
        Me.BtnWbRedDn.TabIndex = 203
        Me.BtnWbRedDn.Text = "q"
        Me.BtnWbRedDn.UseVisualStyleBackColor = True
        Me.BtnWbRedDn.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(671, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 20)
        Me.Label10.TabIndex = 208
        Me.Label10.Text = "WB"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(707, 448)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 20)
        Me.Label11.TabIndex = 207
        Me.Label11.Text = "WB Red"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(339, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 20)
        Me.Label12.TabIndex = 209
        Me.Label12.Text = "Focus"
        '
        'BtnFocusUp
        '
        Me.BtnFocusUp.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnFocusUp.Location = New System.Drawing.Point(329, 47)
        Me.BtnFocusUp.Name = "BtnFocusUp"
        Me.BtnFocusUp.Size = New System.Drawing.Size(60, 40)
        Me.BtnFocusUp.TabIndex = 213
        Me.BtnFocusUp.Text = "p"
        Me.BtnFocusUp.UseVisualStyleBackColor = True
        '
        'BtnFocusDn
        '
        Me.BtnFocusDn.Font = New System.Drawing.Font("Wingdings 3", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnFocusDn.Location = New System.Drawing.Point(329, 128)
        Me.BtnFocusDn.Name = "BtnFocusDn"
        Me.BtnFocusDn.Size = New System.Drawing.Size(60, 40)
        Me.BtnFocusDn.TabIndex = 212
        Me.BtnFocusDn.Text = "q"
        Me.BtnFocusDn.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Webdings", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Button1.Location = New System.Drawing.Point(731, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 30)
        Me.Button1.TabIndex = 214
        Me.Button1.Text = "r"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(4, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 215
        Me.Label13.Text = "v1.0"
        '
        'LabelProfile
        '
        Me.LabelProfile.AutoSize = True
        Me.LabelProfile.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProfile.ForeColor = System.Drawing.Color.Yellow
        Me.LabelProfile.Location = New System.Drawing.Point(1018, 26)
        Me.LabelProfile.Name = "LabelProfile"
        Me.LabelProfile.Size = New System.Drawing.Size(42, 16)
        Me.LabelProfile.TabIndex = 248
        Me.LabelProfile.Text = "profile"
        Me.LabelProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(40, 701)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 16)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Foldback (Aux3)"
        Me.Label4.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(1237, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 252)
        Me.GroupBox1.TabIndex = 258
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label22.Location = New System.Drawing.Point(18, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Startup..."
        '
        'TextPlayerTime
        '
        Me.TextPlayerTime.BackColor = System.Drawing.Color.Black
        Me.TextPlayerTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPlayerTime.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPlayerTime.ForeColor = System.Drawing.Color.Yellow
        Me.TextPlayerTime.Location = New System.Drawing.Point(277, 498)
        Me.TextPlayerTime.Name = "TextPlayerTime"
        Me.TextPlayerTime.Size = New System.Drawing.Size(215, 26)
        Me.TextPlayerTime.TabIndex = 279
        Me.TextPlayerTime.Text = "00:00:00"
        Me.TextPlayerTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextPlayerTime.Visible = False
        '
        'TextBoxCam1Rec
        '
        Me.TextBoxCam1Rec.BackColor = System.Drawing.Color.Black
        Me.TextBoxCam1Rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCam1Rec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCam1Rec.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxCam1Rec.Location = New System.Drawing.Point(95, 317)
        Me.TextBoxCam1Rec.Multiline = True
        Me.TextBoxCam1Rec.Name = "TextBoxCam1Rec"
        Me.TextBoxCam1Rec.Size = New System.Drawing.Size(98, 59)
        Me.TextBoxCam1Rec.TabIndex = 284
        Me.TextBoxCam1Rec.Text = "."
        '
        'TextBoxCam2Rec
        '
        Me.TextBoxCam2Rec.BackColor = System.Drawing.Color.Black
        Me.TextBoxCam2Rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCam2Rec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCam2Rec.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxCam2Rec.Location = New System.Drawing.Point(95, 382)
        Me.TextBoxCam2Rec.Multiline = True
        Me.TextBoxCam2Rec.Name = "TextBoxCam2Rec"
        Me.TextBoxCam2Rec.Size = New System.Drawing.Size(98, 60)
        Me.TextBoxCam2Rec.TabIndex = 285
        Me.TextBoxCam2Rec.Text = "."
        '
        'TextBoxCam3Rec
        '
        Me.TextBoxCam3Rec.BackColor = System.Drawing.Color.Black
        Me.TextBoxCam3Rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCam3Rec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCam3Rec.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxCam3Rec.Location = New System.Drawing.Point(95, 448)
        Me.TextBoxCam3Rec.Multiline = True
        Me.TextBoxCam3Rec.Name = "TextBoxCam3Rec"
        Me.TextBoxCam3Rec.Size = New System.Drawing.Size(98, 60)
        Me.TextBoxCam3Rec.TabIndex = 286
        Me.TextBoxCam3Rec.Text = "."
        '
        'TextBoxCam4Rec
        '
        Me.TextBoxCam4Rec.BackColor = System.Drawing.Color.Black
        Me.TextBoxCam4Rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCam4Rec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCam4Rec.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxCam4Rec.Location = New System.Drawing.Point(95, 514)
        Me.TextBoxCam4Rec.Multiline = True
        Me.TextBoxCam4Rec.Name = "TextBoxCam4Rec"
        Me.TextBoxCam4Rec.Size = New System.Drawing.Size(98, 60)
        Me.TextBoxCam4Rec.TabIndex = 287
        Me.TextBoxCam4Rec.Text = "."
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(208, 317)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(51, 40)
        Me.Button8.TabIndex = 288
        Me.Button8.Text = "Files"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Yellow
        Me.Label23.Location = New System.Drawing.Point(330, 466)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(74, 16)
        Me.Label23.TabIndex = 297
        Me.Label23.Text = "Clip time left"
        Me.Label23.Visible = False
        '
        'TextBoxPipSrc
        '
        Me.TextBoxPipSrc.BackColor = System.Drawing.Color.Black
        Me.TextBoxPipSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPipSrc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPipSrc.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxPipSrc.Location = New System.Drawing.Point(745, 874)
        Me.TextBoxPipSrc.Multiline = True
        Me.TextBoxPipSrc.Name = "TextBoxPipSrc"
        Me.TextBoxPipSrc.Size = New System.Drawing.Size(65, 25)
        Me.TextBoxPipSrc.TabIndex = 302
        Me.TextBoxPipSrc.Text = "Words"
        Me.TextBoxPipSrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonRetryOBS
        '
        Me.ButtonRetryOBS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRetryOBS.Location = New System.Drawing.Point(459, 204)
        Me.ButtonRetryOBS.Name = "ButtonRetryOBS"
        Me.ButtonRetryOBS.Size = New System.Drawing.Size(80, 50)
        Me.ButtonRetryOBS.TabIndex = 315
        Me.ButtonRetryOBS.Text = "Retry OBS"
        Me.ButtonRetryOBS.UseVisualStyleBackColor = True
        '
        'PresetPanel
        '
        Me.PresetPanel.Controls.Add(Me.BtnCNxt)
        Me.PresetPanel.Controls.Add(Me.BtnCPrev)
        Me.PresetPanel.Controls.Add(Me.BtnSlowPanL)
        Me.PresetPanel.Controls.Add(Me.BtnStop)
        Me.PresetPanel.Controls.Add(Me.BtnSlowPanR)
        Me.PresetPanel.Controls.Add(Me.TextBoxPresetEdit)
        Me.PresetPanel.Controls.Add(Me.BtnMovePreset)
        Me.PresetPanel.Controls.Add(Me.BtnEditPreset)
        Me.PresetPanel.Controls.Add(Me.BtnPresetSave)
        Me.PresetPanel.Controls.Add(Me.LabelCap3)
        Me.PresetPanel.Controls.Add(Me.TextCaptionOther)
        Me.PresetPanel.Controls.Add(Me.Label27)
        Me.PresetPanel.Controls.Add(Me.LabelCap2)
        Me.PresetPanel.Controls.Add(Me.LabelCap1)
        Me.PresetPanel.Controls.Add(Me.TextPreacherName)
        Me.PresetPanel.Controls.Add(Me.TextLeaderName)
        Me.PresetPanel.Controls.Add(Me.ListBoxMedia)
        Me.PresetPanel.Controls.Add(Me.Label28)
        Me.PresetPanel.Controls.Add(Me.BtnMNext)
        Me.PresetPanel.Controls.Add(Me.BtnMPrev)
        Me.PresetPanel.Controls.Add(Me.BtnLiveFast)
        Me.PresetPanel.Controls.Add(Me.BtnSlowIn)
        Me.PresetPanel.Controls.Add(Me.BtnSlowOut)
        Me.PresetPanel.Controls.Add(Me.BtnLive)
        Me.PresetPanel.Controls.Add(Me.BtnLivePTZ)
        Me.PresetPanel.Controls.Add(Me.BtnPreload)
        Me.PresetPanel.Controls.Add(Me.BtnLiveSlow)
        Me.PresetPanel.Controls.Add(Me.BtnPreset9)
        Me.PresetPanel.Controls.Add(Me.BtnPreset1)
        Me.PresetPanel.Controls.Add(Me.BtnPreset2)
        Me.PresetPanel.Controls.Add(Me.BtnPreset3)
        Me.PresetPanel.Controls.Add(Me.BtnPreset4)
        Me.PresetPanel.Controls.Add(Me.BtnPreset5)
        Me.PresetPanel.Controls.Add(Me.BtnPreset6)
        Me.PresetPanel.Controls.Add(Me.BtnPreset7)
        Me.PresetPanel.Controls.Add(Me.BtnPreset8)
        Me.PresetPanel.Controls.Add(Me.BtnPreset10)
        Me.PresetPanel.Controls.Add(Me.BtnPreset11)
        Me.PresetPanel.Controls.Add(Me.BtnPreset12)
        Me.PresetPanel.Controls.Add(Me.BtnPreset13)
        Me.PresetPanel.Controls.Add(Me.BtnPreset14)
        Me.PresetPanel.Controls.Add(Me.BtnPreset15)
        Me.PresetPanel.Controls.Add(Me.BtnPreset16)
        Me.PresetPanel.Controls.Add(Me.ShapeContainer3)
        Me.PresetPanel.Location = New System.Drawing.Point(11, 618)
        Me.PresetPanel.Name = "PresetPanel"
        Me.PresetPanel.Size = New System.Drawing.Size(775, 600)
        Me.PresetPanel.TabIndex = 320
        '
        'BtnCNxt
        '
        Me.BtnCNxt.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnCNxt.Image = CType(resources.GetObject("BtnCNxt.Image"), System.Drawing.Image)
        Me.BtnCNxt.Location = New System.Drawing.Point(7, 120)
        Me.BtnCNxt.Name = "BtnCNxt"
        Me.BtnCNxt.Size = New System.Drawing.Size(80, 80)
        Me.BtnCNxt.TabIndex = 339
        Me.BtnCNxt.Text = ""
        Me.BtnCNxt.UseVisualStyleBackColor = True
        '
        'BtnCPrev
        '
        Me.BtnCPrev.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnCPrev.Image = CType(resources.GetObject("BtnCPrev.Image"), System.Drawing.Image)
        Me.BtnCPrev.Location = New System.Drawing.Point(7, 40)
        Me.BtnCPrev.Name = "BtnCPrev"
        Me.BtnCPrev.Size = New System.Drawing.Size(80, 80)
        Me.BtnCPrev.TabIndex = 338
        Me.BtnCPrev.Text = ""
        Me.BtnCPrev.UseVisualStyleBackColor = True
        '
        'BtnSlowPanL
        '
        Me.BtnSlowPanL.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSlowPanL.Image = CType(resources.GetObject("BtnSlowPanL.Image"), System.Drawing.Image)
        Me.BtnSlowPanL.Location = New System.Drawing.Point(265, 488)
        Me.BtnSlowPanL.Name = "BtnSlowPanL"
        Me.BtnSlowPanL.Size = New System.Drawing.Size(100, 100)
        Me.BtnSlowPanL.TabIndex = 337
        Me.BtnSlowPanL.Text = "    Slow     pan L"
        Me.BtnSlowPanL.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.Image = CType(resources.GetObject("BtnStop.Image"), System.Drawing.Image)
        Me.BtnStop.Location = New System.Drawing.Point(7, 508)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(80, 80)
        Me.BtnStop.TabIndex = 336
        Me.BtnStop.Text = "Stop All"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BtnSlowPanR
        '
        Me.BtnSlowPanR.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSlowPanR.Image = CType(resources.GetObject("BtnSlowPanR.Image"), System.Drawing.Image)
        Me.BtnSlowPanR.Location = New System.Drawing.Point(370, 488)
        Me.BtnSlowPanR.Name = "BtnSlowPanR"
        Me.BtnSlowPanR.Size = New System.Drawing.Size(100, 100)
        Me.BtnSlowPanR.TabIndex = 335
        Me.BtnSlowPanR.Text = "    Slow     pan R"
        Me.BtnSlowPanR.UseVisualStyleBackColor = True
        '
        'TextBoxPresetEdit
        '
        Me.TextBoxPresetEdit.BackColor = System.Drawing.Color.White
        Me.TextBoxPresetEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPresetEdit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPresetEdit.ForeColor = System.Drawing.Color.Black
        Me.TextBoxPresetEdit.HideSelection = False
        Me.TextBoxPresetEdit.Location = New System.Drawing.Point(280, 472)
        Me.TextBoxPresetEdit.Multiline = True
        Me.TextBoxPresetEdit.Name = "TextBoxPresetEdit"
        Me.TextBoxPresetEdit.Size = New System.Drawing.Size(85, 87)
        Me.TextBoxPresetEdit.TabIndex = 334
        Me.TextBoxPresetEdit.Text = "..."
        Me.TextBoxPresetEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxPresetEdit.Visible = False
        '
        'BtnMovePreset
        '
        Me.BtnMovePreset.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMovePreset.Image = CType(resources.GetObject("BtnMovePreset.Image"), System.Drawing.Image)
        Me.BtnMovePreset.Location = New System.Drawing.Point(272, 193)
        Me.BtnMovePreset.Name = "BtnMovePreset"
        Me.BtnMovePreset.Size = New System.Drawing.Size(80, 80)
        Me.BtnMovePreset.TabIndex = 333
        Me.BtnMovePreset.Text = "Move"
        Me.BtnMovePreset.UseVisualStyleBackColor = True
        '
        'BtnEditPreset
        '
        Me.BtnEditPreset.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditPreset.Image = CType(resources.GetObject("BtnEditPreset.Image"), System.Drawing.Image)
        Me.BtnEditPreset.Location = New System.Drawing.Point(272, 106)
        Me.BtnEditPreset.Name = "BtnEditPreset"
        Me.BtnEditPreset.Size = New System.Drawing.Size(80, 80)
        Me.BtnEditPreset.TabIndex = 332
        Me.BtnEditPreset.Text = "Label"
        Me.BtnEditPreset.UseVisualStyleBackColor = True
        '
        'BtnPresetSave
        '
        Me.BtnPresetSave.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPresetSave.Image = CType(resources.GetObject("BtnPresetSave.Image"), System.Drawing.Image)
        Me.BtnPresetSave.Location = New System.Drawing.Point(272, 20)
        Me.BtnPresetSave.Name = "BtnPresetSave"
        Me.BtnPresetSave.Size = New System.Drawing.Size(80, 80)
        Me.BtnPresetSave.TabIndex = 331
        Me.BtnPresetSave.Text = "Save"
        Me.BtnPresetSave.UseVisualStyleBackColor = True
        '
        'LabelCap3
        '
        Me.LabelCap3.AutoSize = True
        Me.LabelCap3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCap3.ForeColor = System.Drawing.Color.Yellow
        Me.LabelCap3.Location = New System.Drawing.Point(97, 147)
        Me.LabelCap3.Name = "LabelCap3"
        Me.LabelCap3.Size = New System.Drawing.Size(37, 16)
        Me.LabelCap3.TabIndex = 330
        Me.LabelCap3.Text = "Other"
        '
        'TextCaptionOther
        '
        Me.TextCaptionOther.BackColor = System.Drawing.Color.Black
        Me.TextCaptionOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCaptionOther.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCaptionOther.ForeColor = System.Drawing.Color.Yellow
        Me.TextCaptionOther.Location = New System.Drawing.Point(98, 166)
        Me.TextCaptionOther.Name = "TextCaptionOther"
        Me.TextCaptionOther.Size = New System.Drawing.Size(162, 29)
        Me.TextCaptionOther.TabIndex = 329
        Me.TextCaptionOther.Text = "..."
        Me.TextCaptionOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Yellow
        Me.Label27.Location = New System.Drawing.Point(5, 17)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(82, 20)
        Me.Label27.TabIndex = 328
        Me.Label27.Text = "Caption text"
        '
        'LabelCap2
        '
        Me.LabelCap2.AutoSize = True
        Me.LabelCap2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCap2.ForeColor = System.Drawing.Color.Yellow
        Me.LabelCap2.Location = New System.Drawing.Point(94, 96)
        Me.LabelCap2.Name = "LabelCap2"
        Me.LabelCap2.Size = New System.Drawing.Size(54, 16)
        Me.LabelCap2.TabIndex = 327
        Me.LabelCap2.Text = "Preacher"
        '
        'LabelCap1
        '
        Me.LabelCap1.AutoSize = True
        Me.LabelCap1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCap1.ForeColor = System.Drawing.Color.Yellow
        Me.LabelCap1.Location = New System.Drawing.Point(94, 45)
        Me.LabelCap1.Name = "LabelCap1"
        Me.LabelCap1.Size = New System.Drawing.Size(44, 16)
        Me.LabelCap1.TabIndex = 326
        Me.LabelCap1.Text = "Leader"
        '
        'TextPreacherName
        '
        Me.TextPreacherName.BackColor = System.Drawing.Color.Black
        Me.TextPreacherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPreacherName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPreacherName.ForeColor = System.Drawing.Color.Yellow
        Me.TextPreacherName.Location = New System.Drawing.Point(98, 115)
        Me.TextPreacherName.Name = "TextPreacherName"
        Me.TextPreacherName.Size = New System.Drawing.Size(162, 29)
        Me.TextPreacherName.TabIndex = 325
        Me.TextPreacherName.Text = "..."
        Me.TextPreacherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextLeaderName
        '
        Me.TextLeaderName.BackColor = System.Drawing.Color.Black
        Me.TextLeaderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLeaderName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLeaderName.ForeColor = System.Drawing.Color.Yellow
        Me.TextLeaderName.Location = New System.Drawing.Point(98, 64)
        Me.TextLeaderName.Name = "TextLeaderName"
        Me.TextLeaderName.Size = New System.Drawing.Size(162, 29)
        Me.TextLeaderName.TabIndex = 324
        Me.TextLeaderName.Text = "..."
        Me.TextLeaderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListBoxMedia
        '
        Me.ListBoxMedia.BackColor = System.Drawing.Color.Black
        Me.ListBoxMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBoxMedia.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxMedia.ForeColor = System.Drawing.Color.Yellow
        Me.ListBoxMedia.FormattingEnabled = True
        Me.ListBoxMedia.ItemHeight = 22
        Me.ListBoxMedia.Items.AddRange(New Object() {"..."})
        Me.ListBoxMedia.Location = New System.Drawing.Point(96, 234)
        Me.ListBoxMedia.Name = "ListBoxMedia"
        Me.ListBoxMedia.Size = New System.Drawing.Size(163, 156)
        Me.ListBoxMedia.TabIndex = 323
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Yellow
        Me.Label28.Location = New System.Drawing.Point(6, 211)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(88, 20)
        Me.Label28.TabIndex = 322
        Me.Label28.Text = "Media player"
        '
        'BtnMNext
        '
        Me.BtnMNext.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnMNext.Image = CType(resources.GetObject("BtnMNext.Image"), System.Drawing.Image)
        Me.BtnMNext.Location = New System.Drawing.Point(7, 310)
        Me.BtnMNext.Name = "BtnMNext"
        Me.BtnMNext.Size = New System.Drawing.Size(80, 80)
        Me.BtnMNext.TabIndex = 321
        Me.BtnMNext.Text = ""
        Me.BtnMNext.UseVisualStyleBackColor = True
        '
        'BtnMPrev
        '
        Me.BtnMPrev.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.BtnMPrev.Image = CType(resources.GetObject("BtnMPrev.Image"), System.Drawing.Image)
        Me.BtnMPrev.Location = New System.Drawing.Point(7, 230)
        Me.BtnMPrev.Name = "BtnMPrev"
        Me.BtnMPrev.Size = New System.Drawing.Size(80, 80)
        Me.BtnMPrev.TabIndex = 320
        Me.BtnMPrev.Text = ""
        Me.BtnMPrev.UseVisualStyleBackColor = True
        '
        'BtnLiveFast
        '
        Me.BtnLiveFast.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLiveFast.Image = CType(resources.GetObject("BtnLiveFast.Image"), System.Drawing.Image)
        Me.BtnLiveFast.Location = New System.Drawing.Point(184, 398)
        Me.BtnLiveFast.Name = "BtnLiveFast"
        Me.BtnLiveFast.Size = New System.Drawing.Size(75, 75)
        Me.BtnLiveFast.TabIndex = 243
        Me.BtnLiveFast.Text = "Fast"
        Me.BtnLiveFast.UseVisualStyleBackColor = True
        '
        'BtnSlowIn
        '
        Me.BtnSlowIn.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSlowIn.Image = CType(resources.GetObject("BtnSlowIn.Image"), System.Drawing.Image)
        Me.BtnSlowIn.Location = New System.Drawing.Point(470, 488)
        Me.BtnSlowIn.Name = "BtnSlowIn"
        Me.BtnSlowIn.Size = New System.Drawing.Size(100, 100)
        Me.BtnSlowIn.TabIndex = 153
        Me.BtnSlowIn.Text = "Zoom in"
        Me.BtnSlowIn.UseVisualStyleBackColor = True
        '
        'BtnSlowOut
        '
        Me.BtnSlowOut.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSlowOut.Image = CType(resources.GetObject("BtnSlowOut.Image"), System.Drawing.Image)
        Me.BtnSlowOut.Location = New System.Drawing.Point(570, 488)
        Me.BtnSlowOut.Name = "BtnSlowOut"
        Me.BtnSlowOut.Size = New System.Drawing.Size(100, 100)
        Me.BtnSlowOut.TabIndex = 154
        Me.BtnSlowOut.Text = "Zoom out"
        Me.BtnSlowOut.UseVisualStyleBackColor = True
        '
        'BtnLive
        '
        Me.BtnLive.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLive.Image = CType(resources.GetObject("BtnLive.Image"), System.Drawing.Image)
        Me.BtnLive.Location = New System.Drawing.Point(179, 508)
        Me.BtnLive.Name = "BtnLive"
        Me.BtnLive.Size = New System.Drawing.Size(80, 80)
        Me.BtnLive.TabIndex = 236
        Me.BtnLive.Text = "  Live   move"
        Me.BtnLive.UseVisualStyleBackColor = True
        '
        'BtnLivePTZ
        '
        Me.BtnLivePTZ.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLivePTZ.Image = CType(resources.GetObject("BtnLivePTZ.Image"), System.Drawing.Image)
        Me.BtnLivePTZ.Location = New System.Drawing.Point(93, 508)
        Me.BtnLivePTZ.Name = "BtnLivePTZ"
        Me.BtnLivePTZ.Size = New System.Drawing.Size(80, 80)
        Me.BtnLivePTZ.TabIndex = 237
        Me.BtnLivePTZ.Text = "Joystick live"
        Me.BtnLivePTZ.UseVisualStyleBackColor = True
        '
        'BtnPreload
        '
        Me.BtnPreload.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreload.Image = CType(resources.GetObject("BtnPreload.Image"), System.Drawing.Image)
        Me.BtnPreload.Location = New System.Drawing.Point(670, 488)
        Me.BtnPreload.Name = "BtnPreload"
        Me.BtnPreload.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreload.TabIndex = 240
        Me.BtnPreload.Text = "Preload preset"
        Me.BtnPreload.UseVisualStyleBackColor = True
        '
        'BtnLiveSlow
        '
        Me.BtnLiveSlow.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLiveSlow.Image = CType(resources.GetObject("BtnLiveSlow.Image"), System.Drawing.Image)
        Me.BtnLiveSlow.Location = New System.Drawing.Point(104, 398)
        Me.BtnLiveSlow.Name = "BtnLiveSlow"
        Me.BtnLiveSlow.Size = New System.Drawing.Size(75, 75)
        Me.BtnLiveSlow.TabIndex = 244
        Me.BtnLiveSlow.Text = "Slow"
        Me.BtnLiveSlow.UseVisualStyleBackColor = True
        '
        'BtnPreset9
        '
        Me.BtnPreset9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset9.Image = CType(resources.GetObject("BtnPreset9.Image"), System.Drawing.Image)
        Me.BtnPreset9.Location = New System.Drawing.Point(370, 220)
        Me.BtnPreset9.Name = "BtnPreset9"
        Me.BtnPreset9.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset9.TabIndex = 166
        Me.BtnPreset9.Text = "9"
        Me.BtnPreset9.UseVisualStyleBackColor = True
        '
        'BtnPreset1
        '
        Me.BtnPreset1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset1.Image = CType(resources.GetObject("BtnPreset1.Image"), System.Drawing.Image)
        Me.BtnPreset1.Location = New System.Drawing.Point(370, 20)
        Me.BtnPreset1.Name = "BtnPreset1"
        Me.BtnPreset1.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset1.TabIndex = 156
        Me.BtnPreset1.Text = "1"
        Me.BtnPreset1.UseVisualStyleBackColor = True
        '
        'BtnPreset2
        '
        Me.BtnPreset2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset2.Image = CType(resources.GetObject("BtnPreset2.Image"), System.Drawing.Image)
        Me.BtnPreset2.Location = New System.Drawing.Point(470, 20)
        Me.BtnPreset2.Name = "BtnPreset2"
        Me.BtnPreset2.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset2.TabIndex = 157
        Me.BtnPreset2.Text = "2"
        Me.BtnPreset2.UseVisualStyleBackColor = True
        '
        'BtnPreset3
        '
        Me.BtnPreset3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset3.Image = CType(resources.GetObject("BtnPreset3.Image"), System.Drawing.Image)
        Me.BtnPreset3.Location = New System.Drawing.Point(570, 20)
        Me.BtnPreset3.Name = "BtnPreset3"
        Me.BtnPreset3.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset3.TabIndex = 158
        Me.BtnPreset3.Text = "3"
        Me.BtnPreset3.UseVisualStyleBackColor = True
        '
        'BtnPreset4
        '
        Me.BtnPreset4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset4.Image = CType(resources.GetObject("BtnPreset4.Image"), System.Drawing.Image)
        Me.BtnPreset4.Location = New System.Drawing.Point(670, 20)
        Me.BtnPreset4.Name = "BtnPreset4"
        Me.BtnPreset4.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset4.TabIndex = 159
        Me.BtnPreset4.Text = "4"
        Me.BtnPreset4.UseVisualStyleBackColor = True
        '
        'BtnPreset5
        '
        Me.BtnPreset5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset5.Image = CType(resources.GetObject("BtnPreset5.Image"), System.Drawing.Image)
        Me.BtnPreset5.Location = New System.Drawing.Point(370, 120)
        Me.BtnPreset5.Name = "BtnPreset5"
        Me.BtnPreset5.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset5.TabIndex = 160
        Me.BtnPreset5.Text = "5"
        Me.BtnPreset5.UseVisualStyleBackColor = True
        '
        'BtnPreset6
        '
        Me.BtnPreset6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset6.Image = CType(resources.GetObject("BtnPreset6.Image"), System.Drawing.Image)
        Me.BtnPreset6.Location = New System.Drawing.Point(470, 120)
        Me.BtnPreset6.Name = "BtnPreset6"
        Me.BtnPreset6.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset6.TabIndex = 161
        Me.BtnPreset6.Text = "6"
        Me.BtnPreset6.UseVisualStyleBackColor = True
        '
        'BtnPreset7
        '
        Me.BtnPreset7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset7.Image = CType(resources.GetObject("BtnPreset7.Image"), System.Drawing.Image)
        Me.BtnPreset7.Location = New System.Drawing.Point(571, 120)
        Me.BtnPreset7.Name = "BtnPreset7"
        Me.BtnPreset7.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset7.TabIndex = 162
        Me.BtnPreset7.Text = "7"
        Me.BtnPreset7.UseVisualStyleBackColor = True
        '
        'BtnPreset8
        '
        Me.BtnPreset8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset8.Image = CType(resources.GetObject("BtnPreset8.Image"), System.Drawing.Image)
        Me.BtnPreset8.Location = New System.Drawing.Point(670, 120)
        Me.BtnPreset8.Name = "BtnPreset8"
        Me.BtnPreset8.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset8.TabIndex = 163
        Me.BtnPreset8.Text = "8"
        Me.BtnPreset8.UseVisualStyleBackColor = True
        '
        'BtnPreset10
        '
        Me.BtnPreset10.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset10.Image = CType(resources.GetObject("BtnPreset10.Image"), System.Drawing.Image)
        Me.BtnPreset10.Location = New System.Drawing.Point(470, 220)
        Me.BtnPreset10.Name = "BtnPreset10"
        Me.BtnPreset10.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset10.TabIndex = 167
        Me.BtnPreset10.Text = "10"
        Me.BtnPreset10.UseVisualStyleBackColor = True
        '
        'BtnPreset11
        '
        Me.BtnPreset11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset11.Image = CType(resources.GetObject("BtnPreset11.Image"), System.Drawing.Image)
        Me.BtnPreset11.Location = New System.Drawing.Point(570, 220)
        Me.BtnPreset11.Name = "BtnPreset11"
        Me.BtnPreset11.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset11.TabIndex = 168
        Me.BtnPreset11.Text = "11"
        Me.BtnPreset11.UseVisualStyleBackColor = True
        '
        'BtnPreset12
        '
        Me.BtnPreset12.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset12.Image = CType(resources.GetObject("BtnPreset12.Image"), System.Drawing.Image)
        Me.BtnPreset12.Location = New System.Drawing.Point(670, 220)
        Me.BtnPreset12.Name = "BtnPreset12"
        Me.BtnPreset12.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset12.TabIndex = 169
        Me.BtnPreset12.Text = "12"
        Me.BtnPreset12.UseVisualStyleBackColor = True
        '
        'BtnPreset13
        '
        Me.BtnPreset13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset13.Image = CType(resources.GetObject("BtnPreset13.Image"), System.Drawing.Image)
        Me.BtnPreset13.Location = New System.Drawing.Point(370, 320)
        Me.BtnPreset13.Name = "BtnPreset13"
        Me.BtnPreset13.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset13.TabIndex = 170
        Me.BtnPreset13.Text = "13"
        Me.BtnPreset13.UseVisualStyleBackColor = True
        '
        'BtnPreset14
        '
        Me.BtnPreset14.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset14.Image = CType(resources.GetObject("BtnPreset14.Image"), System.Drawing.Image)
        Me.BtnPreset14.Location = New System.Drawing.Point(470, 320)
        Me.BtnPreset14.Name = "BtnPreset14"
        Me.BtnPreset14.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset14.TabIndex = 171
        Me.BtnPreset14.Text = "14"
        Me.BtnPreset14.UseVisualStyleBackColor = True
        '
        'BtnPreset15
        '
        Me.BtnPreset15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset15.Image = CType(resources.GetObject("BtnPreset15.Image"), System.Drawing.Image)
        Me.BtnPreset15.Location = New System.Drawing.Point(570, 320)
        Me.BtnPreset15.Name = "BtnPreset15"
        Me.BtnPreset15.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset15.TabIndex = 172
        Me.BtnPreset15.Text = "15"
        Me.BtnPreset15.UseVisualStyleBackColor = True
        '
        'BtnPreset16
        '
        Me.BtnPreset16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPreset16.Image = CType(resources.GetObject("BtnPreset16.Image"), System.Drawing.Image)
        Me.BtnPreset16.Location = New System.Drawing.Point(670, 320)
        Me.BtnPreset16.Name = "BtnPreset16"
        Me.BtnPreset16.Size = New System.Drawing.Size(100, 100)
        Me.BtnPreset16.TabIndex = 173
        Me.BtnPreset16.Text = "16"
        Me.BtnPreset16.UseVisualStyleBackColor = True
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShapeCapR, Me.LineShapeCapL, Me.LineShapeCapB, Me.LineShapeCapT})
        Me.ShapeContainer3.Size = New System.Drawing.Size(775, 600)
        Me.ShapeContainer3.TabIndex = 340
        Me.ShapeContainer3.TabStop = False
        '
        'LineShapeCapR
        '
        Me.LineShapeCapR.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeCapR.BorderWidth = 2
        Me.LineShapeCapR.Name = "LineShapeCapR"
        Me.LineShapeCapR.X1 = 264
        Me.LineShapeCapR.X2 = 264
        Me.LineShapeCapR.Y1 = 248
        Me.LineShapeCapR.Y2 = 282
        '
        'LineShapeCapL
        '
        Me.LineShapeCapL.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeCapL.BorderWidth = 2
        Me.LineShapeCapL.Name = "LineShapeCapL"
        Me.LineShapeCapL.X1 = 98
        Me.LineShapeCapL.X2 = 98
        Me.LineShapeCapL.Y1 = 248
        Me.LineShapeCapL.Y2 = 282
        '
        'LineShapeCapB
        '
        Me.LineShapeCapB.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeCapB.BorderWidth = 2
        Me.LineShapeCapB.Name = "LineShapeCapB"
        Me.LineShapeCapB.X1 = 98
        Me.LineShapeCapB.X2 = 264
        Me.LineShapeCapB.Y1 = 282
        Me.LineShapeCapB.Y2 = 282
        '
        'LineShapeCapT
        '
        Me.LineShapeCapT.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeCapT.BorderWidth = 2
        Me.LineShapeCapT.Name = "LineShapeCapT"
        Me.LineShapeCapT.X1 = 98
        Me.LineShapeCapT.X2 = 264
        Me.LineShapeCapT.Y1 = 249
        Me.LineShapeCapT.Y2 = 249
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ModeBtnSettings)
        Me.Panel1.Controls.Add(Me.ModeBtnCam)
        Me.Panel1.Controls.Add(Me.ModeBtnPresets)
        Me.Panel1.Controls.Add(Me.ShapeContainer2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(120, 600)
        Me.Panel1.TabIndex = 321
        '
        'ModeBtnSettings
        '
        Me.ModeBtnSettings.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeBtnSettings.Image = CType(resources.GetObject("ModeBtnSettings.Image"), System.Drawing.Image)
        Me.ModeBtnSettings.Location = New System.Drawing.Point(8, 225)
        Me.ModeBtnSettings.Name = "ModeBtnSettings"
        Me.ModeBtnSettings.Size = New System.Drawing.Size(100, 100)
        Me.ModeBtnSettings.TabIndex = 159
        Me.ModeBtnSettings.Text = "System Settings"
        Me.ModeBtnSettings.UseVisualStyleBackColor = True
        '
        'ModeBtnCam
        '
        Me.ModeBtnCam.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeBtnCam.Image = CType(resources.GetObject("ModeBtnCam.Image"), System.Drawing.Image)
        Me.ModeBtnCam.Location = New System.Drawing.Point(8, 116)
        Me.ModeBtnCam.Name = "ModeBtnCam"
        Me.ModeBtnCam.Size = New System.Drawing.Size(100, 100)
        Me.ModeBtnCam.TabIndex = 158
        Me.ModeBtnCam.Text = "Camera Settings"
        Me.ModeBtnCam.UseVisualStyleBackColor = True
        '
        'ModeBtnPresets
        '
        Me.ModeBtnPresets.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeBtnPresets.Image = CType(resources.GetObject("ModeBtnPresets.Image"), System.Drawing.Image)
        Me.ModeBtnPresets.Location = New System.Drawing.Point(8, 9)
        Me.ModeBtnPresets.Name = "ModeBtnPresets"
        Me.ModeBtnPresets.Size = New System.Drawing.Size(100, 100)
        Me.ModeBtnPresets.TabIndex = 157
        Me.ModeBtnPresets.Text = "Live"
        Me.ModeBtnPresets.UseVisualStyleBackColor = True
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShapeMode4, Me.LineShapeMode3, Me.LineShapeMode2, Me.LineShapeMode1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(120, 600)
        Me.ShapeContainer2.TabIndex = 160
        Me.ShapeContainer2.TabStop = False
        '
        'LineShapeMode4
        '
        Me.LineShapeMode4.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeMode4.BorderWidth = 2
        Me.LineShapeMode4.Name = "LineShapeMode4"
        Me.LineShapeMode4.X1 = 0
        Me.LineShapeMode4.X2 = 110
        Me.LineShapeMode4.Y1 = 380
        Me.LineShapeMode4.Y2 = 380
        '
        'LineShapeMode3
        '
        Me.LineShapeMode3.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeMode3.BorderWidth = 2
        Me.LineShapeMode3.Name = "LineShapeMode3"
        Me.LineShapeMode3.X1 = 0
        Me.LineShapeMode3.X2 = 110
        Me.LineShapeMode3.Y1 = 334
        Me.LineShapeMode3.Y2 = 334
        '
        'LineShapeMode2
        '
        Me.LineShapeMode2.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeMode2.BorderWidth = 2
        Me.LineShapeMode2.Name = "LineShapeMode2"
        Me.LineShapeMode2.X1 = 110
        Me.LineShapeMode2.X2 = 110
        Me.LineShapeMode2.Y1 = 0
        Me.LineShapeMode2.Y2 = 600
        '
        'LineShapeMode1
        '
        Me.LineShapeMode1.BorderColor = System.Drawing.Color.Yellow
        Me.LineShapeMode1.BorderWidth = 2
        Me.LineShapeMode1.Name = "LineShapeMode1"
        Me.LineShapeMode1.X1 = 110
        Me.LineShapeMode1.X2 = 110
        Me.LineShapeMode1.Y1 = 0
        Me.LineShapeMode1.Y2 = 600
        '
        'CamPanel
        '
        Me.CamPanel.Controls.Add(Me.MyButtonAutoWB)
        Me.CamPanel.Controls.Add(Me.MyButtonAutoAgc)
        Me.CamPanel.Controls.Add(Me.MyButtonAutoIris)
        Me.CamPanel.Controls.Add(Me.TextBoxFocus)
        Me.CamPanel.Controls.Add(Me.MyButtonFullTele)
        Me.CamPanel.Controls.Add(Me.MyButtonFullWide)
        Me.CamPanel.Controls.Add(Me.MyButtonCamTele)
        Me.CamPanel.Controls.Add(Me.MyButtonCamWide)
        Me.CamPanel.Controls.Add(Me.Label29)
        Me.CamPanel.Controls.Add(Me.Label23)
        Me.CamPanel.Controls.Add(Me.TextBoxCam4Rec)
        Me.CamPanel.Controls.Add(Me.TextBoxCam3Rec)
        Me.CamPanel.Controls.Add(Me.TextBoxCam2Rec)
        Me.CamPanel.Controls.Add(Me.Button8)
        Me.CamPanel.Controls.Add(Me.TextBoxCam1Rec)
        Me.CamPanel.Controls.Add(Me.TextPlayerTime)
        Me.CamPanel.Controls.Add(Me.BtnCam4Rec)
        Me.CamPanel.Controls.Add(Me.BtnCam3Rec)
        Me.CamPanel.Controls.Add(Me.BtnCam2Rec)
        Me.CamPanel.Controls.Add(Me.BtnCam1Rec)
        Me.CamPanel.Controls.Add(Me.BtnFocusUp)
        Me.CamPanel.Controls.Add(Me.BtnFocusDn)
        Me.CamPanel.Controls.Add(Me.BtnFocusLock)
        Me.CamPanel.Controls.Add(Me.BtnFocusAuto)
        Me.CamPanel.Controls.Add(Me.Label12)
        Me.CamPanel.Controls.Add(Me.Label10)
        Me.CamPanel.Controls.Add(Me.Label11)
        Me.CamPanel.Controls.Add(Me.BtnWbBlueUp)
        Me.CamPanel.Controls.Add(Me.BtnSlow)
        Me.CamPanel.Controls.Add(Me.BtnWbBlueDn)
        Me.CamPanel.Controls.Add(Me.BtnFast)
        Me.CamPanel.Controls.Add(Me.BtnWbRedUp)
        Me.CamPanel.Controls.Add(Me.BtnWbRedDn)
        Me.CamPanel.Controls.Add(Me.Label21)
        Me.CamPanel.Controls.Add(Me.Label9)
        Me.CamPanel.Controls.Add(Me.MyButtonCamDR)
        Me.CamPanel.Controls.Add(Me.BtnAEShiftUp)
        Me.CamPanel.Controls.Add(Me.MyButtonCamD)
        Me.CamPanel.Controls.Add(Me.BtnAEShiftDn)
        Me.CamPanel.Controls.Add(Me.MyButtonCamDL)
        Me.CamPanel.Controls.Add(Me.MyButtonCamR)
        Me.CamPanel.Controls.Add(Me.Label8)
        Me.CamPanel.Controls.Add(Me.MyButtonCamL)
        Me.CamPanel.Controls.Add(Me.BtnGainUp)
        Me.CamPanel.Controls.Add(Me.MyButtonCamUR)
        Me.CamPanel.Controls.Add(Me.BtnGainDown)
        Me.CamPanel.Controls.Add(Me.MyButtonCamU)
        Me.CamPanel.Controls.Add(Me.BtnAGCUp)
        Me.CamPanel.Controls.Add(Me.MyButtonCamUL)
        Me.CamPanel.Controls.Add(Me.BtnAGCDown)
        Me.CamPanel.Controls.Add(Me.Label20)
        Me.CamPanel.Controls.Add(Me.Label19)
        Me.CamPanel.Controls.Add(Me.BtnIrisUp)
        Me.CamPanel.Controls.Add(Me.TextBoxWB)
        Me.CamPanel.Controls.Add(Me.TextBox8)
        Me.CamPanel.Controls.Add(Me.TextBoxAgcLimit)
        Me.CamPanel.Controls.Add(Me.TextBoxAeShift)
        Me.CamPanel.Controls.Add(Me.TextBoxAgc)
        Me.CamPanel.Controls.Add(Me.BtnIrisDown)
        Me.CamPanel.Controls.Add(Me.TextBoxIris)
        Me.CamPanel.Controls.Add(Me.OverrideBtn)
        Me.CamPanel.Location = New System.Drawing.Point(131, 12)
        Me.CamPanel.Name = "CamPanel"
        Me.CamPanel.Size = New System.Drawing.Size(784, 600)
        Me.CamPanel.TabIndex = 322
        '
        'MyButtonAutoWB
        '
        Me.MyButtonAutoWB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonAutoWB.Image = CType(resources.GetObject("MyButtonAutoWB.Image"), System.Drawing.Image)
        Me.MyButtonAutoWB.Location = New System.Drawing.Point(659, 180)
        Me.MyButtonAutoWB.Name = "MyButtonAutoWB"
        Me.MyButtonAutoWB.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonAutoWB.TabIndex = 306
        Me.MyButtonAutoWB.Text = "Auto WB"
        Me.MyButtonAutoWB.UseVisualStyleBackColor = True
        '
        'MyButtonAutoAgc
        '
        Me.MyButtonAutoAgc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonAutoAgc.Image = CType(resources.GetObject("MyButtonAutoAgc.Image"), System.Drawing.Image)
        Me.MyButtonAutoAgc.Location = New System.Drawing.Point(461, 180)
        Me.MyButtonAutoAgc.Name = "MyButtonAutoAgc"
        Me.MyButtonAutoAgc.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonAutoAgc.TabIndex = 305
        Me.MyButtonAutoAgc.Text = "Auto AGC"
        Me.MyButtonAutoAgc.UseVisualStyleBackColor = True
        '
        'MyButtonAutoIris
        '
        Me.MyButtonAutoIris.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonAutoIris.Image = CType(resources.GetObject("MyButtonAutoIris.Image"), System.Drawing.Image)
        Me.MyButtonAutoIris.Location = New System.Drawing.Point(395, 180)
        Me.MyButtonAutoIris.Name = "MyButtonAutoIris"
        Me.MyButtonAutoIris.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonAutoIris.TabIndex = 304
        Me.MyButtonAutoIris.Text = "Auto Iris"
        Me.MyButtonAutoIris.UseVisualStyleBackColor = True
        '
        'TextBoxFocus
        '
        Me.TextBoxFocus.BackColor = System.Drawing.Color.Black
        Me.TextBoxFocus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxFocus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFocus.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxFocus.Location = New System.Drawing.Point(329, 93)
        Me.TextBoxFocus.Name = "TextBoxFocus"
        Me.TextBoxFocus.Size = New System.Drawing.Size(60, 29)
        Me.TextBoxFocus.TabIndex = 303
        Me.TextBoxFocus.Text = "17"
        Me.TextBoxFocus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MyButtonFullTele
        '
        Me.MyButtonFullTele.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonFullTele.Image = CType(resources.GetObject("MyButtonFullTele.Image"), System.Drawing.Image)
        Me.MyButtonFullTele.Location = New System.Drawing.Point(214, 7)
        Me.MyButtonFullTele.Name = "MyButtonFullTele"
        Me.MyButtonFullTele.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonFullTele.TabIndex = 302
        Me.MyButtonFullTele.Text = "Full  Tele"
        Me.MyButtonFullTele.UseVisualStyleBackColor = True
        '
        'MyButtonFullWide
        '
        Me.MyButtonFullWide.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonFullWide.Image = CType(resources.GetObject("MyButtonFullWide.Image"), System.Drawing.Image)
        Me.MyButtonFullWide.Location = New System.Drawing.Point(215, 216)
        Me.MyButtonFullWide.Name = "MyButtonFullWide"
        Me.MyButtonFullWide.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonFullWide.TabIndex = 301
        Me.MyButtonFullWide.Text = "Full  Wide"
        Me.MyButtonFullWide.UseVisualStyleBackColor = True
        '
        'MyButtonCamTele
        '
        Me.MyButtonCamTele.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonCamTele.Image = CType(resources.GetObject("MyButtonCamTele.Image"), System.Drawing.Image)
        Me.MyButtonCamTele.Location = New System.Drawing.Point(214, 69)
        Me.MyButtonCamTele.Name = "MyButtonCamTele"
        Me.MyButtonCamTele.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamTele.TabIndex = 300
        Me.MyButtonCamTele.Text = "Tele"
        Me.MyButtonCamTele.UseVisualStyleBackColor = True
        '
        'MyButtonCamWide
        '
        Me.MyButtonCamWide.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButtonCamWide.Image = CType(resources.GetObject("MyButtonCamWide.Image"), System.Drawing.Image)
        Me.MyButtonCamWide.Location = New System.Drawing.Point(214, 155)
        Me.MyButtonCamWide.Name = "MyButtonCamWide"
        Me.MyButtonCamWide.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamWide.TabIndex = 299
        Me.MyButtonCamWide.Text = "Wide"
        Me.MyButtonCamWide.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Yellow
        Me.Label29.Location = New System.Drawing.Point(19, 13)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(151, 20)
        Me.Label29.TabIndex = 298
        Me.Label29.Text = "Pan Tilt Zoom override"
        Me.Label29.Visible = False
        '
        'BtnCam4Rec
        '
        Me.BtnCam4Rec.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam4Rec.Image = CType(resources.GetObject("BtnCam4Rec.Image"), System.Drawing.Image)
        Me.BtnCam4Rec.Location = New System.Drawing.Point(22, 514)
        Me.BtnCam4Rec.Name = "BtnCam4Rec"
        Me.BtnCam4Rec.Size = New System.Drawing.Size(60, 60)
        Me.BtnCam4Rec.TabIndex = 283
        Me.BtnCam4Rec.Text = "Cam4   REC"
        Me.BtnCam4Rec.UseVisualStyleBackColor = True
        '
        'BtnCam3Rec
        '
        Me.BtnCam3Rec.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam3Rec.Image = CType(resources.GetObject("BtnCam3Rec.Image"), System.Drawing.Image)
        Me.BtnCam3Rec.Location = New System.Drawing.Point(22, 448)
        Me.BtnCam3Rec.Name = "BtnCam3Rec"
        Me.BtnCam3Rec.Size = New System.Drawing.Size(60, 60)
        Me.BtnCam3Rec.TabIndex = 282
        Me.BtnCam3Rec.Text = "Cam3   REC"
        Me.BtnCam3Rec.UseVisualStyleBackColor = True
        '
        'BtnCam2Rec
        '
        Me.BtnCam2Rec.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam2Rec.Image = CType(resources.GetObject("BtnCam2Rec.Image"), System.Drawing.Image)
        Me.BtnCam2Rec.Location = New System.Drawing.Point(22, 382)
        Me.BtnCam2Rec.Name = "BtnCam2Rec"
        Me.BtnCam2Rec.Size = New System.Drawing.Size(60, 60)
        Me.BtnCam2Rec.TabIndex = 281
        Me.BtnCam2Rec.Text = "Cam2   REC"
        Me.BtnCam2Rec.UseVisualStyleBackColor = True
        '
        'BtnCam1Rec
        '
        Me.BtnCam1Rec.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam1Rec.Image = CType(resources.GetObject("BtnCam1Rec.Image"), System.Drawing.Image)
        Me.BtnCam1Rec.Location = New System.Drawing.Point(22, 316)
        Me.BtnCam1Rec.Name = "BtnCam1Rec"
        Me.BtnCam1Rec.Size = New System.Drawing.Size(60, 60)
        Me.BtnCam1Rec.TabIndex = 280
        Me.BtnCam1Rec.Text = "Cam1   REC"
        Me.BtnCam1Rec.UseVisualStyleBackColor = True
        '
        'BtnFocusLock
        '
        Me.BtnFocusLock.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFocusLock.Image = CType(resources.GetObject("BtnFocusLock.Image"), System.Drawing.Image)
        Me.BtnFocusLock.Location = New System.Drawing.Point(329, 246)
        Me.BtnFocusLock.Name = "BtnFocusLock"
        Me.BtnFocusLock.Size = New System.Drawing.Size(60, 60)
        Me.BtnFocusLock.TabIndex = 211
        Me.BtnFocusLock.Text = "Lock"
        Me.BtnFocusLock.UseVisualStyleBackColor = True
        '
        'BtnFocusAuto
        '
        Me.BtnFocusAuto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFocusAuto.Image = CType(resources.GetObject("BtnFocusAuto.Image"), System.Drawing.Image)
        Me.BtnFocusAuto.Location = New System.Drawing.Point(329, 180)
        Me.BtnFocusAuto.Name = "BtnFocusAuto"
        Me.BtnFocusAuto.Size = New System.Drawing.Size(60, 60)
        Me.BtnFocusAuto.TabIndex = 210
        Me.BtnFocusAuto.Text = "Auto Focus"
        Me.BtnFocusAuto.UseVisualStyleBackColor = True
        '
        'BtnSlow
        '
        Me.BtnSlow.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSlow.Image = CType(resources.GetObject("BtnSlow.Image"), System.Drawing.Image)
        Me.BtnSlow.Location = New System.Drawing.Point(133, 238)
        Me.BtnSlow.Name = "BtnSlow"
        Me.BtnSlow.Size = New System.Drawing.Size(60, 60)
        Me.BtnSlow.TabIndex = 234
        Me.BtnSlow.Text = "Slow"
        Me.BtnSlow.UseVisualStyleBackColor = True
        '
        'BtnFast
        '
        Me.BtnFast.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFast.Image = CType(resources.GetObject("BtnFast.Image"), System.Drawing.Image)
        Me.BtnFast.Location = New System.Drawing.Point(48, 238)
        Me.BtnFast.Name = "BtnFast"
        Me.BtnFast.Size = New System.Drawing.Size(60, 60)
        Me.BtnFast.TabIndex = 233
        Me.BtnFast.Text = "Fast"
        Me.BtnFast.UseVisualStyleBackColor = True
        '
        'MyButtonCamDR
        '
        Me.MyButtonCamDR.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamDR.Image = CType(resources.GetObject("MyButtonCamDR.Image"), System.Drawing.Image)
        Me.MyButtonCamDR.Location = New System.Drawing.Point(148, 166)
        Me.MyButtonCamDR.Name = "MyButtonCamDR"
        Me.MyButtonCamDR.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamDR.TabIndex = 223
        Me.MyButtonCamDR.Text = ""
        Me.MyButtonCamDR.UseVisualStyleBackColor = True
        '
        'MyButtonCamD
        '
        Me.MyButtonCamD.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamD.Image = CType(resources.GetObject("MyButtonCamD.Image"), System.Drawing.Image)
        Me.MyButtonCamD.Location = New System.Drawing.Point(86, 166)
        Me.MyButtonCamD.Name = "MyButtonCamD"
        Me.MyButtonCamD.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamD.TabIndex = 222
        Me.MyButtonCamD.Text = ""
        Me.MyButtonCamD.UseVisualStyleBackColor = True
        '
        'MyButtonCamDL
        '
        Me.MyButtonCamDL.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamDL.Image = CType(resources.GetObject("MyButtonCamDL.Image"), System.Drawing.Image)
        Me.MyButtonCamDL.Location = New System.Drawing.Point(22, 166)
        Me.MyButtonCamDL.Name = "MyButtonCamDL"
        Me.MyButtonCamDL.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamDL.TabIndex = 221
        Me.MyButtonCamDL.Text = ""
        Me.MyButtonCamDL.UseVisualStyleBackColor = True
        '
        'MyButtonCamR
        '
        Me.MyButtonCamR.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamR.Image = CType(resources.GetObject("MyButtonCamR.Image"), System.Drawing.Image)
        Me.MyButtonCamR.Location = New System.Drawing.Point(148, 100)
        Me.MyButtonCamR.Name = "MyButtonCamR"
        Me.MyButtonCamR.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamR.TabIndex = 220
        Me.MyButtonCamR.Text = ""
        Me.MyButtonCamR.UseVisualStyleBackColor = True
        '
        'MyButtonCamL
        '
        Me.MyButtonCamL.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamL.Image = CType(resources.GetObject("MyButtonCamL.Image"), System.Drawing.Image)
        Me.MyButtonCamL.Location = New System.Drawing.Point(22, 99)
        Me.MyButtonCamL.Name = "MyButtonCamL"
        Me.MyButtonCamL.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamL.TabIndex = 219
        Me.MyButtonCamL.Text = ""
        Me.MyButtonCamL.UseVisualStyleBackColor = True
        '
        'MyButtonCamUR
        '
        Me.MyButtonCamUR.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamUR.Image = CType(resources.GetObject("MyButtonCamUR.Image"), System.Drawing.Image)
        Me.MyButtonCamUR.Location = New System.Drawing.Point(148, 33)
        Me.MyButtonCamUR.Name = "MyButtonCamUR"
        Me.MyButtonCamUR.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamUR.TabIndex = 218
        Me.MyButtonCamUR.Text = ""
        Me.MyButtonCamUR.UseVisualStyleBackColor = True
        '
        'MyButtonCamU
        '
        Me.MyButtonCamU.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamU.Image = CType(resources.GetObject("MyButtonCamU.Image"), System.Drawing.Image)
        Me.MyButtonCamU.Location = New System.Drawing.Point(86, 33)
        Me.MyButtonCamU.Name = "MyButtonCamU"
        Me.MyButtonCamU.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamU.TabIndex = 217
        Me.MyButtonCamU.Text = ""
        Me.MyButtonCamU.UseVisualStyleBackColor = True
        '
        'MyButtonCamUL
        '
        Me.MyButtonCamUL.Font = New System.Drawing.Font("Wingdings", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MyButtonCamUL.Image = CType(resources.GetObject("MyButtonCamUL.Image"), System.Drawing.Image)
        Me.MyButtonCamUL.Location = New System.Drawing.Point(22, 33)
        Me.MyButtonCamUL.Name = "MyButtonCamUL"
        Me.MyButtonCamUL.Size = New System.Drawing.Size(60, 60)
        Me.MyButtonCamUL.TabIndex = 216
        Me.MyButtonCamUL.Text = ""
        Me.MyButtonCamUL.UseVisualStyleBackColor = True
        '
        'OverrideBtn
        '
        Me.OverrideBtn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverrideBtn.Image = CType(resources.GetObject("OverrideBtn.Image"), System.Drawing.Image)
        Me.OverrideBtn.Location = New System.Drawing.Point(623, 488)
        Me.OverrideBtn.Name = "OverrideBtn"
        Me.OverrideBtn.Size = New System.Drawing.Size(60, 60)
        Me.OverrideBtn.TabIndex = 238
        Me.OverrideBtn.Text = "Over ride"
        Me.OverrideBtn.UseVisualStyleBackColor = True
        Me.OverrideBtn.Visible = False
        '
        'SettingsPanel
        '
        Me.SettingsPanel.Controls.Add(Me.Label30)
        Me.SettingsPanel.Controls.Add(Me.ButtonTouchscreen)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxSaveAE)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxSaveIris)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxSaveFocus)
        Me.SettingsPanel.Controls.Add(Me.ButtonRetryCam)
        Me.SettingsPanel.Controls.Add(Me.Label25)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupSaveNew)
        Me.SettingsPanel.Controls.Add(Me.Label26)
        Me.SettingsPanel.Controls.Add(Me.TextBoxPresetNewFile)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxCam4Dis)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxCam3Dis)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxCam2Dis)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxCam1Dis)
        Me.SettingsPanel.Controls.Add(Me.Label2)
        Me.SettingsPanel.Controls.Add(Me.Label3)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxCam5Dis)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupOsd)
        Me.SettingsPanel.Controls.Add(Me.ButtonRetryOBS)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupDown)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupUp)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupEnter)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupMenu)
        Me.SettingsPanel.Controls.Add(Me.LblCamStatus5)
        Me.SettingsPanel.Controls.Add(Me.TextBoxIPCam5)
        Me.SettingsPanel.Controls.Add(Me.Label6)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxStandby)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxProfile)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupFolderBrowse)
        Me.SettingsPanel.Controls.Add(Me.Label7)
        Me.SettingsPanel.Controls.Add(Me.TextBoxPresetFolder)
        Me.SettingsPanel.Controls.Add(Me.LblCamStatus4)
        Me.SettingsPanel.Controls.Add(Me.LblCamStatus3)
        Me.SettingsPanel.Controls.Add(Me.LblCamStatus2)
        Me.SettingsPanel.Controls.Add(Me.LblCamStatus1)
        Me.SettingsPanel.Controls.Add(Me.Label31)
        Me.SettingsPanel.Controls.Add(Me.BtnSetupFilenameBrowse)
        Me.SettingsPanel.Controls.Add(Me.Label32)
        Me.SettingsPanel.Controls.Add(Me.Button1)
        Me.SettingsPanel.Controls.Add(Me.TextBoxPresetFilename)
        Me.SettingsPanel.Controls.Add(Me.TextBoxIPCam4)
        Me.SettingsPanel.Controls.Add(Me.Label33)
        Me.SettingsPanel.Controls.Add(Me.TextBoxIPCam3)
        Me.SettingsPanel.Controls.Add(Me.Label34)
        Me.SettingsPanel.Controls.Add(Me.TextBoxIPCam2)
        Me.SettingsPanel.Controls.Add(Me.Label35)
        Me.SettingsPanel.Controls.Add(Me.TextBoxIPCam1)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxAutoSwap)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxTally)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxInvert4)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxInvert3)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxInvert2)
        Me.SettingsPanel.Controls.Add(Me.CheckBoxInvert1)
        Me.SettingsPanel.Controls.Add(Me.Label36)
        Me.SettingsPanel.Controls.Add(Me.ComboBoxSetupComport)
        Me.SettingsPanel.Controls.Add(Me.TextBox1)
        Me.SettingsPanel.Controls.Add(Me.Label37)
        Me.SettingsPanel.Controls.Add(Me.Label13)
        Me.SettingsPanel.Location = New System.Drawing.Point(820, 690)
        Me.SettingsPanel.Name = "SettingsPanel"
        Me.SettingsPanel.Size = New System.Drawing.Size(784, 600)
        Me.SettingsPanel.TabIndex = 323
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Yellow
        Me.Label30.Location = New System.Drawing.Point(67, 233)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 16)
        Me.Label30.TabIndex = 320
        Me.Label30.Text = "Fade time"
        '
        'ButtonTouchscreen
        '
        Me.ButtonTouchscreen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTouchscreen.Location = New System.Drawing.Point(545, 204)
        Me.ButtonTouchscreen.Name = "ButtonTouchscreen"
        Me.ButtonTouchscreen.Size = New System.Drawing.Size(80, 50)
        Me.ButtonTouchscreen.TabIndex = 319
        Me.ButtonTouchscreen.Text = "Touch Screen Setup"
        Me.ButtonTouchscreen.UseVisualStyleBackColor = True
        '
        'CheckBoxSaveAE
        '
        Me.CheckBoxSaveAE.AutoSize = True
        Me.CheckBoxSaveAE.Checked = True
        Me.CheckBoxSaveAE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSaveAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSaveAE.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxSaveAE.Location = New System.Drawing.Point(401, 543)
        Me.CheckBoxSaveAE.Name = "CheckBoxSaveAE"
        Me.CheckBoxSaveAE.Size = New System.Drawing.Size(193, 20)
        Me.CheckBoxSaveAE.TabIndex = 318
        Me.CheckBoxSaveAE.Text = "Save AE Shift in presets"
        Me.CheckBoxSaveAE.UseVisualStyleBackColor = True
        '
        'CheckBoxSaveIris
        '
        Me.CheckBoxSaveIris.AutoSize = True
        Me.CheckBoxSaveIris.Checked = True
        Me.CheckBoxSaveIris.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSaveIris.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSaveIris.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxSaveIris.Location = New System.Drawing.Point(236, 543)
        Me.CheckBoxSaveIris.Name = "CheckBoxSaveIris"
        Me.CheckBoxSaveIris.Size = New System.Drawing.Size(160, 20)
        Me.CheckBoxSaveIris.TabIndex = 317
        Me.CheckBoxSaveIris.Text = "Save iris in presets"
        Me.CheckBoxSaveIris.UseVisualStyleBackColor = True
        '
        'CheckBoxSaveFocus
        '
        Me.CheckBoxSaveFocus.AutoSize = True
        Me.CheckBoxSaveFocus.Checked = True
        Me.CheckBoxSaveFocus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSaveFocus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSaveFocus.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxSaveFocus.Location = New System.Drawing.Point(54, 543)
        Me.CheckBoxSaveFocus.Name = "CheckBoxSaveFocus"
        Me.CheckBoxSaveFocus.Size = New System.Drawing.Size(176, 20)
        Me.CheckBoxSaveFocus.TabIndex = 316
        Me.CheckBoxSaveFocus.Text = "Save focus in presets"
        Me.CheckBoxSaveFocus.UseVisualStyleBackColor = True
        '
        'ButtonRetryCam
        '
        Me.ButtonRetryCam.Location = New System.Drawing.Point(373, 204)
        Me.ButtonRetryCam.Name = "ButtonRetryCam"
        Me.ButtonRetryCam.Size = New System.Drawing.Size(80, 50)
        Me.ButtonRetryCam.TabIndex = 264
        Me.ButtonRetryCam.Text = "Retry cameras"
        Me.ButtonRetryCam.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Yellow
        Me.Label25.Location = New System.Drawing.Point(24, 281)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(179, 16)
        Me.Label25.TabIndex = 263
        Me.Label25.Text = "Camera onscreen menus"
        '
        'BtnSetupSaveNew
        '
        Me.BtnSetupSaveNew.Location = New System.Drawing.Point(566, 496)
        Me.BtnSetupSaveNew.Name = "BtnSetupSaveNew"
        Me.BtnSetupSaveNew.Size = New System.Drawing.Size(53, 23)
        Me.BtnSetupSaveNew.TabIndex = 262
        Me.BtnSetupSaveNew.Text = "Save"
        Me.BtnSetupSaveNew.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(277, 481)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(203, 16)
        Me.Label26.TabIndex = 261
        Me.Label26.Text = "Save presets with new name"
        '
        'TextBoxPresetNewFile
        '
        Me.TextBoxPresetNewFile.BackColor = System.Drawing.Color.Black
        Me.TextBoxPresetNewFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPresetNewFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPresetNewFile.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxPresetNewFile.Location = New System.Drawing.Point(272, 499)
        Me.TextBoxPresetNewFile.Name = "TextBoxPresetNewFile"
        Me.TextBoxPresetNewFile.Size = New System.Drawing.Size(288, 22)
        Me.TextBoxPresetNewFile.TabIndex = 260
        Me.TextBoxPresetNewFile.Text = "newpreset.aps"
        '
        'CheckBoxCam4Dis
        '
        Me.CheckBoxCam4Dis.AutoSize = True
        Me.CheckBoxCam4Dis.Checked = True
        Me.CheckBoxCam4Dis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCam4Dis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCam4Dis.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxCam4Dis.Location = New System.Drawing.Point(272, 159)
        Me.CheckBoxCam4Dis.Name = "CheckBoxCam4Dis"
        Me.CheckBoxCam4Dis.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxCam4Dis.TabIndex = 259
        Me.CheckBoxCam4Dis.UseVisualStyleBackColor = True
        '
        'CheckBoxCam3Dis
        '
        Me.CheckBoxCam3Dis.AutoSize = True
        Me.CheckBoxCam3Dis.Checked = True
        Me.CheckBoxCam3Dis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCam3Dis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCam3Dis.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxCam3Dis.Location = New System.Drawing.Point(272, 133)
        Me.CheckBoxCam3Dis.Name = "CheckBoxCam3Dis"
        Me.CheckBoxCam3Dis.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxCam3Dis.TabIndex = 258
        Me.CheckBoxCam3Dis.UseVisualStyleBackColor = True
        '
        'CheckBoxCam2Dis
        '
        Me.CheckBoxCam2Dis.AutoSize = True
        Me.CheckBoxCam2Dis.Checked = True
        Me.CheckBoxCam2Dis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCam2Dis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCam2Dis.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxCam2Dis.Location = New System.Drawing.Point(272, 107)
        Me.CheckBoxCam2Dis.Name = "CheckBoxCam2Dis"
        Me.CheckBoxCam2Dis.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxCam2Dis.TabIndex = 257
        Me.CheckBoxCam2Dis.UseVisualStyleBackColor = True
        '
        'CheckBoxCam1Dis
        '
        Me.CheckBoxCam1Dis.AutoSize = True
        Me.CheckBoxCam1Dis.Checked = True
        Me.CheckBoxCam1Dis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCam1Dis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCam1Dis.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxCam1Dis.Location = New System.Drawing.Point(272, 81)
        Me.CheckBoxCam1Dis.Name = "CheckBoxCam1Dis"
        Me.CheckBoxCam1Dis.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxCam1Dis.TabIndex = 256
        Me.CheckBoxCam1Dis.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(254, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "Cam disable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(74, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 16)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Camera IP address"
        '
        'CheckBoxCam5Dis
        '
        Me.CheckBoxCam5Dis.AutoSize = True
        Me.CheckBoxCam5Dis.Checked = True
        Me.CheckBoxCam5Dis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCam5Dis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCam5Dis.ForeColor = System.Drawing.Color.Black
        Me.CheckBoxCam5Dis.Location = New System.Drawing.Point(272, 185)
        Me.CheckBoxCam5Dis.Name = "CheckBoxCam5Dis"
        Me.CheckBoxCam5Dis.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxCam5Dis.TabIndex = 253
        Me.CheckBoxCam5Dis.UseVisualStyleBackColor = True
        '
        'BtnSetupOsd
        '
        Me.BtnSetupOsd.Location = New System.Drawing.Point(22, 300)
        Me.BtnSetupOsd.Name = "BtnSetupOsd"
        Me.BtnSetupOsd.Size = New System.Drawing.Size(60, 50)
        Me.BtnSetupOsd.TabIndex = 252
        Me.BtnSetupOsd.Text = "osd on"
        Me.BtnSetupOsd.UseVisualStyleBackColor = True
        '
        'BtnSetupDown
        '
        Me.BtnSetupDown.Location = New System.Drawing.Point(326, 300)
        Me.BtnSetupDown.Name = "BtnSetupDown"
        Me.BtnSetupDown.Size = New System.Drawing.Size(60, 50)
        Me.BtnSetupDown.TabIndex = 251
        Me.BtnSetupDown.Text = "down"
        Me.BtnSetupDown.UseVisualStyleBackColor = True
        '
        'BtnSetupUp
        '
        Me.BtnSetupUp.Location = New System.Drawing.Point(250, 300)
        Me.BtnSetupUp.Name = "BtnSetupUp"
        Me.BtnSetupUp.Size = New System.Drawing.Size(60, 50)
        Me.BtnSetupUp.TabIndex = 250
        Me.BtnSetupUp.Text = "up"
        Me.BtnSetupUp.UseVisualStyleBackColor = True
        '
        'BtnSetupEnter
        '
        Me.BtnSetupEnter.Location = New System.Drawing.Point(174, 300)
        Me.BtnSetupEnter.Name = "BtnSetupEnter"
        Me.BtnSetupEnter.Size = New System.Drawing.Size(60, 50)
        Me.BtnSetupEnter.TabIndex = 249
        Me.BtnSetupEnter.Text = "enter"
        Me.BtnSetupEnter.UseVisualStyleBackColor = True
        '
        'BtnSetupMenu
        '
        Me.BtnSetupMenu.Location = New System.Drawing.Point(98, 300)
        Me.BtnSetupMenu.Name = "BtnSetupMenu"
        Me.BtnSetupMenu.Size = New System.Drawing.Size(60, 50)
        Me.BtnSetupMenu.TabIndex = 248
        Me.BtnSetupMenu.Text = "osd off"
        Me.BtnSetupMenu.UseVisualStyleBackColor = True
        '
        'LblCamStatus5
        '
        Me.LblCamStatus5.AutoSize = True
        Me.LblCamStatus5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCamStatus5.ForeColor = System.Drawing.Color.Yellow
        Me.LblCamStatus5.Location = New System.Drawing.Point(370, 182)
        Me.LblCamStatus5.Name = "LblCamStatus5"
        Me.LblCamStatus5.Size = New System.Drawing.Size(28, 16)
        Me.LblCamStatus5.TabIndex = 247
        Me.LblCamStatus5.Text = "OK"
        '
        'TextBoxIPCam5
        '
        Me.TextBoxIPCam5.BackColor = System.Drawing.Color.Black
        Me.TextBoxIPCam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIPCam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIPCam5.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIPCam5.Location = New System.Drawing.Point(77, 182)
        Me.TextBoxIPCam5.Name = "TextBoxIPCam5"
        Me.TextBoxIPCam5.Size = New System.Drawing.Size(157, 22)
        Me.TextBoxIPCam5.TabIndex = 246
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(24, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 245
        Me.Label6.Text = "Cam5"
        '
        'CheckBoxStandby
        '
        Me.CheckBoxStandby.AutoSize = True
        Me.CheckBoxStandby.Checked = True
        Me.CheckBoxStandby.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxStandby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxStandby.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxStandby.Location = New System.Drawing.Point(23, 505)
        Me.CheckBoxStandby.Name = "CheckBoxStandby"
        Me.CheckBoxStandby.Size = New System.Drawing.Size(197, 20)
        Me.CheckBoxStandby.TabIndex = 244
        Me.CheckBoxStandby.Text = "Standby cameras on exit"
        Me.CheckBoxStandby.UseVisualStyleBackColor = True
        '
        'CheckBoxProfile
        '
        Me.CheckBoxProfile.AutoSize = True
        Me.CheckBoxProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxProfile.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxProfile.Location = New System.Drawing.Point(23, 454)
        Me.CheckBoxProfile.Name = "CheckBoxProfile"
        Me.CheckBoxProfile.Size = New System.Drawing.Size(225, 20)
        Me.CheckBoxProfile.TabIndex = 243
        Me.CheckBoxProfile.Text = "Ask to load profile on startup"
        Me.CheckBoxProfile.UseVisualStyleBackColor = True
        '
        'BtnSetupFolderBrowse
        '
        Me.BtnSetupFolderBrowse.Location = New System.Drawing.Point(566, 385)
        Me.BtnSetupFolderBrowse.Name = "BtnSetupFolderBrowse"
        Me.BtnSetupFolderBrowse.Size = New System.Drawing.Size(53, 23)
        Me.BtnSetupFolderBrowse.TabIndex = 242
        Me.BtnSetupFolderBrowse.Text = "Browse"
        Me.BtnSetupFolderBrowse.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(275, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 16)
        Me.Label7.TabIndex = 241
        Me.Label7.Text = "Folder for presets file"
        '
        'TextBoxPresetFolder
        '
        Me.TextBoxPresetFolder.BackColor = System.Drawing.Color.Black
        Me.TextBoxPresetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPresetFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPresetFolder.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxPresetFolder.Location = New System.Drawing.Point(272, 386)
        Me.TextBoxPresetFolder.Name = "TextBoxPresetFolder"
        Me.TextBoxPresetFolder.Size = New System.Drawing.Size(288, 22)
        Me.TextBoxPresetFolder.TabIndex = 240
        '
        'LblCamStatus4
        '
        Me.LblCamStatus4.AutoSize = True
        Me.LblCamStatus4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCamStatus4.ForeColor = System.Drawing.Color.Yellow
        Me.LblCamStatus4.Location = New System.Drawing.Point(370, 156)
        Me.LblCamStatus4.Name = "LblCamStatus4"
        Me.LblCamStatus4.Size = New System.Drawing.Size(28, 16)
        Me.LblCamStatus4.TabIndex = 239
        Me.LblCamStatus4.Text = "OK"
        '
        'LblCamStatus3
        '
        Me.LblCamStatus3.AutoSize = True
        Me.LblCamStatus3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCamStatus3.ForeColor = System.Drawing.Color.Yellow
        Me.LblCamStatus3.Location = New System.Drawing.Point(370, 133)
        Me.LblCamStatus3.Name = "LblCamStatus3"
        Me.LblCamStatus3.Size = New System.Drawing.Size(28, 16)
        Me.LblCamStatus3.TabIndex = 238
        Me.LblCamStatus3.Text = "OK"
        '
        'LblCamStatus2
        '
        Me.LblCamStatus2.AutoSize = True
        Me.LblCamStatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCamStatus2.ForeColor = System.Drawing.Color.Yellow
        Me.LblCamStatus2.Location = New System.Drawing.Point(370, 107)
        Me.LblCamStatus2.Name = "LblCamStatus2"
        Me.LblCamStatus2.Size = New System.Drawing.Size(28, 16)
        Me.LblCamStatus2.TabIndex = 237
        Me.LblCamStatus2.Text = "OK"
        '
        'LblCamStatus1
        '
        Me.LblCamStatus1.AutoSize = True
        Me.LblCamStatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCamStatus1.ForeColor = System.Drawing.Color.Yellow
        Me.LblCamStatus1.Location = New System.Drawing.Point(370, 81)
        Me.LblCamStatus1.Name = "LblCamStatus1"
        Me.LblCamStatus1.Size = New System.Drawing.Size(28, 16)
        Me.LblCamStatus1.TabIndex = 236
        Me.LblCamStatus1.Text = "OK"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Yellow
        Me.Label31.Location = New System.Drawing.Point(370, 59)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(84, 16)
        Me.Label31.TabIndex = 235
        Me.Label31.Text = "Cam status"
        '
        'BtnSetupFilenameBrowse
        '
        Me.BtnSetupFilenameBrowse.Location = New System.Drawing.Point(566, 440)
        Me.BtnSetupFilenameBrowse.Name = "BtnSetupFilenameBrowse"
        Me.BtnSetupFilenameBrowse.Size = New System.Drawing.Size(53, 23)
        Me.BtnSetupFilenameBrowse.TabIndex = 234
        Me.BtnSetupFilenameBrowse.Text = "Browse"
        Me.BtnSetupFilenameBrowse.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Yellow
        Me.Label32.Location = New System.Drawing.Point(277, 425)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(184, 16)
        Me.Label32.TabIndex = 233
        Me.Label32.Text = "Load different presets file"
        '
        'TextBoxPresetFilename
        '
        Me.TextBoxPresetFilename.BackColor = System.Drawing.Color.Black
        Me.TextBoxPresetFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPresetFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPresetFilename.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxPresetFilename.Location = New System.Drawing.Point(272, 443)
        Me.TextBoxPresetFilename.Name = "TextBoxPresetFilename"
        Me.TextBoxPresetFilename.Size = New System.Drawing.Size(288, 22)
        Me.TextBoxPresetFilename.TabIndex = 232
        '
        'TextBoxIPCam4
        '
        Me.TextBoxIPCam4.BackColor = System.Drawing.Color.Black
        Me.TextBoxIPCam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIPCam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIPCam4.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIPCam4.Location = New System.Drawing.Point(77, 156)
        Me.TextBoxIPCam4.Name = "TextBoxIPCam4"
        Me.TextBoxIPCam4.Size = New System.Drawing.Size(157, 22)
        Me.TextBoxIPCam4.TabIndex = 231
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Yellow
        Me.Label33.Location = New System.Drawing.Point(24, 163)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 16)
        Me.Label33.TabIndex = 230
        Me.Label33.Text = "Cam4"
        '
        'TextBoxIPCam3
        '
        Me.TextBoxIPCam3.BackColor = System.Drawing.Color.Black
        Me.TextBoxIPCam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIPCam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIPCam3.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIPCam3.Location = New System.Drawing.Point(77, 130)
        Me.TextBoxIPCam3.Name = "TextBoxIPCam3"
        Me.TextBoxIPCam3.Size = New System.Drawing.Size(157, 22)
        Me.TextBoxIPCam3.TabIndex = 229
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Yellow
        Me.Label34.Location = New System.Drawing.Point(24, 137)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 16)
        Me.Label34.TabIndex = 228
        Me.Label34.Text = "Cam3"
        '
        'TextBoxIPCam2
        '
        Me.TextBoxIPCam2.BackColor = System.Drawing.Color.Black
        Me.TextBoxIPCam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIPCam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIPCam2.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIPCam2.Location = New System.Drawing.Point(77, 104)
        Me.TextBoxIPCam2.Name = "TextBoxIPCam2"
        Me.TextBoxIPCam2.Size = New System.Drawing.Size(157, 22)
        Me.TextBoxIPCam2.TabIndex = 227
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Yellow
        Me.Label35.Location = New System.Drawing.Point(24, 111)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(47, 16)
        Me.Label35.TabIndex = 226
        Me.Label35.Text = "Cam2"
        '
        'TextBoxIPCam1
        '
        Me.TextBoxIPCam1.BackColor = System.Drawing.Color.Black
        Me.TextBoxIPCam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxIPCam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIPCam1.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxIPCam1.Location = New System.Drawing.Point(77, 78)
        Me.TextBoxIPCam1.Name = "TextBoxIPCam1"
        Me.TextBoxIPCam1.Size = New System.Drawing.Size(157, 22)
        Me.TextBoxIPCam1.TabIndex = 225
        '
        'CheckBoxAutoSwap
        '
        Me.CheckBoxAutoSwap.AutoSize = True
        Me.CheckBoxAutoSwap.Checked = True
        Me.CheckBoxAutoSwap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAutoSwap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxAutoSwap.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxAutoSwap.Location = New System.Drawing.Point(23, 431)
        Me.CheckBoxAutoSwap.Name = "CheckBoxAutoSwap"
        Me.CheckBoxAutoSwap.Size = New System.Drawing.Size(211, 20)
        Me.CheckBoxAutoSwap.TabIndex = 224
        Me.CheckBoxAutoSwap.Text = "Auto swap back to preview"
        Me.CheckBoxAutoSwap.UseVisualStyleBackColor = True
        '
        'CheckBoxTally
        '
        Me.CheckBoxTally.AutoSize = True
        Me.CheckBoxTally.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxTally.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxTally.Location = New System.Drawing.Point(23, 479)
        Me.CheckBoxTally.Name = "CheckBoxTally"
        Me.CheckBoxTally.Size = New System.Drawing.Size(150, 20)
        Me.CheckBoxTally.TabIndex = 223
        Me.CheckBoxTally.Text = "Enable tally lights"
        Me.CheckBoxTally.UseVisualStyleBackColor = True
        '
        'CheckBoxInvert4
        '
        Me.CheckBoxInvert4.AutoSize = True
        Me.CheckBoxInvert4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxInvert4.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxInvert4.Location = New System.Drawing.Point(472, 156)
        Me.CheckBoxInvert4.Name = "CheckBoxInvert4"
        Me.CheckBoxInvert4.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxInvert4.TabIndex = 222
        Me.CheckBoxInvert4.Text = "Cam4 invert"
        Me.CheckBoxInvert4.UseVisualStyleBackColor = True
        '
        'CheckBoxInvert3
        '
        Me.CheckBoxInvert3.AutoSize = True
        Me.CheckBoxInvert3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxInvert3.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxInvert3.Location = New System.Drawing.Point(472, 130)
        Me.CheckBoxInvert3.Name = "CheckBoxInvert3"
        Me.CheckBoxInvert3.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxInvert3.TabIndex = 221
        Me.CheckBoxInvert3.Text = "Cam3 invert"
        Me.CheckBoxInvert3.UseVisualStyleBackColor = True
        '
        'CheckBoxInvert2
        '
        Me.CheckBoxInvert2.AutoSize = True
        Me.CheckBoxInvert2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxInvert2.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxInvert2.Location = New System.Drawing.Point(472, 104)
        Me.CheckBoxInvert2.Name = "CheckBoxInvert2"
        Me.CheckBoxInvert2.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxInvert2.TabIndex = 220
        Me.CheckBoxInvert2.Text = "Cam2 invert"
        Me.CheckBoxInvert2.UseVisualStyleBackColor = True
        '
        'CheckBoxInvert1
        '
        Me.CheckBoxInvert1.AutoSize = True
        Me.CheckBoxInvert1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxInvert1.ForeColor = System.Drawing.Color.Yellow
        Me.CheckBoxInvert1.Location = New System.Drawing.Point(472, 78)
        Me.CheckBoxInvert1.Name = "CheckBoxInvert1"
        Me.CheckBoxInvert1.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxInvert1.TabIndex = 219
        Me.CheckBoxInvert1.Text = "Cam1 invert"
        Me.CheckBoxInvert1.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Yellow
        Me.Label36.Location = New System.Drawing.Point(24, 364)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(172, 16)
        Me.Label36.TabIndex = 218
        Me.Label36.Text = "PTZ Controller com port"
        '
        'ComboBoxSetupComport
        '
        Me.ComboBoxSetupComport.BackColor = System.Drawing.Color.Black
        Me.ComboBoxSetupComport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxSetupComport.ForeColor = System.Drawing.Color.Yellow
        Me.ComboBoxSetupComport.FormattingEnabled = True
        Me.ComboBoxSetupComport.Location = New System.Drawing.Point(27, 383)
        Me.ComboBoxSetupComport.Name = "ComboBoxSetupComport"
        Me.ComboBoxSetupComport.Size = New System.Drawing.Size(164, 24)
        Me.ComboBoxSetupComport.TabIndex = 217
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Yellow
        Me.Label37.Location = New System.Drawing.Point(24, 85)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(47, 16)
        Me.Label37.TabIndex = 216
        Me.Label37.Text = "Cam1"
        '
        'StatPanel
        '
        Me.StatPanel.Controls.Add(Me.TextBoxOBSRecTime)
        Me.StatPanel.Controls.Add(Me.BtnOBSRecord)
        Me.StatPanel.Controls.Add(Me.BtnOBSBroadcast)
        Me.StatPanel.Controls.Add(Me.TextBoxOBSBroadcastTime)
        Me.StatPanel.Controls.Add(Me.LabelEncB)
        Me.StatPanel.Controls.Add(Me.PictureBox2)
        Me.StatPanel.Controls.Add(Me.TextEncBStatus)
        Me.StatPanel.Controls.Add(Me.LabelEncA)
        Me.StatPanel.Controls.Add(Me.PictureBox1)
        Me.StatPanel.Controls.Add(Me.TextEncAStatus)
        Me.StatPanel.Controls.Add(Me.LabelEncStatus)
        Me.StatPanel.Controls.Add(Me.ShapeContainer4)
        Me.StatPanel.Location = New System.Drawing.Point(904, 0)
        Me.StatPanel.Name = "StatPanel"
        Me.StatPanel.Size = New System.Drawing.Size(120, 600)
        Me.StatPanel.TabIndex = 324
        '
        'TextBoxOBSRecTime
        '
        Me.TextBoxOBSRecTime.BackColor = System.Drawing.Color.Black
        Me.TextBoxOBSRecTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxOBSRecTime.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOBSRecTime.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxOBSRecTime.Location = New System.Drawing.Point(17, 566)
        Me.TextBoxOBSRecTime.Name = "TextBoxOBSRecTime"
        Me.TextBoxOBSRecTime.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxOBSRecTime.TabIndex = 300
        Me.TextBoxOBSRecTime.Text = "..."
        Me.TextBoxOBSRecTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnOBSRecord
        '
        Me.BtnOBSRecord.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOBSRecord.Image = CType(resources.GetObject("BtnOBSRecord.Image"), System.Drawing.Image)
        Me.BtnOBSRecord.Location = New System.Drawing.Point(17, 460)
        Me.BtnOBSRecord.Name = "BtnOBSRecord"
        Me.BtnOBSRecord.Size = New System.Drawing.Size(100, 100)
        Me.BtnOBSRecord.TabIndex = 299
        Me.BtnOBSRecord.Text = "Rec"
        Me.BtnOBSRecord.UseVisualStyleBackColor = True
        '
        'BtnOBSBroadcast
        '
        Me.BtnOBSBroadcast.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOBSBroadcast.Image = CType(resources.GetObject("BtnOBSBroadcast.Image"), System.Drawing.Image)
        Me.BtnOBSBroadcast.Location = New System.Drawing.Point(17, 320)
        Me.BtnOBSBroadcast.Name = "BtnOBSBroadcast"
        Me.BtnOBSBroadcast.Size = New System.Drawing.Size(100, 100)
        Me.BtnOBSBroadcast.TabIndex = 298
        Me.BtnOBSBroadcast.Text = "Broad cast"
        Me.BtnOBSBroadcast.UseVisualStyleBackColor = True
        '
        'TextBoxOBSBroadcastTime
        '
        Me.TextBoxOBSBroadcastTime.BackColor = System.Drawing.Color.Black
        Me.TextBoxOBSBroadcastTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxOBSBroadcastTime.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOBSBroadcastTime.ForeColor = System.Drawing.Color.Yellow
        Me.TextBoxOBSBroadcastTime.Location = New System.Drawing.Point(17, 426)
        Me.TextBoxOBSBroadcastTime.Name = "TextBoxOBSBroadcastTime"
        Me.TextBoxOBSBroadcastTime.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxOBSBroadcastTime.TabIndex = 297
        Me.TextBoxOBSBroadcastTime.Text = "..."
        Me.TextBoxOBSBroadcastTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelEncB
        '
        Me.LabelEncB.AutoSize = True
        Me.LabelEncB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEncB.ForeColor = System.Drawing.Color.White
        Me.LabelEncB.Location = New System.Drawing.Point(60, 119)
        Me.LabelEncB.MaximumSize = New System.Drawing.Size(58, 0)
        Me.LabelEncB.MinimumSize = New System.Drawing.Size(0, 35)
        Me.LabelEncB.Name = "LabelEncB"
        Me.LabelEncB.Size = New System.Drawing.Size(57, 35)
        Me.LabelEncB.TabIndex = 252
        Me.LabelEncB.Text = "Focus"
        Me.LabelEncB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(17, 116)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 251
        Me.PictureBox2.TabStop = False
        '
        'TextEncBStatus
        '
        Me.TextEncBStatus.BackColor = System.Drawing.Color.Black
        Me.TextEncBStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEncBStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEncBStatus.ForeColor = System.Drawing.Color.Yellow
        Me.TextEncBStatus.Location = New System.Drawing.Point(17, 162)
        Me.TextEncBStatus.Name = "TextEncBStatus"
        Me.TextEncBStatus.Size = New System.Drawing.Size(100, 29)
        Me.TextEncBStatus.TabIndex = 250
        Me.TextEncBStatus.Text = "17"
        Me.TextEncBStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelEncA
        '
        Me.LabelEncA.AutoSize = True
        Me.LabelEncA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEncA.ForeColor = System.Drawing.Color.White
        Me.LabelEncA.Location = New System.Drawing.Point(61, 32)
        Me.LabelEncA.MaximumSize = New System.Drawing.Size(58, 0)
        Me.LabelEncA.MinimumSize = New System.Drawing.Size(0, 35)
        Me.LabelEncA.Name = "LabelEncA"
        Me.LabelEncA.Size = New System.Drawing.Size(32, 35)
        Me.LabelEncA.TabIndex = 249
        Me.LabelEncA.Text = "Iris"
        Me.LabelEncA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(17, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 115
        Me.PictureBox1.TabStop = False
        '
        'TextEncAStatus
        '
        Me.TextEncAStatus.BackColor = System.Drawing.Color.Black
        Me.TextEncAStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEncAStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEncAStatus.ForeColor = System.Drawing.Color.Yellow
        Me.TextEncAStatus.Location = New System.Drawing.Point(17, 76)
        Me.TextEncAStatus.Name = "TextEncAStatus"
        Me.TextEncAStatus.Size = New System.Drawing.Size(100, 29)
        Me.TextEncAStatus.TabIndex = 114
        Me.TextEncAStatus.Text = "17"
        Me.TextEncAStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelEncStatus
        '
        Me.LabelEncStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelEncStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelEncStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEncStatus.Location = New System.Drawing.Point(17, 6)
        Me.LabelEncStatus.Name = "LabelEncStatus"
        Me.LabelEncStatus.Size = New System.Drawing.Size(91, 21)
        Me.LabelEncStatus.TabIndex = 1
        Me.LabelEncStatus.Text = "CAM?"
        Me.LabelEncStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer4
        '
        Me.ShapeContainer4.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer4.Name = "ShapeContainer4"
        Me.ShapeContainer4.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape12})
        Me.ShapeContainer4.Size = New System.Drawing.Size(120, 600)
        Me.ShapeContainer4.TabIndex = 0
        Me.ShapeContainer4.TabStop = False
        '
        'LineShape12
        '
        Me.LineShape12.BorderColor = System.Drawing.Color.Yellow
        Me.LineShape12.BorderWidth = 2
        Me.LineShape12.Name = "LineShape12"
        Me.LineShape12.X1 = 6
        Me.LineShape12.X2 = 6
        Me.LineShape12.Y1 = 0
        Me.LineShape12.Y2 = 600
        '
        'MsgBoxPanel
        '
        Me.MsgBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MsgBoxPanel.Controls.Add(Me.MsgBoxLabel)
        Me.MsgBoxPanel.Controls.Add(Me.MsgboxClose)
        Me.MsgBoxPanel.Location = New System.Drawing.Point(1068, 95)
        Me.MsgBoxPanel.Name = "MsgBoxPanel"
        Me.MsgBoxPanel.Size = New System.Drawing.Size(146, 98)
        Me.MsgBoxPanel.TabIndex = 325
        Me.MsgBoxPanel.Visible = False
        '
        'MsgBoxLabel
        '
        Me.MsgBoxLabel.AutoSize = True
        Me.MsgBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgBoxLabel.ForeColor = System.Drawing.Color.Yellow
        Me.MsgBoxLabel.Location = New System.Drawing.Point(8, 23)
        Me.MsgBoxLabel.Name = "MsgBoxLabel"
        Me.MsgBoxLabel.Size = New System.Drawing.Size(0, 24)
        Me.MsgBoxLabel.TabIndex = 1
        '
        'MsgboxClose
        '
        Me.MsgboxClose.AutoSize = True
        Me.MsgboxClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgboxClose.ForeColor = System.Drawing.Color.Yellow
        Me.MsgboxClose.Location = New System.Drawing.Point(116, 0)
        Me.MsgboxClose.Name = "MsgboxClose"
        Me.MsgboxClose.Size = New System.Drawing.Size(27, 25)
        Me.MsgboxClose.TabIndex = 0
        Me.MsgboxClose.Text = "X"
        '
        'PresetLoadPanel
        '
        Me.PresetLoadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PresetLoadPanel.Controls.Add(Me.Label24)
        Me.PresetLoadPanel.Controls.Add(Me.Label5)
        Me.PresetLoadPanel.Controls.Add(Me.PresetLoadClose)
        Me.PresetLoadPanel.Location = New System.Drawing.Point(1068, 210)
        Me.PresetLoadPanel.Name = "PresetLoadPanel"
        Me.PresetLoadPanel.Size = New System.Drawing.Size(146, 98)
        Me.PresetLoadPanel.TabIndex = 326
        Me.PresetLoadPanel.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Yellow
        Me.Label24.Location = New System.Drawing.Point(14, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(238, 22)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Select Preset File to load"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(8, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 24)
        Me.Label5.TabIndex = 1
        '
        'PresetLoadClose
        '
        Me.PresetLoadClose.AutoSize = True
        Me.PresetLoadClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetLoadClose.ForeColor = System.Drawing.Color.Yellow
        Me.PresetLoadClose.Location = New System.Drawing.Point(116, 0)
        Me.PresetLoadClose.Name = "PresetLoadClose"
        Me.PresetLoadClose.Size = New System.Drawing.Size(27, 25)
        Me.PresetLoadClose.TabIndex = 0
        Me.PresetLoadClose.Text = "X"
        '
        'PanelEncSelect
        '
        Me.PanelEncSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEncSelect.Controls.Add(Me.LabelEnc)
        Me.PanelEncSelect.Controls.Add(Me.ButtonEncAeShift)
        Me.PanelEncSelect.Controls.Add(Me.ButtonEncAgcLimit)
        Me.PanelEncSelect.Controls.Add(Me.ButtonEncAgc)
        Me.PanelEncSelect.Controls.Add(Me.ButtonEncIris)
        Me.PanelEncSelect.Controls.Add(Me.ButtonEncFocus)
        Me.PanelEncSelect.Location = New System.Drawing.Point(1068, 334)
        Me.PanelEncSelect.Name = "PanelEncSelect"
        Me.PanelEncSelect.Size = New System.Drawing.Size(160, 330)
        Me.PanelEncSelect.TabIndex = 326
        Me.PanelEncSelect.Visible = False
        '
        'LabelEnc
        '
        Me.LabelEnc.AutoSize = True
        Me.LabelEnc.Location = New System.Drawing.Point(10, 245)
        Me.LabelEnc.Name = "LabelEnc"
        Me.LabelEnc.Size = New System.Drawing.Size(45, 13)
        Me.LabelEnc.TabIndex = 5
        Me.LabelEnc.Text = "Label25"
        Me.LabelEnc.Visible = False
        '
        'ButtonEncAeShift
        '
        Me.ButtonEncAeShift.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncAeShift.Location = New System.Drawing.Point(12, 261)
        Me.ButtonEncAeShift.Name = "ButtonEncAeShift"
        Me.ButtonEncAeShift.Size = New System.Drawing.Size(136, 50)
        Me.ButtonEncAeShift.TabIndex = 4
        Me.ButtonEncAeShift.Text = "AE Shift"
        Me.ButtonEncAeShift.UseVisualStyleBackColor = True
        '
        'ButtonEncAgcLimit
        '
        Me.ButtonEncAgcLimit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncAgcLimit.Location = New System.Drawing.Point(12, 199)
        Me.ButtonEncAgcLimit.Name = "ButtonEncAgcLimit"
        Me.ButtonEncAgcLimit.Size = New System.Drawing.Size(136, 50)
        Me.ButtonEncAgcLimit.TabIndex = 3
        Me.ButtonEncAgcLimit.Text = "AGC Limit"
        Me.ButtonEncAgcLimit.UseVisualStyleBackColor = True
        '
        'ButtonEncAgc
        '
        Me.ButtonEncAgc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncAgc.Location = New System.Drawing.Point(12, 137)
        Me.ButtonEncAgc.Name = "ButtonEncAgc"
        Me.ButtonEncAgc.Size = New System.Drawing.Size(136, 50)
        Me.ButtonEncAgc.TabIndex = 2
        Me.ButtonEncAgc.Text = "AGC"
        Me.ButtonEncAgc.UseVisualStyleBackColor = True
        '
        'ButtonEncIris
        '
        Me.ButtonEncIris.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncIris.Location = New System.Drawing.Point(12, 75)
        Me.ButtonEncIris.Name = "ButtonEncIris"
        Me.ButtonEncIris.Size = New System.Drawing.Size(136, 50)
        Me.ButtonEncIris.TabIndex = 1
        Me.ButtonEncIris.Text = "Iris"
        Me.ButtonEncIris.UseVisualStyleBackColor = True
        '
        'ButtonEncFocus
        '
        Me.ButtonEncFocus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncFocus.Location = New System.Drawing.Point(12, 13)
        Me.ButtonEncFocus.Name = "ButtonEncFocus"
        Me.ButtonEncFocus.Size = New System.Drawing.Size(136, 50)
        Me.ButtonEncFocus.TabIndex = 0
        Me.ButtonEncFocus.Text = "Focus"
        Me.ButtonEncFocus.UseVisualStyleBackColor = True
        '
        'BtnInp1
        '
        Me.BtnInp1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInp1.Image = CType(resources.GetObject("BtnInp1.Image"), System.Drawing.Image)
        Me.BtnInp1.Location = New System.Drawing.Point(383, 986)
        Me.BtnInp1.Name = "BtnInp1"
        Me.BtnInp1.Size = New System.Drawing.Size(75, 75)
        Me.BtnInp1.TabIndex = 327
        Me.BtnInp1.Text = "Words"
        Me.BtnInp1.UseVisualStyleBackColor = True
        '
        'BtnInp4
        '
        Me.BtnInp4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInp4.Image = CType(resources.GetObject("BtnInp4.Image"), System.Drawing.Image)
        Me.BtnInp4.Location = New System.Drawing.Point(564, 905)
        Me.BtnInp4.Name = "BtnInp4"
        Me.BtnInp4.Size = New System.Drawing.Size(75, 75)
        Me.BtnInp4.TabIndex = 306
        Me.BtnInp4.Text = "Pip"
        Me.BtnInp4.UseVisualStyleBackColor = True
        '
        'AuxSel12
        '
        Me.AuxSel12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuxSel12.Image = CType(resources.GetObject("AuxSel12.Image"), System.Drawing.Image)
        Me.AuxSel12.Location = New System.Drawing.Point(562, 611)
        Me.AuxSel12.Name = "AuxSel12"
        Me.AuxSel12.Size = New System.Drawing.Size(75, 75)
        Me.AuxSel12.TabIndex = 305
        Me.AuxSel12.Text = "Stage"
        Me.AuxSel12.UseVisualStyleBackColor = True
        Me.AuxSel12.Visible = False
        '
        'Aux3Btn12
        '
        Me.Aux3Btn12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn12.Image = CType(resources.GetObject("Aux3Btn12.Image"), System.Drawing.Image)
        Me.Aux3Btn12.Location = New System.Drawing.Point(564, 735)
        Me.Aux3Btn12.Name = "Aux3Btn12"
        Me.Aux3Btn12.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn12.TabIndex = 304
        Me.Aux3Btn12.Text = "Stage"
        Me.Aux3Btn12.UseVisualStyleBackColor = True
        Me.Aux3Btn12.Visible = False
        '
        'BtnPip
        '
        Me.BtnPip.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPip.Image = CType(resources.GetObject("BtnPip.Image"), System.Drawing.Image)
        Me.BtnPip.Location = New System.Drawing.Point(739, 905)
        Me.BtnPip.Name = "BtnPip"
        Me.BtnPip.Size = New System.Drawing.Size(75, 75)
        Me.BtnPip.TabIndex = 303
        Me.BtnPip.Text = "PiP"
        Me.BtnPip.UseVisualStyleBackColor = True
        '
        'Aux3Btn11
        '
        Me.Aux3Btn11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn11.Image = CType(resources.GetObject("Aux3Btn11.Image"), System.Drawing.Image)
        Me.Aux3Btn11.Location = New System.Drawing.Point(861, 735)
        Me.Aux3Btn11.Name = "Aux3Btn11"
        Me.Aux3Btn11.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn11.TabIndex = 301
        Me.Aux3Btn11.Text = "Overlay"
        Me.Aux3Btn11.UseVisualStyleBackColor = True
        Me.Aux3Btn11.Visible = False
        '
        'Aux3Btn10
        '
        Me.Aux3Btn10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn10.Image = CType(resources.GetObject("Aux3Btn10.Image"), System.Drawing.Image)
        Me.Aux3Btn10.Location = New System.Drawing.Point(787, 735)
        Me.Aux3Btn10.Name = "Aux3Btn10"
        Me.Aux3Btn10.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn10.TabIndex = 300
        Me.Aux3Btn10.Text = "Media 1"
        Me.Aux3Btn10.UseVisualStyleBackColor = True
        Me.Aux3Btn10.Visible = False
        '
        'Auxsel11
        '
        Me.Auxsel11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel11.Image = CType(resources.GetObject("Auxsel11.Image"), System.Drawing.Image)
        Me.Auxsel11.Location = New System.Drawing.Point(861, 611)
        Me.Auxsel11.Name = "Auxsel11"
        Me.Auxsel11.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel11.TabIndex = 299
        Me.Auxsel11.Text = "Overlay"
        Me.Auxsel11.UseVisualStyleBackColor = True
        Me.Auxsel11.Visible = False
        '
        'Auxsel10
        '
        Me.Auxsel10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel10.Image = CType(resources.GetObject("Auxsel10.Image"), System.Drawing.Image)
        Me.Auxsel10.Location = New System.Drawing.Point(787, 611)
        Me.Auxsel10.Name = "Auxsel10"
        Me.Auxsel10.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel10.TabIndex = 298
        Me.Auxsel10.Text = "Media 1"
        Me.Auxsel10.UseVisualStyleBackColor = True
        Me.Auxsel10.Visible = False
        '
        'BtnAuxLock
        '
        Me.BtnAuxLock.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAuxLock.Image = CType(resources.GetObject("BtnAuxLock.Image"), System.Drawing.Image)
        Me.BtnAuxLock.Location = New System.Drawing.Point(43, 517)
        Me.BtnAuxLock.Name = "BtnAuxLock"
        Me.BtnAuxLock.Size = New System.Drawing.Size(50, 50)
        Me.BtnAuxLock.TabIndex = 278
        Me.BtnAuxLock.Text = "Lock"
        Me.BtnAuxLock.UseVisualStyleBackColor = True
        Me.BtnAuxLock.Visible = False
        '
        'AuxSel9
        '
        Me.AuxSel9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuxSel9.Image = CType(resources.GetObject("AuxSel9.Image"), System.Drawing.Image)
        Me.AuxSel9.Location = New System.Drawing.Point(637, 611)
        Me.AuxSel9.Name = "AuxSel9"
        Me.AuxSel9.Size = New System.Drawing.Size(75, 75)
        Me.AuxSel9.TabIndex = 265
        Me.AuxSel9.Text = "Black"
        Me.AuxSel9.UseVisualStyleBackColor = True
        Me.AuxSel9.Visible = False
        '
        'Auxsel8
        '
        Me.Auxsel8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel8.Image = CType(resources.GetObject("Auxsel8.Image"), System.Drawing.Image)
        Me.Auxsel8.Location = New System.Drawing.Point(264, 611)
        Me.Auxsel8.Name = "Auxsel8"
        Me.Auxsel8.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel8.TabIndex = 264
        Me.Auxsel8.Text = "CAM4"
        Me.Auxsel8.UseVisualStyleBackColor = True
        Me.Auxsel8.Visible = False
        '
        'Auxsel7
        '
        Me.Auxsel7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel7.Image = CType(resources.GetObject("Auxsel7.Image"), System.Drawing.Image)
        Me.Auxsel7.Location = New System.Drawing.Point(189, 611)
        Me.Auxsel7.Name = "Auxsel7"
        Me.Auxsel7.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel7.TabIndex = 263
        Me.Auxsel7.Text = "CAM3"
        Me.Auxsel7.UseVisualStyleBackColor = True
        Me.Auxsel7.Visible = False
        '
        'Aux3Btn9
        '
        Me.Aux3Btn9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn9.Image = CType(resources.GetObject("Aux3Btn9.Image"), System.Drawing.Image)
        Me.Aux3Btn9.Location = New System.Drawing.Point(637, 735)
        Me.Aux3Btn9.Name = "Aux3Btn9"
        Me.Aux3Btn9.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn9.TabIndex = 262
        Me.Aux3Btn9.Text = "Black"
        Me.Aux3Btn9.UseVisualStyleBackColor = True
        Me.Aux3Btn9.Visible = False
        '
        'Aux3Btn8
        '
        Me.Aux3Btn8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn8.Image = CType(resources.GetObject("Aux3Btn8.Image"), System.Drawing.Image)
        Me.Aux3Btn8.Location = New System.Drawing.Point(264, 735)
        Me.Aux3Btn8.Name = "Aux3Btn8"
        Me.Aux3Btn8.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn8.TabIndex = 261
        Me.Aux3Btn8.Text = "CAM4"
        Me.Aux3Btn8.UseVisualStyleBackColor = True
        Me.Aux3Btn8.Visible = False
        '
        'Aux3Btn7
        '
        Me.Aux3Btn7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn7.Image = CType(resources.GetObject("Aux3Btn7.Image"), System.Drawing.Image)
        Me.Aux3Btn7.Location = New System.Drawing.Point(189, 735)
        Me.Aux3Btn7.Name = "Aux3Btn7"
        Me.Aux3Btn7.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn7.TabIndex = 260
        Me.Aux3Btn7.Text = "CAM3"
        Me.Aux3Btn7.UseVisualStyleBackColor = True
        Me.Aux3Btn7.Visible = False
        '
        'Auxsel3
        '
        Me.Auxsel3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel3.Image = CType(resources.GetObject("Auxsel3.Image"), System.Drawing.Image)
        Me.Auxsel3.Location = New System.Drawing.Point(711, 611)
        Me.Auxsel3.Name = "Auxsel3"
        Me.Auxsel3.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel3.TabIndex = 231
        Me.Auxsel3.Text = "Program"
        Me.Auxsel3.UseVisualStyleBackColor = True
        Me.Auxsel3.Visible = False
        '
        'Auxsel2
        '
        Me.Auxsel2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel2.Image = CType(resources.GetObject("Auxsel2.Image"), System.Drawing.Image)
        Me.Auxsel2.Location = New System.Drawing.Point(339, 611)
        Me.Auxsel2.Name = "Auxsel2"
        Me.Auxsel2.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel2.TabIndex = 230
        Me.Auxsel2.Text = "CAM5"
        Me.Auxsel2.UseVisualStyleBackColor = True
        Me.Auxsel2.Visible = False
        '
        'Auxsel1
        '
        Me.Auxsel1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel1.Image = CType(resources.GetObject("Auxsel1.Image"), System.Drawing.Image)
        Me.Auxsel1.Location = New System.Drawing.Point(414, 611)
        Me.Auxsel1.Name = "Auxsel1"
        Me.Auxsel1.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel1.TabIndex = 229
        Me.Auxsel1.Text = "Words"
        Me.Auxsel1.UseVisualStyleBackColor = True
        Me.Auxsel1.Visible = False
        '
        'BtnMediaOverlay
        '
        Me.BtnMediaOverlay.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMediaOverlay.Image = CType(resources.GetObject("BtnMediaOverlay.Image"), System.Drawing.Image)
        Me.BtnMediaOverlay.Location = New System.Drawing.Point(1175, 905)
        Me.BtnMediaOverlay.Name = "BtnMediaOverlay"
        Me.BtnMediaOverlay.Size = New System.Drawing.Size(75, 75)
        Me.BtnMediaOverlay.TabIndex = 153
        Me.BtnMediaOverlay.Text = "Caption overlay"
        Me.BtnMediaOverlay.UseVisualStyleBackColor = True
        '
        'BtnOverlay
        '
        Me.BtnOverlay.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOverlay.Image = CType(resources.GetObject("BtnOverlay.Image"), System.Drawing.Image)
        Me.BtnOverlay.Location = New System.Drawing.Point(1098, 905)
        Me.BtnOverlay.Name = "BtnOverlay"
        Me.BtnOverlay.Size = New System.Drawing.Size(75, 75)
        Me.BtnOverlay.TabIndex = 152
        Me.BtnOverlay.Text = "Words overlay"
        Me.BtnOverlay.UseVisualStyleBackColor = True
        '
        'BtnTransition
        '
        Me.BtnTransition.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTransition.Image = CType(resources.GetObject("BtnTransition.Image"), System.Drawing.Image)
        Me.BtnTransition.Location = New System.Drawing.Point(946, 905)
        Me.BtnTransition.Name = "BtnTransition"
        Me.BtnTransition.Size = New System.Drawing.Size(90, 75)
        Me.BtnTransition.TabIndex = 151
        Me.BtnTransition.Text = "Fade"
        Me.BtnTransition.UseVisualStyleBackColor = True
        '
        'BtnCut
        '
        Me.BtnCut.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCut.Image = CType(resources.GetObject("BtnCut.Image"), System.Drawing.Image)
        Me.BtnCut.Location = New System.Drawing.Point(850, 905)
        Me.BtnCut.Name = "BtnCut"
        Me.BtnCut.Size = New System.Drawing.Size(90, 75)
        Me.BtnCut.TabIndex = 150
        Me.BtnCut.Text = "Cut"
        Me.BtnCut.UseVisualStyleBackColor = True
        '
        'BtnInp3
        '
        Me.BtnInp3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInp3.Image = CType(resources.GetObject("BtnInp3.Image"), System.Drawing.Image)
        Me.BtnInp3.Location = New System.Drawing.Point(489, 905)
        Me.BtnInp3.Name = "BtnInp3"
        Me.BtnInp3.Size = New System.Drawing.Size(75, 75)
        Me.BtnInp3.TabIndex = 148
        Me.BtnInp3.Text = "Aux"
        Me.BtnInp3.UseVisualStyleBackColor = True
        '
        'BtnCam5
        '
        Me.BtnCam5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam5.Image = CType(resources.GetObject("BtnCam5.Image"), System.Drawing.Image)
        Me.BtnCam5.Location = New System.Drawing.Point(339, 905)
        Me.BtnCam5.Name = "BtnCam5"
        Me.BtnCam5.Size = New System.Drawing.Size(75, 75)
        Me.BtnCam5.TabIndex = 147
        Me.BtnCam5.Text = "CAM5"
        Me.BtnCam5.UseVisualStyleBackColor = True
        '
        'BtnInp2
        '
        Me.BtnInp2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInp2.Image = CType(resources.GetObject("BtnInp2.Image"), System.Drawing.Image)
        Me.BtnInp2.Location = New System.Drawing.Point(414, 905)
        Me.BtnInp2.Name = "BtnInp2"
        Me.BtnInp2.Size = New System.Drawing.Size(75, 75)
        Me.BtnInp2.TabIndex = 146
        Me.BtnInp2.Text = "Media"
        Me.BtnInp2.UseVisualStyleBackColor = True
        '
        'BtnInp5
        '
        Me.BtnInp5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInp5.Image = CType(resources.GetObject("BtnInp5.Image"), System.Drawing.Image)
        Me.BtnInp5.Location = New System.Drawing.Point(637, 905)
        Me.BtnInp5.Name = "BtnInp5"
        Me.BtnInp5.Size = New System.Drawing.Size(75, 75)
        Me.BtnInp5.TabIndex = 145
        Me.BtnInp5.Text = "Black"
        Me.BtnInp5.UseVisualStyleBackColor = True
        '
        'BtnCam4
        '
        Me.BtnCam4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam4.Image = CType(resources.GetObject("BtnCam4.Image"), System.Drawing.Image)
        Me.BtnCam4.Location = New System.Drawing.Point(264, 905)
        Me.BtnCam4.Name = "BtnCam4"
        Me.BtnCam4.Size = New System.Drawing.Size(75, 75)
        Me.BtnCam4.TabIndex = 144
        Me.BtnCam4.Text = "CAM4"
        Me.BtnCam4.UseVisualStyleBackColor = True
        '
        'BtnCam3
        '
        Me.BtnCam3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam3.Image = CType(resources.GetObject("BtnCam3.Image"), System.Drawing.Image)
        Me.BtnCam3.Location = New System.Drawing.Point(189, 905)
        Me.BtnCam3.Name = "BtnCam3"
        Me.BtnCam3.Size = New System.Drawing.Size(75, 75)
        Me.BtnCam3.TabIndex = 143
        Me.BtnCam3.Text = "CAM3"
        Me.BtnCam3.UseVisualStyleBackColor = True
        '
        'BtnCam2
        '
        Me.BtnCam2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam2.Image = CType(resources.GetObject("BtnCam2.Image"), System.Drawing.Image)
        Me.BtnCam2.Location = New System.Drawing.Point(114, 905)
        Me.BtnCam2.Name = "BtnCam2"
        Me.BtnCam2.Size = New System.Drawing.Size(75, 75)
        Me.BtnCam2.TabIndex = 142
        Me.BtnCam2.Text = "CAM2"
        Me.BtnCam2.UseVisualStyleBackColor = True
        '
        'BtnCam1
        '
        Me.BtnCam1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCam1.Image = CType(resources.GetObject("BtnCam1.Image"), System.Drawing.Image)
        Me.BtnCam1.Location = New System.Drawing.Point(39, 905)
        Me.BtnCam1.Name = "BtnCam1"
        Me.BtnCam1.Size = New System.Drawing.Size(75, 75)
        Me.BtnCam1.TabIndex = 141
        Me.BtnCam1.Text = "CAM1"
        Me.BtnCam1.UseVisualStyleBackColor = True
        '
        'Auxsel4
        '
        Me.Auxsel4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel4.Image = CType(resources.GetObject("Auxsel4.Image"), System.Drawing.Image)
        Me.Auxsel4.Location = New System.Drawing.Point(489, 611)
        Me.Auxsel4.Name = "Auxsel4"
        Me.Auxsel4.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel4.TabIndex = 245
        Me.Auxsel4.Text = "OBS"
        Me.Auxsel4.UseVisualStyleBackColor = True
        Me.Auxsel4.Visible = False
        '
        'Auxsel5
        '
        Me.Auxsel5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel5.Image = CType(resources.GetObject("Auxsel5.Image"), System.Drawing.Image)
        Me.Auxsel5.Location = New System.Drawing.Point(39, 611)
        Me.Auxsel5.Name = "Auxsel5"
        Me.Auxsel5.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel5.TabIndex = 249
        Me.Auxsel5.Text = "CAM1"
        Me.Auxsel5.UseVisualStyleBackColor = True
        Me.Auxsel5.Visible = False
        '
        'Auxsel6
        '
        Me.Auxsel6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auxsel6.Image = CType(resources.GetObject("Auxsel6.Image"), System.Drawing.Image)
        Me.Auxsel6.Location = New System.Drawing.Point(114, 611)
        Me.Auxsel6.Name = "Auxsel6"
        Me.Auxsel6.Size = New System.Drawing.Size(75, 75)
        Me.Auxsel6.TabIndex = 250
        Me.Auxsel6.Text = "CAM2"
        Me.Auxsel6.UseVisualStyleBackColor = True
        Me.Auxsel6.Visible = False
        '
        'Aux3Btn3
        '
        Me.Aux3Btn3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn3.Image = CType(resources.GetObject("Aux3Btn3.Image"), System.Drawing.Image)
        Me.Aux3Btn3.Location = New System.Drawing.Point(711, 735)
        Me.Aux3Btn3.Name = "Aux3Btn3"
        Me.Aux3Btn3.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn3.TabIndex = 254
        Me.Aux3Btn3.Text = "Program"
        Me.Aux3Btn3.UseVisualStyleBackColor = True
        Me.Aux3Btn3.Visible = False
        '
        'Aux3Btn2
        '
        Me.Aux3Btn2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn2.Image = CType(resources.GetObject("Aux3Btn2.Image"), System.Drawing.Image)
        Me.Aux3Btn2.Location = New System.Drawing.Point(339, 735)
        Me.Aux3Btn2.Name = "Aux3Btn2"
        Me.Aux3Btn2.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn2.TabIndex = 253
        Me.Aux3Btn2.Text = "CAM5"
        Me.Aux3Btn2.UseVisualStyleBackColor = True
        Me.Aux3Btn2.Visible = False
        '
        'Aux3Btn1
        '
        Me.Aux3Btn1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn1.Image = CType(resources.GetObject("Aux3Btn1.Image"), System.Drawing.Image)
        Me.Aux3Btn1.Location = New System.Drawing.Point(414, 735)
        Me.Aux3Btn1.Name = "Aux3Btn1"
        Me.Aux3Btn1.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn1.TabIndex = 252
        Me.Aux3Btn1.Text = "Words"
        Me.Aux3Btn1.UseVisualStyleBackColor = True
        Me.Aux3Btn1.Visible = False
        '
        'Aux3Btn4
        '
        Me.Aux3Btn4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn4.Image = CType(resources.GetObject("Aux3Btn4.Image"), System.Drawing.Image)
        Me.Aux3Btn4.Location = New System.Drawing.Point(489, 735)
        Me.Aux3Btn4.Name = "Aux3Btn4"
        Me.Aux3Btn4.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn4.TabIndex = 255
        Me.Aux3Btn4.Text = "OBS"
        Me.Aux3Btn4.UseVisualStyleBackColor = True
        Me.Aux3Btn4.Visible = False
        '
        'Aux3Btn5
        '
        Me.Aux3Btn5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn5.Image = CType(resources.GetObject("Aux3Btn5.Image"), System.Drawing.Image)
        Me.Aux3Btn5.Location = New System.Drawing.Point(39, 735)
        Me.Aux3Btn5.Name = "Aux3Btn5"
        Me.Aux3Btn5.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn5.TabIndex = 256
        Me.Aux3Btn5.Text = "CAM1"
        Me.Aux3Btn5.UseVisualStyleBackColor = True
        Me.Aux3Btn5.Visible = False
        '
        'Aux3Btn6
        '
        Me.Aux3Btn6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aux3Btn6.Image = CType(resources.GetObject("Aux3Btn6.Image"), System.Drawing.Image)
        Me.Aux3Btn6.Location = New System.Drawing.Point(114, 735)
        Me.Aux3Btn6.Name = "Aux3Btn6"
        Me.Aux3Btn6.Size = New System.Drawing.Size(75, 75)
        Me.Aux3Btn6.TabIndex = 257
        Me.Aux3Btn6.Text = "CAM2"
        Me.Aux3Btn6.UseVisualStyleBackColor = True
        Me.Aux3Btn6.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1626, 1100)
        Me.Controls.Add(Me.PanelEncSelect)
        Me.Controls.Add(Me.PresetPanel)
        Me.Controls.Add(Me.BtnInp1)
        Me.Controls.Add(Me.PresetLoadPanel)
        Me.Controls.Add(Me.MsgBoxPanel)
        Me.Controls.Add(Me.CamPanel)
        Me.Controls.Add(Me.StatPanel)
        Me.Controls.Add(Me.SettingsPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.eVISMacrosAppHost)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bConnect)
        Me.Controls.Add(Me.chkLogMessages)
        Me.Controls.Add(Me.mLog)
        Me.Controls.Add(Me.BtnInp4)
        Me.Controls.Add(Me.AuxSel12)
        Me.Controls.Add(Me.Aux3Btn12)
        Me.Controls.Add(Me.BtnPip)
        Me.Controls.Add(Me.TextBoxPipSrc)
        Me.Controls.Add(Me.Aux3Btn11)
        Me.Controls.Add(Me.Aux3Btn10)
        Me.Controls.Add(Me.Auxsel11)
        Me.Controls.Add(Me.Auxsel10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnAuxLock)
        Me.Controls.Add(Me.AuxSel9)
        Me.Controls.Add(Me.Auxsel8)
        Me.Controls.Add(Me.Auxsel7)
        Me.Controls.Add(Me.Aux3Btn9)
        Me.Controls.Add(Me.Aux3Btn8)
        Me.Controls.Add(Me.Aux3Btn7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelProfile)
        Me.Controls.Add(Me.Auxsel3)
        Me.Controls.Add(Me.Auxsel2)
        Me.Controls.Add(Me.Auxsel1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ButtonSetup)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtnMediaOverlay)
        Me.Controls.Add(Me.BtnOverlay)
        Me.Controls.Add(Me.BtnTransition)
        Me.Controls.Add(Me.BtnCut)
        Me.Controls.Add(Me.BtnInp3)
        Me.Controls.Add(Me.BtnCam5)
        Me.Controls.Add(Me.BtnInp2)
        Me.Controls.Add(Me.BtnInp5)
        Me.Controls.Add(Me.BtnCam4)
        Me.Controls.Add(Me.BtnCam3)
        Me.Controls.Add(Me.BtnCam2)
        Me.Controls.Add(Me.BtnCam1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Auxsel4)
        Me.Controls.Add(Me.Auxsel5)
        Me.Controls.Add(Me.Auxsel6)
        Me.Controls.Add(Me.Aux3Btn3)
        Me.Controls.Add(Me.Aux3Btn2)
        Me.Controls.Add(Me.Aux3Btn1)
        Me.Controls.Add(Me.Aux3Btn4)
        Me.Controls.Add(Me.Aux3Btn5)
        Me.Controls.Add(Me.Aux3Btn6)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.Text = "CCNCamcontrol"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PresetPanel.ResumeLayout(False)
        Me.PresetPanel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.CamPanel.ResumeLayout(False)
        Me.CamPanel.PerformLayout()
        Me.SettingsPanel.ResumeLayout(False)
        Me.SettingsPanel.PerformLayout()
        Me.StatPanel.ResumeLayout(False)
        Me.StatPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MsgBoxPanel.ResumeLayout(False)
        Me.MsgBoxPanel.PerformLayout()
        Me.PresetLoadPanel.ResumeLayout(False)
        Me.PresetLoadPanel.PerformLayout()
        Me.PanelEncSelect.ResumeLayout(False)
        Me.PanelEncSelect.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents eVISMacrosAppHost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bConnect As System.Windows.Forms.Button
    Friend WithEvents mLog As System.Windows.Forms.TextBox
    Friend WithEvents chkLogMessages As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIris As System.Windows.Forms.TextBox
    Friend WithEvents BtnIrisDown As System.Windows.Forms.Button
    Friend WithEvents TextBoxAgc As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAeShift As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAgcLimit As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxWB As System.Windows.Forms.TextBox
    Friend WithEvents BtnCam1 As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam2 As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam3 As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam4 As CCNCamcontrol.MyButton
    Friend WithEvents BtnInp5 As CCNCamcontrol.MyButton
    Friend WithEvents BtnInp2 As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam5 As CCNCamcontrol.MyButton
    Friend WithEvents BtnInp3 As CCNCamcontrol.MyButton
    Friend WithEvents BtnCut As CCNCamcontrol.MyButton
    Friend WithEvents BtnTransition As CCNCamcontrol.MyButton
    Friend WithEvents BtnOverlay As CCNCamcontrol.MyButton
    Friend WithEvents BtnMediaOverlay As CCNCamcontrol.MyButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents BtnPreset1 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset8 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset7 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset6 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset5 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset4 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset3 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset2 As CCNCamcontrol.MyButton
    Friend WithEvents ButtonSetup As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BtnSlowIn As CCNCamcontrol.MyButton
    Friend WithEvents BtnSlowOut As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset16 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset15 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset14 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset13 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset12 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset11 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset10 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreset9 As CCNCamcontrol.MyButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnIrisUp As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BtnAGCDown As System.Windows.Forms.Button
    Friend WithEvents BtnAGCUp As System.Windows.Forms.Button
    Friend WithEvents BtnGainDown As System.Windows.Forms.Button
    Friend WithEvents BtnGainUp As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnAEShiftDn As System.Windows.Forms.Button
    Friend WithEvents BtnAEShiftUp As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents BtnWbBlueUp As System.Windows.Forms.Button
    Friend WithEvents BtnWbBlueDn As System.Windows.Forms.Button
    Friend WithEvents BtnWbRedUp As System.Windows.Forms.Button
    Friend WithEvents BtnWbRedDn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnFocusAuto As CCNCamcontrol.MyButton
    Friend WithEvents BtnFocusLock As CCNCamcontrol.MyButton
    Friend WithEvents BtnFocusUp As System.Windows.Forms.Button
    Friend WithEvents BtnFocusDn As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MyButtonCamDR As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamD As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamDL As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamR As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamL As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamUR As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamU As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamUL As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel1 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel2 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel3 As CCNCamcontrol.MyButton
    Friend WithEvents BtnSlow As CCNCamcontrol.MyButton
    Friend WithEvents BtnFast As CCNCamcontrol.MyButton
    Friend WithEvents BtnLive As CCNCamcontrol.MyButton
    Friend WithEvents BtnLivePTZ As CCNCamcontrol.MyButton
    Friend WithEvents BtnPreload As CCNCamcontrol.MyButton
    Friend WithEvents BtnLiveSlow As CCNCamcontrol.MyButton
    Friend WithEvents BtnLiveFast As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel4 As CCNCamcontrol.MyButton
    Friend WithEvents LabelProfile As System.Windows.Forms.Label
    Friend WithEvents OverrideBtn As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel5 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel6 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn3 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn2 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn1 As CCNCamcontrol.MyButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Aux3Btn4 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn5 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn6 As CCNCamcontrol.MyButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Aux3Btn7 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn8 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn9 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel7 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel8 As CCNCamcontrol.MyButton
    Friend WithEvents AuxSel9 As CCNCamcontrol.MyButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnAuxLock As CCNCamcontrol.MyButton
    Friend WithEvents TextPlayerTime As System.Windows.Forms.TextBox
    Friend WithEvents BtnCam1Rec As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam2Rec As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam3Rec As CCNCamcontrol.MyButton
    Friend WithEvents BtnCam4Rec As CCNCamcontrol.MyButton
    Friend WithEvents TextBoxCam1Rec As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCam2Rec As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCam3Rec As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCam4Rec As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Auxsel10 As CCNCamcontrol.MyButton
    Friend WithEvents Auxsel11 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn11 As CCNCamcontrol.MyButton
    Friend WithEvents Aux3Btn10 As CCNCamcontrol.MyButton
    Friend WithEvents BtnPip As CCNCamcontrol.MyButton
    Friend WithEvents TextBoxPipSrc As System.Windows.Forms.TextBox
    Friend WithEvents Aux3Btn12 As CCNCamcontrol.MyButton
    Friend WithEvents AuxSel12 As CCNCamcontrol.MyButton
    Friend WithEvents BtnInp4 As CCNCamcontrol.MyButton
    Friend WithEvents ButtonRetryOBS As System.Windows.Forms.Button
    Private WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Private WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape8 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape9 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape10 As Microsoft.VisualBasic.PowerPacks.LineShape
    Private WithEvents LineShape11 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents PresetPanel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ModeBtnSettings As MyButton
    Friend WithEvents ModeBtnCam As MyButton
    Friend WithEvents ModeBtnPresets As MyButton
    Friend WithEvents CamPanel As Panel
    Private WithEvents LineShapeMode1 As PowerPacks.LineShape
    Friend WithEvents SettingsPanel As Panel
    Friend WithEvents StatPanel As Panel
    Friend WithEvents LabelEncB As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextEncBStatus As TextBox
    Friend WithEvents LabelEncA As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextEncAStatus As TextBox
    Friend WithEvents LabelEncStatus As Label
    Private WithEvents LineShape12 As PowerPacks.LineShape
    Friend WithEvents TextBoxOBSRecTime As TextBox
    Friend WithEvents BtnOBSRecord As MyButton
    Friend WithEvents BtnOBSBroadcast As MyButton
    Friend WithEvents TextBoxOBSBroadcastTime As TextBox
    Friend WithEvents ListBoxMedia As ListBox
    Friend WithEvents Label28 As Label
    Friend WithEvents BtnMNext As MyButton
    Friend WithEvents BtnMPrev As MyButton
    Friend WithEvents LabelCap3 As Label
    Friend WithEvents TextCaptionOther As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents LabelCap2 As Label
    Friend WithEvents LabelCap1 As Label
    Friend WithEvents TextPreacherName As TextBox
    Friend WithEvents TextLeaderName As TextBox
    Private WithEvents LineShapeMode2 As PowerPacks.LineShape
    Private WithEvents LineShapeMode4 As PowerPacks.LineShape
    Private WithEvents LineShapeMode3 As PowerPacks.LineShape
    Private WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Private WithEvents ShapeContainer4 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents BtnMovePreset As CCNCamcontrol.MyButton
    Friend WithEvents BtnEditPreset As CCNCamcontrol.MyButton
    Friend WithEvents BtnPresetSave As CCNCamcontrol.MyButton
    Friend WithEvents TextBoxPresetEdit As System.Windows.Forms.TextBox
    Friend WithEvents MsgBoxPanel As Panel
    Friend WithEvents MsgBoxLabel As Label
    Friend WithEvents MsgboxClose As Label
    Friend WithEvents BtnSlowPanR As MyButton
    Friend WithEvents BtnStop As MyButton
    Friend WithEvents BtnSlowPanL As MyButton
    Friend WithEvents BtnCNxt As MyButton
    Friend WithEvents BtnCPrev As MyButton
    Friend WithEvents ShapeContainer3 As PowerPacks.ShapeContainer
    Private WithEvents LineShapeCapR As PowerPacks.LineShape
    Private WithEvents LineShapeCapL As PowerPacks.LineShape
    Private WithEvents LineShapeCapB As PowerPacks.LineShape
    Private WithEvents LineShapeCapT As PowerPacks.LineShape
    Friend WithEvents CheckBoxCam4Dis As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCam3Dis As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCam2Dis As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCam1Dis As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCam5Dis As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSetupOsd As System.Windows.Forms.Button
    Friend WithEvents BtnSetupDown As System.Windows.Forms.Button
    Friend WithEvents BtnSetupUp As System.Windows.Forms.Button
    Friend WithEvents BtnSetupEnter As System.Windows.Forms.Button
    Friend WithEvents BtnSetupMenu As System.Windows.Forms.Button
    Friend WithEvents LblCamStatus5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIPCam5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxStandby As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxProfile As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSetupFolderBrowse As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPresetFolder As System.Windows.Forms.TextBox
    Friend WithEvents LblCamStatus4 As System.Windows.Forms.Label
    Friend WithEvents LblCamStatus3 As System.Windows.Forms.Label
    Friend WithEvents LblCamStatus2 As System.Windows.Forms.Label
    Friend WithEvents LblCamStatus1 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents BtnSetupFilenameBrowse As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPresetFilename As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIPCam4 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIPCam3 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIPCam2 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextBoxIPCam1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxAutoSwap As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTally As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInvert4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInvert3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInvert2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInvert1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSetupComport As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents PresetLoadPanel As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PresetLoadClose As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnSetupSaveNew As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPresetNewFile As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents MyButtonCamWide As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonCamTele As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonFullTele As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonFullWide As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonAutoWB As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonAutoAgc As CCNCamcontrol.MyButton
    Friend WithEvents MyButtonAutoIris As CCNCamcontrol.MyButton
    Friend WithEvents TextBoxFocus As System.Windows.Forms.TextBox
    Friend WithEvents PanelEncSelect As System.Windows.Forms.Panel
    Friend WithEvents ButtonEncAeShift As System.Windows.Forms.Button
    Friend WithEvents ButtonEncAgcLimit As System.Windows.Forms.Button
    Friend WithEvents ButtonEncAgc As System.Windows.Forms.Button
    Friend WithEvents ButtonEncIris As System.Windows.Forms.Button
    Friend WithEvents ButtonEncFocus As System.Windows.Forms.Button
    Friend WithEvents LabelEnc As System.Windows.Forms.Label
    Friend WithEvents ButtonRetryCam As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxSaveAE As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSaveIris As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSaveFocus As System.Windows.Forms.CheckBox
    Friend WithEvents BtnInp1 As MyButton
    Friend WithEvents ButtonTouchscreen As Button
    Friend WithEvents Label30 As Label
End Class
