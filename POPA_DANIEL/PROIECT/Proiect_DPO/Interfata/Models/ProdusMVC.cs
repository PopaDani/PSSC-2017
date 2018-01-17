using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Proiect_DPO.Model.Produs;
using Proiect_DPO.Model;

namespace Interfata.Models
{
    public class ProdusMVC
    {
        public string CodBare { get;  set; }
        public string Denumire { get;  set; }
        public string Marca { get;  set; }
        public TipProdus Tip { get;  set; }
        public string Stoc { get;  set; }
        public string Pret { get;  set; }
        public string Descriere { get;  set; }
        public string Garantie { get;  set; }
        public string Furnizor { get;  set; }
        public StareProdus Stare { get;  set; }

        public ProdusMVC()
        {

        }

        public ProdusMVC(string codBare, string denumire, string marca, TipProdus tip, string stoc, string pret, string descriere, string garantie, string furnizor, StareProdus stare)
        {
            CodBare = codBare;
            Denumire = denumire;
            Marca = marca;
            Tip = tip;
            Stoc = stoc;
            Pret = pret;
            Descriere = descriere;
            Garantie = garantie;
            Furnizor = furnizor;
            Stare = stare;
        }
    }
}