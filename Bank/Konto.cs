using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
            if (Guthaben - betrag < 0)
            {
                throw new ArgumentOutOfRangeException("Nicht genug Guthaben");
            }

            if (betrag <= 0)
            {
                throw new ArgumentOutOfRangeException("Ungültiger Betrag");
            }

            Einzahlen(-betrag);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public decimal Schließen()
        {
            if (this is null)
            {
                return 0;
            }

            decimal betrag = Guthaben;

            IntPtr i = Marshal.AllocHGlobal(Marshal.SizeOf(Guthaben));
            IntPtr thisRef = Marshal.AllocHGlobal(Marshal.SizeOf(this));

            try
            {
                Marshal.StructureToPtr(Guthaben, i, true);
                Marshal.StructureToPtr(this, thisRef, true);
            }
            finally
            {
                Marshal.FreeHGlobal(i);
                Marshal.FreeHGlobal(thisRef);
            }

            return betrag;
        }
    }
}
