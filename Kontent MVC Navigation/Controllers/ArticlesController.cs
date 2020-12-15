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

namespace Kontent_MVC_Navigation.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public ArticlesController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }
    
        // original, single culture attribute routing
        //[Route("articles", Name = "articles")]

        [LocalizedRoute("en-US", "articles")]
        [LocalizedRoute("es-ES", "articulos")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("system.type", "article")
                );

            var articles = response.Items;

            return View(articles);
        }

        [Route("articles/{url_pattern}", Name = "show-article")]
        public async Task<IActionResult> Show(string url_pattern)
        {
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("elements.url_pattern", url_pattern)
                );

            var article = response.Items.FirstOrDefault();

            return View(article);
        }
    }
}