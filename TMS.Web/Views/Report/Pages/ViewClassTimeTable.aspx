<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewClassTimeTable.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.ViewClassTimeTable" %>

<%@ Register Src="~/Views/Report/UserControls/UCViewClassTimeTable.ascx" TagPrefix="uc1" TagName="UCViewClassTimeTable" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UCViewClassTimeTable runat="server" ID="UCViewClassTimeTable" />
    </div>
    </form>
</body>
</html>
