var mobileMenuOpen = false;

jQuery(document).ready(function($) {
	jQuery('.mobile-menu-btn, .close-mobile-menu-btn').on('click', function() { toggleMobileMenu(); });

	mobileSubMenuLinksEvents();
	toggleElements();
});

function toggleElements() {
	var changeHappened = false;
	var windowWidth = window.innerWidth;

	/*Initial*/
	if(windowWidth <= '999') {
		changeHappened = true;
		
	}

	/*On Resize*/
	jQuery(window).resize( function() {
		windowWidth = window.innerWidth;

		if(windowWidth <= '999') {
			if(changeHappened == false) {
				changeHappened = true;
				
			}
		}
		else {
			if(changeHappened == true) {
				changeHappened = false;
				
				quickCloseMobileMenu();	
			}
		}
	});

	jQuery('.touch .header .main-navigation ul.level-0 > li.menu-item-has-children>a').on('touchend', function(event) {
		if (!jQuery(this).hasClass('clicked')) {
			event.preventDefault();
			event.stopPropagation();
			jQuery('.touch .header .main-navigation ul.level-0 > li > a').removeClass('clicked');
			jQuery(this).addClass('clicked');
		}
	});
}

function toggleMobileMenu() {
	if(mobileMenuOpen) {
		mobileMenuOpen = false;
		jQuery('body').removeClass('mobile-menu-open');
		setTimeout(function() { 
			jQuery('.mobile-menu .level-0').css('left', ''); 
			jQuery('.mobile-menu .level-1').removeClass('active');
		}, 600);
	} else {
		mobileMenuOpen = true;
		jQuery('body').addClass('mobile-menu-open');
	}
}

function mobileSubMenuLinksEvents() {
	jQuery('.mobile-arrow').on('click', function() {
		jQuery('.mobile-menu .level-1').removeClass('active');
		jQuery(this).next().addClass('active');
		jQuery('.mobile-menu .level-0').animate({
			left: "-=100%"
		}, 600 );
	});

	jQuery('.mobile-menu li.go-back>a').on('click', function(event) {
		event.preventDefault();
		jQuery('.mobile-menu .level-0').animate({
			left: "+=100%"
		}, 600, function() {
			jQuery('.mobile-menu .level-1').removeClass('active');
		});
	});
}

function quickCloseMobileMenu() {
	mobileMenuOpen = false;

	jQuery('body').removeClass('mobile-menu-open');
	jQuery('.mobile-menu .level-0').css('left', ''); 
	jQuery('.mobile-menu .level-1').removeClass('active');
}