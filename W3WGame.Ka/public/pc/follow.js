/**
 * 游戏关注功能,兼容RelaGame/detail.html和GameFollow/myfollow.html两个页面
 */
var currentPageUrl = encodeURIComponent(document.location.href);
var gameId;

//获取判定绑定手机的来源
var getFrom = function(urlStr){
		if(urlStr == null){
			return ;
		}
		var arr = urlStr.split('&');
		var from;
		for(var i=0; i< arr.length; i++){
				if(arr[i].indexOf("from=") != -1){
					from = arr[i].substring(arr[i].indexOf("from=")+5);
					break;
				}
		}
		return from;
	}
		
$(function(){
	//关注游戏，兼容动态绑定
	$(".follow-info").on('click','a[id^=followLink]',function(event){
		if($("#from").val() == "myfollow"){
			gameId = $(this).attr("id").split('-')[1];
		}else{
			gameId = $("#gameId").val();
		}
		follow();
		event.preventDefault();
	});
	//列表中的链接，RelaGame/detail.html
	
	
	
	
	function follow(){
		var followUrl = $("#followUrl").val();
		var noticeUrl = $("#noticeUrl").val() + "?isSms=1&isRedirect=1";
		$.ajax({
			  url:followUrl ,
			  type:'POST',
			  data:{gameId:gameId,requestType:'ajax',currentPageUrl:currentPageUrl},
			  success:function(result){
				  var resJson = $.parseJSON($.trim(result));
				  if(resJson.status == "success"){
					  var msg = "";
					  var mobileStatus = resJson.mobileStatus;
					  var from = getFrom(resJson.changeMobileLink);
					  var followBtnTxt = "";
					  if(mobileStatus == 1){//绑定手机
						  msg = "添加礼包提醒成功！如有礼包上架、开服开测等信息，您会在第一时间获取站内消息通知，";
					  	  msg += "并可以选择接收短信提醒。您已绑定手机，请确认是否用该手机号接收提醒:";
					  	  msg += "<span class='em'>"+resJson.mobile+"</span> | <a href='javascript:void(0)' id='changeMobileLink'class='link'>更换号码</a>";
					  	  followBtnTxt = "确认";
					  }else{
						  msg = "添加礼包提醒成功！如有礼包上架、开服开测等信息，您可以第一时间获取站内消息通知，并可以选择：";
						  followBtnTxt = "验证手机并接收短信提醒";
						  $("#followSubmit").attr("type",2);
						  
						  //分析绑定手机的状况，方便智能显示提示语。
						  if(from == "get" || from == "request"){
							  $("#mobileVerifyMsg").html("就差一步啦，领号前需要验证手机号码");
						  }else if(from == "notice"){
							  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
						  }else if(from == "changeMobile"){
							  $("#mobileVerifyMsg").html("验证通过后，您将使用新验证的手机号码接收提醒");
						  }else{
							  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
						  }
					  }
					  $("#followMsg").html(msg);
					  $("#followBtn").text(followBtnTxt);
					  
					  //替换关注为取消关注
					  if($("#from").val() == "myfollow"){
						  var cancelFollowLink = "cancelFollowLink-"+gameId;
						  $("#followDiv-"+gameId).html('<a href="javascript:void(0);" id="'+cancelFollowLink+'" class="btn-follow-dis">取消提醒</a>');
						  $("#followPopBox").show();
						  $("#followLink1").hide();
						  $("#followLink").hide();
						  
					  }else{
						  $("#followDiv").html('<a href="javascript:void(0);" id="cancelFollowLink" class="btn-white-high">取消提醒</a>');
						  $("#followPopBox").show();
						  $("#followLink1").hide();
						  $("#followLink").hide();
					  }
					  if($("#totalCount").val() == 0){
						  $("#followScene1").hide();
						  $("#followScene").show();
					  }
				  }else{
					  $("#followResultMsg").html(resJson.message);
					  $("#followResultPopBox").show();
				  }
			  }
		  });
	}
	//取消关注,兼容动态绑定
	$(".follow-info").on('click',"a[id^=cancelFollowLink]",function(event){
		var msg = "取消礼包提醒后将接收不到礼包提醒，确认取消？";
		$("#cancelFollowMsg").html(msg);
		$("#cancelFollowPopBox").show();
		if($("#from").val() == "myfollow"){
			gameId = $(this).attr("id").split('-')[1];
		}else{
			gameId = $("#gameId").val();
		}
		$("#cancelFollowSubmit").unbind('click').bind('click',function(event){
			var cancelUrl = $("#cancelUrl").val();
			$.ajax({
				  url:cancelUrl,
				  type:'POST',
				  data:{gameId:gameId,requestType:'ajax',currentPageUrl:currentPageUrl},
				  success:function(result){
					  var resJson = $.parseJSON($.trim(result));
					  if(resJson.status == "success"){
						//替换取消关注为关注
						$("#cancelFollowPopBox").hide();
						$("#cancelFollowLink-"+gameId).hide();
						$("#followLink1").show();
						var followLink = "followLink-"+gameId;
						if($("#from").val()== "myfollow"){
							document.location.reload();
						}else{
							$("#followDiv").html('<a href="javascript:void(0);" id="'+followLink+'" class="btn-white-high"><i class="add-ico"></i>礼包提醒</a>');
							if($("#totalCount").val() == 0){
								$("#followScene1").show();	
								  $("#followScene").hide();
							  }
						}
					  }else{
						  $("#cancelFollowPopBox").hide();
						  $("#followResultMsg").html(resJson.message);
						  $("#followResultPopBox").show();
					  }
				  }
				 });
			event.preventDefault();
		});
		event.preventDefault();
	});
	//存号箱-关注游戏设置短信提醒
	$("a[id^=setSmsLink]").click(function(event){
		var isSms = $(this).attr("value");
		gameId = $(this).attr("id").split('-')[1];
		if(isSms == 1){//设置接收短信
			checkMobile();
		}else{//取消接收短信
			setNotice(gameId,0);
		}
		event.preventDefault();
	});
	
	
	//接收短信
	$("#followSubmit").click(function(event){
		//手机没绑定，打开绑定手机页面并设置通知
		if($(this).attr('type') == 2){
			$("#followPopBox").hide();
			
			//清空初始值
		    $("#mobile").val("");
		    $("#mobile-err").empty();
	        $("#verifycode").val("");
	        $("#vercode-err").empty();
	        
	        //$("#mobileVerifyMsg").html();
	        
			//弹出手机验证层
			$("#mobileVerifyBox").show();
			//设置通知
			//setNotice(gameId,1);
		}else{
			setNotice(gameId,1);
		}
		//event.preventDefault();
	});
	
	//检查手机状态,只有存号箱使用
	function checkMobile(){
		var checkMobileStatusUrl = $("#checkMobileStatusUrl").val() + "?requestType=ajax&currentPageUrl="+currentPageUrl;
		$.ajax({
		  url: checkMobileStatusUrl,
		  type:'GET',
		  success:function(result){
			  var resJson = $.parseJSON($.trim(result));
			  var msg = "";
			  var mobileStatus = resJson.mobileStatus;
			  
			  var followBtnTxt = "";
			  var from = getFrom(resJson.changeMobileLink);
			  //分析绑定手机的状况，方便智能显示提示语。
			  if(from == "get" || from == "request"){
				  $("#mobileVerifyMsg").html("就差一步啦，领号前需要验证手机号码");
			  }else if(from == "notice"){
				  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
			  }else if(from == "changeMobile"){
				  $("#mobileVerifyMsg").html("验证通过后，您将使用新验证的手机号码接收提醒");
			  }else{
				  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
			  }
			 if(resJson.status == 'success'){
				  if(mobileStatus == 1){//绑定手机
					  msg = "您已绑定手机，请确认是否用该手机号接收提醒:";
				  	  msg += "<span class='em'>"+resJson.mobile+"</span> | <a href='javascript:void(0)' id='changeMobileLink' class='link'>更换号码</a>";
				  	  followBtnTxt = "确认";
				  }else{
					  msg = "如有礼包上架、开服开测等信息，您可以第一时间获取站内消息通知，还可以选择:";
					  followBtnTxt = "验证手机并接收短信提醒";
					  $("#followSubmit").attr("type",2);
				  }
				  $("#followMsg").html(msg);
				  $("#followBtn").text(followBtnTxt);
				  $("#followPopBox").show();
			 }else{
				 $("#followResultMsg").html(resJson.message);
				  $("#followResultPopBox").show();
			 }
		  }
		 });
	}
	/**
	 * 更换手机，先设置短信通知，后以新窗口打开手机绑定页面
	 */
	$("#followMsg").on('click','#changeMobileLink',function(event){
		$("#followPopBox").hide();
		
		//清空初始值
	    $("#mobile").val("");
	    $("#mobile-err").empty();
        $("#verifycode").val("");
        $("#vercode-err").empty();
        //修改提示语
        $("#mobileVerifyMsg").html("验证通过后，您将使用新验证的手机号码接收提醒");
		//弹出手机验证层
		$("#mobileVerifyBox").show();
		
		if($("#from").val() == "myfollow"){
		  	//存号箱
			$("#setSmsLink-"+gameId).text("取消短信提醒");
			$("#setSmsLink-"+gameId).attr("value","0");
			$("#setSmsLink-"+gameId).attr("class","btn-follow-dis");
		}else{
			gameId = $("#gameId").val();
		}
		//设置通知
		 setNotice(gameId,1);
		 //更换手机已经设置通知，在verifymobile.js中不需要重复设置
		 $("#page").val("");
	});
	
	
	 //关闭
	  $("span.close").click(function(event){
		  $("#followResultPopBox").hide();
		  $("#followPopBox").hide();
		  $("#cancelFollowPopBox").hide();
	  });
	  $("a.closeLink").click(function(event){
		  $("#followResultPopBox").hide();
		  $("#followPopBox").hide();
		  $("#cancelFollowPopBox").hide();
		  
		  event.preventDefault();
	  });
});

