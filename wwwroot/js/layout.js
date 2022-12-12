$(document).ready(function () {
    // jQuery.noConflict();
    $("#btnShowModal").click(function () {
        document.getElementById('idErrUserName').innerHTML = ' ';
        document.getElementById('ErrLbl').innerHTML = ' ';
        $("#myModal").modal('show');
    });

    $(".btnHideModal").click(function () {
        $("#myModal").modal('hide');
    });
});

