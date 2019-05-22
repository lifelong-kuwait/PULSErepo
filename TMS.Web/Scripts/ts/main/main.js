var lr = {}; // Global variable.
(function ($) {
    $.getJSON(baseurl + 'Resource/GetResources/', function (data) {
        lr = data;
        ReplaceInvalidNumberMessage(lr.EnterNumber);
    });

    ReplaceInvalidNumberMessage = function (message) {
        $("form").each(function () {
            var $form = $(this);

            $.each($form.validate().settings.messages, function () {

                if (this["number"] !== undefined) {
                    this.number = message;
                }

            });

        });
    }

})(jQuery);

jQuery.validator.setDefaults({
    ignore: []
});

/**
 * return text by value
 * @param {int}value
 * @param objenum
 */
function enumvalue(value, objenum) {
    var arr = jQuery.grep(objenum, function (n, i) {
        return (n.Value === value) ? n.Text : "";
    });
    return (arr.length) ? arr[0].Text : "";
}

function withSearch() {
    return {
        SearchText: jQuery('#searchBox').val()
    };
}
function addedbytemplate(d) {
    if (d !== null) {
        var addedbytemplate = kendo.template(jQuery("#addedbytemplate").html(), { useWithBlock: false });
        return addedbytemplate(d);
    }
    return '';
}

    (function ($, kendo) {
        $.extend(true, kendo.ui.validator, {
            rules: {
                greaterdate: function (input) {
                    if (input.is("[data-val-greaterdate]") && input.val() != "") {
                        var date = kendo.parseDate(input.val()),
                            earlierDate = kendo.parseDate($("[name='" + input.attr("data-val-greaterdate-earlierdate") + "']").val());
                        return !date || !earlierDate || earlierDate.getTime() < date.getTime();
                    }

                    return true;
                }
            },
            messages: {
                greaterdate: function (input) {
                    return input.attr("data-val-greaterdate");
                }
            }
        });
    })(jQuery, kendo);