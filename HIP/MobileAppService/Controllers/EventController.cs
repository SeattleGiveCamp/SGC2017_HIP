using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HIP.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventRepository EventRepository;
        private EventMapper eventMapper = new EventMapper();

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
        public EventModel GetItem(string eventId)
        {
            return EventRepository.Get(eventId);
        }

        [HttpGet("{endDate}")]
		//public IEnumerable<EventModel> GetItemsBeforeDate(string endDateStr)
		public List<EventModel> GetItemsBeforeDate(string endDateStr)

		{
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Parse(endDateStr);

            if (endDate == null || endDate < startDate){
				throw new Exception("Can only display events from today onwards");
			}
            if ((endDate-startDate).Days > 180){
                throw new Exception("Cannot display events further than 180 days in the future");
            }
			IEnumerable<EventModel> storedEvents = EventRepository.GetAll();

            //return eventMapper.BuildEventsToDisplay(startDate, endDate, storedEvents);
            return new List<EventModel>();
        }

        [HttpPost]
        public IActionResult Create([FromBody]EventModel item)
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
        public IActionResult Edit([FromBody] EventModel item)
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
