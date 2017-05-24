using KEYSAPP.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Windows.ApplicationModel.Store;
using Store = Windows.ApplicationModel.Store;

namespace KEYSAPP.Pages
{
    public partial class GamePage : PhoneApplicationPage
    {
        private BitmapImage _bitmapImage;
    
        private bool _isSound;

        public GamePage()
        {
            InitializeComponent();

            _bitmapImage = new BitmapImage();

            AGPBadCode.Completed += AGPBadCode_Completed;
            
        }

        void AGPBadCode_Completed(object sender, EventArgs e)
        {
            AppHelper.Input = TBPass.Text = "";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Цвет темы
            if ((bool)AppHelper.Storage["THEME"]) LayoutRoot.Background = AppHelper.ThemeDay;
            else LayoutRoot.Background = AppHelper.ThemeNight;
            // Звук
            _isSound = (bool)AppHelper.Storage["SOUND"];
            // Реклама
            AdDuplex.AdDuplexTrackingSDK.StartTracking("133535");
            // Показываем кол-во доступных ключей
            Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
            // Номер текущего адания
            TBIndex.Text = "#" + AppHelper.Navigation;
            // Пароль от текущего задания
            AppHelper.Password = KeysDB.ResourceManager.GetString("KEY" + AppHelper.Navigation);
            // Кантинка с кодом
            _bitmapImage.UriSource = new Uri("/Resources/KEY" + AppHelper.Navigation + ".jpg", UriKind.Relative);
            Pic.Source = _bitmapImage;
            // Очищаем поля
            if (AppHelper.Navigation < (int)AppHelper.Storage["LAST_NAVIGATION_INDEX"]) TBPass.Text = AppHelper.Input = AppHelper.Password;
            else TBPass.Text = AppHelper.Input = "";
            // Подсказка
            this.PasswordCoount();



            if ((int)AppHelper.Storage["START_PAGE_COUNT"] > 1 && !(bool)AppHelper.Storage["RATE"])
            {
                MessageBoxResult mBoxResult = MessageBox.Show("Rate the app 5 stars and leave a review!", "Get 10 keys?", MessageBoxButton.OKCancel);
                if (mBoxResult == MessageBoxResult.OK)
                {
                    if (!(bool)AppHelper.Storage["RATE"]) AppHelper.Storage["KEYS"] = 10 + (int)AppHelper.Storage["KEYS"];
                    AppHelper.Storage["RATE"] = true;
                    AppHelper.Storage.Save();

                    MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            TBPass.Text = AppHelper.Input = "";
        }









        private void Pic_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BigPic.Visibility = System.Windows.Visibility.Visible;
            BigPic.Source = _bitmapImage;
        }
        private void BigPic_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            BigPic.Visibility = System.Windows.Visibility.Collapsed;
        }



        private void ButKey_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult _result;

            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if ((int)AppHelper.Storage["KEYS"] > 0)
            {
                _result = MessageBox.Show("Use the key? KEYS: " + AppHelper.Storage["KEYS"], "GET PASSWORD", MessageBoxButton.OKCancel);

             
         
            }
            else
            {
               _result = MessageBox.Show("Get more keys? ", "Ooops! No keys :(", MessageBoxButton.OKCancel);
            
            }

            if (_result == MessageBoxResult.OK)
            {
                if ((int)AppHelper.Storage["KEYS"] > 0)
                {
                    AppHelper.Storage["KEYS"] = (int)AppHelper.Storage["KEYS"] - 1;
                    Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
                    TBPass.Text = AppHelper.Input = AppHelper.Password;
                }
                else this.MoreKeys();
            }
        }

