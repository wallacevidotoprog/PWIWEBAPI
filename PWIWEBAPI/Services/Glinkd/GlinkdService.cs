using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Models;
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
					//var tep = (object[])gamesysModels[i]?.Data.Values;
					if (gamesysModels[i].Data.Values.GetType() == typeof(object[]))
					{
						for (int x = 0; x < ((object[])gamesysModels[i].Data.Values).Length; x++)
						{
							((GamesysModel)((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels[i].Data.Id_tile])
								.ActionValues(Actions.INSERT, gamesysModels[i].Data.Id_key, ((object[])gamesysModels[i].Data.Values));

						}
					}
					else
					{
						((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels[i].Data.Id_tile]
								.ActionValues(Actions.INSERT, gamesysModels[i].Data.Id_key, gamesysModels[i].Data.Values);
					}

				}
				//var x = ((List<GamesysModel>)DatasPw.listPwData[0].DATA)[gamesysModels];


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
