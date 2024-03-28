using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly WebDb _dbContext;
		public UserController(WebDb webDb)
		{
			_dbContext = webDb;
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(User user)
		{
			using (var dbContext = _dbContext)
			{
				var User = new User
				{
					Email = user.Email,
					Name = user.Name,

				};
				if (User == null)
				{
					return BadRequest();
				}
				dbContext.Users.Add(User);
				await dbContext.SaveChangesAsync();

			}
			{
				return Ok();
			}
		}
		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(int Id)
		{
			using (var dbContext = _dbContext)
			{
				var User = dbContext.Users.FirstOrDefault(u => u.Id == Id);

				_dbContext.Remove(User);
				await _dbContext.SaveChangesAsync();
			}
			if (User == null)
			{
				return BadRequest("User not found");
			}
			return Ok("User deleted");

		}

		[HttpPut]
		[Route("Update")]

		public async Task<IActionResult> Update(User user)
		{
			using (var dbContext = _dbContext)
			{
				var existingUser = await dbContext.Users.FindAsync(user.Id);


				if (existingUser != null)
				{
					existingUser.Email = user.Email;
					existingUser.Name = user.Name;
					 

					_dbContext.Update(existingUser);
					await _dbContext.SaveChangesAsync();
					return Ok("details Updated");
				}
				return NotFound("User not found");
			}
		}
		[HttpGet]
		[Route("GetAllUsers")]

		public async Task<IActionResult> GetAllUsers()
		{
			using (var dbContext = _dbContext)
			{
				var User = dbContext.Users.ToList();
				return Ok(User);
			}
		}

		[HttpGet]
		[Route("GetAllUsersByID")]

		public async Task<IActionResult> GetAllUsersByID(int Id)
		{
			using (var dbContext = _dbContext)
			{
				var User = dbContext.Users.FirstOrDefault();
				return Ok(User);
			}
		}
	}
	



}

