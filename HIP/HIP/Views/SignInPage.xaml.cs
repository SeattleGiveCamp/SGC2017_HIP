using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HIP
{
    public partial class SignInPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AdditionalVolunteerPage((MobileAppService.Models.UserModel user) => viewModel.AddVolunteer(user)));
        }

        public SignInPage()
        {
            InitializeComponent();
			BindingContext = viewModel = new SignInViewModel();

		}

        private SignInViewModel viewModel;

    }
}
