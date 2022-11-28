namespace KontoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KontoEroeffnenTest()
        {
            Konto konto1 = new Konto(33);

            Assert.IsTrue(konto1 != null);
        }

        [TestMethod]
        public void EinzahlenTest()
        {
            Konto konto2 = new Konto(69);

            konto2.Einzahlen(420);

            Assert.AreEqual(konto2.Guthaben, 489);
        }

        [TestMethod]
        public void AuszahlenTest()
        {
            Konto konto3 = new Konto(33);

            konto3.Auszahlen(30);

            Assert.AreEqual(konto3.Guthaben, 3);
        }

        [TestMethod]
        public void SchliessenTest()
        {
            int restGuthaben;
            Konto konto3 = new Konto(33);

            konto3.Auszahlen(30);
            restGuthaben = konto3.Guthaben;

            for (int i = 0; i < konto3.Guthaben;)
            {
                konto3.Auszahlen(1);
            }

            bool kontoSchliessung = (restGuthaben == 3) && (konto3.Guthaben == 0);

            Assert.IsTrue(kontoSchliessung);
            //Assert.AreEqual(konto3.Guthaben, 0m);
            //Assert.AreEqual(restGuthaben, 3m);
        }
    }
}