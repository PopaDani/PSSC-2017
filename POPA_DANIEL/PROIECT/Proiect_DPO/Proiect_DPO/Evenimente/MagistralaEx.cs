using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Comenzi;

namespace Proiect_DPO.Evenimente
{
    public static class MagistralaEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaEvenimente magistrala)
        {
            magistrala.InregistreazaProcesator(TipEveniment.AdaugareProdus, new ProcesatorAdaugaProdus());
        }
    }
}
