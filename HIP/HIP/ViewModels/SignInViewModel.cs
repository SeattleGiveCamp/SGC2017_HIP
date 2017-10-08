using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;
using HIP.MobileAppService.Models;
using System.Linq;

namespace HIP
{
	public class SignInViewModel : ViewModelBase
	{
        public SignInViewModel(INavigation navigation)
		{
            Navigation = navigation;
			Title = "Sign In";

            AdditionalVolunteers = new ObservableCollection<VolunteerListItemViewModel>();
            AdditionalVolunteers.Clear();

            SendCommand = new Command(() => Send());
            LessCommand = new Command(() => AddTime(-0.5));
			MoreCommand = new Command(() => AddTime(0.5));
   		}

        private void Send()
        {
            UserModel[] additionalVolunteers = AdditionalVolunteers.Select(m => m.Model).ToArray();
            // TODO: Submit the list of volunteers to the API.
            Navigation.PopAsync();
        }

        public void AddVolunteer(UserModel user)
        {
            AdditionalVolunteers.Add(new VolunteerListItemViewModel(user));
        }

        private double Hours = 1.0; // TODO: Get duration from the actual event.
		public string DisplayHours
		{
			get
			{
                int doubleHours = (int)(Math.Round(Hours * 2.0));
                int wholeHours = doubleHours / 2;
                int halfHours = doubleHours % 2;

                string displayHours = wholeHours.ToString();
                if (halfHours == 1)
                {
                    displayHours += " ½"; // There's a thin-space character in this string. Don't edit this line unless you understand Unicode and typography.
                }

                return displayHours;
			}
		}

        void AddTime(double howMuch)
        {
            double newHours = Hours + howMuch;
            if (newHours < 0.5 || newHours > 48.0)
            {
                return;
            }

            System.Console.WriteLine("Hours: {0}", newHours);
            Hours = newHours;

            OnPropertyChanged(nameof(DisplayHours));
        }

		public ObservableCollection<VolunteerListItemViewModel> AdditionalVolunteers { get; }

		public ICommand LessCommand { get; }
		public ICommand MoreCommand { get; }
		public ICommand SendCommand { get; }
        private INavigation Navigation { get; }
	}
}

