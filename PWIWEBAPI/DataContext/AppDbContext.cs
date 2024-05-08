using Microsoft.EntityFrameworkCore;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.DataContext
{
	public class AppDbContext :DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {}



        public DbSet<UserModel> Users { get; set; }
    }
}
