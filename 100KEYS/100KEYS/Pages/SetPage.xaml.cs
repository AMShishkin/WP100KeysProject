using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace KEYSAPP.Pages
{
    public partial class SetPage : PhoneApplicationPage
    {
        private  Button[] buttons;

        private SolidColorBrush openColor, closedColor;
        private bool _isSound;



        public SetPage()
        {
            InitializeComponent();

            openColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 210, 210, 210));
            closedColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(30, 140, 140, 140));


            buttons = new Button[100];



            // Сезон 1
            buttons[0] = But1; buttons[1] = But2; buttons[2] = But3; buttons[3] = But4; buttons[4] = But5;
            buttons[5] = But6; buttons[6] = But7; buttons[7] = But8; buttons[8] = But9; buttons[9] = But10;
            buttons[10] = But11; buttons[11] = But12; buttons[12] = But13; buttons[13] = But14; buttons[14] = But15;
            buttons[15] = But16; buttons[16] = But17; buttons[17] = But18; buttons[18] = But19; buttons[19] = But20;
            buttons[20] = But21; buttons[21] = But22; buttons[22] = But23; buttons[23] = But24; buttons[24] = But25;
            // Сезон 2
            buttons[25] = But26; buttons[26] = But27; buttons[27] = But28; buttons[28] = But29; buttons[29] = But30;
            buttons[30] = But31; buttons[31] = But32; buttons[32] = But33; buttons[33] = But34; buttons[34] = But35;
            buttons[35] = But36; buttons[36] = But37; buttons[37] = But38; buttons[38] = But39; buttons[39] = But40;
            buttons[40] = But41; buttons[41] = But42; buttons[42] = But43; buttons[43] = But44; buttons[44] = But45;
            buttons[45] = But46; buttons[46] = But47; buttons[47] = But48; buttons[48] = But49; buttons[49] = But50;
            // Сезон 3
            buttons[50] = But51; buttons[51] = But52; buttons[52] = But53; buttons[53] = But54; buttons[54] = But55;
            buttons[55] = But56; buttons[56] = But57; buttons[57] = But58; buttons[58] = But59; buttons[59] = But60;
            buttons[60] = But61; buttons[61] = But62; buttons[62] = But63; buttons[63] = But64; buttons[64] = But65;
            buttons[65] = But66; buttons[66] = But67; buttons[67] = But68; buttons[68] = But69; buttons[69] = But70;
            buttons[70] = But71; buttons[71] = But72; buttons[72] = But73; buttons[73] = But74; buttons[74] = But75;
            // Сезон 4
            buttons[75] = But76; buttons[76] = But77; buttons[77] = But78; buttons[78] = But79; buttons[79] = But80;
            buttons[80] = But81; buttons[81] = But82; buttons[82] = But83; buttons[83] = But84; buttons[84] = But85;
            buttons[85] = But86; buttons[86] = But87; buttons[87] = But88; buttons[88] = But89; buttons[89] = But90;
            buttons[90] = But91; buttons[91] = But92; buttons[92] = But93; buttons[93] = But94; buttons[94] = But95;
            buttons[95] = But96; buttons[96] = But97; buttons[97] = But98; buttons[98] = But99; buttons[99] = But100;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int _lastIndex;

            // Цвет темы
            if ((bool)AppHelper.Storage["THEME"]) LayoutRoot.Background = AppHelper.ThemeDay;
            else LayoutRoot.Background = AppHelper.ThemeNight;
            // Звук
            _isSound = (bool)AppHelper.Storage["SOUND"];
            // Показываем кол-во доступных ключей
            Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];

            _lastIndex = (int)AppHelper.Storage["LAST_NAVIGATION_INDEX"];


            for (var i = 0; i < buttons.Length; i++)
            {
                if (i > _lastIndex - 1) buttons[i].Background = closedColor;
                else buttons[i].Background = openColor;
            }

            if (_lastIndex >= 1 && _lastIndex <= 25) MainPivot.SelectedIndex = 0;
            else if (_lastIndex >= 26 && _lastIndex <= 50) MainPivot.SelectedIndex = 1;
            else if (_lastIndex >= 51 && _lastIndex <= 75) MainPivot.SelectedIndex = 2;
            else if (_lastIndex >= 76 && _lastIndex <= 100) MainPivot.SelectedIndex = 3;
        }


        private void Navigation(int value)
        {
            

            if (value <= (int)AppHelper.Storage["LAST_NAVIGATION_INDEX"])
            {
                if (_isSound)
                {
                    FrameworkDispatcher.Update();
                    AppHelper.SoundClick.Play();
                }

                AppHelper.Navigation = value;
                NavigationService.Navigate(new Uri("/Pages/GamePage.xaml", UriKind.Relative));
            }
        }



        #region Кнопки 1-25
        private void But1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(1);
        }
        private void But2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(2);
        }
        private void But3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(3);
        }
        private void But4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(4);
        }
        private void But5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(5);
        }
        private void But6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(6);
        }
        private void But7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(7);
        }
        private void But8_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(8);
        }
        private void But9_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(9);
        }
        private void But10_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(10);
        }
        private void But11_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(11);
        }
        private void But12_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(12);
        }
        private void But13_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(13);
        }
        private void But14_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(14);
        }
        private void But15_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(15);
        }
        private void But16_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(16);
        }
        private void But17_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(17);
        }
        private void But18_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(18);
        }
        private void But19_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Navigation(19);
        }
        private void But20_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(20);
        }
        private void But21_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(21);
        }
        private void But22_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(22);
        }
        private void But23_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(23);
        }
        private void But24_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(24);
        }
        private void But25_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(25);
        }
        #endregion

        #region Кнопки 26-50
        private void But26_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(26);
        }
        private void But27_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(27);
        }
        private void But28_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(28);
        }
        private void But29_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(29);
        }
        private void But30_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(30);
        }
        private void But31_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(31);
        }
        private void But32_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(32);
        }
        private void But33_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(33);
        }
        private void But34_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(34);
        }
        private void But35_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(35);
        }
        private void But36_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(36);
        }
        private void But37_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(37);
        }
        private void But38_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(38);
        }
        private void But39_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(39);
        }
        private void But40_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(40);
        }
        private void But41_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(41);
        }
        private void But42_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(42);
        }
        private void But43_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(43);
        }
        private void But44_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(44);
        }
        private void But45_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(45);
        }
        private void But46_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(46);
        }
        private void But47_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(47);
        }
        private void But48_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(48);
        }
        private void But49_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(49);
        }
        private void But50_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(50);
        } 
        #endregion

        #region Кнопки 51-75
        private void But51_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(51);
        }
		private void But52_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(52);
		  }
		private void But53_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(53);
		  }
		private void But54_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(54);
		  }
		private void But55_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(55);
		  }
		private void But56_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(56);
		  }
		private void But57_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(57);
		  }
		private void But58_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(58);
		  }
		private void But59_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(59);
		  }
		private void But60_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(60);
		  }
		private void But61_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(61);
		  }
		private void But62_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(62);
		  }
		private void But63_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(63);
		  }
		private void But64_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(64);
		  }
		private void But65_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(65);
		  }
		private void But66_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(66);
		  }
		private void But67_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(67);
		  }
		private void But68_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(68);
		  }
		private void But69_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(69);
		  }
		private void But70_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(70);
		  }
		private void But71_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(71);
		  }
		private void But72_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(72);
		  }
		private void But73_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(73);
		  }
		private void But74_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(74);
		  }
		private void But75_Click(object sender, System.Windows.RoutedEventArgs e)
		  {
              this.Navigation(75);
          }
        #endregion

        #region Кнопки 76-100
        private void But76_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(76);
        }
        private void But77_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(77);
        }
        private void But78_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(78);
        }
        private void But79_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(79);
        }
        private void But80_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(80);
        }
        private void But81_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(81);
        }
        private void But82_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(82);
        }
        private void But83_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(83);
        }
        private void But84_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(84);
        }
        private void But85_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(85);
        }
        private void But86_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(86);
        }
        private void But87_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(87);
        }
        private void But88_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(88);
        }
        private void But89_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(89);
        }
        private void But90_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(90);
        }
        private void But91_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(91);
        }
        private void But92_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(92);
        }
        private void But93_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(93);
        }
        private void But94_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(94);
        }
        private void But95_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(95);
        }
        private void But96_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(96);
        }
        private void But97_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(97);
        }
        private void But98_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(98);
        }
        private void But99_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(99);
        }
        private void But100_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigation(100);
        }
        #endregion

    }
}