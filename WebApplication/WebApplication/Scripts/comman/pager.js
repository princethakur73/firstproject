//Register Helper For Paging
Handlebars.registerHelper('list', function (context, options) {
    if (parseInt(context.TotalPages) > 1) {
        var ret = "<ul class='pagination'>";
        if (context.CurrentPage > 1) {
            ret = ret + "  <li>";
            ret = ret + " <a data-page='1'>First</a>";
            ret = ret + " </li>";
            ret = ret + " <li>";
            ret = ret + " <a data-page='" + (parseInt(context.CurrentPage) - 1) + "'>Previous</a>";
            ret = ret + " </li>";
        }
        for (var i = context.StartPage; i <= context.EndPage; i++) {
            ret = ret + "<li class=" + (i == context.CurrentPage ? 'active' : '') + ">";
            ret = ret + "<a data-page='" + i + "'>" + i + "</a>";
            ret = ret + "</li>";
        }
        if (context.CurrentPage < context.TotalPages) {
            ret = ret + "  <li>";
            ret = ret + " <a data-page='" + (parseInt(context.CurrentPage) + 1) + "'>Next</a>";
            ret = ret + " </li>";
            ret = ret + " <li>";
            ret = ret + " <a data-page='" + context.TotalPages + "'>Last</a>";
            ret = ret + " </li>";

        }
        return ret + "</ul>";
    }
});


Handlebars.registerHelper('dateFormat', function (context, block) {
    var date = context;
    if (moment) {
        date = moment(new Date(context)).format(block.hash.format || "MMM Do, YYYY");
    }

    return date;
});
