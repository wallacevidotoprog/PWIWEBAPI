using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using System.Linq;

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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GetGfactiond", "Exception", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGfactiond()
		{
			var tempRes0 = new ServiceResModel<bool>();
			try
			{

				DatasPw.listPwData[1].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
				tempRes.Data = null;
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				tempRes.Data = null;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "WriteGfactiond", "Exception", ex.Message);
			}

			return tempRes0;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiond(ActionData<List<DataMod>> gamesysModels)
		{
			var tempRes0 = new ServiceResModel<bool>();
			try
			{
				for (int i = 0; i < gamesysModels.Data.Count; i++)
				{					
					switch (gamesysModels.Action)
					{
						case Actions.INSERT:
							
							((List<ListModel>)DatasPw.listPwData[1].DATA).Add(new ListModel { Value = (string)gamesysModels.Data[i].Values });
							break;
						case Actions.DELETE:
							for (int x = 0; x < ((List<ListModel>)DatasPw.listPwData[1].DATA).Count; x++)
							{

							}
							break;
						default:
							break;
					}
				}

				DatasPw.listPwData[1].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
				tempRes.Data = null;
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				tempRes.Data = null;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "SetGfactiond", "Exception", ex.Message);
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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GetGfactiondFilter", "Exception", ex.Message);
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
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "WriteGfactiondFilter", "Exception", ex.Message);
			}

			return null;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiondFilter(ActionData<List<DataMod>> filters)
		{
			throw new NotImplementedException();
		}

	}

}
