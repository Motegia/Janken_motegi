using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Judge
    {
        public static int BattleNum;
        public static int[] PlayerWinningCount;
        public static int[] CpuWinningCount;


        static void Main(string[] args)
        {
            Console.WriteLine("###############################################");
            Console.WriteLine("#                                             #");
            Console.WriteLine("#     プレイヤーとCPUのじゃんけん大会です     #");
            Console.WriteLine("#                                             #");
            Console.WriteLine("# 　　プレイヤーはP、CPUはCと表記します。 　　#");
            Console.WriteLine("#                                             #");
            Console.WriteLine("###############################################");
            Console.WriteLine("");
            Console.WriteLine("プレイヤーは何人参加しますか？");
            Player.PlayerNum = Player.GetPlayerNum();

            Console.WriteLine("CPUは何人参加させますか？");
            Cpu.CpuNum = Cpu.GetCpuNum();

            Console.WriteLine("何戦勝負にしますか？");
            BattleNum = int.Parse(Console.ReadLine());

            PlayerWinningCount = new int[Player.PlayerNum];
            CpuWinningCount = new int[Cpu.CpuNum];
            Random Rnd = new System.Random();
            for (int n = 1; n <= BattleNum; n++)
            {
                Console.WriteLine(n + "回戦目");
                Game.Janken();
                Console.WriteLine("");
                WinJudge(Game.HandType);
                Game.Clear();
            }
            Output.OutputConsole();
            Output.OutputFile();

        }
        static void WinJudge(int x)
        {
            if (x == Game.WinGuu)
            {
                Console.WriteLine("");
                Console.WriteLine("グーを出した人の勝ちです。");
                Console.WriteLine("勝者は");
                for (int i = 0; i < Player.PlayerNum; i++)
                {
                    if (Player.PlayerHand[i] == Game.Guu)
                    {
                        PlayerWinningCount[i] += 1;
                        Console.WriteLine("P" + (i + 1));
                    }
                }
                for (int i = 0; i < Cpu.CpuNum; i++)
                {
                    if (Cpu.CpuHand[i] == Game.Guu)
                    {
                        CpuWinningCount[i] += 1;
                        Console.WriteLine("C" + (i + 1));
                    }
                }
                Console.WriteLine("以上です。");
                Console.WriteLine("--------------------------------------");
            }
            else if (x == Game.WinChoki)
            {
                Console.WriteLine("");
                Console.WriteLine("チョキを出した人の勝ちです。");
                Console.WriteLine("勝者は");
                for (int i = 0; i < Player.PlayerNum; i++)
                {
                    if (Player.PlayerHand[i] == Game.Choki)
                    {
                        PlayerWinningCount[i] += 1;
                        Console.WriteLine("P" + (i + 1));
                    }
                }
                for (int i = 0; i < Cpu.CpuNum; i++)
                {
                    if (Cpu.CpuHand[i] == Game.Choki)
                    {
                        CpuWinningCount[i] += 1;
                        Console.WriteLine("C" + (i + 1));
                    }
                }
                Console.WriteLine("以上です。");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("パーを出した人の勝ちです。");
                Console.WriteLine("勝者は");
                for (int i = 0; i < Player.PlayerNum; i++)
                {
                    if (Player.PlayerHand[i] == Game.Paa)
                    {
                        PlayerWinningCount[i] += 1;
                        Console.WriteLine("P" + (i + 1));
                    }
                }
                for (int i = 0; i < Cpu.CpuNum; i++)
                {
                    if (Cpu.CpuHand[i] == Game.Paa)
                    {
                        CpuWinningCount[i] += 1;
                        Console.WriteLine("C" + (i + 1));
                    }
                }
                Console.WriteLine("以上です。");
                Console.WriteLine("--------------------------------------");
            }
        }


    }
}