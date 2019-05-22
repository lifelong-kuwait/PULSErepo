function RawPersonGrid_onEdit(e) {
    //if current model is not new then remove the Name editor

    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-update"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.SaveRecordGeneralButton);

    } else {
        // edit
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.UpdateRecordGeneralButton);
    }
    var dropdownlistNationality = jQuery("#Nationality").data('kendoDropDownList'); dropdownlistNationality.value("83"); dropdownlistNationality.trigger("change");
    PicturelastUploadedFile = null;

}

function RawPerson_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    })
}
RawPersonGrid_Error = function (args) {

    if (args.errors) {
       // var grid = jQuery("#RawPersonGrid").data("kendoGrid");
        var grid = $(args).data("kendoGrid");
        grid.editable.element.find(".errors").html('');
        var validationTemplate = kendo.template(jQuery("#RawPersonGridErrorTemplate").html());
        grid.one("dataBinding", function (e) {
            e.preventDefault();
            jQuery.each(args.errors, function (propertyName) {
                var renderedTemplate = validationTemplate({ field: propertyName, messages: this.errors });
                grid.editable.element.find(".errors").append(renderedTemplate);
                grid.editable.element.find(".Alertbox").show();
            });
        });
    }
};
function GeneralErrorHandlerPerson(gridName) {
    return function (args) {
        if (args.errors) {
            var grid = jQuery("#" + gridName).data("kendoGrid");
            grid.editable.element.find(".errors").html('');
            var validationTemplate = kendo.template(jQuery("#PersonEducationErrorTemplate").html());
            grid.one("dataBinding", function (e) {
                e.preventDefault();
                jQuery.each(args.errors, function (propertyName) {
                    var renderedTemplate = validationTemplate({ field: propertyName, messages: this.errors });
                    grid.editable.element.find(".errors").append(renderedTemplate);
                    grid.editable.element.find(".Alertbox").show();
                });
            });
        } else if (args.status== "error") {
            abp.notify.error(lr.ResourceUpdateValidationError, lr.ErrorServerError);
        }
    }
}


function GeneralPersonGrid_onEdit(e) {
    //if current model is not new then remove the Name editor

    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-update"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.SaveRecordGeneralButton);


    } else {
        // edit
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}

function GeneralPersonGrid_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function (e) {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    })
}

function PersonChildGrid_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
        //this.read();
    })
}


function PersonEducationRequestEnd(e) { if (e.update) { this.read(); } if (e.create) { this.read(); } }
//Special Function Editing For the WorkExperince
function PersonWEducationWorkExperienceGrid_onEdit(e) {
    //if current model is not new then remove the Name editor

    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-update"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.SaveRecordGeneralButton);
        jQuery("#EndTimePeriod").data("kendoDatePicker").value(null);
        jQuery("#StartTimePeriod").data("kendoDatePicker").value(null);

    } else {
        // edit
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.UpdateRecordGeneralButton);
    }

}

//Special Function Editing For the WorkExperince
function PersonWEducationPersonAchievementsGrid_onEdit(e) {
    //if current model is not new then remove the Name editor

    var title = jQuery(e.container).parent().find(".k-window-title");
    var update = jQuery(e.container).parent().find(".k-grid-update");
    var cancel = jQuery(e.container).parent().find(".k-grid-cancel");
    //jQuery('<a class="k-button k-button-icontext k-grid-update custom" href="\\#"><span class="k-icon k-update"></span>Save & New</a>').insertBefore(".k-grid-update");
    jQuery(cancel).html('<span class="k-icon k-cancel"></span>' + lr.CencelRecordGeneralButton);
    if (e.model.isNew()) {
        // add
        jQuery(title).text(lr.AddRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.SaveRecordGeneralButton);
        jQuery("#AnnouncedDate").data("kendoDatePicker").value(null);

    } else {
        // edit
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-update"></span>' + lr.UpdateRecordGeneralButton);
    }

}
function PersonContactRequestEnd(e) {
    if (e.response.Errors == null) {
        if (e.type == "update") { this.read(); } if (e.type == "create") {  this.read(); }
    }
}