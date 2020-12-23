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
    [LocalizedRoute("en-US", "brewers")]
    [LocalizedRoute("es-ES", "cafeteras")]
    public class BrewersController : Controller
    {
        private readonly IDeliveryClient _deliveryClient;

        public BrewersController(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }
        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public async Task<IActionResult> Index()
        {
            var response = await _deliveryClient.GetItemsAsync<Brewer>(
                new EqualsFilter("system.type", "brewer"),
                new EqualsFilter("system.language", CultureInfo.CurrentCulture.Name), // disable language fallback
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

            var brewers = response.Items;
            if (brewers.Count() > 0)
            {
                return View(brewers);
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
                var response = await _deliveryClient.GetItemsAsync<Brewer>(
                new EqualsFilter("elements.url_pattern", url_pattern),
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

                var brewer = response.Items.FirstOrDefault();

                return View(brewer);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}