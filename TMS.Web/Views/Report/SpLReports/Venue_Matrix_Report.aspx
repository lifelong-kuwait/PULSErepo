<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Venue_Matrix_Report.aspx.cs" Inherits="TMS.Web.Views.Report.SpLReports.Venue_Matrix_Report" %>
<%@ Register Src="~/Views/Report/SpLReports/UserControls/UCVenueMatrixReport.ascx" TagPrefix="uc1" TagName="UCVenueMatrixReport" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body><form id="form1" runat="server"> 
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UCVenueMatrixReport runat="server" id="UCVenueMatrixReport" />
 
    </form>
</body>
            
    
</html>
