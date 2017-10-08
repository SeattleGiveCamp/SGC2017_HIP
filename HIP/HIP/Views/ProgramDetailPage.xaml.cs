using System;

using Xamarin.Forms;
using HIP.Models;

namespace HIP
{
    public partial class ProgramDetailPage : ContentPage
    {
        ProgramDetailViewModel viewModel;

		// Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
		public ProgramDetailPage() : this(new Event
		{
			Name = "Item 1",
			Description = "This is an item description."
		})
        {
        }

        public ProgramDetailPage(Event program)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new ProgramDetailViewModel(program);
        }

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
