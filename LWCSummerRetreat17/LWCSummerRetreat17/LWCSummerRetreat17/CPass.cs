using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWCSummerRetreat17
{
    class CPass
    {
        public int id;
        public string answer;
        public Boolean isAvail;
        public Boolean isElim;

        public CPass(int id, string answer, Boolean isAvail, Boolean isElim){
            this.id = id;
            this.answer = answer;
            this.isAvail = isAvail;
            this.isElim = isElim;
        }

        public Boolean checkAnswer(string answer)
        {
            if (String.Equals(this.answer, answer))
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static CPass[] createCPasses()
        {
            int lineCount = File.ReadLines("cpasses.txt").Count();
            CPass[] ret = new CPass[lineCount];
            StreamReader file = new StreamReader("cpasses.txt");

            for (int i = 0; i < lineCount; i++)
            {
                string answer = file.ReadLine();
                string temp = file.ReadLine();
                Boolean isElim;
                if(temp == "0")
                {
                    isElim = false;
                }
                else
                {
                    isElim = true;
                }
                ret[i] = new CPass(i + 1, answer, true, isElim);
            }
            file.Close();
            return ret;
        }

        public static void saveCPasses(CPass[] cpasses)
        {
            StreamWriter file = new StreamWriter("cpasses.txt");
            for (int i = 0; i < 20; i++)
            {
                file.WriteLine(cpasses[i].answer);
                if (cpasses[i].isElim == true)
                {
                    file.WriteLine("1");
                }
                else
                {
                    file.WriteLine("0");
                }
            }
            file.Close();
        }

    }
}
