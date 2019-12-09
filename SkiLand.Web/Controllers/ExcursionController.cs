using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkiLand.Web.Controllers
{
    public class ExcursionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}