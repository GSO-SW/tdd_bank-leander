using Bank;

namespace TagesgeldTests
{
    [TestClass]
    public class TagesgeldTests
    {
        public void Tagesgeld_KannErstelltWerden()
        {
            // Arrange
            Konto verrechnungskonto = new Konto(0);

            // Act
            Tagesgeld t = new Tagesgeld(verrechnungskonto);

            // Assert
            Assert.AreEqual(verrechnungskonto.KontoNr, t.VerrechnungsKontoNr);
            Assert.AreEqual(0, t.Guthaben);
            Assert.AreEqual(0.0, t.Zinssatz);
        }

        [TestMethod]
        public void Zinssatz_KannVeraendertWerden()
        {
            // Arrange
            Tagesgeld t = new Tagesgeld(new Konto(0));
            double neuer_zinssatz = 1.0;


            // Act
            t.Zinssatz = neuer_zinssatz;

            // Assert
            Assert.AreEqual(neuer_zinssatz, t.Zinssatz);

        }

        [TestMethod]
        public void Einzahlen_KommtVonVerrechnungskonto()
        {
            // Arrange
            int kontoStartguthaben = 100;
            Konto k = new Konto(kontoStartguthaben);
            Tagesgeld t = new Tagesgeld(k);
            int betrag = 50;


            // Act
            t.Einzahlen(betrag);

            // Assert
            Assert.AreEqual(kontoStartguthaben - betrag, k.Guthaben);
            Assert.AreEqual(betrag, t.Guthaben);

        }
    }
}