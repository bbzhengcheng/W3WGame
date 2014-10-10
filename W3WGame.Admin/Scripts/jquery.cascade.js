/*
*Cascade(级联下拉菜单)
*by licous 2013/5/17
*/
!function ($) {
    var Template = '<option value="{0}">{1}</option>';
    /*PUBLIC FUNCTION
    ===============================*/
    function StringFormart(str) {
        for (var i = 1, len = arguments.length; i < len; i++) {
            str = str.replace("{" + (i - 1) + "}", arguments[i]);
        }
        return str;
    }
    function CheckData(data) {
        if (!(data instanceof Array)) return false;
        var first = data[0];
        return !first ? true : first["Text"] && first["Value"];
    }
    function FindChild($element) {
        var selector = $element.attr("datachild");
        if (!selector) return null;
        var child = $(selector);
        return child.length === 0 ? null : child;
    }
    /*PRIVATE FUNCTION
    =============================*/
    function FillSelect(data) {
        this.clear();
        var str = "";
        for (var i = 0, len = data.length; i < len; i++) {
            var temp = data[i];
            str += StringFormart(Template, temp.Value, temp.Text);
        }
        $(str).appendTo(this.$select);
    }
    function CallBack(data) {
        if (!CheckData(data)) return;
        var child = this.child;
        FillSelect.call(this.child, data);
        this.autofill ? GetData.call(child) : this.clearchild();
    }
    function GetData() {
        var that = this;
        if (!this.haschild) return;
        var val = this.val();
        if (val == null) return;
        var url = StringFormart(this.url, val);
        $.getJSON(url, function (data) { CallBack.call(that, data); });
    };
    /*CASCADE
    =================================*/
    var Cascade = function ($element, autofill) {
        var that = this;
        this.$select = $element;
        this.autofill = autofill;
        var child = FindChild($element);
        if (child === null) return;
        this.haschild = true;
        var url = $element.attr("dataurl");
        if (!url) throw ("缺少dataurl属性");
        this.url = url;
        this.child = new Cascade(child, autofill);
        $element.change(function () { GetData.call(that); });
    };
    Cascade.prototype = {
        clearchild: function () { if (this.haschild) this.child.Clear(); },
        clear: function () { this.$select.empty(); },
        val: function () {
            var select = this.$select.find("option:selected");
            if (select.length > 0) return select.val();
            var first = $("option:first", this.$select);
            return first.length > 0 ? first.val() : null;
        }
    };
    /*EXTEND　TO JQUERY
    ============================*/
    $.fn.Cascade = function (autofill) {
        var auto = typeof autofill === "undefined" ? false : autofill;
        this.each(function () {
            this.data = new Cascade($(this), auto);
        });
    };
} (jQuery)