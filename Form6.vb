Public Class Form6
    Dim cb1tc As Integer 'cb1 text changed
    Dim cb2tc As Integer 'cb2 text changed
    Dim Program As String
    Dim Username As String
    Dim Password As String
    Dim where As String
    Dim pws As String
    Dim mpw As String
    Dim mpw1 As String
    Dim mpwbak As String
    Dim user As String
    Dim clos As Boolean
    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As String()
        a = System.Environment.GetCommandLineArgs()
        If a.Length > 1 Then
            If a(1) = "/tray" Then
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
        pws = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + System.Environment.UserName() + "PW"
        mpw = pws + ".pws"
        mpw1 = pws + "1.pws"
        mpwbak = pws + ".bak.pws"
        user = System.Environment.UserName() + "PW.txt"
        where = "pass"
        UsernameL.Text = "Password:"
        If Dir(mpw1, FileAttribute.Normal) = "" Then
            Dim file As System.IO.FileStream
            file = System.IO.File.Create(mpw1)
            file.Close()
        End If
        If Dir(mpw, FileAttribute.Normal) = "" Then
            Dim file As System.IO.FileStream
            file = System.IO.File.Create(mpw)
            file.Close()
        End If
        If Dir(mpwbak, FileAttribute.Normal) = "" Then
            RecoverBackupToolStripMenuItem.Visible = False
        End If
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim temp As String = Encrypt(fileR.ReadLine())
        fileR.Close()
        If temp = "" Then
            MI1.Text = "No Password"
            MI1.Visible = True
            PasswordL.Text = "Confirm:"
            PasswordL.Visible = True
            P3.Visible = True
        End If
        If temp = "!!No Pass!!" Then
            ProgramL.Visible = True
            PasswordL.Visible = True
            UsernameL.Text = "Username:"
            P2.Visible = False
            MI1.Text = "Show Passwords"
            MI1.Visible = True
            MI2.Visible = True
            Exit_ResetPasswordToolStripMenuItem.Text = "Exit"
            ShowPasswords()
        End If
        Dim fileRi As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim encrpt As Boolean = False
        While Not (fileRi.EndOfStream() Or encrpt)
            If fileRi.ReadLine() = "<program>" Then
                encrpt = True
            End If
        End While
        fileRi.Close()
        If (encrpt) Then
            Dim fileWr As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw1, False)
            fileRi = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
            While Not fileRi.EndOfStream()
                fileWr.WriteLine(Encrypt(fileRi.ReadLine))
            End While
            fileRi.Close()
            fileWr.Close()
            fileRi = My.Computer.FileSystem.OpenTextFileReader(mpw1, System.Text.Encoding.Default)
            fileWr = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
            While Not fileRi.EndOfStream()
                fileWr.WriteLine(fileRi.ReadLine)
            End While
            fileRi.Close()
            fileWr.Close()
        End If
        Exit_ResetPasswordToolStripMenuItem.Text = "Reset Password"
        clos = False
        If Me.WindowState = FormWindowState.Normal And P3.Visible = True Then MessageBox.Show("Remember your password or you must reset all data!", "Remember your password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub Form6_Unload(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not clos And e.CloseReason = CloseReason.UserClosing Then
            If MessageBox.Show("Are you sure you want to close?" + vbCrLf + "('No' = minimize to tray)", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel() = True
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub
    Private Sub ShowPasswords_NoPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MI1.Click
        If where = "pass" Then
            If MessageBox.Show("Are you sure you don't want a password?", "No Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
                fileW.WriteLine(Encrypt("!!No Pass!!"))
                fileW.Close()
                ProgramL.Visible = True
                PasswordL.Visible = True
                UsernameL.Text = "Username:"
                P2.Visible = False
                MI1.Text = "Show Passwords"
                MI2.Visible = True
                Exit_ResetPasswordToolStripMenuItem.Text = "Exit"
                ShowPasswords()
            End If
        Else
            ShowPasswords()
        End If
    End Sub
    Private Sub ShowPasswords()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button2.Enabled = False
        Me.Text = "Passwords"
        where = "show passwords"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Hide()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        fileR.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        If p = 1 Then
            Dim u As Integer = 0
            CB2.Items.Clear()
            While Not fileR.EndOfStream()
                Dim fileRS As String = Encrypt(fileR.ReadLine())
                Dim fileRN As String = Encrypt(fileR.ReadLine())
                If fileRS = "     <username>" Then
                    If u = 0 Then
                        L2.Text = fileRN
                    End If
                    CB2.Items.Add(fileRN)
                    u += 1
                    fileRS = Encrypt(fileR.ReadLine())
                    fileRN = Encrypt(fileR.ReadLine())
                    If u = 1 Then
                        L3.Text = fileRN
                    End If
                End If
            End While
            If u = 1 Then
                L2.Visible = True
                L3.Visible = True
            ElseIf u = 0 Then
                L2.Text = "none"
                L2.Visible = True
            Else
                CB2.Sorted = True
                CB2.Visible = True
                CB2.Focus()
            End If
            L1.Visible = True
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub ProgramToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramToolStripMenuItem1.Click
        AddProgram()
    End Sub
    Private Sub AddProgram()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Add Program"
        where = "add program"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Add"
        Button1.Show()
        CB1.Visible = False
        CB2.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        TB1.Text = ""
        TB1.Visible = True
        TB1.Focus()
        TB2.Visible = False
        TB3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
    End Sub
    Private Sub UserNameToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserNameToolStripMenuItem2.Click
        AddUsername()
    End Sub
    Private Sub AddUsername()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Add User Name"
        where = "add username"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Add"
        Button1.Show()
        CB1.Items.Clear()
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        CB1.Visible = False
        CB2.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        If p = 1 Then
            L1.Visible = True
            TB2.Text = ""
            TB2.Visible = True
            TB2.Focus()
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            TB2.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()

    End Sub
    Private Sub ProgramNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramNameToolStripMenuItem.Click
        ChangeProgram()
    End Sub
    Private Sub ChangeProgram()
        CB1.AutoCompleteMode = AutoCompleteMode.None
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Change Program Name"
        where = "change program"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Change"
        Button1.Show()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    TB1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        If p = 1 Then
            TB1.Visible = True
            TB1.Focus()
            Program = TB1.Text
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub UserNameToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserNameToolStripMenuItem1.Click
        ChangeUsername()
    End Sub
    Private Sub ChangeUsername()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.None
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Change User Name"
        where = "change username"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Change"
        Button1.Show()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        fileR.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        If p = 1 Then
            Dim u As Integer = 0
            CB2.Items.Clear()
            While Not fileR.EndOfStream()
                Dim fileRS As String = Encrypt(fileR.ReadLine())
                Dim fileRN As String = Encrypt(fileR.ReadLine())
                If fileRS = "     <username>" Then
                    If u = 0 Then
                        TB2.Text = fileRN
                    End If
                    CB2.Items.Add(fileRN)
                    u += 1
                End If
            End While
            If u = 1 Then
                TB2.Visible = True
                Username = TB2.Text
                TB2.Focus()
            ElseIf u = 0 Then
                L2.Text = "none"
                L2.Visible = True
            Else
                CB2.Sorted = True
                CB2.Visible = True
                CB2.Focus()
            End If
            L1.Visible = True
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub PasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordToolStripMenuItem.Click
        ChangePassword()
    End Sub
    Private Sub ChangePassword()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Change Hint"
        where = "change hint"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Change"
        Button1.Show()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        fileR.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        If p = 1 Then
            Dim u As Integer = 0
            CB2.Items.Clear()
            While Not fileR.EndOfStream()
                Dim fileRS As String = Encrypt(fileR.ReadLine())
                Dim fileRN As String = Encrypt(fileR.ReadLine())
                If fileRS = "     <username>" Then
                    If u = 0 Then
                        L2.Text = fileRN
                    End If
                    CB2.Items.Add(fileRN)
                    u += 1
                    fileRS = Encrypt(fileR.ReadLine())
                    fileRN = Encrypt(fileR.ReadLine())
                    If u = 1 Then
                        TB3.Text = fileRN
                    End If
                End If
            End While
            If u = 1 Then
                L2.Visible = True
                TB3.Visible = True
                TB3.Focus()
                Password = TB3.Text
            ElseIf u = 0 Then
                L2.Text = "none"
                L2.Visible = True
            Else
                CB2.Sorted = True
                CB2.Visible = True
                CB2.Focus()
            End If
            L1.Visible = True
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub ProgramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramToolStripMenuItem.Click
        EraseProgram()
    End Sub
    Private Sub EraseProgram()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Erase Program"
        where = "erase program"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Erase"
        Button1.Show()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        If p = 1 Then
            L1.Visible = True
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub UserNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameToolStripMenuItem.Click
        EraseUsername()
    End Sub
    Private Sub EraseUsername()
        CB1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Erase User Name"
        where = "erase username"
        ProgramL.Text = "Program:"
        UsernameL.Text = "Username:"
        PasswordL.Text = "Hint:"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Erase"
        Button1.Show()
        CB1.Items.Clear()
        CB1.Visible = False
        CB2.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        P1.Visible = False
        P2.Visible = False
        P3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim p As Integer = 0
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" Then
                If p = 0 Then
                    L1.Text = fileRN
                End If
                CB1.Items.Add(fileRN)
                p += 1
            End If
        End While
        fileR.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        If p = 1 Then
            Dim u As Integer = 0
            CB2.Items.Clear()
            While Not fileR.EndOfStream()
                Dim fileRS As String = Encrypt(fileR.ReadLine())
                Dim fileRN As String = Encrypt(fileR.ReadLine())
                If fileRS = "     <username>" Then
                    If u = 0 Then
                        L2.Text = fileRN
                    End If
                    CB2.Items.Add(fileRN)
                    u += 1
                    fileRS = Encrypt(fileR.ReadLine())
                    fileRN = Encrypt(fileR.ReadLine())
                    If u = 1 Then
                        L3.Text = fileRN
                    End If
                End If
            End While
            If u = 1 Then
                L2.Visible = True
                L3.Visible = True
            ElseIf u = 0 Then
                L2.Text = "none"
                L2.Visible = True
            Else
                CB2.Sorted = True
                CB2.Visible = True
                CB2.Focus()
            End If
            L1.Visible = True
        ElseIf p = 0 Then
            L1.Text = "None"
            L1.Visible = True
        Else
            CB1.Text = ""
            CB1.Sorted = True
            CB1.Visible = True
            CB1.Focus()
        End If
        fileR.Close()
    End Sub
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Button1.Enabled = False
        Button2.Enabled = False
        Me.Text = "Change Password"
        where = "change password"
        cb1tc = 0
        cb2tc = 0
        Button1.Text = "Change"
        Button1.Show()
        ProgramL.Text = "Current Password:"
        UsernameL.Text = "New Password:"
        PasswordL.Text = "Confirm Password:"
        CB1.Visible = False
        CB2.Visible = False
        L1.Visible = False
        L2.Visible = False
        L3.Visible = False
        TB1.Visible = False
        TB2.Visible = False
        TB3.Visible = False
        P1.Text = ""
        P1.Visible = True
        P2.Text = ""
        P2.Visible = True
        P3.Text = ""
        P3.Visible = True
    End Sub
    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to clear all data?", "Clear Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
            Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw1, False)
            fileW.WriteLine(fileR.ReadLine())
            fileR.Close()
            fileW.Close()
            fileR = My.Computer.FileSystem.OpenTextFileReader(mpw1, System.Text.Encoding.Default)
            fileW = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
            fileW.WriteLine(fileR.ReadLine())
            fileR.Close()
            fileW.Close()
            ShowPasswords()
        End If
    End Sub
    Private Sub CreateBackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateBackupToolStripMenuItem.Click
        Dim fileW As New System.IO.StreamWriter(mpwbak)
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        While Not fileR.EndOfStream()
            fileW.WriteLine(fileR.ReadLine())
        End While
        fileR.Close()
        fileW.Close()
        RecoverBackupToolStripMenuItem.Visible = True
        MessageBox.Show("Backup Created", "Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ShowPasswords()
    End Sub
    Private Sub RecoverBackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecoverBackupToolStripMenuItem.Click
        If (MessageBox.Show("Are you sure you want to recover your backup? This will erase ALL changes since your last backup, including password changes!", "Recover Backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
            Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpwbak, System.Text.Encoding.Default)
            While Not fileR.EndOfStream()
                fileW.WriteLine(fileR.ReadLine())
            End While
            fileR.Close()
            fileW.Close()
            MessageBox.Show("Backup Recovered", "Backup Recovered", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowPasswords()
        End If
    End Sub
    Private Sub CreateListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateListToolStripMenuItem.Click
        Dim fileW As New System.IO.StreamWriter(user)
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        While Not fileR.EndOfStream()
            fileW.WriteLine(Encrypt(fileR.ReadLine()))
        End While
        fileR.Close()
        fileW.Close()
        System.Diagnostics.Process.Start(user)
        ShowPasswords()
    End Sub
    Private Sub Exit_ResetPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_ResetPasswordToolStripMenuItem.Click
        If where = "pass" Then
            If MessageBox.Show("Are you sure you want to reset your password and erase all data, including backups?", "Reset Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
                fileW.Close()
                On Error Resume Next
                fileW = My.Computer.FileSystem.OpenTextFileWriter(mpwbak, False)
                fileW.Close()
                MI1.Text = "No Password"
                MI1.Visible = True
                PasswordL.Text = "Confirm:"
                PasswordL.Visible = True
                P3.Visible = True
            End If
        Else
            If MessageBox.Show("Are you sure you want to close?" + vbCrLf + "('No' = minimize to tray)", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Me.WindowState = FormWindowState.Minimized
            Else
                clos = True
                Me.Close()
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw1, False)
        Dim sp As Integer = 1
        Select Case where
            Case "pass"
                Dim temp As String = Encrypt(fileR.ReadLine())
                If temp = "" Then
                    If P3.Text = P2.Text Then
                        fileR.Close()
                        fileW.Close()
                        fileW = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
                        fileW.WriteLine(Encrypt(P2.Text))
                        fileW.Close()
                        fileW = My.Computer.FileSystem.OpenTextFileWriter(mpw1, False)
                        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
                        temp = Encrypt(fileR.ReadLine())
                    Else
                        P2.Text = ""
                        P3.Text = ""
                        MessageBox.Show("Passwords not the same!", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        sp = 0
                        GoTo stp
                    End If
                End If
                If (P2.Text = temp) Then
                    ProgramL.Visible = True
                    PasswordL.Visible = True
                    UsernameL.Text = "Username:"
                    PasswordL.Text = "Hint:"
                    P2.Visible = False
                    P3.Visible = False
                    MI1.Text = "Show Passwords"
                    MI1.Visible = True
                    MI2.Visible = True
                    Exit_ResetPasswordToolStripMenuItem.Text = "Exit"
                Else
                    P2.Text = ""
                    sp = 0
                End If
                GoTo stp
            Case "add program"
                If TB1.Text = "" Then
                    If MessageBox.Show("Did you want to add a Program?", "No Program Name?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        sp = 0
                    Else
                        where = "show passwords"
                    End If
                    GoTo stp
                Else
                    While Not fileR.EndOfStream()
                        Dim fileRS As String = Encrypt(fileR.ReadLine())
                        Dim fileRN As String = Encrypt(fileR.ReadLine())
                        If fileRS = "<program>" And fileRN = TB1.Text Then
                            MessageBox.Show("That program name already exists in your list", "Program Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sp = 0
                            GoTo stp
                        Else
                            fileW.WriteLine(Encrypt(fileRS))
                            fileW.WriteLine(Encrypt(fileRN))
                        End If
                    End While
                    fileW.WriteLine(Encrypt("<program>"))
                    fileW.WriteLine(Encrypt(TB1.Text))
                    If TB2.Text = "" Then
                        If Not (TB3.Text = "") Then
                            MessageBox.Show("Hint will not be saved", "No Username!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        If TB3.Text = "" Then
                            If MessageBox.Show("Do you want to add a hint?", "No Hint?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                fileW.WriteLine(Encrypt("     <username>"))
                                fileW.WriteLine(Encrypt(TB2.Text))
                                fileW.WriteLine(Encrypt("     <hint>"))
                                fileW.WriteLine(Encrypt(" "))
                            Else
                                L1.Text = TB1.Text
                                TB1.Visible = False
                                L1.Visible = True
                                where = "add username"
                                sp = 0
                            End If
                        Else
                            fileW.WriteLine(Encrypt("     <username>"))
                            fileW.WriteLine(Encrypt(TB2.Text))
                            fileW.WriteLine(Encrypt("     <hint>"))
                            fileW.WriteLine(Encrypt(TB3.Text))
                        End If
                    End If
                End If
            Case "add username"
                Dim fileR1 As String
                Dim fileR2 As String
                fileR1 = Encrypt(fileR.ReadLine())
                fileR2 = Encrypt(fileR.ReadLine())
                While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(fileR2))
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                End While
                fileW.WriteLine(Encrypt(fileR1))
                fileW.WriteLine(Encrypt(fileR2))
                If TB2.Text = "" Then
                    If MessageBox.Show("Did you want to add a user name?", "No User Name?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        sp = 0
                        GoTo stp
                    Else
                        where = "show passwords"
                    End If
                Else
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                    While fileR1 <> "<program>" And Not fileR.EndOfStream()
                        If fileR1 = "     <username>" And fileR2 = TB2.Text Then
                            MessageBox.Show("User Name already exists for this program!", "User Name Exists!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sp = 0
                            GoTo stp
                        End If
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                    End While
                    If fileR.EndOfStream() Then
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                    End If
                    If TB3.Text = "" Then
                        If MessageBox.Show("Do you want to add a hint?", "No Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            fileW.WriteLine(Encrypt("     <username>"))
                            fileW.WriteLine(Encrypt(TB2.Text))
                            fileW.WriteLine(Encrypt("     <hint>"))
                            fileW.WriteLine(Encrypt(" "))
                        Else
                            sp = 0
                            GoTo stp
                        End If
                    Else
                        fileW.WriteLine(Encrypt("     <username>"))
                        fileW.WriteLine(Encrypt(TB2.Text))
                        fileW.WriteLine(Encrypt("     <hint>"))
                        fileW.WriteLine(Encrypt(TB3.Text))
                    End If
                    If Not fileR.EndOfStream() Then
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                    End If
                End If
            Case "change program"
                If CB1.Visible Then
                    If CB1.Text = "" Then
                        If cb1tc = 1 Then
                            MessageBox.Show("If you want to erase a program go to Edit -> Erase -> Program", "Erase Program?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            CB1.Text = Program
                        End If
                        sp = 0
                        GoTo stp
                    ElseIf Program = CB1.Text Then
                        If MessageBox.Show("Do you want to change the program name?", "Change Program Name?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            sp = 0
                        Else
                            where = "show passwords"
                        End If
                        GoTo stp
                    Else
                        Dim fileR1 As String
                        Dim fileR2 As String
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                        While (fileR1 <> "<program>" Or fileR2 <> Program) And Not fileR.EndOfStream()
                            fileW.WriteLine(Encrypt(fileR1))
                            fileW.WriteLine(Encrypt(fileR2))
                            fileR1 = Encrypt(fileR.ReadLine())
                            fileR2 = Encrypt(fileR.ReadLine())
                        End While
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(CB1.Text))
                    End If
                Else
                    If TB1.Text = "" Then
                        MessageBox.Show("If you want to erase a program" + vbCr + "go to Edit -> Erase -> Program", "Erase Program?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ShowPasswords()
                    ElseIf TB1.Text = Program Then
                        If MessageBox.Show("Do you want to change the program name?", "Change Program Name?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            sp = 0
                        Else
                            where = "show passwords"
                        End If
                        GoTo stp
                    Else
                        Dim fileR1 As String = Encrypt(fileR.ReadLine())
                        Dim fileR2 As String = Encrypt(fileR.ReadLine())
                        While (fileR1 <> "<program>" Or fileR2 <> Program) And Not fileR.EndOfStream()
                            fileW.WriteLine(Encrypt(fileR1))
                            fileW.WriteLine(Encrypt(fileR2))
                            fileR1 = Encrypt(fileR.ReadLine())
                            fileR2 = Encrypt(fileR.ReadLine())
                        End While
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(TB1.Text))
                    End If
                End If
            Case "change username"
                If CB2.Visible And CB2.Text = "" Then
                    If cb2tc = 1 Then
                        MessageBox.Show("If you want to erase a user name" + vbCr + "go to Edit -> Erase -> User Name", "Erase User Name?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        CB2.Text = Username
                    End If
                    sp = 0
                    GoTo stp
                ElseIf TB2.Visible And TB2.Text = "" Then
                    MessageBox.Show("If you want to erase a user name" + vbCr + "go to Edit -> Erase -> User Name", "Erase User Name?", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TB2.Text = Username
                    sp = 0
                    GoTo stp
                ElseIf IIf(CB2.Visible, CB2.Text, TB2.Text) = Username Then
                    If MessageBox.Show("Do you want to change the user name?", "Change User Name?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        sp = 0
                    Else
                        where = "show passwords"
                    End If
                    GoTo stp
                Else
                    Dim fileR1 As String = Encrypt(fileR.ReadLine())
                    Dim fileR2 As String = Encrypt(fileR.ReadLine())
                    While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                    End While
                    While (fileR1 <> "     <username>" Or fileR2 <> Username) And Not fileR.EndOfStream()
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                    End While
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(IIf(CB2.Visible, CB2.Text, TB2.Text)))
                End If
            Case "change hint"
                If TB3.Text = "" Then
                    If MessageBox.Show("Are you sure you don't want" + vbCr + "a password for this user name?", "No Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        sp = 0
                        GoTo stp
                    Else
                        Dim fileR1 As String = Encrypt(fileR.ReadLine())
                        Dim fileR2 As String = Encrypt(fileR.ReadLine())
                        While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                            fileW.WriteLine(Encrypt(fileR1))
                            fileW.WriteLine(Encrypt(fileR2))
                            fileR1 = Encrypt(fileR.ReadLine())
                            fileR2 = Encrypt(fileR.ReadLine())
                        End While
                        While (fileR1 <> "     <username>" Or fileR2 <> IIf(CB2.Visible, CB2.Text, L2.Text)) And Not fileR.EndOfStream()
                            fileW.WriteLine(Encrypt(fileR1))
                            fileW.WriteLine(Encrypt(fileR2))
                            fileR1 = Encrypt(fileR.ReadLine())
                            fileR2 = Encrypt(fileR.ReadLine())
                        End While
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileW.WriteLine(Encrypt(fileR.ReadLine()))
                        fileR2 = Encrypt(fileR.ReadLine())
                        fileW.WriteLine(Encrypt(""))
                    End If
                ElseIf TB3.Text = Password Then
                    If MessageBox.Show("Do you want to change the password?", "Change Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        sp = 0
                    Else
                        where = "show passwords"
                    End If
                    GoTo stp
                Else
                    Dim fileR1 As String = Encrypt(fileR.ReadLine())
                    Dim fileR2 As String = Encrypt(fileR.ReadLine())
                    While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                    End While
                    While (fileR1 <> "     <username>" Or fileR2 <> IIf(CB2.Visible, CB2.Text, L2.Text)) And Not fileR.EndOfStream()
                        fileW.WriteLine(Encrypt(fileR1))
                        fileW.WriteLine(Encrypt(fileR2))
                        fileR1 = Encrypt(fileR.ReadLine())
                        fileR2 = Encrypt(fileR.ReadLine())
                    End While
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(fileR2))
                    fileW.WriteLine(Encrypt(fileR.ReadLine()))
                    fileR2 = Encrypt(fileR.ReadLine())
                    fileW.WriteLine(Encrypt(TB3.Text))
                End If
            Case "erase program"
                If CB1.Visible And CB1.Text = "" Then
                    sp = 0
                    GoTo stp
                End If
                Dim fileR1 As String = Encrypt(fileR.ReadLine())
                Dim fileR2 As String = Encrypt(fileR.ReadLine())
                While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(fileR2))
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                End While
                fileR1 = Encrypt(fileR.ReadLine())
                fileR2 = Encrypt(fileR.ReadLine())
                While fileR1 <> "<program>" And Not fileR.EndOfStream()
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                End While
                fileW.WriteLine(Encrypt(fileR1))
                fileW.WriteLine(Encrypt(fileR2))
            Case "erase username"
                If (CB1.Visible And CB1.Text = "") Or (CB2.Visible And CB2.Text = "") Then
                    sp = 0
                    GoTo stp
                End If
                Dim fileR1 As String = Encrypt(fileR.ReadLine())
                Dim fileR2 As String = Encrypt(fileR.ReadLine())
                While (fileR1 <> "<program>" Or fileR2 <> IIf(CB1.Visible, CB1.Text, L1.Text)) And Not fileR.EndOfStream()
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(fileR2))
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                End While
                fileW.WriteLine(Encrypt(fileR1))
                fileW.WriteLine(Encrypt(fileR2))
                fileR1 = Encrypt(fileR.ReadLine())
                fileR2 = Encrypt(fileR.ReadLine())
                While (fileR1 <> "     <username>" Or fileR2 <> IIf(CB2.Visible, CB2.Text, L2.Text)) And Not fileR.EndOfStream()
                    fileW.WriteLine(Encrypt(fileR1))
                    fileW.WriteLine(Encrypt(fileR2))
                    fileR1 = Encrypt(fileR.ReadLine())
                    fileR2 = Encrypt(fileR.ReadLine())
                End While
                fileR1 = Encrypt(fileR.ReadLine())
                fileR2 = Encrypt(fileR.ReadLine())
            Case "change password"
                If P2.Text <> P3.Text Then
                    MessageBox.Show("Confirmed password does not match!", "Not A Match!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    P1.Text = ""
                    P2.Text = ""
                    P3.Text = ""
                    sp = 0
                    GoTo stp
                Else
                    Dim fileR1 As String = Encrypt(fileR.ReadLine())
                    Dim fileR2 As String = Encrypt(fileR.ReadLine())
                    If (fileR1 = "!!No Pass!!" And P1.Text = "") Or P1.Text = fileR1 Then
                        If P2.Text = "" Then
                            If MessageBox.Show("Are you sure you don't want a password?", "No Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                fileW.WriteLine(Encrypt("!!No Pass!!"))
                            Else
                                P1.Text = ""
                                P2.Text = ""
                                P3.Text = ""
                                sp = 0
                                GoTo stp
                            End If
                        Else
                            fileW.WriteLine(Encrypt(P2.Text))
                        End If
                        fileW.WriteLine(Encrypt(fileR2))
                    Else
                        MessageBox.Show("Current password does not match!", "Not A Match!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        P1.Text = ""
                        P2.Text = ""
                        P3.Text = ""
                        sp = 0
                        GoTo stp
                    End If
                End If
        End Select
        While Not fileR.EndOfStream()
            fileW.WriteLine(fileR.ReadLine())
        End While
        fileR.Close()
        fileW.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw1, System.Text.Encoding.Default)
        fileW = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
        While Not fileR.EndOfStream()
            fileW.WriteLine(fileR.ReadLine())
        End While
stp:
        fileR.Close()
        fileW.Close()
        If sp = 1 Then
            Select Case where
                Case "add program"
                    AddProgram()
                Case "add username"
                    AddUsername()
                Case "change program"
                    ChangeProgram()
                Case "change username"
                    ChangeUsername()
                Case "change hint"
                    ChangePassword()
                Case "erase program"
                    EraseProgram()
                Case "erase username"
                    EraseUsername()
                Case Else
                    ShowPasswords()
            End Select
        End If
    End Sub
    Private Sub Button1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.VisibleChanged
        If Button1.Visible Then
            Button2.Location = New System.Drawing.Point(140, 130)
        Else
            Button2.Location = New System.Drawing.Point(88, 130)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = False
        Button2.Enabled = False
        cb1tc = 0
        cb2tc = 0
        P1.Text = ""
        P2.Text = ""
        P3.Text = ""
        TB1.Text = ""
        TB2.Text = ""
        TB3.Text = ""
        CB1.Text = ""
        CB2.Text = ""
        If L1.Visible() Then
            If L2.Visible() Then
                TB3.Focus()
            Else
                L3.Visible = False
                TB3.Visible = False
                IIf(CB2.Visible, CB2.Focus(), TB2.Focus())
            End If
        Else
            L2.Visible = False
            L3.Visible = False
            TB2.Visible = False
            TB3.Visible = False
            CB2.Visible = False
            IIf(CB1.Visible, CB1.Focus(), IIf(TB1.Visible, TB1.Focus(), IIf(P1.Visible, P1.Focus(), P2.Focus())))
        End If
    End Sub
    Private Sub TB1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.TextChanged
        TB2.Text = ""
        If TB1.Text = "" Then
            Button2.Enabled = False
            TB2.Visible = False
            TB3.Visible = False
        Else
            Button2.Enabled = True
            If where = "add program" Then
                TB2.Visible = True
            End If
        End If
    End Sub
    Private Sub TB2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB2.TextChanged
        TB3.Text = ""
        If TB2.Text = "" Then
            TB3.Visible = False
            Button1.Enabled = False
        Else
            If where <> "change username" Then
                TB3.Text = ""
                TB3.Visible = True
            End If
            Button1.Enabled = True
        End If
    End Sub
    Private Sub TB3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB3.TextChanged
        Button1.Enabled = True
    End Sub
    Private Sub CB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB1.SelectedIndexChanged
        Button2.Enabled = True
        TB2.Visible = False
        TB3.Visible = False
        CB2.Visible = False
        L2.Visible = False
        L3.Visible = False
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Program = CB1.Text
        Dim u As Integer = 0
        CB2.Items.Clear()
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" And fileRN = CB1.Text Then
                fileRS = "     <hint>"
                While fileRS = "     <hint>"
                    fileRS = Encrypt(fileR.ReadLine())
                    fileRN = Encrypt(fileR.ReadLine())
                    If fileRS = "     <username>" Then
                        CB2.Items.Add(fileRN)
                        If u = 0 Then
                            L2.Text = fileRN
                            TB2.Text = fileRN
                            TB3.Visible = False
                        End If
                        fileRS = Encrypt(fileR.ReadLine())
                        fileRN = Encrypt(fileR.ReadLine())
                        If u = 0 Then
                            L3.Text = fileRN
                            TB3.Text = fileRN
                        End If
                        u += 1
                    End If
                End While
            End If
        End While
        CB2.Text = ""
        CB2.Sorted = True
        fileR.Close()
        Select Case where
            Case "show passwords"
                If u = 0 Then
                    L2.Text = "None"
                    L2.Visible = True
                ElseIf u = 1 Then
                    L2.Visible = True
                    L3.Visible = True
                Else
                    CB2.Visible = True
                    CB2.Focus()
                End If
            Case "add username"
                TB2.Text = ""
                TB2.Visible = True
                TB2.Focus()
            Case "change username"
                If u = 0 Then
                    L2.Text = "None"
                    L2.Visible = True
                ElseIf u = 1 Then
                    TB2.Visible = True
                    TB2.Focus()
                    Username = TB2.Text
                    L3.Visible = True
                Else
                    CB2.Visible = True
                    CB2.Focus()
                End If
            Case "change hint"
                If u = 0 Then
                    L2.Text = "None"
                    L2.Visible = True
                ElseIf u = 1 Then
                    L2.Visible = True
                    TB3.Visible = True
                    TB3.Focus()
                    Password = TB3.Text
                Else
                    CB2.Visible = True
                    CB2.Focus()
                End If
            Case "erase program"
                If CB1.Text = "" Then
                    Button1.Enabled = False
                Else
                    Button1.Enabled = True
                End If
            Case "erase username"
                If u = 0 Then
                    L2.Text = "None"
                    L2.Visible = True
                ElseIf u = 1 Then
                    L2.Visible = True
                    L3.Visible = True
                Else
                    CB2.Visible = True
                    CB2.Focus()
                End If
        End Select
    End Sub
    Private Sub CB2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB2.SelectedIndexChanged
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Username = CB2.Text
        While Not fileR.EndOfStream()
            Dim fileRS As String = Encrypt(fileR.ReadLine())
            Dim fileRN As String = Encrypt(fileR.ReadLine())
            If fileRS = "<program>" And (fileRN = CB1.Text Or fileRN = L1.Text) Then
                While (fileRS <> "     <username>" Or fileRN <> CB2.Text) And Not fileR.EndOfStream()
                    fileRS = Encrypt(fileR.ReadLine())
                    fileRN = Encrypt(fileR.ReadLine())
                End While
                fileRS = Encrypt(fileR.ReadLine())
                fileRN = Encrypt(fileR.ReadLine())
                TB3.Text = fileRN
                L3.Text = fileRN
            End If
        End While
        fileR.Close()
        Select Case where
            Case "show passwords"
                L3.Visible = True
            Case "change username"
                L3.Visible = True
            Case "change hint"
                TB3.Visible = True
                TB3.Focus()
                Password = TB3.Text
            Case "erase username"
                L3.Visible = True
        End Select
    End Sub
    Private Sub CB1_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB1.TextUpdate
        If where = "change program" Then
            cb1tc = 1
        End If
        If CB1.Text = "" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
    End Sub
    Private Sub CB2_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB2.TextUpdate
        If where = "change username" Then
            cb2tc = 1
        End If
    End Sub
    Private Sub L1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L1.VisibleChanged
        If Not L1.Visible Then
            L1.Text = ""
        End If
    End Sub
    Private Sub L2_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L2.VisibleChanged
        If Not L2.Visible Then
            L2.Text = ""
        End If
    End Sub
    Private Sub L3_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L3.VisibleChanged
        If Not L3.Visible Then
            L3.Text = ""
        End If
    End Sub
    Private Sub P1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P1.TextChanged
        If P1.Text = P2.Text And P2.Text = P3.Text Then
            Button1.Enabled = False
            Button2.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
        End If
    End Sub
    Private Sub P2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P2.TextChanged
        If where = "pass" Then
            If P2.Text.Length > 0 Then
                Button2.Enabled = True
                If P2.Text = P3.Text Or P3.Visible = False Then
                    Button1.Enabled = True
                Else
                    If P3.Text.Length = 0 Then
                        Button1.Enabled = False
                    End If
                End If
            Else
                Button1.Enabled = False
                If P3.Text.Length = 0 Then
                    Button2.Enabled = False
                End If
            End If
        Else
            If P1.Text = P2.Text And P2.Text = P3.Text Then
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                Button1.Enabled = True
                Button2.Enabled = True
            End If
        End If
    End Sub
    Private Sub P3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P3.TextChanged
        If where = "pass" Then
            If P3.Text.Length > 0 Then
                Button2.Enabled = True
                If P2.Text = P3.Text Then
                    Button1.Enabled = True
                Else
                    Button1.Enabled = False
                End If
            Else
                Button1.Enabled = False
                If P2.Text.Length = 0 Then
                    Button2.Enabled = False
                End If
            End If
        Else
            If P1.Text = P2.Text And P2.Text = P3.Text Then
                Button1.Enabled = False
                Button2.Enabled = False
            Else
                Button1.Enabled = True
                Button2.Enabled = True
            End If
        End If
    End Sub
    Private Sub MadeByTonyBrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MadeByTonyBrixToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.freewebs.com/tonysfiles")
    End Sub
    Private Sub Version35ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version35ToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.freewebs.com/tonysfiles")
    End Sub
    Private Sub TBrix13gmailcomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBrix13gmailcomToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.freewebs.com/tonysfiles")
    End Sub
    Private Sub ClearSpacesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fileR As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
        Dim fileW As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(mpw1, False)
        Dim fileR1 As String = Encrypt(fileR.ReadLine())
        While Not fileR.EndOfStream()
            If fileR1 <> "" Then
                fileW.WriteLine(Encrypt(fileR1))
            End If
            fileR1 = Encrypt(fileR.ReadLine())
        End While
        fileR.Close()
        fileW.Close()
        fileR = My.Computer.FileSystem.OpenTextFileReader(mpw1, System.Text.Encoding.Default)
        fileW = My.Computer.FileSystem.OpenTextFileWriter(mpw, False)
        While Not fileR.EndOfStream()
            If fileR1 <> "" Then
                fileW.WriteLine(Encrypt(fileR1))
            End If
            fileR1 = Encrypt(fileR.ReadLine())
        End While
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        clos = True
        Me.Close()
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If P3.Visible = True Then MessageBox.Show("Remember your password or you must reset all data!", "Remember your password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        WindowState = FormWindowState.Normal
    End Sub
    Private Sub Form6_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            ShowInTaskbar = False
        ElseIf WindowState = FormWindowState.Normal Then
            ShowInTaskbar = True
        End If
        If where <> "pass" And where <> "" Then
            where = "pass"
            ProgramL.Visible = False
            UsernameL.Text = "Password:"
            PasswordL.Visible = False
            CB1.Visible = False
            CB2.Visible = False
            TB1.Visible = False
            TB2.Visible = False
            TB3.Visible = False
            L1.Visible = False
            L2.Visible = False
            L3.Visible = False
            P2.Text = ""
            P2.Visible = True
            MI1.Visible = False
            MI2.Visible = False
            Button1.Visible = True
            Exit_ResetPasswordToolStripMenuItem.Text = "Reset Password"
            Dim file As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(mpw, System.Text.Encoding.Default)
            Dim temp As String = Encrypt(file.ReadLine())
            file.Close()
            If temp = "" Then
                MI1.Text = "No Password"
                MI1.Visible = True
            End If
            If temp = "!!No Pass!!" Then
                ProgramL.Visible = True
                PasswordL.Visible = True
                UsernameL.Text = "Username:"
                P2.Visible = False
                MI1.Text = "Show Passwords"
                MI1.Visible = True
                MI2.Visible = True
                Exit_ResetPasswordToolStripMenuItem.Text = "Exit"
                ShowPasswords()
            End If
        End If
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        WindowState = FormWindowState.Normal
        If P3.Visible = True Then MessageBox.Show("Remember your password or you must reset all data!", "Remember your password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Function Encrypt(ByVal s As String) As String
        Dim es As String = ""
        If s = vbNullString Then
            Return ""
        End If
        For Each c As Char In s
            Dim bits As Byte() = System.BitConverter.GetBytes(c)
            Array.Reverse(bits)
            es += System.BitConverter.ToChar(bits, 0)
        Next
        Return es
    End Function
End Class