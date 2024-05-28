using PWIWEBAPI.Models;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PWIWEBAPI.Logger
{
	public static class Loggers
	{
		public static string dir = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "log";
		public static string fileLog = Path.Combine(dir, "LogAPIPW.log");
		public static void InitLogger()
		{
			DirectoryInfo tempDirs = Directory.CreateDirectory(dir);
			File.Delete(fileLog);
			LogWrite($"# => LOG PWAPI  {DateTime.Now} ");
		}

		public static void LogWrite(string msg)
		{
			if (!File.Exists(fileLog))
			{
				using (TextWriter tw = new StreamWriter(fileLog, false, Encoding.Default))
				{
					tw.Close();
				}
			}
			using (StreamWriter sw = File.AppendText(fileLog))
			{
				sw.WriteLine(msg);
			}
		}
		public static void LogWriteLog(TypeLog typeLog, TypeActionLog typeActionLog, TypePostionLog typePostionLog, string title, string nameFile, string msgErr = null)
		{
			string temp = $"{typeActionLog.ToString()}_{title}_{nameFile}";

			string msg = $"{Extencions.PadRight(title.ToUpper(), title.Length > 15 ? title.Length : 15)}" +
				$"-\t\t" +
				$"{Extencions.PadRight(DateTime.Now.ToString(), 19)}" +
				$"\t\t-\t\t" +
				$"{Extencions.PadRight(typePostionLog.ToString(), typePostionLog.ToString().Length > 10 ? typePostionLog.ToString().Length : 10)}" +
				$"-\t\t" +
				$"{Extencions.PadRight(temp, temp.Length > 35 ? temp.Length : 35)}";

			if (msgErr != null)
			{
				msg += $"-\t\t{msgErr}";
			}
			LogWrite(msg);
		}

		public static async Task<List<string[]>> LogGet()
		{
			List<string[]> tempLog = null;
			if (File.Exists(fileLog))
			{
				tempLog = new List<string[]>();
				using (StreamReader sr = new StreamReader(fileLog))
				{
					while (!sr.EndOfStream)
					{
						string temp = sr.ReadLine();
						if (temp != "" && temp != null)
						{
							tempLog.Add(temp.Split('-').Select(x => x.Trim().Replace("\t", null)).ToArray());
						}
					}
					sr.Close();
				}
			}

			return tempLog;
		}
	}
	public enum TypeLog
	{
		NONE, ALERT, INFO, WARNING, ERROR
	}
	public enum TypeActionLog
	{
		NONE, READ, WRITE, EXECUTE
	}
	public enum TypePostionLog
	{
		NONE, INIT, FINISH, ERROR
	}
}
