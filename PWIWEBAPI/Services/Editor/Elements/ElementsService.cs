using Microsoft.AspNetCore.Mvc;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.sElement;
using System.ComponentModel;

namespace PWIWEBAPI.Services.Editor.Elements
{
	public class ElementsService : IElements
	{

		public async Task<ActionResult<ServiceResModel<eList[]>>> GetAllElements()
		{
			try
			{
				return new ServiceResModel<eList[]> { Data = DatasPw.eList.Lists, Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "GetAllElements", ex.Message);
				return new ServiceResModel<eList[]> { Data = null, Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetElement(int selectedIndex)
		{
			try
			{
				Dictionary<int, string[]> temp = new Dictionary<int, string[]>();

				int indexName = Array.IndexOf(DatasPw.eList.Lists[selectedIndex].elementFields, "Name");

				for (int i = 0; i < DatasPw.eList.Lists[selectedIndex].elementValues.Length; i++)
				{
					temp.Add(i, new string[] { DatasPw.eList.GetValue(selectedIndex, i, 0), DatasPw.eList.GetValue(selectedIndex, i, indexName) });
				}


				return new ServiceResModel<Dictionary<int, string[]>> { Data = temp, Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "GetListName", ex.Message);
				return new ServiceResModel<Dictionary<int, string[]>> { Data = null, Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<Dictionary<int, string>>>> GetListName()
		{
			try
			{
				Dictionary<int, string> temp = new Dictionary<int, string>();

				for (int i = 0; i < DatasPw.eList.Lists.Length; i++)
				{
					temp.Add(i, DatasPw.eList.Lists[i].listName);

				}
				return new ServiceResModel<Dictionary<int, string>> { Data = temp, Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "GetListName", ex.Message);
				return new ServiceResModel<Dictionary<int, string>> { Data = null, Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<Dictionary<int, string[]>>>> GetValues(int selectedIndex, int selectedElement)
		{
			try
			{
				Dictionary<int, string[]> temp = new Dictionary<int, string[]>();

				for (int i = 0; i < DatasPw.eList.Lists[selectedIndex].elementValues[selectedElement].Length; i++)
				{
					temp.Add(i, new string[] { DatasPw.eList.Lists[selectedIndex].elementFields[i], DatasPw.eList.Lists[selectedIndex].elementTypes[i], DatasPw.eList.GetValue(selectedIndex, selectedElement, i) });
				}

				return new ServiceResModel<Dictionary<int, string[]>> { Data = temp, Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "GetListName", ex.Message);
				return new ServiceResModel<Dictionary<int, string[]>> { Data = null, Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> NewItem(int selectedIndex)
		{
			try
			{



				return new ServiceResModel<bool> { Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "DupeItem", ex.Message);
				return new ServiceResModel<bool> { Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> DupeItem(int selectedIndex, int selectedElement)
		{
			try
			{
				object[] o = new object[DatasPw.eList.Lists[selectedIndex].elementValues[selectedElement].Length];
				DatasPw.eList.Lists[selectedIndex].elementValues[selectedElement].CopyTo(o, 0);
				DatasPw.eList.Lists[selectedIndex].AddItem(o);


				return new ServiceResModel<bool> { Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "DupeItem", ex.Message);
				return new ServiceResModel<bool> { Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> SetValue(int selectedIndex, int selectedElement, int selectedField, string value)
		{
			try
			{
				DatasPw.eList.SetValue(selectedIndex, selectedElement, selectedField, value);


				return new ServiceResModel<bool> { Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "SetValue", ex.Message);
				return new ServiceResModel<bool> { Error = true, Message = ex.Message };
			}
			return null;
		}

		public async Task<ActionResult<ServiceResModel<bool>>> DeleteItem(int selectedIndex, int selectedElement)
		{
			try
			{
				DatasPw.eList.Lists[selectedIndex].RemoveItem(selectedElement);

				return new ServiceResModel<bool> { Error = false, Message = null };

			}
			catch (Exception ex)
			{
				Loggers.LogWriteLog(TypeLog.WARNING, TypeActionLog.EXECUTE, TypePostionLog.ERROR, "ElementsService", "DeleteItem", ex.Message);
				return new ServiceResModel<bool> { Error = true, Message = ex.Message };
			}
			return null;
		}
	}
}
