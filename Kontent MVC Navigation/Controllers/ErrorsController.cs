using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kontent_MVC_Navigation.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error/{code}", Name="error")]
        public IActionResult Error(int code)
        {
            if (code == 404)
            {
                return View("NotFound");
            }
            else
            {
                return View("Error");
            }
        }
    }
}