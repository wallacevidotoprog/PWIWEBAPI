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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GetGlinkd", "Exception", ex.Message);
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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "WriteGlinkd", "Exception", ex.Message);
			}

			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> SetGlinkd(List<ActionData<DataMod>> gamesysModels)
		{
			tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				for (int i = 0; i < gamesysModels.Count; i++)
				{
					if (((JsonElement)gamesysModels[i].Data.Values).ValueKind.ToString() == "Array")
					{
							((GamesysModel)((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels[i].Data.Id_tile])
								.ActionValues((Actions)gamesysModels[i].Action, gamesysModels[i].Data.Id_key, JsonSerializer.Deserialize<object[]>(gamesysModels[i].Data.Values.ToString()).Select(x => x.ToString()).Cast<object>().ToArray());
						
					}
					else
					{
						((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels[i].Data.Id_tile]
								.ActionValues((Actions)gamesysModels[i].Action, gamesysModels[i].Data.Id_key, gamesysModels[i].Data.Values) ;
					}

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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "SetGlinkd", "Exception", ex.Message);
			}

			return tempRes;
		}

	}

}
