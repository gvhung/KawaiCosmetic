$(document).ready(function() {
	$('input, textarea').placeholder();
	/* PIE */
	if (window.PIE) {
		$('nav').each(function() {
			PIE.attach(this);
		});
	}
	var ff;
	$('input[type=text]:not(.des-kk input)').focus(function() {
		if($(this).attr('data-place')==$(this).val()) {
			$(this).val('');
		}
	});
	$('input[type=text]:not(.des-kk input)').blur(function() {
		if($(this).val()=='') {
			$(this).val($(this).attr('data-place'));
		}
	});
	$('textarea').focus(function() {
		if($(this).attr('data-place')==$(this).val()) {
			$(this).val('');
		}
	});
	$('textarea').blur(function() {
		ff=$(this).attr('data-place');
		if($(this).val().length==0) {
			$(this).val(ff);
		}
	});
	function ress() {
		$('.modal-tb').width($(window).width()).height($(window).height());
	}
	$(window).load(function() {
		$('input[type=text]').each(function() {
			$(this).attr('data-place',$(this).val());
		});
		$('textarea').each(function() {
			$(this).attr('data-place',$(this).val());
		});
		$('.ct-img div').each(function() {
			$(this).width($(this).parent().width());
		});
		$('.fl1').flexslider({
			animation: "slide",
			slideshowSpeed: 5000
		});
		$('.fl2').flexslider({
			animation: "slide",
			animationLoop: false,
			itemWidth: 178,
			slideshow: false,
			move:1
		});
		$('.fl3').flexslider({
			animation: "slide",
			animationLoop: false,
			itemWidth: 212,
			slideshow: false,
			move:1
		});
		$('.fl4').flexslider({
			animation: "fade",
			slideshow: false
		});
		if($('.ep2 select').length>0) {
			$('.ep2 select').styler();
		}
		if($('.rr-flt select').length>0) {
			$('.rr-flt select').styler();
		}
		if($('.hide-form-st1 select').length>0) {
			$('.hide-form-st1 select').styler();
		}
		ress();
		$('.line1:even').addClass('active');
		if($('.lnt-poss .item1 div').length>0) {
			$('.lnt-poss .item1 div').each(function() {
				$(this).width($(this).parent().width());
			});
		}
		if($('.dc-et1').length>0) {
			$('.dc-et1').each(function() {
				$(this).width($(this).parent().width());
			});
		}
		if($('.chat1').length>0) {
			if($('.off').length>0) {
				$('.chat1').animate({bottom:'-250px'}, 0);
			}
		}
	});
	$(window).resize(function() {
		ress();
	});
	$('.mess-now').click(function(e) {
		e.preventDefault();
		$('.m1').fadeIn(400);
		ress();
	});
	$('.cart-add1-now1').click(function(e) {
		e.preventDefault();
		$('.m3').fadeIn(400);
		ress();
	});
	$('.sub-s input').click(function(e) {
		e.preventDefault();
		$('.m1').hide();
		$('.m2').show();
		ress();
	});
	$('.bg-modal,.close,.sub-s2,.bty1').click(function(e) {
		e.preventDefault();
		$('.modal').fadeOut(400);
	});
	$('.des-kk input').keydown(function(e) {
		if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
	             // Allow: Ctrl+A
	             (e.keyCode == 65 && e.ctrlKey === true) || 
	             // Allow: home, end, left, right
	             (e.keyCode >= 35 && e.keyCode <= 39)) {
	                 // let it happen, don't do anything
	             return;
	         }
	        // Ensure that it is a number and stop the keypress
	        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
	        	e.preventDefault();
	        }
	    });
	$('.price-s1 .des-kk div span:first-child').click(function() {
		$(this).parent().parent().find('input').val(parseInt($(this).parent().parent().find('input').val())+1);
	});
	$('.price-s1 .des-kk div span:last-child').click(function() {
		if(parseInt($(this).parent().parent().find('input').val())>0) {
			$(this).parent().parent().find('input').val(parseInt($(this).parent().parent().find('input').val())-1);
		}
	});
	$('.dr1 .des-kk div span:first-child').click(function() {
		$(this).parent().parent().find('input').val(parseInt($(this).parent().parent().find('input').val())+1);
	});
	$('.dr1 .des-kk div span:last-child').click(function() {
		if(parseInt($(this).parent().parent().find('input').val())>0) {
			$(this).parent().parent().find('input').val(parseInt($(this).parent().parent().find('input').val())-1);
		}
	});
	$('.gl1 .item1 div').click(function(e) {
		e.preventDefault();
		$(this).parent().addClass('active').siblings().removeClass('active');
		$('.big-ert img').attr('src',$(this).prev().attr('href'));
		$('.big-ert a').attr('href',$(this).prev().attr('href'));
	});
	if($('.big-ert a').length>0) {
		$('.big-ert a,.gl1 .item1 a').fancybox({
			helpers		: {
				overlay: {
					locked: false
				},
				media : {},
				buttons : {}
			},
			prevEffect : 'none',
			nextEffect : 'none'
		});
	}
	$('.more-form-ip').click(function(e) {
		e.preventDefault();
		$(this).hide().next().show();
		$('body,html').animate({scrollTop:$('.title3').offset().top-30}, 0);
	});
	$('.qq1 span').click(function() {
		if($(this).parent().attr('dt')=='0') {
			$(this).parent().addClass('active').next().slideDown(100);
			$(this).parent().attr('dt','1');
			$(this).parent().parent().siblings().find('.qq1').attr('dt','0').removeClass('active').next().slideUp(100);
		}
		else {
			$(this).parent().removeClass('active').next().slideUp(100);
			$(this).parent().attr('dt','0');
		}
	});
	$('.close-c').click(function(e) {
		if($('.off').length>0) {
			$('.chat1').removeClass('off').animate({bottom:'0px'}, 300);
		}
		else {
			$('.chat1').addClass('off').animate({bottom:'-250px'}, 300);
		}
	});
	$('.l-tabs li').mouseenter(function() {
		$(this).addClass('active').siblings().removeClass('active');
		$('.pos-ct-item-s1').eq($(this).index()).addClass('active').siblings().removeClass('active');
	});
	$('.l-tabs li a').click(function(e) {
		e.preventDefault();
	});
});