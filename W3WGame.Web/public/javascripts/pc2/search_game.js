(function(window,document){
	xTabMove('.one-tab-con','.text-tab-con',{'parent':'.game-recom-con','active':'current','mouse':'click'});
	xTabMove('.two-tab-con','.three-tab-con',{'parent':'.text-tab','active':'current'});
	xTabMove('.one-tab-con','.text-tab-con',{'parent':'.game-rank-con','active':'current','mouse':'click'});
	$('.game-rank-con .text-tab-con').find('.corner').each(function(i,obj){
		
		var left=i%10 * -55;
		var top=parseInt(i/10) * -55;
		var pst=left+'px '+top+'px';
		$(obj).css('background-position',pst);
	});
})(window,document)