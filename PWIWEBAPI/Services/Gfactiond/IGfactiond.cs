using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.Gfactiond
{
	public interface IGfactiond
	{
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond();
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGfactiond(List<GamesysModel> gamesysModels);
		Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter();
		Task<ActionResult<ServiceResModel<List<string>>>> WriteGfactiondFilter(ActionData<List<string>> filters);
		//Task<ActionResult<bool>> WriteGfactiondFilter(ActionData<List<string>> filters);
	}
}
