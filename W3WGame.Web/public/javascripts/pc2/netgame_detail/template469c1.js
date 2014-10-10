$(document).ready(function(){
	xTabMove('.focus-ctrl','.focus-img',{'parent':'.foucs-con','active':'current','mode':'fade','autoplay':'true'});
	xTabMove('.role-player-list>ul','.right-box',{'parent':'.game-role-ind','active':'current'});
	xTabMove('.tag-title','.list-con',{'parent':'.game-raiders-ind','active':'current'});
	xTabMove('.tag-title','.contain',{'parent':'.tab-relative-art','active':'current'});
	xTabMove('.inside-tag','.contain',{'parent':'.side-ctrl','active':'current'});
	xTabMove('.tag-title','.context-con',{'parent':'.right-news-con','active':'current'});
	var $getBow=getBow();
	//截图3D轮播
	(function(){
		$('.game-pic-ind').each(function(){
			var This=$(this);
			var li=This.find('.pic-con li');
			var meng=This.find('.meng-con');
			var length=li.length;
			var middle=Math.ceil(length /2 ) - 1;
			var lock=1;
			var temp=li.eq(0).find('img');
			var img = new Image();
			var style;
			img.onload = function(){
				var width=this.width;
				var height=this.height;
				if(width>=height){
					style=[{'left':'0','top':'50px','width':'300px','height':'200px','z-index':'5'},
						{'left':'120px','top':'0','width':'480px','height':'320px','z-index':'10'},
						{'left':'420px','top':'50px','width':'300px','height':'200px','z-index':'5'}];
					This.addClass('style1').removeClass('style2');
				}else{
					style=[{'left':'0','top':'80px','width':'195px','height':'300px','z-index':'5'},
						{'left':'164px','top':'0','width':'327px','height':'480px','z-index':'10'},
						{'left':'470px','top':'80px','width':'195px','height':'300px','z-index':'5'}];
					This.addClass('style2').removeClass('style1');
				}
				if(length==1){
					li.eq(0).css(style[1]);
					meng.hide();
					This.find('.ctrl').hide();
					return ;
				}
				init();
				This.find('.ctrl').click(function(){
					if(lock){
						if( $(this).hasClass('prev')){
							imgChange(-1);
						}else{
							imgChange(1);
						}
					}
				});
			}
			img.src=temp.attr('src');
			
			function init(){ //布局初始化
				li.each(function(i){
					var This=$(this);
					This.removeClass('current');
					if(i==(middle-1 + length)%length){
						This.css(style[0],100);
					}else if(i==middle){
						This.css(style[1],300);
						This.addClass('current');
					}else if(i==(middle+1 + length)%length){
						This.css(style[2],100);
					}else{
						This.hide();
					}
					
				});
			}
			function imgChange(toward){
				lock=0;
				var now=li.filter('.current');
				var next=(now.index()+toward + li.length)%li.length;
				meng.fadeOut(50);
				li.eq(next).css('z-index','10');
				li.each(function(i){
					var This=$(this);
					This.removeClass('current');
					if(i==(next-1 + length)%length){
						This.css(style[0],100);
						This.fadeIn();
					}else if(i==next){
						This.animate(style[1],300);
						This.addClass('current');
						setTimeout(function(){
							meng.fadeIn(400,function(){
								lock=1;
							});
						},100);
					}else if(i==(next+1 + length)%length){
						This.css(style[2],100);
						This.fadeIn();
					}else{
						This.fadeOut();
					}
				});
			}
		});
	})();
	(function(window){
		//滚动到页面固定位置
		var scroll_lock=true;
		var littNav=$('.littlt-fix-nav')
		var toTop=littNav.find('.to-top');
		var tagHeight=[];
		var iNow=-1;
		littNav.delegate('.togo','click',function(){
			if(scroll_lock){
				var scrollTag =$(this).attr("data-go");
				var scrollId = "#"+scrollTag;
				scroll_lock=false;
				click_scroll(scrollId);
			}
		});
		$(window).scroll(function(){
			var top=$(this).scrollTop();
				if(top<575){
					toTop.removeClass('show');
					toTop.removeClass('togo');
				}else{
					toTop.addClass('show');
					toTop.addClass('togo');
				}
		});
		function click_scroll(tag) {
			var scrollOffset = $(tag).offset();  //得到pos这个div层的offset
			var scrollTop =  scrollOffset.top - 44;
			
			$("body,html").animate({
				scrollTop: scrollTop //让body的scrollTop等于pos的top，就实现了滚动
			},500,function(){
				scroll_lock=true;
			});
		}
	})(window);
	(function(window){
		//头部图片
		var h=$('#header_img');
		var src=h.children().children('img:eq(0)').attr('src');
		h.css('backgroundImage','url('+src+')');
	})(window);
	(function(window){
		//用户反馈扫码
		var scroll_lock=true;
		var littNav=$('.littlt-fix-nav')
		var sugg=littNav.find('.suggest');
		var wei=sugg.find('.sugg-weixin');
		var time=null;
		sugg.bind({'mouseenter':function(){
			clearTimeout(time);
			wei.show();
		},'mouseleave':function(){
			time=setTimeout(function(){
				wei.hide();
			},200);
			
		}});
	})(window);
	(function(window){
		//游戏详情
		$('.game-raiders-ind').each(function(index,val){
			var li=$(this).find('.tag-title').children('li');
			var role_length=li.length;
			var width= parseInt(parseInt($(this).width()-2) / role_length -1);
			li.css({'width':width+'px'});
		});
	})(window);
	(function(){
		$('.down-yure').each(function(){
			var This=$(this);
			var count=This.find('.btn-con .btn').length;
			if(count>2){
				This.find('.des').removeClass('long');
			}
		});
	})();
	(function(){
		//礼包详情显示
		$('.game-gift-ind').delegate('.tips-con','mouseenter',function(){
			$(this).children('.tips').show();
		});
		$('.game-gift-ind').delegate('.tips-con','mouseleave',function(){
			$(this).children('.tips').hide();
		});
	})();
	(function(){
		if($('.game-role-ind').find('.news-list').length == 0){
			$('.game-role-ind').addClass('type2').removeClass('type1');
		}else{
			$('.game-role-ind').addClass('type1').removeClass('type2');
		}
		/* 职业介绍高度重置 */
		$('.role-player-list').each(function(index,val){
			var li=$(this).children('ul').children('li');
			var role_length=li.length;
			if(role_length<6){
				var height= parseInt(parseInt($(this).height()) / role_length -1);
				li.css({'height':height+'px','line-height':height+'px'});
			}
		});
		$('.left-box').each(function(index,val){
			var This=this;
			this.pre=$(this).find('.prev').eq(0);
			this.next=$(this).find('.next').eq(0);
			this.img_ul=$(this).find('.role-player-list').eq(0).children('ul');
			this.img_leg=$(this.img_ul).find('li').length;
			this.li_height=30;
			this.max=6;
			this.now=0;
			this.move_legth=3;
			this.status=false;
			this.pre.addClass('no');
			if(this.img_leg<this.max)
				this.next.addClass('no');
			this.img_move=function($this){
				if($($this).attr('class').match(/next/)){
					if(This.now + This.max < This.img_leg){
						if(This.now + This.max + This.move_legth > This.img_leg)
							This.now = This.img_leg - This.max;
						else 
							This.now+=This.move_legth ;
					}else return;
				}else{
					if(This.now!=0){
						if(This.now - This.move_legth < 0)
							This.now = 0;
						else 
							This.now-=This.move_legth;	
					}else return;
				}
				var move=This.li_height * This.now * -1;
				move=move+'px';
				This.img_ul.animate({'top': move },'fast');
				if(This.now<=0){
					This.pre.addClass('no');
				}else{
					This.pre.removeClass('no');
				}
				if(This.now + This.max >= This.img_leg){
					This.next.addClass('no');
				}else{
					This.next.removeClass('no');
				}
			}
			this.pre.bind({'click':function(){
				This.img_move(this);
			},'mouseenter':function(){
				if(This.now!=0 && !($(this).hasClass('no')) ){
					$(this).addClass('current');
				}
			},'mouseleave':function(){
				$(this).removeClass('current');
			}});
			this.next.bind({'click':function(){
				This.img_move(this);
			},'mouseenter':function(){
				if(This.now + This.max < This.img_leg && !($(this).hasClass('no')) )
					$(this).addClass('current');
			},'mouseleave':function(){
				$(this).removeClass('current');
			}});
		});
	})();
	(function(){
		//下载详细信息
		$('.down-yure').find('.more').bind({'mouseenter':function(){
			$(this).find('.tips').show();
		},'mouseleave':function(){
			$(this).find('.tips').hide();
		}});
	})();
	(function(){
		//热点新闻
		var detail_length=$('.detail-list').length;
		var detail_width=parseInt( 978 / detail_length ) -1;
		var h=0;
		$('.detail-list').each(function(){
			h=$(this).height() > h ? $(this).height() : h;
		});
		$('.detail-list').each(function(){
			this.style.cssText='width:'+detail_width+'px;height:'+h+'px';
		});
		$('.detail-tit').children().each(function(){
			this.style.cssText='width:'+detail_width+'px';
		});
	})();
	(function(window){
		/* 弹窗下载 */
		var pb_popup_yr=$('#pb_popup_yr');
		$('.code-show-yr').click(function(e){
			estop(e);
			pb_popup_yr.show();
			$('body').addClass('popup_of');
		});
		pb_popup_yr.find('.close').click(function(e){
			pb_popup_yr.hide();
			$('body').removeClass('popup_of');
		});
		pb_popup_yr.bind({'click':function(){
			$(this).hide();
			$('body').removeClass('popup_of');
		}});
		pb_popup_yr.find('.popup-yr').bind({'mouseenter':function(){
			pb_popup_yr.unbind();
		},'mouseleave':function(){
			pb_popup_yr.bind({'click':function(){
				$(this).hide();
				$('body').removeClass('popup_of');
			}});
		}});
		/* 二维码 */
		pb_popup_yr.find('.i-code').each(function(){
			var This=$(this);
			if($getBow=="IE6" || $getBow=="IE7" || $getBow=="IE8")
				This.append(xMan_qrcode({render: "table",width:180,height:180,correctLevel:0,text:This.attr('data-code')}));
			else{
				This.append(xMan_qrcode({render: "canvas",width:180,height:180,correctLevel:0,text:This.attr('data-code')}));
			}
		});
	})(window);
	(function(){
		//多包弹窗
		$(".close").click(function(){
			$("#pb_popup").hide();
			$('body').removeClass('popup_of');
		});
		$('#pb_popup').bind({'click':function(){
				$(this).hide();
				$('body').removeClass('popup_of');
		}});
		$('#pb_popup').find('.down-popup-side').bind({'mouseenter':function(){
			$('#pb_popup').unbind();
		},'mouseleave':function(){
			$('#pb_popup').bind({'click':function(){
				$(this).hide();
				$('body').removeClass('popup_of');
			}});
		}});
	}());
	(function(window){
		var link=$('#link_pop');
		if(link.length>0){
			var pop=$('.article-page').find('.pop-link');
			var top=parseInt(link.position().top) - parseInt(pop.eq(0).outerHeight(true)) - 10;
			var left=parseInt(link.position().left) + parseInt(link.outerWidth(true))/2;
			var time=null;
			pop.css({'left':left+'px','top':top +'px' });
			link.bind({'mouseenter':function(){
				clearTimeout(time);
				pop.show();
			},'mouseleave':function(){
				time=setTimeout(function(){
					pop.hide();
				},300);
			}});
			pop.bind({'mouseenter':function(){
				clearTimeout(time);
				pop.show();
			},'mouseleave':function(){
				time=setTimeout(function(){
					pop.hide();
				},300);
			}});
		}
	})(window);
	(function(window){
		/* 关注弹窗 */
		var call=$('#call_game');
		$('.call-pop').click(function(e){
			estop(e);
			call.show();
			$('body').addClass('popup_of');
		});
		call.find('.close').click(function(e){
			call.hide();
			$('body').removeClass('popup_of');
		});
		call.find('.cancle').click(function(e){
			call.hide();
			$('body').removeClass('popup_of');
		});
		call.bind({'click':function(){
			$(this).hide();
			$('body').removeClass('popup_of');
		}});
		call.find('.call_game_pop').bind({'mouseenter':function(){
			call.unbind();
		},'mouseleave':function(){
			call.bind({'click':function(){
				$(this).hide();
				$('body').removeClass('popup_of');
			}});
		}});
		/* 二维码 */
		call.find('.i-code').each(function(){
			var This=$(this);
			if($getBow=="IE6" || $getBow=="IE7" || $getBow=="IE8")
				This.append(xMan_qrcode({render: "table",width:150,height:150,correctLevel:0,text:This.attr('data-code')}));
			else{
				This.append(xMan_qrcode({render: "canvas",width:150,height:150,correctLevel:0,text:This.attr('data-code')}));
			}
		});
		$('.chongzi').find('.close').click(function(){
			$('.chongzi').hide();
		});
	})(window);
	//阻止事件冒泡
	function estop(e){
		if ( e && e.preventDefault ) 
			e.preventDefault(); 
		else
			window.event.returnValue = false; 
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
		else if (Sys.firefox) return '';
		else if (Sys.chrome) return '-webkit-';
		else if (Sys.opera) return '-o-';
		else if (Sys.safari) return '-a-';
		else return '';
	}
	
});