$(function(){
	$(window).scroll(function(event){
        if($(this).scrollTop() > 160){
            if($(".backTop").css('display') == 'none'){
                $(".backTop").show();
            }
        }else{
            $(".backTop").hide();
        }
	})
	$(".backTop").click(function(){
	  	$('body,html').animate({scrollTop:0},1000);
		return false;
	});
	
})