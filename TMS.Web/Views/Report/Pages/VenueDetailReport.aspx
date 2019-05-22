<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueDetailReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.VenueDetailReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCVenueDetailReport.ascx" TagPrefix="uc1" TagName="UCVenueDetailReport" %>


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
    <uc1:UCVenueDetailReport runat="server" id="UCVenueDetailReport" />
</body>
</html>
