(function(window,document){
    var $con=$('#comment_list');
    var $loading=$('#page_load');
    var $reload=$('#page_reload');
    var param = JSON.parse($("#param").val());
    var once_count=param.count;    //一次加载个数
    var isloading=1;    //状态选择 -- 是否正在加载
    var time=1;    //已加载次数
    var url=$("#param").attr("data-url");
    var begin_index= once_count * time;     //开始下标
    var sum_total=param.total; //总数
    sum_total=parseInt(sum_total);
    var prev_count= once_count * time;
    $loading.hide();
    $reload.show();
    if( sum_total > prev_count ){
        $reload.find('.page-reload').click(function(){      //点击加载
            if(isloading==1){
                ajax_loading(url);
            }
        });
    }else{
        is_all();
    }
    if(sum_total==0){
        $reload.html("暂无数据");
    }
    //异步加载
    function ajax_loading(sUrl){
        var param = JSON.parse($("#param").val());
        param.offset = once_count*time;
        param.isAjax = 1;
        try {  //请求html
            $.ajax({
                type: "get",
            //  dataType: "json",
                url: sUrl,   //获取数据地址
                data: param,//传参数
                beforeSend:function(){
                    isloading=0;
                    $loading.show();
                    $reload.hide();
                },
                success: function(result){
                    if(result.length > 1){
                        $con.append(result);
                        time++;
                        if(sum_total <=  once_count * time){
                            is_all();
                        }
                    }else{
                        is_all();
                    }
                },error:function(){
                    $reload.find('a').html("加载失败,点击重新加载");
                },complete:function(){
                    isloading=1;
                    $loading.hide();
                    $reload.show();
                }
           });
        } catch(e) {
        }
    }
    function is_all(){
        $loading.hide();
        $reload.html("以上是全部数据");
    }
})(window,document)