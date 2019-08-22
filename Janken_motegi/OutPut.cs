using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Janken
{
    class Output
    {

        public static void OutputConsole()
        {
            Console.WriteLine("成績を見ますか？");
            Console.WriteLine("1:見る　　2：見ない");
            int Seeing = int.Parse(Console.ReadLine());

            if (Seeing == 1)
            {
                Console.WriteLine("【結果発表】");
                for (int i = 0; i < Player.PlayerNum; i++)
                {
                    Player.PlayerWinningPercentage.Add(((float)Judge.PlayerWinningCount[i] / (float)Judge.BattleNum) * 100);
                    Console.Write("P" + (i + 1) + ":" + "勝ち:" + Judge.PlayerWinningCount[i] + "回" + ",  " + "負け:" + (Judge.BattleNum - Judge.PlayerWinningCount[i]) + "回" + ",  " + "勝率:" + Player.PlayerWinningPercentage[i].ToString("f2") + "%");
                    Console.WriteLine("");
                }
                for (int i = 0; i < Cpu.CpuNum; i++)
                {
                    Cpu.CpuWinningPercentage.Add(((float)Judge.CpuWinningCount[i] / (float)Judge.BattleNum) * 100);
                    Console.Write("C" + (i + 1) + ":" + "勝ち:" + Judge.CpuWinningCount[i] + "回" + ",  " + "負け:" + (Judge.BattleNum - Judge.CpuWinningCount[i]) + "回" + ",  " + "勝率:" + Cpu.CpuWinningPercentage[i].ToString("f2") + "%");
                    Console.WriteLine("");
                }
                Console.WriteLine();

            }
        }

        public static void OutputFile()
        {
            Console.WriteLine("この結果をファイルに出力しますか？");
            Console.WriteLine("1:出力する　　2：出力しない");
            int Seeing = int.Parse(Console.ReadLine());
            if (Seeing == 1)
            {
                Console.WriteLine("結果ファイルの出力先のパスを入力して下さい");
                string Path = Console.ReadLine();
                Console.WriteLine("結果ファイルの名前を拡張子も含めて入力して下さい");
                string Name = Console.ReadLine();
                string PathName = Path + "\\" + Name;
                Encoding enc = Encoding.GetEncoding("Shift_JIS"); //文字化け防止のため文字コードをShift-JISに指定
                var resultfile = new StreamWriter(@PathName, append: false, encoding: enc); //ファイルを開く
                resultfile.WriteLine("【結果発表】");

                if (SubstringRight(Name, 3) == "csv" || SubstringRight(Name, 3) == "CSV")
                {
                    resultfile.WriteLine(" " + "  ," + "勝ち" + "  ," + "負け" + "  ," + "勝率");
                    for (int i = 0; i < Player.PlayerNum; i++)
                    {
                        Player.PlayerWinningPercentage.Add(((float)Judge.PlayerWinningCount[i] / (float)Judge.BattleNum) * 100);
                        resultfile.Write("P" + (i + 1) + ",  " + Judge.PlayerWinningCount[i] + "回" + ",  " + (Judge.BattleNum - Judge.PlayerWinningCount[i]) + "回" + ",  " + Player.PlayerWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                    for (int i = 0; i < Cpu.CpuNum; i++)
                    {
                        Cpu.CpuWinningPercentage.Add(((float)Judge.CpuWinningCount[i] / (float)Judge.BattleNum) * 100);
                        resultfile.Write("C" + (i + 1) + ",  " + Judge.CpuWinningCount[i] + "回" + ",  " + (Judge.BattleNum - Judge.CpuWinningCount[i]) + "回" + ",  " + Cpu.CpuWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                }
                else
                {
                    for (int i = 0; i < Player.PlayerNum; i++)
                    {
                        Player.PlayerWinningPercentage.Add(((float)Judge.PlayerWinningCount[i] / (float)Judge.BattleNum) * 100);
                        resultfile.Write("P" + (i + 1) + ":" + "勝ち:" + Judge.PlayerWinningCount[i] + "回" + ",  " + "負け:" + (Judge.BattleNum - Judge.PlayerWinningCount[i]) + "回" + ",  " + "勝率:" + Player.PlayerWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                    for (int i = 0; i < Cpu.CpuNum; i++)
                    {
                        Cpu.CpuWinningPercentage.Add(((float)Judge.CpuWinningCount[i] / (float)Judge.BattleNum) * 100);
                        resultfile.Write("C" + (i + 1) + ":" + "勝ち:" + Judge.CpuWinningCount[i] + "回" + ",  " + "負け:" + (Judge.BattleNum - Judge.CpuWinningCount[i]) + "回" + ",  " + "勝率:" + Cpu.CpuWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                }

                resultfile.WriteLine();

                resultfile.Close();

            }

        }
        static string SubstringRight(string target, int length) //文字列targetの右からlength文字取り出して抜き出すメソッド
        {
            return target.Substring(target.Length - length, length);
        }

    }
}