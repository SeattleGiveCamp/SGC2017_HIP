using System;

using Xamarin.Forms;
using HIP.Models;
namespace HIP
{
    public partial class ProgramDetailPage : ContentPage
    {
        ProgramDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ProgramDetailPage()
        {
            InitializeComponent();

            var item = new Event
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ProgramDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ProgramDetailPage(ProgramDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
