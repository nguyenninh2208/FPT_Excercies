function ShowPopupCustomize(url, title, width, type, button1, functionName1, button2, functionName2) {
    $.ajax({
        type: 'get',
        url: url,
        success: function (data) {
            $('#modal-notify .modal-dialog').css("max-width", width);
            $('#modal-notify .modal-body').html(data);
            $('#modal-notify .modal-title').html(title);
            if (typeof (type) != "undefined" && type == 1) {
                $('#modal-notify .modal-footer').html("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button><button type='button' class='btn btn-primary' onclick='" + functionName1 + "'>" + button1 + "</button>");
            }
            else if (type == 2) {
                $('#modal-notify .modal-footer').html("<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button><button type='button' class='btn btn-primary' onclick='" + functionName1 + "'>" + button1 + "</button> <button type='button' class='btn btn-danger' onclick='" + functionName2 + "'>" + button2 + "</button>");
            }
            $("#modal-notify").modal('show');
        }
    });
}
