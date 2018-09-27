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
    [HtmlTargetElement("line-chart-scripts")]
    public class LineChartScripts : TagHelper, ITagBuilderBase
    {
        private readonly IHtmlHelper _helper;

        public LineChartScripts(IHtmlHelper helper)
        {
            _helper = helper;
        }


        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (_helper as IViewContextAware).Contextualize(ViewContext);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var partialView = "~/Views/_LineChartScripts.cshtml";
            var content = await _helper.PartialAsync(partialView);
            output.Content.SetHtmlContent(content);
        }
    }
}
