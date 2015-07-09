$(document).ready(function () {
    $('#booking_StartTime').timepicker({
        'scrollDefault': '9:00am',
        'minTime': '9:00am',
        'maxTime': '6:30pm',
        'showDuration': false
    });
    
  
    $(".time").each(function () {
       $(this).timepicker({
            'scrollDefault': '9:00am',
            'minTime': '9:00am',
            'maxTime': '6:30pm',
            'showDuration': false
        });
    });

    

});