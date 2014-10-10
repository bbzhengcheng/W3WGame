$(document).ready(function () {
    // 提交游戏信息
    $("a[id^='req']").click(function () {
        var aId = $(this).attr("id");
        $("#temp").val(aId.substring(3, aId.length));
        $("#form-elem").html($("#o_hid" + aId.substring(3, aId.length)).html());
        $("#o_hid" + aId.substring(3, aId.length)).html("");
        $("#show1").show();
        return false;
    });
    // 提交层关闭
    $("#close1,#a_cen").click(function () {
        $("#show1").hide();
        var tempId = $("#temp").val();
        $("#o_hid" + tempId).html($("#form-elem").html());
        $("#form-elem").html("");
        return false;
    });
    // 确认层关闭
    $("#close2").click(function () {
        $("#show2").hide();
        var tempId = $("#temp").val();
        $("#t_hid" + tempId).html($("#post-info").html());
        $("#post-info").html("");
        return false;
    });
    // 提交按钮
    $("#a_ref").click(function () {
        var tempId = $("#temp").val();
        var length = $("#hid_" + tempId).val();
        var flag = true;
        var content = "";
        var paramsCount = 0;
        for (var i = 0; i < length; i++) {
            var val = $("input[name='" + tempId + "_" + (i + 1) + "']").val();
            if (val == null || val == '') {
                flag = false;
            }
            content += val;
            paramsCount++;
            var limitLength = 50 - (paramsCount - 1) * 2;
            if (content.length > limitLength) {
                alert("内容超长！");
                flag = false;
                break;
            }
            $("span[name='" + tempId + "_" + (i + 1) + "_span']").text(val);
            $("#" + tempId + "_" + (i + 1) + "_inp").val(val);
        }
        if (flag) {
            $("#show1").hide();
            $("#post-info").html($("#t_hid" + tempId).html());
            $("#o_hid" + tempId).html($("#form-elem").html());
            $("#form-elem").html("");
            $("#t_hid" + tempId).html("");
            $("#show2").show();
        }
        return false;
    });
    // 修改按钮
    $("#a_upd").click(function () {
        $("#show2").hide();
        var tempId = $("#temp").val();
        var length = $("#hid_" + tempId).val();
        $("#form-elem").html($("#o_hid" + tempId).html());
        $("#o_hid" + tempId).html("");
        for (var i = 0; i < length; i++) {
            $("input[name='" + tempId + "_" + (i + 1) + "']").val($("span[name='" + tempId + "_" + (i + 1) + "_span']")
                    .text());
        }
        $("#t_hid" + tempId).html($("#post-info").html());
        $("#post-info").html("");
        $("#show1").show();
        return false;
    }
    );
    // 确认按钮
    $("#a_com").click(function () {
        var tempId = $("#temp").val();
        $("#id").val($("#sce" + tempId).val());
        $("#paramter").val($("#par" + tempId).val());
        $("#kaboxId").val(tempId);
        $("#kaId").val($("#kaId" + tempId).val());
        $("#show2").hide();
        $("#form_id").ajaxPost(function (result) {
            if (result.status == "failure") {
                alert(result.message);
                self.location.href = $("#backurl").val();
            }
            else {
                alert("您的游戏信息已提交，我们会稍后将礼包发放到您的存号箱，并站内消息通知您！");
                self.location.href = $("#backurl").val();
            }
        });
        return false;
    });
    $("a[id^='con']").hover(function () {
        var aId = $(this).attr("id");
        var tmpId = aId.substring(3, aId.length);
        $("#li" + tmpId).addClass("zIndex");
        if (!$("#li" + tmpId).is("li[id^='li']:first") && $("#li" + tmpId).is("li[id^='li']:last")) {
            $("#con_div" + tmpId).addClass("last");
        }
        $("#con_div" + tmpId).show();
    }, function () {
        var aId = $(this).attr("id");
        var tmpId = aId.substring(3, aId.length);
        $("#li" + tmpId).removeClass("zIndex");
        if (!$("#li" + tmpId).is("li[id^='li']:first") && $("#li" + tmpId).is("li[id^='li']:last")) {
            $("#con_div" + tmpId).removeClass("last");
        }
        $("#con_div" + tmpId).hide();
    });
    $("a[id^='ins']").hover(function () {
        var aId = $(this).attr("id");
        var tmpId = aId.substring(3, aId.length);
        $("#li" + tmpId).addClass("zIndex");
        if (!$("#li" + tmpId).is("li[id^='li']:first") && $("#li" + tmpId).is("li[id^='li']:last")) {
            $("#ins_div" + tmpId).addClass("last");
        }
        $("#ins_div" + tmpId).show();
    }, function () {
        var aId = $(this).attr("id");
        var tmpId = aId.substring(3, aId.length);
        $("#li" + tmpId).removeClass("zIndex");
        if (!$("#li" + tmpId).is("li[id^='li']:first") && $("#li" + tmpId).is("li[id^='li']:last")) {
            $("#ins_div" + tmpId).removeClass("last");
        }
        $("#ins_div" + tmpId).hide();
    });
}
);
var codeCopy = function (obj) {
    var code = obj.attr('rel')
    try {
        if (window.clipboardData.setData("Text", code)) {
            alert("已复制到剪贴板");
        }
        else {
            var t = window.prompt("请按Ctrl+C快捷键进行复制!", code);
        }
    }
    catch (ex) {
        var t = window.prompt("请按Ctrl+C快捷键进行复制!", code);
    }
};