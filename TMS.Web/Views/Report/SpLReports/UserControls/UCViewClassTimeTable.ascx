<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewClassTimeTable.ascx.cs" Inherits="TMS.Web.Views.Report.SpLReports.UserControls.UCViewClassTimeTable" %>


<script src="../../../Scripts/jquery-2.1.4.js"></script>
<script src="../../../Scripts/jquery-2.1.4.min.js"></script>
    <link href="../../../Content/bootstrap.css" rel="stylesheet" />
<script src="../../../js/TimetablePopup.js"></script>

<style>
span.ScheduleSessionName {
    color: #fff;
}
</style>

<%--<script type="text/javascript" src="/Scripts/EIS.Training.Scripts/TimetablePopup.js"></script>
<eis:popupwindow runat="server" id="ucPopUpWindow" />--%>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpTimeTable" UpdateMode="Conditional">
    <ContentTemplate>

      
   
        <fieldset>
            <asp:ValidationSummary HeaderText="" CssClass="validationsummary" runat="server"
                ID="vldSummaryDegrees" ValidationGroup="VgTimeTable" DisplayMode="BulletList" />
           
            
           
                 
             <div class="row">
           <div  class="col-md-4 pull-right"  style="margin-top:10px; margin-bottom:10px">
              <asp:LinkButton ID="btnPrint" runat="server" ToolTip="Print" class="btn btn-success"
            OnClientClick="PrintFeedbacks(); return false;">&nbsp;<span title="Timetable">Print</span></asp:LinkButton>
               </div>
                 </div>
            
            <div class="PrintingArea">
                <div class="row">
                <h1 style="margin-left:25%;">Time Table Schedule</h1>
                    
                </div>
                <asp:Label runat="server" ID="LblCourseName" Style="display: none;" />
                <asp:Label runat="server" ID="LblClassName" Style="display: none;" />
                <asp:Label runat="server" ID="LblCalenderSpan" Style="display: none;" />
                <p id="CalendarContainer" runat="server">
                </p>
                <div style="width: 90%; margin-top: 5px; display: inline-block">
                    <asp:Repeater runat="server" ID="rptColors">
                        <ItemTemplate>
                            <div class="ScheduleColorRepeater">
                                <table style="width: 100%">
                                    <tr>
                                        <td style='<%# "border:1px solid #dcdcdc; width: 3%; background:"+Eval("Color")+";" %>'>
                                        </td>
                                        <td style="width: 80%">
                                            <%#Eval("DisplayName") %>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
                
        </fieldset>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
    function PrintFeedbacks() {
        w = window.open();
        w.document.write($('.PrintingArea').html());
        w.print();
        w.close();
    //    try {
    //        debugger
    //    var options = { mode: 'iframe', popClose: true };
    //    jQuery("div.PrintingArea").printArea(options);
    //    } catch (e) {
    //        debugger

    //} 
    }
</script>
