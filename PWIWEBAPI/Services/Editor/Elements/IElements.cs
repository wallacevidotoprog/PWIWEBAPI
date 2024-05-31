using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.sElement;

namespace PWIWEBAPI.Services.Editor.Elements
{
	public interface IElements
	{
		Task<ActionResult<ServiceResModel<eList[]>>> GetAllElements();

		Task<ActionResult<ServiceResModel<Dictionary<int, string>>>> GetListName();
		Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetElement(int selectedIndex);
		Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetValues(int selectedIndex,int selectedElement);

		Task<ActionResult<ServiceResModel<bool>>> SetValue(int selectedIndex, int selectedElement, int selectedField, string value);

		Task<ActionResult<ServiceResModel<bool>>> DupeItem(int selectedIndex, int selectedElement);

		Task<ActionResult<ServiceResModel<bool>>> DeleteItem(int selectedIndex, int selectedElement);

	}
}
