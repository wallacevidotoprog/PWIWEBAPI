using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.Gfactiond
{
	public interface IGfactiond
	{
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond();
		Task<ActionResult<ServiceResModel<bool>>> SetGfactiond(ActionData<DataMod> gamesysModels);
		Task<ActionResult<ServiceResModel<bool>>> WriteGfactiond();

		Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter();
		Task<ActionResult<ServiceResModel<bool>>> SetGfactiondFilter(ActionData<List<ListModel>> filters);
		Task<ActionResult<ServiceResModel<bool>>> WriteGfactiondFilter();

	}
}
