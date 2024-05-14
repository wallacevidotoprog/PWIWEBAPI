using System.Text;

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
	}
}
