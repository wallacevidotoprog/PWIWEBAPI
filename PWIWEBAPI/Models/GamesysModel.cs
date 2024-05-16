using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PWIWEBAPI.DataContext;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace PWIWEBAPI.Models
{
	public class GamesysModel
	{
		public int? TitleIndex { get; set; }
		public string? Title { get; set; }
		public List<Types>? Types { get; set; }

		public void OnInit()
		{
			for (int i = 0; i < Types.Count; i++)
			{
				Types[i].OnInit();

			}
		}


	}
	public class Types
	{
		public int? KeyIndex { get; private set; }
		public string? Key { get; set; }
		public object? Value { get; set; }
		public object? IndexValue { get; set; }
		public object? TypeValue { get; private set; }
		public string? KeySpritValue { get;  set; }


		public void OnInit()
		{
			
			if (Value is not null)
			{
				if (Value.GetType() == typeof(object[]))
				{
					TypeValue = null;

					object[] array = (object[])Value;
					string tempAr = "";

					for (int i = 0; i < array.Length; i++)
					{
						if (int.TryParse(array[i].ToString(), out int numero))
						{
							tempAr += "int;";
						}
						else if (float.TryParse(array[i].ToString(), out float numeroF))
						{
							if (Regex.Matches(array[i].ToString(), ".").Count >= 3)
							{
								tempAr += "string;";
							}
							else
							{
								tempAr += "float;";
							}

						}
						else if (bool.TryParse(array[i].ToString(), out bool result))
						{
							tempAr += "bool;";
						}
						else
						{
							if (array[i].ToString().EndsWith("f"))
							{
								tempAr += "float;";
							}
							else
							{
								tempAr += "string;";
							}
						}
					}
					TypeValue = (object[])tempAr.Split(";").Where(x => x != "").ToArray();
					


				}
				else
				{
					if (int.TryParse(Value.ToString(), out int numero))
					{
						TypeValue = "int";
					}
					else if (float.TryParse(Value.ToString(), out float numeroF))
					{
						if (Regex.Matches(Value.ToString(), ".").Count >= 3)
						{
							TypeValue = "string";
						}
						else
						{
							TypeValue = "float";
						}
					}
					else if (bool.TryParse(Value.ToString(), out bool result))
					{
						TypeValue = "bool";
					}
					else
					{
						if (Value.ToString().EndsWith("f"))
						{
							TypeValue = "float";
						}
						else
						{
							TypeValue = "string";
						}

					}					
				}
				SetIndex();

			}
		}
		private void SetIndex()
		{
			if (Value is not null)
			{
				if (Value.GetType() == typeof(object[]))
				{
					object[] array = (object[])Value;
					IndexValue = new object[array.Length];
					for (int i = 0; i < ((object[])Value).Length; i++)
					{
						((object[])IndexValue)[i] = i;
					}
				}
				else
				{
					IndexValue = 0;
				}

			}
		} 

	}

	public class ListModel
	{
        public int Index { get; set; }
        public string Value { get; set; }
    }

}
