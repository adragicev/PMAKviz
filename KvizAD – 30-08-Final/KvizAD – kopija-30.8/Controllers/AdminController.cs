using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KvizAD.Services;
using Microsoft.AspNetCore.Http;


namespace KvizAD.Controllers
{
    public class AdminController : Controller
    {
        private AdminServices _adminService;

        public AdminController(AdminServices adminService) //nije korišteno
        {
            _adminService = adminService;
        }

        [KvizAD.Startup.SessionAdminTimeout]
        public ActionResult<List<Models.Pitanja>> Pitanja()
        {
            
            return View(_adminService.GetAll().ToList());

        }
    }
}
