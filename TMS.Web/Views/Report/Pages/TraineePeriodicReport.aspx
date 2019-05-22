<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TraineePeriodicReport.aspx.cs" Inherits="TMS.Web.Views.Report.Pages.TraineePeriodicReport" %>

<%@ Register Src="~/Views/Report/UserControls/UCTraineePeriodicReport.ascx" TagPrefix="uc1" TagName="UCTraineePeriodicReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UCTraineePeriodicReport runat="server" id="UCTraineePeriodicReport" />
    </div>
    </form>
</body>
</html>
