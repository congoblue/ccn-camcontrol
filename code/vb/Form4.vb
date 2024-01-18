Public Class Form4
    Dim idx As Integer
    Dim listid As String
    Dim res As String
    Dim WithEvents wc As New System.Net.WebClient

    Sub FillListBox()
        If RadioButton1.Checked = True Then idx = 1
        If RadioButton2.Checked = True Then idx = 2
        If RadioButton3.Checked = True Then idx = 3
        If RadioButton4.Checked = True Then idx = 4
        ListBox1.Items.Clear()
        res = MainForm.SendCamQuery(idx, "get_mp4_list2?maxmatches=10&index=1")
        'res = "no,filename,mm/dd/yyyy hh:mm:ss,duration" & vbCrLf & "1,S0MA001000000110,01/01/2015 12:0:0,00:05:05" & vbCrLf & "2,S0MA001000000210,01/01/2015 15:15:15,00:05:05" & vbCrLf & "MP4fileNum=2" & vbCrLf & "MP4fileALLNum=2" & vbCrLf & "list_id = 123"
        If InStr(res, "list_id") <> 0 Then
            listid = Mid(res, InStr(res, "list_id") + 8)
        End If
        Dim strArray As String() = res.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        For Each item As String In strArray
            ListBox1.Items.Add(item)
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillListBox()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As System.EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click, RadioButton4.Click
        FillListBox()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'delete
        Dim file As String
        Dim fileno As String
        If ListBox1.SelectedIndex = -1 Or ListBox1.SelectedIndex = 0 Or InStr(ListBox1.SelectedItem.ToString, ",") = 0 Then MessageBox.Show("Select a file from the list") : Exit Sub
        file = ListBox1.SelectedItem.ToString
        fileno = Mid(file, 1, InStr(file, ",") - 1)
        res = MainForm.SendCamQuery(idx, "del_mp4_file?fileno=" & fileno & "&list_id=" & listid)
        FillListBox()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'download
        If Button2.Text="Downloading" then Exit Sub
        Dim file As String
        Dim fileno, url As String
        If ListBox1.SelectedIndex = -1 Then MessageBox.Show("Select a file from the list") : Exit Sub
        file = ListBox1.SelectedItem.ToString
        fileno = Mid(file, InStr(file, ",") + 1)
        fileno = Mid(fileno, 1, InStr(fileno, ",") - 1)
        url = "http://" & Globals.CamIP(idx) & "/cgi-bin/get_mp4_file?filename=" & fileno & "&list_id=" & listid

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "mp4 video|*.mp4"
        saveFileDialog1.Title = "Save video file"
        saveFileDialog1.FileName = fileno
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.  
        If saveFileDialog1.FileName <> "" Then
            'Me.Cursor = Cursors.WaitCursor
            'Form5.Show()
            'Form5.Refresh()
            Button2.Text = "Downloading"
            Label1.Text = "Downloading"
            Label1.Visible = True
            wc.DownloadFileAsync(New Uri(url), fileno & ".mp4")

            'Me.Cursor = Cursors.Default
            'Form5.Hide()
            

        End If


    End Sub
    Private Sub wc_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles wc.DownloadFileCompleted

        Label1.Visible = False
        Button2.Text = "Download"
        MsgBox("Downloaded ok")
    End Sub

    Private Sub wc_DownloadProgressChanged1(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles wc.DownloadProgressChanged

        Label1.Text = "Download " & e.ProgressPercentage & "%"
    End Sub
End Class