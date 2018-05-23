using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCSummerRetreat17
{
    class Game2
    {
        public int playerID;
        public int currentCPassID;
        public int prevCPassID;
        public int isEliminated;
        public Boolean didSit;

        public Game2(int playerID, int currentCPassID, int prevCPassID, int isEliminated, Boolean didSit)
        {
            this.playerID = playerID;
            this.currentCPassID = currentCPassID;
            this.prevCPassID = prevCPassID;
            this.isEliminated = isEliminated;
            this.didSit = didSit;
        }

        public static ArrayList playerToGame2()
        {
            ArrayList allPlayerAsGame2 = new ArrayList(GameIO.numPlayers);
            for (int i = 0; i < GameIO.numPlayers; i++)
            {
                Game2 member = new Game2((i + 1), -1, 0, 0, false);
                allPlayerAsGame2.Add(member);
            }
            return allPlayerAsGame2;
        }
    }
}
