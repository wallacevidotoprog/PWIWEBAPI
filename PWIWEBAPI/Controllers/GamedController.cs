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


		[HttpGet("GmServer")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGamed() => await _gamed.GetGmServer();

		[HttpGet("Gsalia")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia() => await _gamed.GetGsalia();

		[HttpPost("GmServer")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGamed(List<GamesysModel> gamesysModels)
		{
			return await _gamed.WriteGmServer(gamesysModels);
		}

		[HttpPost("Gsalias")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGsalias(ActionData<List<GamesysModel>> gamesysModels)
		{
			return await _gamed.WriteGsalias(gamesysModels);
		}
	}
}
		
	