//礼包提醒提示语有关
function followNote(totalCount,isFollow){
	if(totalCount.val()==0){
		if(isFollow.val()=="true"){
			$("#followScene").show();
		}
		else{
			$("#followScene1").show();
		}
	} 	
}

//设置短信通知
function setNotice(gameId,isSms){
	var noticeUrl = $("#noticeUrl").val();
	$.ajax({
	  url: noticeUrl ,
	  type:'POST',
	  data:{gameId:gameId,isSms:isSms,requestType:'ajax',currentPageUrl:currentPageUrl},
	  success:function(result){
		  var resJson = $.parseJSON($.trim(result));
		  var from = getFrom(resJson.changeMobileLink);
			  //分析绑定手机的状况，方便智能显示提示语。
			  if(from == "get" || from == "request"){
				  $("#mobileVerifyMsg").html("就差一步啦，领号前需要验证手机号码");
			  }else if(from == "notice"){
				  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
			  }else if(from == "changeMobile"){
				  $("#mobileVerifyMsg").html("验证通过后，您将使用新验证的手机号码接收提醒");
			  }else{
				  $("#mobileVerifyMsg").html("接收短信提醒需要验证手机号码");
			  }
			  
		  if(resJson.status == "success"){
			var mobileStatus = resJson.mobileStatus;
			
			var msg = "";
		   	if(mobileStatus == 1){//已绑定手机节奏
		   		msg = "设置成功！您将会在第一时间接收到重要礼包上架和开服开测信息，";
		   		msg += "请留意站内和短信提醒。可在";
		   		msg += "<a  href='"+$('#kaBoxUrl').val()+"'>存号箱</a>对礼包提醒进行管理。"
		   		if($("#from").val() == "myfollow"){
		   			if(isSms == 0){
		   				msg = "取消短信提醒成功，您有需要时可以继续设置短信提醒。";
		   				$("#setSmsLink-"+gameId).text("设置短信提醒");
		   				$("#setSmsLink-"+gameId).attr("value","1");
		   				$("#setSmsLink-"+gameId).attr("class","btn-phone");
		   			}else{
		   				msg = "设置成功！您将会在第一时间接收到重要礼包上架和开服开测信息，";
				   		msg += "请留意站内和短信提醒。";
		   				$("#setSmsLink-"+gameId).text("取消短信提醒");
		   				$("#setSmsLink-"+gameId).attr("value","0");
		   				$("#setSmsLink-"+gameId).attr("class","btn-follow-dis");
		   			}
		   		}
		   		$("#followResultMsg").html(msg);
		   		$("#followPopBox").hide();
		   		$("#followResultPopBox").show();
		   		
		   	}else {
		   		if(isSms == 0){//取消设置
		   			msg = "取消短信提醒成功，您有需要时可以继续设置短信提醒。";
		   			$("#setSmsLink-"+gameId).text("设置短信提醒");
	   				$("#setSmsLink-"+gameId).attr("value","1");
	   				$("#setSmsLink-"+gameId).attr("class","btn-phone");
	   				$("#followResultMsg").html(msg);
	   				$("#followResultPopBox").show();
		   		}else{//设置
		   			$("#setSmsLink-"+gameId).text("取消短信提醒");
	   				$("#setSmsLink-"+gameId).attr("value","0");
	   				$("#setSmsLink-"+gameId).attr("class","btn-follow-dis");
		   		}
		   	}
		  }else{
			  $("#followResultMsg").html(resJson.message);
			  $("#followResultPopBox").show();
		  }
	  }
	 });
}