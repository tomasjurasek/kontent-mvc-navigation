﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Kontent_MVC_Navigation.Models;
using AspNetCore.Mvc.Routing.Localization;

namespace Kontent_MVC_Navigation.Views.Shared.Components.LanguageSelector
{
    public class LanguageSelectorViewComponent : ViewComponent
    {

        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;
        private readonly ILocalizedRoutingProvider _localizedRoutingProvider;

        public LanguageSelectorViewComponent(IOptions<RequestLocalizationOptions> localizationOptions, ILocalizedRoutingProvider localizedRoutingProvider)
        {
            _localizationOptions = localizationOptions;
            _localizedRoutingProvider = localizedRoutingProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUICulture = CultureInfo.CurrentUICulture;
            var currentController = HttpContext.Request.RouteValues["controller"].ToString();
            var currentAction = HttpContext.Request.RouteValues["action"].ToString();


            var translatedController = await _localizedRoutingProvider.ProvideRouteAsync(
                currentUICulture.Name,
                currentController,
                currentAction, 
                LocalizationDirection.OriginalToTranslated);

            var translatedAction = await _localizedRoutingProvider.ProvideRouteAsync(
                currentUICulture.Name,
                currentController,
                currentAction,
                LocalizationDirection.OriginalToTranslated);

            var languageSwitcher = new LanguageSwitcher
            {
                SupportedCultures = _localizationOptions.Value.SupportedCultures.ToList(),
                CurrentUICulture = currentUICulture,
                CurrentController = translatedController.Controller,
                CurrentAction = translatedAction.Action,
                CurrentPath = this.HttpContext.Request.Path
            };



            return View("languageSelector", languageSwitcher);
        }
    }
}
