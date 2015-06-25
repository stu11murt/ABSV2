$(document).ready(function () {

    $(".time").each(function () {
        $(this).timepicker({ 'scrollDefault': 'now' });
    });

    $('#booking_StartTime').timepicker();

});