using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    [Serializable]
    public class Jeu
    {
        public Set set;
        public SerializableDictionary<Joueur, String> scoreJoueur;
        public bool tiebreak;

        public Jeu()
        {
            scoreJoueur = new SerializableDictionary<Joueur, String>();
            tiebreak = false;
        }

        public void setJoueur(Joueur j1, Joueur j2)
        {
            scoreJoueur.Add(j1, "0");
            scoreJoueur.Add(j2, "0");
        }
        public void resetJeu()
        {
            List<Joueur> joueurs = new List<Joueur>();
            foreach (KeyValuePair<Joueur, String> entry in scoreJoueur)
            {
                joueurs.Add(entry.Key);
            }
            foreach (Joueur j in joueurs)
                scoreJoueur[j] = "0";
            tiebreak = false;
        }

        public void setTieBreak(bool tb)
        {
            tiebreak = tb;
        }

        public void incrementJeu(Joueur j)
        {
            Joueur other = null;
            foreach (KeyValuePair<Joueur, String> entry in scoreJoueur)
            {


                if (!entry.Key.Equals(j))
                    other = entry.Key;
            }

            if (!tiebreak)
            {
                if (scoreJoueur[j] == "0")
                    scoreJoueur[j] = "15";
                else if (scoreJoueur[j] == "15")
                    scoreJoueur[j] = "30";
                else if (scoreJoueur[j] == "30")
                    scoreJoueur[j] = "40";
                else if (scoreJoueur[j] == "40" && scoreJoueur[other] == "40")
                    scoreJoueur[j] = "avantage";
                else if (scoreJoueur[j] == "40" && scoreJoueur[other] == "avantage")
                    scoreJoueur[other] = "40";
                else
                    scoreJoueur[j] = "jeu";
            }
            else
            {
                int score = Convert.ToInt32(scoreJoueur[j]);
                score++;
                if (score >= 7 && score - Convert.ToInt32(scoreJoueur[other]) >= 2)
                    scoreJoueur[j] = "jeu";
                else
                    scoreJoueur[j] = (score).ToString();

            }
        }

        public String getScoreJoueur(Joueur j)
        {
            return scoreJoueur[j];
        }

        public string getScoreJoueur(string nom)
        {
            foreach (var vk in scoreJoueur)
            {
                if (vk.Key.nom == nom)
                    return scoreJoueur[vk.Key];
            }
            return "";
        }

    }
}
