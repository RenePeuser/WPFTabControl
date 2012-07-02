Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InteropUserControl
    Inherits System.Windows.Forms.UserControl

    'InteropUserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.elementHost = New System.Windows.Forms.Integration.ElementHost()
        Me.SuspendLayout()
        '
        'elementHost
        '
        Me.elementHost.BackColor = System.Drawing.Color.Red
        Me.elementHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.elementHost.Location = New System.Drawing.Point(0, 0)
        Me.elementHost.Name = "elementHost"
        Me.elementHost.Size = New System.Drawing.Size(802, 418)
        Me.elementHost.TabIndex = 0
        Me.elementHost.Child = Nothing
        '
        'InteropUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.elementHost)
        Me.Name = "InteropUserControl"
        Me.Size = New System.Drawing.Size(802, 418)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents elementHost As System.Windows.Forms.Integration.ElementHost

End Class
