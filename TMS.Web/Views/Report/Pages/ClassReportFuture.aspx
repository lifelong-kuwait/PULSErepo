<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassReportFuture.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.ClassReportFuture" %>

<%@ Register Src="~/Views/Report/UserControls/UCClassReportFuture.ascx" TagPrefix="uc1" TagName="UCClassReportFuture" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UCClassReportFuture runat="server" id="UCClassReportFuture" />
    </div>
    </form>
</body>
</html>
