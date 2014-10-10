	(function(){
	var app={
		getByClass:function (oParent, sClass){
			var aEle=oParent.getElementsByTagName('*');
			var aResult=[];
			var re=new RegExp('\\b'+sClass+'\\b', 'i');
			for(var i=0;i<aEle.length;i++){
				if(re.test(aEle[i].className)){
						aResult.push(aEle[i]);
				}
			}
			return aResult;
		},
		addClass:function(elem, newClass){
			if(!elem) 
				return false;
			else if(!elem.className) {
				elem.className = newClass;
				return false; 
			}
			else {
				var ownClass = elem.className.split(" "), had = false;
				for(var i = 0; i < ownClass.length; i++){
					if(ownClass[i] === newClass){
						had = true;
						break;
					}
				}
				if(!had){
					elem.className += " " + newClass;
				}
				return had;
			}
		},
		removeClass : function(elem, oneClass){
			if(!elem || !elem.className) return false;
			var ownClass = elem.className.split(" "),
				had = false;
			for(var i = 0; i < ownClass.length; i++){
				if(ownClass[i] === oneClass){
					ownClass.splice(i, 1);
					had = true;
					break;
				}
			}
			if(had){
				elem.className = "";
				if(ownClass.length < 1){
					return had;
				}else if(ownClass.length == 1){
					elem.className = ownClass[0];
				}else if(ownClass.length >1){
					for(var i = 0; i < ownClass.length; i++){
						if(i == ownClass.length - 1){
							elem.className += ownClass[i];
						}else{
							elem.className += ownClass[i] + " ";
						}
					}
				}
			}	
			return had;	
		},
		addEvent: function(elem, eventName, handler){
			if(elem){
				if(elem.addEventListener){
					return elem.addEventListener(eventName, handler, false);
				}else if(elem.attachEvent){
					return elem.attachEvent("on" + eventName, handler);
				}else {
					elem["on" + eventName] = handler;
				}
			}
		}
	};
	var header=document.getElementById('pub_9pcheader');
	var ali=app.getByClass(header,'right-li');
	var site_con=app.getByClass(header,'web-site')[0];
	var site=app.getByClass(header,'web-site-pop')[0];
	var con=app.getByClass(site,'site-con');
	var height=0;
	
	for(var i=0;i<ali.length;i++){
		+function(i){
			app.addEvent(ali[i],'mouseover',function(){
				app.addClass(ali[i],'current');
			});
			app.addEvent(ali[i],'mouseout',function(){
				app.removeClass(ali[i],'current');
			});
		}(i);
	}
	app.addClass(site_con,'current');
	for(var i=0;i<con.length;i++){
		height=con[i].offsetHeight>height? con[i].offsetHeight : height;
	}
	app.removeClass(site_con,'current');
	for(var i=0;i<con.length;i++){
		con[i].style.height=height+7+'px';
	}
	
	
}())
