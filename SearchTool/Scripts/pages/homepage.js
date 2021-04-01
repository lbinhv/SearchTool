var HOMEPAGE = {
    key_words : '',
    url_list: '',
    url_create_csv : '',
    url_search: '',
    datatable: {},
    init_page: function () { //Only init when load page

        $(".btn-insert-data").on('click', function () {
            COMMON.call_ajax({
                url: HOMEPAGE.url_create_csv,
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    if (data.status) {
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                },
                error: function (error) {
                    toastr.error(error.responseJSON.error);
                }
            });
        })

        $(".btn-search-data").on('click', function () {
            var searchData = $("#txtKeywords").val();
            if (searchData) {
                HOMEPAGE.key_words = searchData;
                //Init gridview
                HOMEPAGE.init_list();
            }
            else {
                toastr.error("Please Input Your Search Value!")
            }            
        });
    },
    init_list: function () {
        HOMEPAGE.datatable = $("#table-data").on('error.dt', function (e, settings, techNote, message) {
            toastr.error(message);
        }).DataTable({
            "pagingType": "full_numbers",
            "processing": true,
            "serverSide": false,
            "ajax": {
                "url": HOMEPAGE.url_search + "?searchValue=" + HOMEPAGE.key_words,
                "type": "GET",
                "complete": function () {
                    $(".btn-tooltip").tooltip();
                },
                "error": function (err) {
                    toastr.error(err.responseJSON.error);
                }
            },
            "columnDefs": [
                {
                    "targets": [0, 1, 2],
                    "orderable": false,
                }
            ],
            "columns": [
                { "data": "Id" },
                { "data": "Content" },
                { "data": "SearchTime"}
            ],
            "bDestroy": true,
            "searching": false
        });
    }
}