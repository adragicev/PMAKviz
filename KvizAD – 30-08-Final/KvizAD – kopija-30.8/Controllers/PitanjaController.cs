using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KvizAD.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KvizAD.Controllers
{
    public class PitanjaController : Controller
    {
        private readonly KvizAnaDContext _dbcontext;
        public PitanjaController(KvizAnaDContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [KvizAD.Startup.SessionAdminTimeout]
        public IActionResult Pitanja()
        {

            var rezultati = _dbcontext.Pitanja.Include(x=>x.Odgovori);
            return View(rezultati);
        }
    }
}
