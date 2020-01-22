using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class PizzaCala
    {
        public PizzaCala()
        {
            PizzaCustom = new HashSet<PizzaCustom>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdGotowaPizza { get; set; }
        public int IdSkladnik { get; set; }
        public int IdPizza { get; set; }
        public decimal Cena { get; set; }
        public int IdRodzajuCiasta { get; set; }
        public int IdRozmiar { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual RodzajCiasta IdRodzajuCiastaNavigation { get; set; }
        public virtual Rozmiar IdRozmiarNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
        public virtual ICollection<PizzaCustom> PizzaCustom { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
