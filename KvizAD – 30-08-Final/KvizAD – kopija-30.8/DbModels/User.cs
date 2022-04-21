using System;
using System.Collections.Generic;

namespace KvizAD.DbModels
{
    public partial class User
    {
        public User()
        {
            UserPitanja = new HashSet<UserPitanja>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int BestScore { get; set; }

        public virtual ICollection<UserPitanja> UserPitanja { get; set; }
    }
}
