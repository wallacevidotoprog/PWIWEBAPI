using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Models;
using System.Linq;

namespace PWIWEBAPI.Services.Gfactiond
{
	public class GfactiondService : IGfactiond
	{
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond()
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				tempRes.Data = DatasPw.DataGfactiondGamesys;

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

		public async Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter()
		{
			ServiceResModel<List<ListModel>> tempRes = new ServiceResModel<List<ListModel>>();
			try
			{
				tempRes.Data = DatasPw.DataGfactiondFilter;

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

		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> WriteGfactiond(List<GamesysModel> gamesysModels)
		{
			ServiceResModel<List<GamesysModel>> tempRes = new ServiceResModel<List<GamesysModel>>();
			try
			{
				for (int i = 0; i < gamesysModels.Count; i++)
				{
					for (int y = 0; y < DatasPw.DataGfactiondGamesys.Count; y++)
					{

						if (DatasPw.DataGfactiondGamesys[y].Title == gamesysModels[i].Title)
						{
							for (int x = 0; x < DatasPw.DataGfactiondGamesys[y].Types.Count; x++)
							{
								for (int x1 = 0; x1 < gamesysModels[i].Types.Count; x1++)
								{
									if (DatasPw.DataGfactiondGamesys[y].Types[x].Key == gamesysModels[i].Types[x1].Key)
									{
										DatasPw.DataGfactiondGamesys[y].Types[x].Value = gamesysModels[i].Types[x1].Value;
									}
								}

							}
						}
					}
				}

				DatasPw.WriteGfactiondGamesys();
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

		public async Task<ActionResult<ServiceResModel<List<string>>>> WriteGfactiondFilter(ActionData<List<string>> filters)
		{

			ServiceResModel<List<bool>> tempRes = new ServiceResModel<List<bool>>();
			try
			{
				//for (int i = 0; i < filters.Data.Count; i++)
				//{
				//	switch (filters.Action)
				//	{
				//		case Actions.INSERT:

				//			DatasPw.DataGfactiondFilter.Add(filters.Data[i]);
				//			break;
				//		case Actions.UPDATE:
				//			break;
				//		case Actions.DELETE:
				//			DatasPw.DataGfactiondFilter.Remove(filters.Data[i]);
				//			break;
				//		default:
				//			break;
				//	}
				//}

				DatasPw.WriteGfactiondFilter();

				tempRes.Error = false;
				tempRes.Message = "Sucess";
			}
			catch (Exception ex)
			{
				tempRes.Data = null;
				tempRes.Error = false;
				tempRes.Message = ex.Message;
			}
           
			return null;
		}

	}

}
