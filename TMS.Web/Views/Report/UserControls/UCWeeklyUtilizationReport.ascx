<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWeeklyUtilizationReport.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCWeeklyUtilizationReport" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <link href="../../../Content/bootstrap.css" rel="stylesheet" />
<asp:UpdatePanel runat="server" ID="UpTraineeReport" UpdateMode="Conditional">
    <ContentTemplate>
       
       
        <fieldset>
            <asp:ValidationSummary HeaderText="Validation errors occured." CssClass="validationsummary"
                runat="server" ID="VsClassDetailReport" ValidationGroup="VgTraineeReport" DisplayMode="BulletList" />
                       <div class="row">
      
            <div class="col-md-2">
                 <strong>Venue</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="ddlVenue" class="form-control" />
                       
               </div>
            
        </div>
         
                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Start Date</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtStartDate" runat="server" autocomplete="off" type="date"  class="form-control"
                        placeholder="select start date" />
                  
                 </div>
            
        </div>
         
                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>End Date</strong>
                     
            </div>
            <div class="col-md-5">

                    <asp:TextBox ID="TxtEndDate" runat="server"  autocomplete="off" type="date"  class="form-control"></asp:TextBox>
                    </div>
                     </div>
            <div class="row">
           <div  class="col-md-6 pull-right"  style="margin-top:10px;">
                <asp:Button ID="BtnView" runat="server" CausesValidation="True" OnClick="BtnView_OnClick"
                    Text="View" ValidationGroup="VgAttendanceReport" class="btn btn-primary" />
            </div>
                </div>
               <fieldset class="RDLCReport">
                <rsweb:ReportViewer ID="ReportViewerMasterReport" runat="server" Width="100%" Height="100%" 
                    Style="border: 1px solid #dcdcdc; margin-bottom: 2px;" SizeToReportContent="True"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" AsyncRendering="True" CssClass="MaxTable" ShowRefreshButton="False" ShowZoomControl="False">
                </rsweb:ReportViewer>
                <iframe id="frmPrint" name="IframeName" width="0" height="0" runat="server"></iframe>
            </fieldset>
    </ContentTemplate>
  
</asp:UpdatePanel>