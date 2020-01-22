using System;
using System.Collections.Generic;

namespace PizzaApp.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdGotowaPizza { get; set; }
        public decimal CenaTotal { get; set; }
        public DateTime DataZamowienia { get; set; }
        public DateTime CzasDostawy { get; set; }
        public string Imie { get; set; }
        public string Adres { get; set; }
        public int NrTelefonu { get; set; }

        public virtual PizzaCala IdGotowaPizzaNavigation { get; set; }
    }
}
