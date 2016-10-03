using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Project1
{
    class DataProducer
    {
        private List<Match> matchs {get; set;}
        private MessageQueue msgQ {get; set;}
        private const String queueName = ".\\Private$\\newPrivQueue";

        public DataProducer()
        {
    
            Joueur joueur1match1 = new Joueur("Novak" ,"Djokovic");
            Joueur joueur2match1 = new Joueur("Roger" ,"Federer");
 	        Joueur joueur1match2 = new Joueur("Rafael","Nadal");
 	        Joueur joueur2match2 = new Joueur("Andy" ,"Murray");
 	        Joueur joueur1match3 = new Joueur("Kei", "Nishikori");
 	        Joueur joueur2match3 = new Joueur("Milos", "Raonic");
 	        Joueur joueur1match4 = new Joueur("Tomas", "Berdych");
 	        Joueur joueur2match4 = new Joueur("Stan", "Wawrinka");

            Match m1 = new Match(DateTime.Now, joueur1match1, joueur2match1);
            Match m2 = new Match(DateTime.Now, joueur1match2, joueur2match2);
            Match m3 = new Match(DateTime.Now, joueur1match3, joueur2match3);
            Match m4 = new Match(DateTime.Now, joueur1match4, joueur2match4);

            matchs = new List<Match>();
            matchs.Add(m1);
            matchs.Add(m2);
            matchs.Add(m3);
            matchs.Add(m4);

            if (!MessageQueue.Exists(queueName))
                try
                {
                    msgQ = MessageQueue.Create(queueName);
                }
                catch (Exception)
                {
                    Console.Write("exeption");
                }
            else
                msgQ = new MessageQueue(queueName);
        }

        public static void Main()
        {

            DataProducer producer = new DataProducer();
            bool[] lastCoupGagnant = { true, true, true, true };
            int joueur = 0;
            while(true)
            {
                int nbmatch = 0;
                foreach (Match m in producer.matchs){
                    Coup c =new Coup(m.getJoueurs()[joueur], producer.GetRandomTypeCoup(lastCoupGagnant[nbmatch]), producer.GetRandomPosition(), producer.IsCoupGagnant());
                    lastCoupGagnant[nbmatch] = c.gagnant;
                    producer.msgQ.Send(c);
                    nbmatch++;
                    System.Threading.Thread.Sleep(500);

                }
                    joueur = (joueur + 1) % 2;
            }
        }

        
        private String GetRandomTypeCoup(bool lastCoupGagnt)
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 200);

            if(lastCoupGagnt)
                 return "Service";

            if (i < 100)
            {
                return "coup droit";
            }
            else
            {
                return "revers";
            }

        }

        private String GetRandomPosition()
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 3);

            switch(i)
            {
                case 1 : return "droite";
                case 2 : return "centre";
                case 3 : return "gauche";
            }

            return "centre";

        }

        private bool IsCoupGagnant()
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 100);
            if(i > 80)
                return true;
            else
                return false;
        }
}
}
