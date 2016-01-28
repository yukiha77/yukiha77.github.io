using System;

class MonsterState
{
    void MobState()
    {
        int MobHP;
        int MobPhysicAT;
        int MobPhysicDF;
        int MobMagicAT;
        int MobMagicDF;
        int MobEXP;
        string MobName;

        //テスト用変数
        int NowLevel = 1;
        int a = 1;
        //ここまで

        switch (a)
        {
            case 1://ナタデ・ココ
                MobName = "ナタデ・ココ";
                MobHP = 30 + ((NowLevel - 1) * 15);
                MobPhysicAT = 10 + ((NowLevel - 1) * 2);
                MobPhysicDF = 4;
                MobMagicAT = 10;
                MobMagicDF = 5;
                MobEXP = 14;
                break;

            case 2://ダークサモナー
                MobName = "ダークサモナー";
                MobHP = 33 + ((NowLevel - 1) * 10);
                MobPhysicAT = 10;
                MobPhysicDF = 60 + ((NowLevel - 1) * 2);
                MobMagicAT = 20 + ((NowLevel - 1) * 3);
                MobMagicDF = -33;
                MobEXP = 14;
                break;

            case 3://スカルパイレーツ
                MobName = "スカルパイレーツ";
                MobHP = 40 + ((NowLevel - 1) * 20);
                MobPhysicAT = 26 + ((NowLevel - 1) * 2);
                MobPhysicDF = 4;
                MobMagicAT = 10;
                MobMagicDF = 32 + ((NowLevel - 1) * 2);
                MobEXP = 24;
                break;

            case 4://ポジティブムーン
                MobName = "ポジティブムーン";
                MobHP = 40 + ((NowLevel - 1) * 20);
                MobPhysicAT = 15;
                MobPhysicDF = 20 + ((NowLevel - 1) * 2);
                MobMagicAT = 22 + ((NowLevel - 1) * 3);
                MobMagicDF = -20;
                MobEXP = 30;
                break;

            case 5://ネガティブサン
                MobName = "ネガティブサン";
                MobHP = 90 + ((NowLevel - 1) * 20);
                MobPhysicAT = 23 + ((NowLevel - 1) * 2);
                MobPhysicDF = 7;
                MobMagicAT = 10;
                MobMagicDF = 45 + ((NowLevel - 1) * 3);
                MobEXP = 34;
                break;

            case 6://チックワン
                MobName = "チックワン";
                MobHP = 220 + ((NowLevel - 1) * 20);
                MobPhysicAT = 80 + ((NowLevel - 1) * 3);
                MobPhysicDF = 4;
                MobMagicAT = 10;
                MobMagicDF = 5;
                MobEXP = 90;
                break;

            case 7://神様
                //イベントを描く
                break;

            case 8://バジリスク
                MobName = "バジリスク";
                MobHP = 230 + ((NowLevel - 1) * 50);
                MobPhysicAT = 50 + ((NowLevel - 1) * 2);
                MobPhysicDF = 9;
                MobMagicAT = 10;
                MobMagicDF = 5;
                MobEXP = 110;
                break;

            case 9://ワームドック
                MobName = "ワームドック";
                MobHP = 240 + ((NowLevel - 1) * 50);
                MobPhysicAT = 40 + ((NowLevel - 1) * 2);
                MobPhysicDF = 4 + ((NowLevel - 1) * 2);
                MobMagicAT = 40;
                MobMagicDF = 45;
                MobEXP = 100;
                break;

            case 10://プロテクター
                MobName = "プロテクター";
                MobHP = 200 + ((NowLevel - 1) * 100);
                MobPhysicAT = 30 + ((NowLevel - 1) * 2);
                MobPhysicDF = 200 + ((NowLevel - 1) * 5);
                MobMagicAT = 70;
                MobMagicDF = -300;
                MobEXP = 140;
                break;

            case 11://ディバーデット
                MobName = "ディバーデット";
                MobHP = 220 + ((NowLevel - 1) * 50);
                MobPhysicAT = 40 + ((NowLevel - 1) * 2);
                MobPhysicDF = 30;
                MobMagicAT = 50;
                MobMagicDF = 85;
                MobEXP = 200;
                break;

            case 12://グリペル
                MobName = "グリペル";
                MobHP = 20 + ((NowLevel - 1) * 300);
                MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                MobPhysicDF = -5000;
                MobMagicAT = 130;
                MobMagicDF = 3000;
                MobEXP = 300;
                break;

            case 13://ジョイ
                MobName = "ジョイ";
                MobHP = 20 + ((NowLevel - 1) * 300);
                MobPhysicAT = 120;
                MobPhysicDF = -5000;
                MobMagicAT = 130 + ((NowLevel - 1) * 2);
                MobMagicDF = 3000;
                MobEXP = 240;
                break;

            case 14://ウィーブ
                MobName = "ウィーブ";
                MobHP = 20 + ((NowLevel - 1) * 300);
                MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                MobPhysicDF = 3000;
                MobMagicAT = 130;
                MobMagicDF = -5000;
                MobEXP = 200;
                break;

            case 15://ファン
                MobName = "ファン";
                MobHP = 20 + ((NowLevel - 1) * 300);
                MobPhysicAT = 120;
                MobPhysicDF = 3000;
                MobMagicAT = 120 + ((NowLevel - 1) * 2);
                MobMagicDF = -5000;
                MobEXP = 200;
                break;

            case 16://パドル
                MobName = "パドル";
                MobHP = 520 + ((NowLevel - 1) * 50);
                MobPhysicAT = 50 + ((NowLevel - 1) * 2);
                MobPhysicDF = 3000;
                MobMagicAT = 70 + ((NowLevel - 1) * 3);
                MobMagicDF = 0;
                MobEXP = 300;
                break;

            case 17://ワント
                MobName = "ワント";
                MobHP = 520 + ((NowLevel - 1) * 50);
                MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                MobPhysicDF = 30;
                MobMagicAT = 30;
                MobMagicDF = 69;
                MobEXP = 300;
                break;

            case 18://エンスレイヴン
                MobName = "エンスレイヴン";
                MobHP = 720 + ((NowLevel - 1) * 50);
                MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                MobPhysicDF = 50 + ((NowLevel - 1) * 2);
                MobMagicAT = 90 + ((NowLevel - 1) * 2);
                MobMagicDF = 50;
                MobEXP = 300;
                break;

            case 19://アテンダント
                MobName = "アテンダント";
                MobHP = 1020 + ((NowLevel - 1) * 50);
                MobPhysicAT = 80 + ((NowLevel - 1) * 2);
                MobPhysicDF = 200 + ((NowLevel - 1) * 2);
                MobMagicAT = 80;
                MobMagicDF = 30;
                MobEXP = 320;
                break;

            case 20://ブラインカーズ
                MobName = "ブラインカーズ";
                MobHP = 920 + ((NowLevel - 1) * 50);
                MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                MobPhysicDF = 20;
                MobMagicAT = 100;
                MobMagicDF = 20 + ((NowLevel - 1) * 2);
                MobEXP = 400;
                break;

            case 21://クラウン
                MobName = "クラウン";
                MobHP = 1220 + ((NowLevel - 1) * 50);
                MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                MobPhysicDF = 3000;
                MobMagicAT = 70;
                MobMagicDF = 20;
                MobEXP = 600;
                break;

            case 22://ピット
                MobName = "ピット";
                MobHP = 920 + ((NowLevel - 1) * 50);
                MobPhysicAT = 50 + ((NowLevel - 1) * 3);
                MobPhysicDF = 100;
                MobMagicAT = 130;
                MobMagicDF = 100 + ((NowLevel - 1) * 2);
                MobEXP = 400;
                break;

            case 23://エリアル
                MobName = "エリアル";
                MobHP = 1520 + ((NowLevel - 1) * 50);
                MobPhysicAT = 20 + ((NowLevel - 1) * 3);
                MobPhysicDF = 150 + ((NowLevel - 1) * 3);
                MobMagicAT = 130;
                MobMagicDF = 20;
                MobEXP = 600;
                break;

            case 24://プリゾナ
                MobName = "プリゾナ";
                MobHP = 1220 + ((NowLevel - 1) * 50);
                MobPhysicAT = 20 + ((NowLevel - 1) * 3);
                MobPhysicDF = -400;
                MobMagicAT = 130 + ((NowLevel - 1) * 2);
                MobMagicDF = -400;
                MobEXP = 600;
                break;

            case 25://Mtヴェント
                MobName = "Mtヴェント";
                MobHP = 1000;
                MobPhysicAT = 30;
                MobPhysicDF = -50;
                MobMagicAT = 30;
                MobMagicDF = 75;
                MobEXP = 500;
                break;

            case 26://Mhブラザーズ
                MobName = "Mhブラザーズ";
                MobHP = 2000;
                MobPhysicAT = 70;
                MobPhysicDF = 3000;
                MobMagicAT = 70;
                MobMagicDF = -300;
                MobEXP = 700;
                break;

            case 27://キング・ココ
                MobName = "キング・ココ";
                MobHP = 10000;
                MobPhysicAT = 70;
                MobPhysicDF = 0;
                MobMagicAT = 19;
                MobMagicDF = 0;
                MobEXP = 1000;
                break;

            case 28://アルカトル
                MobName = "アルカトル";
                MobHP = 10000;
                MobPhysicAT = 130;
                MobPhysicDF = 30;
                MobMagicAT = 110;
                MobMagicDF = 90;
                MobEXP = 1235;
                break;

            case 29://サラマンダ
                MobName = "サラマンダ";
                MobHP = 15000;
                MobPhysicAT = 150;
                MobPhysicDF = 100;
                MobMagicAT = 150;
                MobMagicDF = 100;
                MobEXP = 1435;
                break;

            case 30://シュラ
                MobName = "シュラ";
                MobHP = 20000;
                MobPhysicAT = 200;
                MobPhysicDF = 70;
                MobMagicAT = 125;
                MobMagicDF = 55;
                MobEXP = 2035;
                break;

            case 31://テンペスト
                MobName = "テンペスト";
                MobHP = 25000;
                MobPhysicAT = 100;
                MobPhysicDF = 100;
                MobMagicAT = 200;
                MobMagicDF = 4000;
                MobEXP = 3035;
                break;

            case 32://ヴァンパイア
                MobName = "ヴァンパイア";
                MobHP = 30000;
                MobPhysicAT = 250;
                MobPhysicDF = 100;
                MobMagicAT = 150;
                MobMagicDF = 100;
                MobEXP = 4035;
                break;

            case 33://アブソリュート
                MobName = "アブソリュート";
                MobHP = 35000;
                MobPhysicAT = 200;
                MobPhysicDF = 100;
                MobMagicAT = 250;
                MobMagicDF = 100;
                MobEXP = 8000;
                break;

            case 34://モーティシャン
                MobName = "モーティシャン";
                MobHP = 50000;
                MobPhysicAT = 300;
                MobPhysicDF = 200;
                MobMagicAT = 100;
                MobMagicDF = -2000;
                MobEXP = 10000;
                break;

            case 35://シヴァ
                MobName = "シヴァ";
                MobHP = 70000;
                MobPhysicAT = 250;
                MobPhysicDF = 200;
                MobMagicAT = 270;
                MobMagicDF = 200;
                MobEXP = 13000;
                break;

            case 36://ケロベロス
                MobName = "ケロベロス";
                MobHP = 100000;
                MobPhysicAT = 300;
                MobPhysicDF = 1000;
                MobMagicAT = 130;
                MobMagicDF = -2000;
                MobEXP = 15000;
                break;

            case 37://イフリート
                MobName = "イフリート";
                MobHP = 150000;
                MobPhysicAT = 300;
                MobPhysicDF = 100;
                MobMagicAT = 200;
                MobMagicDF = 250;
                MobEXP = 20000;
                break;

            case 38://ラムゥ
                MobName = "ラムゥ";
                MobHP = 200000;
                MobPhysicAT = 200;
                MobPhysicDF = 1200;
                MobMagicAT = 350;
                MobMagicDF = 200;
                MobEXP = 30000;
                break;

            case 39://メデューサ
                MobName = "メデューサ";
                MobHP = 220000;
                MobPhysicAT = 300;
                MobPhysicDF = 105;
                MobMagicAT = 400;
                MobMagicDF = 1505;
                MobEXP = 30000;
                break;

            case 40://デストロイヤー
                MobName = "デストロイヤー";
                MobHP = 300000;
                MobPhysicAT = 500;
                MobPhysicDF = 500;
                MobMagicAT = 0;
                MobMagicDF = 3000;
                MobEXP = 50000;
                break;

            case 41://魔人
                MobName = "魔人";
                MobHP = 1500000;
                MobPhysicAT = 1200;
                MobPhysicDF = 10000000;
                MobMagicAT = 1200;
                MobMagicDF = 10000000;
                MobEXP = 100000;
                break;
        }
    }
}