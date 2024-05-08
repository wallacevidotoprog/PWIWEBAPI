using System.Security.Cryptography;

namespace PWIWEBAPI.Services
{
    public class ServiceResModel<T>
    {
        public T? Data { get; set; }
        public bool Error { get; set; }
        public string? Message { get; set; }
    }
}
