<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueDailyUtilizationReport.aspx.cs" Inherits="TMS.Web.Views.Report.SpLReports.VenueDailyUtilizationReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
       <div class="col-md-5" style="height: 700px;width: 1000px;">
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <rsweb:ReportViewer ID="ReportViewerRSFReports" runat="server"  IsReadyForRendering="false" AsyncRendering="false" ProcessingMode="Remote" Width="797px" ><LocalReport ReportPath="../../../Report/DailyUtilizationReport.rdlc"></LocalReport></rsweb:ReportViewer>
         </div>
    </form>
</body>
</html>
