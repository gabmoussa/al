using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    [Serializable]
    public class Set
    {
        public List<Coup> coups { get; set; }
        public Match match;
        public Match Match
        {
            get { return match; }
        }
        public SerializableDictionary<Joueur, int> scoreJoueur;
        public int numeroSet;
        public Jeu jeu;
        public Set() { }
        public Set(int numSet)
        {
            coups = new List<Coup>();
            scoreJoueur = new SerializableDictionary<Joueur, int>();
            numeroSet = numSet;
            jeu = new Jeu();
        }

        public void addCoup(Coup c)
        {
            coups.Add(c);
            c.SetSet(this);
        }

        public void setMatch(Match m)
        {
            this.match = m;
            scoreJoueur.Add(match.getJoueurs()[0], 0);
            scoreJoueur.Add(match.getJoueurs()[1], 0);
            jeu.setJoueur(match.getJoueurs()[0], match.getJoueurs()[1]);
        }

        public void incrementPoint(Joueur j)
        {
            scoreJoueur[j]++;

        }

        public int getpoint(Joueur j)
        {
            return scoreJoueur[j];
        }
        public int getPoint(string j)
        {
            foreach(var kv in scoreJoueur){
                if (kv.Key.nom == j)
                    return kv.Value;
            }
            return -1;
        }
        public int[] getpoint()
        {

            int[] score = new int[2];
            int i = 0;
            foreach (KeyValuePair<Joueur, int> entry in scoreJoueur)
            {
                score[i] = entry.Value;
                i++;
            }

            return score;
        }
    }
}
