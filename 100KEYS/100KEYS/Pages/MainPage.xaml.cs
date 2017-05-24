using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace KEYSAPP
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool _isSound;

        public MainPage()
        {
            InitializeComponent();

            // Кол-во запусков приложения
            if (!AppHelper.Storage.Contains("START_PAGE_COUNT")) AppHelper.Storage.Add("START_PAGE_COUNT", 1);
            // Оценка
            if (!AppHelper.Storage.Contains("RATE")) AppHelper.Storage.Add("RATE", false);
            // Просмотр моих приложений
            if (!AppHelper.Storage.Contains("SHOW_MY_APPS")) AppHelper.Storage.Add("SHOW_MY_APPS", false);
            // Прогресс
            if (!AppHelper.Storage.Contains("LAST_NAVIGATION_INDEX")) AppHelper.Storage.Add("LAST_NAVIGATION_INDEX", 1);
            // Звук
            if (!AppHelper.Storage.Contains("SOUND")) AppHelper.Storage.Add("SOUND", false);
            // Доступные ключи
            if (!AppHelper.Storage.Contains("KEYS")) AppHelper.Storage.Add("KEYS", 40);
            // Тема
            if (!AppHelper.Storage.Contains("THEME")) AppHelper.Storage.Add("THEME", true);

            AppHelper.Storage.Save();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Звук
            _isSound = (bool)AppHelper.Storage["SOUND"];
            // Стартовая анимация
            AMPStart.Begin();





            if ((bool)AppHelper.Storage["THEME"])
            {
                LayoutRoot.Background = AppHelper.ThemeDay;
                ButThem.Content = "DAY";
            }
            else
            {
                LayoutRoot.Background = AppHelper.ThemeNight;
                ButThem.Content = "NIGHT";
            }


            if ((bool)AppHelper.Storage["SOUND"]) ButSound.Content = "SOUND";
            else ButSound.Content = "SILENCE";






            // Показываем кол-во доступных ключей
            Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
        }


        // Кнопка INFO
        private void ButInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            NavigationService.Navigate(new Uri("/Pages/InfoPage.xaml", UriKind.Relative));
        }
        // Кнопка PLAY
        private void ButPlay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            NavigationService.Navigate(new Uri("/Pages/SetPage.xaml", UriKind.Relative));
        }
        // Кнопка THEME
        private void ButThem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if ((bool)AppHelper.Storage["THEME"])
            {
                AppHelper.Storage["THEME"] = false;
                LayoutRoot.Background = AppHelper.ThemeNight;
                ButThem.Content = "NIGHT";
            }
            else
            {
                AppHelper.Storage["THEME"] = true;
                LayoutRoot.Background = AppHelper.ThemeDay;
                ButThem.Content = "DAY";
            }

            AppHelper.Storage.Save();
        }
        // Кнопка SOUND
        private void ButSound_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
             FrameworkDispatcher.Update();
             AppHelper.SoundClick.Play();
            

            if ((bool)AppHelper.Storage["SOUND"])
            {
                AppHelper.Storage["SOUND"] = _isSound = false;
                ButSound.Content = "SILENCE";
            }
            else
            {
                AppHelper.Storage["SOUND"] = _isSound = true;
                ButSound.Content = "SOUND";
            }
        }
    }
}