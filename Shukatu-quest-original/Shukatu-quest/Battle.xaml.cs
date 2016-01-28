using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Storage;


namespace Shukatu_quest
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class Battle : Page
    {
        //プレイヤーステータス初期化(レベル1に設定)
        int NowLevel = 1;
        int PlayerPhysicAT = 24;
        int PlayerPhysicDF = 8;
        int PlayerMasicAT = 12;
        int PlayerMasicDF = 6;
        int MaxHP = 70;
        int MaxMP = 60;
        int EXP = 0;
        //敵ステータス初期化
        int MobPhysicDF = 0;
        int MobPhysicDFNow = 0;
        int MobMagicDF = 0;
        int MobMagicDFNow = 0;
        int MobPhysicAT = 0;
        int MobMagicAT = 0;
        int MobHP = 100;
        int MobEXP = 0;
        string MobName;
        int MobID = 0;
        //戦闘用変数の初期化
        int PlayerDamage = 0;
        int EnemyDamage = 0;
        int ItemAT =0;
        int ItemMT = 0;
        string ItemName="無し";
        int MobCommand = 0;
        //戦闘中のステータスを管理(レベル1に設定)
        int NowHP = 70;
        int NowMP = 60;
        int NowPhysicDF = 14;
        //FloorCutInで使う変数
        int NowFloor = 1;
        //武器のステータス
        bool WeaDrop = false;
        string WeaponName;
        int WeaPhysicAT=0;
        int WeaMagicAT=0;
        //戦闘中コマンド呼び出し
        int x = 0;
        int y = 0;
        //チックワン、デストロイヤーの特殊コマンド用変数
        int attackcount=0;


        //初期呼び出し
        public Battle()
        {
            this.InitializeComponent();
            GameStart();
            Battle1.Visibility = Visibility.Collapsed;
            TextSend.IsEnabled = false;
            Attack.IsEnabled = false;
            Magic.IsEnabled = false;
            Hidden.IsEnabled = false;
            Defense.IsEnabled = false;
            Yes.IsEnabled = false;
            No.IsEnabled = false;

            //NextStage.IsEnabled = false;

        }

        private async void GameStart()
        {
            await Task.Delay(2000);
            arasuji.Visibility = Visibility.Collapsed;
            //FloorCutIn();
            //FloorCutInGrid.Visibility = Visibility;            
        }

        //戦闘開始の表示
        private async void BattleStart() {
            Battle1.Visibility = Visibility.Visible;
            Yes.Visibility = Visibility.Collapsed;
            Yes.IsEnabled = false;
            No.Visibility = Visibility.Collapsed;
            No.IsEnabled = false;
            TextSend.IsEnabled = false;
            Attack.IsEnabled = true;
            Magic.IsEnabled = true;
            Hidden.IsEnabled = true;
            Defense.IsEnabled = true;
            //ボタンの非表示
            text.Visibility = Visibility;
            Attack.Visibility = Visibility.Collapsed;
            Magic.Visibility = Visibility.Collapsed;
            Hidden.Visibility = Visibility.Collapsed;
            Defense.Visibility = Visibility.Collapsed;

            await Task.Delay(2000);
            Attack.Visibility = Visibility;
            Magic.Visibility = Visibility;
            Hidden.Visibility = Visibility;
            Defense.Visibility = Visibility;
            text.Visibility = Visibility.Collapsed;
            text2.Text =  " Lv:" + NowLevel +"HP:" + NowHP + " MP:" + NowMP + "\n   装備:" + ItemName;
        }

        //戦闘終了の表示
        private void BattleEnd() {
            TextSend.IsEnabled = false;
            Attack.IsEnabled = false;
            Magic.IsEnabled = false;
            Hidden.IsEnabled = false;
            Defense.IsEnabled = false;
            Battle1.Visibility = Visibility.Collapsed;
            FloorCutIn();
        }

        //階層処理
        private async void FloorCutIn() {
            Floortext.Text = NowFloor.ToString();
            FloorCutInGrid.Visibility = Visibility.Visible;
            NextStage.IsEnabled = true;
            if (NowFloor >= 1 && NowFloor <= 20)//1ボスまで
            {
                mt_vento_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 21 && NowFloor <= 50)//2ボスまで
            {
                mt_vento_shadow_png.Visibility = Visibility.Collapsed;
                mh_brothers_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 51 && NowFloor <= 70)//3ボスまで
            {
                mh_brothers_shadow_png.Visibility = Visibility.Collapsed;
                king_coco_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 71 && NowFloor <= 100)//4ボスまで
            {
                king_coco_shadow_png.Visibility = Visibility.Collapsed;
                alcatol_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 101 && NowFloor <= 150)//5ボスまで
            {
                alcatol_shadow_png.Visibility = Visibility.Collapsed;
                salamander_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 151 && NowFloor <= 200)//6ボスまで
            {
                salamander_shadow_png.Visibility = Visibility.Collapsed;
                shura_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 201 && NowFloor <= 230)//7ボス
            {
                shura_shadow_png.Visibility = Visibility.Collapsed;
                tempest_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 231 && NowFloor <= 260)//8ボス
            {
                tempest_shadow_png.Visibility = Visibility.Collapsed;
                vampire_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 261 && NowFloor <= 280)//9ボス
            {
                vampire_shadow_png.Visibility = Visibility.Collapsed;
                absolute_zero_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 281 && NowFloor <= 300)//10ボス
            {
                absolute_zero_shadow_png.Visibility = Visibility.Collapsed;
                motishan_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 301 && NowFloor <= 330)//11ボス
            {
                motishan_shadow_png.Visibility = Visibility.Collapsed;
                shiva_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 331 && NowFloor <= 350)//12ボス
            {
                shiva_shadow_png.Visibility = Visibility.Collapsed;
                ceroberus_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 351 && NowFloor <= 370)//13ボス
            {
                ceroberus_shadow_png.Visibility = Visibility.Collapsed;
                ifrit_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 371 && NowFloor <= 400)//14ボス
            {
                ifrit_shadow_png.Visibility = Visibility.Collapsed;
                ramuu_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 401 && NowFloor <= 450)//15ボス
            {
                ramuu_shadow_png.Visibility = Visibility.Collapsed;
                medusa_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 451 && NowFloor <= 500)//16ボス
            {
                medusa_shadow_png.Visibility = Visibility.Collapsed;
                destroyer_shadow_png.Visibility = Visibility;
            }
            else if (NowFloor >= 501 && NowFloor <= 2000)//17ボス
            {
                destroyer_shadow_png.Visibility = Visibility.Collapsed;
                demon_shadow_png.Visibility = Visibility;
            }
            await Task.Delay(2000);
            FloorCutInGrid.Visibility = Visibility.Collapsed;
            BattleStart();
            EnemyEncount();
        }

        //名前入力
        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
            textBox.MaxLength = 4;//4文字まで
        }
        //名前保存
        private async void Dec_Click(object sender, RoutedEventArgs e) { }

        //戦闘自ターン
        private async void MyTurn()
        {
            if (x == 0 && y == 0)
            {
                //物理攻撃
                PlayerDamage = PlayerPhysicAT + ItemAT - MobPhysicDFNow;

                if (PlayerDamage <= 0)
                {
                    PlayerDamage = 0;
                    text.Text = MobName + "は平気な顔をしている。";
                }
                else
                {
                    text.Text = textBox.Text + "の攻撃！\n" + PlayerDamage + "のダメージ！";
                }
                MobHP -= PlayerDamage;
                if (MobHP <= 0)
                {
                    MobHP = 0;
                }

                //ボタンの有効、無効の切り替え
                Attack.IsEnabled = false;
                Magic.IsEnabled = false;
                Hidden.IsEnabled = false;
                Defense.IsEnabled = false;
                TextSend.IsEnabled = true;
                //ボタンの非表示
                Attack.Visibility = Visibility.Collapsed;
                Magic.Visibility = Visibility.Collapsed;
                Hidden.Visibility = Visibility.Collapsed;
                Defense.Visibility = Visibility.Collapsed;
                text.Visibility = Visibility;
                await Task.Delay(2000);
                EnemyTurn();
                return;
            }
            if (x == 1 && y == 0)
            {
                //魔法攻撃
                if (NowMP >= 10)
                {
                    if (MobID != 40)
                    {
                        NowMP -= 10;
                        PlayerDamage = PlayerMasicAT + ItemMT - MobMagicDFNow;

                        if (PlayerDamage <= 0)
                        {
                            PlayerDamage = 0;
                            text.Text = MobName + "は平気な顔をしている。";
                        }
                        else
                        {
                            text.Text = textBox.Text + "の魔法攻撃！\n" + PlayerDamage + "のダメージ！";
                        }
                        MobHP -= PlayerDamage;
                        if (MobHP <= 0)
                        {
                            MobHP = 0;
                        }
                    }
                    else
                    {
                        if (attackcount == 0)
                        {
                            PlayerDamage = 0;
                            text.Text = "魔法の鎖で封印した！";
                            attackcount = 4;
                        }
                        else
                        {
                            PlayerDamage = 0;
                            text.Text = "効果がない！";
                        }
                    }
                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    TextSend.IsEnabled = true;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility;
                    await Task.Delay(2000);
                    EnemyTurn();
                }               
                else
                {
                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    TextSend.IsEnabled = false;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility;
                    //テキストを表示
                    text.Text = "Mpが足りない！";
                    await Task.Delay(2000);
                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = true;
                    Magic.IsEnabled = true;
                    Hidden.IsEnabled = true;
                    Defense.IsEnabled = true;
                    TextSend.IsEnabled = false;
                    //ボタンの表示
                    Attack.Visibility = Visibility;
                    Magic.Visibility = Visibility;
                    Hidden.Visibility = Visibility;
                    Defense.Visibility = Visibility;
                    text.Visibility = Visibility;
                }

                return;
            }
            if (x == 0 && y == 1)
            {
                //奥義
                if (NowMP >= 20)
                {
                    DateTime dt = System.DateTime.Now;
                    int Day = dt.Day;
                    NowMP -= 20;
                    PlayerDamage = (Day + PlayerPhysicAT * 2 + ItemAT * 2) - MobPhysicDFNow;

                    if (PlayerDamage <= 0)
                    {
                        PlayerDamage = 0;
                        text.Text = MobName + "は平気な顔をしている。";
                    }
                    else
                    {
                        text.Text = "奥義を放った！\n" + PlayerDamage + "のダメージ！";
                    }
                    MobHP -= PlayerDamage;
                    if (MobHP <= 0)
                    {
                        MobHP = 0;
                    }

                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    TextSend.IsEnabled = true;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility;
                    await Task.Delay(2000);
                    EnemyTurn();
                }
                else
                {
                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    TextSend.IsEnabled = false;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility;
                    //テキストを表示
                    text.Text = "Mpが足りない！";
                    await Task.Delay(2000);
                    //ボタンの有効、無効の切り替え
                    Attack.IsEnabled = true;
                    Magic.IsEnabled = true;
                    Hidden.IsEnabled = true;
                    Defense.IsEnabled = true;
                    TextSend.IsEnabled = false;
                    //ボタンの表示
                    Attack.Visibility = Visibility.Visible;
                    Magic.Visibility = Visibility.Visible;
                    Hidden.Visibility = Visibility.Visible;
                    Defense.Visibility = Visibility.Visible;
                    text.Visibility = Visibility;

                }
                return;
            }
            if (x == 1 && x == 1)
            {
                //防御
                NowPhysicDF = PlayerPhysicDF * 2;
                NowHP += NowLevel * 5;
                NowMP += 5;
                text.Text = textBox.Text + "は防御に徹した。\nHPが" + NowLevel * 5
                            + "回復した！MPが" + 5 + "回復した！";
                if (NowHP >= MaxHP)
                {
                    NowHP = MaxHP;
                }
                if (NowMP >= MaxMP)
                {
                    NowMP = MaxMP;
                }

                //ボタンの有効、無効の切り替え
                Attack.IsEnabled = false;
                Magic.IsEnabled = false;
                Hidden.IsEnabled = false;
                Defense.IsEnabled = false;
                await Task.Delay(800);
                TextSend.IsEnabled = true;
                //ボタンの非表示
                Attack.Visibility = Visibility.Collapsed;
                Magic.Visibility = Visibility.Collapsed;
                Hidden.Visibility = Visibility.Collapsed;
                Defense.Visibility = Visibility.Collapsed;
                text.Visibility = Visibility;
                await Task.Delay(2000);
                EnemyTurn();
                return;
            }
            await Task.Delay(2000);
        }

        private async void EnemyTurn()
        {
            //敵コマンド
            TextSend.IsEnabled = false;
            //勝利画面へ
            if (MobHP == 0)
            {

                Attack.Visibility = Visibility.Collapsed;
                Magic.Visibility = Visibility.Collapsed;
                Hidden.Visibility = Visibility.Collapsed;
                Defense.Visibility = Visibility.Collapsed;
                TextSend.IsEnabled = false;
                Defense.IsEnabled = false;
                Attack.IsEnabled = false;
                Magic.IsEnabled = false;
                Hidden.IsEnabled = false;
                GameSet();
            }

            else
            {
                Random rand = new Random();
                MobCommand = rand.Next(4);
                switch (MobID)
                {
                    case 6: //チックワンのコマンド                        
                        if (attackcount == 0)
                        {
                            EnemyDamage = MobPhysicAT - NowPhysicDF;
                            if (EnemyDamage <= 0)
                            {
                                EnemyDamage = 0;
                                text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
                            }
                            else
                            {
                                text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
                            }
                            attackcount = 3;
                        }
                        else
                        {
                            text.Text = MobName + "は力を溜めている。";
                            EnemyDamage = 0;
                            attackcount -= 1;
                        }
                        NowHP -= EnemyDamage;
                        if (NowHP <= 0)
                        {
                            NowHP = 0;
                            EnemyDamage = 0;
                        }
                        break;
                    case 40: //デストロイヤーのコマンド
                        if (attackcount == 0)
                        {
                            EnemyDamage = MobPhysicAT - NowPhysicDF;
                            if (EnemyDamage <= 0)
                            {
                                EnemyDamage = 0;
                                text.Text = MobName + "は暴れている！\n" + "痛くもかゆくもない。";
                            }
                            else
                            {
                                text.Text = MobName + "は暴れている！\n" + EnemyDamage + "のダメージを受けた。";
                            }
                        }
                        else
                        {
                            text.Text = MobName + "は魔法の鎖を切ろうとしている！";
                            EnemyDamage = 0;
                            attackcount -= 1;

                            if (attackcount == 0)
                            {
                                await Task.Delay(2000);
                                text.Text = "魔法の鎖が切れてしまった！";
                            }
                        }
                        NowHP -= EnemyDamage;
                        if (NowHP <= 0)
                        {
                            NowHP = 0;
                            EnemyDamage = 0;
                        }
                        break;
                    case 41: //魔人のコマンド
                        switch (MobCommand)
                        {
                            case 0:
                                EnemyDamage = MobPhysicAT - NowPhysicDF;
                                if (EnemyDamage <= 0)
                                {
                                    EnemyDamage = 0;
                                    text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
                                }
                                else
                                {
                                    text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
                                }
                                MobMagicDFNow = 0;
                                break;
                            case 1:
                                EnemyDamage = MobMagicAT - PlayerMasicDF;
                                if (EnemyDamage <= 0)
                                {
                                    EnemyDamage = 0;
                                    text.Text = MobName + "の天罰！\n" + "痛くもかゆくもない。";
                                }
                                else
                                {
                                    text.Text = MobName + "の天罰！\n" + EnemyDamage + "のダメージを受けた。";
                                }
                                MobPhysicDFNow = 0;
                                break;
                            case 2:
                                MobPhysicDFNow = MobPhysicDF * 2;
                                text.Text = MobName + "は防御に徹している。" + MobName + "の防御力が上昇した。";
                                EnemyDamage = 0;
                                break;
                            case 3:
                                text.Text = MobName + "は呪文を唱えている。";
                                MobPhysicDFNow = MobPhysicDF;
                                MobMagicDFNow = MobMagicDF;
                                EnemyDamage = 0;
                                break;
                        }
                        NowHP -= EnemyDamage;
                        if (NowHP <= 0)
                        {
                            NowHP = 0;
                            EnemyDamage = 0;
                        }
                        break;
                    default:
                        switch (MobCommand)
                        {
                            case 0:
                                EnemyDamage = MobPhysicAT - NowPhysicDF;
                                if (EnemyDamage <= 0)
                                {
                                    EnemyDamage = 0;
                                    text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
                                }
                                else
                                {
                                    text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
                                }
                                break;
                            case 1:
                                EnemyDamage = MobMagicAT - PlayerMasicDF;
                                if (EnemyDamage <= 0)
                                {
                                    EnemyDamage = 0;
                                    text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
                                }
                                else
                                {
                                    text.Text = MobName + "の魔法攻撃！\n" + EnemyDamage + "のダメージを受けた。";
                                }
                                break;
                            case 2:
                                MobPhysicDFNow = MobPhysicDF * 2;
                                text.Text = MobName + "は防御に徹している。" + MobName + "の防御力が上昇した。";
                                EnemyDamage = 0;
                                break;
                            case 3:
                                text.Text = MobName + "は様子を伺っている。";
                                EnemyDamage = 0;
                                break;
                        }

                        NowHP -= EnemyDamage;
                        if (NowHP <= 0)
                        {
                            NowHP = 0;
                            EnemyDamage = 0;
                        }
                        break;
                }

            }
            text2.Text = " Lv:" + NowLevel + "HP:" + NowHP + " MP:" + NowMP + "\n   装備:" + ItemName;

            if (MobID <= 40)
            {
                MobPhysicDFNow = MobPhysicDF;
            }



            await Task.Delay(2000);
            //敗北画面へ
            if (NowHP == 0)
            {
                TextSend.IsEnabled = false;
                Attack.IsEnabled = false;
                Magic.IsEnabled = false;
                Hidden.IsEnabled = false;
                Defense.IsEnabled = false;
                Attack.Visibility = Visibility.Collapsed;
                Magic.Visibility = Visibility.Collapsed;
                Hidden.Visibility = Visibility.Collapsed;
                Defense.Visibility = Visibility.Collapsed;
                GameSet();
            }
            else if (NowHP != 0)
            {
                Attack.IsEnabled = true;
                Magic.IsEnabled = true;
                Hidden.IsEnabled = true;
                Defense.IsEnabled = true;
                TextSend.IsEnabled = false;
                Attack.Visibility = Visibility;
                Magic.Visibility = Visibility;
                Hidden.Visibility = Visibility;
                Defense.Visibility = Visibility;
                text.Visibility = Visibility.Collapsed;
            }
            await Task.Delay(2000);
            return;
        }

        private void button2_Click() { }

        private async void EnemyEncount()//エネミーの選抜
        {
            Assets_natade_coco_png.Visibility = Visibility.Collapsed;

            Assets_dark_summoner_png.Visibility = Visibility.Collapsed;

            Assets_sukll_pirate_png.Visibility = Visibility.Collapsed;

            Assets_nagative_moon_png.Visibility = Visibility.Collapsed;

            Assets_negative_sun_png.Visibility = Visibility.Collapsed;

            Assets_chikkuwan_png.Visibility = Visibility.Collapsed;

            Assets_god_png.Visibility = Visibility.Collapsed;

            Assets_basilisk_png.Visibility = Visibility.Collapsed;
          
            Assets_worm_dog_png.Visibility = Visibility.Collapsed;

            Assets_protector_png.Visibility = Visibility.Collapsed;

            Assets_dibadetto_png.Visibility = Visibility.Collapsed;

            Assets_guriperu_png.Visibility = Visibility.Collapsed;

            Assets_joy_png.Visibility = Visibility.Collapsed;

            Assets_weave_png.Visibility = Visibility.Collapsed;

            Assets_fun_png.Visibility = Visibility.Collapsed;

            Assets_paddle_png.Visibility = Visibility.Collapsed;

            Assets_wanto_png.Visibility = Visibility.Collapsed;

            Assets_enns_raven_png.Visibility = Visibility.Collapsed;

            Assets_attendant_png.Visibility = Visibility.Collapsed;

            Assets_bryn_cars_png.Visibility = Visibility.Collapsed;

            Assets_crown_png.Visibility = Visibility.Collapsed;

            Assets_pit_png.Visibility = Visibility.Collapsed;

            Assets_erial_png.Visibility = Visibility.Collapsed;

            Assets_purizona_png.Visibility = Visibility.Collapsed;

            Assets_mt_vento_png.Visibility = Visibility.Collapsed;

            Assets_mh_brothers_png.Visibility = Visibility.Collapsed;

            Assets_king_coco_png.Visibility = Visibility.Collapsed;

            Assets_alcatol_png.Visibility = Visibility.Collapsed;

            Assets_salamander_png.Visibility = Visibility.Collapsed;

            Assets_shura_png.Visibility = Visibility.Collapsed;

            Assets_tempest_png.Visibility = Visibility.Collapsed;

            Assets_vampire_png.Visibility = Visibility.Collapsed;

            Assets_absolute_zero_png.Visibility = Visibility.Collapsed;

            Assets_motishan_png.Visibility = Visibility.Collapsed;

            Assets_shiva_png.Visibility = Visibility.Collapsed;

            Assets_ceroberus_png.Visibility = Visibility.Collapsed;

            Assets_ifrit_png.Visibility = Visibility.Collapsed;

            Assets_ramuu_png.Visibility = Visibility.Collapsed;

            Assets_medusa_png.Visibility = Visibility.Collapsed;

            Assets_destroyer_png.Visibility = Visibility.Collapsed;

            Assets_demon_png.Visibility = Visibility.Collapsed;

            Yes.IsEnabled = false;
            Yes.Visibility = Visibility.Collapsed;
            No.IsEnabled = false;
            No.Visibility = Visibility.Collapsed;
            Random rand = new Random();
            int EnemyEncount = 1;
            //敵の出現テーブル
            if (NowFloor >= 1 && NowFloor <= 19)
            {
                EnemyEncount = rand.Next(7) + 1;
            }
            else if (NowFloor == 20)//1ボス
            {
                EnemyEncount = 25;
            }
            else if (NowFloor >= 21 && NowFloor <= 49)
            {
                EnemyEncount = rand.Next(11) + 1;
            }
            else if (NowFloor == 50)//2ボス
            {
                EnemyEncount = 26;
            }
            else if (NowFloor >= 51 && NowFloor <= 69)
            {
                EnemyEncount = rand.Next(15) + 1;
            }
            else if (NowFloor == 70)//3ボス
            {
                EnemyEncount = 27;
            }
            else if (NowFloor >= 71 && NowFloor <= 99)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor >= 71 && NowFloor <= 99)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 100)//4ボス
            {
                EnemyEncount = 28;
            }
            else if (NowFloor >= 101 && NowFloor <= 149)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 150)//5ボス
            {
                EnemyEncount = 29;
            }
            else if (NowFloor >= 151 && NowFloor <= 199)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 200)//6ボス
            {
                EnemyEncount = 30;
            }
            else if (NowFloor >= 201 && NowFloor <= 229)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 230)//7ボス
            {
                EnemyEncount = 31;
            }
            else if (NowFloor >= 231 && NowFloor <= 259)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 260)//8ボス
            {
                EnemyEncount = 32;
            }
            else if (NowFloor >= 261 && NowFloor <= 279)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 280)//9ボス
            {
                EnemyEncount = 33;
            }
            else if (NowFloor >= 281 && NowFloor <= 299)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 300)//10ボス
            {
                EnemyEncount = 34;
            }
            else if (NowFloor >= 301 && NowFloor <= 329)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 330)//11ボス
            {
                EnemyEncount = 35;
            }
            else if (NowFloor >= 331 && NowFloor <= 349)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 350)//12ボス
            {
                EnemyEncount = 36;
            }
            else if (NowFloor >= 351 && NowFloor <= 369)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 370)//13ボス
            {
                EnemyEncount = 37;
            }
            else if (NowFloor >= 371 && NowFloor <= 399)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 400)//14ボス
            {
                EnemyEncount = 38;
            }
            else if (NowFloor >= 401 && NowFloor <= 449)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 450)//15ボス
            {
                EnemyEncount = 39;
            }
            else if (NowFloor >= 451 && NowFloor <= 499)
            {
                EnemyEncount = rand.Next(24) + 1;
            }
            else if (NowFloor == 500)//16ボス
            {
                EnemyEncount = 40;
            }
            else if (NowFloor >= 501 && NowFloor <= 999)
            {
                EnemyEncount = rand.Next(39) + 1;
            }
            else if (NowFloor == 2000)//17ボス
            {
                EnemyEncount = 41;
            }

            switch (EnemyEncount)
            {
                case 1://ナタデ・ココ
                    MobName = "ナタデ・ココ";
                    MobHP = 30 + ((NowLevel - 1) * 15);
                    MobPhysicAT = 10 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 4;
                    MobMagicAT = 10;
                    MobMagicDF = 5;
                    MobEXP = 14;
                    MobID = 1;
                    Assets_natade_coco_png.Visibility = Visibility;
                    break;

                case 2://ダークサモナー
                    MobName = "ダークサモナー";
                    MobHP = 33 + ((NowLevel - 1) * 10);
                    MobPhysicAT = 10;
                    MobPhysicDF = 60 + ((NowLevel - 1) * 2);
                    MobMagicAT = 20 + ((NowLevel - 1) * 3);
                    MobMagicDF = -33;
                    MobEXP = 14;
                    MobID = 2;
                    Assets_dark_summoner_png.Visibility = Visibility;
                    break;

                case 3://スカルパイレーツ
                    MobName = "スカルパイレーツ";
                    MobHP = 40 + ((NowLevel - 1) * 20);
                    MobPhysicAT = 26 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 4;
                    MobMagicAT = 10;
                    MobMagicDF = 32 + ((NowLevel - 1) * 2);
                    MobEXP = 24;
                    MobID = 3;
                    Assets_sukll_pirate_png.Visibility = Visibility;
                    break;

                case 4://ポジティブムーン
                    MobName = "ポジティブムーン";
                    MobHP = 40 + ((NowLevel - 1) * 20);
                    MobPhysicAT = 15;
                    MobPhysicDF = 20 + ((NowLevel - 1) * 2);
                    MobMagicAT = 22 + ((NowLevel - 1) * 3);
                    MobMagicDF = -20;
                    MobEXP = 30;
                    MobID = 4;
                    Assets_nagative_moon_png.Visibility = Visibility;
                    break;

                case 5://ネガティブサン
                    MobName = "ネガティブサン";
                    MobHP = 90 + ((NowLevel - 1) * 20);
                    MobPhysicAT = 23 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 7;
                    MobMagicAT = 10;
                    MobMagicDF = 45 + ((NowLevel - 1) * 3);
                    MobEXP = 34;
                    MobID = 5;
                    Assets_negative_sun_png.Visibility = Visibility;
                    break;

                case 6://チックワン
                    MobName = "チックワン";
                    MobHP = 120 + ((NowLevel - 1) * 20);
                    MobPhysicAT = 50 + ((NowLevel - 1) * 3);
                    MobPhysicDF = 4;
                    MobMagicAT = 10;
                    MobMagicDF = 5;
                    MobEXP = 90;
                    MobID = 6;
                    attackcount = 3;
                    Assets_chikkuwan_png.Visibility = Visibility;
                    break;

                case 7://神様
                    MobName = "神様";
                    MobHP = 1;
                    MobPhysicAT = 1;
                    MobPhysicDF = 1;
                    MobMagicAT = 1;
                    MobMagicDF = 1;
                    MobEXP = 80 * NowLevel;
                    MobID = 7;
                    Assets_god_png.Visibility = Visibility;
                    break;

                case 8://バジリスク
                    MobName = "バジリスク";
                    MobHP = 230 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 50 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 9;
                    MobMagicAT = 10;
                    MobMagicDF = 5;
                    MobEXP = 110;
                    MobID = 8;
                    Assets_basilisk_png.Visibility = Visibility;
                    break;

                case 9://ワームドック
                    MobName = "ワームドック";
                    MobHP = 240 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 40 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 4 + ((NowLevel - 1) * 2);
                    MobMagicAT = 40;
                    MobMagicDF = 45;
                    MobEXP = 100;
                    MobID = 9;
                    Assets_worm_dog_png.Visibility = Visibility;
                    break;

                case 10://プロテクター
                    MobName = "プロテクター";
                    MobHP = 200 + ((NowLevel - 1) * 100);
                    MobPhysicAT = 30 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 200 + ((NowLevel - 1) * 5);
                    MobMagicAT = 70;
                    MobMagicDF = -300;
                    MobEXP = 140;
                    MobID = 10;
                    Assets_protector_png.Visibility = Visibility;
                    break;

                case 11://ディバーデット
                    MobName = "ディバーデット";
                    MobHP = 220 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 40 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 30;
                    MobMagicAT = 50;
                    MobMagicDF = 85;
                    MobEXP = 200;
                    MobID = 11;
                    Assets_dibadetto_png.Visibility = Visibility;
                    break;

                case 12://グリペル
                    MobName = "グリペル";
                    MobHP = 20 + ((NowLevel - 1) * 300);
                    MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                    MobPhysicDF = -5000;
                    MobMagicAT = 130;
                    MobMagicDF = 3000;
                    MobEXP = 300;
                    MobID = 12;
                    Assets_guriperu_png.Visibility = Visibility;
                    break;

                case 13://ジョイ
                    MobName = "ジョイ";
                    MobHP = 20 + ((NowLevel - 1) * 300);
                    MobPhysicAT = 120;
                    MobPhysicDF = -5000;
                    MobMagicAT = 130 + ((NowLevel - 1) * 2);
                    MobMagicDF = 3000;
                    MobEXP = 240;
                    MobID = 13;
                    Assets_joy_png.Visibility = Visibility;
                    break;

                case 14://ウィーブ
                    MobName = "ウィーブ";
                    MobHP = 20 + ((NowLevel - 1) * 300);
                    MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 3000;
                    MobMagicAT = 130;
                    MobMagicDF = -5000;
                    MobEXP = 200;
                    MobID = 14;
                    Assets_weave_png.Visibility = Visibility;
                    break;

                case 15://ファン
                    MobName = "ファン";
                    MobHP = 20 + ((NowLevel - 1) * 300);
                    MobPhysicAT = 120;
                    MobPhysicDF = 3000;
                    MobMagicAT = 120 + ((NowLevel - 1) * 2);
                    MobMagicDF = -5000;
                    MobEXP = 200;
                    MobID = 15;
                    Assets_fun_png.Visibility = Visibility;
                    break;

                case 16://パドル
                    MobName = "パドル";
                    MobHP = 520 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 50 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 3000;
                    MobMagicAT = 70 + ((NowLevel - 1) * 3);
                    MobMagicDF = 0;
                    MobEXP = 300;
                    MobID = 16;
                    Assets_paddle_png.Visibility = Visibility;
                    break;

                case 17://ワント
                    MobName = "ワント";
                    MobHP = 520 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 30;
                    MobMagicAT = 30;
                    MobMagicDF = 69;
                    MobEXP = 300;
                    MobID = 17;
                    Assets_wanto_png.Visibility = Visibility;
                    break;

                case 18://エンスレイヴン
                    MobName = "エンスレイヴン";
                    MobHP = 720 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 50 + ((NowLevel - 1) * 2);
                    MobMagicAT = 90 + ((NowLevel - 1) * 2);
                    MobMagicDF = 50;
                    MobEXP = 300;
                    MobID = 18;
                    Assets_enns_raven_png.Visibility = Visibility;
                    break;

                case 19://アテンダント
                    MobName = "アテンダント";
                    MobHP = 1020 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 80 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 200 + ((NowLevel - 1) * 2);
                    MobMagicAT = 80;
                    MobMagicDF = 30;
                    MobEXP = 320;
                    MobID = 19;
                    Assets_attendant_png.Visibility = Visibility;
                    break;

                case 20://ブラインカーズ
                    MobName = "ブラインカーズ";
                    MobHP = 920 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 70 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 20;
                    MobMagicAT = 100;
                    MobMagicDF = 20 + ((NowLevel - 1) * 2);
                    MobEXP = 400;
                    MobID = 20;
                    Assets_bryn_cars_png.Visibility = Visibility;
                    break;

                case 21://クラウン
                    MobName = "クラウン";
                    MobHP = 1220 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 90 + ((NowLevel - 1) * 2);
                    MobPhysicDF = 3000;
                    MobMagicAT = 70;
                    MobMagicDF = 20;
                    MobEXP = 600;
                    MobID = 21;
                    Assets_crown_png.Visibility = Visibility;
                    break;

                case 22://ピット
                    MobName = "ピット";
                    MobHP = 920 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 50 + ((NowLevel - 1) * 3);
                    MobPhysicDF = 100;
                    MobMagicAT = 130;
                    MobMagicDF = 100 + ((NowLevel - 1) * 2);
                    MobEXP = 400;
                    MobID = 22;
                    Assets_pit_png.Visibility = Visibility;
                    break;

                case 23://エリアル
                    MobName = "エリアル";
                    MobHP = 1520 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 20 + ((NowLevel - 1) * 3);
                    MobPhysicDF = 150 + ((NowLevel - 1) * 3);
                    MobMagicAT = 130;
                    MobMagicDF = 20;
                    MobEXP = 600;
                    MobID = 23;
                    Assets_erial_png.Visibility = Visibility;
                    break;

                case 24://プリゾナ
                    MobName = "プリゾナ";
                    MobHP = 1220 + ((NowLevel - 1) * 50);
                    MobPhysicAT = 20 + ((NowLevel - 1) * 3);
                    MobPhysicDF = -400;
                    MobMagicAT = 130 + ((NowLevel - 1) * 2);
                    MobMagicDF = -400;
                    MobEXP = 600;
                    MobID = 24;
                    Assets_purizona_png.Visibility = Visibility;
                    break;

                case 25://Mtヴェント
                    MobName = "Mtヴェント";
                    MobHP = 2000;
                    MobPhysicAT = 30;
                    MobPhysicDF = -50;
                    MobMagicAT = 30;
                    MobMagicDF = 75;
                    MobEXP = 500;
                    MobID = 25;
                    Assets_mt_vento_png.Visibility = Visibility;
                    break;

                case 26://Mhブラザーズ
                    MobName = "Mhブラザーズ";
                    MobHP = 2000;
                    MobPhysicAT = 70;
                    MobPhysicDF = 3000;
                    MobMagicAT = 70;
                    MobMagicDF = -300;
                    MobEXP = 700;
                    MobID = 26;
                    Assets_mh_brothers_png.Visibility = Visibility;
                    break;

                case 27://キング・ココ
                    MobName = "キング・ココ";
                    MobHP = 20000;
                    MobPhysicAT = 70;
                    MobPhysicDF = 0;
                    MobMagicAT = 19;
                    MobMagicDF = 0;
                    MobEXP = 2000;
                    MobID = 27;
                    Assets_king_coco_png.Visibility = Visibility;
                    break;

                case 28://アルカトル
                    MobName = "アルカトル";
                    MobHP = 20000;
                    MobPhysicAT = 130;
                    MobPhysicDF = 30;
                    MobMagicAT = 110;
                    MobMagicDF = 90;
                    MobEXP = 1235;
                    MobID = 28;
                    Assets_alcatol_png.Visibility = Visibility;
                    break;

                case 29://サラマンダ
                    MobName = "サラマンダ";
                    MobHP = 20000;
                    MobPhysicAT = 150;
                    MobPhysicDF = 100;
                    MobMagicAT = 150;
                    MobMagicDF = 100;
                    MobEXP = 1435;
                    MobID = 29;
                    Assets_salamander_png.Visibility = Visibility;
                    break;

                case 30://シュラ
                    MobName = "シュラ";
                    MobHP = 20000;
                    MobPhysicAT = 200;
                    MobPhysicDF = 70;
                    MobMagicAT = 125;
                    MobMagicDF = 55;
                    MobEXP = 2035;
                    MobID = 30;
                    Assets_shura_png.Visibility = Visibility;
                    break;

                case 31://テンペスト
                    MobName = "テンペスト";
                    MobHP = 25000;
                    MobPhysicAT = 100;
                    MobPhysicDF = 100;
                    MobMagicAT = 200;
                    MobMagicDF = 4000;
                    MobEXP = 3035;
                    MobID = 31;
                    Assets_tempest_png.Visibility = Visibility;
                    break;

                case 32://ヴァンパイア
                    MobName = "ヴァンパイア";
                    MobHP = 30000;
                    MobPhysicAT = 250;
                    MobPhysicDF = 100;
                    MobMagicAT = 150;
                    MobMagicDF = 100;
                    MobEXP = 4035;
                    MobID = 32;
                    Assets_vampire_png.Visibility = Visibility;
                    break;

                case 33://アブソリュート
                    MobName = "アブソリュート";
                    MobHP = 35000;
                    MobPhysicAT = 200;
                    MobPhysicDF = 100;
                    MobMagicAT = 250;
                    MobMagicDF = 100;
                    MobEXP = 8000;
                    MobID = 33;
                    Assets_absolute_zero_png.Visibility = Visibility;
                    break;

                case 34://モーティシャン
                    MobName = "モーティシャン";
                    MobHP = 50000;
                    MobPhysicAT = 300;
                    MobPhysicDF = 200;
                    MobMagicAT = 100;
                    MobMagicDF = -2000;
                    MobEXP = 20000;
                    MobID = 34;
                    Assets_motishan_png.Visibility = Visibility;
                    break;

                case 35://シヴァ
                    MobName = "シヴァ";
                    MobHP = 70000;
                    MobPhysicAT = 250;
                    MobPhysicDF = 200;
                    MobMagicAT = 270;
                    MobMagicDF = 200;
                    MobEXP = 13000;
                    MobID = 35;
                    Assets_shiva_png.Visibility = Visibility;
                    break;

                case 36://ケロベロス
                    MobName = "ケロベロス";
                    MobHP = 200000;
                    MobPhysicAT = 300;
                    MobPhysicDF = 2000;
                    MobMagicAT = 130;
                    MobMagicDF = -2000;
                    MobEXP = 20000;
                    MobID = 36;
                    Assets_ceroberus_png.Visibility = Visibility;
                    break;

                case 37://イフリート
                    MobName = "イフリート";
                    MobHP = 200000;
                    MobPhysicAT = 300;
                    MobPhysicDF = 100;
                    MobMagicAT = 200;
                    MobMagicDF = 250;
                    MobEXP = 20000;
                    MobID = 37;
                    Assets_ifrit_png.Visibility = Visibility;
                    break;

                case 38://ラムゥ
                    MobName = "ラムゥ";
                    MobHP = 200000;
                    MobPhysicAT = 200;
                    MobPhysicDF = 1200;
                    MobMagicAT = 350;
                    MobMagicDF = 200;
                    MobEXP = 30000;
                    MobID = 38;
                    Assets_ramuu_png.Visibility = Visibility;
                    break;

                case 39://メデューサ
                    MobName = "メデューサ";
                    MobHP = 220000;
                    MobPhysicAT = 300;
                    MobPhysicDF = 105;
                    MobMagicAT = 400;
                    MobMagicDF = 1505;
                    MobEXP = 30000;
                    MobID = 39;
                    Assets_medusa_png.Visibility = Visibility;
                    break;

                case 40://デストロイヤー
                    MobName = "デストロイヤー";
                    MobHP = 300000;
                    MobPhysicAT = 500;
                    MobPhysicDF = 500;
                    MobMagicAT = 0;
                    MobMagicDF = 3000;
                    MobEXP = 50000;
                    MobID = 40;
                    attackcount = 4;
                    Assets_destroyer_png.Visibility = Visibility;
                    break;

                case 41://魔人
                    MobName = "魔人";
                    MobHP = 2000000;
                    MobPhysicAT = 1200;
                    MobPhysicDF = 20000000;
                    MobMagicAT = 1200;
                    MobMagicDF = 20000000;
                    MobEXP = 200000;
                    MobID = 41;
                    Assets_demon_png.Visibility = Visibility;
                    break;
            }
            MonsterFlame.Visibility = Visibility;
            MobPhysicDFNow = MobPhysicDF;
            MobMagicDFNow = MobMagicDF;
            text2.Text = " Lv:" + NowLevel + "HP:" + NowHP + " MP:" + NowMP + "\n   装備:" + ItemName;
            if (MobID == 7)//神様出現時の処理
            {
                text.Text = MobName + "が現れた！\n「練習に付き合ってやんよ！」\nどうする？";
            }
            else if (MobID == 41)
            {
                text.Text = "よくぞ我が封印を解いてくれた" + textBox.Text + "！\nしかし、お前が開けたのは…\nパンドラの箱だったのだ！！！";
            }
            else if(MobID != 7 && MobID != 41)//その他のモンスター
                text.Text = MobName + "が現れた！\nどうする？";
        }

        private void PlayerNowState()
        {
            //レベルアップ時のステータス処理
            NowLevel++;
            MaxHP = 70 + ((NowLevel - 1) * 15);
            MaxMP = 60 + ((NowLevel - 1) * 10);
            PlayerPhysicAT = 24 + ((NowLevel - 1) * 2);
            PlayerPhysicDF = 8 + ((NowLevel - 1) * 2);
            PlayerMasicAT = 12 + ((NowLevel - 1) * 2);
            PlayerMasicDF = 6 + ((NowLevel - 1) * 2);
            NowHP = MaxHP;
            NowMP = MaxMP;
        }

        private void WeaponDrop()
        {
           
            //武器のドロップ判定
            Random rand = new Random();

            if (rand.Next(15) % 7 == 0) { WeaDrop = true; }

            //ドロップ処理
            if (WeaDrop == true)
            {
                    switch (MobID + 1)
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
                        WeaMagicAT = 2000;
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
                        WeaMagicAT = 2000;
                        break;

                    case 25://プリズンブレイク
                        WeaponName = "プリズンブレイク";
                        WeaPhysicAT = 2000;
                        WeaMagicAT = 2000;
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
                        WeaPhysicAT = 2000;
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
                        WeaPhysicAT = 20000;
                        WeaMagicAT = 20000;
                        break;

                    case 42://エグゼット
                        WeaponName = "エグゼット";
                        WeaPhysicAT = 50000;
                        WeaMagicAT = 50000;
                        break;
                }
            }
            return;
        }
        
        //戦闘時のコマンド呼び出し
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //攻撃
            x = 0;
            y = 0;
            MyTurn();
        }
        private void button_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            //魔法
            x = 1;
            y = 0;
            MyTurn();
        }
        private void button_Copy1_Click_1(object sender, RoutedEventArgs e)
        {
            //奥義
            x = 0;
            y = 1;
            MyTurn();
        }
        private void button_Copy2_Click_1(object sender, RoutedEventArgs e)
        {
            //防御
            x = 1;
            y = 1;
            MyTurn();
        }
        private async void button1_Click_1(object sender, RoutedEventArgs e)
        {
            ////敵コマンド
            //TextSend.IsEnabled = false;
            ////勝利画面へ
            //if (MobHP == 0)
            //{

            //    Attack.Visibility = Visibility.Collapsed;
            //    Magic.Visibility = Visibility.Collapsed;
            //    Hidden.Visibility = Visibility.Collapsed;
            //    Defense.Visibility = Visibility.Collapsed;
            //    TextSend.IsEnabled = false;
            //    Defense.IsEnabled = false;
            //    Attack.IsEnabled = false;
            //    Magic.IsEnabled = false;
            //    Hidden.IsEnabled = false;
            //    GameSet();
            //}

            //else
            //{
            //    Random rand = new Random();
            //    MobCommand = rand.Next(4);
            //    switch (MobID)
            //    {
            //        case 6: //チックワンのコマンド                        
            //            if (attackcount == 0)
            //            {
            //                EnemyDamage = MobPhysicAT - NowPhysicDF;
            //                if (EnemyDamage <= 0)
            //                {
            //                    EnemyDamage = 0;
            //                    text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
            //                }
            //                else
            //                {
            //                    text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
            //                }
            //                attackcount = 3;
            //            }
            //            else
            //            {
            //                text.Text = MobName + "は力を溜めている。";
            //                EnemyDamage = 0;
            //                attackcount -= 1;
            //            }
            //            NowHP -= EnemyDamage;
            //            if (NowHP <= 0)
            //            {
            //                NowHP = 0;
            //                EnemyDamage = 0;
            //            }
            //            break;
            //        case 40: //デストロイヤーのコマンド
            //            if (attackcount == 0)
            //            {
            //                EnemyDamage = MobPhysicAT - NowPhysicDF;
            //                if (EnemyDamage <= 0)
            //                {
            //                    EnemyDamage = 0;
            //                    text.Text = MobName + "は暴れている！\n" + "痛くもかゆくもない。";
            //                }
            //                else
            //                {
            //                    text.Text = MobName + "は暴れている！\n" + EnemyDamage + "のダメージを受けた。";
            //                }
            //            }
            //            else
            //            {
            //                text.Text = MobName + "は魔法の鎖を切ろうとしている！";
            //                EnemyDamage = 0;
            //                attackcount -= 1;
                            
            //                if (attackcount == 0)
            //                {
            //                    await Task.Delay(800);
            //                    text.Text = "魔法の鎖が切れてしまった！";
            //                }
            //            }
            //            NowHP -= EnemyDamage;
            //            if (NowHP <= 0)
            //            {
            //                NowHP = 0;
            //                EnemyDamage = 0;
            //            }
            //            break;
            //        case 41: //魔人のコマンド
            //            switch (MobCommand)
            //            {
            //                case 0:
            //                    EnemyDamage = MobPhysicAT - NowPhysicDF;
            //                    if (EnemyDamage <= 0)
            //                    {
            //                        EnemyDamage = 0;
            //                        text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
            //                    }
            //                    else
            //                    {
            //                        text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
            //                    }
            //                    MobMagicDFNow = 0;
            //                    break;
            //                case 1:
            //                    EnemyDamage = MobMagicAT - PlayerMasicDF;
            //                    if (EnemyDamage <= 0)
            //                    {
            //                        EnemyDamage = 0;
            //                        text.Text = MobName + "の天罰！\n" + "痛くもかゆくもない。";
            //                    }
            //                    else
            //                    {
            //                        text.Text = MobName + "の天罰！\n" + EnemyDamage + "のダメージを受けた。";
            //                    }
            //                    MobPhysicDFNow = 0;
            //                    break;
            //                case 2:
            //                    MobPhysicDFNow = MobPhysicDF * 2;
            //                    text.Text = MobName + "は防御に徹している。" + MobName + "の防御力が上昇した。";
            //                    EnemyDamage = 0;
            //                    break;
            //                case 3:
            //                    text.Text = MobName + "は呪文を唱えている。";
            //                    MobPhysicDFNow = MobPhysicDF;
            //                    MobMagicDFNow = MobMagicDF;
            //                    EnemyDamage = 0;
            //                    break;
            //            }
            //            NowHP -= EnemyDamage;
            //            if (NowHP <= 0)
            //            {
            //                NowHP = 0;
            //                EnemyDamage = 0;
            //            }
            //            break;
            //        default:
            //            switch (MobCommand)
            //            {
            //                case 0:
            //                    EnemyDamage = MobPhysicAT - NowPhysicDF;
            //                    if (EnemyDamage <= 0)
            //                    {
            //                        EnemyDamage = 0;
            //                        text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
            //                    }
            //                    else
            //                    {
            //                        text.Text = MobName + "の攻撃！\n" + EnemyDamage + "のダメージを受けた。";
            //                    }
            //                    break;
            //                case 1:
            //                    EnemyDamage = MobMagicAT - PlayerMasicDF;
            //                    if (EnemyDamage <= 0)
            //                    {
            //                        EnemyDamage = 0;
            //                        text.Text = MobName + "の攻撃！\n" + "痛くもかゆくもない。";
            //                    }
            //                    else
            //                    {
            //                        text.Text = MobName + "の魔法攻撃！\n" + EnemyDamage + "のダメージを受けた。";
            //                    }
            //                    break;
            //                case 2:
            //                    MobPhysicDFNow = MobPhysicDF * 2;
            //                    text.Text = MobName + "は防御に徹している。" + MobName + "の防御力が上昇した。";
            //                    EnemyDamage = 0;
            //                    break;
            //                case 3:
            //                    text.Text = MobName + "は様子を伺っている。";
            //                    EnemyDamage = 0;
            //                    break;
            //            }

            //            NowHP -= EnemyDamage;
            //            if (NowHP <= 0)
            //            {
            //                NowHP = 0;
            //                EnemyDamage = 0;
            //            }
            //            break;
            //    }

            //}
            //text2.Text = " Lv:" + NowLevel + "HP:" + NowHP + " MP:" + NowMP + "\n   装備:" + ItemName;

            //if(MobID <= 40)
            //{
            //    MobPhysicDFNow = MobPhysicDF;                
            //}



            //await Task.Delay(2000);
            ////敗北画面へ
            //if (NowHP == 0)
            //{
            //    TextSend.IsEnabled = false;
            //    Attack.IsEnabled = false;
            //    Magic.IsEnabled = false;
            //    Hidden.IsEnabled = false;
            //    Defense.IsEnabled = false;
            //    Attack.Visibility = Visibility.Collapsed;
            //    Magic.Visibility = Visibility.Collapsed;
            //    Hidden.Visibility = Visibility.Collapsed;
            //    Defense.Visibility = Visibility.Collapsed;
            //    GameSet();
            //}
            //else if(NowHP != 0)
            //{
            //    Attack.IsEnabled = true;
            //    Magic.IsEnabled = true;
            //    Hidden.IsEnabled = true;
            //    Defense.IsEnabled = true;
            //    TextSend.IsEnabled = false;
            //    Attack.Visibility = Visibility;
            //    Magic.Visibility = Visibility;
            //    Hidden.Visibility = Visibility;
            //    Defense.Visibility = Visibility;
            //    text.Visibility = Visibility.Collapsed;
            //}
            //await Task.Delay(2000);
            //return;

        }
        private async void GameSet()
        {
            
            //勝利
            if (MobHP <= 0)
            {
                ////ボタンの無効化
                TextSend.IsEnabled = false;


                switch (MobID)
                {
                    case 1://ナタデ・ココ
                        Assets_natade_coco_png.Visibility = Visibility.Collapsed;
                        break;

                    case 2://ダークサモナー
                        Assets_dark_summoner_png.Visibility = Visibility.Collapsed;
                        break;

                    case 3://スカルパイレーツ
                        Assets_sukll_pirate_png.Visibility = Visibility.Collapsed;
                        break;

                    case 4://ポジティブムーン
                        Assets_nagative_moon_png.Visibility = Visibility.Collapsed;
                        break;

                    case 5://ネガティブサン
                        Assets_negative_sun_png.Visibility = Visibility.Collapsed;
                        break;

                    case 6://チックワン
                        Assets_chikkuwan_png.Visibility = Visibility.Collapsed;
                        break;

                    case 7://神様
                           //イベントを描く
                        Assets_god_png.Visibility = Visibility.Collapsed;
                        break;

                    case 8://バジリスク
                        Assets_basilisk_png.Visibility = Visibility.Collapsed;
                        break;

                    case 9://ワームドック
                        Assets_worm_dog_png.Visibility = Visibility.Collapsed;
                        break;

                    case 10://プロテクター
                        Assets_protector_png.Visibility = Visibility.Collapsed;
                        break;

                    case 11://ディバーデット
                        Assets_dibadetto_png.Visibility = Visibility.Collapsed;
                        break;

                    case 12://グリペル
                        Assets_guriperu_png.Visibility = Visibility.Collapsed;
                        break;

                    case 13://ジョイ
                        Assets_joy_png.Visibility = Visibility.Collapsed;
                        break;

                    case 14://ウィーブ
                        Assets_weave_png.Visibility = Visibility.Collapsed;
                        break;

                    case 15://ファン
                        Assets_fun_png.Visibility = Visibility.Collapsed;
                        break;

                    case 16://パドル
                        Assets_paddle_png.Visibility = Visibility.Collapsed;
                        break;

                    case 17://ワント
                        Assets_wanto_png.Visibility = Visibility.Collapsed;
                        break;

                    case 18://エンスレイヴン
                        Assets_enns_raven_png.Visibility = Visibility.Collapsed;
                        break;

                    case 19://アテンダント
                        Assets_attendant_png.Visibility = Visibility.Collapsed;
                        break;

                    case 20://ブラインカーズ
                        Assets_bryn_cars_png.Visibility = Visibility.Collapsed;
                        break;

                    case 21://クラウン
                        Assets_crown_png.Visibility = Visibility.Collapsed;
                        break;

                    case 22://ピット
                        Assets_pit_png.Visibility = Visibility.Collapsed;
                        break;

                    case 23://エリアル
                        Assets_erial_png.Visibility = Visibility.Collapsed;
                        break;

                    case 24://プリゾナ
                        Assets_purizona_png.Visibility = Visibility.Collapsed;
                        break;

                    case 25://Mtヴェント
                        Assets_mt_vento_png.Visibility = Visibility.Collapsed;
                        break;

                    case 26://Mhブラザーズ
                        Assets_mh_brothers_png.Visibility = Visibility.Collapsed;
                        break;

                    case 27://キング・ココ
                        Assets_king_coco_png.Visibility = Visibility.Collapsed;
                        break;

                    case 28://アルカトル
                        Assets_alcatol_png.Visibility = Visibility.Collapsed;
                        break;

                    case 29://サラマンダ
                        Assets_salamander_png.Visibility = Visibility.Collapsed;
                        break;

                    case 30://シュラ
                        Assets_shura_png.Visibility = Visibility.Collapsed;
                        break;

                    case 31://テンペスト
                        Assets_tempest_png.Visibility = Visibility.Collapsed;
                        break;

                    case 32://ヴァンパイア
                        Assets_vampire_png.Visibility = Visibility.Collapsed;
                        break;

                    case 33://アブソリュート
                        Assets_absolute_zero_png.Visibility = Visibility.Collapsed;
                        break;

                    case 34://モーティシャン
                        Assets_motishan_png.Visibility = Visibility.Collapsed;
                        break;

                    case 35://シヴァ
                        Assets_shiva_png.Visibility = Visibility.Collapsed;
                        break;

                    case 36://ケロベロス
                        Assets_ceroberus_png.Visibility = Visibility.Collapsed;
                        break;

                    case 37://イフリート
                        Assets_ifrit_png.Visibility = Visibility.Collapsed;
                        break;

                    case 38://ラムゥ
                        Assets_ramuu_png.Visibility = Visibility.Collapsed;
                        break;

                    case 39://メデューサ
                        Assets_medusa_png.Visibility = Visibility.Collapsed;
                        break;

                    case 40://デストロイヤー
                        Assets_destroyer_png.Visibility = Visibility.Collapsed;
                        break;

                    case 41://魔人
                        Assets_demon_png.Visibility = Visibility.Collapsed;
                        break;
                }
                text.Text = MobName + "を倒した。";

                await Task.Delay(2000);
                EXP += MobEXP;
                NowFloor++;
                if (EXP >= NowLevel * 80)
                {
                    //ボタンの無効化
                    TextSend.IsEnabled = false;
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    //AttackText.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility.Visible;
                    text.Text = "レベルが上がった！";
                    await Task.Delay(2000);
                    EXP -= NowLevel * 80;
                    PlayerNowState();

                }
                if (NowFloor == 1001) {
                    this.Frame.Navigate(typeof(GameClear));
                }
                WeaponDrop();
                if (WeaDrop == true) {
                    //ボタンの無効化
                    TextSend.IsEnabled = false;
                    Attack.IsEnabled = false;
                    Magic.IsEnabled = false;
                    Hidden.IsEnabled = false;
                    Defense.IsEnabled = false;
                    //ボタンの非表示
                    Attack.Visibility = Visibility.Collapsed;
                    Magic.Visibility = Visibility.Collapsed;
                    Hidden.Visibility = Visibility.Collapsed;
                    Defense.Visibility = Visibility.Collapsed;
                    text.Visibility = Visibility;
                    text.Text = WeaponName + "を手に入れた！\n装備しますか？\n攻撃力"+WeaPhysicAT+"\n魔法攻撃力"+WeaMagicAT+"\n次の面接まで5秒";
                    Yes.IsEnabled = true;
                    Yes.Visibility = Visibility.Visible;
                    textBlock1.Visibility = Visibility.Visible;
                    No.IsEnabled = true;
                    No.Visibility = Visibility.Visible;
                    textBlock2.Visibility = Visibility.Visible;
                }
                else
                BattleEnd();
            }
            //敗北
            if (NowHP <= 0)
            {
                await Task.Delay(2000);
                text.Text = textBox.Text + "は力尽きた。";
                await Task.Delay(2000);
                //ゲームオーバーへ
                this.Frame.Navigate(typeof(GameOver));
            }
            

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            //武器取得時はいを選択
            text.Text = WeaponName + " を装備した";
            ItemAT = WeaPhysicAT;
            ItemMT = WeaMagicAT;
            ItemName = WeaponName;
            Yes.IsEnabled = false;
            Yes.Visibility = Visibility.Visible;
            No.IsEnabled = false;
            No.Visibility = Visibility.Visible;
            textBlock1.Visibility = Visibility.Collapsed;
            textBlock2.Visibility = Visibility.Collapsed;
            WeaDrop = false;
            BattleEnd();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            //武器取得時いいえを選択
            Yes.IsEnabled = false;
            Yes.Visibility = Visibility.Visible;
            No.IsEnabled = false;
            No.Visibility = Visibility.Visible;
            WeaDrop = false;
            BattleEnd();
        }

        private void NextStage_Click(object sender, RoutedEventArgs e)
        {
            //NextStage.IsEnabled = false;
            //FloorCutInGrid.Visibility = Visibility.Collapsed;
            //BattleStart();
        }

        private async void Dec_Click_1(object sender, RoutedEventArgs e)
        {
            //名前入力時の処理
            if (textBox.Text == "")
            {
                textBox.Text = Convert.ToString("就活生");
            }
            await Task.Delay(400);
            Name.Visibility = Visibility.Collapsed;
            Dec.IsEnabled = false;
            FloorCutIn();
        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            textBox.MaxLength = 4;//4文字まで入力可
        }
    }
}
