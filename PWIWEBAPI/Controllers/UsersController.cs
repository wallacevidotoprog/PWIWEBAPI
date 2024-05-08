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

        [HttpGet]
		public async Task<ActionResult<ServiceResModel<List<UserModel>>>> GetAllUsers()
		{
			return Ok(await _iusers.GetAllUsers());

		}

		//[HttpGet]
		//public async Task<ActionResult<ServiceResModel<UserModel>>> GetUsersById()
		//{
		//	return Ok("GetUsersById");

		//}

		[HttpPost]
		public async Task<ActionResult<ServiceResModel<UserModel>>> CreateUsers(UserModel userModel)
		{
			return Ok(await _iusers.CreateUsers(userModel));

		}

		//[HttpPut]
		//public async Task<ActionResult<ServiceResModel<UserModel>>> UpdateUsers()
		//{
		//	return Ok("UpdateUsers");

		//}
		//[HttpDelete]
		//public async Task<ActionResult<ServiceResModel<UserModel>>> DeletUsers()
		//{
		//	return Ok("DeletUsers");

		//}

	}
}
