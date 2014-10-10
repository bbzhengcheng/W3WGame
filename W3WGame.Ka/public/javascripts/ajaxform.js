/**
Name    : ajaxPost
Author  : kingthy
Email   : kingthy@gmail.com
Blog    : http://www.cnblogs.com/kingthy/
Version : 1.0.0
License : MIT,GPL licenses.

**/
jQuery.fn.extend({
    ajaxPost: function (settings) {
        if (typeof settings == 'function') {
            success = arguments[0];
        } else {
            success = null;
        }

        settings = jQuery.extend({
            url: null,
            dataType: 'json',
            success: success
        }, settings);

        function createIframe(id) {
            var iframeHtml = '<iframe id="' + id + '" name="' + id + '" style="position:absolute; top:-9999px; left:-9999px" src="javascript:false;" />';
            jQuery(iframeHtml).appendTo(document.body);

            return jQuery('#' + id);
        }

        function postCallbackData(data) {
            var d = settings.dataType == 'xml' ? data.responseXML : data.responseText;
            if (settings.dataType == 'json' && d) {
                return jQuery.parseJSON(d);
            } else {
                return d;
            }
        }

        var id = "jAjaxPostFrame" + (new Date().getTime());
        var io = createIframe(id);

        var postCallback = function () {
            var io = jQuery('#' + id)[0];
            var data = {};
            try {
                if (io.contentWindow) {
                    data.responseText = io.contentWindow.document.body ? io.contentWindow.document.body.innerHTML : null;
                    data.responseXML = io.contentWindow.document.XMLDocument ? io.contentWindow.document.XMLDocument : io.contentWindow.document;
                } else if (io.contentDocument) {
                    data.responseText = io.contentDocument.document.body ? io.contentDocument.document.body.innerHTML : null;
                    data.responseXML = io.contentDocument.document.XMLDocument ? io.contentDocument.document.XMLDocument : io.contentDocument.document;
                }
            } catch (e) {
                data.error = e;
            }

            if (data.error) {
                if (settings.error) settings.error(data.error);
            } else {
                try {
                    var d = postCallbackData(data);
                    if (settings.success) settings.success(d);
                } catch (e) { }
            }
            if (settings.complete) settings.complete(data);

            jQuery(io).unbind();
            setTimeout(function () {
                try {
                    jQuery(io).remove();
                } catch (e) { }
            }, 100);
        }

        try {
            if (jQuery('input[type=file]', this).length) {
                this.attr('encoding', 'multipart/form-data');
                this.attr('enctype', 'multipart/form-data');
            } else {
                this.attr('encoding', 'application/x-www-form-urlencoded');
                this.attr('enctype', 'application/x-www-form-urlencoded');
            }
            this.attr('target', id);
            this.attr('method', 'POST');
            if (settings.url) this.attr('action', settings.url);
            io.load(postCallback);
            this[0].submit();

        } catch (e) { }
        return this;
    }
});