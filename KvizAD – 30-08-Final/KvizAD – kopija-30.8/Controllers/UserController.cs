using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KvizAD.Controllers
{
    public class UserController : Controller
    {
        [KvizAD.Startup.SessionUserTimeout]
        public IActionResult Index()
        {
            return View();
        }
    }
}
