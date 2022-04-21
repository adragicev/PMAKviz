using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KvizAD.DbModels;
using KvizAD.Mappers;


namespace KvizAD.Repositories
{
    public class LogRepository
    {
        private readonly KvizAnaDContext _dbContext;

        public LogRepository(KvizAnaDContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int  RegisterUser(Models.User mkorisnik)
        {
            var dbKorisnik = UserMapper.ToDatabase(mkorisnik);
            _dbContext.User.Add(dbKorisnik); //u tablicu
            _dbContext.SaveChanges();

            var k = _dbContext.User.Where(x => x.Username == mkorisnik.Username).FirstOrDefault();

            return k.UserId;
            

        }

        public bool UserExists(string username)
        {
            var dbKor = _dbContext.User.Where(x => x.Username.Equals(username)).FirstOrDefault();
            return dbKor != null;
        }

        public Models.User LogKorisnik(string username, string pasword) //kad ima registraciju
        {

            var dbKorisnik = _dbContext.User.Where(x => (x.Username.Equals(username) && x.Password.Equals(pasword))).FirstOrDefault();
            if (dbKorisnik == null) return null;
            return UserMapper.FromDatabase(dbKorisnik);

        }

    }
}
