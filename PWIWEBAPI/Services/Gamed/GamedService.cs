using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using System.Linq;

namespace PWIWEBAPI.Services.Gamed
{
	public class GamedService : IGamed
	{
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGmServer()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[2].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "GetGmServer", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGmServer()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{
				DatasPw.listPwData[2].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "WriteGmServer", ex.Message);
			}

			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> SetGmServer()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{
				//DatasPw.listPwData[2].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "SetGmServer", ex.Message);
			}

			return tempRes;
		}



		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGsalia()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[3].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "GetGsalia", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGsalias()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{
				

				DatasPw.listPwData[3].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = true;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "WriteGsalias", ex.Message);
			}

			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> SetGsalias()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{
				//DatasPw.listPwData[3].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "SetGsalias", ex.Message);
			}

			return tempRes;
		}

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGs()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[5].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "GetGs", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGs()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{


				DatasPw.listPwData[5].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = true;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "WriteGs", ex.Message);
			}

			return tempRes;
		}

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetPtemplate()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = (List<GamesysModel>?)DatasPw.listPwData[6].DATA;

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "GetPtemplate", ex.Message);
			}
			return tempRes;
		}
		public async Task<ActionResult<ServiceResModel<bool>>> WritePtemplate()
		{
			ServiceResModel<bool> tempRes = new ServiceResModel<bool>();
			try
			{


				DatasPw.listPwData[6].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
			}
			catch (Exception ex)
			{

				tempRes.Error = true;
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "GamedService", "WritePtemplate", ex.Message);
			}

			return tempRes;
		}
	}

}
