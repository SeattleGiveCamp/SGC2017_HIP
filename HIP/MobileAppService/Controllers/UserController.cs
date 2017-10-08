//using System;
//using Microsoft.AspNetCore.Mvc;
//using HIP.MobileAppService.Models;

//namespace HIP.Controllers
//{
//	[Route("api/[controller]")]
//	public class UserController : Controller
//	{
//		private readonly IUserRepository UserRepository;

//		public UserController(IUserRepository userRepository)
//		{
//			this.UserRepository = userRepository;
//		}

//		[HttpGet]
//		public IActionResult List()
//		{
//			return Ok(UserRepository.GetAll());
//		}

//		[HttpGet("{Email}")]
//		public UserModel GetItem(string email)
//		{
//			UserModel item = UserRepository.Get(email);
//			return item;
//		}

//		[HttpPost]
//		public IActionResult Create([FromBody]UserModel item)
//		{
//			try
//			{
//				if (item == null || !ModelState.IsValid)
//				{
//					return BadRequest("Invalid State");
//				}

//				UserRepository.Add(item);

//			}
//			catch (Exception)
//			{
//				return BadRequest("Error while creating");
//			}
//			return Ok(item);
//		}

//		[HttpPut]
//		public IActionResult Edit([FromBody] UserModel item)
//		{
//			try
//			{
//				if (item == null || !ModelState.IsValid)
//				{
//					return BadRequest("Invalid State");
//				}
//				UserRepository.Update(item);
//			}
//			catch (Exception)
//			{
//				return BadRequest("Error while creating");
//			}
//			return NoContent();
//		}

//		[HttpDelete("{Id}")]
//		public void Delete(string id)
//		{
//			UserRepository.Remove(id);
//		}
//	}
//}
