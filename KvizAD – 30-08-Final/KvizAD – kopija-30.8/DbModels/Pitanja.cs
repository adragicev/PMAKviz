using System;
using System.Collections.Generic;

namespace KvizAD.DbModels
{
    public partial class Pitanja
    {
        public Pitanja()
        {
            Odgovori = new HashSet<Odgovori>();
            UserPitanja = new HashSet<UserPitanja>();
        }

        public int PitanjaId { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Odgovori> Odgovori { get; set; }
        public virtual ICollection<UserPitanja> UserPitanja { get; set; }
    }
}
