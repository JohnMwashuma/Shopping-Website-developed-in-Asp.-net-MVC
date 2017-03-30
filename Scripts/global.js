var toTopVisible = false;

jQuery(document).ready(function($){
	customTabs();

	jQuery('.header .main-navigation li.search>a, .mobile-controls .mobile-search-btn').on('click', function(event) {
		event.preventDefault();
		jQuery('.search-container').slideToggle();
	});

	jQuery('.wp-block .block-title').on('click', function() {
		jQuery(this).toggleClass('active');
		jQuery(this).next().slideToggle();
	});

	jQuery('.std a').each(function(index, val) {
		var href = jQuery(val).attr('href');
		if(!jQuery(val).parents().hasClass('ribbon-blue-inner')) {
			if(href.indexOf('pdf') > 0)
				jQuery(val).addClass('pdf-link');
			else if(href.indexOf('ppt') > 0)
				jQuery(val).addClass('ppt-link');
			else if(href.indexOf('pptx') > 0)
				jQuery(val).addClass('ppt-link');
			else if(href.indexOf('xlsx') > 0)
				jQuery(val).addClass('xls-link');
			else if(href.indexOf('xls') > 0)
				jQuery(val).addClass('xls-link');
			else if(href.indexOf('doc') > 0)
				jQuery(val).addClass('doc-link');
			else if(href.indexOf('docx') > 0)
				jQuery(val).addClass('doc-link');
			else if(href.indexOf('mp4') > 0)
				jQuery(val).addClass('video-link');
			else if(href.indexOf('mpg') > 0)
				jQuery(val).addClass('video-link');
			else if(href.indexOf('MPG') > 0)
				jQuery(val).addClass('video-link');
			else if(href.indexOf('m4v') > 0)
				jQuery(val).addClass('video-link');
		}
	});

	jQuery('.technical-papers .body ul li a').each(function(index, val) {
		var href = jQuery(val).attr('href');
		if(href.indexOf('pdf') > 0)
			jQuery(val).addClass('pdf-link');
		else if(href.indexOf('ppt') > 0)
			jQuery(val).addClass('ppt-link');
		else if(href.indexOf('pptx') > 0)
			jQuery(val).addClass('ppt-link');
		else if(href.indexOf('xlsx') > 0)
			jQuery(val).addClass('xls-link');
		else if(href.indexOf('xls') > 0)
			jQuery(val).addClass('xls-link');
		else if(href.indexOf('doc') > 0)
			jQuery(val).addClass('doc-link');
		else if(href.indexOf('docx') > 0)
			jQuery(val).addClass('doc-link');
		else if(href.indexOf('mp4') > 0)
			jQuery(val).addClass('video-link');
		else if(href.indexOf('mpg') > 0)
			jQuery(val).addClass('video-link');
		else if(href.indexOf('MPG') > 0)
			jQuery(val).addClass('video-link');
		else if(href.indexOf('m4v') > 0)
			jQuery(val).addClass('video-link');
		else
			jQuery(val).addClass('generic-link');
	});

	jQuery('.tab-content table').wrap('<div class="table-wrapper"></div>');

	$('body').imagesLoaded( function() {
		//formatSelectBoxes();
		matchHeight();
		isotope();
		if(jQuery('body').hasClass('ie-8')) {
			jQuery('.background-cover, .backgroundcover').each(function(index, val) {
				jQuery(val).addClass('ie-8-background-cover ie-8-backgroundcover');
			});
		}
	});

	if(!jQuery('body').hasClass('.ie-8')) {
		if(!jQuery('body').hasClass('cms-home'))
			headerTransitionEvents();
		globalAnimations();
	}

	jQuery('.to-top-btn').on('click', function() {
		if(jQuery('body').hasClass('cms-home') && window.innerWidth > '1200') {
			toSlideOne();
		} else
			jQuery('html, body').animate({scrollTop: 0}, 500);
	});
	toTopInit();

	jQuery('.firstscribe-landingpages-landingpage-view a').click(function(event) {
		var href = jQuery(this).attr('href');
		if(href.indexOf('#') >= 0) {
			event.preventDefault();
			jQuery('html, body').animate({
		        scrollTop: jQuery(href).offset().top - 85
		    }, 600);
		}
	});
});

function matchHeight() {
	jQuery('.match').matchHeight();
}

function isotope() {
	jQuery('.masonry').isotope({
		itemSelector: '.masonry-item'
	});
	jQuery('.masonry-row').isotope({
		itemSelector: '.masonry-item',
		layoutMode: 'fitRows'
	});

	/**Custom Isotope**/
	jQuery('.technical-papers').isotope({
	  itemSelector: '.technical-paper'
	});

	jQuery('.technical-papers .technical-paper .title').on('click', function() {
		if(jQuery(this).hasClass('active')) {
			jQuery(this).removeClass('active');
			jQuery(this).next().addClass('hide');
		} else {
			jQuery('.technical-papers .technical-paper .title.active').next().addClass('hide')
			jQuery('.technical-papers .technical-paper .title.active').removeClass('active');

			jQuery(this).addClass('active');
			jQuery(this).next().removeClass('hide');
		}
		
		jQuery('.technical-papers').isotope('layout');
	});
}

// function formatSelectBoxes() {
// 	jQuery('select').each(function( index, val ) {
// 		jQuery(val).wrap('<div class="select-box-wrapper"></div>');

// 		var parentWidth = jQuery(val).parent().width();
// 		jQuery(val).width(parentWidth + 5);
// 	});

