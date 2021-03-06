Imports Microsoft.Reporting.WinForms

Public Class Form1

    Private _NumeroEncomenda As Integer = 1
    Public Property NumeroEncomenda() As Integer
        Get
            Return _NumeroEncomenda
        End Get
        Set(ByVal value As Integer)
            _NumeroEncomenda = value
        End Set
    End Property

    Private _VerDetalhe As Boolean
    Public Property VerDetalhe() As Boolean
        Get
            Return _VerDetalhe
        End Get
        Set(ByVal value As Boolean)
            _VerDetalhe = value
        End Set
    End Property

    Private _TextoAdicional As String
    Public Property TextoAdicional() As String
        Get
            Return _TextoAdicional
        End Get
        Set(ByVal value As String)
            _TextoAdicional = value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ORDER_DATATableAdapter1.Fill(Me.VendasDataSet1.ORDER_DATA)
        'LINEITEMTableAdapter1.Fill(Me.VendasDataSet1.LINEITEM)

        AtualizarRelatorio()
    End Sub

    Private Sub AtualizarRelatorio()

        ReportViewer1.Visible = False
        ReportViewer1.LocalReport.DataSources.Clear()

        Console.WriteLine(DirectCast(ComboBox1.SelectedValue, Integer))
        Console.WriteLine(Me.ORDER_DATATableAdapter1.GetData().Rows.Count())


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

        'ReportViewer1.DataBind()
        'ReportViewer1.LocalReport.Refresh()
        ReportViewer1.RefreshReport()
        Application.DoEvents()
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
        NumeroEncomenda = ComboBox1.SelectedValue
        VerDetalhe = CheckBox1.Checked
        TextoAdicional = TextBox1.Text
        AtualizarRelatorio()
    End Sub

End Class
