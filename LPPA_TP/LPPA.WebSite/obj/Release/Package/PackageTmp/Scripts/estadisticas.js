    var myChart = Highcharts.chart('chart_container', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Fruit Consumption'
        },
        xAxis: {
            categories: ['Apples', 'Bananas', 'Oranges']
        },
        yAxis: {
            title: {
                text: 'Fruit eaten'
            }
        },
        series: [{
            name: 'Jane',
            data: [1, 0, 4]
        }, {
            name: 'John',
            data: [5, 7, 3]
        }]
    });

    $("#submit_stat").click(function () {
        $.ajax({
            type: "POST",
            url: "/Estadistica/GetChart",
            //data: "{ type: " + $("#stats").val() + " }",
            //data: { type: "hola" } ,
            success: function (msg) {
                var cats = msg.d;
                $.each(cats, function (index, cat) {
                    alert(cat);
                });
            },
            error: function (xhr) {
                alert('Error: ' + xhr.statusText);
            },
        });
    });