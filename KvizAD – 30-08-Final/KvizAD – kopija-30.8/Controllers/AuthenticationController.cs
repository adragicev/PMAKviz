using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KvizAD.Services; //za LogServices
using Newtonsoft.Json;
using KvizAD.DbModels;

using KvizAD.Models;

namespace KvizAD.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly LogServices _logServices;
        public  AuthenticationController( LogServices logServices, KvizAnaDContext db)
        {
            _logServices = logServices;
            _dbContext = db;

        }
        
        public IActionResult Registracija()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registracija(string username, string password,string passconf, string email)
        {

            var noviUser = _logServices.VerifyKorisnik(username, password,passconf, email);
            if (noviUser == null)
            {
                //ViewBag.Poruka = "Losa registracija";
                return View();
            }
            else
            {
                int Id = _logServices.RegisterUser(noviUser); 
                
                HttpContext.Session.SetString("Id", Id.ToString());
                HttpContext.Session.SetString("Username", noviUser.Username);
                HttpContext.Session.SetString("Role", "User");
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(noviUser)); 


                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            

        }
        [HttpPost]
        
        public IActionResult LogIn(string username, string password)
        {
            var noviUser = _logServices.LogKorisnik(username, password);


            if (noviUser != null)
            {
                HttpContext.Session.SetString("Role", "User");
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(noviUser));
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }
            else
            {
                ViewBag.Poruka = "Pogresno korisničko ime ili lozinka";
                return RedirectToRoute(new { controller = "Home", action = "Index" }); 
                //return View(); //za pogresan unos mi javljalo gresku pa sam redirectala na stranicu
            }
        }

            //za admina
            public IActionResult AdminLogIn()
            {
            return View();
            }

        [HttpPost]
        public IActionResult AdminLogIn(string username, string password)
        {
            var valid = VerifyAdmin(username, password);
            if (valid == null)
            {
                return View();
            }
            else
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToRoute(new
                {
                    controller = "Pitanja",
                    action = "Pitanja"
                });
            }

        }

        private KvizAnaDContext _dbContext;

        public DbModels.Admin VerifyAdmin(string username, string password)
        {
            
            var result = _dbContext.Admin.Where(x => (x.Username.Equals(username) && x.Password.Equals(password))).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {
                HttpContext.Session.SetString("Role", "Admin");
                //kreiramo sesiju admina
                var userInfo = new UserInfo() { Username = result.Username, UserId = result.AdminId };
                HttpContext.Session.SetString("SessionAdmin", JsonConvert.SerializeObject(userInfo));
                return result;
            }

        }


        //za LogOut admina (i Usera)
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", new { controller = "Home" });
        }


        
        
    }


}
