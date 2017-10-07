using HIP.Views;
using System;

using Xamarin.Forms;

namespace HIP
{
    public class MainPage : TabbedPage
    {
        //The goal should be to replace this MainPage. 
        //But for the start, let's use this as a simple launch screen to get to our different views
        public MainPage()
        {
            Page loginPage, itemsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    loginPage = new NavigationPage(new LoginPage())
                    {
                        Title = "Login"
                    };

                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    loginPage = new LoginPage()
                    {
                        Title = "Login"
                    };

                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(loginPage);
            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
