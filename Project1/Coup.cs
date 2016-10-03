using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    [Serializable]
    public class Coup
    {
        public Joueur joueur;
        public String typeCoup;
        public String position;
        private Set set;
        public bool gagnant;

        public Coup() {}

        public Coup(Joueur j, String type, String p, bool g)
        {
            joueur = j;
            typeCoup = type;
            position = p;
            gagnant = g;
        }

        public void SetSet(Set s)
        {
            set = s;
        }

        public bool IsGagnant()
        {
            return gagnant;
        }

        public String toString()
        {
            return "coup de " + joueur.nom + "de type " + typeCoup + "sur la position " + position +"dans le match " + set.match.Joueurs[0].nom + "-" + set.match.Joueurs[1].nom + ". Le coup est gagnant : " + gagnant;
        }
    }
}
