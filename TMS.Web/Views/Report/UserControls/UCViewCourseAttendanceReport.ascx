<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewCourseAttendanceReport.ascx.cs" Inherits="TMS.Web.Views.Report.User_Controls.UCViewCourseAttendanceReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

 <form id="form1" runat="server">
    <div>
  <asp:UpdatePanel runat="server" ID="UpTraineeReport" UpdateMode="Conditional">
    <ContentTemplate>
            <p>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <div class="row">
      
            <div class="col-md-1">
                 <strong>Course</strong>
                     
            </div>
            <div class="col-md-5">
                    <asp:DropDownList runat="server" ID="DdlCourse" class="dropdown form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="DdlCourse_SelectedIndexChanged" />
                     </div>
            
        </div>
                 <div class="row" style="margin-top:10px">
      
            <div class="col-md-1">
                 <strong>Class</strong>
                     
            </div>
            <div class="col-md-5">

                    <asp:DropDownList runat="server" ID="DdlClass" class="dropdown form-control" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"
                        AutoPostBack="True" />
             </div>
                       </div>
        
          <div class="row" style="margin-top:20px;" >
            <div class="col-lg-7" id="reports">    
         
           <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="829px" Height="970px">
                <LocalReport ReportPath="Report\Tran_ViewCourseAttendanceReport.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>

                 </div>
              </div>
         </ContentTemplate>
</asp:UpdatePanel>
       
       
       
    </div>
    </form>
