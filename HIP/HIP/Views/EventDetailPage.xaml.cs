using System;

using Xamarin.Forms;
using HIP.Models;
namespace HIP
{
    public partial class EventDetailPage : ContentPage
    {
        EventDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public EventDetailPage()
        {
            InitializeComponent();

            var item = new Event
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new EventDetailViewModel(item);
            BindingContext = viewModel;
        }

        public EventDetailPage(EventDetailViewModel viewModel)
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
