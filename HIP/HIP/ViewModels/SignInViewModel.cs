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
		public SignInViewModel()
		{
			Title = "Sign In";

            AdditionalVolunteers = new ObservableCollection<VolunteerListItemViewModel>();

            SendCommand = new Command(() => Send());
            LessCommand = new Command(() => AddTime(-0.5));
			MoreCommand = new Command(() => AddTime(0.5));

            UserModel user1 = new UserModel("foo@bar.com", "Hello", "World");
			UserModel user2 = new UserModel("noname@nemo.com");
			UserModel user3 = new UserModel("kid@minor.com");
            user3.IsMinor = true;

            AdditionalVolunteers.Clear();
            AdditionalVolunteers.Add(new VolunteerListItemViewModel(user1));
			AdditionalVolunteers.Add(new VolunteerListItemViewModel(user2));
			AdditionalVolunteers.Add(new VolunteerListItemViewModel(user3));
		}

        private void Send()
        {
            UserModel[] additionalVolunteers = AdditionalVolunteers.Select(m => m.Model).ToArray();
        }

        private double Hours = 8.5;
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
	}
}

