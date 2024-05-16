using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services.Glinkd;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PWIWEBAPI.DataContext
{
	public static class DatasPw
	{
		private static string glinkdFile = @"C:\xampp\htdocs\PWSERVER\glinkd\gamesys.conf";
		private static string gfactiondFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\gamesys.conf";
		private static string gfactiondFilterFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\filters";

		private static string gamedGmServerFile = @"C:\xampp\htdocs\PWSERVER\gamed\gmserver.conf";
		private static string gamedGsaliasFile = @"C:\xampp\htdocs\PWSERVER\gamed\gsalias.conf";

		public static List<GamesysModel>? DataGlinkdGamesys;
		public static List<GamesysModel>? DataGfactiondGamesys;
		public static List<ListModel>? DataGfactiondFilter;
		public static List<GamesysModel>? DataGmServer;
		public static List<GamesysModel>? DataGsalia;


		public static void StartAll()
		{
			DataGlinkdGamesys = StartReadGamesysModel(glinkdFile);
			DataGfactiondGamesys = StartReadGamesysModel(gfactiondFile);
			DataGmServer = StartReadGamesysModel(gamedGmServerFile);
			DataGsalia = StartReadGamesysModel(gamedGsaliasFile);

			DataGfactiondFilter = StartReadListString(gfactiondFilterFile);
			//StartGlinkdGamesys();
			//StartGfactiondGamesys();
			//StartGfactiondFilter();
			//StartGmServer();
			//StartGsalias();
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
						string line = sr.ReadLine().Trim().Replace("\t", "").Replace(" ", "");

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
									DataGlinkdGamesys[it].OnInit();
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
					using (StreamWriter writer = new StreamWriter(glinkdFile, false))
					{

						foreach (var item in DataGlinkdGamesys)
						{
							writer.WriteLine($"[{item.Title}]");

							foreach (var tp in item.Types)
							{
								//writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{tp.Value}");

								writer.WriteLine($"{Extencions.PadRight(tp.Key, 25)}=\t\t\t{tp.Value}");
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
			//try
			//{
			//	Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init - StartGfactiondFilter");

			//	DataGfactiondFilter = new List<string>();

			//	using (StreamReader sr = new StreamReader(gfactiondFilterFile))
			//	{
			//		while (!sr.EndOfStream)
			//		{
			//			DataGfactiondFilter.Add(sr.ReadLine());

			//		}
			//	}
			//	Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish - StartGfactiondFilter");
			//}
			//catch (Exception ex)
			//{
			//	Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Error read - StartGfactiondFilter => {ex.Message}");
			//	DataGfactiondFilter = null;
			//}
		}
		public static void WriteGfactiondGamesys()
		{
			try
			{
				if (DataGfactiondGamesys != null)
				{
					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Init -  WriteGfactiondGamesys");
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

					Loggers.LogWrite($"Gfactiond - {DateTime.Now} - Finish  - WriteGfactiondFilter  - {gfactiondFilterFile}");
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

		#region Gamed
		public static void StartGmServer()
		{
			try
			{
				Loggers.LogWrite($"GmServer - {DateTime.Now} - Init - StartGmServer");

				DataGmServer = new List<GamesysModel>();

				using (StreamReader sr = new StreamReader(gamedGmServerFile))
				{
					int it = -1;
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine().Trim().Replace("\t", "").Replace(" ", "");

						if (!line.StartsWith("#") && !line.StartsWith(";"))
						{
							if (line.StartsWith("["))
							{
								it++;
								DataGmServer.Add(new GamesysModel { Title = line.Substring(1).Replace("]", ""), TitleIndex = it });

							}
							else
							{
								if (line != "")
								{
									string[] temps = line.Split('=');

									if (DataGmServer[it].Types == null)
									{
										DataGmServer[it].Types = new List<Types>();
									}

									object tempValue = null;
									string tempSplit = null;

									if (temps[1].Contains(";"))
									{
										tempValue = temps[1].Replace(" ", null).Split(";").Where(x => x != "").ToArray();
										tempSplit = ";";
									}
									else if (temps[1].Contains(","))
									{
										tempValue = temps[1].Replace(" ", null).Split(",").Where(x => x != "").ToArray();
										tempSplit = ",";
									}
									else
									{
										tempValue = temps[1];
									}
									DataGmServer[it].Types.Add(new Types { Key = temps[0], Value = tempValue, KeySpritValue = tempSplit });
									DataGmServer[it].OnInit();
									//string[] temps = line.Replace("\t", "").Split('=');

									//if (DataGmServer[it].Types == null)
									//{
									//	DataGmServer[it].Types = new List<Types>();

									//}
									//DataGmServer[it].Types.Add(new Types { Key = temps[0], Value = temps[1] });
									// DataGmServer[it].OnInit();
								}
							}
						}
					}
				}

				Loggers.LogWrite($"GmServer - {DateTime.Now} - Finish - StartGmServer");
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"GmServer - {DateTime.Now} - Error read - StartGmServer => {ex.Message}");
				DataGmServer = null;
			}
		}
		public static void WriteGmServer()
		{
			try
			{
				if (DataGmServer != null)
				{
					Loggers.LogWrite($"GmServer - {DateTime.Now} - Init -  WriteGmServer");
					using (StreamWriter writer = new StreamWriter(gamedGmServerFile, false))
					{

						foreach (var item in DataGmServer)
						{
							writer.WriteLine($"[{item.Title}]");

							foreach (var tp in item.Types)
							{
								writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{tp.Value}");
							}
							writer.WriteLine($"\n");
						}
					}

					Loggers.LogWrite($"GmServer - {DateTime.Now} - Finish  - WriteGmServer  - {gamedGmServerFile}");
				}
				else
				{
					Loggers.LogWrite($"GmServer - {DateTime.Now} - DataGlinkd is null - WriteGmServer");
				}

			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"GmServer - {DateTime.Now} - Error write - WriteGmServer => {ex.Message}");
			}
		}
		#endregion

		#region gsalias
		public static void StartGsalias()
		{
			try
			{
				Loggers.LogWrite($"Gsalia - {DateTime.Now} - Init - StartGsalias");

				DataGsalia = new List<GamesysModel>();

				using (StreamReader sr = new StreamReader(gamedGsaliasFile))
				{
					int it = -1;
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine().Trim().Replace("\t", "").Replace(" ", "");

						if (!line.StartsWith("#"))
						{
							if (line.StartsWith("["))
							{
								DataGsalia.Add(new GamesysModel { Title = line.Substring(1).Replace("]", "") });
								it++;
							}
							else
							{
								if (line != "")
								{
									string[] temps = line.Split('=');

									if (DataGsalia[it].Types == null)
									{
										DataGsalia[it].Types = new List<Types>();
									}

									object tempValue = null;
									string tempSplit = null;

									if (temps[1].Contains(";"))
									{
										tempValue = temps[1].Replace(" ", null).Split(";").Where(x => x != "").ToArray();
										tempSplit = ";";
									}
									else if (temps[1].Contains(";"))
									{
										tempValue = temps[1].Replace(" ", null).Split(",").Where(x => x != "").ToArray();
										tempSplit = ",";
									}
									else
									{
										tempValue = temps[1];
									}
									DataGsalia[it].Types.Add(new Types { Key = temps[0], Value = tempValue, KeySpritValue = tempSplit });
									DataGsalia[it].OnInit();

								}
							}
						}
					}
				}

				Loggers.LogWrite($"Gsalia - {DateTime.Now} - Finish - StartGsalias");
			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gsalia - {DateTime.Now} - Error read - StartGsalias => {ex.Message}");
				DataGsalia = null;
			}
		}
		public static void WriteGsalias()
		{
			try
			{
				if (DataGsalia != null)
				{
					Loggers.LogWrite($"Gsalias - {DateTime.Now} - Init -  WriteGsalias");

					using (StreamWriter writer = new StreamWriter(gamedGsaliasFile, false))
					{

						foreach (var item in DataGsalia)
						{
							writer.WriteLine($"[{item.Title}]");

							foreach (var tp in item.Types)
							{
								if (tp.Value.GetType() == typeof(string[]))
								{
									string temp = string.Join(tp.KeySpritValue, (string[])tp.Value);
									writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{temp}");
								}
								else
								{
									writer.WriteLine($"{tp.Key}\t\t\t=\t\t\t{tp.Value}");
								}
							}
							writer.WriteLine($"\n");
						}
					}

					Loggers.LogWrite($"Gsalias - {DateTime.Now} - Finish  - WriteGsalias  - {gamedGsaliasFile}");
				}
				else
				{
					Loggers.LogWrite($"Gsalias - {DateTime.Now} - DataGlinkd is null - WriteGsalias");
				}

			}
			catch (Exception ex)
			{
				Loggers.LogWrite($"Gsalias - {DateTime.Now} - Error write - WriteGsalias => {ex.Message}");
			}
		}
		#endregion

		public static List<GamesysModel> StartReadGamesysModel(string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1].Replace((new FileInfo(file)).Extension, null).ToUpper();

				List<GamesysModel> gamesysModels = new List<GamesysModel>();

				try
				{
					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - INIT - START_READ_{_NAME}_{_FILE}");

					using (StreamReader sr = new StreamReader(file))
					{
						int it = -1;
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine().Trim().Replace("\t", "").Replace(" ", "");

							if (!line.StartsWith("#"))
							{
								if (line.StartsWith("["))
								{
									it++;
									gamesysModels.Add(new GamesysModel { Title = line.Substring(1).Replace("]", ""), TitleIndex = it });
								}
								else
								{
									if (line != "")
									{
										string[] temps = line.Split('=');

										if (gamesysModels[it].Types == null)
										{
											gamesysModels[it].Types = new List<Types>();
										}

										object tempValue = null;
										string tempSplit = null;

										if (temps[1].Contains(";"))
										{
											tempValue = temps[1].Replace(" ", null).Split(";").Where(x => x != "").Cast<object>().ToArray();
											tempSplit = ";";
										}
										else if (temps[1].Contains(";"))
										{
											tempValue = temps[1].Replace(" ", null).Split(",").Where(x => x != "").Cast<object>().ToArray();
											tempSplit = ",";
										}
										else
										{
											tempValue = temps[1];
										}
										gamesysModels[it].Types.Add(new Types { Key = temps[0], Value = tempValue, KeySpritValue = tempSplit });
										gamesysModels[it].OnInit();

									}
								}
							}
						}
					}

					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - FINISH - START_READ_{_NAME}_{_FILE}");
				}
				catch (Exception ex)
				{
					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - ERROR - START_READ_{_NAME}_{_FILE} => {ex.Message}");
					gamesysModels = null;
				}
				return gamesysModels;
			}
			return null;
		}

		public static void WriteGamesysModel(List<GamesysModel> gamesysModels, string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1].Replace((new FileInfo(file)).Extension, null).ToUpper();

				try
				{
					if (gamesysModels != null)
					{
						Loggers.LogWrite($"{_NAME} - {DateTime.Now} - INIT - WRITE_READ_{_NAME}_{_FILE}");

						using (StreamWriter writer = new StreamWriter(file, false))
						{
							foreach (var item in gamesysModels)
							{
								writer.WriteLine($"[{item.Title}]");

								foreach (var tp in item.Types)
								{
									if (tp.Value.GetType() == typeof(object[]))
									{
										string temp = string.Join(tp.KeySpritValue, (string[])tp.Value);

										writer.WriteLine($"{Extencions.PadRight(tp.Key, tp.Key.Length > 25 ? tp.Key.Length : 25)}=\t\t\t{tp.Value}");
									}
									else
									{
										writer.WriteLine($"{Extencions.PadRight(tp.Key, tp.Key.Length > 25 ? tp.Key.Length : 25)}=\t\t\t{tp.Value}");
									}
								}
								writer.WriteLine($"\n");
							}
						}

						Loggers.LogWrite($"{_NAME} - {DateTime.Now} - FINISH - WRITE_READ_{_NAME}_{_FILE}");
					}
					else
					{
						Loggers.LogWrite($"{_NAME} - {DateTime.Now} - DATANULL - WRITE_READ_{_NAME}_{_FILE}");
					}

				}
				catch (Exception ex)
				{
					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - ERROR - WRITE_READ_{_NAME}_{_FILE}  => {ex.Message}");
				}
			}
		}

		public static List<ListModel> StartReadListString(string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1];//.Replace((new FileInfo(file))?.Extension, null).ToUpper();

				_FILE = (new FileInfo(_FILE)).Extension != null ? _FILE.ToUpper() : _FILE.Replace((new FileInfo(file))?.Extension, null).ToUpper();

				List<ListModel> data = new List<ListModel>();

				try
				{
					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - INIT - START_READ_{_NAME}_{_FILE}");

					using (StreamReader sr = new StreamReader(file))
					{
						int index = 0;
						while (!sr.EndOfStream)
						{
							if (sr.ReadLine() != "")
							{
								data.Add(new ListModel { Index = index, Value = sr.ReadLine().Trim() });
								index++;
							}
						}
					}

					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - FINISH - START_READ_{_NAME}_{_FILE}");
				}
				catch (Exception ex)
				{
					Loggers.LogWrite($"{_NAME} - {DateTime.Now} - ERROR - START_READ_{_NAME}_{_FILE} => {ex.Message}");
					data = null;
				}
				return data;
			}
			return null;
		}
	}
}
