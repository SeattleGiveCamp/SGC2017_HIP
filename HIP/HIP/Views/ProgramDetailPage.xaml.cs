using System;

using Xamarin.Forms;
using HIP.Models;
using HIP.Services;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace HIP
{
    public partial class ProgramDetailPage : ContentPage
    {
        ProgramDetailViewModel viewModel;

        public ProgramDetailPage(ProgramDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new ProgramDetailViewModel(viewModel.Item);
            calendarPicker.SelectedIndexChanged += (sender, e) =>
            {
                calendarPicker.IsVisible = false;
                doAddEvent();
            };
            calendarPicker.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUpdateMode(UpdateMode.WhenFinished);
        }

        void AddToCalendar_Clicked(object sender, System.EventArgs e)
        {
            if (viewModel.SelectedCalendar == null)
                calendarPicker.Focus();
            else
                doAddEvent();
        }

        async void doAddEvent()
        {
            if (viewModel.SelectedCalendar == null)
                return;
            
            bool result = await CalendarService.AddReminderAsync(viewModel.SelectedCalendar, viewModel.Item);
            if (result == true)
                await DisplayAlert("Success", "Event has been added to your calendar", "OK");
            else
            {
                if (viewModel.SelectedCalendar != null)
                {
                    viewModel.SelectedCalendar = null;
                    await DisplayAlert("Error", "Select another calendar", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Cannot add event", "OK");
                }
            }
		}

        async void Signin_Clicked(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new SignInPage());
			//await Navigation.PushAsync(new AdditionalVolunteerPage((user) => DisplayAlert("User added", user.FirstName, "OK")));
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if (viewModel.UserCalendars.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
    }
}
