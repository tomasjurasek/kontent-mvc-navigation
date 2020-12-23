﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kontent_MVC_Navigation.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.AspNetCore.LocalizedRouting.Attributes;

namespace Kontent_MVC_Navigation.Controllers
{
    [LocalizedRoute("en-US", "home")]
    [LocalizedRoute("es-ES", "inicio")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IDeliveryClient _deliveryClient;

        public HomeController(ILogger<HomeController> logger, IDeliveryClient deliveryClient)
        {
            _logger = logger;
            _deliveryClient = deliveryClient;
        }

        //[Route("")]
        //[Route("home")]
        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
