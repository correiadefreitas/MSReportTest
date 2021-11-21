<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CrystalReportTest1 = New CrystalReportsTest.CrystalReportTest()
        Me.VendasDataSet1 = New CrystalReportsTest.VendasDataSet()
        Me.LINEITEMTableAdapter = New CrystalReportsTest.VendasDataSetTableAdapters.LINEITEMTableAdapter()
        Me.ORDER_DATATableAdapter = New CrystalReportsTest.VendasDataSetTableAdapters.ORDER_DATATableAdapter()
        CType(Me.VendasDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(106, 12)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportTest1
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(800, 490)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'VendasDataSet1
        '
        Me.VendasDataSet1.DataSetName = "VendasDataSet"
        Me.VendasDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LINEITEMTableAdapter
        '
        Me.LINEITEMTableAdapter.ClearBeforeFill = True
        '
        'ORDER_DATATableAdapter
        '
        Me.ORDER_DATATableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 514)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.VendasDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReportTest1 As CrystalReportTest
    Friend WithEvents VendasDataSet1 As VendasDataSet
    Friend WithEvents LINEITEMTableAdapter As VendasDataSetTableAdapters.LINEITEMTableAdapter
    Friend WithEvents ORDER_DATATableAdapter As VendasDataSetTableAdapters.ORDER_DATATableAdapter
End Class
