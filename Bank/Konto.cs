using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Bank
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Konto
    {
        public int guthaben
        {
            get;
            private set;
        }

        public Konto(int startGuthaben = 0)
        {
            checked
            {
                guthaben = startGuthaben switch
                {
                    >= 0 => startGuthaben,
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
        public void Einzahlen(int betrag)
        {
            checked
            {
                guthaben += betrag;
            }
        }

        public void Auszahlen(decimal betrag)
        {
            if (guthaben - betrag < 0)
            {
                throw new ArgumentOutOfRangeException("Nicht genug guthaben");
            }

            if (betrag <= 0)
            {
                throw new ArgumentOutOfRangeException("Ungültiger Betrag");
            }

            Einzahlen(-betrag);
        }

        public decimal Schließen()
        {
            if (this is null)
            {
                return 0;
            }

            decimal betrag = Guthaben;

            Guthaben = 0;

            return betrag;
        }
    }
}