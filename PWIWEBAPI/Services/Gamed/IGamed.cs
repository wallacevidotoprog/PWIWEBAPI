using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.Gamed
{
	public interface IGamed
	{
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGmServer();
		Task<ActionResult<ServiceResModel<bool>>> WriteGmServer();
		Task<ActionResult<ServiceResModel<bool>>> SetGmServer();


		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia();
		Task<ActionResult<ServiceResModel<bool>>> WriteGsalias();
		Task<ActionResult<ServiceResModel<bool>>> SetGsalias();

		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGs();

		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetPtemplate();
	}
}
