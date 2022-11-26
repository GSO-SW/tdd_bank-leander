using System;

namespace Bank
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Konto
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

        public decimal Schließen()
        {
            if (this is null)
            {
                return 0;
            }

            decimal betrag = Guthaben;

            Guthaben = 0;

            #region Muss überarbeitet werden
            //IntPtr thisRef = IntPtr.Zero;

            //try
            //{
            //    thisRef = Marshal.AllocHGlobal(Unsafe.SizeOf<Konto>());

            //    Marshal.StructureToPtr(this, thisRef, true);
            //}
            //catch (AccessViolationException)
            //{
            //    return 0;
            //}
            //catch (OutOfMemoryException)
            //{
            //    return 0;
            //}
            //finally
            //{
            //    if (thisRef != IntPtr.Zero)
            //    {
            //        Marshal.FreeHGlobal(thisRef);
            //    }
            //} 
            #endregion

            return betrag;
        }
    }
}
