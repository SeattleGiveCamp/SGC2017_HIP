using HIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIP.Views
{
	public class FavoriteProgramsPage : ContentPage
	{
        struct favorite
        {
            public ProgramType programType;
            public Switch programSwitch;
        }
        List<favorite> favoriteList;
        List<string> knownFavorites;

        Label loadingDetailsLabel;

        public FavoriteProgramsPage()
		{
            if (Application.Current.Properties.ContainsKey("favorites"))
            {
                var favsWithNewlines = Application.Current.Properties["favorites"] as string;
                knownFavorites = favsWithNewlines.Split('\n').ToList();
            }
            else
            {
                knownFavorites = new List<string>();
            }

            loadElements();
        }

        void loadElements()
        {
            layoutLoadingElements();
            //TODO: Call loaded after retrevial or failure on fail

            populateFakeElements();
            layoutLoadedElements();
            //layoutLoadFailureElements();
        }


        //TODO: Remove this when hooked up
        void populateFakeElements()
        {
            favoriteList = new List<favorite>();
            for (int i = 0; i < 10; i++)
            {
                var fav = new favorite();
                fav.programType = new ProgramType("what: " + i.ToString());
                favoriteList.Add(fav);
            }
        }


        void layoutLoadingElements()
        {
            loadingDetailsLabel = new Label
            {
                Text = "Please wait just a moment...",
                FontSize = 15,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Content = loadingDetailsLabel;
        }

        void layoutLoadFailureElements()
        {
            loadingDetailsLabel.Text = "Something went wrong! Please check your internet connection and try again. (Sorry, we know that's a bad line.)";
        }

        void layoutLoadedElements()
        {
            var scrollview = new ScrollView();
            Content = scrollview;
            var layout = new StackLayout();
            scrollview.Content = layout;


            var introWelcomeLabel = new Label
            {
                Text = "Welcome!",
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            
            var introLabel = new Label
            {
                Text = "Please select any program types you're interested in. This will help us to let you know about upcoming events.",
                FontSize = 15,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            layout.Children.Add(introLabel);

            

            for (int i = 0; i < favoriteList.Count; i++)
            {
                var elementLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                var switch1 = new Switch
                {
                    HorizontalOptions = LayoutOptions.Center
                };
                var name = favoriteList[i].programType.Name;
                var fav = new favorite();
                fav.programType = new ProgramType(name);
                fav.programSwitch = switch1;
                favoriteList[i] = fav;
                var switchDescription = new Label
                {
                    Text = favoriteList[i].programType.Name,
                    FontSize = 15,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                elementLayout.Children.Add(switch1);
                elementLayout.Children.Add(switchDescription);

                switch1.IsToggled = knownFavorites.Contains(favoriteList[i].programType.Name);

                layout.Children.Add(elementLayout);
            }

            var doneButton = new Button
            {
                Text = "Save",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            doneButton.Clicked += OnDoneButtonClickedAsync;
            layout.Children.Add(doneButton);


            layout.Spacing = 10;
            layout.Padding = 10;
        }



        async void OnDoneButtonClickedAsync(object sender, EventArgs e)
        {
            var newFavs = new List<string>();

            foreach (favorite fav in favoriteList)
            {
                if (fav.programSwitch.IsToggled)
                {
                    newFavs.Add(fav.programType.Name);
                }
            }
            var joinedString = string.Join("\n", newFavs.ToArray());
            Application.Current.Properties["favorites"] = joinedString;
            await Application.Current.SavePropertiesAsync();

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
                App.Current.MainPage = new UpcomingProgramsPage();
            else
                App.Current.MainPage = new NavigationPage(new UpcomingProgramsPage());
        }





        public async Task<int> DownloadHomepage()
        {
            var httpClient = new HttpClient(); // Xamarin supports HttpClient!

            Task<string> contentsTask = httpClient.GetStringAsync("http://xamarin.com"); // async method!

            // await! control returns to the caller and the task continues to run on another thread
            string contents = await contentsTask;
            /*
            lastNameEntry.Text = "DownloadHomepage method continues after async call. . . . .\n";

            // After contentTask completes, you can calculate the length of the string.
            int exampleInt = contents.Length;

            lastNameEntry.Text = "Downloaded the html and found out the length.\n\n\n";

            lastNameEntry.Text = contents; // just dump the entire HTML
            lastNameEntry.IsVisible = false;




            var modalPage = new FavoriteProgramsPage();
            await Navigation.PushModalAsync(modalPage);
            Debug.WriteLine("The modal page is now on screen");
            //var poppedPage = await Navigation.PopModalAsync();
            Debug.WriteLine("The modal page is dismissed");
            //Debug.WriteLine(Object.ReferenceEquals(modalPage, poppedPage)); //prints "true"

    */

            return 1;// exampleInt; // Task<TResult> returns an object of type TResult, in this case int
        }
    }
}