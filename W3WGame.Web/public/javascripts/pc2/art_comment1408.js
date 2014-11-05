(function () {
    var tools = {
        getCookie: function (name) {
            var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
            if (arr != null) return unescape(arr[2]); return null;

        },
        setcookie: function (cookieName, cookieValue, seconds, path, domain, secure) {
            var expires = new Date();
            expires.setTime(expires.getTime() + seconds);
            document.cookie = cookieName + "=" + escape(cookieValue) + ";expires=" + expires.toGMTString();
        },
        trim: function (s) { //去除字符串两边空格
            return s.replace(/(^\s*)|(\s*$)/ig, "");
        },
        // 将HTML转义为实体
        escape: function (html) {
            var keys = Object.keys || function (obj) {
                obj = Object(obj)
                var arr = []
                for (var a in obj) arr.push(a)
                return arr
            }
            var invert = function (obj) {
                obj = Object(obj)
                var result = {}
                for (var a in obj) result[obj[a]] = a
                return result
            }
            var entityMap = {
                escape: {
                    '&': '&amp;',
                    '<': '&lt;',
                    '>': '&gt;',
                    '"': '&quot;',
                    '/': '\/'
                }
            }
            entityMap.unescape = invert(entityMap.escape)
            var entityReg = {
                escape: RegExp('[' + keys(entityMap.escape).join('') + ']', 'g'),
                unescape: RegExp('(' + keys(entityMap.unescape).join('|') + ')', 'g')
            }
            if (typeof html !== 'string') return '';
            return html.replace(entityReg.escape, function (match) {
                return entityMap.escape[match]
            })
        }
    };
    var app = {
        init: function () {
            this.getDom();
            this.addEvent();
            if (this.$comment_con.children('li').length < 1) {
                this.first = true;
                this.$comment_con.after('<div class="page-unload" id="first_com" style="display: block;background:#fff;"><span class="page-reload">还没有评论，快来抢沙发吧！</span></div>');
            }
        },
        getDom: function () {		//获取dom
            this.$submit_con = $('#art_scroe_sub'); 		//提交
            this.$text_con = $('#art_textarea_text'); 		//文本框
            this.$limit_con = $('#art_limit'); 			//字数
            this.$uesr_img = $('#uesr_img'); 			//字数
            this.$comment_con = $('#comment_list'); 	//评论列表
            this.$comment_all = $('#comment_all'); 	//所有评论列表
            this.$page_unload = $('#page_unload'); 	//点击加载
            this.$page_load = $('#page_load'); 		//正在加载
            this.limit_min = 3; 						//最小限制字数
            this.limit_max = 240; 						//最大限制字数
            this.news_id = $("#atr_content").attr("news_id"); //被评论文章的id
            this.param = JSON.parse(this.$submit_con.attr('data-id')); //用户评论相关参数
            this.comment_limit_time = 10 * 1000; //评论限制时间  6s=6*1000 ms
            this.like_limit_time = 24 * 60 * 60 * 1000; //点赞限制时间  24h=10*60*1000 ms
            this.first = false;

            this.$tag = $("#fast_tag");
            this.aTag = [];

            this.$score = $("#get_score");
            this.star_score = $("#get_score .up").length;

        },
        light_star: function (num) {	//点亮星星
            var $stars = this.$score.children();
            if (num > 0) {
                for (var i = 0; i < $stars.length; i++) {
                    if (i < num) {
                        $stars.eq(i).addClass('up').removeClass('down');
                    } else {
                        $stars.eq(i).addClass('down').removeClass('up');
                    }
                }
            } else {
                $stars.addClass('down').removeClass('up');
            }
        },
        getTag: function () {    //获取快速评论
            var that = this,
				$tags = this.$tag.children(),
				tempTag = [];
            for (var i = 0; i < $tags.length; i++) {
                if ($tags.eq(i).hasClass("current")) {
                    tempTag.push($tags.eq(i).text());
                }
            }

            tagsWord = tempTag.join(",");
            that.tagsWord = tagsWord;
            that.aTag = tempTag;
            return that.aTag;
        },

        limitWord: function (str) {	//字数限制判断
            var last = this.limit_max - str.length;
            if (str.length <= 0) {
                this.$limit_con.html('赶快给我写个评论吧~');
                return true;
            } else if (str.length < this.limit_min) {		//太少
                this.$limit_con.html('少于<span class="high">' + this.limit_min + '</span>个字');
                return false;
            } else if (str.length <= this.limit_max) {			//适中
                this.$limit_con.html('还可输入<span>' + last + '</span>个字');
                return true;
            } else if (str.length > this.limit_max) {		//太多
                this.$limit_con.html('超出了<span class="high">' + (last * -1) + '</span>个字');
                return false;
            }
            return false;
        },
        addEvent: function () {	//事件添加
            var This = this;
            this.$text_con.bind({ 'keyup': function () {	//字数限制事件
                var That = $(this);
                This.limitWord(That.val());
            } 
            });
            this.$submit_con.click(function () {			//提交评论事件	

                if (This.star_score == 0) {  //星级评分
                    This.$limit_con.html('<span class="high">请评分!</span>');
                    return false;
                }

                if (This.timeLimit('cmtfrqflag_' + This.param.game_id + '_' + This.param.platform_id)) {
                    var commentStr = $("#art_textarea_text").val();
                    This.getTag(); //快速评论
                    if (!This.limitWord(commentStr)) {
                        This.$limit_con.html('亲,需输入3~240字喔!');
                    } else {
                        This.commentAjax();
                    }
                } else {
                    This.$limit_con.html('亲,你评论发得太快啦,喝杯茶休息一下吧!');
                }
            });
            this.$comment_all.delegate(".addlike", "mouseup", function () {		//点赞事件
                var That = $(this);
                var data = That.parents("li").attr('commentId'); //获取评论id
                if (data != 'null' && data) {
                    if (This.timeLimit('comattitude_' + data)) {
                        This.likeAjax(That, data);
                    } else {
                        That.addClass('current');
                    }
                }
            });

            var stars = This.$score.children(); //评分事件
            $(stars).bind({
                mouseenter: function () {
                    var num = parseInt($(this).index()) + 1;
                    This.light_star(num);
                },
                mouseleave: function () {
                    This.light_star(This.star_score);
                },
                click: function () {
                    var num = parseInt($(this).index()) + 1;
                    This.star_score = num;
                }
            });

            this.$tag.delegate(".tag", "click", function () { //快速评论
                $(this).toggleClass("current");
            })
        },
        timeLimit: function (id) {
            if (tools.getCookie(id) == null || tools.getCookie(id).length < 1) {
                return true;
            } else {
                return false;
            }
        },
        addNewComment: function (data) {		//评论html
            var d = new Date();
            var hour = d.getHours() < 10 ? "0" + d.getHours() : d.getHours();
            var min = d.getMinutes() < 10 ? "0" + d.getMinutes() : d.getMinutes();
            var sec = d.getSeconds() < 10 ? "0" + d.getSeconds() : d.getSeconds();
            var date = "" + d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate() + '&nbsp;' + hour + ':' + min + ":" + sec + "";
            var html = '';

            var nickname = this.param.nickName,
				com = tools.trim(data.comment),
				ment = data.tag,
				comment = (com === "") ? ment : (com + "," + ment);

            html += '<li>';
            html += '<div class="img-con"><img src="http://image.base.w3wgame.com:8080/2014/6/25/9774681.jpg" alt=""/></div>';
            html += '<div class="detail">';
            html += '<p class="from"><span class="name">' + nickname + '</span>来自于<a href="" class="jiu">w3w游戏网页版</a><span class="time">' + date + '</span></p>';
            html += '<p class="text">' + tools.escape(comment) + '</p>';
            html += '</div>';
            html += '</li>';
            this.$comment_con.prepend(html);
        },
        commentAjax: function () {   //评论ajax请求
            var This = this;

            //发送的数据
            var postData = {
                "comment": $("#art_textarea_text").val(),
                "score": This.star_score,
                "platform_id": This.param.platform_id,
                "src": 2,
                "game_id": This.param.game_id,
                "game_version": This.param.game_version,
                "tag": This.tagsWord
            }

            try {
                $.ajax({
                    type: "post",
                    dataType: "json",
                    url: "/commentscore",   //提交地址
                    data: postData,
                    success: function (result) {
                        if (result == -3) {
                            This.$limit_con.html('亲,你评论发得太快啦,喝杯茶休息一下吧!');
                        }
                        else if (result == 1) {
                            This.addNewComment(postData);
                            This.$limit_con.html('发布成功!!');
                            if (This.first) {
                                $('#first_com').hide();
                            }
                            This.$text_con.val("");
                        } else {
                            This.$limit_con.html('<span class="high">可能由于网络问题,发送失败,请稍后再试!!</span>');
                        }
                    },
                    error: function () {
                        This.$limit_con.html('<span class="high">可能由于网络问题,发送失败,请稍后再试!!</span>');
                    }
                });

            } catch (e) {

            }
        },
        likeAjax: function (con, id) {			//点赞
            var This = this;
            var postData = {};
            try {
                $.ajax({
                    type: "get",
                    url: "/support/" + id + ".html",                   //=============
                    dataType: "json",         //=============
                    success: function (result) {
                        if (result == true) {
                            con.addClass('current');
                            var num = parseInt(con.html().replace(/[^0-9]/ig, "")) + 1;
                            con.html("\(" + num + "\)");
                            //tools.setcookie('91commentlike_game_'+This.gameId.news_id+'_'+id,id,This.like_limit_time);
                        } else {

                        }
                    },
                    error: function () {

                    }
                });

            } catch (e) {

            }
        }
    }
    app.init();
})();