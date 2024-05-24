using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
using PWIWEBAPI.Services.Gamed;
namespace PWIWEBAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GamedController : Controller
	{
		private readonly IGamed _gamed;

		public GamedController(IGamed gamed)=> _gamed = gamed;


		[HttpGet("gmserver")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGamed() => await _gamed.GetGmServer();

		[HttpGet("Gsalia")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia() => await _gamed.GetGsalia();
		[HttpGet("gs")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGs() => await _gamed.GetGs();
		[HttpGet("ptemplate")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetPtemplate() => await _gamed.GetPtemplate();



		[HttpPost("gmServer")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGamed()
		{
			return await _gamed.WriteGmServer();
		}

		[HttpPost("gsalias")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGsalias()
		{
			return await _gamed.WriteGsalias();
		}
	}
}
		
	


