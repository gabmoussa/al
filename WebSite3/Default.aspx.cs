using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using statsModule;
using Project1;

public partial class _Default : System.Web.UI.Page 
{
    static public int test = 0;
    
    private MessageQueue statsQueue { get; set; }
    private const String statsName = ".\\Private$\\statsQueue";
    
    private MessageQueue scoreQueue { get; set; }
    private const String scoreName = ".\\Private$\\scoreQueue";

    private MessageQueue matchQueue { get; set; }
    private const String matchName = ".\\Private$\\matchQueue";

    private Boolean initQueue = true;
    private Boolean initMatch = true;

    static public  Match LEmatch;
    static public string joueurA;
    static public string joueurB;

    static public statistics statsA = new statistics();
    static public statistics statsB = new statistics();

    static public string scoreA = "0";
    static public string scoreB = "0";

    static public string scoreAPdtSet = "0";
    static public string scoreBPdtSet = "0";

    static public string scoreAPdtSet2 = "0";
    static public string scoreBPdtSet2 = "0";

    static public string scoreAPdtSet3 = "0";
    static public string scoreBPdtSet3 = "0";
    private void init()
    {
        initQueue = false;
        if (!MessageQueue.Exists(statsName))
            statsQueue = MessageQueue.Create(statsName);
        else
            statsQueue = new MessageQueue(statsName);
        if (!MessageQueue.Exists(scoreName))
            scoreQueue = MessageQueue.Create(scoreName);
        else
            scoreQueue = new MessageQueue(scoreName);
        if (!MessageQueue.Exists(matchName))
            matchQueue = MessageQueue.Create(matchName);
        else
            matchQueue = new MessageQueue(matchName);
        
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (initQueue)
        {
            init();
        }

        matchQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Match) });
        Message mm=null;
        if ( initMatch)
        {
            if (LEmatch == null)
            {
                mm = matchQueue.Receive();
                LEmatch = (Match)mm.Body;
                joueurA = LEmatch.getJoueurs().ElementAt(0).nom;
                joueurB = LEmatch.getJoueurs().ElementAt(1).nom;
                initMatch = false;
            }
        }

        statsQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(statistics) });
        Message m = statsQueue.Receive();
        statistics stats = (statistics)m.Body;
        if(LEmatch!=null)
        {
            string a = stats.Joueur.nom;
            string b = joueurA;
            string c = joueurB;
            if (stats.Joueur.nom == (joueurA) /*&& LEmatch == (stats.Match)*/)
                statsA = stats;
            else if (stats.Joueur.nom.Equals(joueurB) /*&& LEmatch.Equals(stats.Match)*/)
                statsB = stats;
        }

        scoreQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Set) });
        Message msgSet = scoreQueue.Receive();
        Set setScore = (Set)msgSet.Body;

        scoreA = setScore.jeu.getScoreJoueur(joueurA).ToString() != "-1" ? setScore.jeu.getScoreJoueur(joueurA) : scoreA;
        scoreB = setScore.jeu.getScoreJoueur(joueurB).ToString() != "-1" ? setScore.jeu.getScoreJoueur(joueurB) : scoreB;

        if (setScore.numeroSet == 1) {
            scoreAPdtSet = setScore.getPoint(joueurA).ToString() != "" ? setScore.getPoint(joueurA).ToString() : scoreAPdtSet;
            scoreBPdtSet = setScore.getPoint(joueurB).ToString() != "" ? setScore.getPoint(joueurB).ToString() : scoreBPdtSet;
        }
        if (setScore.numeroSet == 2) {
            scoreAPdtSet2 = setScore.getPoint(joueurA).ToString() != "" ? setScore.getPoint(joueurA).ToString() : scoreAPdtSet2;
            scoreBPdtSet2 = setScore.getPoint(joueurB).ToString() != "" ? setScore.getPoint(joueurB).ToString() : scoreBPdtSet2;
        }
        if (setScore.numeroSet == 3) {
            scoreAPdtSet3 = setScore.getPoint(joueurA).ToString() != "" ? setScore.getPoint(joueurA).ToString() : scoreAPdtSet3;
            scoreBPdtSet3 = setScore.getPoint(joueurB).ToString() != "" ? setScore.getPoint(joueurB).ToString() : scoreBPdtSet3;
        }
        Random RandomClass = new Random();
        int n = RandomClass.Next(1, 9);
        test = test+1;
    }
}
