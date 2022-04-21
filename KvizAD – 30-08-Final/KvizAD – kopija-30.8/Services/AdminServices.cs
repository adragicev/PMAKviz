using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KvizAD.DbModels;
using KvizAD.Repositories;

namespace KvizAD.Services
{
    public class AdminServices
    {
        public AdminRepository _adminRepository;

        public AdminServices(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public IEnumerable<Models.Pitanja> GetAll() // za ispis svih pitanja
        {
            return _adminRepository.GetAll();
        }
        public void DeletePitanje(int id)
        {
            _adminRepository.DeletePitanje(id);
        }
        public IEnumerable<Pitanja> GetPitanja() 
        {
            return _adminRepository.GetPitanje();
        }
        //indeks
        public IEnumerable<Odgovori> GetOdg()
        {
            return _adminRepository.GetOdg();

        }
        public Models.User GetUser(int id)
        {
            return _adminRepository.GetUser(id);

        }
        public void Update(Models.User u)
        {
            _adminRepository.Update(u);

        }
        //admin
        public void EditPitanje(Models.Pitanja pitanje)
        {
            _adminRepository.EditPitanje(pitanje);


        }
    }
}
