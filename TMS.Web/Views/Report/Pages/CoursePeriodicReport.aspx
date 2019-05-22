<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursePeriodicReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.CoursePeriodicReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCCoursePeriodicReport.ascx" TagPrefix="uc1" TagName="UCCoursePeriodicReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UCCoursePeriodicReport runat="server" ID="UCCoursePeriodicReport" />
    </div>
    </form>
</body>
</html>
