using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Models;
namespace PWIWEBAPI.Services.Glinkd
{
	public class GlinkdService : IGlinkd
	{
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGlinkd()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[0].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
			}
			return tempRes;
		}

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGlinkd(List<GamesysModel> gamesysModels)
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{


				DatasPw.listPwData[0].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
				tempRes.Data = null;
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				tempRes.Data = null;
			}

			return tempRes;
		}

	}

}
