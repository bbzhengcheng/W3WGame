/* ajax请求抛包弹窗下载 */

(function(){
    $('body').delegate(".ajax-down-pop","click",function(){
        var parm=JSON.parse($(this).attr('data-params'));
        try {
            $.ajax({
                type: "get",
                dataType: "json",
                url: "/tpl/pc2/common/pop_win_gamefile_ajax2.html",   //获取数据地址
                //data: {"type":$search_type.val()},//传手机类型参数
                data: parm,
                success: function(result){
                    if(result.code==1){
                        window.open(result.downurl,"_self");
                    }else if(result.code==2){
                        var gameId=parm.gameId;
                         var name=parm.name;
                        $("#pb_popup").find('.box-title').children('p').text(name);
                           var f = result.packageList[0];
                           var  pack=f["k_"+gameId+"_"+2];
                           var  fp=pack.packageinfo;  
                           var lis="";
                           for(i=0;i<fp.length;i++) {
                            var p = fp[i];
                            lis += "<div class=\"down-con\">";
                            lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/down_" + gameId + "_" + p.id + ".html\"";
                            lis += " data-statis=\"" + parm.statis_text+ "\"";
                            lis+= " class=\"popup-down\">"
                            lis+= "<p class=\"name\">"+p.name+"</p>";
                            //lis+= "<p class=\"size\">" + (p.fileSize / 1048576).toFixed(1) + "MB</p>";
                            lis+= "<p class=\"size\">" + sizeFormat(p.fileSize) + "</p>";
                            lis+= "</a>";
                            lis+= "</div>";
                        }
                        $('#popup-android-con').show();
                        $("#popup-android").html(lis);
                        if(result.android==1){
                          $('#popup-apple-con').hide();
                        }else{
                           f = result.packageList[1];
                           pack=f["k_"+gameId+"_"+3];
                           fp=pack.packageinfo; 
                           p=fp[0]; 
                          lis="";
                          lis += "<div class=\"down-con\">";
                          lis += "<a id=\"index_pop_furl\"  target=\"_self\" href=\"http://www.w3wgame.com/game/downs_" + gameId+"_3.html\"";
                          lis += " data-statis=\"" + parm.statis_text+ "\"";
                          lis+= " class=\"popup-down\">"
                          lis+= "<p class=\"name\">"+p.name+"</p>";
                          lis+= "<p class=\"size\">" +  sizeFormat(p.fileSize) + "</p>";
                          lis+= "</a>";
                          lis+= "</div>";
                          $('#popup-apple-con').show();
                         $("#popup-apple").html(lis);
                        }
                        $("#pb_popup").show();
                         $('body').addClass('popup_of');   
                       
                    }
                }       
           });
        } catch(e) { return false;}
    });
    
    function isNetGame(typeId){
        if(typeId==null)
           return false;
        if(typeId==14||typeId==15||typeId==16||typeId==19){
           return true;
          }
        return false;
    }
    function sizeFormat(fileSize){
         var flag = 0;
            var fileSizeStr = "";
            if (fileSize >= 1024) {
                flag = flag ^ 1;
            }
            if (fileSize >= 1048576) {
                flag = flag ^ 2;
            }

            if (fileSize >= 1073741824) {
                flag = flag ^ 4;
            }

            if ((flag & 1) > 0) {
                var _fileSize = fileSize;
                _fileSize = _fileSize / 1024;
                fileSizeStr = _fileSize.toFixed(1) + "KB";
            }

            if ((flag & 2) > 0) {
                var _fileSize = fileSize;
                _fileSize = _fileSize / 1048576;
                fileSizeStr = _fileSize.toFixed(1) + "M";
            }

            if ((flag & 4) > 0) {
                var _fileSize = fileSize;
                _fileSize = _fileSize / 1073741824;
                fileSizeStr = _fileSize.toFixed(1) + "GB";
            }
            return fileSizeStr;

    }
    
}());   
