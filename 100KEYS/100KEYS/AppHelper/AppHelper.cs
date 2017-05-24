using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KEYSAPP
{
    static class AppHelper
    {
        private static SoundEffect _soundEff;
    

        static AppHelper()
        {
            Navigation = 1;
            Input = Password = "";
            Storage = IsolatedStorageSettings.ApplicationSettings;

            ThemeDay = new ImageBrush();
            ThemeNight = new ImageBrush();

            ThemeDay.ImageSource = new BitmapImage(new Uri("/Assets/BLight.jpg", UriKind.Relative));
            ThemeNight.ImageSource = new BitmapImage(new Uri("/Assets/BDark.jpg", UriKind.Relative));

            _soundEff = SoundEffect.FromStream(TitleContainer.OpenStream("Sounds/snd_click.wav"));
            SoundClick = _soundEff.CreateInstance();

            _soundEff = SoundEffect.FromStream(TitleContainer.OpenStream("Sounds/snd_eff_click_false.wav"));
            SoundBadCode = _soundEff.CreateInstance();

            _soundEff = SoundEffect.FromStream(TitleContainer.OpenStream("Sounds/snd_eff_click_true.wav"));
            SoundGood = _soundEff.CreateInstance();

            MaxPasswordChars = 4;
        }

        public static IsolatedStorageSettings Storage { get; set; }


        /// <summary>
        /// Светлая тема
        /// </summary>
        public static ImageBrush ThemeDay { get; private set; }
        /// <summary>
        /// Темная тема
        /// </summary>
        public static ImageBrush ThemeNight { get; private set; }
        /// <summary>
        /// Длина кода
        /// </summary>
        public static int MaxPasswordChars { get; private set; }
        /// <summary>
        /// Текущая страница
        /// </summary>
        public static int Navigation { get; set; }


        public static SoundEffectInstance SoundClick { get; private set; }
        public static SoundEffectInstance SoundBadCode { get; private set; }
        public static SoundEffectInstance SoundGood { get; private set; }

        public static string Input { get; set; }

        public static string Password { get; set; }
    }

   

}
