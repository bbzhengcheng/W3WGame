$(document).ready(function(){
	(function(){
	var $search_con=$('.search-con:eq(0)');
	var $search_text=$('.search-text:eq(0)');
	var $result_list=$('#result_list');
	var $search_type=$('#search_type');
	var andriudHtml='http://android.w3wgame.com/game/downs_';
	var iosHtml='http://ios.w3wgame.com/game/downs_';
	var wwwHtml='http://www.w3wgame.com/game/downs_';
	var detailHtml='http://ng.w3wgame.com/game/detail_';
	var initWord=$.trim($search_text.val());
	var lock=0;
	var blur=1;
	/* 搜索框 文本框 */
	$search_text.bind({
		'focus':function(){
			$(this).css('color','#333');
			if($(this).val()==initWord){
				$(this).attr('value','');
			}
			if( $.trim($search_text.val()).length >= 1){
				$result_list.show();
			}else{
				$result_list.hide();
			}
		},'keyup':function(e){
			if($.trim($(this).val())!=''){
				search_think(e);
			}else{
				$(this).parent().children('.result-list').hide();
			}
		},'blur':function(){
			var This=$(this);
			if(This.val()==''){
				setTimeout(function(){
					This.css('color','#a8a8a8').val(initWord);
				},300);
			}
			lock=0;
			if(blur){
				$result_list.hide()
			}
		}
	});
	$search_con.bind({'mouseenter':function(){
		blur=0;
	},'mouseleave':function(){
		blur=1;
	}});
	$("#search-form").bind({
		'submit':function(e){
			if($.trim($search_text.val())==""){
				return false;
			}
			if(lock){
				window.open ($result_list.children(".current:eq(0)").find('.name a')[0].href,'newwindow');
				return false;
			}
		}
	});
	/* 搜索框 文本框 列表*/
	$result_list.delegate('li','mouseup',function(){
		window.open ($(this).find('.name a')[0].href,'newwindow');
		setTimeout(function(){
			$result_list.hide();
		},200);
		lock=0;
	});
	$result_list.delegate('a','mouseup',function(e){
		e.stopPropagation();
		$result_list.hide();
	});
	$result_list.delegate('li','mouseenter',function(){
		$(this).addClass('current').siblings().removeClass('current');
	});
	function search_think(event){
		var key=$.trim($search_text.val());
		if( key.length >= 1){
			$result_list.show();
		}else{
			$result_list.hide();
		}
		if(event.which==13){	//回车事件
			prevent(event);
		}else if(event.which<37 || event.which>40){		//除上下键以外的事件
			which_word();
		}else if (event.which==38){		//方向键上键的事件
			upDownCtrl('up');
		}else if (event.which==40){		//方向键下键的事件
			upDownCtrl('down');
		}
		function upDownCtrl(side){
			if( key.length >= 1){
				lock=1;
				prevent(event);
				var child=$result_list.children();
				var length=child.length;
				var now=child.filter(".current").index();
				if(side==="up"){
					if(now>=0){
						next=(now-1+length) % length;
					}else{
						next=length-1;
					}
				}else if(side==="down"){
					if(now>=0){
						next=(now+1) % length;
					}
					else{
						next=0;
					}
				}
				$search_text.val(child.eq(next).find('.name a').attr('title'));
				child.eq(next).addClass('current').siblings().removeClass("current");
			}
		}
		function which_word(){
			if( key.length >= 1 && key.length<=15){
				// jquery 异步调用服务器代码
				try {
					$.ajax({
						type: "get",
						dataType: "json",
						url: "/suggest4pc.html",   //获取数据地址
						data: {"kwd":key,limit:10,columnId:2002142},
						success: function(result){
							$result_list.html('');
							successFun(result);
						}
				   });
				} catch(e) {
					console.log(e)
				} 
			}else{
				return false;
			}
		}
		function successFun(result){
			lock=0;
			for(var i in result) {
				if(i<8){ //限制最多输出8个结果
					if(result[i].downType==""){
						$result_list.append(shortHtml(result[i]));
					}else{
						$result_list.append(longHtml(result[i]));
					}
				}
				else{
					break;
				}
			}
		}
		function longHtml(data){
			var reg=new RegExp($search_text.val(),"ig")
			var name=data.name.replace(reg,"</b>"+$search_text.val()+"<b>");
			name='<b>'+name+'</b>';
			var html='';
			html+='<li class="spec">';
			html+='<div class="img">';
			html+='<a href="'+data.detailUrl+'" data-statis="text:logo_p_search_searchbox_' + data.gameid + '" title="'+data.name+'"><img src="http://image.game.uc.cn'+data.image+'" /></a>';
			html+='<span class="radius48"></span>';
			html+='</div>';
			html+='<div class="name"><a href="'+data.detailUrl+'" data-statis="text:logo_p_search_searchbox_' + data.gameid + '" title="'+data.name+'">'+name+'</a></div>';
			html+='<div class="sr-btn">';
			if(data.downType==2){
				if(data.typeId==14||data.typeId==15||data.typeId==16||data.typeId==19){
					html+='<a href="'+wwwHtml+data.gameid+'_2.html" class="down android" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">安卓下载</a>';
				} else {
					html+='<a href="'+andriudHtml+data.gameid+'_2.html" class="down android" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">安卓下载</a>';
				}
			}else if(data.downType==3){
				if(data.typeId==14||data.typeId==15||data.typeId==16||data.typeId==19){
					html+='<a href="'+wwwHtml+data.gameid+'_3.html" class="down apple" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">苹果下载</a>';
				} else {
					html+='<a href="'+iosHtml+data.gameid+'_3.html" class="down apple" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">苹果下载</a>';
				}
			}else if(data.downType==1){
				if(data.typeId==14||data.typeId==15||data.typeId==16||data.typeId==19){
					html+='<a href="'+wwwHtml+data.gameid+'_2.html" class="down android" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">安卓下载</a>';
					html+='<a href="'+wwwHtml+data.gameid+'_3.html" class="down apple" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">苹果下载</a>';
				} else {
					html+='<a href="'+andriudHtml+data.gameid+'_2.html" class="down android" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">安卓下载</a>';
					html+='<a href="'+iosHtml+data.gameid+'_3.html" class="down apple" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">苹果下载</a>';
				}
			}else if(data.downType==4){
				html+='<a href="'+data.detailUrl+'" class="down android" data-statis="text:bt_p_search_searchbox_' + data.gameid + '">进入专区</a>';
			}
			html+='</div>';
			html+='</li>';
			return html;
		}
		function shortHtml(data){
			var reg=new RegExp($search_text.val(),"ig")
			var name=data.name.replace(reg,"</b>"+$search_text.val()+"<b>");
			name='<b>'+name+'</b>';
			var html='';
			html+='<li><div class="name"><a href="'+data.detailUrl+'" title="'+data.name+'">'+name+'</a></div></li>';
			return html;
		}
		function prevent(e){
			if ( e && e.preventDefault ) 
				e.preventDefault(); 
			else
				window.event.returnValue = false;
		}
	}
	}());
});