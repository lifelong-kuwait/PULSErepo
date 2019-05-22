/// <reference path="../../../typings/jquery/jquery.d.ts" />
/// <reference path="../../../typings/kendo-ui/kendo-ui.d.ts" />
"use strict";

function onChangeCourseCategoryId(e) {
    if (e.sender.value() === "") {
        jQuery("#CourseCategoryCode").text("");
    } else {
        jQuery.getJSON(baseurl + 'Program/CourseCategoryCode/' + e.sender.value(), function (data) {
            jQuery("#CourseCategoryCode").text(data);
        });
    }
}
jQuery(function () {
    jQuery("#emptysearch").live("mousedown", function (event) {
        var search = jQuery('#searchBox');
        if (search.val() !== "") {
            search.val("");
            jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
        }
    });
    jQuery("#btnSearch").live("mousedown", function (event) {
        var searchValue = jQuery('#searchBox').val();
        if (searchValue !== "") {
            jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
        }
    });
    jQuery("#searchBox").on('keyup', function (e) {
        if (e.keyCode == 13) {
            var searchValue = jQuery('#searchBox').val();
            jQuery("#CourseGrid").data("kendoGrid").dataSource.filter({});
        }
    });
});
function CourseTemplate(data) {
    if (data !== null) {
        var CourseTemplate = kendo.template(jQuery("#CourseTemplate").html(), { useWithBlock: false });
        return CourseTemplate(data);
    }
    return '';
}
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
    } else {
        // edit
        jQuery("#CourseCategoryCode").text(e.model.CourseCode.split("-")[0]);
        jQuery("#CourseCode").val(e.model.CourseCode.split("-")[1]).trigger("change");
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}
function couserAddtionalData() {
    return {
        codeSuffix: jQuery('#CourseCategoryCode').text()
    };
}
function withSearch() {
    return {
        SearchText: jQuery('#searchBox').val()
    };
}
//Class
function ClassTemplate(data) {
    if (data !== null) {
        var ClassTemplate = kendo.template(jQuery("#ClassTemplate").html(), { useWithBlock: false });
        return ClassTemplate(data);
    }
    return '';
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
        jQuery("#StartDate").data("kendoDateTimePicker").value(null);
        jQuery("#EndDate").data("kendoDateTimePicker").value(null);
    } else {
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}
function onChangeCourseId(e) {
    if (e.sender.value() === "") {
        jQuery("#CourseCategoryCode").text("");
    } else {
        jQuery.getJSON(baseurl + 'Program/CourseCategoryCode/' + e.sender.value(), function (data) {
            jQuery("#CourseCategoryCode").text(data);
        });
    }
}
/*

*/
/**
 * return text by value
 * @param {int}value
 * @param objenum
 */
function enumvalue(value, objenum) {
    var arr = jQuery.grep(objenum, function (n, i) {
        return n.Value === value ? n.Text : "";
    });
    return arr.length ? arr[0].Text : "";
}