        private void ButDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if (AppHelper.Input.Length > 0) TBPass.Text = AppHelper.Input = AppHelper.Input.Substring(0, AppHelper.Input.Length - 1);
        }

        private void ButKey1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(1);
        }
        private void ButKey2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(2);
        }
        private void ButKey3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(3);
        }
        private void ButKey4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(4);
        }
        private void ButKey5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.Input(5);
        }
        private void ButKey6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(6);
        }
        private void ButKey7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(7);
        }
        private void ButKey8_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(8);
        }
        private void ButKey9_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(9);
        }
        private void ButKey0_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Input(0);
        }

        private void ButEnter_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AppHelper.Input == AppHelper.Password)
            {
                if (AppHelper.Navigation + 1 < 101)
                {

                    if (_isSound)
                    {
                        FrameworkDispatcher.Update();
                        AppHelper.SoundGood.Play();
                    }




                    AppHelper.Navigation++;

                    // Запоминаем прогресс
                    if (AppHelper.Navigation >= (int)AppHelper.Storage["LAST_NAVIGATION_INDEX"]) AppHelper.Storage["LAST_NAVIGATION_INDEX"] = AppHelper.Navigation;


                    this.Next();

                    // Подсказка
                    this.PasswordCoount();
                }
                else
                {
                    if (_isSound)
                    {
                        FrameworkDispatcher.Update();
                        AppHelper.SoundGood.Play();
                    }

                    AGPGood.Begin();
                    AppHelper.Storage["LAST_NAVIGATION_INDEX"] = AppHelper.Navigation = 101;

                    
                   
                }
            }
            else
            {
                AGPBadCode.Begin();

                if (_isSound)
                {
                    FrameworkDispatcher.Update();
                    AppHelper.SoundBadCode.Play();
                }
            }

            AppHelper.Storage.Save();

        }




        private void PasswordCoount()
        {
            if (AppHelper.Password.Length == 0) TBPassCount.Text = "";
            else if (AppHelper.Password.Length == 1) TBPassCount.Text = "*";
            else if (AppHelper.Password.Length == 2) TBPassCount.Text = "**";
            else if (AppHelper.Password.Length == 3) TBPassCount.Text = "***";
            else if (AppHelper.Password.Length == 4) TBPassCount.Text = "****";
        }


        private async void MoreKeys()
        {
            if (!Store.CurrentApp.LicenseInformation.ProductLicenses["AddKeys"].IsActive)
            {
                try
                {

                    await CurrentApp.RequestProductPurchaseAsync("AddKeys", false);
                    ProductLicense productLicense = null;
                    if (CurrentApp.LicenseInformation.ProductLicenses.TryGetValue("AddKeys", out productLicense))
                    {
                        if (productLicense.IsActive)
                        {
                            AppHelper.Storage["KEYS"] = 100 + (int)AppHelper.Storage["KEYS"];
                            Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
                            AppHelper.Storage.Save();

                            MessageBoxResult result = MessageBox.Show("Congratulations, you got 100 keys ;).", "+100 Keys!", MessageBoxButton.OK);
                            // Сообщаем Магазину, о том что продукт доставлен
                            CurrentApp.ReportProductFulfillment("AddKeys");
                            return;
                        }
                    }
                }
                catch { }

            }
        }

        private void Next()
        {
            TBIndex.Text = "#" + AppHelper.Navigation;
            // Получили пароль от текущего задания
            AppHelper.Password = KeysDB.ResourceManager.GetString("KEY" + AppHelper.Navigation);

            if (AppHelper.Navigation < (int)AppHelper.Storage["LAST_NAVIGATION_INDEX"]) TBPass.Text = AppHelper.Input = AppHelper.Password;
            else TBPass.Text = AppHelper.Input = "";

            _bitmapImage.UriSource = new Uri("/Resources/KEY" + AppHelper.Navigation + ".jpg", UriKind.Relative);
            Pic.Source = _bitmapImage;

           

            AGPGood.Begin();
        }

        private void Input(byte value)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if (AppHelper.Input.Length < AppHelper.MaxPasswordChars) AppHelper.Input += value;

            TBPass.Text = AppHelper.Input;

           // InputAnimation.Begin();

        }

    }
}