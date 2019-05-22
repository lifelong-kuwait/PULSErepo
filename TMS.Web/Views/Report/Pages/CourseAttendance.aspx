<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAttendance.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.CourseAttendance" %>

<%@ Register Src="~/Views/Report/UserControls/UCViewCourseAttendanceReport.ascx" TagPrefix="uc1" TagName="UCViewCourseAttendanceReport" %>


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
    
    <div>
        <uc1:UCViewCourseAttendanceReport runat="server" ID="UCViewCourseAttendanceReport" />
    </div>

</body>
</html>
