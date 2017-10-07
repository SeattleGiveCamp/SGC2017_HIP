using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIP.Views
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            var scrollview = new ScrollView();
            Content = scrollview;
            var layout = new StackLayout();
            scrollview.Content = layout;


            var logoImage = new Image
            {
                Source = "logo_x96.png"
            };

            var introWelcomeLabel = new Label
            {
                Text = "Welcome!",
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                
                
            };

            var introDetailsLabel = new Label
            {
                Text = "Thanks for volunteering! Please take a moment to give us some info. I promise, you'll only have to do this once!",
                FontSize = 15,
                HorizontalTextAlignment = TextAlignment.Center

            };

            var introDetails2Label = new Label
            {
                Text = "Bringing more people with you? You can set them up later!",
                FontSize = 12,
                TextColor = Color.DarkGray,
                HorizontalTextAlignment = TextAlignment.Center

            };

            var firstNameEntry = new Entry
            {
                Placeholder = "First Name",
                IsPassword = false
            };

            var lastNameEntry = new Entry
            {
                Placeholder = "Last Name",
                IsPassword = false
            };

            var emailEntry = new Entry
            {
                Placeholder = "Email",
                IsPassword = false
            };

            
            var doneButton = new Button
            {
                Text = "Done",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


            layout.Children.Add(logoImage);
            layout.Children.Add(introWelcomeLabel);
            layout.Children.Add(introDetailsLabel);
            layout.Children.Add(introDetails2Label);
            layout.Children.Add(firstNameEntry);
            layout.Children.Add(lastNameEntry);
            layout.Children.Add(emailEntry);
            layout.Children.Add(doneButton);
            layout.Spacing = 10;
        }
	}
}