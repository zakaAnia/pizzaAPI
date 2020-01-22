using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaCala = new HashSet<PizzaCala>();
            PizzaMenu = new HashSet<PizzaMenu>();
        }

        public int IdPizza { get; set; }
        public string NazwaPizza { get; set; }
        public int IdSos { get; set; }

        public virtual Sos IdSosNavigation { get; set; }
        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
        public virtual ICollection<PizzaMenu> PizzaMenu { get; set; }
    }
}
