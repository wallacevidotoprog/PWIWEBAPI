using static System.Reflection.Metadata.BlobBuilder;

namespace PWIWEBAPI
{
	public static class Extencions
	{

		public static object addItemArrays(this object[] obj, string newItem)
		{
			object[] newArr = new object[obj.Length + 1];

			for (int i = 0; i < obj.Length; i++)
			{
				newArr[i] = obj[i];
			}
			newArr[newArr.Length - 1] = newItem;

			return newArr;
		}
		public static object addItensArray(object[] obj, object newItem)
		{
			object[] tempO = newItem.ToString().Split(";").Cast<object>().ToArray();	
			object[] arr = obj.Concat(tempO).ToArray();
			return arr;
		}
		public static string[] removeItensArray(this string[] obj, string newItem)
		{
			string[] tempO = newItem.Split(';');

            for (int i = 0; i < tempO.Length; i++)
            {
				for (int x = 0; x < obj.Length; x++)
				{
					if (obj[x].ToString() == tempO[i].ToString())
					{
						obj[x] = "";
					}
				}
            }

			return obj.Where(x => x != "").ToArray();
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
