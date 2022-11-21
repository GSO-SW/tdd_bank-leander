using System;

namespace Bank
{
    internal class Konto
    {
        private int guthaben;

        public int Guthaben
        {
            get
            {
                return guthaben;
            }
        }

        public Konto(int guthaben)
        {
            this.guthaben = guthaben;
        }

        public void Einzahlen(int betrag)
        {
            guthaben += betrag;
        }

        public void Auszahlen(int betrag)
        {
            if (guthaben >= betrag)
            {
                guthaben -= betrag;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Guthaben nicht ausreichend");
            }
        }
    }
}
