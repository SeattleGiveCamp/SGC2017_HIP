using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIP.Views
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "The Login Screen!" }
				}
			};
		}
	}
}