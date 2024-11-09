using Banque;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BanqueTest
{
    [TestClass]
    public class CompteBancaireTests
    {
        // Test pour vérifier le débit correct d'un montant
        [TestMethod]
        public void VerifierDebitCompteCorrect()
        {
            // Ouvrir un compte
            double soldeInitial = 500000;
            double montantDebit = 400000;
            double soldeAttendu = 100000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter
            compte.Debiter(montantDebit);

            // Tester
            double soldeObtenu = compte.Balance;
            Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
        }

        // Test pour vérifier que débiter un montant négatif lève une exception ArgumentOutOfRangeException
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebiterMontantNegatifLèveArgumentOutOfRange()
        {
            // Ouvrir un compte
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);

            // Débiter un montant négatif
            compte.Debiter(-1000);
        }

        // Test pour vérifier que débiter un montant supérieur au solde lève une exception ArgumentOutOfRangeException
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebiterMontantSupérieurSoldeLèveArgumentOutOfRange()
        {
            // Ouvrir un compte
            double soldeInitial = 500000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter un montant supérieur au solde
            compte.Debiter(soldeInitial + 1000);
        }
    }
}
