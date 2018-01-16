using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;
using Newtonsoft.Json;

namespace Proiect_DPO.Evenimente
{
    public class ProcesatorAdaugaProdus : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {

            var repo = new WriteRepository();
            var trimite = new Send();
            trimite.TrimiteEveniment(e);
            repo.SalvareEvenimente(e);

        }
    }
}
