using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services.Glinkd;
using System.Text;

namespace PWIWEBAPI.DataContext
{
	public static class DatasPw
	{
		private static string glinkdFile = @"C:\xampp\htdocs\PWSERVER\glinkd\gamesys.conf";
		private static string gfactiondFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\gamesys.conf";
		private static string gfactiondFilterFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\filters";

		public static List<GamesysModel> DataGlinkdGamesys;
		public static List<GamesysModel> DataGfactiondGamesys;
		public static List<string> DataGfactiondFilter;


		public static void StartAll()
		{
			StartGlinkdGamesys();
			StartGfactiondGamesys();

		}
		#region Glinkd
		public static void StartGlinkdGamesys()
		{
			try
			{
				Loggers.LogWrite($"Glinkd - {DateTime.Now} - Init - StartGlinkdGamesys");

				DataGlinkdGamesys = new List<GamesysModel>();

				using (StreamReader sr = new StreamReader(glinkdFile))
				{
					int it = -1;
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();

						if (!line.StartsWith("#"))
						{
							if (line.StartsWith("["))
							{
								DataGlinkdGamesys.Add(new GamesysModel { Title = line.Substring(1).Replace("]", "") });
								it++;
							}
							else
							{
								if (line != "")
								{
									string[] temps = line.Replace("\t", "").Split('=');

									if (DataGlinkdGamesys[it].Types == null)
									{
										DataGlinkdGamesys[it].Types = new List<Types>();

									}
									DataGlinkdGamesys[it].Types.Add(new Types { Key = temps[0], Value = temps[1] });

								}
							}
						}
					}
				}

				Loggers.LogWrite($"Glinkd - {DateTime.Now} - Finish - StartGlinkdGamesys");
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Glinkd - {DateTime.Now} - Error read - StartGlinkdGamesys => {ex.Message}");
				DataGlinkdGamesys = null;
			}
		}
		public static void WriteGlinkdGamesys()
		{
			try
			{
				if (DataGlinkdGamesys != null)
				{
					Loggers.LogWrite($"Glinkd - {DateTime.Now} - Init -  WriteGlinkdGamesys");
					using (StreamWriter writer = new StreamWriter(glinkdFile,false))
					{

						foreach (var item in DataGlinkdGamesys)
						{
							writer.WriteLine($"[{item.Title}]");

							foreach (var tp in item.Types)
							{
								writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{tp.Value}");
							}
							writer.WriteLine($"\n");
						}
					}

					Loggers.LogWrite($"Glinkd - {DateTime.Now} - Finish  - WriteGlinkdGamesys  - {glinkdFile}");
				}
				else
				{
					Loggers.LogWrite($"Glinkd - {DateTime.Now} - DataGlinkd is null - WriteGlinkdGamesys");
				}
				
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Glinkd - {DateTime.Now} - Error write - WriteGlinkdGamesys => {ex.Message}");
			}
		}
		#endregion

		#region Gfactiond
		public static void StartGfactiondGamesys()
		{
			try
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init - StartGfactiondGamesys");

				DataGfactiondGamesys = new List<GamesysModel>();

				using (StreamReader sr = new StreamReader(gfactiondFile))
				{
					int it = -1;
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();

						if (!line.StartsWith("#"))
						{
							if (line.StartsWith("["))
							{
								DataGfactiondGamesys.Add(new GamesysModel { Title = line.Substring(1).Replace("]", "") });
								it++;
							}
							else
							{
								if (line != "")
								{
									string[] temps = line.Replace("\t", "").Split('=');

									if (DataGfactiondGamesys[it].Types == null)
									{
										DataGfactiondGamesys[it].Types = new List<Types>();

									}
									DataGfactiondGamesys[it].Types.Add(new Types { Key = temps[0], Value = temps[1] });

								}
							}
						}
					}
				}

				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish - StartGfactiondGamesys");
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Error read - StartGfactiondGamesys => {ex.Message}");
				DataGlinkdGamesys = null;
			}
		}
		public static void StartGfactiondFilter()
		{
			try
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init - StartGfactiondFilter");

				DataGfactiondFilter = new List<string>();

				using (StreamReader sr = new StreamReader(gfactiondFilterFile))
				{
					while (!sr.EndOfStream)
					{
						DataGfactiondFilter.Add(sr.ReadLine());

					}
				}
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish - StartGfactiondFilter");
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Error read - StartGfactiondFilter => {ex.Message}");
				DataGfactiondFilter = null;
			}
		}
		public static void WriteGfactiondGamesys()
		{
			try
			{
				if (DataGfactiondGamesys != null)
				{
					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init -  WriteGfactiondGamesys" );
					using (StreamWriter writer = new StreamWriter(gfactiondFile, false))
					{

						foreach (var item in DataGfactiondGamesys)
						{
							writer.WriteLine($"[{item.Title}]");

							foreach (var tp in item.Types)
							{
								writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{tp.Value}");
							}
							writer.WriteLine($"\n");
						}
					}

					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish  - WriteGfactiondGamesys  - {gfactiondFile}");
				}
				else
				{
					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - DataGlinkd is null - WriteGfactiondGamesys");
				}

			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Error write - WriteGfactiondGamesys => {ex.Message}");
			}
		}
		public static void WriteGfactiondFilter()
		{
			try
			{
				if (DataGfactiondFilter != null)
				{
					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init -  WriteGfactiondFilter");
					using (StreamWriter writer = new StreamWriter(gfactiondFilterFile, false))
					{
						for (int i = 0; i < DataGfactiondFilter.Count; i++)
						{
							writer.WriteLine($"{DataGfactiondFilter[i]}");
						}
					}

					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish  - WriteGfactiondFilter  - {gfactiondFile}");
				}
				else
				{
					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - DataGlinkd is null - WriteGfactiondFilter");
				}

			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Error write - WriteGfactiondFilter => {ex.Message}");
			}
		}
		#endregion
	}
}
