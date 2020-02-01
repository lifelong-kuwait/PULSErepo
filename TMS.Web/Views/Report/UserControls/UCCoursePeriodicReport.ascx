<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCoursePeriodicReport.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCCoursePeriodicReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<link href="../../../Content/bootstrap.css" rel="stylesheet" />
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpTraineeReport" UpdateMode="Conditional">
    <contenttemplate>
       
        <fieldset>
            <asp:ValidationSummary HeaderText="Validation errors occured." CssClass="validationsummary"
                runat="server" ID="vldSummaryDegrees" ValidationGroup="VgTraineeReport" DisplayMode="BulletList" />
              <div class="row">
      
            <div class="col-md-2">
                 <strong>Start Date</strong>
                   
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtStartDate" runat="server" type="date"  class="form-control" CausesValidation="false"
                        placeholder="select week start date" />
                </div>
                       </div>
              <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>End Date</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtEndDate" runat="server" type="date"  class="form-control" CausesValidation="false" AutoPostBack="True"
                    OnTextChanged="TxtEndDate_OnTextChanged"
                        placeholder="select week end date" />
                  
                </div>
                     </div>
             <p runat="server" id="ParagraphCourse">
                     <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Class</strong>
                     
            </div>
            <div class="col-md-5">
                        <asp:DropDownList ID="DdlCourseID" runat="server" class="form-control" AutoPostBack="False"/>
                         
                    </div>
                         </div>
                </p>
           
             <div class="row">
           <div  class="col-md-6 pull-right"  style="margin-top:10px;">
              
                <asp:Button ID="BtnView" runat="server" CausesValidation="True" OnClick="BtnView_Click"
                    Text="View" ValidationGroup="VgAttendanceReport" class="btn btn-primary" />
            </div>
                  </div>
                 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="800px" Height="800px"></rsweb:ReportViewer>
        </fieldset>
    </contenttemplate>
</asp:UpdatePanel>