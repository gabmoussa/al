using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;

namespace statsModule
{
    public class statistics
    {
        private Match match;
        public Match Match { get { return match; } set { match = value; } }
        private Joueur joueur;
        public Joueur Joueur { get { return joueur; } set { joueur = value; } }

        private double tauxServiceGagnant;
        public double TauxServiceGagnant { get { return tauxServiceGagnant; } set { tauxServiceGagnant = value; } }
        private double tauxCoupDroitGagnant;
        public double TauxCoupDroitGagnant { get { return tauxCoupDroitGagnant; } set { tauxCoupDroitGagnant = value; } }
        private double tauxReversGagnant;
        public double TauxReversGagnant { get { return tauxServiceGagnant; } set { tauxReversGagnant = value; } }

        private int nbService;
        public int NbService { get { return nbService; } set { nbService = value; } }
        private int nbRevers;
        public int NbRevers { get { return nbRevers; } set { nbRevers = value; } }
        private int nbDroit;
        public int NbDroit { get { return nbDroit; } set { nbDroit = value; } }

        private int nbServiceGagnant;
        public int NbServiceGagnant { get { return nbServiceGagnant; } set { nbServiceGagnant = value; } }
        private int nbReversGagnant;
        public int NbReversGagnant { get { return nbReversGagnant; } set { nbReversGagnant = value; } }
        private int nbDroitGagnant;
        public int NbDroitGagnant { get { return nbDroitGagnant; } set { nbDroitGagnant = value; } }

        private int nbCoupTotal;
        public int NbCoupTotal { get { return nbCoupTotal; } set { nbCoupTotal = value; } }

        private int nbDroite;
        public int NbDroite { get { return nbDroite; } set { nbDroite = value; } }
        private int nbGauche;
        public int NbGauche { get { return nbGauche; } set { nbGauche = value; } }
        private int nbCentre;
        public int NbCentre { get { return nbCentre; } set { nbCentre = value; } }

        private double tauxDroite;
        public double TauxDroite { get { return tauxDroite; } set { tauxDroite = value; } }
        private double tauxGauche;
        public double TauxGauche { get { return tauxGauche; } set { tauxGauche = value; } }
        private double tauxCentre;
        public double TauxCentre { get { return tauxCentre; } set { tauxCentre = value; } }

        public statistics(Match m, Joueur j)
        {
            match = m;
            joueur = j;

            tauxServiceGagnant = 0;
            tauxCoupDroitGagnant = 0;
            tauxReversGagnant = 0;
            nbService = 0;
            nbRevers = 0;
            nbDroit = 0;
            nbServiceGagnant = 0;
            nbReversGagnant = 0;
            nbDroitGagnant = 0;
            nbCoupTotal = 0;
        }

        public statistics() { }
        
    }
}
