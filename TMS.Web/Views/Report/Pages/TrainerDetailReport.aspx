<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerDetailReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.TrainerDetailReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Views/Shared/UCTrainerDetailsReport.ascx" TagPrefix="uc1" TagName="UCTrainerDetailsReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../../../Content/bootstrap.css" rel="stylesheet" />
    <style>
        .form-group{
            display:grid;
        }
    </style>
</head>
<body>
   <%-- <form id="form1" runat="server">--%>
    <div>
        <uc1:UCTrainerDetailsReport runat="server" ID="UCTrainerDetailsReport" />

       
       
    </div>
  <%--  </form>--%>
</body>
</html>
