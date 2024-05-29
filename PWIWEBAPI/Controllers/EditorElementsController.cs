using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.sElement;
using PWIWEBAPI.Services;
using PWIWEBAPI.Services.Editor.Elements;

namespace PWIWEBAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EditorElementsController : Controller
	{
        private readonly IElements _elements;
        public EditorElementsController(IElements elements)=> _elements = elements;

		[HttpGet("GetListName")]
		public async Task<ActionResult<ServiceResModel<Dictionary<int, string>>>> GetListName() => await _elements.GetListName();

		[HttpGet("GetGetElement")]
		public async Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetElement(int selectedIndex) => await _elements.GetElement(selectedIndex);
		[HttpGet("GetGetValues")]
		public async Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetValues(int selectedIndex, int selectedElement) => await _elements.GetValues(selectedIndex, selectedElement);

		[HttpPost("SetValue")]
		public async Task<ActionResult<ServiceResModel<bool>>> SetValue(int selectedIndex, int selectedElement, int selectedField, string value)=> await _elements.SetValue(selectedIndex, selectedElement, selectedField, value);
		[HttpPost("NewItem")]
		public async Task<ActionResult<ServiceResModel<bool>>> NewItem(int selectedIndex)=> await _elements.NewItem(selectedIndex);

		[HttpPost("DupeItem")]
		public async Task<ActionResult<ServiceResModel<bool>>> DupeItem(int selectedIndex, int selectedElement) => await _elements.DupeItem(selectedIndex, selectedElement);

		[HttpDelete("DeleteItem")]
		public async Task<ActionResult<ServiceResModel<bool>>> DeleteItem(int selectedIndex, int selectedElement)=> await _elements.DeleteItem(selectedIndex, selectedElement);

	}
}
