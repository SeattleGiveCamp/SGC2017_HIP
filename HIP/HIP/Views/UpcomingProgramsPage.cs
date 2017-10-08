using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using HIP.Models;
using HIP.ViewModels;
using HIP.Views;

namespace HIP
{
    public partial class UpcomingProgramsPage : ContentPage
    {
        ProgramListViewModel viewModel;

        public UpcomingProgramsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProgramListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ProgramListItemViewModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ProgramDetailPage(new ProgramDetailViewModel(item.Event)));

            // Manually deselect item
            ProgramsListView.SelectedItem = null;
        }

        async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
