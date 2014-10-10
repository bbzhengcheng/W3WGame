
function ChangeImg(arg){
	/**
	 * 实现首页图片轮换
	 * @author 黄浩明
	 */
	var that = this;
	that.index = 0;
	that.main = arg.main.children();
	that.title = arg.title.children();
	that.title.eq(0).addClass("show-wrap");
	that.main_p = arg.main;
	that.handle_p = arg.handle;
	that.on_class = arg.on_class;
	that.time = arg.time;
	that.num = that.main.length;
	
	that.bar_index = 0;
	that._echoSpanNav(that.num);
	that.handle = arg.handle.children();
	that.bar_num = Math.ceil(that.handle.length / 4);
	that.main.hide();
	that.main.eq(0).show();
	that.handle_p.width(88*that.num);
	if(that.num > 4){
		that.prev.click( function () { 
			that._barPrev();
		});
		that.next.click( function () {
			that._barNext();
		});		
	}
	that.handle.hover(function() {
		if(that.index != $(this).index()){		
			that.index = $(this).index();
			that._goNum(that.index);
		}
		clearInterval(that.auto_change);
	}, function(){
		that._autoChange();
	});
	that.main.hover(function() {
		clearInterval(that.auto_change);
	}, function() {
		that._autoChange();
	});
	that._autoChange();
	
}


ChangeImg.prototype={
	_autoChange: function() {
		var that = this;
		that.auto_change = setInterval(function() {
			that.main.addClass(that.none_class);
			if(that.index + 1 != that.num){
				that.index +=1;
			}else{
				that.index = 0;
			}
			that._goBarNum(Math.floor(that.index / 4));		
			that._goNum(that.index);
		},that.time);
	},
	_goNum: function(n) {
		var that = this;
		if(!that.main.eq(n).is(":animated")){
			that.main.stop().fadeOut();
			that.main.eq(n).stop().fadeIn();
		}
		that.title.removeClass("show-wrap");		
		that.title.eq(n).addClass("show-wrap");
		that.handle.removeClass(that.on_class);
		that.handle.eq(n).addClass(that.on_class);
		that._n = n;
	},
	_echoSpanNav: function(n) {
		var that = this;
		var h='';
		for(i=1;i<n;i++){
			h+='<li class=""><img src='+that.main.eq(i).find("img").attr("src")+' class="img"><span class="mod-wrap"></span></li>';
		}
		var bar_on = '<li class="current"><img src='+that.main.eq(0).find("img").attr("src")+' class="img"><span class="mod-wrap"></span></li>'
		that.handle_p.html(bar_on + h);
	},
	_goBarNum: function(n) {
		var that = this;
		that.bar_index = n;
		var left = n * -296 ;
		that.handle_p.animate({left: ''+left+'px'}, "slow");
	}
	
}
new ChangeImg({
		  main: $("#js-img-box"),
		handle: $("#js-samll-pic"),	
		 title: $("#js-game-title"),
	  on_class: "current",
		  time: 4000
	});


