# NetCore-LineChartTagHelper
.Net Core Line Chart Tag Helper

![enter image description here](https://github.com/tahaipek/NetCore-LineChartTagHelper/blob/master/ss01.png?raw=true)

```csharp


<button id="TahaChartYenile01" class="btn btn-success">Reload Taha Chart</button>
<button id="BurakChartYenile02" class="btn btn-primary">Reload Burak Chart</button>

<line-chart name="BurakChart" chart-url="/Home/GetLineCharts" max-width="500" y-axis-title="Test" chart-title="Burak Chart" chart-sub-title="Burak Alt Başlık"></line-chart>
<line-chart name="TahaChart" chart-url="/Home/GetLineCharts" max-width="500" y-axis-title="Test" chart-title="Taha Chart" chart-sub-title="Taha Alt Başlık"></line-chart>
<line-chart name="dummyChart" chart-url="/Home/GetLineCharts" max-width="500" y-axis-title="Test" chart-title="Test Chart" chart-sub-title="Test Alt Başlık"></line-chart>



@section Scripts{
    <line-chart-scripts></line-chart-scripts>

    <script>
        $(document).ready(function () {
       
            $("#BurakChartYenile02").click(function (e) {
                e.preventDefault();

                var chartId = $('[data-name="BurakChart"]').attr("id");
                var chart = window.lineChart.getChart(chartId)[0];

                chart.chartUrl = "/Home/GetLineChartsWeeks";
                chart.dataParameter = { maxValue: Math.floor(Math.random() * 1000) };

                var lineChart = new LineChart(chart);
                lineChart.loadChart();

            });

     $("#TahaChartYenile01").click(function (e) {
                e.preventDefault();

                var data = [{
                   name: 'Installation',
                   data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
                }, {
                   name: 'Manufacturing',
                   data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
                }, {
                   name: 'Sales & Distribution',
                   data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
                }, {
                   name: 'Project Development',
                   data: [null, null, 7988, 12169, 15112, 22452, 34400, 34227]
                }, {
                   name: 'Other',
                   data: [12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111]
                }];
                

                var chartId = $('[data-name="TahaChart"]').attr("id");
                var chart = window.lineChart.getChart(chartId)[0];
                chart.chart.update(
                   {
                       series: data
                   }
                );

                debugger;
            });


        });
    </script>
}

```
