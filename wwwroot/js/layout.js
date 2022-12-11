$(document).ready(function () {
    // jQuery.noConflict();
    $("#btnShowModal").click(function () {
        $("#myModal").modal('show');
    });

    $(".btnHideModal").click(function () {
        $("#myModal").modal('hide');
    });
    $('#myModal').modal({ backdrop: 'static', keyboard: false })
});

