var COMMON = {
    call_ajax: function (data) {
        if (!(data.url && data.success)) {
            console.log('ajax is not valid.');
            return;
        }

        $.ajax({
            url: data.url,
            type: data.type ? data.type : 'GET',
            data: data.data ? data.data : null,
            dataType: data.dataType ? data.dataType : 'text',
            beforeSend: function () {
                $("#spinner-loading").show();
            },
            complete: function () {
                $("#spinner-loading").hide();
            },
            success: data.success,
            error: data.error
        })
    },
}

toastr.options = {
    "closeButton": true,
    "debug": false,
    "positionClass": "toast-bottom-right",
    "onclick": null,
    "showDuration": "1000",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}