using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LineChartTagHelper.Web.Test.Models;
using LineChartTagHelper.LineChart.Models;

namespace LineChartTagHelper.Web.Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetLineCharts()
        {
            var result = new LineChartResult
            {
                Series = new List<Series>
                {

                },
                XAxisTitles = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            };

            for (int y = 0; y < 3; y++)
            {

                var series = new Series
                {
                    Name = "Line " + y,
                    Data = new List<decimal?>()
                };

                for (int i = 0; i < 12; i++)
                {
                    var random = (new Random()).NextDecimal(1,12);
                    series.Data.Add(random);
                }
                result.Series.Add(series);
            }

            return Json(result);
        }


        [HttpGet]
        public IActionResult GetLineChartsWeeks(long maxValue)
        {
            var result = new LineChartResult
            {
                Series = new List<Series>
                {

                },
                XAxisTitles = new List<string> { "Pzt", "Sal", "Çar", "Perş", "Cum", "Cmrts", "Pzr" }
            };

            for (int y = 0; y < 5; y++)
            {

                var series = new Series
                {
                    Name = "Line Week " + y,
                    Data = new List<decimal?>()
                };

                for (int i = 0; i < 7; i++)
                {
                    var random = (new Random()).NextDecimal(1, maxValue);
                    series.Data.Add(random);
                }
                result.Series.Add(series);
            }

            return Json(result);
        }
    }



    public static class RandomHelper
    {
        public static decimal NextDecimal(this Random rnd, decimal from, decimal to)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(from).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(to).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
                scale = 28;

            decimal r = new decimal(rnd.Next(), rnd.Next(), rnd.Next(), false, scale);
            if (Math.Sign(from) == Math.Sign(to) || from == 0 || to == 0)
                return decimal.Remainder(r, to - from) + from;

            bool getFromNegativeRange = (double)from + rnd.NextDouble() * ((double)to - (double)from) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -from) + from : decimal.Remainder(r, to);
        }
    }

}
