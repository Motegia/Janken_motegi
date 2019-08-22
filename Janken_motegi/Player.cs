using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Player
    {
        public static int PlayerNum;
        public static List<int> PlayerHand = new List<int>();
        public static List<float> PlayerWinningPercentage = new List<float>();

        public static int GetPlayerNum()
        {
            int n = int.Parse(Console.ReadLine());
            return n;
        }

        public static void DecideHand()
        {
            for (int i = 0; i < PlayerNum; i++)
            {
                Console.WriteLine("●プレイヤー" + (i + 1) + "は何を出しますか？");
                Game.Print();
                int x = int.Parse(Console.ReadLine());

                while (!(x == 1 || x == 2 || x == 3))
                {
                    Console.WriteLine("数字は1～3で選んでください！(怒)");
                    Game.Print();
                    x = int.Parse(Console.ReadLine()); //プレイヤーの入力した数値を格納する変数
                }
                PlayerHand.Add(x);
                Game.AllHand.Add(x);
            }
        }

    }
}