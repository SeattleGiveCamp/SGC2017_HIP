using System;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

using Acr.UserDialogs;

using HIP.Models;
using HIP.MobileAppService.Models;
using System.Threading.Tasks;

namespace HIP
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage(Event program)
        {
            InitializeComponent();
            this.program = program;

            BindingContext = viewModel = new SignInViewModel(program);
            viewModel.AdditionalVolunteers.CollectionChanged += (sender, e) => UpdateListViewHeight();
		}

        private void UpdateListViewHeight()
        {
            ListView listView = AdditionalVolunteersListView;
            int requestedHeight = listView.RowHeight * viewModel.AdditionalVolunteers.Count;
            listView.HeightRequest = requestedHeight;
		}

        private void AddAdditionalVolunteer(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdditionalVolunteerPage((MobileAppService.Models.UserModel user) => viewModel.AddVolunteer(user)));
        }

		public void RemoveAdditionalVolunteer(object sender, EventArgs e)
		{
			var mi = (MenuItem)sender;
            var vlivm = (VolunteerListItemViewModel)mi.CommandParameter;
            viewModel.AdditionalVolunteers.Remove(vlivm);
		}

        private async void Send(object sender, EventArgs e)
        {
            IProgressDialog waiter = null;

            try 
            {
                UserModel[] additionalVolunteers = viewModel.AdditionalVolunteers.Select(m => m.Model).ToArray();
                double hours = viewModel.Hours;
                DateTime now = DateTime.UtcNow;

                UserModel user = UserModel.CurrentUser;

                IDataStore<Event> dataStore = DependencyService.Get<IDataStore<Event>>() ?? new MockDataStore();

                EventCheckInModel checkIn = new EventCheckInModel();
                checkIn.EventId = program.Id;
                checkIn.CheckinDate = now;
                checkIn.HourCount = hours;
                checkIn.ParentUserEmail = null;
                checkIn.UserEmail = user.Email;

                waiter = UserDialogs.Instance.Loading("Sending...", maskType: MaskType.Clear);
                waiter.Show();

                bool result = await dataStore.CheckInUserOnEventAsync(checkIn);

                if (!result)
                {
                    throw new Exception();
                }

                waiter?.Hide();
                await Navigation.PopAsync();
            }
            catch
            {
                waiter?.Hide();
                await DisplayAlert("Error", "Cannot save hours", "OK");
            }
        }

        private Event program;
        private SignInViewModel viewModel;
    }
}
