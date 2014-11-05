function isNetGame(typeId){
   if(typeId==null)
       return false;
  if(typeId==14||typeId==15||typeId==16||typeId==19){
       return true;
      }
  return false;
}
function sizeFormat(fileSize){
     var flag = 0;
        var fileSizeStr = "";
        if (fileSize >= 1024) {
            flag = flag ^ 1;
        }

        if (fileSize >= 1048576) {
            flag = flag ^ 2;
        }

        if (fileSize >= 1073741824) {
            flag = flag ^ 4;
        }

        if ((flag & 1) > 0) {
            var _fileSize = fileSize;
            _fileSize = _fileSize / 1024;
            fileSizeStr = _fileSize.toFixed(1) + "KB";
        }

        if ((flag & 2) > 0) {
            var _fileSize = fileSize;
            _fileSize = _fileSize / 1048576;
            fileSizeStr = _fileSize.toFixed(1) + "M";
        }

        if ((flag & 4) > 0) {
            var _fileSize = fileSize;
            _fileSize = _fileSize / 1073741824;
            fileSizeStr = _fileSize.toFixed(1) + "GB";
        }
        return fileSizeStr;

}
    function show_win_gamefile(gameId,platformId,name,uploadtime,iosflag,typeId,statis_page,statis_category) {
	//将名字的空字符串去掉,测试发现名字有空时不能异步请求
	name=name.replace(' ','');
	   // jquery 异步调用服务器代码
		try {
			$.ajax({
				type: "get",
				dataType: "json",
				url: "/tpl/pc2/common/pop_win_gamefile_ajax.html",   //获取数据地址
				//data: {"type":$search_type.val()},//传手机类型参数
				data: {"gameId":gameId,"platformId":platformId,"name":name,"uploadtime" : uploadtime, "iosflag" : iosflag,"typeId":typeId,"statis_page":statis_page,"statis_category":statis_category},
				success: function(result){
				    
					//进行弹出框的显示
					 $("#pb_popup").find('.box-title').children('p').text(name);
					//int length=result.length;
					var lis="";
					if(iosflag==0){ //只有android多包
					   var f = result[0];
						 var  pack=f["k_"+gameId+"_"+platformId];
						 var  fp=pack.packageinfo;	
						  for(i=0;i<fp.length;i++) {
							var p = fp[i];
							var domain = "";
							
							lis += "<div class=\"down-con\">";
							 if(isNetGame(typeId))
							lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
							   if(typeId==17||typeId==18)
							lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
							if(statis_page != null){
								lis += " data-statis=\"" + statis_page+ "\"";
							}
							lis+= " class=\"popup-down\">"
							lis+= "<p class=\"name\">"+p.name+"</p>";
							//lis+= "<p class=\"size\">" + (p.fileSize / 1048576).toFixed(1) + "MB</p>";
							lis+= "<p class=\"size\">" + sizeFormat(p.fileSize) + "</p>";
							lis+= "</a>";
							lis+= "</div>";
						}
						if(fp.length>0){
						$('#popup-apple-con').hide();
						$('#popup-android-con').show();
						$("#popup-android").html(lis);
					  }else{
						$('#popup-android-con').hide();
					  }
					
					}
					else if (iosflag==2){ //只有苹果有多包  ,去除不会出现苹果多包的情况
					   var f = result[0];
						 var  pack=f["k_"+gameId+"_"+platformId];
						 var  fp=pack.packageinfo;	
						  for(i=0;i<fp.length;i++) {
							var p = fp[i];
							var domain = "";
							
							lis += "<div class=\"down-con\">";
							 if(isNetGame(typeId))
							lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
							   if(typeId==17||typeId==18)
							lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
							if(statis_page != null){
								//lis += " data-statis=\"text:bd_" + statis_page+ "_" + platformname + statis_prefix + gameId+ "\"";
								lis += " data-statis=\"" + statis_page+ "\"";
							}
							lis+= " class=\"popup-down\">"
							lis+= "<p class=\"name\">"+p.name+"</p>";
							//lis+= "<p class=\"size\">" + (p.fileSize / 1048576).toFixed(1) + "MB</p>";
							lis+= "<p class=\"size\">" + sizeFormat(p.fileSize) + "</p>";
							lis+= "</a>";
							lis+= "</div>";
						}
						if(fp.length>0){
						$('#popup-apple-con').hide();
						$('#popup-android-con').show();
						$("#popup-android").html(lis);
						$("#pop_sub_title_android").html("苹果平台下载");
					  }else{
						$('#popup-android-con').hide();
					  }
					
					}
				else{    //多平台
				   var f = result[0];
				   var  pack=f["k_"+gameId+"_"+2];
				  var  fp=pack.packageinfo;	
				  for(i=0;i<fp.length;i++) {
					var p = fp[i];
					var domain = "";
					
					lis += "<div class=\"down-con\">";
					 if(isNetGame(typeId))
					lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
					   if(typeId==17||typeId==18)
					lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
					if(statis_page != null){
						//lis += " data-statis=\"text:bd_" + statis_page+ "_" + platformname + statis_prefix + gameId+ "\"";
						lis += " data-statis=\"" + statis_page+ "\"";
					}
					lis+= " class=\"popup-down\">"
					lis+= "<p class=\"name\">"+p.name+"</p>";
					//lis+= "<p class=\"size\">" + (p.fileSize / 1048576).toFixed(1) + "MB</p>";
					lis+= "<p class=\"size\">" + sizeFormat(p.fileSize) + "</p>";
					lis+= "</a>";
					lis+= "</div>";
				 }
				 $('#popup-android-con').show();
				 $("#popup-android").html(lis);
				 //显示苹果
				   lis="";
				   f = result[1];
				 var  pack=f["k_"+gameId+"_"+3];
				 var  fp=pack.packageinfo;	
				  for(i=0;i<1;i++) {
					var p = fp[i];
					var domain = "";
					
					lis += "<div class=\"down-con\">";
					 if(isNetGame(typeId))
					lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/downs_" + gameId+"_3.html\"";
					   if(typeId==17||typeId==18)
					lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/downs_" + gameId+"_3.html\"";
					if(statis_page != null){
						//lis += " data-statis=\"text:bd_" + statis_page+ "_" + platformname + statis_prefix + gameId+ "\"";
					 lis += " data-statis=\"" + statis_page+ "\"";
					}
					lis+= " class=\"popup-down\">"
					lis+= "<p class=\"name\">"+p.name+"</p>";
					//lis+= "<p class=\"size\">" + (p.fileSize / 1048576).toFixed(1) + "MB</p>";
					lis+= "<p class=\"size\">" +  sizeFormat(p.fileSize) + "</p>";
					lis+= "</a>";
					lis+= "</div>";
				}
				$('#popup-apple-con').show();
				$("#popup-apple").html(lis);
				 
				}
					
				$("#pb_popup").show();
				$('body').addClass('popup_of');
			}		
		   });
		} catch(e) {
			console.log(e);
		} 
    }
