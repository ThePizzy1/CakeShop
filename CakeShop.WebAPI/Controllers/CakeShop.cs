using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.WebAPI.Controllers
{
    public class CakeShop : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
