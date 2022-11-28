using Bank;
    
namespace BankTest
{
    [TestClass]
    public class KontoTests
    {
        #region UnitTest_101
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

        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Konto_KannNichtMitNegativemBetragErstelltWerden()
        {
            // Arrange
            int guthaben = -1;
            // Act
            Konto k = new Konto(guthaben);
        }

        [TestMethod]
        public void KontoNr_KannAbgefragtWerden()
        {
            // Arrange
            Konto k = new Konto(0);
            int nummer_soll = 1;
            // Act
            int nummer_ist = k.KontoNr;
            //Arrange
            Assert.AreEqual(nummer_soll, nummer_ist);
        }

        [TestMethod]
        public void KontoNr_WirdAutomatischVergeben()
        {
            // Arrange
            Konto k1 = new Konto(0);
            Konto k2 = new Konto(0);
            Konto k3 = new Konto(0);
            int kontoNummer_soll = 3;
            // Act
            int kontoNummer_ist = k3.KontoNr;
            // Assert
            Assert.AreEqual(kontoNummer_soll, kontoNummer_ist);
        }
    }
}
