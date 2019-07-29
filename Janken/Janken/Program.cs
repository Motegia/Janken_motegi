using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace janken2
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
            int pNum = int.Parse(Console.ReadLine()); //プレイヤーの数を入力
            Console.WriteLine("CPUは何人参加させますか？");
            int cNum = int.Parse(Console.ReadLine()); //CPUの数を入力
            Console.WriteLine("何戦勝負にしますか？");
            int bNum = int.Parse(Console.ReadLine()); //何回勝負にするか入力

            int[] iplayer = new int[pNum]; //各プレイヤーの手を格納する配列。
            int[] icpu = new int[cNum]; //各CPUの手を格納する配列。
            string[] splayer = new string[pNum]; //N番目のプレイヤーが出した手をグー、チョキ、パーとして文字列で格納する配列
            string[] scpu = new string[cNum]; //N番目のCPUが出した手をグー、チョキ、パーとして文字列で格納する配列

            int[] pwincnt = new int[pNum]; //各プレイヤーの勝ち数を格納する配列。
            int[] cwincnt = new int[cNum]; //各CPUの勝ち数を格納する配列。
            int[] plosecnt = new int[pNum]; //各プレイヤーの負け数を格納する配列。
            int[] closecnt = new int[cNum]; //各CPUの負け数を格納する配列。
            float[] pwinper = new float[pNum]; //各プレイヤーの勝率を格納する配列。
            float[] cwinper = new float[cNum];　//各CPUの勝率を格納する配列。

            int[] itotal = new int[pNum + cNum]; 　//プレイヤーとCPUの出した手を数値で格納する配列。
            string[] stotal = new string[pNum + cNum]; //プレイヤーとCPUの出した手を文字で格納する配列。


            for (int n = 0; n < bNum; n++)
            {
                if (n > 0) //2回戦以降の変数の初期化
                {
                    for (int x = 0; x < pNum; x++) //iplayerとsplayerの初期化
                    {
                        iplayer[x] = 0;
                        splayer[x] = "";
                    }

                    for (int x = 0; x < cNum; x++) //icpuとscpuの初期化
                    {
                        icpu[x] = 0;
                        scpu[x] = "";
                    }



                }



                Console.WriteLine((n + 1) + "回戦目");
                Console.WriteLine("じゃんけんをしましょう。");
                Console.WriteLine("");
                for (int i = 0; i < pNum; i++)
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
                for (int i = 0; i < cNum; i++)
                {
                    icpu[i] = cRandom.Next(1, 4); //1以上4未満(1から3)の乱数を取得し、CPU側の手とする。
                    scpu[i] = convert(icpu[i]); //数をグー、チョキ、パーに変換
                    itotal[i + pNum] = icpu[i];
                    stotal[i + pNum] = convert(icpu[i]);
                }

                Console.WriteLine("");

                for (int i = 0; i < pNum; i++)
                {
                    Console.Write("P" + (i + 1) + ":" + stotal[i] + "  ");
                }
                for (int i = pNum; i < pNum + cNum; i++)
                {
                    Console.Write("C" + (i - pNum + 1) + ":" + stotal[i] + "  ");
                }

                Console.WriteLine("");



                //以下勝敗判定
                int gcnt = 0; //グーを出した人をカウントする変数
                int ccnt = 0; //チョキを出した人をカウントする変数
                int pcnt = 0; //パーを出した人をカウントする変数

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

                    for (int i = 0; i < pNum; i++)
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

                    for (int i = 0; i < cNum; i++)
                    {
                        icpu[i] = cRandom.Next(1, 4); //1以上4未満(1から3)の乱数を取得し、CPU側の手とする。
                        scpu[i] = convert(icpu[i]); //数をグー、チョキ、パーに変換
                        itotal[i + pNum] = icpu[i];
                        stotal[i + pNum] = convert(icpu[i]);
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

                    for (int i = 0; i < pNum; i++)
                    {
                        Console.Write("P" + (i + 1) + ":" + stotal[i] + "  ");
                    }
                    for (int i = pNum; i < pNum + cNum; i++)
                    {
                        Console.Write("C" + (i - pNum + 1) + ":" + stotal[i] + "  ");
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
                    for (int i = 0; i < pNum; i++)
                    {
                        if (iplayer[i] == 1)
                        {
                            pwincnt[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            plosecnt[i] += 1;
                        }
                    }
                    for (int i = 0; i < cNum; i++)
                    {
                        if (icpu[i] == 1)
                        {
                            cwincnt[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            closecnt[i] += 1;
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
                    for (int i = 0; i < pNum; i++)
                    {
                        if (iplayer[i] == 2)
                        {
                            pwincnt[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            plosecnt[i] += 1;
                        }
                    }
                    for (int i = 0; i < cNum; i++)
                    {
                        if (icpu[i] == 2)
                        {
                            cwincnt[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            closecnt[i] += 1;
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
                    for (int i = 0; i < pNum; i++)
                    {
                        if (iplayer[i] == 3)
                        {
                            pwincnt[i] += 1;
                            Console.WriteLine("P" + (i + 1));
                        }
                        else
                        {
                            plosecnt[i] += 1;
                        }
                    }
                    for (int i = 0; i < cNum; i++)
                    {
                        if (icpu[i] == 3)
                        {
                            cwincnt[i] += 1;
                            Console.WriteLine("C" + (i + 1));
                        }
                        else
                        {
                            closecnt[i] += 1;
                        }
                    }
                    Console.WriteLine("以上です。");
                    Console.WriteLine("--------------------------------------");
                }


            }

            //結果発表
            Console.WriteLine("成績を見ますか？");
            Console.WriteLine("1:見る　　2：見ない");
            int fin = int.Parse(Console.ReadLine());
            if (fin == 1)
            {
                Console.WriteLine("【結果発表】");
                for (int i = 0; i < pNum; i++)
                {
                    pwinper[i] = ((float)pwincnt[i] / (float)bNum) * 100;
                    Console.Write("P" + (i + 1) + ":" + "勝ち:" + pwincnt[i] + "回" + ",  " + "負け:" + plosecnt[i] + "回" + ",  " + "勝率:" + "{0:0.##}", pwinper[i] + "%");
                    Console.WriteLine("");
                }
                for (int i = 0; i < cNum; i++)
                {
                    cwinper[i] = ((float)cwincnt[i] / (float)bNum) * 100;
                    Console.Write("C" + (i + 1) + ":" + "勝ち:" + cwincnt[i] + "回" + ",  " + "負け:" + closecnt[i] + "回" + ",  " + "勝率:" + "{0:0.##}", cwinper[i] + "%");
                    Console.WriteLine("");
                }
                Console.WriteLine();

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



    }

}
