using System.Security.Cryptography;

namespace PWIWEBAPI.Services
{
	public class ServiceResModel<T>
	{
		public T? Data { get; set; }
		public bool Error { get; set; }
		public string? Message { get; set; }
	}
	public class ActionData<DataMod>
	{
		public DataMod? Data { get; set; }
		public Actions? Action { get; set; }
	}
	public class DataMod
	{
        public int Id_tile { get; set; }
		public int Id_key { get; set; }
		public object? Values { get; set; }
	}
	public enum Actions
	{
		INSERT,
		UPDATE,
		DELETE
	}
}
