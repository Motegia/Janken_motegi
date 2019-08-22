using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Game
    {
        public const int Initial = 0;
        public const int Guu = 1;
        public const int Choki = 2;
        public const int Paa = 3;
        public const int AllGuu = 100;
        public const int AllChoki = 10;
        public const int AllPaa = 1;
        public const int AllTypes = 111;
        public const int WinGuu = 110;
        public const int WinChoki = 11;
        public const int WinPaa = 101;

        public static int HandType;
        static List<string> Hand = new List<string>();
        public static List<int> AllHand = new List<int>();

        public static void Janken()
        {
            Console.WriteLine("じゃんけんをしましょう。");
            Console.WriteLine("");
            JankenPoi();
            HandType = Bit();
            Console.WriteLine("");

            while (Draw())
            {
                Console.WriteLine("あーいこで");
                Console.WriteLine("");
                Console.WriteLine("");

                Clear();
                HandType = Initial;

                JankenPoi();
                HandType = Bit();
            }

        }
        public static void Print()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1:グー      2:チョキ      3:パー ");
            Console.WriteLine("---------------------------------");
        }
        public static string Convert(int x)
        {
            switch (x)
            {
                case 1:
                    return "グー";
                case 2:
                    return "チョキ";
                case 3:
                    return "パー";
                default:
                    return "";
            }
        }
        public static void PrintHand()
        {
            for (int i = 0; i < Player.PlayerNum; i++)
            {
                Console.Write("P" + (i + 1) + ":" + Convert(Player.PlayerHand[i]) + "  ");
            }
            for (int i = Player.PlayerNum; i < Player.PlayerNum + Cpu.CpuNum; i++)
            {
                Console.Write("C" + (i - Player.PlayerNum + 1) + ":" + Convert(Cpu.CpuHand[i]) + "  ");
            }
        }
        public static void JankenPoi()
        {
            Player.DecideHand();
            Cpu.DecideHand();
            Console.WriteLine("");
            PrintHand();
        }
        public static int Bit()
        {
            int x = 0;
            if (AllHand.Contains(Guu))
            { x += AllGuu; }
            if (AllHand.Contains(Choki))
            { x += AllChoki; }
            if (AllHand.Contains(Paa))
            { x += AllPaa; }
            return x;
        }
        public static bool Draw()
        {
            if ((HandType == AllTypes) || (HandType == AllGuu) || (HandType == AllChoki) || (HandType == AllPaa) || (HandType == 0))
            {
                return true;
            }
            else return false;
        }
        public static void Clear()
        {
            Player.PlayerHand.RemoveRange(0, Player.PlayerNum);
            Cpu.CpuHand.RemoveRange(0, Cpu.CpuNum);
            AllHand.RemoveRange(0, Player.PlayerNum + Cpu.CpuNum);
        }

    }
}

