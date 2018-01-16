using Proiect_DPO.Model.Produs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Proiect_DPO.Comenzi
{
    public class ComandaEditeazaProdus:Comanda
    {
        public Produs Produs { get; set; }
    }
}
