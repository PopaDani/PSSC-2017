using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;

namespace Proiect_DPO.Comenzi
{
    public abstract class ProcesatorComanda
    {
        public abstract void Proceseaza(Comanda comanda);
    }
}
