<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassSchedule.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.ClassSchedule" %>

<%@ Register Src="~/Views/Report/UserControls/UCClassReportCurrent.ascx" TagPrefix="uc1" TagName="UCClassReportCurrent" %>








<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UCClassReportCurrent runat="server" ID="UCClassReportCurrent" />
    </div>
    </form>
</body>
</html>
