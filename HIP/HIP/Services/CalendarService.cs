using System;
using System.Threading.Tasks;
using Plugin.Calendars.Abstractions;
using Plugin.Calendars;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using FormsToolkit;
using System.Diagnostics;
using Xamarin.Forms;
using System.Collections.Generic;

namespace HIP.Services
{
	public static class CalendarService
	{
		public static async Task<bool> AddReminderAsync(Event model)
		{
            CalendarEvent calEvent = new CalendarEvent();
            calEvent.Name = model.Name;
            calEvent.Description = model.Description;
            calEvent.Start = DateTime.Now;
            calEvent.End = DateTime.Now.AddHours(5);

			var ready = await CheckPermissionsGetCalendarAsync();
			if (!ready)
				return false;

			try
			{
                //Create event and then create the reminder!
                IList<Calendar> calendars = await CrossCalendars.Current.GetCalendarsAsync();
                if (calendars == null || calendars.Count == 0)
                    return false;

                Calendar cal = calendars[0];                                          
				await CrossCalendars.Current.AddOrUpdateEventAsync(cal, calEvent);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Unable to create event: " + ex);
				return false;
			}
			return true;
		}

		static async Task<bool> CheckPermissionsGetCalendarAsync(bool alert = true)
		{
			var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Calendar);
			if (status != PermissionStatus.Granted)
			{
				var request = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Calendar);
				if (!request.ContainsKey(Permission.Calendar) || request[Permission.Calendar] != PermissionStatus.Granted)
				{
					if (alert)
					{
                        throw new Exception("Unable to set reminders as the Calendar permission was not granted");
					}

					return false;
				}
			}

			return true;
		}
	}
}
