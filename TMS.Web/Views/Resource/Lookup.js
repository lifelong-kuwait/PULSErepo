function LookupCreation_onEdit(e) {
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
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
}

function LookupGrid_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    })
}
LookupCreation_Error = function (args) {
    if (args.errors) {
        var grid = jQuery("#ResourceLookupGridMian").data("kendoGrid");
        grid.editable.element.find(".errors").html('');
        var validationTemplate = kendo.template(jQuery("#LookupCreationErrorTemplate").html());
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
//Lookup Detail Grid Functions
function LookupDetailCreation_onEdit(e) {
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
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
}

function LookupDetailGrid_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    })
}

function grid_dataBound(e) {
    var grid = this;
    jQuery(e.row).find('a.k-grid-delete').remove();
    var items = e.sender.items();
    items.each(function (index) {
        var dataItem = grid.dataItem(this);
        if (dataItem.IsSelected) {
            this.className += " k-grid-Active-Row";
        }
    })
}

function onLookupDetailRequestEnd(evt) {
    if (evt.type === "update") {
        evt.sender.read();
    }
    if (evt.type === "create") {
        evt.sender.read();
    }
}