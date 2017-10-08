using System;
using System.Windows.Input;
// using FormsToolkit;
using HIP.Models;
using HIP.Services;
using Xamarin.Forms;

namespace HIP.ViewModels
{
	public class ProgramListItemViewModel
	{
		public ProgramListItemViewModel(Event model)
		{
			Event = model;
			//AddToCalendar = new Command(() => {
   //             await CalendarService.AddReminderAsync();
			//});

            Name = model.Name;
            Description = model.Description;
            Date = DateTime.Now.ToString();
		}

        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

		public Event Event { get; set; }

		public ICommand AddToCalendar { get; }
	}
}
