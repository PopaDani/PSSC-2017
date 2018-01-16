using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_DPO.Evenimente
{
    public class ProcesatorEditeazaProdus: ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
            var repo = new WriteRepository();
            repo.SalvareEvenimente(e);
        }
    }
}
