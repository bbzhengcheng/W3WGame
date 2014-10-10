new tab({
	handle: $(".tab_role"),	
	  main: $(".main_role"),
  on_class: "current",
none_class: "none"
});


$(function(){
	//列表不同状态切换
	$(".js-rank li").mouseover(
		function(){
			$(this).addClass("g-current").siblings().removeClass("g-current");
		}
	);
	//列表不同状态切换 --end

	/**模拟checkbox**/
	// $(".checkbox").click(
	// 	function(){
	// 		if($(this).hasClass("yes-check"))
	// 		{
	// 			$(this).removeClass("yes-check");
	// 		}
	// 		else
	// 		{
	// 			$(this).addClass("yes-check")
	// 		}
	// 	}
	// )
})


