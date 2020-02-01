<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursePeriodicReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.CoursePeriodicReport" %>
<%@ Register Src="~/Views/Report/SpLReports/UserControls/VenueMatrixUserControl.ascx" TagPrefix="uc1" TagName="VenueMatrixUserControl" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="col-md-5" style="height: 700px;width:800px;">
          <uc1:VenueMatrixUserControl runat="server" id="VenueMatrixUserControl" />
    </div>
    </form>
</body>
</html>
