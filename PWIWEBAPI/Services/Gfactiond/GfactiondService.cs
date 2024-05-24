using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using System.Linq;
using System.Text.Json;

namespace PWIWEBAPI.Services.Gfactiond
{
	public class GfactiondService : IGfactiond
	{

		ServiceResModel<List<GamesysModel>> tempRes;
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond()
		{
			tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[1].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "GetGfactiond", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGfactiond()
		{
			var tempRes0 = new ServiceResModel<bool>();
			try
			{

				DatasPw.listPwData[1].Write();
				tempRes0.Error = false;
				tempRes0.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes0.Error = false;
				tempRes0.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "WriteGfactiond", ex.Message);
			}

			return tempRes0;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiond(ActionData<DataMod> gamesysModels)
		{
			var tempRes0 = new ServiceResModel<bool>();
			try
			{
				if (((JsonElement)gamesysModels.Data.Values).ValueKind.ToString() == "Array")
				{
					((GamesysModel)((List<GamesysModel>)DatasPw.listPwData[1].DATA)[gamesysModels.Data.Id_tile])
						.ActionValues((Actions)gamesysModels.Action, gamesysModels.Data.Id_key, ((JsonElement)gamesysModels.Data.Values).Return());
				}
				else
				{
					((List<GamesysModel>)DatasPw.listPwData[1].DATA)[gamesysModels.Data.Id_tile]
							.ActionValues((Actions)gamesysModels.Action, gamesysModels.Data.Id_key, gamesysModels.Data.Values);
				}

				//DatasPw.listPwData[1].Write();
				tempRes0.Error = false;
				tempRes0.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes0.Error = false;
				tempRes0.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "SetGfactiond", ex.Message);
			}

			return tempRes0;
		}



		public async Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter()
		{
			ServiceResModel<List<ListModel>> tempRes = new ServiceResModel<List<ListModel>>();
			try
			{
				tempRes.Data = (List<ListModel>?)DatasPw.listPwData[4].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "GetGfactiondFilter", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGfactiondFilter()
		{

			ServiceResModel<List<bool>> tempRes = new ServiceResModel<List<bool>>();
			try
			{

				DatasPw.listPwData[4].Write();

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "WriteGfactiondFilter", ex.Message);
			}

			return null;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiondFilter(ActionData<List<ListModel>> filters)
		{
			var tempRes0 = new ServiceResModel<bool>();
			try
			{
				for (int i = 0; i < filters.Data.Count; i++)
				{

					switch (filters.Action)
					{
						case Actions.INSERT:
							((List<ListModel>)DatasPw.listPwData[4].DATA).Add(new ListModel { Value = filters.Data[i].Value.ToString().Trim(), Index = (((List<ListModel>)DatasPw.listPwData[4].DATA).Count) });
							break;
						case Actions.DELETE:
							((List<ListModel>)DatasPw.listPwData[4].DATA).RemoveAt((filters.Data[i].Index));
							for (int x = 0; x < ((List<ListModel>)DatasPw.listPwData[4].DATA).Count; x++)
							{
								((List<ListModel>)DatasPw.listPwData[4].DATA)[x].Index = x;
							}
							break;
						default:
							break;
					}


				}
				tempRes0.Error = false;
				tempRes0.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes0.Error = false;
				tempRes0.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GfactiondService", "SetGfactiondFilter", ex.Message);
			}

			return tempRes0;
		}

	}

}
