﻿using PWIWEBAPI.Services.Glinkd;
using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Services.Gfactiond;


namespace PWIWEBAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GfactiondController : Controller
	{
		private readonly IGfactiond _gfactiond;

		public GfactiondController(IGfactiond gfactiondService)
		{
			_gfactiond = gfactiondService;

		}
		#region GET
		[HttpGet]
		public async Task<ActionResult<ServiceResModel<List<GamesysModel>>>> GetGfactiond()=> await _gfactiond.GetGfactiond();

		[HttpGet("filters")]
		public async Task<ActionResult<ServiceResModel<List<ListModel>>>> GetGfactiondFilter() => await _gfactiond.GetGfactiondFilter();
		#endregion


		#region POST
		[HttpPost]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGfactiond()=> await _gfactiond.WriteGfactiond();
		
		[HttpPost("filters")]
		public async Task<ActionResult<ServiceResModel<bool>>> WriteGfactiondFilter() => await _gfactiond.WriteGfactiondFilter();
		#endregion


		#region PUT
		[HttpPut]
		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiond(ActionData<DataMod> gamesysModels) => await _gfactiond.SetGfactiond(gamesysModels);
		[HttpPut("filters")]
		public async Task<ActionResult<ServiceResModel<bool>>> SetGfactiondFilter(ActionData<List<ListModel>> filter) => await _gfactiond.SetGfactiondFilter(filter);
		#endregion

	}
}
		
	


