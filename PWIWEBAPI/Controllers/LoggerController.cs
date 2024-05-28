using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
using PWIWEBAPI.Services.User;

namespace PWIWEBAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LoggerController : Controller
	{
		[HttpGet("GetLog")]
		public async Task<ActionResult<ServiceResModel<List<string[]>>>> GetLog()
		{
			return Ok(await Loggers.LogGet());
		}
	}
}
