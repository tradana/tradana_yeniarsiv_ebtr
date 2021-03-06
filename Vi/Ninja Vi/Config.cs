﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace Vi
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Ninja Vi";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Vi By Zpitty");
            Menu.AddLabel("Sorunları Lütfen Forumdan Bildirin!");
            Menu.AddLabel("Çeviri-TRAdana");


            Modes.Initialize();
            Smite.Initialize();
            Draw.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                Menu = Config.Menu.AddSubMenu("Modes");

                Combo.Initialize();
                Menu.AddSeparator();
                JungleClear.Initialize();
                Menu.AddSeparator();
                LaneClear.Initialize();
                Menu.AddSeparator();
                MiscMenu.Initialize();
                
                
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {

                public static Menu MainMenu
                {
                    get { return Menu; }
                }

                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }


                static Combo()
                {
                    Menu.AddGroupLabel("Kombo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Kullan W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Kullan E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Kullan R", false));
                    Menu.Add("flashq", new KeyBind("FlashQ - Seçili Hedefe (Bas)", false, KeyBind.BindTypes.HoldActive, 'T'));
                    Menu.Add("forceR", new KeyBind("Zorla R", false, KeyBind.BindTypes.HoldActive, 'R'));
                    Menu.Add("gankbutton", new KeyBind("Gank - (Bas)", false, KeyBind.BindTypes.HoldActive, 'Z'));
                    Menu.AddLabel("R için:");
                    if (EntityManager.Heroes.Enemies.Count > 0)
                    {
                        var addedChamps = new List<string>();
                        foreach (var enemy in EntityManager.Heroes.Enemies.Where(enemy => !addedChamps.Contains(enemy.ChampionName)))
                        {
                            addedChamps.Add(enemy.ChampionName);
                            Menu.Add(enemy.ChampionName, new CheckBox(string.Format("{0} ({1})", enemy.ChampionName, enemy.Name)));
                        }
                    }
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;
                private static readonly Slider _minMana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int MinMana
                {
                    get { return _minMana.CurrentValue; }
                }

                static JungleClear()
                {
                    Menu.AddGroupLabel("OrmanTemizleme");
                    _useQ = Menu.Add("jungleUseQ", new CheckBox("Kullan Q"));
                    _useE = Menu.Add("jungleUseE", new CheckBox("Kullan E"));
                    _minMana = Menu.Add("jungleMana", new Slider("Büyüler için gereken mana %", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;
                private static readonly Slider _minMana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int MinMana
                {
                    get { return _minMana.CurrentValue; }
                }

                static LaneClear()
                {
                    Menu.AddGroupLabel("LaneTemizleme");
                    _useQ = Menu.Add("laneUseQ", new CheckBox("Kullan Q"));
                    _useE = Menu.Add("laneUseE", new CheckBox("Kullan E"));
                    _minMana = Menu.Add("laneMana", new Slider("Büyüler için gereken mana %", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class MiscMenu
            {
                private static readonly CheckBox _enablePotion;
                private static readonly Slider _minHPPotion;
                private static readonly Slider _minMPPotion;

                public static bool EnablePotion
                {
                    get { return _enablePotion.CurrentValue; }
                }

                public static int MinHPPotion
                {
                    get { return _minHPPotion.CurrentValue; }
                }

                public static int MinMPPotion
                {
                    get { return _minMPPotion.CurrentValue; }
                }


                static MiscMenu()
                {
                    Menu.AddGroupLabel("Ek");
                    Menu.AddGroupLabel("İksir Yardımcısı");
                    _enablePotion = Menu.Add("Potion", new CheckBox("İksirleri Kullan"));
                    _minHPPotion = Menu.Add("minHPPotion", new Slider("Canım Şundan Az %", 60));
                    _minMPPotion = Menu.Add("minMPPotion", new Slider("Manam Şundan Az %", 20));
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class Smite
        {
            public static readonly Menu SMenu;
            static Smite()
            {

                SMenu = Config.Menu.AddSubMenu("Smite Menu");

                SmiteMenu.Initialize();
            }
            public static void Initialize()
            {
            }

            public static class SmiteMenu
            {
                public static readonly KeyBind _smiteEnemies;
                public static readonly KeyBind _smiteCombo;
                private static readonly KeyBind _smiteToggle;
                private static readonly Slider _redSmitePercent;

                public static Menu MainMenu
                {
                    get { return SMenu; }
                }


                public static bool SmiteToggle
                {
                    get { return _smiteToggle.CurrentValue; }
                }

                public static bool SmiteEnemies
                {
                    get { return _smiteEnemies.CurrentValue; }
                }

                public static bool SmiteCombo
                {
                    get { return _smiteCombo.CurrentValue; }
                }

                public static int RedSmitePercent
                {
                    get { return _redSmitePercent.CurrentValue; }
                }

                static SmiteMenu()
                {
                    SMenu.AddGroupLabel("Çarp  Ayarları");
                    SMenu.AddSeparator();
                    _smiteToggle = SMenu.Add("EnableSmite", new KeyBind("Çarp Canavarlar Üzerinde Aktif Tuşu", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteEnemies = SMenu.Add("EnableSmiteEnemies", new KeyBind("Mavi Çarp KS Tuşu", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _smiteCombo = SMenu.Add("EnableSmiteCombo", new KeyBind("Kırmızı Çarp Kombosu Tuşu", false, KeyBind.BindTypes.PressToggle, 'M'));
                    _redSmitePercent = SMenu.Add("SmiteRedPercent", new Slider("Kırmızı Çarp İçin düşmanın canı %", 60));
                    SMenu.AddSeparator();
                    SMenu.AddGroupLabel("Çarp Kullanılabilecek Canavarlar");
                    SMenu.Add("SRU_Baron", new CheckBox("Baron"));
                    SMenu.Add("SRU_Dragon", new CheckBox("Ejder"));
                    SMenu.Add("SRU_Red", new CheckBox("Kırmızı"));
                    SMenu.Add("SRU_Blue", new CheckBox("Mavi"));
                    SMenu.Add("SRU_Gromp", new CheckBox("Kurbağa"));
                    SMenu.Add("SRU_Murkwolf", new CheckBox("AlacaKurt"));
                    SMenu.Add("SRU_Krug", new CheckBox("Golem"));
                    SMenu.Add("SRU_Razorbeak", new CheckBox("SivriGagalar"));
                    SMenu.Add("Sru_Crab", new CheckBox("Yampiri Yengeç"));
                    SMenu.Add("SRU_RiftHerald", new CheckBox("Baronun Kız Kardeşi", false));
                }

                public static void Initialize()
                {
                }

            }
        }
        public static class Draw
        {
            public static readonly Menu DMenu;
            static Draw()
            {

                DMenu = Config.Menu.AddSubMenu("Draw Menu");

                DrawMenu.Initialize();
            }
            public static void Initialize()
            {
            }

            public static class DrawMenu
            {
                public static readonly CheckBox _drawQ;
                public static readonly CheckBox _drawW;
                public static readonly CheckBox _drawE;
                public static readonly CheckBox _drawR;
                public static readonly CheckBox _drawSmite;

                public static Menu MainMenu
                {
                    get { return DMenu; }
                }


                public static bool DrawQ
                {
                    get { return _drawQ.CurrentValue; }
                }

                public static bool DrawW
                {
                    get { return _drawW.CurrentValue; }
                }

                public static bool DrawE
                {
                    get { return _drawE.CurrentValue; }
                }

                public static bool DrawR
                {
                    get { return _drawR.CurrentValue; }
                }

                public static bool DrawSmite
                {
                    get { return _drawSmite.CurrentValue; }
                }
                static DrawMenu()
                {
                    DMenu.AddGroupLabel("Gösterge");
                    DMenu.AddSeparator();
                    _drawQ = DMenu.Add("QDraw", new CheckBox("Göster Q"));
                    _drawW = DMenu.Add("WDraw", new CheckBox("Göster W"));
                    _drawE = DMenu.Add("EDraw", new CheckBox("Göster E"));
                    _drawR = DMenu.Add("RDraw", new CheckBox("Göster R"));
                    _drawSmite = DMenu.Add("SmiteDraw", new CheckBox("Göster Çarp"));
                }

                public static void Initialize()
                {
                }

            }
        }
    }
}
