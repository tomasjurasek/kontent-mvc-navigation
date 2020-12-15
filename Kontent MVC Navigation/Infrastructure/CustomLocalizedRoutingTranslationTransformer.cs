using Microsoft.AspNetCore.Mvc.Routing;
using Kentico.AspNetCore.LocalizedRouting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

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
            return await _localizedRoutingDynamicRouteValueResolver.ResolveAsync(values);
        }
    }
}
