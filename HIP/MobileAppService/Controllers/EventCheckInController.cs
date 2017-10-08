using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;
using HIP.MobileAppService.Models.Repositories;

namespace HIP.MobileAppService.Controllers
{
	[Route("api/[controller]")]
	public class EventCheckInController : Controller
	{
		private readonly IEventCheckInRepository EventCheckInRepository;

		public EventCheckInController(IEventCheckInRepository userRepository)
		{
			this.EventCheckInRepository = userRepository;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(EventCheckInRepository.GetAll());
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
                return BadRequest("Error while creating: "+e.Message);
			}
			return Ok(item);
		}
	}
}
