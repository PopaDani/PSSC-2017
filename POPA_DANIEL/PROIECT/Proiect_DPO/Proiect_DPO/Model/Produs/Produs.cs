using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_DPO.Model.Produs;
using Proiect_DPO.Evenimente;


namespace Proiect_DPO.Model.Produs
{
    public class Produs : IProdus
    {
        public PlainText CodBare { get; private set; }
        public PlainText Denumire { get; private set; }
        public PlainText Marca { get; private set; }
        public TipProdus Tip { get; private set; }
        public PlainText Stoc { get; private set; }
        public PlainText Pret { get; private set; }
        public PlainText Descriere { get; private set; }
        public PlainText Garantie { get; private set; }
        public PlainText Furnizor { get; private set; }
        public StareProdus Stare { get; private set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get => _evenimenteNoi.AsReadOnly(); }

        private MagistralaEvenimente _magistralaEveniment;

        public Produs(PlainText codBare, PlainText denumire, PlainText marca, TipProdus tip, PlainText stoc, PlainText pret, PlainText descriere, PlainText garantie, PlainText furnizor, StareProdus stare)
        {
            CodBare = codBare;
            Denumire = denumire;
            Marca = marca;
            Tip = tip;
            Stoc = stoc;
            Pret = pret;
            Descriere = descriere;
            Garantie = garantie;
            Furnizor = furnizor;
            Stare = stare;
        }

        public Produs()
        { }

        public Produs(IEnumerable<Eveniment> evenimente)
        {
            foreach (var e in evenimente)
            {
                RedaEveniment(e);
            }
        }

        public void AdaugaProdus(Produs produs)
        {
            var e = new EvenimentGeneric<Produs>(produs.CodBare, TipEveniment.AdaugareProdus, produs);
            Aplica(e);
            PublicaEveniment(e);
        }

        private void Aplica(EvenimentGeneric<Produs> e)
        {
            Stare = StareProdus.InStoc;
        }

        public string GetCodBare()
        {
            return "11";
        }
        public void StergereProdus(Produs produs)
        {
            if (Stare != StareProdus.InStoc) throw new InvalidOperationException("Nu exista produs pe stoc");
            else
            {
                var e = new EvenimentGeneric<Produs>(produs.CodBare, TipEveniment.StergereProdus, produs);
                AplicaStergere(e);
                PublicaEveniment(e);
            }
        }

        private void AplicaStergere(EvenimentGeneric<Produs> e)
        {
            Stare = StareProdus.StocInsuficient;
        }

        public void PromotieProdus(Produs produs, StareProdus stare)
        {
            if (stare != StareProdus.InStoc) throw new InvalidOperationException("Nu exista produs pe stoc");
            else
            {
                var e = new EvenimentGeneric<Produs>(produs.CodBare, TipEveniment.PromotieProdus, produs);
                AplicaPromotie(e);    ///!!!!!!!!!!!
                PublicaEveniment(e);
            }
        }

        private void AplicaPromotie(EvenimentGeneric<Produs> e)
        {
            Stare = StareProdus.Promotie;
        }

        private void ComandaFurnizori(EvenimentGeneric<Produs> e)
        {
            Stare = StareProdus.LipsaFurnizori;
        }

        public override string ToString()
        {
            return Denumire + "," + Marca + ", " + Tip + ", " + Pret + ", " + Garantie + ", " + Descriere;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void RedaEveniment(Eveniment e)
        {
            switch (e.Tip)
            {
                case TipEveniment.AdaugareProdus:
                    Aplica(e.ToGeneric<Produs>());
                    break;
                case TipEveniment.CautareProdus:
                    Aplica(e.ToGeneric<Produs>());
                    break;
                default:
                    throw new EvenimentNecunoscutException();
            }
        }

        protected void PublicaEveniment(Eveniment eveniment)
        {
            _evenimenteNoi.Add(eveniment);
            //EvenimentMeci?.Invoke(this, eveniment);
            MagistralaEvenimente.Instanta.Value.Trimite(eveniment);
        }
    }
}

