﻿using Proiect_DPO.Comenzi;
using Proiect_DPO.Evenimente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interfata.App_Start
{
    public static class DDDconfig
    {
        public static void config()
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();
        }
    }
}