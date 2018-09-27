using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LineChartTagHelper.LineChart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LineChartTagHelper.LineChart
{
    [HtmlTargetElement("line-chart")]
    public class LineChart : TagHelper, ITagBuilderBase
    {
        private readonly IHtmlHelper _helper;

        public LineChart(IHtmlHelper helper)
        {
            _helper = helper;
        }

        [HtmlAttributeName("name")]
        public string Name { get; set; }

        [HtmlAttributeName("chart-url")]
        public string ChartUrl { get; set; }

        [HtmlAttributeName("chart-title")]
        public string Title { get; set; }
        [HtmlAttributeName("chart-sub-title")]
        public string SubTitle { get; set; }
        [HtmlAttributeName("y-axis-title")]
        public string YAxisTitle { get; set; }
        [HtmlAttributeName("max-width")]
        public int MaxWidth { get; set; }


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (_helper as IViewContextAware).Contextualize(ViewContext);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var viewModel = new LineChartViewModel()
            {
                Name = Name,

                ChartUrl = ChartUrl,
                Title = Title,
                SubTitle = SubTitle,
                YAxisTitle = YAxisTitle,
                MaxWidth = MaxWidth
            };

            var partialView = "~/Views/_LineChart.cshtml";
            var content = await _helper.PartialAsync(partialView, viewModel);
            output.Content.SetHtmlContent(content);
        }
    }
}
