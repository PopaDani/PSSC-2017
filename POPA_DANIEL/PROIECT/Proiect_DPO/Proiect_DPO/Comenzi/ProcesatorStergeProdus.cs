using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_DPO.Comenzi
{
    public class ProcesatorStergeProdus : ProcesatorComandaGeneric<ComandaStergeProdus>
    {
        public override void Proceseaza(ComandaStergeProdus comanda)
        {
            var write = new WriteRepository();
            var gasit = write.StergereProdus(comanda.CodBare);

        }
    }
}
