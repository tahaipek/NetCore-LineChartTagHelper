using System;
using System.Collections.Generic;
using System.Text;

namespace LineChartTagHelper.LineChart.Models
{
    public class Series
    {
        public string Name { get; set; }
        public List<decimal?> Data { get; set; }
    }
}
