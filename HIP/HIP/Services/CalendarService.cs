using System;
using System.Threading.Tasks;
using Plugin.Calendars.Abstractions;
using Plugin.Calendars;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
// using FormsToolkit;
using System.Diagnostics;
using Xamarin.Forms;
using System.Collections.Generic;
using HIP.Models;

namespace HIP.Services
{
	public static class CalendarService
	{
        public static async Task<IList<Calendar>> GetCalendarsAsync()
        {
			var ready = await CheckPermissionsGetCalendarAsync();
			if (!ready)
                return new List<Calendar>();
            
            return await CrossCalendars.Current.GetCalendarsAsync();
        }

		public static async Task<bool> AddReminderAsync(Calendar calendar, Event model)
		{
            CalendarEvent calEvent = new CalendarEvent();
            calEvent.Name = model.Name;
            calEvent.Description = model.Description;
            calEvent.Start = model.Start;
            calEvent.End = model.End;

			var ready = await CheckPermissionsGetCalendarAsync();
			if (!ready)
				return false;

			try
			{                                         
                await CrossCalendars.Current.AddOrUpdateEventAsync(calendar, calEvent);
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
