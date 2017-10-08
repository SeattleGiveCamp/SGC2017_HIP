using HIP.Views;
using System;

using Xamarin.Forms;

namespace HIP
{
    public class MainPage : TabbedPage
    {
        // *****************************************************************************************************
        //NOTE: THIS PAGE IS NOT UTILIZED. SEE App.xaml.cs FOR LOGIC DETERMINING WHICH PAGE TO INITIALLY DISPLAY
        // *****************************************************************************************************
        public MainPage()
        {
            Page loginPage, upcomingPage, aboutPage = null;
            const string loginTitle = "Login";
            const string upcomingTitle = "Upcoming";
            const string aboutTitle = "About";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    loginPage = new NavigationPage(new LoginPage())
                    {
                        Title = loginTitle
                    };

                    upcomingPage = new NavigationPage(new UpcomingProgramsPage())
                    {
                        Title = upcomingTitle,
                        Icon = "tab_feed.png"                            
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = aboutTitle,
                        Icon = "tab_about.png"
                    };

                    break;

                default:
                    loginPage = new LoginPage()
                    {
                        Title = loginTitle
                    };

                    upcomingPage = new UpcomingProgramsPage()
                    {
                        Title = upcomingTitle
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = aboutTitle
                    };
                    break;
            }

            Children.Add(loginPage);
            Children.Add(upcomingPage);
            //Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
