using Newtonsoft.Json;
using System.Collections.Generic;

namespace LineChartTagHelper.LineChart.Models
{
    public class LineChartResult
    {
        public List<string> XAxisTitles { get; set; }
        public List<Series> Series { get; set; }
    }
}