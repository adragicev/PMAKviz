using System;
using System.Collections.Generic;

namespace KvizAD.DbModels
{
    public partial class UserPitanja
    {
        public int UserPitanjaId { get; set; }
        public int UserId { get; set; }
        public int PitanjaId { get; set; }
        public int? Rezultat { get; set; }

        public virtual Pitanja Pitanja { get; set; }
        public virtual User User { get; set; }
    }
}
