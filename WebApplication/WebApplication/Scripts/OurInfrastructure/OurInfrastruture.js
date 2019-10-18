$("#library > div:gt(0)").hide();

setInterval(function () {
    $('#library > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#library');
}, 3000);

/////////////////////////////////////////////////////////////////////
$("#SciLab > div:gt(0)").hide();

setInterval(function () {
    $('#SciLab > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#SciLab');
}, 3000);
////////////////////////////////////////////////////Classroom
$("#Classroom > div:gt(0)").hide();

setInterval(function () {
    $('#Classroom > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#Classroom');
}, 3000);
////////////////////////////////////////CompLab
$("#CompLab > div:gt(0)").hide();

setInterval(function () {
    $('#CompLab > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#CompLab');
}, 3000);
////////////////////////////////////////////////////////////SmartClass
$("#SmartClass > div:gt(0)").hide();

setInterval(function () {
    $('#SmartClass > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#SmartClass');
}, 3000);
////////////////////////////////////////////////////////PhyCul
$("#PhyCul > div:gt(0)").hide();

setInterval(function () {
    $('#PhyCul > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#PhyCul');
}, 3000);