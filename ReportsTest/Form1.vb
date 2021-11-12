Imports Microsoft.Reporting.WinForms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ORDER_DATATableAdapter1.Fill(Me.VendasDataSet1.ORDER_DATA)
        Me.LINEITEMTableAdapter1.Fill(Me.VendasDataSet1.LINEITEM)

        AtualizarRelatorio()
    End Sub

    Private Sub AtualizarRelatorio()

        ReportViewer1.Visible = False
        ReportViewer1.LocalReport.DataSources.Clear()




        Console.WriteLine(DirectCast(ComboBox1.SelectedValue, Integer))
        Console.WriteLine(Me.ORDER_DATATableAdapter1.GetData().Rows.Count())


        Dim dtOrderData As DataTable = Me.ORDER_DATATableAdapter1.GetData().Where(Function(x) x.ORDERID = DirectCast(ComboBox1.SelectedValue, Integer)).CopyToDataTable()
        dtOrderData.TableName = "DadosEncomenda"

        Dim dtLineItem = Me.LINEITEMTableAdapter1.GetData().Where(Function(x) x.ORDERID = DirectCast(ComboBox1.SelectedValue, Integer)).CopyToDataTable()
        dtLineItem.TableName = "DetalheEncomenda"


        Dim rdsOrderData = New ReportDataSource("DadosEncomenda", dtOrderData)
        Dim rdsLineItem = New ReportDataSource("DetalheEncomenda", dtLineItem)

        Me.ReportViewer1.LocalReport.DataSources.Add(rdsOrderData)
        Me.ReportViewer1.LocalReport.DataSources.Add(rdsLineItem)

        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf ProcessarSubReport

        Me.ReportViewer1.RefreshReport()
        ReportViewer1.Visible = True
    End Sub

    Private Sub ProcessarSubReport(sender As Object, e As SubreportProcessingEventArgs)

        e.DataSources.Clear()

        Dim dt As DataTable = Me.LINEITEMTableAdapter1.GetData()
        dt.TableName = "DetalheEncomenda"
        Dim rds = New ReportDataSource("DetalheEncomenda", dt)

        e.DataSources.Add(rds)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AtualizarRelatorio()
    End Sub
End Class
