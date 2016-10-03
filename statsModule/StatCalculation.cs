using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace statsModule
{
    public class StatCalculation
    {
        private List<Match> matchEnCours;
        private Dictionary<Joueur, statistics> joueurStats;
        private Dictionary<Joueur, Match> joueurMatch;
        private QueueHandler queueHandler;
        public StatCalculation()
        {
            matchEnCours = new List<Match>();
            joueurStats = new Dictionary<Joueur, statistics>();
            joueurMatch = new Dictionary<Joueur, Match>();

            Joueur joueur1match1 = new Joueur("Novak", "Djokovic");
            Joueur joueur2match1 = new Joueur("Roger", "Federer");
            //Joueur joueur1match1 = new Joueur("Novak", "Djokovic");
            //Joueur joueur2match1 = new Joueur("Roger", "Federer");
            //Joueur joueur1match2 = new Joueur("Rafael", "Nadal");
            //Joueur joueur2match2 = new Joueur("Andy", "Murray");
            //Joueur joueur1match3 = new Joueur("Kei", "Nishikori");
            //Joueur joueur2match3 = new Joueur("Milos", "Raonic");
            //Joueur joueur1match4 = new Joueur("Tomas", "Berdych");
            //Joueur joueur2match4 = new Joueur("Stan", "Wawrinka");

            Match m1 = new Match(DateTime.Now, joueur1match1, joueur2match1);
            //Match m2 = new Match(DateTime.Now, joueur1match2, joueur2match2);
            //Match m3 = new Match(DateTime.Now, joueur1match3, joueur2match3);
            //Match m4 = new Match(DateTime.Now, joueur1match4, joueur2match4);
            
            joueurMatch.Add(joueur1match1,m1);
            joueurMatch.Add(joueur2match1,m1);
            //joueurMatch.Add(joueur1match2,m2);
            //joueurMatch.Add(joueur2match2,m2);
            //joueurMatch.Add(joueur1match3,m3);
            //joueurMatch.Add(joueur2match3,m3);
            //joueurMatch.Add(joueur1match4,m4);
            //joueurMatch.Add(joueur2match4,m4);

            matchEnCours.Add(m1);
            //matchEnCours.Add(m2);
            //matchEnCours.Add(m3);
            //matchEnCours.Add(m4);

            joueurStats.Add(joueur1match1,  new statistics(m1,joueur1match1));
            joueurStats.Add(joueur2match1,  new statistics(m1,joueur2match1));
            //joueurStats.Add(joueur1match2,  new statistics(m2, joueur1match2));
            //joueurStats.Add(joueur2match2,  new statistics(m2, joueur2match2));
            //joueurStats.Add(joueur1match3,  new statistics(m3, joueur1match3));
            //joueurStats.Add(joueur2match3,  new statistics(m3, joueur2match3));
            //joueurStats.Add(joueur1match4,  new statistics(m4, joueur1match4));
            //joueurStats.Add(joueur2match4,  new statistics(m4, joueur2match4));
        }

        public void computeScore(Coup c)
        {
            Set set = joueurMatch[c.joueur].getLastSet();
            set.jeu.incrementJeu(c.joueur);

            if (set.jeu.getScoreJoueur(c.joueur) == "jeu")
            {
                set.jeu.resetJeu();
                set.incrementPoint(c.joueur);

                if (set.getpoint(c.joueur) >= 6)
                {
                    Joueur other;
                    if (!joueurMatch[c.joueur].getJoueurs()[0].Equals(c.joueur))
                        other = joueurMatch[c.joueur].getJoueurs()[0];
                    else
                        other = joueurMatch[c.joueur].getJoueurs()[1];

                    if (set.getpoint(c.joueur) - set.getpoint(other) >= 2)
                    {
                        joueurMatch[c.joueur].addSet(new Set(set.numeroSet + 1));
                    }
                    else if (set.getpoint(c.joueur) == 6 && set.getpoint(other) == 6)
                    {
                        set.jeu.setTieBreak(true);
                    }

                }
            }

            queueHandler.sendScore(set);

        }

        public void computeStat(Coup c)
        {
            joueurMatch[c.joueur].getLastSet().addCoup(c);
            statistics stat = joueurStats[c.joueur];
            stat.NbCoupTotal++;

            if (c.typeCoup == "Service")
            {
                stat.NbService++;
                if (c.gagnant)
                {
                    stat.NbServiceGagnant++;
                    stat.TauxServiceGagnant = (double) (stat.NbServiceGagnant) / (double) (stat.NbService);
                }
            }

            else if (c.typeCoup == "revers")
            {
                stat.NbRevers++;
                if (c.gagnant)
                {
                    stat.NbReversGagnant++;
                    stat.TauxReversGagnant = (double) (stat.NbReversGagnant) / (double) (stat.NbRevers);
                }
            }

            else if (c.typeCoup == "coup droit")
            {
                stat.NbDroit++;
                if (c.gagnant)
                {
                    stat.NbDroitGagnant++;
                    stat.TauxCoupDroitGagnant = (double)(stat.NbDroitGagnant) / (double)(stat.NbDroit);
                }
            }

            if (c.position == "centre")
            {
                stat.NbCentre++;
                stat.TauxCentre = (double) (stat.NbCentre / stat.NbCoupTotal);
            }
            else if(c.position == "gauche")
            {
                stat.NbGauche++;
                stat.TauxGauche = (double) (stat.NbGauche / stat.NbCoupTotal);
            }
            else if (c.position == "droite")
            {
                stat.NbDroite++;
                stat.TauxDroite = (double) (stat.NbDroite / stat.NbCoupTotal);
            }
            queueHandler.sendStatistics(stat);
            IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("matchs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, matchEnCours);
            //stream.Close();
        }

        public void setQueueHandler(QueueHandler qh){
            queueHandler = qh;
            foreach(Match m in matchEnCours){
                queueHandler.sendNewMatch(m);
            }
        }

        public static void Main()
        {
            StatCalculation sc = new StatCalculation();
            QueueHandler qh = new QueueHandler(sc);
            sc.setQueueHandler(qh);

            while (true)
            {
                qh.readIput();
            }
        }

    }
}
