using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.Glinkd
{
	public interface IGlinkd
	{
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGlinkd();
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGlinkd();
		Task<ActionResult<ServiceResModel<List<GamesysModel>>>> SetGlinkd(List<ActionData<DataMod>> gamesysModels);
	}
}
