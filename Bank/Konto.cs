using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Bank
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Konto
    {
        private static int kontoZaehler = 0;

        public readonly int KontoNr;
        public decimal Guthaben
        {
            get;
            private set;
        }

        public Konto(decimal startGuthaben = 0)
        {
            KontoNr = ++kontoZaehler;

            //KontoNr = GetHashCode();

            Guthaben = startGuthaben switch
            {
                >= 0 => startGuthaben,
                _ => throw new ArgumentOutOfRangeException("Der Betrag muss positiv oder 0 sein")
            }; 
        }

        //~Konto()
        //{
        //    kontoZaehler--;
        //}

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


        [MethodImpl(MethodImplOptions.Synchronized)]
        public decimal Schließen()
        {
            if (this is null)
            {
                return 0;
            }

            decimal betrag = Guthaben;

            Guthaben = 0;

            IntPtr thisRef = IntPtr.Zero;

            try
            {
                thisRef = Marshal.AllocHGlobal(Marshal.SizeOf<Konto>());

                Marshal.StructureToPtr(this, thisRef, false);
                Marshal.DestroyStructure<Konto>(thisRef);
            }
            catch (AccessViolationException)
            {
                return 0;
            }
            catch (OutOfMemoryException)
            {
                return 0;
            }
            finally
            {
                if (thisRef != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(thisRef);

                    GC.Collect();
                }
            }

            return betrag;
        }
    }
}
