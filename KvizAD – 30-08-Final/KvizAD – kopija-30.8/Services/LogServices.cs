using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KvizAD.Models;
using KvizAD.Repositories;

namespace KvizAD.Services
{
    public class LogServices
    {
        public LogRepository _logRepository;

        public LogServices(LogRepository logRepository)
        {
            _logRepository = logRepository;
        }

       public int RegisterUser(Models.User mUser)
        {
            return _logRepository.RegisterUser(mUser);
        }

        public Models.User VerifyKorisnik(string username, string pass,string passconf, string email)
        {
           // bool prvi = username == null || pass == null || email == null;
            bool unos = _logRepository.UserExists(username);
            if (username == null  || pass == null || email== null) return null;
            if (username.Length <= 2 || pass.Length <=2 || pass != passconf ) return null;

            if (!unos) return new Models.User(null, username, pass,email,0); //ako ne postoji

            return null;
        }

        public Models.User LogKorisnik(string username, string pasword) //kad ima registraciju
        {
            return _logRepository.LogKorisnik(username, pasword);


        }

    }
    
}
