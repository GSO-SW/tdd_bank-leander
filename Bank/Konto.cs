using System;
using System.Runtime.CompilerServices;

namespace Bank
{
    internal sealed class Konto
    {
        public decimal Guthaben
        {
            get;
            private set;
        }

        public Konto(decimal startGuthaben = 0)
        {
            checked
            {
                Guthaben = startGuthaben switch
                {
                    >= 0 => Guthaben,
                    _ => throw new ArgumentOutOfRangeException("Der Betrag muss positiv oder 0 sein")
                }; 
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Konto Eröffnen(decimal startGuthaben = 0)
        {
            return new Konto(startGuthaben);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Einzahlen(decimal betrag)
        {
            checked
            {
                Guthaben += betrag;
            }
        }

        public void Auszahlen(decimal betrag)
        {
            if (betrag > 0) Einzahlen(-betrag);
        }
    }
}
