using HIP.MobileAppService.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIP.Views
{
	public class LoginPage : ContentPage
	{
        Entry firstNameEntry, lastNameEntry, emailEntry;
        bool isFirstTime;

        UserModel user;
        
        public LoginPage()
		{
            isFirstTime = true;
            layoutElements();
        }

        public LoginPage(UserModel user)
        {
            isFirstTime = false;
            this.user = user;
            layoutElements();
        }


        void layoutElements()
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

            firstNameEntry = new Entry
            {
                Placeholder = "First Name",
                IsPassword = false
            };

            lastNameEntry = new Entry
            {
                Placeholder = "Last Name",
                IsPassword = false
            };

            emailEntry = new Entry
            {
                Placeholder = "Email",
                IsPassword = false
            };


            if (!isFirstTime)
            {
                introWelcomeLabel.Text = "Settings";
                introDetailsLabel.Text = "Update your personal information if needed.";
                introDetails2Label.IsVisible = false;

                emailEntry.Text = user.Email;
                if (!string.IsNullOrWhiteSpace(user.FirstName))
                {
                    firstNameEntry.Text = user.FirstName;
                }
                if (!string.IsNullOrWhiteSpace(user.LastName))
                {
                    lastNameEntry.Text = user.LastName;
                }
            }

            var doneButton = new Button
            {
                Text = "Next",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            doneButton.Clicked += OnDoneButtonClicked;


            layout.Children.Add(introWelcomeLabel);
            layout.Children.Add(introDetailsLabel);
            layout.Children.Add(introDetails2Label);
            layout.Children.Add(firstNameEntry);
            layout.Children.Add(lastNameEntry);
            layout.Children.Add(emailEntry);
            layout.Children.Add(doneButton);
            layout.Spacing = 10;
        }

        void OnDoneButtonClicked(object sender, EventArgs e)
        {
            string firstName;
            if (firstNameEntry == null || string.IsNullOrWhiteSpace(firstNameEntry.Text))
            {
                firstName = "";
            } else
            {
                firstName = firstNameEntry.Text;
            }

            string lastName;
            if (lastNameEntry == null || string.IsNullOrWhiteSpace(lastNameEntry.Text))
            {
                lastName = "";
            }
            else
            {
                lastName = lastNameEntry.Text;
            }

            string email;
            if (emailEntry == null || string.IsNullOrWhiteSpace(emailEntry.Text))
            {
                flashRequiredField(emailEntry);
                return;
            }
            else
            {
                email = emailEntry.Text;
            }


            OpenFavorites();

        }

        public async Task<int> OpenFavorites()
        {
            var modalPage = new FavoriteProgramsPage();
            await Navigation.PushModalAsync(modalPage);
            return 0;
        }


        void flashRequiredField(InputView inputView)
        {
            var whiteToRed = false;
            inputView.Animate(
                "colorchange",
                x =>
                {
                    if (whiteToRed)
                    {
                        x = 1 - x;
                    }
                    var red = (int)(254 * x);
                    var amount = (double)(red) / 254.0;
                    var white = 254 * (1 - amount);

                    byte r = (byte)((red * amount) + white);
                    byte g = (byte)((0) + white);
                    byte b = (byte)((0) + white);

                    inputView.BackgroundColor = Color.FromRgb(r, g, b);
                },
                length: 500,
                finished: delegate (double d, bool b)
                {
                    if (!whiteToRed)
                        inputView.BackgroundColor = Color.FromRgb(255, 0, 0);
                    else
                        inputView.BackgroundColor = Color.FromRgb(255, 255, 255);
                },
                repeat: () =>
                {
                    whiteToRed = !whiteToRed;
                    return false;
                }
            );
        }


    }
}