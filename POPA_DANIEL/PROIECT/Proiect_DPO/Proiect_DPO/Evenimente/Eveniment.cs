﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Proiect_DPO.Model;

namespace Proiect_DPO.Evenimente
{
    public  class Eveniment
    {
        public Guid Id { get; private set; }
        public PlainText IdRadacina { get; private set; }
        public TipEveniment Tip;
        public object Detalii { get; private set; }

        public Eveniment(PlainText idRadacina, TipEveniment tipEveniment, object detalii)
        {
            Tip = tipEveniment;
            IdRadacina = idRadacina;
            Detalii = detalii;
            Id = Guid.NewGuid();
        }

        public EvenimentGeneric<T> ToGeneric<T>()
        {
            EvenimentGeneric<T> eveniment = null;
            if (Detalii is T)
            {
                eveniment = new EvenimentGeneric<T>(this.IdRadacina, this.Tip, (T)Detalii);
            }
            else if (Detalii is JObject)
            {
                var detalii = ((JObject)this.Detalii).ToObject<T>();
                eveniment = new EvenimentGeneric<T>(this.IdRadacina, this.Tip, detalii);
            }
            else
            {
                throw new InvalidCastException();
            }
            return eveniment;
        }
    }

    public class EvenimentGeneric<T> : Eveniment
    {
        public EvenimentGeneric(PlainText idRadacina, TipEveniment tipEveniment, T detalii)
            : base(idRadacina, tipEveniment, detalii)
        {
        }

        public new T Detalii { get => (T)base.Detalii; }
    }
}
