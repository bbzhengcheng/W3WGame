$(document).ready(function(){
	
	tabChange('.tag-tit-ul','.box-text',false,'.open-test'); //开测表
	tabChange('.tag-tit-ul','.more',false,'.open-test'); //开测表
	tabChange('.friend-link .tag-tit-ul','.friend-link>.box-text'); //友情链接
	tabChange('.game-info-down .tag-tit-ul2','.game-info-down .context-con'); //网游详情页下载
	
	
	/*  头部导航 重置宽度*/
	var nav_list_length=$('.seo-nav-list').find('.list').length;
	$('.seo-nav-list').css('width',nav_list_length*101 + 'px');
	/*  头部导航 seo */
	$('.header:eq(0)').find('.seo-nav').hover(
	function () {
		$(this).find('.seo-nav-list').show();
		$(this).children('a').addClass('current');
	},function () {
		$(this).find('.seo-nav-list').hide();
		$(this).children('a').removeClass('current');
	});
	/* 头部导航 二维码*/
	$('.header:eq(0)').find('.wechat').hover(
	function () {
		$(this).find('.code').show();
		$(this).children('a').addClass('current');
	},function () {
		$(this).find('.code').hide();
		$(this).children('a').removeClass('current');
	});
	
	/* 推广 */
	$('.speard-con:eq(0)').delegate('a','mouseenter',function(){
		$(this).children('.meng').stop().animate({'bottom':"0"},300);
	});
	$('.speard-con:eq(0)').delegate('a','mouseleave',function(){
		$(this).children('.meng').stop().animate({'bottom':"-100%"},300);
	});
	/* 弹窗 */
	$(".close").click(function(){
		$("#pb_popup").hide();
		$('body').removeClass('popup_of');
	});
	$('#pb_popup').bind({'click':function(){
			$(this).hide();
			$('body').removeClass('popup_of');
	}});
	$('#pb_popup').find('.popup').bind({'mouseenter':function(){
		$('#pb_popup').unbind();
	},'mouseleave':function(){
		$('#pb_popup').bind({'click':function(){
			$(this).hide();
			$('body').removeClass('popup_of');
		}});
	}});
	/* 搜索提示弹窗 */
	if(!cookie.getRaw('sr_cookies') && $('#search_popup').length){
		var pop=$('#search_popup');
		var domain = ".9game.cn";
		pop.show();
		$('body').addClass('popup_of');
		$(".sr-close").click(function(){
			pop.hide();
			$('body').removeClass('popup_of');
			cookie.setRaw('sr_cookies',"true",{
				path : "/",
				domain : domain,
				expires : 259200000 
			});
		});
		pop.bind({'click':function(){
			$(this).hide();
			$('body').removeClass('popup_of');
			cookie.setRaw('sr_cookies',"true",{
				path : "/",
				domain : domain,
				expires : 259200000 
			});
		}});
		pop.find('.sr-popup').bind({'mouseenter':function(){
			pop.unbind();
		},'mouseleave':function(){
			pop.bind({'click':function(){
				$(this).hide();
				$('body').removeClass('popup_of');
				cookie.setRaw('sr_cookies',"true",{
					path : "/",
					domain : domain,
					expires : 259200000 
				});
			}});
		}});
	}
	/* 分页页码 */
	var page_time=null;
	$('.page-change:eq(0)').find('.now').hover(
	function () {
		clearTimeout(page_time);
		$(this).addClass('current');
		$(this).parent().children('.page-change-list').show();
	},function () {
		var $This=$(this);
		page_time=setTimeout(function(){
			$This.parent().children('.page-change-list').hide();
			clearTimeout(page_time);
			$This.removeClass('current');
		},500)
		
	});
	$('.page-change:eq(0)').find('.page-change-list').bind({'mouseenter':function(){
		clearTimeout(page_time);
	},'mouseleave':function(){
		var $This=$(this);
		page_time=setTimeout(function(){
			$This.hide();
			$('.page-change:eq(0)').find('.now').removeClass('current');
		},500)
	}});
	
	/* 固定导航 */
	(function(window){
		if(getBow() != 'IE6'){
			var This={};
			This.info_con=$('.sub-nav').eq(0);
			if($('.sub-nav').length>0){
				This.limit=This.info_con.offset().top;
				This.stat=0;
				This.height=This.info_con.height();
				$win=$(window);
				$win.scroll(function(){
					This.height=This.info_con.height();
					if($win.height() > This.height){
						This.change_pos();
					}
				});
				$win.resize(function(){
					This.change_pos();
				});
				This.change_pos=function(){
					This.height=This.info_con.height();
					if($win.height() > This.height && $win.scrollTop() > This.limit){
						if(!This.stat){
							This.info_con.addClass('sub-nav-fixed');
							This.stat=1;
						}
					}else{
						This.info_con.removeClass('sub-nav-fixed');
						This.stat=0;
					}
				}
			}
		}
	})(window);
	(function(window){
		//滚动到页面固定位置
		var scroll_lock=true;
		var tag=$('.navTag');
		var toTop=$('.to-top');
		var tagHeight=[];
		var iNow=-1;
		for(var i=0;i<tag.length;i++){
			tagHeight.push($('#' + $(tag[i]).attr("data-go")).offset().top);
		}
		$(document).delegate('.js-togo','click',function(){
			if(scroll_lock){
				var This=$(this);
				var scrollTag =This.attr("data-go");
				var scrollId = "#"+scrollTag;
				scroll_lock=false;
				var margin=This.attr('data-margin') ? This.attr('data-margin') : 0 ;
				click_scroll(scrollId,margin);
			}
		});
		$(window).scroll(function(){
			var top=$(this).scrollTop();
			var i=0;
			for(i=tagHeight.length-1;i>=0;i--){
				if(top+100>tagHeight[i] ){
					break;
				}
			}
			
			if(iNow!=i && i>=0){
				iNow=i;
				tag.eq(i).addClass("on").siblings().removeClass("on");
			}
			if(i<0 && top+100<tagHeight[0]){
				iNow=-1;
				tag.eq(0).removeClass("on");
			}
			if(top<575){
				toTop.css("visibility","hidden");
			}else{
				toTop.css("visibility","visible");
			}
		});
		function click_scroll(tag,margin) {
			var scrollOffset = $(tag).offset();  //得到pos这个div层的offset
			var scrollTop =  scrollOffset.top - margin;
			
			$("body,html").animate({
				scrollTop: scrollTop //让body的scrollTop等于pos的top，就实现了滚动
			},500,function(){
				scroll_lock=true;
			});
		}
	})(window);
});

