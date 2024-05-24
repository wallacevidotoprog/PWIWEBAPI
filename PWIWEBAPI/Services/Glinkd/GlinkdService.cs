using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;
namespace PWIWEBAPI.Services.Glinkd
{
	public class GlinkdService : IGlinkd
	{
		ServiceResModel<List<GamesysModel>> tempRes;
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGlinkd()
		{
			tempRes = new ServiceResModel<List<GamesysModel>>();
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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GlinkdService", "GetGlinkd", ex.Message);
			}
			return tempRes;
		}

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGlinkd()
		{
			tempRes = new ServiceResModel<List<GamesysModel>>();
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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GlinkdService", "WriteGlinkd", ex.Message);
			}

			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> SetGlinkd(ActionData<DataMod> gamesysModels)
		{
			tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				if (((JsonElement)gamesysModels.Data.Values).ValueKind.ToString() == "Array")
				{
					((GamesysModel)((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels.Data.Id_tile])
						.ActionValues((Actions)gamesysModels.Action, gamesysModels.Data.Id_key, ((JsonElement)gamesysModels.Data.Values).Return());

				}
				else
				{
					((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels.Data.Id_tile]
							.ActionValues((Actions)gamesysModels.Action, gamesysModels.Data.Id_key, gamesysModels.Data.Values);
				}


				tempRes.Error = false;
				tempRes.Message = "Sucesse";
				tempRes.Data = null;
			}
			catch (Exception ex)
			{

				tempRes.Error = true;
				tempRes.Message = ex.Message;
				tempRes.Data = null;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GlinkdService", "SetGlinkd", ex.Message);
			}

			return tempRes;
		}

	}

}
