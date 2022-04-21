using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KvizAD.Models;
using Newtonsoft.Json.Linq;


namespace KvizAD.Mappers
{
    public class PitanjaMapper
    {
        public static Models.Pitanja FromDatabase(DbModels.Pitanja p)
        {
            
            return new Pitanja(
                p.PitanjaId,
                p.Text
                
                );

        }
        public static DbModels.Pitanja ToDatabase(Pitanja p)
        {
            return new DbModels.Pitanja
            {
                PitanjaId = p.PitanjaId.HasValue ? p.PitanjaId.Value : 0,
                Text = p.Text

            };
        }
    }
    
}
