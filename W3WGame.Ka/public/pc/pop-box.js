$(function(){
	//弹层
	$(".pop-mask").click(function(){
		$(".page-box-mod").show();
	})
	$(".closeMod").click(function(){
		$(".page-box-mod").hide();
	})

	$(".page-wrap-mask").click(function(){
		$(".page-box-mod").hide();
	})
})