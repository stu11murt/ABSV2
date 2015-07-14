$(document).ready(function () {

    //DAYSHEETS SECTION
    //////////////////////////////////////////////////////////////////////////////////////////////////
    $('#datepicker').datepicker();

    var sDate = $('#datepicker').attr('data-date');

    $("#datepicker").on("changeDate", function (event) {
        $("#my_hidden_input").val(
                $("#datepicker").datepicker('getFormattedDate')
        )

        sDate = $("#my_hidden_input").val();

    });

    //$('#ExportToExcel').click(function () {
    //    var url = "/Admin/ExportToExcel?eventDate=" + sDate + "&queryType=" + $(this).attr("data-id");
    //    window.location.href = url;
    //});

    $('#ExportToExcel').click(function () {
        $("#tableToExport").tableExport({
            //exclude CSS class
            type: "excel",
            escape: "false",
            ignoreColumn: [7]
        });
    });

    $('#ExportToPDF').click(function () {
        $("#tableToExport").tableExport({
            //exclude CSS class
            type: 'pdf',
            pdfFontSize: '7',
            tableName:'Test143',
            escape: 'false',
            ignoreColumn: [7]
        });
    });

    $('#paintball').click(function () {
        var url = "/Admin/DaySheets?selectedDate=" + sDate + "&queryType=" + $(this).attr("data-id");
        window.location.href = url;
    });

    $('#prepay').click(function () {
        var url = "/Admin/DaySheets?selectedDate=" + sDate + "&queryType=" + $(this).attr("data-id");
        window.location.href = url;
    });

    $('#laser').click(function () {
        var url = "/Admin/DaySheets?selectedDate=" + sDate + "&queryType=" + $(this).attr("data-id");
        window.location.href = url;
    });

    $('#walkon').click(function () {
        var url = "/Admin/DaySheets?selectedDate=" + sDate + "&queryType=" + $(this).attr("data-id");
        window.location.href = url;
    });

    $('#bigticket').click(function () {
        var url = "/Admin/DaySheets?selectedDate=" + sDate + "&queryType=" + $(this).attr("data-id");
        window.location.href = url;
    });




    //END OF DAYSHEETS SECTION
    /////////////////////////////////////////////////////////////////////////////////////////////////

});