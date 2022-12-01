using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Tagesgeld
    {
        private readonly Konto verrechnungsKonto;

        public decimal Zinssatz { get; set; }

        public int VerrechnungsKontoNr
        {
            get
            {
                return verrechnungsKonto.KontoNr;
            }
        }

        public decimal Guthaben
        {
            get
            {
                return verrechnungsKonto.Guthaben;
            }
        }

        public Tagesgeld(Konto verrechnungsKonto)
        {
            this.verrechnungsKonto = verrechnungsKonto;
        }

        public void Einzahlen(decimal betrag)
        {
            verrechnungsKonto.Einzahlen(betrag);
        }
    }
}
