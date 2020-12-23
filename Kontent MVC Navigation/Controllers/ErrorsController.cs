using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.AspNetCore.LocalizedRouting.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    [LocalizedRoute("en-US", "errors")]
    [LocalizedRoute("es-ES", "errores")]
    public class ErrorsController : Controller
    {
        [LocalizedRoute("en-US", "")]
        [LocalizedRoute("es-ES", "")]
        public new IActionResult NotFound()
        {
            return View();
        }
    }
}