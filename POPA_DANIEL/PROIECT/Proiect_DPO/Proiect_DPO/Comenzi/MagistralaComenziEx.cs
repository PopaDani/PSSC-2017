using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_DPO.Comenzi
{
    public static class MagistralaComenziEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaComenzi magistrala)
        {
            magistrala.InregistreazaProcesator(new ProcesatorAdaugaProdus());
            magistrala.InregistreazaProcesator(new ProcesatorCautaProdus());
            magistrala.InregistreazaProcesator(new ProcesatorEditeazaProdus());
            magistrala.InregistreazaProcesator(new ProcesatorStergeProdus());
            magistrala.InregistreazaProcesator(new ProcesatorVindeProdus());
        }
    }
}
