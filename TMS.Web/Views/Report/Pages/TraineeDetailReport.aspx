<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraineeDetailReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.TraineeDetailReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCTraineeDetailReport.ascx" TagPrefix="uc1" TagName="UCTraineeDetailReport" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <%--  <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../../../Content/bootstrap.css" rel="stylesheet" />
    <style>
        .form-group{
            display:grid;
        }
    </style>
  <%--  <style>
        div#classd {
    margin-left: -513px;
}
        .col-lg-7.col-md-7 {
    margin-top: 18px;
}
        /*ul {
    display: none;
}*/
        div#reports {
    margin-top: 43px;
}
        .col-lg-1 {
    margin-top: 20px;
}
        .col-lg-7 {
    margin-top: 24px;
}
    </style>--%>
</head>
<body>
    <uc1:UCTraineeDetailReport runat="server" id="UCTraineeDetailReport" />
</body>
</html>
