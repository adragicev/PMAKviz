using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KvizAD.Controllers
{
    public class TheEndController : Controller
    {
        public IActionResult Win()
        {
            return View();
        }
        public IActionResult Defeat()
        {
            return View();
        }
    }
}
