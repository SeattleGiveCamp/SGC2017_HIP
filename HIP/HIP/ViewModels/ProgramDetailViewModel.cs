using System;
using System.Windows.Input;
using Xamarin.Forms;
using HIP.Models;
using System.Collections.Generic;
using Plugin.Calendars.Abstractions;
using Plugin.Calendars;
using HIP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HIP
{
    public class ProgramDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }

        public ProgramDetailViewModel(Event item = null)
        {
            UserCalendars = new ObservableCollection<Calendar>();
            Title = item?.Name;
            Item = item;
			Name = item.Name;
			Description = item.Description;
			Date = DateTime.Now.ToString();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public Calendar SelectedCalendar { get; set; }
        public ObservableCollection<Calendar> UserCalendars { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }
        public Command LoadItemsCommand { get; set; }

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
                UserCalendars.Clear();
				var items = await CalendarService.GetCalendarsAsync();
				foreach (var item in items)
				{
                    UserCalendars.Add(item);
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
