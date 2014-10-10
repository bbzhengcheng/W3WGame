$(function(){
	//头部热门搜索
	var hotLi=$(".hotSeach li").length;
	$(".hotSeach li").eq(hotLi-1).addClass("last");
})

//图片大小的缩放
window.onload=ImageFunction;
function ImageFunction() {
	$(".dateilImg img").each(function(){
		if($(this).width() > 630){
			$(this).width(630);
		}
	})
}
