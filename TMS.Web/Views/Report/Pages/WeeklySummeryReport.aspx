<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeeklySummeryReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.WeeklySummeryReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCWeeklyUtilizationReport.ascx" TagPrefix="uc1" TagName="UCWeeklyUtilizationReport" %>


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
 <form runat="server" id="form1">
    <uc1:UCWeeklyUtilizationReport runat="server" id="UCWeeklyUtilizationReport" />
     </form>
</body>
</html>
