using System;
using System.Collections.Generic;
using System.Text;

namespace LineChartTagHelper.LineChart.Models
{
    public class LineChartViewModel
    {
        public string Id { get; private set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                Id = $"{_name}-{Guid.NewGuid().ToString()}";
            }
        }


        public string ChartUrl { get; set; }
        public string DataParameter { get; set; }


        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string YAxisTitle { get; set; }

        public int MaxWidth { get; set; }
    }
}
