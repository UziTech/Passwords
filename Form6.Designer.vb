<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If P3.Visible = True Then MessageBox.Show("Remember your password or you must reset all data!", "Remember your password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        WindowState = FormWindowState.Normal
        ShowInTaskbar = True
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.ProgramL = New System.Windows.Forms.Label
        Me.UsernameL = New System.Windows.Forms.Label
        Me.PasswordL = New System.Windows.Forms.Label
        Me.TB1 = New System.Windows.Forms.TextBox
        Me.TB2 = New System.Windows.Forms.TextBox
        Me.TB3 = New System.Windows.Forms.TextBox
        Me.L1 = New System.Windows.Forms.Label
        Me.CB1 = New System.Windows.Forms.ComboBox
        Me.CB2 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.L2 = New System.Windows.Forms.Label
        Me.L3 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MI1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MI2 = New System.Windows.Forms.ToolStripMenuItem
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgramToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UserNameToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgramNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UserNameToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EraseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsernameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RecoverBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.About = New System.Windows.Forms.ToolStripMenuItem
        Me.MadeByTonyBrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Version35ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TBrix13gmailcomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Exit_ResetPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.P2 = New System.Windows.Forms.TextBox
        Me.P1 = New System.Windows.Forms.TextBox
        Me.P3 = New System.Windows.Forms.TextBox
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgramL
        '
        Me.ProgramL.AutoSize = True
        Me.ProgramL.Location = New System.Drawing.Point(12, 33)
        Me.ProgramL.Name = "ProgramL"
        Me.ProgramL.Size = New System.Drawing.Size(49, 13)
        Me.ProgramL.TabIndex = 3
        Me.ProgramL.Text = "Program:"
        Me.ProgramL.Visible = False
        '
        'UsernameL
        '
        Me.UsernameL.AutoSize = True
        Me.UsernameL.Location = New System.Drawing.Point(12, 66)
        Me.UsernameL.Name = "UsernameL"
        Me.UsernameL.Size = New System.Drawing.Size(63, 13)
        Me.UsernameL.TabIndex = 2
        Me.UsernameL.Text = "User Name:"
        '
        'PasswordL
        '
        Me.PasswordL.AutoSize = True
        Me.PasswordL.Location = New System.Drawing.Point(12, 98)
        Me.PasswordL.Name = "PasswordL"
        Me.PasswordL.Size = New System.Drawing.Size(29, 13)
        Me.PasswordL.TabIndex = 3
        Me.PasswordL.Text = "Hint:"
        Me.PasswordL.Visible = False
        '
        'TB1
        '
        Me.TB1.Location = New System.Drawing.Point(114, 30)
        Me.TB1.Name = "TB1"
        Me.TB1.Size = New System.Drawing.Size(100, 20)
        Me.TB1.TabIndex = 1
        Me.TB1.Visible = False
        '
        'TB2
        '
        Me.TB2.Location = New System.Drawing.Point(114, 63)
        Me.TB2.Name = "TB2"
        Me.TB2.Size = New System.Drawing.Size(100, 20)
        Me.TB2.TabIndex = 4
        Me.TB2.Visible = False
        '
        'TB3
        '
        Me.TB3.Location = New System.Drawing.Point(114, 95)
        Me.TB3.Name = "TB3"
        Me.TB3.Size = New System.Drawing.Size(100, 20)
        Me.TB3.TabIndex = 7
        Me.TB3.Visible = False
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Location = New System.Drawing.Point(114, 33)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(39, 13)
        Me.L1.TabIndex = 1
        Me.L1.Text = "Label1"
        Me.L1.Visible = False
        '
        'CB1
        '
        Me.CB1.AllowDrop = True
        Me.CB1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB1.FormattingEnabled = True
        Me.CB1.Location = New System.Drawing.Point(114, 30)
        Me.CB1.Name = "CB1"
        Me.CB1.Size = New System.Drawing.Size(121, 21)
        Me.CB1.TabIndex = 2
        Me.CB1.Visible = False
        '
        'CB2
        '
        Me.CB2.AllowDrop = True
        Me.CB2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB2.FormattingEnabled = True
        Me.CB2.Location = New System.Drawing.Point(114, 63)
        Me.CB2.Name = "CB2"
        Me.CB2.Size = New System.Drawing.Size(121, 21)
        Me.CB2.TabIndex = 5
        Me.CB2.Visible = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(30, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(140, 130)
        Me.Button2.MaximumSize = New System.Drawing.Size(75, 23)
        Me.Button2.MinimumSize = New System.Drawing.Size(75, 23)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Location = New System.Drawing.Point(114, 66)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(39, 13)
        Me.L2.TabIndex = 12
        Me.L2.Text = "Label2"
        Me.L2.Visible = False
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Location = New System.Drawing.Point(114, 98)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(39, 13)
        Me.L3.TabIndex = 13
        Me.L3.Text = "Label3"
        Me.L3.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MI1, Me.MI2, Me.About, Me.Exit_ResetPasswordToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(247, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MI1
        '
        Me.MI1.Name = "MI1"
        Me.MI1.Size = New System.Drawing.Size(106, 20)
        Me.MI1.Text = "Show Passwords"
        Me.MI1.Visible = False
        '
        'MI2
        '
        Me.MI2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.ChangeToolStripMenuItem, Me.EraseToolStripMenuItem, Me.ToolStripMenuItem1, Me.ChangePasswordToolStripMenuItem, Me.ClearDataToolStripMenuItem, Me.CreateBackupToolStripMenuItem, Me.RecoverBackupToolStripMenuItem, Me.CreateListToolStripMenuItem})
        Me.MI2.Name = "MI2"
        Me.MI2.Size = New System.Drawing.Size(42, 20)
        Me.MI2.Text = "Edit "
        Me.MI2.Visible = False
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem1, Me.UserNameToolStripMenuItem2})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'ProgramToolStripMenuItem1
        '
        Me.ProgramToolStripMenuItem1.Name = "ProgramToolStripMenuItem1"
        Me.ProgramToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.ProgramToolStripMenuItem1.Text = "Program"
        '
        'UserNameToolStripMenuItem2
        '
        Me.UserNameToolStripMenuItem2.Name = "UserNameToolStripMenuItem2"
        Me.UserNameToolStripMenuItem2.Size = New System.Drawing.Size(132, 22)
        Me.UserNameToolStripMenuItem2.Text = "User Name"
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramNameToolStripMenuItem, Me.UserNameToolStripMenuItem1, Me.PasswordToolStripMenuItem})
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangeToolStripMenuItem.Text = "Change"
        '
        'ProgramNameToolStripMenuItem
        '
        Me.ProgramNameToolStripMenuItem.Name = "ProgramNameToolStripMenuItem"
        Me.ProgramNameToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ProgramNameToolStripMenuItem.Text = "Program Name"
        '
        'UserNameToolStripMenuItem1
        '
        Me.UserNameToolStripMenuItem1.Name = "UserNameToolStripMenuItem1"
        Me.UserNameToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.UserNameToolStripMenuItem1.Text = "User Name"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.PasswordToolStripMenuItem.Text = "Password"
        '
        'EraseToolStripMenuItem
        '
        Me.EraseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramToolStripMenuItem, Me.UsernameToolStripMenuItem})
        Me.EraseToolStripMenuItem.Name = "EraseToolStripMenuItem"
        Me.EraseToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EraseToolStripMenuItem.Text = "Erase"
        '
        'ProgramToolStripMenuItem
        '
        Me.ProgramToolStripMenuItem.Name = "ProgramToolStripMenuItem"
        Me.ProgramToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ProgramToolStripMenuItem.Text = "Program"
        '
        'UsernameToolStripMenuItem
        '
        Me.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
        Me.UsernameToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.UsernameToolStripMenuItem.Text = "Username"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear All Data"
        '
        'CreateBackupToolStripMenuItem
        '
        Me.CreateBackupToolStripMenuItem.Name = "CreateBackupToolStripMenuItem"
        Me.CreateBackupToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CreateBackupToolStripMenuItem.Text = "Create Backup"
        '
        'RecoverBackupToolStripMenuItem
        '
        Me.RecoverBackupToolStripMenuItem.Name = "RecoverBackupToolStripMenuItem"
        Me.RecoverBackupToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RecoverBackupToolStripMenuItem.Text = "Recover Backup"
        '
        'CreateListToolStripMenuItem
        '
        Me.CreateListToolStripMenuItem.Name = "CreateListToolStripMenuItem"
        Me.CreateListToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CreateListToolStripMenuItem.Text = "Create List"
        '
        'About
        '
        Me.About.BackColor = System.Drawing.SystemColors.Control
        Me.About.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MadeByTonyBrixToolStripMenuItem, Me.Version35ToolStripMenuItem, Me.TBrix13gmailcomToolStripMenuItem})
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(52, 20)
        Me.About.Text = "About"
        '
        'MadeByTonyBrixToolStripMenuItem
        '
        Me.MadeByTonyBrixToolStripMenuItem.BackColor = System.Drawing.Color.Lime
        Me.MadeByTonyBrixToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.MadeByTonyBrixToolStripMenuItem.Name = "MadeByTonyBrixToolStripMenuItem"
        Me.MadeByTonyBrixToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MadeByTonyBrixToolStripMenuItem.Text = "Made by Tony Brix"
        '
        'Version35ToolStripMenuItem
        '
        Me.Version35ToolStripMenuItem.BackColor = System.Drawing.Color.Lime
        Me.Version35ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.Version35ToolStripMenuItem.Name = "Version35ToolStripMenuItem"
        Me.Version35ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Version35ToolStripMenuItem.Text = "Version 3.5"
        '
        'TBrix13gmailcomToolStripMenuItem
        '
        Me.TBrix13gmailcomToolStripMenuItem.BackColor = System.Drawing.Color.Lime
        Me.TBrix13gmailcomToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.TBrix13gmailcomToolStripMenuItem.Name = "TBrix13gmailcomToolStripMenuItem"
        Me.TBrix13gmailcomToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TBrix13gmailcomToolStripMenuItem.Text = "TBrix13@gmail.com"
        '
        'Exit_ResetPasswordToolStripMenuItem
        '
        Me.Exit_ResetPasswordToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Exit_ResetPasswordToolStripMenuItem.Name = "Exit_ResetPasswordToolStripMenuItem"
        Me.Exit_ResetPasswordToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.Exit_ResetPasswordToolStripMenuItem.Text = "Exit"
        '
        'P2
        '
        Me.P2.AccessibleDescription = ""
        Me.P2.Location = New System.Drawing.Point(114, 63)
        Me.P2.Name = "P2"
        Me.P2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.P2.Size = New System.Drawing.Size(116, 20)
        Me.P2.TabIndex = 3
        '
        'P1
        '
        Me.P1.AccessibleDescription = ""
        Me.P1.Location = New System.Drawing.Point(114, 30)
        Me.P1.Name = "P1"
        Me.P1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.P1.Size = New System.Drawing.Size(116, 20)
        Me.P1.TabIndex = 0
        Me.P1.Visible = False
        '
        'P3
        '
        Me.P3.AccessibleDescription = ""
        Me.P3.Location = New System.Drawing.Point(114, 95)
        Me.P3.Name = "P3"
        Me.P3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.P3.Size = New System.Drawing.Size(116, 20)
        Me.P3.TabIndex = 6
        Me.P3.Visible = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Passwords"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 48)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'Form6
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 158)
        Me.Controls.Add(Me.P3)
        Me.Controls.Add(Me.P1)
        Me.Controls.Add(Me.P2)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CB2)
        Me.Controls.Add(Me.CB1)
        Me.Controls.Add(Me.TB3)
        Me.Controls.Add(Me.TB2)
        Me.Controls.Add(Me.TB1)
        Me.Controls.Add(Me.PasswordL)
        Me.Controls.Add(Me.UsernameL)
        Me.Controls.Add(Me.ProgramL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form6"
        Me.Text = "Passwords"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgramL As System.Windows.Forms.Label
    Friend WithEvents UsernameL As System.Windows.Forms.Label
    Friend WithEvents PasswordL As System.Windows.Forms.Label
    Friend WithEvents TB1 As System.Windows.Forms.TextBox
    Friend WithEvents TB2 As System.Windows.Forms.TextBox
    Friend WithEvents TB3 As System.Windows.Forms.TextBox
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents CB1 As System.Windows.Forms.ComboBox
    Friend WithEvents CB2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MI1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MI2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Exit_ResetPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserNameToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserNameToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EraseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsernameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents P2 As System.Windows.Forms.TextBox
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents P1 As System.Windows.Forms.TextBox
    Friend WithEvents P3 As System.Windows.Forms.TextBox
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MadeByTonyBrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Version35ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TBrix13gmailcomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateBackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecoverBackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreateListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
