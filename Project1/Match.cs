using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    [Serializable]
    public class Match
    {
        public DateTime date { get; set; }
        public Joueur[] joueurs;
        public Joueur[] Joueurs{ get{return joueurs;}}
        private List<Set> sets { get; set; }

        public Match()
        {
            sets = new List<Set>();
            addSet(new Set(1));
        }
    
        public Match(DateTime d, Joueur j1, Joueur j2)
        {
            date = d;
            joueurs = new Joueur[2];
            joueurs[0] = j1;
            joueurs[1] = j2;
            sets = new List<Set>();
            addSet(new Set(1));
        }

        public void addSet(Set s){
            sets.Add(s);
            s.setMatch(this);
        }

        public Set getLastSet()
        {
            return sets[sets.Count - 1];
        }

        public Joueur[] getJoueurs()
        {
            return joueurs;
        }

    }
}
