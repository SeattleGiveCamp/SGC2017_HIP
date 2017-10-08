using System;
using System.Collections.Generic;
using HIP.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;
using HIP.MobileAppService.Models.ClientModels;

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

        [HttpGet("getByEndDate/{date}")]
		public List<Event> GetItemsBeforeDate(string date)

		{
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Parse(date);

            if (endDate == null || endDate < startDate){
				throw new Exception("Can only display events from today onwards");
			}
            if ((endDate-startDate).Days > 180){
                throw new Exception("Cannot display events further than 180 days in the future");
            }
            //IEnumerable<EventModel> storedEvents = EventRepository.GetAll();

            //return eventMapper.BuildEventsToDisplay(startDate, endDate, storedEvents);

            ////////TEMP///////////
            List<Event> tmpList = new List<Event>();
			tmpList.Add(new Event("qwert", "Carrott cutting party", "At my apartment", DateTime.Now.AddHours(1), DateTime.Now.AddHours(3), new List<ProgramType>()));
			tmpList.Add(new Event("asdf", "Potato cutting party", "At your apartment", DateTime.Now.AddHours(2), DateTime.Now.AddHours(7), new List<ProgramType>()));
			tmpList.Add(new Event("zxcv", "Beet cutting party", "At my friend's apartment", DateTime.Now.AddHours(3), DateTime.Now.AddHours(4), new List<ProgramType>()));
            return tmpList;
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
            catch (Exception e)
            {
                return BadRequest("Error while creating: "+e.Message);
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
