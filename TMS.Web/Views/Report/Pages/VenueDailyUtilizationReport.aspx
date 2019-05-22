<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueDailyUtilizationReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.VenueDailyUtilizationReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCDailyUtilizationReport.ascx" TagPrefix="uc1" TagName="UCDailyUtilizationReport" %>



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
    <form ID="form1" runat="server">
    <uc1:UCDailyUtilizationReport runat="server" id="UCDailyUtilizationReport" />
        </form>
</body>
</html>
