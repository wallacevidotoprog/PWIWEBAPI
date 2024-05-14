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
				tempRes.Data = DatasPw.DataGlinkdGamesys;

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
				for (int i = 0; i < gamesysModels.Count; i++)
				{
					for (int y = 0; y < DatasPw.DataGlinkdGamesys.Count; y++)
					{

						if (DatasPw.DataGlinkdGamesys[y].Title == gamesysModels[i].Title)
						{
							for (int x = 0; x < DatasPw.DataGlinkdGamesys[y].Types.Count; x++)
							{
								for (int x1 = 0; x1 < gamesysModels[i].Types.Count; x1++)
								{
									if (DatasPw.DataGlinkdGamesys[y].Types[x].Key == gamesysModels[i].Types[x1].Key)
									{
										DatasPw.DataGlinkdGamesys[y].Types[x].Value = gamesysModels[i].Types[x1].Value;
									}
								}

							}
						}
					}
				}

				DatasPw.WriteGlinkdGamesys();
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
