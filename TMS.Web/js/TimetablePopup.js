/* 
author: istockphp.com
*/
jQuery(function () {
    //debugger
    jQuery("a.topopup").click(function ($) {


        var contentDetail = jQuery(jQuery(this).parent().children(".eventdetail")).html();
        jQuery("#popup_content").html(contentDetail);

        loading(); // loading
        setTimeout(function () { // then show popup, deley in .5 second



            loadPopup(); // function show popup 
        }, 500); // .5 second
        return false;
    });

    /* event for close the popup */
    jQuery("div.close").hover(
					function () {
					    jQuery('span.ecs_tooltip').show();
					},
					function () {
					    jQuery('span.ecs_tooltip').hide();
					}
				);

    jQuery("div.close").click(function () {
        disablePopup();  // function close pop up
    });

    jQuery(this).keyup(function (event) {
        if (event.which == 27) { // 27 is 'Ecs' in the keyboard
            disablePopup();  // function close pop up
        }
    });

    jQuery("div#backgroundPopup").click(function () {
        disablePopup();  // function close pop up
    });

    jQuery('a.livebox').click(function () {
        alert('Hello World!');
        return false;
    });


    /************** start: functions. **************/
    function loading() {
        jQuery("div.loader").show();
        debugger
    }
    function closeloading() {
        jQuery("div.loader").fadeOut('normal');
        debugger
    }

    var popupStatus = 0; // set value

    function loadPopup() {
        debugger
        if (popupStatus == 0) { // if value is 0, show popup
            closeloading(); // fadeout loading
            jQuery("#toPopup").fadeIn(1000); // fadein popup div
            jQuery("#backgroundPopup").css("opacity", "0.7"); // css opacity, supports IE7, IE8
            jQuery("#backgroundPopup").fadeIn(0001);
            popupStatus = 1; // and set value to 1
        }
    }

    function disablePopup() {
        if (popupStatus == 1) { // if value is 1, close popup
            jQuery("#toPopup").fadeOut("normal");
            jQuery("#backgroundPopup").fadeOut("normal");
            popupStatus = 0;  // and set value to 0
        }
    }
    /************** end: functions. **************/
});     // jQuery End