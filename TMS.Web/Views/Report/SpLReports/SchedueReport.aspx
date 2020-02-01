<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchedueReport.aspx.cs" Inherits="TMS.Web.Views.Report.SpLReports.SchedueReport" %>

<%@ Register Src="~/Views/Report/SpLReports/UserControls/UCViewClassTimeTable.ascx" TagPrefix="uc1" TagName="UCViewClassTimeTable" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="col-md-5" style="height: 700px;width: 120%;">
           
            <uc1:UCViewClassTimeTable runat="server" ID="UCViewClassTimeTable" />
        </div>
    </form>
</body>
</html>
