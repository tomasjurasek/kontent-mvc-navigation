using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.AspNetCore.LocalizedRouting.Attributes;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{

    [LocalizedRoute("en-US", "products")]
    [LocalizedRoute("es-ES", "productos")]
    public class ProductsController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public ProductsController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemAsync<Page>("products", new DepthParameter(2));

            var products = response.Item;

            if (products != null)
            {
                return View(products);
            }
            else
            {
                return NotFound(404);
            }
        }
    }
}