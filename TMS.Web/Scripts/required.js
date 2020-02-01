
function Grid_onEdit(e) {
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
        setTimeout(function () {
            jQuery(".k-widget.k-tooltip.k-tooltip-validation.k-invalid-msg.field-validation-error").hide();
        }, 100);
      
    } else {
        jQuery(title).text(lr.EditRecordGeneralTitle);
        jQuery(update).html('<span class="k-icon k-i-check"></span>' + lr.UpdateRecordGeneralButton);
    }
    //
}

function GeneralErrorHandler(gridName) {
    return function (args) {
        if (args.errors) {
            var grid = jQuery("#" + gridName).data("kendoGrid");
            grid.editable.element.find(".errors").html('');
            var validationTemplate = kendo.template(jQuery("#GridErrorTemplate").html());
            grid.one("dataBinding", function (e) {
                e.preventDefault();
                jQuery.each(args.errors, function (propertyName) {
                    var renderedTemplate = validationTemplate({ field: propertyName, messages: this.errors });
                    grid.editable.element.find(".errors").append(renderedTemplate);
                    grid.editable.element.find(".Alertbox").show();
                });
            });
        } else if (args.status == "error") {
            abp.notify.error(lr.ResourceUpdateValidationError, lr.ErrorServerError);
        }
    }
}

function General_onSave(e) {
    jQuery(event.srcElement)
        .addClass("k-state-disabled")
        .bind("click", disable = function (e) { e.preventDefault(); return false; })

    this.dataSource.one("requestEnd", function () {
        jQuery("[data-role=window] .k-grid-update").off("click", disable).removeClass("k-state-disabled");
    });
}

