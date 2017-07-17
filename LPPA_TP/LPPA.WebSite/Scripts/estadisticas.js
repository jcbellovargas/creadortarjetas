function renderChart(title, categories, series) {
    var myChart = Highcharts.chart('chart_container', {
        chart: {
            type: 'bar'
        },
        title: {
            text: title
        },
        xAxis: {
            categories: categories
        },
        yAxis: {
            title: {
                text: ''
            }
        },
        series: [{
            name: 'Cantidad',
            data: series
        }]
    });
}


    $("#submit_stat").click(function () {
        $.ajax({
            type: "POST",
            url: "/Estadistica/GetChart",
            dataType: "json",
            data: { type: $("#stats").val() },
            success: function (data) {
                data["series"] = data["series"].map(Number);
                renderChart(data["title"][0], data["categories"], data["series"]);
            },
            error: function (xhr) {
                alert('Error: ' + xhr.statusText);
            },
        });
    });