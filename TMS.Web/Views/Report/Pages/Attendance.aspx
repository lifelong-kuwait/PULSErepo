<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.Attendance" %>

<%@ Register Src="~/Views/Report/UserControls/UCViewAttendanceReport.ascx" TagPrefix="uc1" TagName="UCViewAttendanceReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 
    <div>
        <uc1:UCViewAttendanceReport runat="server" ID="UCViewAttendanceReport" />
    </div>

</body>
</html>
