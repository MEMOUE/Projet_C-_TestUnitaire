using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    /// <summary>
    /// Classe démo pour un compte bancaire.
    /// </summary>
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloque = false;

        // Constructeur privé par défaut
        private CompteBancaire() { }

        // Constructeur principal
        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        // Propriété pour obtenir le nom du client
        public string NomClient
        {
            get { return m_nomClient; }
        }

        // Propriété pour obtenir le solde
        public double Balance
        {
            get { return m_solde; }
        }

        // Méthode pour débiter un montant du compte
        public void Debiter(double montant)
        {
            if (m_bloque)
            {
                throw new Exception("Le compte est bloqué.");
            }

            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant", "Le montant débité doit être inférieur ou égal au solde disponible.");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant", "Le montant doit être positif.");
            }

            m_solde -= montant; // Correction : soustraire le montant
        }

        // Méthode pour créditer un montant au compte
        public void Crediter(double montant)
        {
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant", "Le montant doit être positif.");
            }

            m_solde -= montant;
        }

        // Méthode pour bloquer le compte
        public void BloquerCompte()
        {
            m_bloque = true;
        }

        // Méthode pour débloquer le compte
        public void DebloquerCompte()
        {
            m_bloque = false;
        }

        public static void Main(string[] args)
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
            cb.Crediter(500000);
            cb.Debiter(400000);
            Console.WriteLine("Solde Disponible Egal à F{0}", cb.Balance); // Correction : bon format pour afficher le solde
        }
    }
}
