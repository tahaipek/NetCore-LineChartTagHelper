using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace LineChartTagHelper
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNetCharts(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(new CompositeFileProvider(new EmbeddedFileProvider(typeof(ITagBuilderBase).GetTypeInfo().Assembly)));
            });
        }

        public static void UseNetCharts(this IApplicationBuilder app)
        {

        }

    }
}
