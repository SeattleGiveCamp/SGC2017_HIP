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
			tmpList.Add(new Event("qwert", "Healthy HIP Packs Packing Party", "Help pack weekend backpacks for kids who don't have access to free/reduced priced meals during the weekend\nLocation: Fellowship Hall at Lake City Presbyterian Church", DateTime.Now.AddHours(1), DateTime.Now.AddHours(3), new List<ProgramType>()));
            tmpList.Add(new Event("asdf", "Senior Meals Prep", "Prepare meals for our Senior Meals program\nLocation: Lake City Presbyterian Church", DateTime.Now.AddDays(2), DateTime.Now.AddDays(7), new List<ProgramType>()));
			tmpList.Add(new Event("zxcv", "Senior Meals Serving", "Serve meals, help with setup, and cleanup for our Senior Meals Program\nLocation: Lake City Community Center", DateTime.Now.AddHours(3), DateTime.Now.AddHours(4), new List<ProgramType>()));
			tmpList.Add(new Event("zxcv", "Healthy HIP Packs Repackaging", "Repackage bulk food into smaller portions for our Healthy HIP Packs Program\nLocation: Fellowship Hall at Lake City Presbyterian Church", DateTime.Now.AddHours(30), DateTime.Now.AddHours(34), new List<ProgramType>()));
			tmpList.Add(new Event("zxcv", "Afterschool Snacks", "Serve healthy snacks to kids and youth during the Homework Help program\nLocation: Lake City Branch of Seattle Public Libraries", DateTime.Now.AddHours(53), DateTime.Now.AddHours(54), new List<ProgramType>()));
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
