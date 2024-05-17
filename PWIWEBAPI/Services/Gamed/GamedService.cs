using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
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
			}
			return tempRes;
		}

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGmServer(List<GamesysModel> gamesysModels)
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				//for (int i = 0; i < gamesysModels.Count; i++)
				//{
				//	for (int y = 0; y < DatasPw.DataGmServer.Count; y++)
				//	{

				//		if (DatasPw.DataGmServer[y].Title == gamesysModels[i].Title)
				//		{
				//			for (int x = 0; x < DatasPw.DataGmServer[y].Types.Count; x++)
				//			{
				//				for (int x1 = 0; x1 < gamesysModels[i].Types.Count; x1++)
				//				{
				//					if (DatasPw.DataGmServer[y].Types[x].Key == gamesysModels[i].Types[x1].Key)
				//					{
				//						DatasPw.DataGmServer[y].Types[x].Value = gamesysModels[i].Types[x1].Value;
				//					}
				//				}

				//			}
				//		}
				//	}
				//}

				DatasPw.listPwData[2].Write();
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

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGsalias(ActionData<List<GamesysModel>> gamesysModels)
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				//for (int i = 0; i < gamesysModels.Data.Count; i++)
				//{
				//	for (int y = 0; y < DatasPw.DataGsalia.Count; y++)
				//	{

				//		if (DatasPw.DataGsalia[y].Title == gamesysModels.Data[i].Title)
				//		{
				//			for (int x = 0; x < DatasPw.DataGsalia[y].Types.Count; x++)
				//			{
				//				for (int x1 = 0; x1 < gamesysModels.Data[i].Types.Count; x1++)
				//				{
				//					if (DatasPw.DataGsalia[y].Types[x].Key == gamesysModels.Data[i].Types[x1].Key)
				//					{
				//						switch (gamesysModels.Action)
				//						{
				//							case Actions.INSERT:
				//								if (DatasPw.DataGsalia[y].Types[x].Value.GetType() == typeof(string[]))
				//								{
				//									DatasPw.DataGsalia[y].Types[x].Value = ((string[])DatasPw.DataGsalia[y].Types[x].Value).addItensArray(string.Join(";", gamesysModels.Data[i].Types[x1].Value));
				//								}												
				//								break;
				//							case Actions.UPDATE:
				//								break;
				//							case Actions.DELETE:
				//								DatasPw.DataGsalia[y].Types[x].Value= ((string[])DatasPw.DataGsalia[y].Types[x].Value).removeItensArray(string.Join(";", gamesysModels.Data[i].Types[x1].Value));
				//								break;
				//							default:
				//								break;
				//						}									

				//					}
				//				}
				//				DatasPw.DataGsalia[y].OnInit();
				//			}
				//		}
				//	}
				//}3

				DatasPw.listPwData[3].Write();
				tempRes.Error = false;
				tempRes.Message = "Sucesse";
				tempRes.Data = null;
			}
			catch (Exception ex)
			{

				tempRes.Error = true;
				tempRes.Message = ex.Message;
				tempRes.Data = null;
			}

			return tempRes;
		}
	}

}
