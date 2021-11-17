<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebAppReportTest._Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Parametros</h2>
            <table>
                <tr>
                    <td>Encomenda nº</td>
                    <td><asp:DropDownList ID="ComboBox1" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Ver detalhe</td>
                    <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                </tr>
                <tr>
                    <td>Texto adicional</td>
                    <td><asp:TextBox ID="TextBox1" runat="server" style="width:100%;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Aplicar" /></td>
                </tr>
            </table>
        </div>
        <div class="col-md-8">
            <h2>Report</h2>
            <p>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" ClientIDMode="AutoID" Width="100%">
                    <LocalReport ReportPath="ReportTeste.rdlc" ShowDetailedSubreportMessages="True">
                    </LocalReport>
            </rsweb:ReportViewer>
            </p>
        </div>
    </div>
    
</asp:Content>
