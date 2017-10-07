using System;
using System.Windows.Input;
using FormsToolkit;
using HIP.Models;
using HIP.Services;
using Xamarin.Forms;

namespace HIP.ViewModels
{
	public class EventViewModel
	{
		public EventViewModel(Event model)
		{
			Event = model;
			AddToCalendar = new Command(() => {
				MessagingService.Current.SendMessage<MessagingServiceAlert>("message", new MessagingServiceAlert
				{
					Title = "Event Creation",
					Message = "Pfff",
					Cancel = "OK"
				});

                //CalendarService.AddReminderAsync();
			});

            Name = model.Name;
            Description = model.Description;
            Date = model.Date;
		}

        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

		public Event Event { get; set; }

		public ICommand AddToCalendar { get; }
	}
}
