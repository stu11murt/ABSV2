$(function () {

    /**
     * Pie charts data and options used in many views
     */

    $("span.pie").peity("pie", {
        fill: ["#006B9D", "#53ACD5"]
    })

    $(".line").peity("line",{
        fill: '#006B9D',
        stroke: '#53ACD5',
    })

    $(".bar").peity("bar", {
        fill: ["#006B9D", "#53ACD5"]
    })

    $(".bar_dashboard").peity("bar", {
        fill: ["#006B9D", "#53ACD5"],
    })
});
