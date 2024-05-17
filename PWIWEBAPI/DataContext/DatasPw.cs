using PWIWEBAPI.Logger;
using PWIWEBAPI.Models;
using PWIWEBAPI.Services.Glinkd;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PWIWEBAPI.DataContext
{
	public static class DatasPw
	{
		public static List<ListPwData>? listPwData;

		public static string glinkdFile = @"C:\xampp\htdocs\PWSERVER\glinkd\gamesys.conf";
		public static string gfactiondFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\gamesys.conf";
		public static string gfactiondFilterFile = @"C:\xampp\htdocs\PWSERVER\gfactiond\filters";

		public static string gamedGmServerFile = @"C:\xampp\htdocs\PWSERVER\gamed\gmserver.conf";
		private static string gamedGsaliasFile = @"C:\xampp\htdocs\PWSERVER\gamed\gsalias.conf";


		public static void StartAll()
		{
			SetLPD();
		}
		public static void SetLPD()
		{
			listPwData = new List<ListPwData>();
			listPwData.Add(new ListPwData { DATA = new List<GamesysModel>(), FILE = glinkdFile });
			listPwData.Add(new ListPwData { DATA = new List<GamesysModel>(), FILE = gfactiondFile });
			listPwData.Add(new ListPwData { DATA = new List<GamesysModel>(), FILE = gamedGmServerFile });
			listPwData.Add(new ListPwData { DATA = new List<GamesysModel>(), FILE = gamedGsaliasFile });
			listPwData.Add(new ListPwData { DATA = new List<ListModel>(), FILE = gfactiondFilterFile });

			for (int i = 0; i < listPwData.Count; i++)
			{
				listPwData[i].OnInit(i);

			}
		}
		public static List<GamesysModel> StartReadGamesysModel(string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1];
				_FILE = (new FileInfo(_FILE)).Extension != null ? _FILE.ToUpper() : _FILE.Replace((new FileInfo(file))?.Extension, null).ToUpper();

				List<GamesysModel> gamesysModels = new List<GamesysModel>();

				try
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.INIT, _NAME, _FILE);

					using (StreamReader sr = new StreamReader(file))
					{
						int it = -1;
						int xt = -1;
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine().Trim().Replace("\t", "").Replace(" ", "");

							if (!line.StartsWith("#") && !line.StartsWith(";"))
							{
								if (line.StartsWith("["))
								{
									it++;
									gamesysModels.Add(new GamesysModel { Title = line.Substring(1).Replace("]", ""), TitleIndex = it });
									xt = 0;
								}
								else
								{
									if (line != "")
									{
										string[] temps = line.Trim().Split('=');

										if (gamesysModels[it].Types == null)
										{
											gamesysModels[it].Types = new List<Types>();
										}

										object tempValue = null;


										if (temps[1].ToString().StartsWith("{"))
										{
											string xr = temps[1].ToString().Trim();
											string ins = "\t"; 

											if (xr.Contains("},{"))
											{
												ins = "\t,\t";
												xr = xr.Replace(",{", "{");
											}

											var ry = xr.Replace("{", "").Split("}").Cast<object>().ToArray();

											ry = ry.Where(x => (x != ",")&&(x != "")).Cast<object>().ToArray();


											tempValue = new InterString { StartString = "{", JoinString = ins, EndString = "}", Value = ry};
											
										}
										else if (temps[1].ToString().StartsWith("("))
										{
											string xr = temps[1].ToString().Trim();
											string ins = "\t";

											if (xr.Contains("),("))
											{
												ins = "\t,\t";
												xr = xr.Replace(",(", "(");
											}

											object[] ry = xr.Replace("(", "").Split(")").Cast<object>().ToArray();

											ry = ry.Where(x => (x != ",") && (x != "")).Cast<object>().ToArray();


											tempValue = new InterString { StartString = "(", JoinString = ins, EndString = ")", Value = ry };
										}
										else if (temps[1].Contains(";") && (!temps[1].Contains("(") && !temps[1].Contains("{")))
										{
											object ob = temps[1].Replace(" ", null).Split(";").Where(x => x != "").Cast<object>().ToArray();
											tempValue = new InterString {JoinString = ";" , Value = ob };
										}
										else if (temps[1].Contains(",") && (!temps[1].Contains("(") && !temps[1].Contains("{")))
										{
											object ob = temps[1].Replace(" ", null).Split(",").Where(x => x != "").Cast<object>().ToArray();
											tempValue = new InterString { JoinString = ",", Value = ob };
										}
										else
										{
											tempValue = new InterString { Value = (object)temps[1] } ;
										}


										gamesysModels[it].Types.Add(new Types { Key = temps[0], KeyIndex = xt, Value = tempValue });
										xt++;
										gamesysModels[it].OnInit();

									}
								}
							}
						}
						sr.Close();
					}

					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.FINISH, _NAME, _FILE);
				}
				catch (Exception ex)
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.ERROR, _NAME, _FILE, ex.Message);
					gamesysModels = null;
				}
				return gamesysModels;
			}
			return null;
		}

		public static void WriteGamesysModel(List<GamesysModel> gamesysModels, string file)
		{
			bool typesSet = false;
			for (int i = 0; i < gamesysModels.Count; i++)
			{
				if (gamesysModels[i].OnTypes())
				{
					typesSet = true;
					break;
				}

			}
			if (file != "" && !typesSet)
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1].Replace((new FileInfo(file)).Extension, null).ToUpper();

				try
				{
					if (gamesysModels != null)
					{
						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.INIT, _NAME, _FILE);
						string tempwriter = null;
						for (int i = 0; i < gamesysModels.Count; i++)
						{
							tempwriter += ($"{(i > 0 ? "\n" : "")}[{gamesysModels[i].Title}]\n");
							for (int x = 0; x < gamesysModels[i].Types.Count; x++)
							{
								var tp = gamesysModels[i].Types[x];

								if (((InterString)tp.Value).Value.GetType() == typeof(object[]))
								{
									var xs = (object[])((InterString)tp.Value).Value;

                                    for (int j = 0; j < xs.Length; j++)
                                    {
										xs[j] = $"{((InterString)tp.Value).StartString}{xs[j]}{((InterString)tp.Value).EndString}";

									}
                                    var tpValue = string.Join(((InterString)tp.Value).JoinString, xs) ;

									tempwriter += ($"{Extencions.PadRight(tp.Key, tp.Key.Length > 25 ? tp.Key.Length : 25)}=\t\t\t{tpValue}\n");
								}
								else
								{
									var xtx = (InterString)tp.Value;
									tempwriter += ($"{Extencions.PadRight(tp.Key, tp.Key.Length > 25 ? tp.Key.Length : 25)}=\t\t\t{xtx.Value}\n");
								}
							}
						}

						using (StreamWriter writer = new StreamWriter(file, false))
						{
							writer.Write(tempwriter);
							writer.Close();
						}

						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.FINISH, _NAME, _FILE);
					}
					else
					{
						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.ERROR, _NAME, _FILE, $"DataNull => {_FILE}");
					}

				}
				catch (Exception ex)
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.ERROR, _NAME, _FILE, ex.Message);
				}
			}
		}

		public static List<ListModel> StartReadListString(string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1];
				_FILE = (new FileInfo(_FILE)).Extension != null ? _FILE.ToUpper() : _FILE.Replace((new FileInfo(file)).Extension, null).ToUpper();

				List<ListModel> data = new List<ListModel>();

				try
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.INIT, _NAME, _FILE);

					using (StreamReader sr = new StreamReader(file))
					{
						int index = 0;
						while (!sr.EndOfStream)
						{
							string temp = sr.ReadLine();
							if (temp != "" && temp != null)
							{
								data.Add(new ListModel { Index = index, Value = temp.Trim() });
								index++;
							}
						}
						sr.Close();
					}

					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.FINISH, _NAME, _FILE);
				}
				catch (Exception ex)
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.READ, TypePostionLog.ERROR, _NAME, _FILE, ex.Message);
					data = null;
				}
				return data;
			}
			return null;
		}
		public static void WriteListModels(List<ListModel> listModels, string file)
		{
			if (file != "")
			{
				string _NAME = file.Split("\\")[file.Split("\\").Length - 2].ToUpper();
				string _FILE = file.Split("\\")[file.Split("\\").Length - 1].Replace((new FileInfo(file)).Extension, null).ToUpper();

				try
				{
					if (listModels != null)
					{
						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.INIT, _NAME, _FILE);

						using (StreamWriter writer = new StreamWriter(file, false))
						{
							for (int i = 0; i < listModels.Count; i++)
							{
								writer.WriteLine($"{listModels[i]}");
							}
							writer.Close();
						}

						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.FINISH, _NAME, _FILE);
					}
					else
					{
						Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.ERROR, _NAME, _FILE, $"DataNull => {_FILE}");
					}

				}
				catch (Exception ex)
				{
					Loggers.LogWriteLog(TypeLog.INFO, TypeActionLog.WRITE, TypePostionLog.ERROR, _NAME, _FILE, ex.Message);
				}
			}
		}
	}

	public class ListPwData
	{
		public int? INDEX { get; private set; }
		public object? DATA { get; set; }
		public string? FILE { get; set; }

		public void OnInit(int index)
		{
			if (FILE != "")
			{
				INDEX = index;

				if (DATA.GetType() == typeof(List<GamesysModel>))
				{
					DATA = DatasPw.StartReadGamesysModel(FILE);
				}
				else if (DATA.GetType() == typeof(List<ListModel>))
				{
					DATA = DatasPw.StartReadListString(FILE);
				}
			}

		}

		public void Write()
		{
			if (FILE != "")
			{
				if (DATA.GetType() == typeof(List<GamesysModel>))
				{
					DatasPw.WriteGamesysModel((List<GamesysModel>)DATA, FILE);
				}
				else if (DATA.GetType() == typeof(List<ListModel>))
				{
					DatasPw.WriteListModels((List<ListModel>)DATA, FILE);
				}
			}
		}
	}
}
