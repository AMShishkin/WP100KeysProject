using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;
using System.Windows;
using System.Windows.Navigation;
using System;
using Windows.ApplicationModel.Store;
using Store = Windows.ApplicationModel.Store;

namespace KEYSAPP.Pages
{
    public partial class InfoPage : PhoneApplicationPage
    {
        private bool _isSound;

        public InfoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Стартовая анимация
            AIPStart.Begin();
            // Цвет темы
            if ((bool)AppHelper.Storage["THEME"]) LayoutRoot.Background = AppHelper.ThemeDay;
            else LayoutRoot.Background = AppHelper.ThemeNight;
            // Показываем кол-во доступных ключей
            Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
            // Звук
            _isSound = (bool)AppHelper.Storage["SOUND"];

            if (!(bool)AppHelper.Storage["RATE"]) ButRate.Content = "+10 Keys >> Rate";
            else ButRate.Content = "Rate";

            if (!(bool)AppHelper.Storage["SHOW_MY_APPS"]) ButOtherApps.Content = "+5 Keys >> My Apps";
            else ButOtherApps.Content = "My Apps";
        }

        // Купить 100 ключей
        private async void But100Keys_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundGood.Play();
            }

            if (!Store.CurrentApp.LicenseInformation.ProductLicenses["5f446e6a_27f3_485e_bda7_629f6197fab3"].IsActive)
            {
                try
                {

                    await CurrentApp.RequestProductPurchaseAsync("5f446e6a_27f3_485e_bda7_629f6197fab3", false);
                    ProductLicense productLicense = null;
                    if (CurrentApp.LicenseInformation.ProductLicenses.TryGetValue("5f446e6a_27f3_485e_bda7_629f6197fab3", out productLicense))
                    {
                        if (productLicense.IsActive)
                        {
                             AppHelper.Storage["KEYS"] = 100 + (int)AppHelper.Storage["KEYS"];
                             Keys.Text = "KEYS: " + AppHelper.Storage["KEYS"];
                             AppHelper.Storage.Save();

                             MessageBoxResult result = MessageBox.Show("Congratulations, you got 100 keys ;).", "+100 Keys!", MessageBoxButton.OK);
                            // Сообщаем Магазину, о том что продукт доставлен
                             CurrentApp.ReportProductFulfillment("5f446e6a_27f3_485e_bda7_629f6197fab3");
                            return;
                        }
                    }
                }
                catch { }
            }



         


        }
        // Оценить
        private void ButRate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if (!(bool)AppHelper.Storage["RATE"]) AppHelper.Storage["KEYS"] = 10 + (int)AppHelper.Storage["KEYS"];
            AppHelper.Storage["RATE"] = true;
            AppHelper.Storage.Save();

            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
        // Посмотреть мои приложения
        private void ButOtherApps_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            if (!(bool)AppHelper.Storage["SHOW_MY_APPS"]) AppHelper.Storage["KEYS"] = 5 + (int)AppHelper.Storage["KEYS"];
            AppHelper.Storage["SHOW_MY_APPS"] = true;
            AppHelper.Storage.Save();

            MarketplaceSearchTask marketplaceSearchTaskAll = new MarketplaceSearchTask { SearchTerms = "AMShishkin" };
            marketplaceSearchTaskAll.Show();
        }
        // Написать мне
        private void ButContct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_isSound)
            {
                FrameworkDispatcher.Update();
                AppHelper.SoundClick.Play();
            }

            EmailComposeTask emailComposeTask = new EmailComposeTask { Subject = "100KEYS", To = "AMShishkin.vrn@gmail.com" };
            emailComposeTask.Show();
        }
    }
}