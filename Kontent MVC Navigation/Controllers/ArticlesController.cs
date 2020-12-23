using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using KenticoKontentModels;
using Kentico.AspNetCore.LocalizedRouting.Attributes;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using System.Threading;
using System.Globalization;

namespace Kontent_MVC_Navigation.Controllers
{
    [LocalizedRoute("en-US", "articles")]
    [LocalizedRoute("es-ES", "articulos")]
    public class ArticlesController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public ArticlesController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("system.type", "article"),
                new EqualsFilter("system.language", CultureInfo.CurrentCulture.Name), // disable language fallback
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

            var articles = response.Items;

            if (articles.Count > 0)
            {
                return View(articles);
            }
            else
            {
                return NotFound(404);
            }

        }

        [LocalizedRoute("en-US", "show")]
        [LocalizedRoute("es-ES", "mostrar")]
        public async Task<IActionResult> Show(string url_pattern)
        {
            if(url_pattern != null) { 
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("elements.url_pattern", url_pattern),
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

                var article = response.Items.FirstOrDefault();

                return View(article);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}