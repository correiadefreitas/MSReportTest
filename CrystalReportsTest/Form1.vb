Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Debug.Print(Me.ORDER_DATATableAdapter.Adapter.SelectCommand)

        'TODO: This line of code loads data into the 'VendasDataSet1.ORDER_DATA' table. You can move, or remove it, as needed.
        Me.ORDER_DATATableAdapter.Fill(Me.VendasDataSet1.ORDER_DATA, 1)

        'TODO: This line of code loads data into the 'VendasDataSet1.LINEITEM' table. You can move, or remove it, as needed.
        Me.LINEITEMTableAdapter.Fill(Me.VendasDataSet1.LINEITEM)

        Dim rs As CrystalReportTest = CrystalReportViewer1.ReportSource
        rs.SetDataSource(VendasDataSet1)

    End Sub
End Class
