using System;

using Xamarin.Forms;
using HIP.Models;
using HIP.ViewModels;
using HIP.Services;
namespace HIP
{
    public partial class EventDetailPage : ContentPage
    {
        EventDetailViewModel viewModel;

        public EventDetailPage(EventDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void AddToCalendar_Clicked(object sender, System.EventArgs e)
        {
            bool result = await CalendarService.AddReminderAsync(viewModel.Item.Event);
            if (result == true)
                await DisplayAlert("Success", "Event has been added to your calendar", "OK");
            else
                await DisplayAlert("Error", "Cannot add event", "OK");
        }

		void Signin_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
    }
}
