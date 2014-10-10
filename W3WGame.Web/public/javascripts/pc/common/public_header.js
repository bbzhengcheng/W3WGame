$(document).ready(function () {
    /*  头部导航 重置宽度*/
    var nav_list_length = $('.seo-nav-list').find('.list').length;
    $('.seo-nav-list').css('width', nav_list_length * 101 + 'px');
    /*  头部导航 seo */
    $('.header:eq(0)').find('.seo-nav').hover(
	function () {
	    $(this).find('.seo-nav-list').show();
	    $(this).children('a').addClass('current');
	}, function () {
	    $(this).find('.seo-nav-list').hide();
	    $(this).children('a').removeClass('current');
	});
    /* 头部导航 二维码*/
    $('.header:eq(0)').find('.wechat').hover(
	function () {
	    $(this).find('.code').show();
	    $(this).children('a').addClass('current');
	}, function () {
	    $(this).find('.code').hide();
	    $(this).children('a').removeClass('current');
	});
});