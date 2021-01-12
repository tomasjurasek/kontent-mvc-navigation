using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    public class BrewersController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public BrewersController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [Route("products/brewers", Name = "brewers")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemsAsync<Brewer>(
                new EqualsFilter("system.type", "brewer")
                );

            var brewers = response.Items;

            return View(brewers);
        }

        [Route("products/brewers/{url_pattern}", Name = "show-brewer")]
        public async Task<IActionResult> Show(string url_pattern)
        {
            var response = await _deliveryClient.GetItemsAsync<Brewer>(
                new EqualsFilter("elements.url_pattern", url_pattern)
                );

            var brewer = response.Items.FirstOrDefault();

            return View(brewer);
        }
    }
}