using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KvizAD.DbModels;
using KvizAD.Mappers;
using System.Security.Cryptography.X509Certificates;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace KvizAD.Repositories
{
    public class AdminRepository
    {
        private readonly KvizAnaDContext _dbContext;
        public AdminRepository(KvizAnaDContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Models.Pitanja> GetAll()
        {
            var dbp = _dbContext.Pitanja;
            return _dbContext.Pitanja.Select(x => PitanjaMapper.FromDatabase(x)); 
        }
        public async Task<Models.Pitanja> GetAsync(int id)
        {
            var result = await _dbContext.Pitanja.SingleOrDefaultAsync(x => x.PitanjaId == id);
            return PitanjaMapper.FromDatabase(result);
        }
        public IEnumerable<Pitanja> GetPitanje()
        {
            var result = _dbContext.Pitanja.Include(x=>x.Odgovori);
            return result;
        }
        public void DeletePitanje(int id)
        {
            var k = _dbContext.Pitanja.Where(x => x.PitanjaId == id).FirstOrDefault();
            while(_dbContext.Odgovori.Where(x=> x.PitanjaId == id).FirstOrDefault() != null)
            {
                var o = _dbContext.Odgovori.Where(x => x.PitanjaId == id).FirstOrDefault();
                _dbContext.Odgovori.Remove(o);
                _dbContext.SaveChanges(); //da spremi promjene odmah..da nam odma bude vidljivo da je izbrisano

            }
            _dbContext.Pitanja.Remove(k);
            _dbContext.SaveChanges();
        }
        //za indeks
        public IEnumerable<Odgovori> GetOdg()
        {
            return _dbContext.Odgovori;

        }
        public Models.User GetUser(int id)
        {
            var db = _dbContext.User.Where(x => x.UserId == id).SingleOrDefault();
            return UserMapper.FromDatabase(db);
        }
        public void Update(Models.User u)
        {
            var du = UserMapper.ToDatabase(u);
            _dbContext.User.Update(du);
            _dbContext.SaveChanges();

        }
        //admin
        public void EditPitanje(Models.Pitanja pitanje)
        {
            var db_pitanje = PitanjaMapper.ToDatabase(pitanje);
            _dbContext.Pitanja.Update(db_pitanje);
            _dbContext.SaveChanges();

        }
    }
}
