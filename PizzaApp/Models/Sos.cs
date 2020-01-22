using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Sos
    {
        public Sos()
        {
            Pizza = new HashSet<Pizza>();
            PizzaCustom = new HashSet<PizzaCustom>();
            PizzaMenu = new HashSet<PizzaMenu>();
        }

        public int IdSos { get; set; }
        public string NazwaSos { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<PizzaCustom> PizzaCustom { get; set; }
        public virtual ICollection<PizzaMenu> PizzaMenu { get; set; }
    }
}
