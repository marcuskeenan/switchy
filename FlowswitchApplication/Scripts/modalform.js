﻿$(function () {
    $.ajaxSetup({ cache: false });
    $("a[data-modal]").on("click", function (e) {
        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');
        $('#myModalContent').load(this.href, function () {
            $('#myModal')
                .removeData()
                //.html('loading....')
                //.load($(this).attr('href'))
                .modal({
                    /*backdrop: 'static',*/
                    keyboard: true
                }, 'show');
            bindForm(this);
        });
        return false;
    });
});

$('#myModal').on("hidden.bs.modal", function (e) {
    $(e.target).removeData("bs.modal").find(".modal-content").empty();
});

/*
$('#myModal').on('hidden.bs.modal', function () {
    $(this).removeData('bs.modal');
});*/
function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide').removeData();
                    //Refresh
                    location.reload();
                } else {
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}
