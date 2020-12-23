using Kentico.Kontent.Delivery;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kontent_MVC_Navigation.Views.Shared.Components.Navigation
{
    public class NavigationViewComponent : ViewComponent
    {
        private IDeliveryClient _deliveryClient;

        public NavigationViewComponent(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Get the root navigation item from Kontent
            IDeliveryItemResponse<Homepage> response = await _deliveryClient.GetItemAsync<Homepage>("homepage", 
                new DepthParameter(3),
                new LanguageParameter(CultureInfo.CurrentCulture.Name)
                );

            var homepage = response.Item;

            return View("Navigation", homepage);
        }
    }
}
