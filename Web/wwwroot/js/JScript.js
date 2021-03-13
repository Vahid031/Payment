
function AJAX(params) {
    $.ajax({
        type: params.type == undefined ? 'GET' : params.type,
        url: params.url,
        data: params.data == undefined ? {} : params.data,
        dataType: params.dataType == undefined ? 'json' : params.dataType,
        async: params.async == undefined ? true : params.async,
        cache: params.cache != undefined ? params.cache : false,
        processData: params.processData != undefined ? params.processData : true,
        beforeSend: params.beforeSend != undefined ? params.beforeSend : function () { $('#loading').fadeIn(); },
        complete: params.complete != undefined ? params.complete : function () { $('#loading').fadeOut(); },
        success: params.success != undefined ? params.success : function (data) { console.log(data) },
        contentType: params.contentType == undefined ? "application/x-www-form-urlencoded; charset=utf-8" : params.contentType,
        failure: function () { alert('failure'); },
        error: function (xhr, Result, ajaxOptions, thrownError) {

            switch (xhr.status) {
                case 401:
                    alert('شما به این صفحه دسترسی ندارید');
                case 403:
                    alert('شما به این صفحه دسترسی ندارید');
                case 404:
                    alert('دسترسی غیرمجاز');

            }
        }
    });
}

$.fn.PartialView = function (options) {

    var container = $(this);
    var callBack;

    callBack = options.callBack;

    AJAX({
        type: options.type,
        url: options.url,
        data: options.data,
        success: function (data) { permissions = data; },
        dataType: "html",
        beforeSend: function () {
            var height = container.height();
            var width = container.width();

            container.html(`<div class="loader" style="height:${height}px;width:${width}px"><span></span></div>`);
        },
        complete: function () {
        },
        success: function (data) {

            container.fadeOut(50, function () {
                container.html(data);

                if ($('.operationform').length > 0) {
                    prepareLoadedForm();
                }

                if (typeof callBack === 'function')
                    callBack();
                else if (callBack != undefined)
                    eval(callBack);



                container.fadeIn(50);
                container.PartialViewHandler();
            });
        },
    });
}

