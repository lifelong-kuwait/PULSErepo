<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueDetailUtilizationReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.VenueDetailUtilizationReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCVenueDetailUtilizationReport.ascx" TagPrefix="uc1" TagName="UCVenueDetailUtilizationReport" %>


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
    <uc1:UCVenueDetailUtilizationReport runat="server" id="UCVenueDetailUtilizationReport" />
        </form>
</body>
</html>
