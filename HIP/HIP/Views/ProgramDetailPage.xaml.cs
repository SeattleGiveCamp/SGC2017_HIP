using System;

using Xamarin.Forms;
using HIP.Models;
using HIP.ViewModels;
using HIP.Services;
namespace HIP
{
    public partial class ProgramDetailPage : ContentPage
    {
        ProgramDetailViewModel viewModel;

        public ProgramDetailPage(ProgramDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new ProgramDetailViewModel(viewModel.Item);
        }

        async void AddToCalendar_Clicked(object sender, System.EventArgs e)
        {
            bool result = await CalendarService.AddReminderAsync(viewModel.Item);
            if (result == true)
                await DisplayAlert("Success", "Event has been added to your calendar", "OK");
            else
                await DisplayAlert("Error", "Cannot add event", "OK");
        }

        async void Signin_Clicked(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new SignInPage());
        }
    }
}
