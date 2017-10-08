
using HIP.Helpers;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;

using Xamarin.Forms;
namespace HIP
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://hipmobileappservice.azurewebsites.net";

        public App()
        {
            InitializeComponent();

            MobileCenter.Start($"android={Constants.MobileCenterAndroid};" +
                   $"uwp={Constants.MobileCenterUWP};" +
                   $"ios={Constants.MobileCenteriOS}",
                   typeof(Analytics), typeof(Crashes));


            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            //Only show the settings screen initially if the user has not previously provided an email
            if (Application.Current.Properties != null && Application.Current.Properties.ContainsKey("email"))
            {
                MainPage = new NavigationPage(new UpcomingProgramsPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
