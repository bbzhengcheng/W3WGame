/**
 * 手机号验证功能,兼容Personal/detail.html页面

 */
var currentUrl = encodeURI(document.location.href);	//当前地址currentPageUrl这个变量命名在页面上有使用。所以要换个名字。
$(function(){
  	  var wait = 60;
	  //获取验证码
	  $("#getVerifyCode").click(function(event){
		  var mobileVerifyUrl = $("#mobileVerifyUrl").val();
		  var mobile = $("#mobile").val();
		  
		  if(mobile.length==0){
		  	  $("#mobile-err").html("请输入手机号码");
		  	  $("#vercode-err").empty();
              return false;
		  }
		  
		  if(!checkMobile(mobile)){
			  $("#mobile-err").html("请输入正确的手机号码");
			  $("#vercode-err").empty();
			  return false;
		  }else{
	        	$("#mobile-alert").css('display','block');
	      }
		  
		  var verifycode = $("#verifycode").val();
		  var captcha = $("#captcha").val();
		  captcha = "获取验证码";
		  $("#mobile-err").empty();
		  $("#vercode-err").empty();
		  $("#btnGetVCode").html("再次发送");
		  $("#getCodeAgainDiv").html("再次发送");
          $("#getCodeDiv").hide();
          $("#getCodeAgainDiv").show();
		  $.ajax({
			  url:mobileVerifyUrl,
			  type:'POST',
			  data:{
			  	mobile:mobile,
			  	requestType:'ajax',
			  	verifycode:verifycode,
			  	captcha:captcha,
			  	rtnUrl:currentUrl,
			  	currentPageUrl:currentUrl
			  	},
			  success:function(result){
				  var resJson = $.parseJSON($.trim(result));
				  if(resJson.merror != ""){
					  $("#mobile-err").empty().html(resJson.merror);
				  }
				  if(resJson.verror != ""){ 
					  $("#vercode-err").empty().html(resJson.verror);
				  }
				  
				  if(resJson.status != "" && resJson.status==5000611){
				  	  wait = 60;
					  time();
				  }
				  else{
				  	  wait = 5;
                      time();
				  }
			  }
		  });
	  });
	  
	  
	  //提交验证表单
	  $("#submitVerifyCode").click(function(event){
		  var mobileVerifyUrl = $("#mobileVerifyUrl").val();
		  var mobile = $("#mobile").val();
		  var verifycode = $("#verifycode").val();
		  
		  if(mobile.length==0){
              $("#mobile-err").html("请输入手机号码");
              $("#vercode-err").empty();
              return false;
          }
          
          if(!checkMobile(mobile)){
              $("#mobile-err").html("请输入正确的手机号码");
              $("#vercode-err").empty();
              return false;
          }
          
          if(verifycode.length==0){
        	  $("#mobile-err").empty();
              $("#vercode-err").html("请输入验证码");
              return false;
          }
		  
		  var captcha = $("#captcha").val();
		  $("#mobile-err").empty();
		  $("#vercode-err").empty();
		  $.ajax({
			  url:mobileVerifyUrl,
			  type:'POST',
			  data:{mobile:mobile,requestType:'ajax',verifycode:verifycode,captcha:captcha,rtnUrl:currentUrl,currentPageUrl:currentUrl},
			  success:function(result){
				  var resJson = $.parseJSON($.trim(result));
				  if(resJson.merror != ""){
					  $("#mobile-err").empty().html(resJson.merror);
				  }
				  if(resJson.verror != ""){ 
					  $("#vercode-err").empty().html(resJson.verror);
				  }
				  
				  if(resJson.pass != "" && resJson.pass == true){
					  $("#mobileVerifyBox").hide();
					  $("#resultDiv").click(function(){
						  window.location.href=resJson.rtnUrl;
					  });
					  $("#hint_msg").empty().html(resJson.merror).show();
					  $("#messageBox").show();
					//游戏关注页面更换手机，需要验证手机成功后才设置通知
					  if($("#page").val() == "gameFollow"){
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
					  }
				  }
				  
			  }
		  });
	  });
	  //关闭
	  $("span.close").click(function(){
		  $("#requestPopBox").hide();
		  $("#qrCodeBox").hide();
		  $("#taoPopBox").hide();
		  $("#guildPopBox").hide();
		  $("#confirmPopBox").hide();
		  $('#fechPopBox').hide();
		  $('#messageBox').hide();
		  $('#bookPopBox').hide();
		  $('#mobileCheckBox').hide();
		  $('#mobileVerifyBox').hide();
		  $('#cancelFollowPopBox').hide();
	    $('#followResultPopBox').hide();
	    $('#followPopBox').hide();
	    $('#guildPopBox').hide();
	  });
	  
	  $("a.closeLink").click(function(event){
		    $('#messageBox').hide();
			$('#requestPopBox').hide();
			$('#confirmPopBox').hide();
			$('#fechPopBox').hide();
			$('#taoPopBox').hide();
			$('#qrCodeBox').hide();
			$('#guildPopBox').hide();
			$('#bookPopBox').hide();
			$('#mobileCheckBox').hide();
			$('#mobileVerifyBox').hide();
			$('#cancelFollowPopBox').hide();
			$('#followResultPopBox').hide();
			$('#followPopBox').hide();
			$('#guildPopBox').hide();	
				  
		  event.preventDefault();
	  });
	  
	  $("#mobile").focus(function(){  
         $("#mobile-err").empty();
         $("#vercode-err").empty();
      }).blur(function(){
          if($(this).val().length==0){
              $("#mobile-err").html("请输入手机号码");
              return false;
          }
          
          if(!checkMobile($(this).val())){
              $("#mobile-err").html("请输入正确的手机号码");
              return false;
          }
      })
	  
		function time() {
		    if (wait == 0) {
		    	$("#getCodeAgainDiv").hide();
		    	$("#getCodeDiv").show();
		        wait = 60;
		    } else {
		    	$("#getCodeAgainDiv").html("再次发送(" + wait + ")");
		        $("#getCodeDiv").hide();
		        $("#getCodeAgainDiv").show();
		        wait--;
		        setTimeout(function() {
		            time();
		        }, 1000);
		    };
		}
		
		/**
		 * 检查手机号码合法性
		 */
		function checkMobile(mobile){
			regr = /^1[3,4,5,7,8]{1}\d{9}$/;
			if(regr.test(mobile)){
				return true;
			}
			else{
				return false;
			}
		}
});