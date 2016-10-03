using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    [Serializable]
    public class Joueur
    {
        public String nom { get; set; }
        public String prenom { get; set; }

        public Joueur() {}

        public Joueur(String prenom, String nom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Joueur);
        }
        public bool Equals(Joueur obj)
        {
            return obj != null && obj.nom == this.nom && obj.prenom==this.prenom;
        }

        public override int GetHashCode()
        {
            return nom.GetHashCode();
        }

    }
}
