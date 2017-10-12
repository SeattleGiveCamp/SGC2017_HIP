﻿using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;
using HIP.MobileAppService.Models.Repositories;
using System.Text;

namespace HIP.MobileAppService.Controllers
{
	[Route("api/[controller]")]
	public class EventCheckInController : Controller
	{
		private readonly IEventCheckInRepository EventCheckInRepository;
		private readonly IUserRepository UserRepository;
        private readonly IEventRepository EventRepository;

		public EventCheckInController(IEventCheckInRepository checkinRepo, IUserRepository userRepo, IEventRepository eventRepo)
		{
			this.EventCheckInRepository = checkinRepo;
            this.UserRepository = userRepo;
            this.EventRepository = eventRepo;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(EventCheckInRepository.GetAll());
		}

		[HttpGet("getFlatFileBetweenDates/{startDate}/{endDate}")]
		public String GetItemsBeforeDate(string startDate, string endDate)
        {
            List<EventCheckInModel> checkIns = EventCheckInRepository.GetBetweenDates(DateTime.Parse(startDate), DateTime.Parse(endDate));

            Dictionary<string, UserModel> users = new Dictionary<string, UserModel>();
            foreach (var user in UserRepository.GetAll())
            {
                users.Add(user.Email, user);
            }

            Dictionary<string, int> guestCount = new Dictionary<string, int>();
			foreach (EventCheckInModel checkin in checkIns)
			{
                if (checkin.ParentUserEmail != null && checkin.ParentUserEmail.Length > 0)
                {
                    string email = checkin.ParentUserEmail;
                    if (!guestCount.ContainsKey(email))
                    {
                        guestCount.Add(email, 0);
                    }
                    guestCount[email] += 1;
                }
			}

			StringBuilder builder = new StringBuilder();
			//build header row           
            builder.Append("FirstName").Append(",");
			builder.Append("LastName").Append(",");
			builder.Append("Email").Append(",");
			builder.Append("ProgramName").Append(",");
			builder.Append("CheckinDate").Append(",");
			builder.Append("HourCount").Append(",");
			builder.Append("VolunteerCount").Append("\r\n");
            foreach(EventCheckInModel checkin in checkIns)
            {
                string email = checkin.ParentUserEmail != null && checkin.ParentUserEmail.Length > 0? checkin.ParentUserEmail : checkin.UserEmail;
                UserModel user = getUser(email);
                int volunteerCount = guestCount.ContainsKey(email) ? guestCount[email] : 1;
                string programName = EventRepository.Get(checkin.EventId).Name;

                builder.Append(user.FirstName).Append(",");
                builder.Append(user.LastName).Append(",");
                builder.Append(email).Append(",");
                builder.Append(programName).Append(",");
                builder.Append(checkin.CheckinDate).Append(",");
                builder.Append(checkin.HourCount).Append(",");
                builder.Append(volunteerCount).Append("\r\n");
            }
            return builder.ToString();
        }

        private UserModel getUser(string email){
            try{
                return this.UserRepository.Get(email);
            }
            catch(Exception e){
                return null;
            }
        }

		[HttpPost]
		public IActionResult Create([FromBody]EventCheckInModel item)
		{
			try
			{
				if (item == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}

				EventCheckInRepository.Add(item);

			}
			catch (Exception e)
			{
				string error = "Error while creating: " + e.Message + ". " + e.InnerException;
				return BadRequest(error);			
            }
			return Ok(item);
		}
	}
}
