using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using HIP.Models;
using System.Windows.Input;
// using FormsToolkit;
using HIP.ViewModels;

namespace HIP
{
    public class ProgramListViewModel : ViewModelBase
    {
        public ObservableCollection<ProgramListItemViewModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ProgramListViewModel()
        {
            Title = "Upcoming Programs"; // this should really get set by the page, not the view model
            Items = new ObservableCollection<ProgramListItemViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(new ProgramListItemViewModel(item));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
