using PWIWEBAPI.Models;
using System.Linq;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace PWIWEBAPI
{
	public static class Extencions
	{
		public static object addItensArray(object[] obj, object newItem)
		{
			object[] tempO = null;
			if (newItem.GetType() == typeof(object[]))
			{
				tempO = newItem.ToString().Split().Cast<object>().ToArray();
			}
			else
			{
				tempO = newItem.ToString().Split(";").Cast<object>().ToArray();
			}

			object[] arr = obj.Concat(tempO).ToArray().Where(x => x != null).Cast<object>().ToArray();
			return arr;
		}
		public static object addItemArray(object[] obj, object newItem)
		{
			object[]  temp = { newItem };
			object[] arr = obj.Concat(temp).ToArray().Where(x => x != null).Cast<object>().ToArray();
			return arr;
		}
		public static object[] removeItensArray(object[] obj, object newItem)
		{
			object[] tempO = null;
			if (newItem.GetType() != typeof(object[]))
			{
				tempO = newItem.ToString().Split().Cast<object>().ToArray();
			}
			for (int i = 0; i < tempO.Length; i++)
			{

				for (int x = 0; x < obj.Length; x++)
				{
					string xt = tempO[i].ToString();
					string tx = obj[x].ToString();
					if (obj[x].ToString() == tempO[i].ToString())
					{
						obj[x] = null;
					}
				}

			}
			return (object[])obj.Where(x => x != null).Cast<object>().ToArray();
		}

		public static string PadRight(string text, int totalWidth)
		{
			if (text.Length >= totalWidth)
			{
				return text.Substring(0, totalWidth);
			}
			return text.PadRight(totalWidth);
		}

		public static object[] Return(this JsonElement objJe)
		{
			return JsonSerializer.Deserialize<object[]>(objJe.ToString()).Select(x => x.ToString()).Cast<object>().ToArray();
		}


		public static InterString SetComma(InterString _is)
		{
			if (_is.Value.GetType()== typeof(object[]))
			{
                for (int i = 0; i < ((object[])_is.Value).Length; i++)
                {
					if (((object[])_is.Value)[i].ToString().Contains(","))
					{
						((object[])_is.Value)[i] = ((object[])_is.Value)[i].ToString().Split(",").Cast<object>().ToArray();
					}
                }
            }
			else
			{
				if (_is.Value.ToString().Contains(","))
				{
					_is.Value = ((object[])_is.Value).ToString().Split(",").Cast<object>().ToArray();
				}
			}
			
			return _is;
		}

		public static string GetComma(object obj)
		{
			string temp = null;
			if (obj.GetType() == typeof(object[]))
			{
				temp = string.Join(",", (object[])obj);
			}
			else
			{
				temp = obj.ToString();
			}
			return obj.GetType() == typeof(object[])? string.Join(",", (object[])obj): obj.ToString();
		}

		public static object RemoveNullString(object obj)
		{
			object[] tempO = null;

			if (obj.GetType() == typeof(object[]))
			{
				for (int i = 0; i < ((object[])obj).Length; i++)
				{
					((object[])obj)[i] = ((object[])obj)[i].ToString().Trim().Replace(" ", null);
				}
			}
			else
			{
				obj = ((object)obj).ToString().Trim().Replace(" ", null);
			}

			return obj;
		}
	}
}
