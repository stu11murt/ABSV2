$(document).ready(function () {

    $('.group-header').each(function () {
        $(this).nextUntil('.group-header').hide();
    });

    $(function () {
       

        $('.group-header').click(function () {
            $(this).nextUntil('.group-header').toggle();
            $('.children').hide();
        });
    });

    $(function () {


        $('.group-subheader').click(function () {
            $(this).nextUntil('.group-subheader, .group-header').toggle();
        });
    });

    //function addPaging() {
    //    $('#employeeGrid tr:first').prepend('<th style="width:60px;">S. No.</th>');
    //    $('#employeeGrid tr:not(:first, .group-header, .group-footer)').each(function (index) {
    //        $(this).prepend('<td class="text-right">' + (index + 1) + '.</td>');
    //    });
    //}

});