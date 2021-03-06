﻿using System;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace AddonTemplate
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Aka´s Sion";
                public static Activator activator;
        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Hoşgeldin Sion Addon Umarım eğlenirsin! :)");
            Menu.AddLabel("Ayarları göreceksin");
            Menu.AddLabel("Modlara tıkla :)");
            //activator = new Activator(Menu);
            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                Menu.AddSeparator();
                Flee.Initialize();
                Menu.AddSeparator();
                LaneClear.Initialize();
                Menu.AddSeparator();
                JungleClear.Initialize();
                Menu.AddSeparator();
                MiscMenu.Initialize();
                Menu.AddSeparator();
                Drawing.Initialize();
                Menu.AddSeparator();

            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
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
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Kullan W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Kullan E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Kullan R(Bozuk)", false));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {

                private static readonly CheckBox _UseQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _UseQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Dürtme");
                   _UseQ = Menu.Add("UseQHarrass", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("UseWHarass", new CheckBox("Kullan W"));
                    _useE = Menu.Add("UseEHarass", new CheckBox("Kullan E"));
                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    _Mana = Menu.Add("ManaHarass", new Slider("En az mana ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;


                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }


                static Flee()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Kaçma(flee)");
                    _useW = Menu.Add("FleeUseW", new CheckBox("Kullan W"));
                    _useE = Menu.Add("FleeUseE", new CheckBox("Kullan E"));
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

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

                static JungleClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("OrmanTemizleme");
                    _useQ = Menu.Add("JCQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("JCW", new CheckBox("Kullan W"));
                    _useE = Menu.Add("JCE", new CheckBox("Kullan E"));
                }

                public static void Initialize()
                {
                }
            }


            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }


                static LaneClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Lanetemizleme");
                    _useQ = Menu.Add("LCQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("LCW", new CheckBox("Kullan W"));
                }

                public static void Initialize()
                {
                }
            }

            public class MiscMenu
            {
                private static readonly CheckBox _InterruptQ;
                private static readonly CheckBox _KSQ;
                private static readonly CheckBox _KSW;
                private static readonly CheckBox _KSR;
                private static readonly CheckBox _KSE;

                public static bool InterruptQ
                {
                    get { return _InterruptQ.CurrentValue; }
                }

                public static bool KSQ
                {
                    get { return _KSQ.CurrentValue; }
                }

                public static bool KSR
                {
                    get { return _KSR.CurrentValue; }
                }

                public static bool KSW
                {
                    get { return _KSW.CurrentValue; }
                }
                public static bool KSE
                {
                    get { return _KSE.CurrentValue; }
                }
                static MiscMenu()
                {

                    Menu.AddGroupLabel("Ek/Kill Çalma");
                    _KSQ = Menu.Add("KSQ", new CheckBox("Ks Q"));
                    _KSW = Menu.Add("KSW", new CheckBox("Ks W"));
                    _KSE = Menu.Add("KSE", new CheckBox("Ks E"));
                    _KSR = Menu.Add("KSR", new CheckBox("Ks R(Bozuk!)", false));
                    _InterruptQ = Menu.Add("InterruptQ", new CheckBox("İnterrupt büyülere Q?"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Drawing
                {
                    private static readonly CheckBox _useQ;
                    private static readonly CheckBox _useW;
                    private static readonly CheckBox _useE;
                    private static readonly CheckBox _DrawonlyReady;

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


                public static bool DrawOnlyReady
                {
                    get { return _DrawonlyReady.CurrentValue; }
                }

                static Drawing()
                    {
                        // Initialize the menu values
                        Menu.AddGroupLabel("Göstergeler?");
                        _useQ = Menu.Add("DrawQ", new CheckBox("Göster Q"));
                        _useW = Menu.Add("DrawW", new CheckBox("Göster W"));
                        _useE = Menu.Add("DrawE", new CheckBox("Göster E"));
                        _DrawonlyReady = Menu.Add("DrawOnlyReady", new CheckBox("Sadece büyü hazırsa göster"));
                }

                    public static void Initialize()
                    {
                    }
                }

            }
        }
    }

            
        
    

