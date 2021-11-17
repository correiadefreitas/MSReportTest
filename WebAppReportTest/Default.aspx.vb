Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms

Public Class _Default
    Inherits Page

    Public Property ORDER_DATATableAdapter1 As VendasDataSetTableAdapters.ORDER_DATATableAdapter
    Public Property LINEITEMTableAdapter1 As VendasDataSetTableAdapters.LINEITEMTableAdapter

    Public Property NumeroEncomenda() As Integer = 1
    Public Property VerDetalhe() As Boolean
    Public Property TextoAdicional() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim VendasDataSet1 = New VendasDataSet()
        ORDER_DATATableAdapter1 = New VendasDataSetTableAdapters.ORDER_DATATableAdapter()
        LINEITEMTableAdapter1 = New VendasDataSetTableAdapters.LINEITEMTableAdapter()

        ORDER_DATATableAdapter1.Fill(VendasDataSet1.ORDER_DATA)
        LINEITEMTableAdapter1.Fill(VendasDataSet1.LINEITEM)

        If Not IsPostBack Then
            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc")



            ComboBox1.DataSource = VendasDataSet1
            ComboBox1.DataMember = "ORDER_DATA"
            ComboBox1.DataTextField = "ORDERID"
            ComboBox1.DataValueField = "ORDERID"
            ComboBox1.DataBind()

            AtualizarRelatorio()

        End If


        'LINEITEMTableAdapter1.Fill(Me.VendasDataSet1.LINEITEM)


    End Sub

    Private Sub AtualizarRelatorio()

        ReportViewer1.Visible = False
        ReportViewer1.LocalReport.DataSources.Clear()

        Debug.Print(ComboBox1.SelectedValue)
        Debug.Print(ORDER_DATATableAdapter1.GetData().Rows.Count())

        Dim dtOrderData As DataTable = Me.ORDER_DATATableAdapter1.GetData().Where(Function(x) x.ORDERID = NumeroEncomenda).CopyToDataTable()
        dtOrderData.TableName = "DadosEncomenda"

        Dim dtLineItem = Me.LINEITEMTableAdapter1.GetData().Where(Function(x) x.ORDERID = NumeroEncomenda).CopyToDataTable()
        dtLineItem.TableName = "DetalheEncomenda"


        Dim rdsOrderData = New ReportDataSource("DadosEncomenda", dtOrderData)
        Dim rdsLineItem = New ReportDataSource("DetalheEncomenda", dtLineItem)

        ReportViewer1.LocalReport.DataSources.Add(rdsOrderData)
        ReportViewer1.LocalReport.DataSources.Add(rdsLineItem)

        Dim reportParameters = New List(Of ReportParameter)

        reportParameters.Add(New ReportParameter("MostrarDetalhe", VerDetalhe))
        reportParameters.Add(New ReportParameter("TextoAdicional", TextoAdicional))

        ReportViewer1.LocalReport.SetParameters(reportParameters)

        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf ProcessarSubReport

        ReportViewer1.DataBind()
        ReportViewer1.LocalReport.Refresh()
        'ReportViewer1.RefreshReport()
        'Application.DoEvents()
        ReportViewer1.Visible = True
    End Sub

    Private Sub ProcessarSubReport(sender As Object, e As SubreportProcessingEventArgs)

        e.DataSources.Clear()

        Dim dt As DataTable = LINEITEMTableAdapter1.GetData().Where(Function(x) x.ORDERID = NumeroEncomenda).CopyToDataTable()
        dt.TableName = "DetalheEncomenda"
        Dim rds = New ReportDataSource("DetalheEncomenda", dt)

        e.DataSources.Add(rds)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Integer.TryParse(ComboBox1.SelectedValue, NumeroEncomenda) Then
            NumeroEncomenda = 1
        End If
        VerDetalhe = CheckBox1.Checked
        TextoAdicional = TextBox1.Text
        AtualizarRelatorio()
    End Sub

End Class