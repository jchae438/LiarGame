using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCSummerRetreat17
{
    class GameIO
    {
        /* 
         * gameID Key:
         * 0 is Player
         * 1 is Game 1
         * 2 is Game 2
         * 3 is Game 3
         */

        public static int numPlayers = Directory.GetFiles("master").Length;
        public static int game2Round = 1;

        public static Boolean save(ArrayList list, int gameID)
        {
            switch (gameID)
            {
                case 0:
                    for(int i = 0; i < numPlayers; i++)
                    {
                        Player temp = (Player)list[i];
                        string pathName = "master/" + temp.id.ToString() + ".txt";
                        StreamWriter srcFile = new StreamWriter(pathName);
                        srcFile.WriteLine(temp.firstName);
                        srcFile.WriteLine(temp.lastName);
                        string tempBalance = (temp.balance).ToString("F");
                        srcFile.WriteLine(tempBalance);
                        srcFile.Close();
                    }
                    break;
                case 1:
                    string pathName1 = "game1/gamestate.txt";
                    StreamWriter file1 = new StreamWriter(pathName1);
                    int totalVicPoints = 0;
                    file1.WriteLine("yes");
                    for(int i = 0; i < GameIO.numPlayers; i++)
                    {
                        Game1 temp = (Game1)list[i];
                        totalVicPoints += temp.victoryPoints;
                        string vicPointsString = temp.victoryPoints.ToString();
                        file1.WriteLine(vicPointsString);
                    }
                    string totalVicPointsString = totalVicPoints.ToString();
                    file1.WriteLine(totalVicPointsString);
                    file1.Close();
                    break;
                case 2:
                    string pathName2 = "game2/gamestate.txt";
                    StreamWriter file2 = new StreamWriter(pathName2);
                    file2.WriteLine("yes");
                    for(int i = 0; i < GameIO.numPlayers; i++)
                    {
                        Game2 temp = (Game2)list[i];
                        file2.WriteLine(temp.currentCPassID);
                        file2.WriteLine(temp.prevCPassID);
                        file2.WriteLine(temp.isEliminated.ToString());
                    }
                    file2.Close();
                    break;
                case 3:
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static ArrayList load(int gameID)
        {
            string path;
            switch (gameID)
            {
                case 0:
                    ArrayList allPlayers = new ArrayList();
                    for (int id = 0; id < numPlayers; id++)
                    {
                        path = "master/" + (id + 1).ToString() + ".txt";
                        StreamReader file0 = new StreamReader(path);
                        string firstName = file0.ReadLine();
                        string lastName = file0.ReadLine();
                        string balanceString = file0.ReadLine();
                        double balance = double.Parse(balanceString);
                        balance = Math.Round(balance, 2);
                        Player ret = new Player(firstName, lastName, (id + 1), balance);
                        file0.Close();
                        allPlayers.Add(ret);
                    }

                    Player bank = new Player("Bank", "System", 0, 1000000000000);
                    allPlayers.Add(bank);
                    return allPlayers;
                case 1:
                    ArrayList allPlayersAsGame1 = new ArrayList();
                    path = "game1/gamestate.txt";
                    StreamReader file1 = new StreamReader(path);
                    if (file1.ReadLine() == "no")
                    {
                        for (int i = 0; i < GameIO.numPlayers; i++)
                        {
                            Game1 ret = new Game1((i + 1), 0, 0, false, 0);
                            allPlayersAsGame1.Add(ret);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < numPlayers; i++)
                        {
                            string vicPointsString = file1.ReadLine();
                            int vicPoints;
                            int.TryParse(vicPointsString, out vicPoints);
                            Game1 ret = new Game1((i + 1), 0, vicPoints, false, 0);
                            allPlayersAsGame1.Add(ret);
                        }
                    }
                    file1.Close();
                    return allPlayersAsGame1;
                case 2:
                    ArrayList allPlayersAsGame2 = new ArrayList();
                    path = "game2/gamestate.txt";
                    StreamReader file2 = new StreamReader(path);
                    if (file2.ReadLine() == "no")
                    {
                        allPlayersAsGame2 = Game2.playerToGame2();
                    }
                    else
                    {
                        for (int i = 0; i < numPlayers; i++)
                        {
                            int currCPID; int prevCPID; int isEliminated;
                            string currentCPassID = file2.ReadLine();
                            string prevCPassID = file2.ReadLine();
                            string isElim = file2.ReadLine();
                            int.TryParse(currentCPassID, out currCPID);
                            int.TryParse(prevCPassID, out prevCPID);
                            int.TryParse(isElim, out isEliminated);
                            Game2 ret = new Game2((i + 1), currCPID, prevCPID, isEliminated, false);
                            allPlayersAsGame2.Add(ret);
                        }
                    }
                    file2.Close();
                    return allPlayersAsGame2;
                case 3:
                    break;
                default:
                    return null;
            }
            return null;
        }
        
    }
}
