﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerDetailReport.aspx.cs" Inherits="TMS.Web.Views.Report.SpLReports.TrainerDetailReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="col-md-8" style="height: 700px;width: 100%;">
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <rsweb:ReportViewer ID="ReportViewerRSFReports" runat="server"  IsReadyForRendering="false" AsyncRendering="false" ProcessingMode="Remote" Width="797px" ><LocalReport ReportPath="../../../Report/Tran_TrainerDetailReport.rdlc"></LocalReport></rsweb:ReportViewer>
         </div>
    </form>
</body>
</html>
