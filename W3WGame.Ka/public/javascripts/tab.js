function tab(arg){
		/**
		 * 实现tab切换
		 * @author 黄浩明
		 */
		var that = this;
		
		that.handle = arg.handle.children();
		that.main = arg.main.children();
		that.on_class = arg.on_class;
		that.none_class = arg.none_class;
		that.handle.hover(function(){
			that.handle.removeClass(that.on_class);
			$(this).addClass(that.on_class);
			that.index = $(this).index();
			that.main.addClass(that.none_class);
			that.main.eq(that.index).removeClass(that.none_class);
		}, function(){
			
		});
	
}
new tab({
	handle: $(".js-tab-head"),	
	  main: $(".js-tab-main"),
  on_class: "current",
none_class: "none"
});