using PWIWEBAPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace PWIWEBAPI.Models
{
	[Table("user-edit")]
	public class UserModel
	{
		[Key]
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
        public EnumUsers TypeUser { get; set; }

        public DateTime Updates { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Create { get; set; } = DateTime.Now.ToLocalTime();

		
	}
}
