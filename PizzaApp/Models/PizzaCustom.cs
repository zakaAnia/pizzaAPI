using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaCustom
    {
        public int IdSkladnik { get; set; }
        public int IdGotowaPizza { get; set; }
        public int IdSos { get; set; }

        public virtual PizzaCala IdGotowaPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
        public virtual Sos IdSosNavigation { get; set; }
    }
}
