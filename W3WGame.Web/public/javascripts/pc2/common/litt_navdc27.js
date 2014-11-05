$(document).ready(function(){
	function creatBaseCss(){
		var headEle=document.getElementsByTagName("head")[0];
		var js=document.getElementById("litt_nav_js");
		var type=js.getAttribute("data-type");
		var css=document.createElement("style");
		var bows=getBow();
		css.type="text/css";
		var cssHtml='';
		css.id='popup_css_litnav';
		cssHtml+='';
		cssHtml+='.pub-littlt-fix-nav {   position: fixed;   left: 50%;   margin-left: 495px;   bottom: 80px;   width: 40px;   display: block;   _display: none;   user-select: none;   -webkit-user-select: none;   -moz-user-select: none;   -ms-user-select: none;   z-index:15; }';
		cssHtml+='.pub-littlt-fix-nav li {   height: 36px;   padding: 2px 0;   margin-bottom: 1px;   background: #f3f3f3;   font-size: 14px;   line-height: 18px;   color: #333;   text-align: center; }';
		cssHtml+='.pub-littlt-fix-nav li:hover {         cursor: pointer; }';
		cssHtml+='.pub-littlt-fix-nav li.on {   color: #fff;   background-color: #ff8a00;   cursor: pointer; }';
		cssHtml+='.pub-littlt-fix-nav li:hover .link {  background-color: color: #fff; #ff8a00;  display: block;   text-decoration:none; }';
		cssHtml+='.pub-littlt-fix-nav .link {   display: none;   width: 100%;   height: 36px;   margin-bottom: 1px;   background: #ff8a00;   font-size: 14px;   line-height: 18px;   color: #fff;   text-align: center; }';
		cssHtml+='.pub-littlt-fix-nav .to-top {   visibility: hidden; }';
		cssHtml+='.pub-littlt-fix-nav .client{ 	background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat 0px -40px; 	_background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat 0px -40px; 	background-color: #fff; 	visibility: visible; 	position:relative; }';
		cssHtml+='.pub-littlt-fix-nav .client .lit{ 	line-height:14px; 	font-size:12px; 	display:block; }';
		cssHtml+='.pub-littlt-fix-nav .client .client-code{ 	width:148px; padding:15px 0 10px;	border:1px solid #e0e0e0; 	background:#fff; 	position:absolute; 	left:-52px; 	bottom:46px; 	cursor:default; }';
		cssHtml+='.pub-littlt-fix-nav .client .client-code.first{position:absolute; 	left:0; 	bottom:0;  }';
		cssHtml+='.pub-littlt-fix-nav .client .client-code.first .cor{display:none;}';
		cssHtml+='.pub-littlt-fix-nav .client .img{ 	width:110px; 	height:110px; 	display:block; 	margin:0 0 10px 19px; }';
		cssHtml+='.pub-littlt-fix-nav .client .p{ 	line-height:16px; 	font-size:12px; 	text-align:center; 	color:#333; }';
		cssHtml+='.pub-littlt-fix-nav .client .p2{ 	line-height:16px; 	font-size:12px; 	text-align:center; 	color:#f60; }';
		cssHtml+='.pub-littlt-fix-nav .client .close{ 	width:23px; 	height:23px; 	position:absolute; 	right:-1px; 	top:-24px; 	background:#fff url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat -8px 4px; 	_background:#fff url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat -8px 4px; 	border:1px solid #e0e0e0; 	border-bottom:0; 	cursor:pointer; }';
		cssHtml+='.pub-littlt-fix-nav .client .cor{ 	width:60px; 	height:8px; 	position:absolute; 	left:40px; 	bottom:-8px; 	background:url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat 10px -315px; 	_background:#fff url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat 10px -315px; }';
		cssHtml+='.pub-littlt-fix-nav .to-top.show{ 	background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat 0 -162px; 	_background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat 0 -162px; 	background-color: #fff; 	visibility: visible; }';
		cssHtml+='.pub-littlt-fix-nav .to-top.show:hover {   background-color: #ff8a00;   background-position:0 -214px;   cursor:pointer; }';
		cssHtml+='.pub-littlt-fix-nav #bdshare {   width: 40px;   float: none; }';
		cssHtml+='.pub-littlt-fix-nav #bdshare .bds_more {   margin: 0;   padding: 0;   display: none;   width: 100%;   height: 36px;   margin-bottom: 1px;   background: #ff8a00  !important;   font-size: 14px;   line-height: 18px;   color: #fff;   text-align: center; }';
		cssHtml+='.pub-littlt-fix-nav #bdshare:hover .bds_more {   display: block;   font-size: 14px;   line-height: 18px;   color: #fff;   text-align: center; }';
		cssHtml+='.pub-littlt-fix-nav #bdshare:hover .bds_more:hover {   opacity: 1;   filter: alpha(opacity=100); }';
		cssHtml+='.pub-littlt-fix-nav .suggest {   background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat 1px -81px;   _background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat 1px -81px;   background-color: #fff;   position:relative; }';
		cssHtml+='.pub-littlt-fix-nav .share {    background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.png) no-repeat 1px -122px;   _background: url(http://www.w3wgame.com/public/images/pc/pc_9game_public/litnav/litt_nav.gif) no-repeat 1px -122px;   background-color: #fff; }';
		cssHtml+='#bdshare_l {   position: fixed !important;   left: 50% !important;   margin-left: 278px !important;   bottom: 121px !important;   top: auto !important;   _display: none; }';
		cssHtml+='#bdsIfr{ 	display:none !important; }';
		if(type=="2"){
			cssHtml+=".pub-littlt-fix-nav{left:auto;right:0;}";
			cssHtml+='.pub-littlt-fix-nav .client .client-code.first{left:auto;right:0;}';
			cssHtml+=".pub-littlt-fix-nav .client  .client-code{left:auto;right:46px;bottom:0;}";
			cssHtml+='.pub-littlt-fix-nav .client .cor{width:8px;height:45px;background-position:-20px -324px;left: auto; right: -8px; bottom: 0;}';
			cssHtml+="#bdshare_l {left:auto !important;right:40px !important;margin-left:0 !important;}";
		}
		if(type=="3"){
			cssHtml+=".pub-littlt-fix-nav .suggest,.pub-littlt-fix-nav .client,.pub-littlt-fix-nav #bdshare,.pub-littlt-fix-nav .to-top.show{background-color:#f3f3f3;}";
		}
		headEle.appendChild(css);
		if(bows=='IE6' || bows=='IE7' || bows=='IE8') css.styleSheet.cssText=cssHtml;
		else css.innerHTML=cssHtml;
	}
	function getBow(){
		var Sys = {};
		var ua = navigator.userAgent.toLowerCase();
		var s;
		(s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] : (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] : (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] : (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] : (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
		if (Sys.ie &&  Sys.ie=='6.0'  ) return 'IE6';
		else if (Sys.ie &&  Sys.ie=='7.0'  ) return 'IE7';
		else if (Sys.ie &&  Sys.ie=='8.0'  ) return 'IE8';
		else if (Sys.ie &&  Sys.ie=='9.0'  ) return 'IE9';
		else if (Sys.ie &&  Sys.ie=='10.0'  ) return 'IE10';
		else if (Sys.ie &&  Sys.ie=='11.0'  ) return 'IE11';
		else if (Sys.firefox) return '-moz-';
		else if (Sys.chrome) return '-webkit-';
		else if (Sys.opera) return '-o-';
		else if (Sys.safari) return '-webkit-';
		else return '';
	}
	creatBaseCss();
	(function(){
		var littNav=$('#pub-littlt-fix-nav');
		var cli=littNav.find('.client');
		var pop=littNav.find('.client-code');
		littNav.find('.client .close').click(function(){
			$(this).hide();
			pop.hide();
			pop.removeClass('first');
			cli.children('a').hide();
			cli.bind({'mouseenter':function(){
				cli.children('a').show();
				pop.show();
			},'mouseleave':function(){
				cli.children('a').hide();
				pop.hide();
			}});
		});
	})();
	(function(window){
		//滚动到页面固定位置
		var scroll_lock=true;
		var littNav=$('#pub-littlt-fix-nav');
		var toTop=littNav.find('.to-top');
		$(window).scroll(function(){
			var top=$(this).scrollTop();
			if(top<575){
				toTop.removeClass('show');
			}else{
				toTop.addClass('show');
			}
		});
		toTop.click(function(){
			var scrollTop = 0;
			$("body,html").animate({
				scrollTop: scrollTop //让body的scrollTop等于pos的top，就实现了滚动
			},500,function(){
				scroll_lock=true;
			});
		});
	})(window);
});