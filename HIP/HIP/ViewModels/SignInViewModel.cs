using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

using HIP.Models;
using HIP.MobileAppService.Models;

namespace HIP
{
	public class SignInViewModel : ViewModelBase
	{
        private const double minHours = 0.5;
        private const double maxHours = 48.0;

        public SignInViewModel(INavigation navigation, Event program)
		{
            Navigation = navigation;
			Title = "Sign In";

            TimeSpan duration = program.End - program.Start;
            hours = Math.Round(duration.TotalHours * 2.0) / 2.0;
            if (hours < minHours) {
                hours = minHours;
            }

            if (hours > maxHours) {
                hours = maxHours;
            }

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

		public string DisplayHours
		{
			get
			{
                int doubleHours = (int)(Math.Round(hours * 2.0));
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
            double newHours = hours + howMuch;
            if (newHours < minHours || newHours > maxHours)
            {
                return;
            }

            System.Console.WriteLine("Hours: {0}", newHours);
            hours = newHours;

            OnPropertyChanged(nameof(DisplayHours));
        }

		public ObservableCollection<VolunteerListItemViewModel> AdditionalVolunteers { get; }

		public ICommand LessCommand { get; }
		public ICommand MoreCommand { get; }
		public ICommand SendCommand { get; }
        private INavigation Navigation { get; }

        private double hours = 1.0;
	}
}