function tabChange(ctrl,ctrled,stat,parent){  //tab切换函数
	stat=stat || false ;
	parent= parent || window.document;
	$(parent).each(function(){
		var $This=$(this);
		$This.find(ctrl).children().each(function(){
			$(this).bind({'mouseenter':function(){
				var p_index = $(this).index();
				$(this).addClass("current").siblings().removeClass("current");	
				var getbow=getBow();
				if(getbow!='IE6' && getbow!='IE7' && getbow!=''){
					if(stat)
						$This.find(ctrled).children().eq(p_index).fadeIn(500).siblings().fadeOut(500);
					else
						$This.find(ctrled).children().eq(p_index).show().siblings().hide();
				}else{
					$This.find(ctrled).children().eq(p_index).show().siblings().hide();
					
				}
			}});
		});
	});
	
}
function tabChange2(ctrl,ctrled,stat,parent){  //tab切换函数
	stat=stat || false ;
	parent= parent || window.document;
	$(parent).each(function(){
		var $This=$(this);
		$This.find(ctrl).children().each(function(){
			$(this).bind({'click':function(){
				var p_index = $(this).index();
				$(this).addClass("current").siblings().removeClass("current");	
				var getbow=getBow();
				if(getbow!='IE6' && getbow!='IE7' && getbow!=''){
					if(stat)
						$This.find(ctrled).children().eq(p_index).fadeIn(500).siblings().fadeOut(500);
					else
						$This.find(ctrled).children().eq(p_index).show().siblings().hide();
				}else{
					$This.find(ctrled).children().eq(p_index).show().siblings().hide();
					
				}
			}});
		});
	});
	
}

function getBow(){//判断浏览器类型
	var Sys = {};
	var ua = navigator.userAgent.toLowerCase();
	var s;
	(s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
	(s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
	(s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
	(s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
	(s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

	//以下进行测试
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
//设为首页 < a onclick="SetHome(this,window.location)" > 设为首页 < /a>
function SetHome(sUrl) {
	if (document.all) { 
		document.body.style.behavior='url(#default#homepage)'; 
		document.body.setHomePage(sUrl); 
	} 
	else if (window.sidebar) { 
		if(window.netscape) { 
			try { 
				netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect"); 
			} 
			catch(e) { 
				alert("抱歉，您所使用的浏览器无法完成此操作。\n\n您需要手动将【"+sUrl+"】设置为首页。");
			} 
		} 
		var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components. interfaces.nsIPrefBranch); 
		prefs.setCharPref('browser.startup.homepage',sUrl);
	}else{
		alert("抱歉，您所使用的浏览器无法完成此操作。\n\n您需要手动将【"+sUrl+"】设置为首页。");
	}
}
// 加入收藏 < a onclick="AddFavorite(window.location,document.title)" >加入收藏< /a>
function AddFavorite(sURL, sTitle){
    try
    {
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e)
    {
        try
        {
            window.sidebar.addPanel(sTitle, sURL, "");
        }
        catch (e)
        {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}
var cookie={
	setRaw : function(key, value, options) {
        if (!cookie._isValidKey(key)) {
            return;
        }
        
        options = options || {};
        
        // 计算cookie过期时间
        var expires = options.expires;
        if ('number' == typeof options.expires) {
            expires = new Date();
            expires.setTime(expires.getTime() + options.expires);
        }
        
        document.cookie = key + "=" + value + (options.path ? "; path=" + options.path : "")
                + (expires ? "; expires=" + expires.toGMTString() : "")
                + (options.domain ? "; domain=" + options.domain : "") + (options.secure ? "; secure" : '');
				
    },
	getRaw : function(key) {
        if (this._isValidKey(key)) {
            var reg = new RegExp("(^| )" + key + "=([^;]*)(;|\x24)"), result = reg.exec(document.cookie);
            
            if (result) {
                return result[2] || null;
            }
        }
        return null;
    },
	_isValidKey : function(key) {
        
        return (new RegExp("^[^\\x00-\\x20\\x7f\\(\\)<>@,;:\\\\\\\"\\[\\]\\?=\\{\\}\\/\\u0080-\\uffff]+\x24"))
                .test(key);
    }
}




