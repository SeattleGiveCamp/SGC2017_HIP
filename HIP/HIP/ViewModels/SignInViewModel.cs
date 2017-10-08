using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace HIP
{
	public class SignInViewModel : ViewModelBase
	{
		public SignInViewModel()
		{
			Title = "Sign In";

			SendCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
		}

		public ICommand SendCommand { get; }
	}
}

