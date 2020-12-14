using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    public class ProductCatalogController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public ProductCatalogController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [Route("product-catalog", Name = "product-catalog")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemAsync<Page>("product_catalog", new DepthParameter(2));

            var catalog = response.Item;

            return View(catalog);
        }
    }
}