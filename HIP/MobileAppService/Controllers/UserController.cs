using System;
using Microsoft.AspNetCore.Mvc;
using HIP.Models;

namespace HIP.Controllers
{
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IUserRepository UserRepository;

		public UserController(IUserRepository userRepository)
		{
			this.UserRepository = userRepository;
		}

		[HttpGet]
		public IActionResult List()
		{
			return Ok(UserRepository.GetAll());
		}

		[HttpGet("{Email}")]
		public Item GetItem(string email)
		{
			Item item = UserRepository.Get(email);
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

				UserRepository.Add(item);

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
				UserRepository.Update(item);
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
			UserRepository.Remove(id);
		}
	}
}
