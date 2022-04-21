using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KvizAD.Models;
using KvizAD.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using KvizAD.Mappers;


namespace KvizAD.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private AdminServices _adminService;
        public AdminApiController(AdminServices adminService)
        {
            _adminService = adminService;
        }

        [KvizAD.Startup.SessionAdminTimeout]
        [HttpDelete("deletepitanje/{id}")]
        public void DeletePitanje(int id)
        {
            _adminService.DeletePitanje(id);
        }
 

        [KvizAD.Startup.SessionAdminTimeout]
        [HttpPut("editpitanje")] //ne radi pa nisam koristila
        public IActionResult EditPitanje([FromBody] JObject json)
        {
            

            string text = json["textPitanje"].ToObject<string>();
            int pitanjaId = json["pitanjeID"].ToObject<int>();
            Pitanja promjena = new Pitanja(pitanjaId, text);
            _adminService.EditPitanje(promjena);
            return Ok();
        }


        //index
        
        [HttpGet("pitanja")] //nisam koristila za admina vec za index (usera)
        public IEnumerable<Pitanja> GetPitanja()
        {
            var pit = _adminService.GetAll();
            return pit;
        }

        
        [HttpGet("odgovori")]
        public IEnumerable<DbModels.Odgovori> GetOdg()
        {
            var odg = _adminService.GetOdg();
            return odg;
        }
        [KvizAD.Startup.SessionAdminTimeout]
        [HttpPut("edit")] //nije koristeno
        public IActionResult Edit(JObject json)
        {
            
            int Idkorisnik = json["id"].ToObject<int>();
            int score = json["score"].ToObject<int>();
            var user = _adminService.GetUser(Idkorisnik);
            user.BestScore = score;
            

            _adminService.Update(user);
            return Ok();
        }




    }
}
