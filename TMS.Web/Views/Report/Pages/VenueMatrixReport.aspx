<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueMatrixReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.VenueMatrixReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCVenueMatrixReport.ascx" TagPrefix="uc1" TagName="UCVenueMatrixReport" %>


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
<form id="form1" runat="server"> 
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <uc1:UCVenueMatrixReport runat="server" id="UCVenueMatrixReport" />
    </form>
</body>
</html>
