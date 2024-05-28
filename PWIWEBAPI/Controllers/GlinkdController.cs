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


		[HttpGet("GetAllGlinkd")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGlinkd() => await _glinkd.GetGlinkd();

		[HttpPost("WriteGlinkd")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGlinkd()
		{
			return await _glinkd.WriteGlinkd();
		}
		[HttpPut("SetGlinkd")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> Glinkd(ActionData<DataMod> valuesModels)
		{
			return await _glinkd.SetGlinkd(valuesModels);
		}
	}
}
		
	


