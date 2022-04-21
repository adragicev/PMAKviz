using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvizAD.Models
{
    public class Pitanja
    {
        public int? PitanjaId { get; set; }
        public string Text { get; set; }
        public Pitanja(int? pitanjaId, string text)
        {
            PitanjaId = pitanjaId.HasValue ? pitanjaId : 0;
            Text = text;
        }
    }
}
