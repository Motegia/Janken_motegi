using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Janken
{
    class Program
    {
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
            int PlayerNum = int.Parse(Console.ReadLine()); //プレイヤーの数を入力
            Console.WriteLine("CPUは何人参加させますか？");
            int CpuNum = int.Parse(Console.ReadLine()); //CPUの数を入力
            Console.WriteLine("何戦勝負にしますか？");
            int BattleNum = int.Parse(Console.ReadLine()); //何回勝負にするか入力

            int[] iplayer = new int[PlayerNum]; //各プレイヤーの手を格納する配列。
            int[] icpu = new int[CpuNum]; //各CPUの手を格納する配列。
            string[] splayer = new string[PlayerNum]; //N番目のプレイヤーが出した手をグー、チョキ、パーとして文字列で格納する配列
            string[] scpu = new string[CpuNum]; //N番目のCPUが出した手をグー、チョキ、パーとして文字列で格納する配列

            int[] PlayerWinningCount = new int[PlayerNum]; //各プレイヤーの勝ち数を格納する配列。
            int[] CpuWinningCount = new int[CpuNum]; //各CPUの勝ち数を格納する配列。
            int[] PlayerLoseCount = new int[PlayerNum]; //各プレイヤーの負け数を格納する配列。
            int[] CpuLoseCount = new int[CpuNum]; //各CPUの負け数を格納する配列。
            float[] PlayerWinningPercentage = new float[PlayerNum]; //各プレイヤーの勝率を格納する配列。
            float[] CpuWinningPercentage = new float[CpuNum];　//各CPUの勝率を格納する配列。

            int[] itotal = new int[PlayerNum + CpuNum]; 　//プレイヤーとCPUの出した手を数値で格納する配列。
            string[] stotal = new string[PlayerNum + CpuNum]; //プレイヤーとCPUの出した手を文字で格納する配列。


            for (int n = 1; n <= BattleNum; n++)
            {
                int gcnt = 0; //グーを出した人をカウントする変数
                int ccnt = 0; //チョキを出した人をカウントする変数
                int pcnt = 0; //パーを出した人をカウントする変数

                if (n >= 2) //2回戦以降の変数の初期化
                {
                    for (int x = 0; x < PlayerNum; x++) //iplayerとsplayerの初期化
                    {
                        iplayer[x] = 0;
                        splayer[x] = "";
                    }

                    for (int x = 0; x < CpuNum; x++) //icpuとscpuの初期化
                    {
                        icpu[x] = 0;
                        scpu[x] = "";
                    }

                }

                Console.WriteLine(n + "回戦目");
                Console.WriteLine("じゃんけんをしましょう。");
                Console.WriteLine("");
                for (int i = 0; i < PlayerNum; i++)
                {
                    Console.WriteLine("●プレイヤー" + (i + 1) + "は何を出しますか？");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("1:グー      2:チョキ      3:パー ");
                    Console.WriteLine("---------------------------------");
                    iplayer[i] = int.Parse(Console.ReadLine()); //プレイヤーの入力した数値を格納する変数
                    splayer[i] = convert(iplayer[i]); //数をグー、チョキ、パーに変換
                    itotal[i] = iplayer[i];
                    stotal[i] = convert(iplayer[i]);

                    while (!(iplayer[i] == 1 || iplayer[i] == 2 || iplayer[i] == 3)) //ユーザーが1,2,3以外を選んだ時の処理
                    {
                        Console.WriteLine("数字は1～3で選んでください！(怒)");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("1:グー      2:チョキ      3:パー");
                        Console.WriteLine("--------------------------------");
                        iplayer[i] = int.Parse(Console.ReadLine()); //プレイヤーの入力した数値を格納する変数
                        splayer[i] = convert(iplayer[i]);
                        itotal[i] = iplayer[i];
                        stotal[i] = convert(iplayer[i]);
                    }
                }

                Random cRandom = new System.Random();  //Randomクラスのあたらしいインスタンスを作成
                for (int i = 0; i < CpuNum; i++)
                {
                    icpu[i] = cRandom.Next(1, 4); //1以上4未満(1から3)の乱数を取得し、CPU側の手とする。
                    scpu[i] = convert(icpu[i]); //数をグー、チョキ、パーに変換
                    itotal[i + PlayerNum] = icpu[i];
                    stotal[i + PlayerNum] = convert(icpu[i]);
                }

                Console.WriteLine("");

                for (int i = 0; i < PlayerNum; i++)
                {
                    Console.Write("P" + (i + 1) + ":" + stotal[i] + "  ");
                }
                for (int i = PlayerNum; i < PlayerNum + CpuNum; i++)
                {
                    Console.Write("C" + (i - PlayerNum + 1) + ":" + stotal[i] + "  ");
                }

                Console.WriteLine("");



                //以下勝敗判定
                for (int i = 0; i < itotal.Length; i++)
                {
                    switch (itotal[i])
                    {
                        case 1:
                            gcnt += 1;
                            break;
                        case 2:
                            ccnt += 1;
                            break;
                        case 3:
                            pcnt += 1;
                            break;
                    }
                }

                bool ap = (gcnt == 0 && ccnt == 0); //パーだけしか場に出ていない時に真を返す変数
                bool ag = (ccnt == 0 && pcnt == 0); //チョキだけしか場に出ていない時に真を返す変数
                bool ac = (pcnt == 0 && gcnt == 0); //グーだけしか場に出ていないときに真を返す変数
                bool all = (gcnt != 0 && ccnt != 0 && pcnt != 0); //場にグー、チョキ、パーがすべて出ているときに真を返す変数


                while (ap || ag || ac || all) //あいこのとき、勝敗が付くまで繰り返す
                {
                    Console.WriteLine("あーいこで");
                    Console.WriteLine("");
                    gcnt = 0; //グーカウンタの初期化
                    ccnt = 0; //チョキカウンタの初期化
                    pcnt = 0; //パーカウンタの初期化

                    for (int i = 0; i < PlayerNum; i++)
                    {
                        Console.WriteLine("●プレイヤー" + (i + 1) + "は何を出しますか？");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("1:グー      2:チョキ      3:パー ");
                        Console.WriteLine("---------------------------------");
                        iplayer[i] = int.Parse(Console.ReadLine()); //プレイヤーの入力した数値を格納する変数
                        splayer[i] = convert(iplayer[i]); //数をグー、チョキ、パーに変換
                        itotal[i] = iplayer[i];
                        stotal[i] = convert(iplayer[i]);

                        while (!(iplayer[i] == 1 || iplayer[i] == 2 || iplayer[i] == 3)) //ユーザーが1,2,3以外を選んだ時の処理
                        {
                            Console.WriteLine("数字は1～3で選んでください！(怒)");
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("1:グー      2:チョキ      3:パー");
                            Console.WriteLine("--------------------------------");
                            iplayer[i] = int.Parse(Console.ReadLine()); //プレイヤーの入力した数値を格納する変数
                            splayer[i] = convert(iplayer[i]);
                            itotal[i] = iplayer[i];
                            stotal[i] = convert(iplayer[i]);
                        }
                    }

                    for (int i = 0; i < CpuNum; i++)
                    {
                        icpu[i] = cRandom.Next(1, 4); //1以上4未満(1から3)の乱数を取得し、CPU側の手とする。
                        scpu[i] = convert(icpu[i]); //数をグー、チョキ、パーに変換
                        itotal[i + PlayerNum] = icpu[i];
                        stotal[i + PlayerNum] = convert(icpu[i]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");

                    for (int i = 0; i < itotal.Length; i++)
                    {
                        switch (itotal[i])
                        {
                            case 1:
                                gcnt += 1;
                                break;
                            case 2:
                                ccnt += 1;
                                break;
                            case 3:
                                pcnt += 1;
                                break;
                        }
                    }

                    for (int i = 0; i < PlayerNum; i++)
                    {
                        Console.Write("P" + (i + 1) + ":" + stotal[i] + "  ");
                    }
                    for (int i = PlayerNum; i < PlayerNum + CpuNum; i++)
                    {
                        Console.Write("C" + (i - PlayerNum + 1) + ":" + stotal[i] + "  ");
                    }
                    Console.WriteLine("");
                    ap = (gcnt == 0 && ccnt == 0);
                    ag = (ccnt == 0 && pcnt == 0);
                    ac = (pcnt == 0 && gcnt == 0);
                    all = (gcnt != 0 && ccnt != 0 && pcnt != 0);

                }



                if (pcnt == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("グーを出した人の勝ちです。");
                    Console.WriteLine("勝者は");
                    for (int i = 0; i < PlayerNum; i++)
                    {
                        if (iplayer[i] == 1)
                        {
                            PlayerWinningCount[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            PlayerLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < CpuNum; i++)
                    {
                        if (icpu[i] == 1)
                        {
                            CpuWinningCount[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            CpuLoseCount[i] += 1;
                        }
                    }
                    Console.WriteLine("以上です。");
                    Console.WriteLine("--------------------------------------");
                }
                else if (gcnt == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("チョキを出した人の勝ちです。");
                    Console.WriteLine("勝者は");
                    for (int i = 0; i < PlayerNum; i++)
                    {
                        if (iplayer[i] == 2)
                        {
                            PlayerWinningCount[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            PlayerLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < CpuNum; i++)
                    {
                        if (icpu[i] == 2)
                        {
                            CpuWinningCount[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            CpuLoseCount[i] += 1;
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
                    for (int i = 0; i < PlayerNum; i++)
                    {
                        if (iplayer[i] == 3)
                        {
                            PlayerWinningCount[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            PlayerLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < CpuNum; i++)
                    {
                        if (icpu[i] == 3)
                        {
                            CpuWinningCount[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            CpuLoseCount[i] += 1;
                        }
                    }
                    Console.WriteLine("以上です。");
                    Console.WriteLine("--------------------------------------");
                }

            }
            //結果発表 (コンソール)
            Console.WriteLine("成績を見ますか？");
            Console.WriteLine("1:見る　　2：見ない");
            int rst = int.Parse(Console.ReadLine());
            if (rst == 1)
            {
                Console.WriteLine("【結果発表】");
                for (int i = 0; i < PlayerNum; i++)
                {
                    PlayerWinningPercentage[i] = ((float)PlayerWinningCount[i] / (float)BattleNum) * 100;
                    Console.Write("P" + (i + 1) + ":" + "勝ち:" + PlayerWinningCount[i] + "回" + ",  " + "負け:" + PlayerLoseCount[i] + "回" + ",  " + "勝率:" + PlayerWinningPercentage[i].ToString("f2") + "%");
                    Console.WriteLine("");
                }
                for (int i = 0; i < CpuNum; i++)
                {
                    CpuWinningPercentage[i] = ((float)CpuWinningCount[i] / (float)BattleNum) * 100;
                    Console.Write("C" + (i + 1) + ":" + "勝ち:" + CpuWinningCount[i] + "回" + ",  " + "負け:" + CpuLoseCount[i] + "回" + ",  " + "勝率:" + CpuWinningPercentage[i].ToString("f2") + "%");
                    Console.WriteLine("");
                }
                Console.WriteLine();

            }

            Console.WriteLine("この結果をファイルに出力しますか？");
            Console.WriteLine("1:出力する　　2：出力しない");
            int output = int.Parse(Console.ReadLine());
            if (output == 1)
            {
                Console.WriteLine("結果ファイルの出力先のパスを入力して下さい");
                string path = Console.ReadLine();
                Console.WriteLine("結果ファイルの名前を拡張子も含めて入力して下さい");
                string name = Console.ReadLine();
                string pn = path + "\\" + name; //pathとファイル名を組み合わせた文字列
                Encoding enc = Encoding.GetEncoding("Shift_JIS"); //文字化け防止のため文字コードをShift-JISに指定
                var resultfile = new StreamWriter(@pn, append:false, encoding:enc); //ファイルを開く
                resultfile.WriteLine("【結果発表】");

                if (SubstringRight(name, 3) == "csv" || SubstringRight(name, 3) == "CSV") 
                {
                    resultfile.WriteLine(" " + "  ," + "勝ち" + "  ," + "負け" + "  ," + "勝率");
                    for (int i = 0; i < PlayerNum; i++)
                    {
                        PlayerWinningPercentage[i] = ((float)PlayerWinningCount[i] / (float)BattleNum) * 100;
                        resultfile.Write("P" + (i + 1)+ ",  " + PlayerWinningCount[i] + "回" + ",  " + PlayerLoseCount[i] + "回" + ",  " + PlayerWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                    for (int i = 0; i < CpuNum; i++)
                    {
                        CpuWinningPercentage[i] = ((float)CpuWinningCount[i] / (float)BattleNum) * 100;
                        resultfile.Write("C" + (i + 1) + ",  " + CpuWinningCount[i] + "回" + ",  " + CpuLoseCount[i] + "回" + ",  " + CpuWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                }
                else {
                    for (int i = 0; i < PlayerNum; i++)
                    {
                        PlayerWinningPercentage[i] = ((float)PlayerWinningCount[i] / (float)BattleNum) * 100;
                        resultfile.Write("P" + (i + 1) + ":" + "勝ち:" + PlayerWinningCount[i] + "回" + ",  " + "負け:" + PlayerLoseCount[i] + "回" + ",  " + "勝率:" + PlayerWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                    for (int i = 0; i < CpuNum; i++)
                    {
                        CpuWinningPercentage[i] = ((float)CpuWinningCount[i] / (float)BattleNum) * 100;
                        resultfile.Write("C" + (i + 1) + ":" + "勝ち:" + CpuWinningCount[i] + "回" + ",  " + "負け:" + CpuLoseCount[i] + "回" + ",  " + "勝率:" + CpuWinningPercentage[i].ToString("f2") + "%");
                        resultfile.WriteLine("");
                    }
                }
             
                resultfile.WriteLine();

                resultfile.Close();

            }




        }


        static string convert(int num) //値をグー、チョキ、パーの文字に変換するメソッド
        {
            switch (num)  //プレイヤーの入力した数値をグー、チョキ、パーの文字に割り当てる処理
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

        static string SubstringRight(string target, int length) //文字列targetの右からlength文字取り出して抜き出すメソッド
        {
            return target.Substring(target.Length - length, length);
        }

    }

}
