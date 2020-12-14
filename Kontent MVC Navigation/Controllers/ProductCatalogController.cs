using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    public class ProductCatalogController : Controller
    {
        [Route("product-catalog", Name = "product-catalog")]
        public IActionResult Index()
        {
            return View();
        }
    }
}