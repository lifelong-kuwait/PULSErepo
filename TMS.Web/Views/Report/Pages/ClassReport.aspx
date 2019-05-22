<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.ClassReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCClassReport.ascx" TagPrefix="uc1" TagName="UCClassReport" %>


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
    <uc1:UCClassReport runat="server" ID="UCClassReport" />
</body>
</html>
