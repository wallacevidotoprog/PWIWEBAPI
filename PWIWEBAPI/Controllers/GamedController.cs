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


		[HttpGet("GetAllGmServer")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGamed() => await _gamed.GetGmServer();

		[HttpGet("GetAllGsalia")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia() => await _gamed.GetGsalia();
		[HttpGet("GetAllGs")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGs() => await _gamed.GetGs();
		[HttpGet("GetAllPtemplate")]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetPtemplate() => await _gamed.GetPtemplate();



		[HttpPost("WriteGmServer")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGamed() => await _gamed.WriteGmServer();

		[HttpPost("WriteGsalias")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGsalias()=> await _gamed.WriteGsalias();

		[HttpPost("WriteGs")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGs() => await _gamed.WriteGs();

		[HttpPost("WritePtemplate")]
		public async Task<ActionResult<ServiceResModel<bool>>> WritePtemplate() => await _gamed.WritePtemplate();
	}
}
		
	


