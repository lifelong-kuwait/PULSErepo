function PersonGrid_onEdit(e) {
    //if current model is not new then remove the Name editor

    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-i-check"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-i-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery("#personeditdiv").hide();
        //jQuery("#country_Code").hide();
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.SaveRecordGeneralButton);

    } else {
        // edit
        jQuery("#personeditdiv").show();
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
   //var dropdownlistNationality = jQuery("#Nationality").data('kendoDropDownList'); dropdownlistNationality.value("83"); dropdownlistNationality.trigger("change");
    PicturelastUploadedFile = null;

}

function Person_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    })
}



function PersonEducationRequestEnd(e) { if (e.type=="update") { this.read(); } if (e.type=="create") { this.read(); } }
//Special Function Editing For the WorkExperince
function PersonWEducationWorkExperienceGrid_onEdit(e) {
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
        jQuery("#EndTimePeriod").data("kendoDatePicker").value(null);
        jQuery("#StartTimePeriod").data("kendoDatePicker").value(null);

    } else {
        // edit
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }

}
