using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Banque;

namespace BanqueTest
{
    [TestClass]
    public class CompteBancaireTests
    {
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
    }
}
