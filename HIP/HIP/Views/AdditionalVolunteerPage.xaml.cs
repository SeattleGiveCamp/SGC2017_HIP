using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using HIP.ViewModels;
using Xamarin.Forms;

namespace HIP
{
	public partial class AdditionalVolunteerPage : ContentPage
	{
		void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			FirstNameView.IsVisible = !e.Value;
			LastNameView.IsVisible = !e.Value;
			EmailNameView.IsVisible = !e.Value;
		}

		public AdditionalVolunteerPage(Action<UserModel> returnUserCallback)
		{
			InitializeComponent();
			BindingContext = viewModel = new AdditionalVolunteerViewModel();
			this.returnUserCallback = returnUserCallback;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			UserModel user;
			if (!viewModel.IsChild)
				user = new UserModel(viewModel.EmailName, viewModel.FirstName, viewModel.LastName);
			else
			{
				user = new UserModel("");
				user.IsMinor = true;
			}

			returnUserCallback.Invoke(user);
			await Navigation.PopAsync();
		}

		private Action<UserModel> returnUserCallback;
		private AdditionalVolunteerViewModel viewModel;
	}
}
