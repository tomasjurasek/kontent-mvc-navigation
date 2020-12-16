using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Kontent_MVC_Navigation
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureRequestLocalization(this IServiceCollection services, string defaultCulture, params string[] otherSupportedCultures)
        {
            var defaultCultureInfo = new CultureInfo(defaultCulture);
            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    defaultCultureInfo
                };

                supportedCultures.AddRange(otherSupportedCultures.Select(culture => new CultureInfo(culture)));

                options.DefaultRequestCulture = new RequestCulture(culture: defaultCultureInfo, uiCulture: defaultCultureInfo);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.AddInitialRequestCultureProvider(new RouteDataRequestCultureProvider()
                {
                    RouteDataStringKey = "culture"
                });
            });
        }
    }
}
