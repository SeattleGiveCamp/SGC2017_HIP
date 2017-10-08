using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HIP
{
    public partial class SignInPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AdditionalVolunteerPage2((MobileAppService.Models.UserModel user) => viewModel.AddVolunteer(user)));
        }

        public SignInPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignInViewModel(Navigation);
            viewModel.AdditionalVolunteers.CollectionChanged += (sender, e) => UpdateListViewHeight();
		}

        private void UpdateListViewHeight()
        {
            ListView listView = AdditionalVolunteersListView;
            int requestedHeight = listView.RowHeight * viewModel.AdditionalVolunteers.Count;
            listView.HeightRequest = requestedHeight;
		}

		public void RemoveAdditionalVolunteer(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
            var vlivm = (VolunteerListItemViewModel)mi.CommandParameter;
            viewModel.AdditionalVolunteers.Remove(vlivm);
		}

        private SignInViewModel viewModel;

    }
}
