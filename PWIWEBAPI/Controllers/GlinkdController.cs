using PWIWEBAPI.Services.Glinkd;
using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
namespace PWIWEBAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GlinkdController : Controller
	{
		private readonly IGlinkd _glinkd;

		public GlinkdController(IGlinkd glinkdService)=> _glinkd = glinkdService;


		[HttpGet]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGlinkd() => await _glinkd.GetGlinkd();

		[HttpPost]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGlinkd(List<GamesysModel> gamesysModels)
		{
			return await _glinkd.WriteGlinkd(gamesysModels);
		}
	}
}
		
	


