// Onload Table Bind
$(document).ready(function () {
    var templateHtml = $('#table-list').html();
    var templateCompile = Handlebars.compile(templateHtml);
    $.get('/Admin/Circulars/GetPtmList', { 'pageNumber': 1, 'pageSize': 10 }, function (data) {
        data.PtmModels.forEach(task => { task.Month = getMonthYear(task.Month) });
        var templateResult = templateCompile(data);
        $('#table').html(templateResult);
    });

    $('').on('click', function () {
        alert('');
    });
});
function getMonthYear(d) {
    debugger
    var subStr = parseInt(d.substr(6));
    var dt = new Date(subStr);
    var d = dt.getDate();
    var dtm = dt.toLocaleString('default', { month: 'long' });
    var dty = dt.getFullYear();
    return d + " " + dtm + " " + dty
}
$(document).on('click', 'table > tbody > tr > td > .pull-right > .delete', function () {

    var a = confirm("Are you sure to delete this record?");
    if (a) {
        var $buttonDelete = $(this);
        var id = $(this).attr('data-id');
        $.get('/Admin/Circulars/deletePtm', { "Id": id }, function (data) {
            if (data === true) {
                $buttonDelete.closest('.row-command').remove();
                $('#alert').html("<div class='container-fluid alert-container'><div class='alert alert-success alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>Record deleted successfully.</div></div>");
            }
            else {
                $('#alert').html("<div class='container-fluid alert-container'><div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>Unable to delete, record is already in use.</div></div>");
            }
        });
    }
});

// Paging Click Table Bind
$(document).on('click', 'li > a', function () {

    var pageNo = $(this).attr('data-page');

    var templateHtml = $('#table-list').html();
    var templateCompile = Handlebars.compile(templateHtml);

    $.get('/Admin/Circulars/GetPtmList', { 'pageNumber': parseInt(pageNo), 'pageSize': 10 }, function (data) {
        var templateResult = templateCompile(data);
        $('#table').html(templateResult);
    });
});