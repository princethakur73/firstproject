// Onload Table Bind
$(document).ready(function () {
    var templateHtml = $('#table-list').html();
    var templateCompile = Handlebars.compile(templateHtml);
    var sessionId = document.getElementById("SessionId").value;
    $.get('/Admin/Circulars/GetCircularsList', { 'sessionId': sessionId,'pageNumber': 1, 'pageSize': 10 }, function (data) {
        console.log(data);
        var templateResult = templateCompile(data);
        debugger
        $('#table').html(templateResult);
    });

    $('').on('click', function () {
        alert('');
    });
});

$('#SessionId').change(function () {
    var templateHtml = $('#table-list').html();
    var templateCompile = Handlebars.compile(templateHtml);
    var sessionId = this.value;
    img.click();
    $.get('/Admin/Circulars/GetCircularsList', { 'sessionId': sessionId, 'pageNumber': 1, 'pageSize': 10 }, function (data) {
        var templateResult = templateCompile(data);
        $('#table').html(templateResult);
        span.click();
    });

    $('').on('click', function () {
        alert('');
    });
});

$(document).on('click', 'table > tbody > tr > td > .pull-right > .delete', function () {

    var a = confirm("Are you sure to delete this record?");
    if (a) {
        var $buttonDelete = $(this);
        var id = $(this).attr('data-id');
        $.get('/Admin/Circulars/delete', { "Id": id }, function (data) {
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
    var sessionId = document.getElementById("SessionId").value;
    $.get('/Admin/Circulars/GetCircularsList', { 'sessionId': sessionId,'pageNumber': parseInt(pageNo), 'pageSize': 10 }, function (data) {
        var templateResult = templateCompile(data);
        $('#table').html(templateResult);
    });
});

///////////////////////////////////////////////////////////////////////////
// Get Loading
var modal = document.getElementById("myModal");

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById("myImg");
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
img.onclick = function () {
    modal.style.display = "block";
    modalImg.classList.add("center");
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span = document.getElementById("close1");

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}