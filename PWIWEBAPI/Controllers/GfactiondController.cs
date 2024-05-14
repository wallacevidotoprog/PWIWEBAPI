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

		[HttpPost]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGfactiond(List<GamesysModel> gamesysModels)
		{
			return await _gfactiond.WriteGfactiond(gamesysModels);
		}
	}
}
		
	


