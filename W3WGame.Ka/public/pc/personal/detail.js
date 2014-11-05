/**
 * 照样生效的初始化事件
 * @returns {} 
 */
function initValid(){
	//验证码相关事件
	//提交验证码
	$("#postValidCode").click(function(event){
		_postCode(event);
	});	  

	$("#validCodeText").keydown(function(event){
		if(event.keyCode == 13){ 
			_postCode(event);		
		}
	});	

	  //换一个图片
	  $("#validCodeA").click(function(event){
		  document.getElementById('validCode').src = "/validCode?time="+new Date().getTime();
		  event.preventDefault();
	  });
	  //换一个图片	  
	  $("#validCode").click(function(event){
		  document.getElementById('validCode').src = "/validCode?time="+new Date().getTime();
		  event.preventDefault();
	  });	
}

/**
 * 
 * @param {} event
 * @returns {} 
 */
function _postCode(event){
    var sceneId = $("#sceneId").val();
    var kaId = $("#kaId").val();
    var price = $("#price").val();
    var validCode = $("#validCodeText").val();
    
    if(validCode==null || validCode==''){
    	showCodeErrorHint();
    	return;
    }
	    
    var getUrl = '/personal/get.html?requestType=ajax&id='+sceneId+'&kaId='+kaId+
    	'&price='+price+'&validCode='+validCode+'&currentPageUrl='+currentPageUrl+"&getFrom=postCode";
    $.ajax({
		  url:getUrl,
		  type:'GET',
		  success:function(result){
			  var resJson = $.parseJSON($.trim(result));
			  if(resJson.status == "success"){
			      $("#codeBox").hide();
			      var codeList = resJson.parameterList;
				  var htmlStr = "<div class='code-box cf'><div class='code-copy code-pop'>";
				  
				  for(var i = 0 ; i < codeList.length; i++){
					  htmlStr +=  codeList[i] + " ";
				  }
				  htmlStr += "</div>";
				  if(codeList.length == 1){
				  	htmlStr += "<a href='javascript:void(0)' id='copyLink2' rel='"+ resJson.parameterList2 +"' onclick='codeCopy($(this))' class='y-copy-btn em'>复制卡号</a>";
				  	htmlStr += "<a href='javascript:void(0)' class='code-t em' onclick=\"$('#codeCon').show();\">二维码扫描</a></div>"
				  	htmlStr += "<div id='codeCon' class='codeCon' style='display:none;'>";
				  	htmlStr += "<img src='/qr?content="+ resJson.qrCodeStr +"'></div>";
				  }
				  var client9ling;
				  var lingcontent;
				  if(resJson.gameDownloadUrl != null){
				  	client9ling = "<a href='###' onclick='javascript:download9game();'>"
						+ "<span class='l-org'></span><span class='c-org'>下载游戏</span><span class='r-org'></span></a>";
				  	lingcontent = "<div><p>• 请尽快使用，否则会进入淘号</p><p>• 领到的号仅适用于w3w游戏游戏客户端，请先下载游戏</p></div>";	  
				  }
				  else{
					  client9ling = "<a href='/redirect?a3=pc_get_hint&type=9clientDown&redirectURL="+ pc_app_url +"?ch=KD_59' target='_blank'>"
							+ "<span class='l-org'></span><span class='c-org'>下载w3w游戏游戏中心</span><span class='r-org'></span></a>";
					  	lingcontent = "<div><p>• 请尽快使用，否则会进入淘号</p><p>• 使用w3w游戏游戏中心，礼包上架早知道，更有专属福利等职你</p></div>";	
				  }
				  $("#9clientDowloadling").html(client9ling);
				  $("#lingcontent").html(lingcontent);
				  $("#fetch_con").html(htmlStr);
				  $("#fechPopBox").show();
				  getSuccess = true;
			  }else if(resJson.status == "credentialGot"){
				  var codeList = resJson.parameterList;
				  var htmlStr = "<div class='code-box cf'><div class='code-copy code-pop'>";
				  
				  for(var i = 0 ; i < codeList.length; i++){
					  htmlStr +=  codeList[i] + " ";
				  }
				  htmlStr += "</div>";
				  
				  //只有一个码的情况才显示二维码
				  if(codeList.length == 1){
				  	htmlStr += "<a href='javascript:void(0)' id='copyLink2' rel='"+ resJson.parameterList2 +"' onclick='codeCopy($(this))' class='y-copy-btn em'>复制卡号</a>";
				  	htmlStr += "<a href='javascript:void(0)' class='code-t em' onclick=\"$('#codeCon').show();\">二维码扫描</a></div>"
				  	htmlStr += "<div id='codeCon' class='codeCon' style='display:none;'>";
				  	htmlStr += "<img src='/qr?content="+ resJson.qrCodeStr +"'></div>";
				  }
				  
				  //title
				  $("#credentialGot_title").html("您已使用手机领取过这个号：");
				  
				  $("#credentialGot_con").html(htmlStr);
				  $("#credentialGotPopBox").show();
				  getSuccess = true;					  
			  }else if(resJson.status == "mobileNoBind"){
			  	  var from = resJson.pageForm;
				  messageBindMobile(true, from);	  
			  }else if(resJson.status == "failure" 
					  && resJson.loginUrl != null){
				  window.location = resJson.loginUrl;
			  }else if(resJson.status == "needValidCode"){	//需要跑验证码
				  showCodeErrorHint();
				  document.getElementById('validCode').src = "/validCode?time="+new Date().getTime();
					document.getElementById('validCodeText').value='';
			  }else{
				  $("#hint_msg").empty().html(resJson.message).show();
				  $("#messageBox").show();
			  }
		  }
	  });
	event.preventDefault();
}

/**
 * 显示验证码错误的提示
 * @returns {} 
 */
function showCodeErrorHint(flag){
	if(false==flag){
		document.getElementById('errorHint').style.display="none";	
	}else{
		document.getElementById('errorHint').style.display="";	
	}
}

/**
 * 隐藏所有弹窗
 * @returns {} 
 */
function hideAllBox(){
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
	$('#requestPopCredentialBox').hide();
	$('#credentialGotPopBox').hide();
	$('#downloadBox').hide();
	$('#codeBox').hide();
	$('#clientbookPopBox').hide();
}