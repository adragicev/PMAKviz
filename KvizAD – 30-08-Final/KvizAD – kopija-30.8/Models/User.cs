using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvizAD.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int BestScore { get; set; }

        public User(int? id, string username, string pass, string mail, int bscore)
        {
            this.Id =id;
            this.Username = username;
            this.Password = pass;
            this.Email = mail;
            this.BestScore = bscore;


        }
    }
    
}
