<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTrainerDetailReport.ascx.cs" Inherits="TMS.Web.Views.Report.User_Controls.UCTrainerDetailReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="607px">
    <LocalReport ReportPath="Report\Tran_TrainerDetailReport.rdlc">
    </LocalReport>
</rsweb:ReportViewer>

