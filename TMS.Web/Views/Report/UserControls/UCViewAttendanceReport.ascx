<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewAttendanceReport.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCViewAttendanceReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
  <link href="../../../Content/bootstrap.css" rel="stylesheet" />
  
<form ID="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpTraineeReport">
    <ContentTemplate>
      
        <fieldset>
            <asp:ValidationSummary HeaderText="Validation errors occured." CssClass="validationsummary"
                runat="server" ID="VsAttendanceReport" ValidationGroup="VgTraineeReport" DisplayMode="BulletList" />
            <p id="ParagraphCourse" runat="server">
                 <div class="row">
      
            <div class="col-md-2">
                 <strong>Course</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="DdlCourse" class="dropdown form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="DdlCourse_SelectedIndexChanged" />
                 </div>
                     </div>
                
            </p>
            <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Class</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="DdlClass" class="dropdown form-control" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"
                        AutoPostBack="true" />
                </div>
                       </div>

                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Dates</strong>
                     
            </div>
            <div class="col-md-2">
                    <asp:Label Text="" ID="LblStartDate"  runat="server"  class="form-control" />
                </div>
                  <div class="col-md-3">
                
                    <asp:Label Text="" ID="LblEndDate"  class="form-control"  runat="server" /></span>
             </div>
                       </div>

                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Week Start Date</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtWeekStartDate" runat="server" type="date"  class="form-control"
                        CausesValidation="false" placeholder="select week start date" OnTextChanged="TxtWeekStartDate_TextChanged"
                        AutoPostBack="true" />
                   
              </div>
                     </div>
            
            <p id="ParagraphEndDate" runat="server"   visible="false">
              <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Week End Date</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox ID="TxtWeekEndDate"  class="form-control" runat="server"  ReadOnly="true"
                        placeholder="week start date" />
                  
              </div>
                       </div>
            </p>
         <div  class="col-md-6 pull-right"  style="margin-top:10px;">
                 <%--  <asp:Button ID="BtnCancel" runat="server" CausesValidation="false" CssClass="Cancel"
                    OnClick="BtnCancel_Click" Text="Cancel" /> --%>
                <asp:Button ID="BtnView" runat="server" CausesValidation="True" OnClick="BtnView_Click"
                    Text="View" ValidationGroup="VgAttendanceReport" class="btn btn-primary" />
            </div>
            <br />      
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="782px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="803px">
                <LocalReport ReportPath="Report\Tran_ViewAttendanceReport.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
            </label>
            </label>
            </label>
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
    </form>