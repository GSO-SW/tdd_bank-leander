using System;

using System.Runtime.CompilerServices;
namespace Bank
{
    internal static class Program
    {
        static void Main()
        {
            // In dieser Datei muss eigentlich nichts bearbeitet werden. 
            // Wir brauchen nur Tests.
            Console.WriteLine("Hello World");

            Konto konto3 = new Konto(33);

            konto3.Auszahlen(30);
            //decimal restGuthaben = konto3.Schließen();

            //bool kontoSchliessung = (restGuthaben == 3m) && (Unsafe.IsNullRef(ref konto3));

            //Console.WriteLine(kontoSchliessung);

            //konto3.Einzahlen(10);

            //Console.WriteLine(konto3.Guthaben);
        }
    }
}
