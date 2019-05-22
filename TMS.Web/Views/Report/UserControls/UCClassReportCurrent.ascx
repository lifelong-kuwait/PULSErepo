<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCClassReportCurrent.ascx.cs" Inherits="TMS.Web.Views.Report.UserControls.UCClassReportCurrent" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

   <link href="../../../Content/bootstrap.css" rel="stylesheet" />

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


<asp:UpdatePanel runat="server" ID="UpTraineeReport" UpdateMode="Always">
    <ContentTemplate>
     
        <fieldset>
            <asp:ValidationSummary HeaderText="Validation errors occured." CssClass="validationsummary"
                runat="server" ID="VsClassDetailReport" ValidationGroup="VgTraineeReport" DisplayMode="BulletList" />
             <div class="row">
             <div class="col-md-2">
                 <strong>Date From</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox runat="server" ID="TxtFromYear" AutoPostBack="True"  type="date"  class="form-control"
                        OnTextChanged="TxtFromYear_OnTextChanged" />
                 </div>
            </div>
           <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Add Month</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="DdlAddMonths" AutoPostBack="True" OnSelectedIndexChanged="DdlAddMonts_SelectedIndexChanged"
                       class="form-control">
                        <asp:ListItem Value="3" Text="3" />
                        <asp:ListItem Value="6" Text="6" />
                        <asp:ListItem Value="9" Text="9" />
                        <asp:ListItem Value="12" Text="12" />
                    </asp:DropDownList>
               </div>
                       </div>
               <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Date To</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:TextBox runat="server" ID="TxtToYear" AutoPostBack="True" type="date"  class="form-control"
                        OnTextChanged="TxtToYear_OnTextChanged" />
                     </div>
                     </div>
                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-2">
                 <strong>Course Category</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="DdlCourseCategory" class="form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="DdlCourseCategory_SelectedIndexChanged" />
                    <br />
                   </div>
                    </div>
            <div class="row">
            <div class="col-md-7">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Width="800px" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="994px">
                <LocalReport ReportPath="Report\Tran_ClassReport.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
                </div></div>
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
