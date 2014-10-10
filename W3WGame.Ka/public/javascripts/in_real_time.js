
/*
function inRealTime(_divClass, _ulClass){
    var hot_box = $(_divClass);
    var hot_list = $(_ulClass);
    var _li = hot_list.children("li");
    var timer;
    var _top = 0;
    var children_height = _li.eq(0).height();
    
    if(_ulClass==".hot-gift-list"){
    	children_height+=21;
    }else if(_ulClass==".new"){
    	children_height+=29;    
    }
    
    var scroll_height = _li.length * children_height;

    _li.clone().appendTo(hot_list);
    clearInterval(timer);
    hot_box.hover(
        function(){
            clearInterval(timer);
        },
        function(){
            timer = setInterval(function(){
                _top -= children_height;
                hot_list.animate({"top": _top +"px"},600,function(){
                    if(_top == -scroll_height){
                        _top = 0;
                        hot_list.css("top",_top+"px");
                    }
                });
            },2000);
        }
    ).trigger('mouseleave')
}
*/

/**
 * 只作用在首页
 * @param {} _divClass
 * @param {} _ulClass
 * @returns {} 
 */
function inRealTime(_divClass, _ulClass){
	var that = this;
	var nowIssueHtml =  $("#nowIssue").html();
	var size = $("#nowIssue li").size();	
	
	if(size<6){
		$("#newWarp").height(64*size);
		return;
	}
	
	var height = $("#newWarp").height();
	var html = "";
	if(height == 390){
		var minLength = 7;
	}else if(height == 511){
		var minLength = 9;
	}
	if(size < minLength-1){
		var length = Math.ceil((minLength-size)/size+1)+1;
	}else{
		var length = 2;
	}
	
	for(var i = 0; i < length; i++){
		html += nowIssueHtml;
	}
	
	var beyond = length*size - (minLength-1);
	
	$("#nowIssue").html(html);
	
	var top = 0;
	var scrollNum = 0;
	setInterval(function() {
		top -= 63;	
		$("#nowIssue").animate({ 
			top:top + "px"
		}, 2000, function(){
			scrollNum++;	
			if(scrollNum>size){	
				top = -63;
				scrollNum = 0;
				$("#nowIssue").css("top",top+"px");
			}
		});
		
	},2000);
	
}
