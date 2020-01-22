using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            PizzaCala = new HashSet<PizzaCala>();
        }

        public int IdRozmiar { get; set; }
        public string Rozmiar1 { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<PizzaCala> PizzaCala { get; set; }
    }
}
