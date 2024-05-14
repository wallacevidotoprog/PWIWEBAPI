using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PWIWEBAPI.DataContext;

namespace PWIWEBAPI.Models
{
	public class GamesysModel
	{
		public string? Title { get; set; }
		public List<Types>? Types { get; set; }

		public string[] RetTs(bool all =true)
		{
			string[] temp = new string[Types.Count];
			if (all)
			{

				for (int i = 0; i < Types.Count; i++)
				{
					temp[i] = $"{Title}:{Types[i].RetA()}";
				}
			}
			else
			{

				for (int i = 0; i < Types.Count; i++)
				{
					temp[i] = $"{Title}:{Types[i].RetK()}";
				}
			}
			


            return temp;
		}

		public bool SetTypesValue(string key, string value)
		{
			if (Types.Contains(new Models.Types { Key = key }))
			{
				for (int i = 0; i < Types.Count; i++)
				{
					if (Types[i].Key == key)
					{
						Types[i].Value = value;
					}
				}
				return true;
			}
			return false;	
        }
	}	

	public class Types
	{
        public string? Key { get; set; }
		public string? Value { get; set; }

		public string RetK()
		{			
			return Key;
		}
		public string RetA()
		{
			return $"{Key}:{Value}";
		}
	}
}
