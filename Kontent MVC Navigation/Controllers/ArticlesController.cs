using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using KenticoKontentModels;


namespace Kontent_MVC_Navigation.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public ArticlesController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [Route("Articles", Name = "articles")]
        public async Task<IActionResult> Index()
        {
            // Get the root navigation item from Kontent
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("system.type", "article")
                );

            var articles = response.Items;

            return View(articles);
        }

        [Route("Articles/{url_pattern}", Name = "show-article")]
        public async Task<IActionResult> Show(string url_pattern)
        {
            // Get the root navigation item from Kontent
            var response = await _deliveryClient.GetItemsAsync<Article>(
                new EqualsFilter("elements.url_pattern", url_pattern)
                );

            var article = response.Items.FirstOrDefault();

            return View(article);
        }
    }
}