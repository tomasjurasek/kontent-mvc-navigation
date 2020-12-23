using System;
using System.Collections.Generic;
using System.Globalization;
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
    [LocalizedRoute("en-US", "coffees")]
    [LocalizedRoute("es-ES", "cafes")]
    public class CoffeesController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public CoffeesController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemsAsync<Coffee>(
                new EqualsFilter("system.type", "coffee"),
                new EqualsFilter("system.language", CultureInfo.CurrentCulture.Name), // disable language fallback
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

            var coffees = response.Items;
            if (coffees.Count() > 0)
            {
                return View(coffees);
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
            if (url_pattern != null)
            {
                var response = await _deliveryClient.GetItemsAsync<Coffee>(
                new EqualsFilter("elements.url_pattern", url_pattern),
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

                var coffee = response.Items.FirstOrDefault();

                return View(coffee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}