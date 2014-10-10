function DeletePost(url, data) {
    if (confirm('是否确定删除?')) {
        $.post(url, data, function () {
            alert("删除成功");
            window.location.reload();
        });
    }
}

function setSelectVal(sel, val, callback) {
    if ($.browser.msie && $.browser.version == "6.0") {
        setTimeout(function () {
            sel.val(val);
            callback();
        }, 1);
    } else {
        sel.val(val);
    }
}