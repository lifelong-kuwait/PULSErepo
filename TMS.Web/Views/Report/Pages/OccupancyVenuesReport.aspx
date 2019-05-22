<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OccupancyVenuesReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.OccupancyVenuesReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCOccupancyVenueReport.ascx" TagPrefix="uc1" TagName="UCOccupancyVenueReport" %>


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
    <uc1:UCOccupancyVenueReport runat="server" id="UCOccupancyVenueReport" />
</body>
</html>
