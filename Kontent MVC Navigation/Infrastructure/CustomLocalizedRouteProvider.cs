using Kentico.AspNetCore.LocalizedRouting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kontent_MVC_Navigation.Infrastructure
{
    public class CustomLocalizedRouteProvider : LocalizedRouteProvider
    {
        public CustomLocalizedRouteProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
        }

        protected override async Task<IEnumerable<Localized>> GetTranslationsAsync()
        {
            var routes = new List<Localized>
            {
                new Localized
                {
                    OriginalName = "home", LocalizerRoutes = new List<LocalizedRoute>
                    {
                        new LocalizedRoute {Culture = "en-US", Localized = "home"},
                        new LocalizedRoute {Culture = "es-ES", Localized = "inicio"},
                    }
                },
                new Localized
                {
                    OriginalName = "articles", LocalizerRoutes = new List<LocalizedRoute>
                    {
                        new LocalizedRoute {Culture = "en-US", Localized = "articles"},
                        new LocalizedRoute {Culture = "es-ES", Localized = "articulos"},
                    }
                }
            };

            return routes.AsEnumerable();
        }
    }
}