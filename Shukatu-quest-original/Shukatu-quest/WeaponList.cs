using System;


class WeaponList
{
    void WeaponState()
    {
        string WeaponName;
        int WeaPhysicAT;
        int WeaMagicAT;

        //テスト用変数
        int NowLevel = 1;
        int a = 1;
        //終わり

        switch (a)
        {
            case 1://ショートソード
                WeaponName = "ショートソード";
                WeaPhysicAT = 0;
                WeaMagicAT = 0;
                break;

            case 2://ココットソード
                WeaponName = "ココットソード";
                WeaPhysicAT = 15;
                WeaMagicAT = 5;
                break;

            case 3://ダークグレイブ
                WeaponName = "ダークグレイブ";
                WeaPhysicAT = 20;
                WeaMagicAT = 54;
                break;

            case 4://ツインDナイフ
                WeaponName = "ツイン・D・ナイフ";
                WeaPhysicAT = 22;
                WeaMagicAT = 25;
                break;

            case 5://ムーンハルベル
                WeaponName = "ムーンハルベル";
                WeaPhysicAT = 43;
                WeaMagicAT = 20;
                break;

            case 6://アポロンサイズ
                WeaponName = "アポロンサイズ";
                WeaPhysicAT = 25;
                WeaMagicAT = 45;
                break;

            case 7://チェックメイス
                WeaponName = "チェックメイス";
                WeaPhysicAT = 125;
                WeaMagicAT = 125;
                break;

            case 8://エグゼソード
                WeaponName = "エグゼソード";
                WeaPhysicAT = 100 + ((NowLevel - 1) * 25);
                WeaMagicAT = 100 + ((NowLevel - 1) * 25);
                break;

            case 9://スネイク
                WeaponName = "スネイク";
                WeaPhysicAT = 125;
                WeaMagicAT = 45;
                break;

            case 10://マイン・ゴーシュ
                WeaponName = "マイン・ゴーシュ";
                WeaPhysicAT = 125;
                WeaMagicAT = 125;
                break;

            case 11://プロテクトアックス
                WeaponName = "プロテクトアックス";
                WeaPhysicAT = 205;
                WeaMagicAT = 15;
                break;

            case 12://正宗
                WeaponName = "正宗";
                WeaPhysicAT = 245;
                WeaMagicAT = 245;
                break;

            case 13://怒りの剣
                WeaponName = "怒りの剣";
                WeaPhysicAT = 499;
                WeaMagicAT = 59;
                break;

            case 14://楽しみの剣
                WeaponName = "楽しみの剣";
                WeaPhysicAT = ((NowLevel - 1) * 50);
                WeaMagicAT = ((NowLevel - 1) * 50);
                break;

            case 15://悲しみの剣
                WeaponName = "悲しみの剣";
                WeaPhysicAT = 50;
                WeaMagicAT = 488;
                break;

            case 16://喜びの剣
                WeaponName = "喜びの剣";
                WeaPhysicAT = 500;
                WeaMagicAT = 500;
                break;

            case 17://レイン
                WeaponName = "レイン";
                WeaPhysicAT = 799;
                WeaMagicAT = 499;
                break;

            case 18://ワントソード
                WeaponName = "ワントソード";
                WeaPhysicAT = 490;
                WeaMagicAT = 799;
                break;

            case 19://ピンクメロウ
                WeaponName = "ピンクメロウ";
                WeaPhysicAT = 630;
                WeaMagicAT = 1500;
                break;

            case 20://イースター
                WeaponName = "イースター";
                WeaPhysicAT = 900;
                WeaMagicAT = 459;
                break;

            case 21://ブラインド
                WeaponName = "ブラインド";
                WeaPhysicAT = 600;
                WeaMagicAT = 900;
                break;

            case 22://ビンX2
                WeaponName = "ビンX2";
                WeaPhysicAT = 808;
                WeaMagicAT = 1208;
                break;

            case 23://ビックソード
                WeaponName = "ビックソード";
                WeaPhysicAT = 1300;
                WeaMagicAT = 300;
                break;

            case 24://エアリッパー
                WeaponName = "エアリッパー";
                WeaPhysicAT = 900;
                WeaMagicAT = 1000;
                break;

            case 25://プリズンブレイク
                WeaponName = "プリズンブレイク";
                WeaPhysicAT = 1000;
                WeaMagicAT = 1000;
                break;

            case 26://如意棒
                WeaponName = "如意棒";
                WeaPhysicAT = 305;
                WeaMagicAT = 305;
                break;

            case 27://グフ・スティック
                WeaponName = "グフ・スティック";
                WeaPhysicAT = 450;
                WeaMagicAT = 450;
                break;

            case 28://ココットソードΩ
                WeaponName = "ココットソードΩ";
                WeaPhysicAT = 700;
                WeaMagicAT = 700;
                break;

            case 29://エクスカリバー
                WeaponName = "エクスカリバー";
                WeaPhysicAT = 1200;
                WeaMagicAT = 1200;
                break;

            case 30://サラマンダー
                WeaponName = "サラマンダー";
                WeaPhysicAT = 1505;
                WeaMagicAT = 1505;
                break;

            case 31://修羅
                WeaponName = "修羅";
                WeaPhysicAT = 2055;
                WeaMagicAT = 755;
                break;

            case 32://テンペスト
                WeaponName = "テンペスト";
                WeaPhysicAT = 1000;
                WeaMagicAT = 2500;
                break;

            case 33://ブラッドファントム
                WeaponName = "ブラッドファントム";
                WeaPhysicAT = 2505;
                WeaMagicAT = 1055;
                break;

            case 34://アイスエイジ
                WeaponName = "アイスエイジ";
                WeaPhysicAT = 1455;
                WeaMagicAT = 4005;
                break;

            case 35://ナイトメア
                WeaponName = "ナイトメア";
                WeaPhysicAT = 3555;
                WeaMagicAT = 3555;
                break;

            case 36://ダイヤモンドダスト
                WeaponName = "ダイヤモンドダスト";
                WeaPhysicAT = 4055;
                WeaMagicAT = 4055;
                break;

            case 37://タルタロス
                WeaponName = "タルタロス";
                WeaPhysicAT = 4550;
                WeaMagicAT = 3250;
                break;

            case 38://イフリート
                WeaponName = "イフリート";
                WeaPhysicAT = 5000;
                WeaMagicAT = 5000;
                break;

            case 39://トライデント
                WeaponName = "トライデント";
                WeaPhysicAT = 6000;
                WeaMagicAT = 6000;
                break;

            case 40://ゴーゴン
                WeaponName = "ゴーゴン";
                WeaPhysicAT = 9000;
                WeaMagicAT = 9000;
                break;

            case 41://デストロイヤー
                WeaponName = "デストロイヤー";
                WeaPhysicAT = 10000;
                WeaMagicAT = 10000;
                break;

            case 42://エグゼット
                WeaponName = "エグゼット";
                WeaPhysicAT = 50000;
                WeaMagicAT = 50000;
                break;
        }
    }
}