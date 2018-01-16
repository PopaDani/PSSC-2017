using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;

namespace Proiect_DPO.Comenzi
{
    public class ProcesatorAdaugaProdus: ProcesatorComandaGeneric<ComandaAdaugaProdus>
    {
        public override void Proceseaza(ComandaAdaugaProdus comanda)
        {
            //var repo = new WriteRepository();
            Produs produs = new Produs();
            produs.AdaugaProdus(comanda.Produs1);
           
            // var controller = new HomePageController();
            

        }
    }
}
