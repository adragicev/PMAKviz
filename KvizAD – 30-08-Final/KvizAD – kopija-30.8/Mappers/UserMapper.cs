using KvizAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvizAD.Mappers
{
    public class UserMapper
    {
        public static User FromDatabase(DbModels.User k) //obratno
        {

            var ko = new User(k.UserId, k.Username, k.Password, k.Email, k.BestScore);
            return ko;


        }
        public static DbModels.User ToDatabase(User k) //iz modelsa u db models
        {
            return new DbModels.User
            {
                UserId = k.Id.HasValue ? k.Id.Value : 0,
                Username = k.Username,
                Password = k.Password,
                Email = k.Email,
                BestScore = k.BestScore




            };
        }
    }
}
