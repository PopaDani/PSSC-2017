using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;

namespace Proiect_DPO.Comenzi
{
    public class ProcesatorCautaProdus : ProcesatorComandaGeneric<ComandaCautaProdus>
    {
        public override void Proceseaza(ComandaCautaProdus comanda)
        {

            var read = new ReadRepository();

            var gasit = read.CautaProdus("18");   /////!!!!


        }
    }
}
