Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Public Class MyButton
    Inherits System.Windows.Forms.Button
    Private pushed As Boolean

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim offset As Integer
        'MyBase.OnPaint(e) 'draw default appearance
        If Not pushed Then
            If Me.BackColor = Color.Green Then
                e.Graphics.DrawImage(My.Resources.greenbtnrnd, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            ElseIf Me.BackColor = Color.Red Then
                e.Graphics.DrawImage(My.Resources.redbtnrnd, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            ElseIf Me.BackColor = Color.Yellow Then
                e.Graphics.DrawImage(My.Resources.RedGrnBtn, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            ElseIf Me.BackColor = Color.Orange Then
                e.Graphics.DrawImage(My.Resources.yellowbtnrnd, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            ElseIf Me.BackColor = Color.Purple Then
                e.Graphics.DrawImage(My.Resources.purplebtnrnd, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            Else
                e.Graphics.DrawImage(My.Resources.whitebtnrnd, ClientRectangle.Top, ClientRectangle.Left, ClientRectangle.Width, ClientRectangle.Height + 3)
            End If
            offset = 0
        Else
            If Me.BackColor = Color.Green Then
                e.Graphics.DrawImage(My.Resources.greenbtnrnd, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            ElseIf Me.BackColor = Color.Red Then
                e.Graphics.DrawImage(My.Resources.redbtnrnd, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            ElseIf Me.BackColor = Color.Yellow Then
                e.Graphics.DrawImage(My.Resources.RedGrnBtn, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            ElseIf Me.BackColor = Color.Orange Then
                e.Graphics.DrawImage(My.Resources.yellowbtnrnd, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            ElseIf Me.BackColor = Color.Purple Then
                e.Graphics.DrawImage(My.Resources.purplebtnrnd, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            Else
                e.Graphics.DrawImage(My.Resources.whitebtnrnd, ClientRectangle.Top + 2, ClientRectangle.Left + 2, ClientRectangle.Width - 4, ClientRectangle.Height + 3 - 4)
            End If
            offset = 2
        End If

        Dim flags As TextFormatFlags = TextFormatFlags.WordBreak Or TextFormatFlags.TextBoxControl Or TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.NoPadding
        'the textboxcontrol flag causes it to split long words
        TextRenderer.DrawText(e.Graphics, MyBase.Text, Me.Font, ClientRectangle, Me.ForeColor, flags)

    End Sub


    Private Sub MyButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        pushed = True
        Me.Invalidate()
    End Sub

    Private Sub MyButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        pushed = False
        Me.Invalidate()
    End Sub
End Class
