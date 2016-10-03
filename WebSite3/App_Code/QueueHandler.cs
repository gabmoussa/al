using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Project1;

namespace statsModule
{


    public class QueueHandler
    {
        private MessageQueue inputQueue { get; set; }
        private const String inputQueueName = ".\\Private$\\newPrivQueue";

        private MessageQueue scoreQueue { get; set; }
        private const String scoreName = ".\\Private$\\scoreQueue";

        private MessageQueue statsQueue { get; set; }
        private const String statsName = ".\\Private$\\statsQueue";

        private StatCalculation statCalculation;

        public QueueHandler(StatCalculation sc){

            statCalculation = sc;
        try
           {
               if (!MessageQueue.Exists(inputQueueName))
                   inputQueue = MessageQueue.Create(inputQueueName);
               else
                   inputQueue = new MessageQueue(inputQueueName);

               if (!MessageQueue.Exists(scoreName))
                   scoreQueue = MessageQueue.Create(scoreName);
               else
                   scoreQueue = new MessageQueue(scoreName);

               if (!MessageQueue.Exists(statsName))
                   statsQueue = MessageQueue.Create(statsName);
               else
                   statsQueue = new MessageQueue(statsName);
             }
             catch (Exception)
             {
                  Console.Write("exeption");
             }
        }

        public void readIput()
        {
            inputQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Coup) });
            Message m = inputQueue.Receive();
            Coup coup = (Coup) m.Body;
            if (coup.gagnant)
            {
                statCalculation.computeScore(coup);
            }
            statCalculation.computeStat(coup);
        }

        public void sendStatistics(statistics s) 
        {
            statsQueue.Send(s);

        }

        public void sendScore(Set s)
        {
            scoreQueue.Send(s);        
        }

        public void sendNewMatch(Match m)
        {
            statsQueue.Send(m, "match");
        }


    }
}
