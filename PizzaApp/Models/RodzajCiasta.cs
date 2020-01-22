using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class RodzajCiasta
    {
        public RodzajCiasta()
        {
            PizzaCala = new HashSet<PizzaCala>();
        }

        public int IdRodzajuCiasta { get; set; }
        public string RodzajCiasta1 { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
    }
}
