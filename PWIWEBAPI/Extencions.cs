using System.Linq;
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
				tempO = newItem.ToString().Split(";").Cast<object>().ToArray();
			}
			else
			{
				tempO = newItem.ToString().Split().Cast<object>().ToArray();
			}

			object[] arr = obj.Concat(tempO).ToArray().Where(x => x != null).Cast<object>().ToArray();
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
	}
}
