/// <reference path="../../../typings/jquery/jquery.d.ts" />
/// <reference path="../../../typings/sweetalert/sweetalert.d.ts" />
function onChangeCourseCategoryId(e) {
    if (e.sender.value() === "") {
        jQuery("#CourseCategoryCode").text("");
    }
    else {
        jQuery.getJSON(baseurl + 'Program/CourseCategoryCode/' + e.sender.value(), function (data) {
            jQuery("#CourseCategoryCode").text(data);
        });
    }
}
//jQuery(function () {
//    jQuery("#emptysearch").live("mousedown", function (event) {
//        var search = jQuery('#searchBox');
//        if (search.val() !== "") {
//            search.val("");
//            jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
//        }
//    });
//    jQuery("#btnSearch").live("mousedown", function (event) {
//        var searchValue = jQuery('#searchBox').val();
//        if (searchValue !== "") {
//            jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
//        }
//    });
//jQuery("#searchBox").on('keyup', function (e) {
//    if (e.keyCode == 13) {
//       var searchValue = jQuery('#searchBox').val();
//       jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
//    }
//});
//});
function CourseGrid_onEdit(e) {
    //if current model is not new then remove the Name editor
    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-i-check"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-i-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.SaveRecordGeneralButton);
    }
    else {
        // edit
        jQuery("#CourseCategoryCode").prop("disabled", true);
        jQuery("#CourseCode").prop("disabled", true);
        var couCat = e.model.CourseCode;
       // "data-123".replace('data-', '');
        couCat = couCat.replace(e.model.CourseCategoryName,'');
        jQuery("#CourseCategoryCode").text(e.model.CourseCategoryName);
        jQuery("#CourseCode").val(couCat.slice(1)).trigger("change");
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}
function courseAddtionalData() {
    return {
        codeSuffix: jQuery('#CourseCategoryCode').text()
    };
}
function ClassGrid_onEdit(e) {
    //if current model is not new then remove the Name editor
    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    jQuery(cancel).html('<span class="k-icon k-i-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.SaveRecordGeneralButton);
        jQuery("#StartDate").data("kendoDatePicker").value(null);
        jQuery("#EndDate").data("kendoDatePicker").value(null);
    }
    else {
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery("#courseddl").remove();
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}
function onChangeCourseId(e) {
    if (e.sender.value() === "") {
        jQuery("#CourseCategoryCode").text("");
    }
    else {
        jQuery.getJSON(baseurl + 'Program/CourseDetailById/' + e.sender.value(), function (data) {
            if (data.CourseCode == undefined) {
                jQuery("#ClassName").val("").trigger("change");
            }
            else {
                jQuery("#ClassName").val(data.CourseCode).trigger("change");
            }
            if (data.CourseDurationType == undefined) {
                var FeeCurrency = jQuery("#ClassDurationType").data('kendoDropDownList');
                FeeCurrency.value("0");
                FeeCurrency.trigger("change");
            }
            else {
                var ClassDurationType = jQuery("#ClassDurationType").data('kendoDropDownList');
                ClassDurationType.value(data.CourseDurationType);
                ClassDurationType.trigger("change");
            }
            if (data.CourseDuration == undefined) {
                jQuery("#ClassDuration").val("").trigger("change");
            }
            else {
                jQuery("#ClassDuration").val(data.CourseDuration).trigger("change");
            }
            if (data.MinimumAttendanceRequirement == undefined) {
                jQuery("#MinimumAttendanceRequirement").val("").trigger("change");
            }
            else {
                jQuery("#MinimumAttendanceRequirement").val(data.MinimumAttendanceRequirement).trigger("change");
            }
            if (data.MinimumTrainee == undefined) {
                jQuery("#MinimumTrainee").val("").trigger("change");
            }
            else {
                jQuery("#MinimumTrainee").val(data.MinimumTrainee).trigger("change");
            }
            if (data.CourseFee == undefined) {
                jQuery("#ClassFee").val("").trigger("change");
            }
            else {
                // var ClassFee = jQuery("#ClassFee").data('kendoDropDownList'); ClassFee.value(data.CourseFee); ClassFee.trigger("change");
                jQuery("#ClassFee").val(data.CourseFee).trigger("change");
            }
            if (data.FeeCurrency == undefined) {
                var FeeCurrency = jQuery("#FeeCurrency").data('kendoDropDownList');
                FeeCurrency.value("0");
                FeeCurrency.trigger("change");
            }
            else {
                var FeeCurrency = jQuery("#FeeCurrency").data('kendoDropDownList');
                FeeCurrency.value(data.FeeCurrency);
                FeeCurrency.trigger("change");
            }
        });
    }
}
function onChangeClassId(e) {
    if (e.sender.value() === "") {
        jQuery("#SessionName").text("");
    }
    else {
        jQuery.getJSON(baseurl + 'Program/ClassDetailById/?id=' + e.sender.value() + '&sid=' + jQuery("#SessionID").val(), function (data) {
            if (!data.IsLastSessionExist && !data.MinTraineeNotAdded) {
                updateSessionSettings(data);
            }
            else { //CannotProceed
                if (data.IsLastSessionExist) {
                    swal({
                        title: lr.CannotProceed,
                        text: lr.SessionIsLastAlreadyExist,
                        type: "warning",
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: lr.ButtonOk,
                        closeOnConfirm: true,
                        customClass: "tmsconfirm border2pxsilid",
                    }, function (isConfirm) {
                        if (isConfirm) {
                            window.location.reload();
                        }
                        else {
                            window.location.reload();
                        }
                    });
                    //
                }
                else if (data.MinTraineeNotAdded) {
                    //
                    swal({
                        title: lr.CannotProceed,
                        text: lr.SessionClassMinimumTraineesNotAdded,
                        type: "warning",
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: lr.ButtonOk,
                        closeOnConfirm: true,
                        customClass: "tmsconfirm border2pxsilid",
                    }, function (isConfirm) {
                        if (isConfirm) {
                            window.location.reload();
                        }
                        else {
                            window.location.reload();
                        }
                    });
                }
            }
        });
    }
}
function updateSessionSettings(data) {
    if (data.ClassName == undefined) {
        jQuery("#SessionName").val("").trigger("change");
    }
    else {
        jQuery("#SessionName").val(data.ClassName).trigger("change");
    }
    if (data.StartTimeString == undefined) {
        var StartTimeString = jQuery("#StartTimeString").data('kendoDropDownList');
        StartTimeString.value("0");
        StartTimeString.trigger("change");
    }
    else {
        var StartTimeString = jQuery("#StartTimeString").data('kendoDropDownList');
        StartTimeString.value(data.StartTimeString);
        StartTimeString.trigger("change");
    }
    if (data.EndTimeString == undefined) {
        var EndTimeString = jQuery("#EndTimeString").data('kendoDropDownList');
        EndTimeString.value("0");
        EndTimeString.trigger("change");
    }
    else {
        var EndTimeString = jQuery("#EndTimeString").data('kendoDropDownList');
        EndTimeString.value(data.EndTimeString);
        EndTimeString.trigger("change");
    }
}
function SessionGrid_onEdit(e) {
    //if current model is not new then remove the Name editor
    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    jQuery(cancel).html('<span class="k-icon k-i-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.SaveRecordGeneralButton);
        jQuery("#ScheduleDate").data("kendoDatePicker").value(null);
        setTimeout(function () {
            jQuery(".k-widget.k-tooltip.k-tooltip-validation.k-invalid-msg.field-validation-error").hide();
        }, 100);
    }
    else {
        //jQuery("#classdll").remove();
        var dropdownlist = jQuery("#ClassID").data("kendoDropDownList");
        dropdownlist.enable(false);
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}
function SessionGrid_onEdit(e) {
    if (e.model.isNew()) {
        jQuery('.scheduleDateHide').hide();
        jQuery('.calendarSession').show();
        //console.log("new")
        
    }
    else {
        jQuery('.scheduleDateHide').show();
        jQuery('.calendarSession').hide();
       // console.log("Old")


    }
}
function JobsRequiredGrid_onEdit(e) {
    if (e.model.isNew()) {
        jQuery('#personeditdiv').hide();        
        console.log("new")
    }
    else {
        jQuery('#personeditdiv').show();        
        console.log("Old")
    }
}
/*

*/
