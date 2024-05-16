using PWIWEBAPI.Services.Glinkd;
using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Services.Gfactiond;


namespace PWIWEBAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GfactiondController : Controller
	{
		private readonly IGfactiond _gfactiond;

		public GfactiondController(IGfactiond gfactiondService)
		{
			_gfactiond = gfactiondService;

		}

		[HttpGet]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond()=> await _gfactiond.GetGfactiond();

		[HttpGet("filters")]
		public async Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter() => await _gfactiond.GetGfactiondFilter();

		[HttpPost]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGfactiond(List<GamesysModel> gamesysModels)
		{
			return await _gfactiond.WriteGfactiond(gamesysModels);
		}
		[HttpPost("filters")]
		public async Task<ActionResult<ServiceResModel<List<string>>>> WriteGfactiond(ActionData<List<string>> filter)
		{
			return await _gfactiond.WriteGfactiondFilter(filter);
		}
	}
}
		
	


