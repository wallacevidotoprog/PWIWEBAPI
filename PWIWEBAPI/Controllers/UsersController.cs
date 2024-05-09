using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
using PWIWEBAPI.Services.User;

namespace PWIWEBAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : Controller
	{
		private readonly IUser _iusers;
        public UsersController(IUser iusers)=> _iusers = iusers;

        [HttpGet("GetAllUsers")]
		public async Task<ActionResult<ServiceResModel<List<UserModel>>>> GetAllUsers()
		{
			return Ok(await _iusers.GetAllUsers());

		}

		[HttpGet("GetUsersById{id}")]
		public async Task<ActionResult<ServiceResModel<UserModel>>> GetUsersById(int id)
		{
			return Ok(await _iusers.GetUsersById(id));

		}

		[HttpPost("CreateUsers")]
		public async Task<ActionResult<ServiceResModel<UserModel>>> CreateUsers(UserModel userModel)
		{
			return Ok(await _iusers.CreateUsers(userModel));

		}
		[HttpPut("inativeUser{id}")]
		public async Task<ActionResult<ServiceResModel<UserModel>>> DeletUsers(int id)
		{
			return Ok(await _iusers.DeletUsers(id));

		}
		[HttpPut("UpdateUsers")]
		public async Task<ActionResult<ServiceResModel<UserModel>>> UpdateUsers(UserModel upUser)
		{
			return Ok(await _iusers.UpdateUsers(upUser));

		}



	}
}
