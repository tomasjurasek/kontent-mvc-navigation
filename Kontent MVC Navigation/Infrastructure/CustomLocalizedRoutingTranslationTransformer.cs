using Microsoft.AspNetCore.Mvc.Routing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using AspNetCore.Mvc.Routing.Localization;
using System;

namespace Kontent_MVC_Navigation.Infrastructure
{
    public class CustomLocalizedRoutingTranslationTransformer : DynamicRouteValueTransformer
    {
        private ILocalizedRoutingDynamicRouteValueResolver _localizedRoutingDynamicRouteValueResolver;

        public CustomLocalizedRoutingTranslationTransformer(ILocalizedRoutingDynamicRouteValueResolver localizedRoutingDynamicRouteValueResolver)
        {
            _localizedRoutingDynamicRouteValueResolver = localizedRoutingDynamicRouteValueResolver;
        }
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            try
            {      
                return await _localizedRoutingDynamicRouteValueResolver.ResolveAsync(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return values;
            }
        }
    }
}