// 	jQuery(window).resize( function() {
// 		jQuery('select').each(function( index, val ) {
// 			var parentWidth = jQuery(val).parent().width();
// 			jQuery(val).width(parentWidth + 5);
// 		});
// 	});
// }

function globalAnimations() {
    function elementAnimation(val) {
        var animation = jQuery(val).data('animation');
        jQuery(val).removeClass('pre-animated');
        jQuery(val).addClass('animated');
        jQuery(val).addClass(animation);
    }
   
	jQuery('.pre-animated').each(function(index, val) {
		if( isElementInViewport(val, 200) ) {
			elementAnimation(val);
		} else {
			jQuery(val).appear();
			jQuery(val).on('appear', function(event, affected) { elementAnimation(val); });
		}
	});
}

function headerTransitionEvents() {
	var scrollHappened = false;

	/*Initial*/
	var scrollDistance = jQuery(document).scrollTop();
	if (scrollDistance > 0 && scrollHappened == false) {
		scrollHappened = true;
		transitionHeader(1);
	}

	/*On Scroll*/
	jQuery(window).scroll(function() {
		var scrollDistance = jQuery(document).scrollTop();
		
		if (scrollDistance > 0 && scrollHappened == false) {
			scrollHappened = true;
				transitionHeader(1);
		} else if(scrollDistance == 0 && scrollHappened == true) {
			scrollHappened = false;
				transitionHeader(0);
		}
	});
}

function transitionHeader(state) {
	if(state == 1) {
		jQuery('body').removeClass('header-transition-false');
		jQuery('body').addClass('header-transition-true');
	}
	else {
		jQuery('body').addClass('header-transition-false');
		jQuery('body').removeClass('header-transition-true');
	}	
}

function toTopInit() {
	jQuery(window).scroll(function() {
		var scrollDistance = jQuery(document).scrollTop();
		
		if (scrollDistance > 0)
			transitionScrollTop(1);
		else
			transitionScrollTop(0);
	});
}

function transitionScrollTop(state) {
	if (state == 1 && toTopVisible == false) {
		toTopVisible = true;
		jQuery('.to-top-btn').addClass("active");
	} else if (state == 0 && toTopVisible == true) {
		toTopVisible = false;
		jQuery('.to-top-btn').removeClass("active");
	}
}

function isElementInViewport(elem, offset) {
  var docViewTop = jQuery(window).scrollTop();
  var docViewBottom = docViewTop + jQuery(window).height();
  var elemTop = jQuery(elem).offset().top;
  offset = typeof offset !== 'undefined' ? offset : jQuery(elem).outerHeight(false);
  var elemBottom = elemTop + offset;
  return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
}



/**
* Custom JS Tabs
*
* Use the following html structure

<div class="custom-tabs">
	<ul class="tab-bar tablet-hide">
		<li class="tab pointer active" data-tab="1">Tab 1</li>
		<li class="tab pointer" data-tab="2">Tab 2</li>
		<li class="tab pointer" data-tab="3">Tab 3</li>
	</ul>

	<div class="tab-bodies">
		<div class="mobile-tab-title pointer hide tablet-block active" data-tab="1">Tab 1</div>
		<div class="tab-body" data-tab="1">
	        Body 1
		</div>

		<div class="mobile-tab-title pointer hide tablet-block" data-tab="2">Tab 2</div>
		<div class="tab-body hide" data-tab="2">
			Body 2
		</div>

		<div class="mobile-tab-title pointer hide tablet-block" data-tab="3">Tab 3</div>
		<div class="tab-body hide" data-tab="3">
			Body 3
		</div>
	</div>
</div>

*
* @author Michael Zenner <mzenner@firstscribe.com>
* @version 2016-6-13
*/
function customTabs() {
	jQuery('.custom-tabs .tab').on('click', function() {
		var tabNum = jQuery(this).data('tab');
		jQuery(this).closest('.custom-tabs').find('.tab').removeClass('active');
		jQuery(this).addClass('active');

		jQuery(this).closest('.custom-tabs').find('.mobile-tab-title').removeClass('active');
		jQuery(this).closest('.custom-tabs').find('.mobile-tab-title[data-tab="' + tabNum + '"]').addClass('active');

		jQuery(this).closest('.custom-tabs').find('.tab-body').addClass('hide');
		jQuery(this).closest('.custom-tabs').find('.tab-body[data-tab="' + tabNum + '"]').removeClass('hide');

		jQuery('html, body').animate({
	        scrollTop: jQuery(this).offset().top - 90
	    }, 400);

		/*Fix Select Box Widths*/
		// jQuery('select').each(function( index, val ) {
		// 	var parentWidth = jQuery(val).parent().width();
		// 	jQuery(val).width(parentWidth + 30);
		// });
	});

	jQuery('.custom-tabs .mobile-tab-title').on('click', function() {
		var tabNum = jQuery(this).data('tab');
		jQuery(this).closest('.custom-tabs').find('.mobile-tab-title').removeClass('active');
		jQuery(this).addClass('active');

		jQuery(this).closest('.custom-tabs').find('.tab').removeClass('active');
		jQuery(this).closest('.custom-tabs').find('.tab[data-tab="' + tabNum + '"]').addClass('active');

		jQuery(this).closest('.custom-tabs').find('.tab-body').addClass('hide');
		jQuery(this).next().removeClass('hide');

		jQuery('html, body').animate({
	        scrollTop: jQuery(this).offset().top - 90
	    }, 0);

		/*Fix Select Box Widths*/
	    // jQuery('select').each(function( index, val ) {
	    // 	var parentWidth = jQuery(val).parent().width();
	    // 	jQuery(val).width(parentWidth + 30);
	    // });
	});
}