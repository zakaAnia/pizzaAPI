using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaCala = new HashSet<PizzaCala>();
            PizzaCustom = new HashSet<PizzaCustom>();
            PizzaMenu = new HashSet<PizzaMenu>();
        }

        public int IdSkladnik { get; set; }
        public string NazwaSkladnik { get; set; }
        public decimal CenaSkladnik { get; set; }

        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
        public virtual ICollection<PizzaCustom> PizzaCustom { get; set; }
        public virtual ICollection<PizzaMenu> PizzaMenu { get; set; }
    }
}
