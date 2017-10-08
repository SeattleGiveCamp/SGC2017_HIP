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
		public FavoriteProgramsPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin Forms!" }
				}
			};
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