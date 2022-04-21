using System;
using System.Collections.Generic;

namespace KvizAD.DbModels
{
    public partial class Odgovori
    {
        public int OdgovoriId { get; set; }
        public string Text { get; set; }
        public int PitanjaId { get; set; }
        public bool? IsCorect { get; set; }

        public virtual Pitanja Pitanja { get; set; }
    }
}
