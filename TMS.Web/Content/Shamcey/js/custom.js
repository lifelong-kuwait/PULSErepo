jQuery.noConflict();


   

jQuery(document).ready(function(){
	
	// dropdown in leftmenu
	jQuery('.leftmenu .dropdown > a').click(function(){

	    if (!jQuery(this).next().is(':visible')){
	        jQuery(this).next().slideDown('fast');
	    }
		else
			jQuery(this).next().slideUp('fast');	
		return false;
	});
	

	if(jQuery.uniform) 
	   jQuery('input:checkbox, input:radio, .uniform-file').uniform();
		
	if (jQuery('.widgettitle .close').length > 0) {
	    jQuery('.widgettitle .close').click(function () {
	        jQuery(this).parents('.widgetbox').fadeOut(function () {
	            jQuery(this).remove();
	        });
	    });
	}


	jQuery('.leftmenu li a').click(function () {


	    if (jQuery(this).parent().hasClass('dropdown')) {
	        jQuery(this).parents('ul').find('li').addClass("active");
	    }


	    jQuery(this).parent().siblings().removeClass('active');
	    jQuery(this).parent().addClass("active");

	    
	});



   // add menu bar for phones and tablet
   jQuery('<div class="topbar"><a class="barmenu">'+'</a><div class="chatmenu"></a></div>').insertBefore('.mainwrapper');
     	  var lwidth = '260px';
     	  if(jQuery(window).width() < 340) {
     				 lwidth = '260px';
     	  }

     	  
     	 


    // Left SideBar
     	  jQuery('body.lang-EN .topbar .barmenu').click(function () {

     	      if (!jQuery(this).hasClass('open')) {
     	          jQuery('body.lang-EN .rightpanel, body.lang-EN .headerinner, body.lang-EN .topbar').css({ marginLeft: lwidth }, 'fast');
     	          jQuery('body.lang-EN .logo, body.lang-EN .leftpanel').css({ marginLeft: 0 }, 'fast');
     	          jQuery(this).addClass('open');
     	      } else {
     	          jQuery('body.lang-EN .rightpanel, body.lang-EN .headerinner, body.lang-EN .topbar').css({ marginLeft: 0 }, 'fast');
     	          jQuery('body.lang-EN .logo, body.lang-EN .leftpanel').css({ marginLeft: '-' + lwidth }, 'fast');
     	          jQuery(this).removeClass('open');
     	      }
     	  });

   
    /// Right Sidbar
     	  jQuery('body.lang-AR .topbar .barmenu').click(function () {

    	  if(!jQuery(this).hasClass('open')) {
    	      jQuery('body.lang-AR .rightpanel, body.lang-AR .headerinner, body.lang-AR .topbar').css({ marginLeft:'-'+lwidth }, 'fast');
    	      jQuery('body.lang-AR .logo, body.lang-AR .leftpanel').css({ marginRight: 0 }, 'fast');
    				 jQuery(this).addClass('open');
    	  } else {
    	      jQuery('body.lang-AR .rightpanel, body.lang-AR .headerinner, body.lang-AR .topbar').css({ marginLeft: '0' }, 'fast');
    	      jQuery('body.lang-AR .logo, body.lang-AR .leftpanel').css({ marginRight: '-' + lwidth }, 'fast');
    				 jQuery(this).removeClass('open');
    	  }
    });

    ////addded for the Dashboard 2
    // 	  jQuery('<div class="topbar"><a data-toggle="dropdown" href="#" class="Outmenu" id="Outmenu">' + '</a><div class="chatmenu"></a></div>').insertBefore('.mainwrapperId');



    // Left SideBar
     	  //jQuery('body.lang-EN .headmenu .Outmenu').click(function (e) {
     	  //    // e.stopPropagation();
     	  //    debugger;
     	  //    jQuery("#outlookid").dropdown('toggle');// this doesn't
     	  //});

     	  //jQuery("a.Outmenu").click(function (e) {

     	  //    if (!jQuery("#outlookid").hasClass('open')) {
     	  //        jQuery("#outlookid").show();
     	  //        jQuery("#outlookid").addClass('open');
     	  //    } else {
     	  //        jQuery("#outlookid").hide();
     	  //        jQuery("#outlookid").removeClass('open');
     	  //    }     	      
     	  //});
     	  //jQuery(':not(a.Outmenu)').click(function () {
     	  //    jQuery('#outlookid').hide();
     	  //    jQuery("#outlookid").removeClass('open');
     	  //});
     	  jQuery("a.Outmenu").click(function (event) {
     	      event.stopPropagation();
     	      jQuery('#outlookid').slideToggle(100);
     	  });

     	  jQuery('body').click(function () {
     	      jQuery('#outlookid').slideUp(100);
     	  });
    /// Right Sidbar
     	  jQuery('body.lang-AR .headmenu .Outmenu').click(function (e) {
     	    //  e.stopPropagation();
     	      jQuery("#outlookid").dropdown('toggle');// this doesn't
     	  
     	  });

     	  
    //jQuery('body.lang-EN .topbar body.lang-EN .chatmenu').click(function () {
    //    if (!jQuery('body.lang-EN .onlineuserpanel').is(':visible')) {
    //        jQuery('body.lang-EN .onlineuserpanel,#chatwindows').show();
    //        jQuery('body.lang-EN .topbar .chatmenu').css({ right: '210px' });
    // 	} else {
    //        jQuery('body.lang-EN .onlineuserpanel, body.lang-EN #chatwindows').hide();
    //        jQuery('body.lang-EN .topbar .chatmenu').css({ right: '10px' });
    // 	}
    //});


     //show/hide left menu
   //jQuery(window).resize(function () {

	   
   //    if (jQuery('body').hasClass('lang-EN')) {

   //     if (jQuery('.topbar').is(':visible')) {
   //         if (jQuery('.barmenu').hasClass('open')) {
   //             jQuery('.rightpanel , .headerinner').css({ marginLeft: '260px' });
   //             jQuery('.logo , .leftpanel').css({ marginLeft: 0 });
   // 			} else {
   //             jQuery('.rightpanel , .headerinner').css({ marginLeft: 0 });
   //             jQuery('.logo, .leftpanel').css({ marginLeft: '-260px' });
   // 			}
   // 	  } else {
   //         jQuery('.rightpanel , .headerinner').css({ marginLeft: '260px' });
   //         jQuery('.logo , .leftpanel').css({ marginLeft: 0 });
   //     }
   //    }
   //    if (jQuery('body').hasClass('lang-AR')) {
		
		   
   //        if (jQuery('.topbar').is(':visible')) {
   //            if (jQuery('.barmenu').hasClass('open')) {
   //                jQuery('.rightpanel , .headerinner').css({ marginRight: '260px' });
   //                jQuery('.logo , .leftpanel').css({ marginRight: 0 });
   //            } else {
   //                jQuery('.rightpanel , .headerinner').css({ marginRight: '0' });
   //                jQuery('.logo , .leftpanel').css({ marginRight: '-260px' });
   //            }
   //        } else {
   //            jQuery('.rightpanel , .headerinner').css({ marginRight: '260px' });
   //            jQuery('.logo , .leftpanel').css({ marginRight: '0' });
   //        }
   //    }
   // });
	// dropdown menu for profile image
	jQuery('.userloggedinfo img').click(function(){
		  if(jQuery(window).width() < 480) {
					 var dm = jQuery('.userloggedinfo .userinfo');
					 if(dm.is(':visible')) {
								dm.hide();
					 } else {
								dm.show();
					 }
		  }
   });
	// change skin color
	//jQuery('.skin-color a').click(function(){ return false; });
	
	// expand/collapse boxes
	if(jQuery('.minimize').length > 0) {
		  
		  jQuery('.minimize').click(function(){
					 if(!jQuery(this).hasClass('collapsed')) {
								jQuery(this).addClass('collapsed');
								jQuery(this).html("&#43;");
								jQuery(this).parents('.widgetbox')
										      .css({marginBottom: '20px'})
												.find('.widgetcontent')
												.hide();
					 } else {
								jQuery(this).removeClass('collapsed');
								jQuery(this).html("&#8211;");
								jQuery(this).parents('.widgetbox')
										      .css({marginBottom: '0'})
												.find('.widgetcontent')
												.show();
					 }
					 return false;
		  });
			  
	}
	
	// fixed right panel
	var winSize = jQuery(window).height();
	if(jQuery('.rightpanel').height() < winSize) {
		jQuery('.rightpanel').height(winSize);
	}
	
	
	// if facebook like chat is enabled
	if(jQuery.cookie('enable-chat')) {
		
		jQuery('body').addClass('chatenabled');
		jQuery.get('ajax/chat.html',function(data){
			jQuery('body').append(data);
		});
		
	} else {
		
		if(jQuery('.chatmenu').length > 0) {
			jQuery('.chatmenu').remove();
		}
	}

    // Select All Checkboxes in tables

	jQuery('.checkall').click(function () {
	    var parentTable = jQuery(this).parents('table');
	    var ch = parentTable.find('tbody input[type=checkbox]');
	    if (jQuery(this).is(':checked')) {
	        //check all rows in table
	        ch.each(function () {
	            jQuery(this).attr('checked', true);
	            jQuery(this).parent().addClass('checked');	//used for the custom checkbox style
	            jQuery(this).parents('tr').addClass('selected'); // to highlight row as selected
	        });
	    } else {
	        //uncheck all rows in table
	        ch.each(function () {
	            jQuery(this).attr('checked', false);
	            jQuery(this).parent().removeClass('checked');	//used for the custom checkbox style
	            jQuery(this).parents('tr').removeClass('selected');
	        });
	    }
	});


    // delete row in a table
	if (jQuery('.deleterow').length > 0) {
	    jQuery('.deleterow').click(function () {
	        var conf = confirm('Continue delete?');
	        if (conf)
	            jQuery(this).parents('tr').fadeOut(function () {
	                jQuery(this).remove();
	                // do some other stuff here
	            });
	        return false;
	    });
	}

});