using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCSummerRetreat17
{
    class Game1
    {
        public int id;
        public double gameBalance;
        public int victoryPoints;
        public Boolean isInfected;
        public int vaccines;

        public Game1(int id, double gameBalance, int victoryPoints, Boolean isInfected, int vaccines)
        {
            this.id = id;
            this.gameBalance = gameBalance;
            this.victoryPoints = victoryPoints;
            this.isInfected = isInfected;
            this.vaccines = vaccines;
        }

        public ArrayList playerToGame1()
        {
            ArrayList allPlayerAsGame1 = new ArrayList(GameIO.numPlayers);
            for(int i = 0; i < GameIO.numPlayers; i++)
            {
                Game1 member = new Game1((i+1), 0, 0, false, 0);
                allPlayerAsGame1.Add(member);
            }
            return allPlayerAsGame1;
        }
    }
}
