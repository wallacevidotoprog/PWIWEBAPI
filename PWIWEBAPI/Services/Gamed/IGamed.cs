using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.Gamed
{
	public interface IGamed
	{
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGmServer();
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGmServer(List<GamesysModel> gamesysModels);
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia();
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGsalias(ActionData<List<GamesysModel>> gamesysModels);
	}
}
