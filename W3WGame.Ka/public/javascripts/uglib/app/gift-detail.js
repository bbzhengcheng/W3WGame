define("/public/javascripts/uglib/app/gift-detail",["../module/global/pub-header","../module/page-scroll"],function(a){a("../module/global/pub-header"),a("../module/page-scroll"),$(".tab-list li").mouseover(function(){$(this).addClass("on").siblings().removeClass("on");var a=$(".tab-list li").index(this);$(".tab-info-box").children(".tab-main").eq(a).removeClass("fn-none").siblings().addClass("fn-none")})}),define("uglib/module/global/pub-header",[],function(){!function(){for(var a={getByClass:function(a,b){for(var c=a.getElementsByTagName("*"),d=[],e=new RegExp("\\b"+b+"\\b","i"),f=0;f<c.length;f++)e.test(c[f].className)&&d.push(c[f]);return d},addClass:function(a,b){if(a){if(a.className){for(var c=a.className.split(" "),d=!1,e=0;e<c.length;e++)if(c[e]===b){d=!0;break}return d||(a.className+=" "+b),d}return a.className=b,!1}return!1},removeClass:function(a,b){if(!a||!a.className)return!1;for(var c=a.className.split(" "),d=!1,e=0;e<c.length;e++)if(c[e]===b){c.splice(e,1),d=!0;break}if(d){if(a.className="",c.length<1)return d;if(1==c.length)a.className=c[0];else if(c.length>1)for(var e=0;e<c.length;e++)a.className+=e==c.length-1?c[e]:c[e]+" "}return d},addEvent:function(a,b,c){if(a){if(a.addEventListener)return a.addEventListener(b,c,!1);if(a.attachEvent)return a.attachEvent("on"+b,c);a["on"+b]=c}}},b=document.getElementById("pub_9pcheader"),c=a.getByClass(b,"right-li"),d=a.getByClass(b,"web-site")[0],e=a.getByClass(b,"web-site-pop")[0],f=a.getByClass(e,"site-con"),g=0,h=0;h<c.length;h++)+function(b){a.addEvent(c[b],"mouseover",function(){a.addClass(c[b],"current")}),a.addEvent(c[b],"mouseout",function(){a.removeClass(c[b],"current")})}(h);a.addClass(d,"current");for(var h=0;h<f.length;h++)g=f[h].offsetHeight>g?f[h].offsetHeight:g;a.removeClass(d,"current");for(var h=0;h<f.length;h++)f[h].style.height=g+7+"px"}()}),define("uglib/module/page-scroll",[],function(){var a,b=$(".hot-box"),c=$(".hot-gift-list"),d=c.children("li"),e=0,f=d.eq(0).height()+21,g=d.length*f;clearInterval(a),d.length>4&&(d.clone().appendTo(c),b.hover(function(){clearInterval(a)},function(){a=setInterval(function(){e-=f,c.animate({top:e+"px"},600,function(){e==-g&&(e=0,c.css("top",e+"px"))})},2e3)}).trigger("mouseleave"))});