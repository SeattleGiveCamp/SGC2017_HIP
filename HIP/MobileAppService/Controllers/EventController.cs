using System;
using Microsoft.AspNetCore.Mvc;
using HIP.Models;

namespace HIP.Controllers
{
	[Route("api/[controller]")]
	public class EventController : Controller
	{
		private readonly IEventRepository EventRepository;

		public EventController(IEventRepository userRepository)
		{
			this.EventRepository = userRepository;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(EventRepository.GetAll());
		}

		[HttpGet("{id}")]
		public Item GetItem(string eventId)
		{
			Item item = EventRepository.Get(eventId);
			return item;
		}

		[HttpPost]
		public IActionResult Create([FromBody]Item item)
		{
			try
			{
				if (item == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}

				EventRepository.Add(item);

			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return Ok(item);
		}

		[HttpPut]
		public IActionResult Edit([FromBody] Item item)
		{
			try
			{
				if (item == null || !ModelState.IsValid)
				{
					return BadRequest("Invalid State");
				}
				EventRepository.Update(item);
			}
			catch (Exception)
			{
				return BadRequest("Error while creating");
			}
			return NoContent();
		}

		[HttpDelete("{Id}")]
		public void Delete(string id)
		{
			EventRepository.Remove(id);
		}
	}
}