function GridRequestEndUpdate(e) {
    if (e.response != undefined) {
        if (e.response == "403") {
            window.location = LoginUrl;
        }
        else if (e.response.Errors == null) {
            if (e.type == "update") { this.read(); } if (e.type == "create") { this.read(); }
        }
    }
}
var currentRowId = null;
jQuery(function () {
  /*
the cache section page elements
  */
    var $gridsearchBox = jQuery("#searchBox");
    var $maingrid = jQuery(".k-widget.k-grid[data-role='grid']:visible").parent("div:not(.ChildGrid)").children(".k-widget.k-grid[data-role='grid']:visible");
    var $maingriddata = $maingrid.data("kendoGrid");
     /*
the cache section page elements
  */

     /*
The section is about the the widget search
  */
    jQuery(".gridsearch .clearspace").live("mousedown", function (event) {
        if ($gridsearchBox.val() !== "") {
            $gridsearchBox.val('').focus(); jQuery(".clear").removeClass("showicon");
            $maingriddata.dataSource.filter({});
        }
    });
    jQuery(".tms-gridsearch").live("mousedown", function (event) {
        if ($gridsearchBox.val() !== "") {
            $maingriddata.dataSource.filter({});
        }
    });
    $gridsearchBox.on('keyup', function (e) {
        if (e.keyCode == 13) {
            $maingriddata.dataSource.filter({});
        }
    });
    $gridsearchBox.after('<span class="clearspace" ><i class="clear" title="clear"> <i class="mdi mdi-close-circle fa-2x tms-reset" ></i></i></span>');
    $gridsearchBox.on('keyup input', function () {
        if (jQuery(this).val()) { jQuery(".clear").addClass("showicon"); } else { jQuery(".clear").removeClass("showicon"); }
    });
    /*
The section is about the the widget search
*/
    jQuery(".tms-grid-add").live("mousedown", function (event) {
        jQuery(this).parents('.k-grid').data("kendoGrid").addRow();
    });

    jQuery(".tms-grid-edit").live("mousedown", function (event) {
        var selectedrow = jQuery("#" + jQuery(this).parents('.k-grid')[0].id + " tr.k-state-selected");
        if (selectedrow.length === 1) { currentRowId = selectedrow.data().uid; jQuery(this).parents('.k-grid').data("kendoGrid").editRow(selectedrow); }
    });


    jQuery(".tms-grid-destroy").live("mousedown", function (event) {
        var selectedRows = jQuery("#" + jQuery(this).parents('.k-grid')[0].id + " tr.k-state-selected");

        var checkedLength = selectedRows.length;
        if (checkedLength == 1) {
            var grid = jQuery(this).parents('.k-grid').data("kendoGrid");
            var gridId = jQuery(this).parents('.k-grid')[0].id;
            if (gridId.search("ClassGrid") == 0) {
                var dataitem = grid.dataItem(grid.select());
                swal({
                    title: lr.Areyousureyouwanttodeletethisrecord,
                    text: lr.Youwillnotbeabletorecover,
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: lr.confirmDelete,
                    cancelButtonText: lr.confirmNo,
                    closeOnConfirm: false,
                    closeOnCancel: true,
                    customClass: "tmsconfirm"
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            jQuery.ajax({
                                method: "post",
                                url: "/Program/ClassDelteChk",
                                dataType: "JSON",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify({ _ClassID: dataitem.ID }),
                                success: function (msg) {
                                    if (!msg) {
                                        swal({
                                            title: lr.Oops,
                                            text: lr.MaximumSessionConflictDelete,
                                            type: "error"
                                        });
                                    } else {
                                        grid.removeRow(selectedRows);
                                        swal({
                                            title: lr.confirmDeleted,
                                            text:lr.confirmDeletedMessage,
                                            type: "success"
                                        },
                                            function () {
                                                window.location.reload;
                                            });
                                    }
                                }
                            });

                        }
                    });
            }
            else if (gridId.search("SessionsGrid") == 0) {
                var dataitem = grid.dataItem(grid.select());
                swal({
                    title: lr.Areyousureyouwanttodeletethisrecord,
                    text: lr.Youwillnotbeabletorecover,
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: lr.confirmDelete,
                    cancelButtonText: lr.confirmNo,
                    closeOnConfirm: false,
                    closeOnCancel: true,
                    customClass: "tmsconfirm"
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            jQuery.ajax({
                                method: "post",
                                url: "/Program/SessionDelteChk",
                                dataType: "JSON",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify({ _Sessions: dataitem.ID }),
                                success: function (msg) {
                                    if (!msg) {
                                        swal({
                                            title: lr.Oops,
                                            text: lr.SessionAttandanceMarked,
                                            type: "error"
                                        });
                                        window.location.reload;
                                    }
                                    else {
                                        grid.removeRow(selectedRows);
                                        swal({
                                            title: lr.confirmDeleted,
                                            text: lr.confirmDeletedMessage,
                                            type: "success"
                                        },
                                            function () {
                                                window.location.reload;
                                            });
                                    }
                                }
                            });
                        }
                    });
            } else {
                swal({
                    title: lr.Areyousureyouwanttodeletethisrecord,
                    text: lr.Youwillnotbeabletorecover,
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: lr.confirmDelete,
                    cancelButtonText: lr.confirmNo,
                    closeOnConfirm: false,
                    closeOnCancel: true,
                    customClass: "tmsconfirm"
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            grid.removeRow(selectedRows);
                            swal(lr.confirmDeleted, lr.confirmDeletedMessage, "success");
                        } else {
                        }
                    });
            }
            
        }
        else if (checkedLength > 1) {
            var grid = jQuery(this).parents('.k-grid').data("kendoGrid");

            swal({
                title: lr.Areyousureyouwanttodeletetheserecord,
                text: lr.Youwillnotbeabletorecover + ' <strong style="font-weight:bold">' + checkedLength + ' ' + lr.confirmRecords + '</strong> ?',
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: lr.confirmDelete,
                cancelButtonText: lr.confirmNo,
                closeOnConfirm: false,
                closeOnCancel: true,
                html: true,
                customClass: "tmsconfirm"
            },
            function (isConfirm) {
                if (isConfirm) {
                    selectedRows.each(function () { grid.removeRow(jQuery(this)); });
                    swal(lr.confirmDeleted, lr.confirmDeletedMessageMultiple, "success");
                } else {
                }
            });
        }
        else {
            }
            
    });
});


//jQuery(".tms-grid-detail").live("mousedown", function (event) {
//    var selectedRows = jQuery("#" + jQuery(this).parents('.k-grid')[0].id + " tr.k-state-selected");
//    if (selectedRows.length == 1) {
//        var grid = jQuery(this).parents('.k-grid').data("kendoGrid");
//        var data = grid.dataItem(grid.select());
//        var url = baseurl + '/Organization/Detail?oid=' + data.ID;
//        window.open(url, '_blank');
//    }
//});