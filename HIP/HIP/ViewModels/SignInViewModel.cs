using System;
using System.Collections.ObjectModel;
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

        public SignInViewModel(Event program)
		{
			Title = "Sign In";

            TimeSpan duration = program.End - program.Start;
            Hours = Math.Round(duration.TotalHours * 2.0) / 2.0;
            if (Hours < minHours) {
                Hours = minHours;
            }

            if (Hours > maxHours) {
                Hours = maxHours;
            }

            AdditionalVolunteers = new ObservableCollection<VolunteerListItemViewModel>();
            AdditionalVolunteers.Clear();

            LessCommand = new Command(() => AddTime(-0.5));
			MoreCommand = new Command(() => AddTime(0.5));
   		}

        public void AddVolunteer(UserModel user)
        {
            AdditionalVolunteers.Add(new VolunteerListItemViewModel(user));
        }

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
            if (newHours < minHours || newHours > maxHours)
            {
                return;
            }

            System.Console.WriteLine("Hours: {0}", newHours);
            Hours = newHours;

            OnPropertyChanged(nameof(DisplayHours));
        }

		public ObservableCollection<VolunteerListItemViewModel> AdditionalVolunteers { get; }
        public double Hours { get; private set; } = 1.0;

		public ICommand LessCommand { get; }
		public ICommand MoreCommand { get; }
	}
}

