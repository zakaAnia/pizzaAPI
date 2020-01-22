using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaMenu
    {
        public int IdSkladnik { get; set; }
        public int IdPizza { get; set; }
        public int IdSos { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
        public virtual Sos IdSosNavigation { get; set; }
    }
}
