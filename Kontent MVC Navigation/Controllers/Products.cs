using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    public class Products : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public Products(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [Route("products", Name = "products")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemAsync<Page>("products", new DepthParameter(2));

            var catalog = response.Item;

            return View(catalog);
        }
    }
}