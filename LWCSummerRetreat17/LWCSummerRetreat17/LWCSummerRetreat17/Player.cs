using System;
using System.Collections;
using System.IO;

namespace LWCSummerRetreat17
{
    class Player
    {
        public string firstName;
        public string lastName;
        public int id;
        public double balance;

        public Player(string firstName, string lastName, int id, double balance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.balance = balance;
        }

        //edits a player's balance but DOES NOT relay edits to master folder
        public static void editBalance(ref Player player, double value)
        {
            //value can be positive or negative. value is added to the original balance
            player.balance = player.balance + value;
        }

        //edits the two players' balances accordingly and DOES relay edits to master folder
        public static Boolean transferCurrency(int srcID, int destID, double value)
        {
            ArrayList allPlayers = GameIO.load(0);

            Player src;
            Player dest;
            if (srcID == 0)
            {
                src = (Player)allPlayers[GameIO.numPlayers];
            }
            else
            {
                src = (Player)allPlayers[srcID - 1];
            }

            if (destID == 0)
            {
                dest = (Player)allPlayers[GameIO.numPlayers];
            }
            else
            {
                dest = (Player)allPlayers[destID - 1];
            }

            if (src.balance < value)
            {
                //not enough funds to transfer
                return false;
            }

            //make changes to balance accordingly
            src.balance -= value;
            dest.balance += value;
            
            //save src and dest changes to master folder
            return GameIO.save(allPlayers, 0);
        }
    }
}
