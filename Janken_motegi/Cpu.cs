using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Janken
{
    class Cpu
    {
        public static int CpuNum;
        public static List<int> CpuHand = new List<int>();
        public static List<float> CpuWinningPercentage = new List<float>();
        public static Random Rnd = new System.Random();


        public static int GetCpuNum()
        {
            int x = int.Parse(Console.ReadLine());
            return x;
        }

        public static void DecideHand()
        {
            for (int i = 0; i < CpuNum; i++)
            {
                int x = Rnd.Next(1, 4);
                CpuHand.Add(x);
                Game.AllHand.Add(x);
                x = Rnd.Next(1, 4);
            }

        }


    }
}