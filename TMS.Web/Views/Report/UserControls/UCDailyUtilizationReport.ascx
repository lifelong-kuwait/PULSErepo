<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDailyUtilizationReport.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCDailyUtilizationReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
   <link href="../../../Content/bootstrap.css" rel="stylesheet" />

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpTraineeReport" UpdateMode="Conditional">
    <ContentTemplate>
      
        <fieldset>
            <asp:ValidationSummary HeaderText="Validation errors occured." CssClass="validationsummary"
                runat="server" ID="VsClassDetailReport" ValidationGroup="VgTraineeReport" DisplayMode="BulletList" />
            <p id="P1" runat="server">
                   <div class="row">
      
            <div class="col-md-2">
                 <strong>Venue Type</strong>
                     
            </div>
            <div class="col-md-5">
               
                    <asp:DropDownList runat="server" ID="ddlVenueType"  
                       class="form-control">
                        <asp:ListItem Text="Select Venue Type" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Common" Value="1"></asp:ListItem>
                        <asp:ListItem Text="All Utilized" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                   
              </div>
                       </div>
                </p>
          
                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Select Date</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtStartDate" runat="server" autocomplete="off"  type="date"  class="form-control"
                        placeholder="select start date" />
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
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>