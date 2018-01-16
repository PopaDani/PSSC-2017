using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;
using Proiect_DPO.Model.Produs;
using Proiect_DPO.Comenzi;
using Proiect_DPO.Evenimente;
using Proiect_DPO.Model;

namespace Proiect_DPO
{
    class Program
    {
        static void Main(string[] args)
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();

            var produs = new Produs(new PlainText("9"), new PlainText("suc"), new PlainText("Fanta"), TipProdus.Alimentar, new PlainText("250"), new PlainText("4"),
                new PlainText("portocale"), new PlainText("-"), new PlainText("Pepsi Romania"), StareProdus.InStoc);

            var comandaAdaugaProdus = new ComandaAdaugaProdus();
            comandaAdaugaProdus.Produs1 = produs;
            MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaProdus);


            /*
            var repo = new  ReadRepository();
            var produs1 = new Produs();
            var comandaCautareProdus = new ComandaCautaProdus();
            comandaCautareProdus.Produs = produs1;
            */
        //    comandaCautareProdus.Produs.CodBare = "8";
            ////MagistralaComenzi.Instanta.Value.Trimite(comandaCautareProdus);

            //var gasit = repo.UpdateProdus("19");

            /*
             * var comandaCautareProdus = new ComandaCautaProdus();
            var produsCautat  = 
            comandaCautareProdus.Produs = produsCautat;
            MagistralaComenzi.Instanta.Value.Trimite(comandaCautareProdus);
            */

        }
    }
}
