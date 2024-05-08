using PWIWEBAPI.DataContext;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.User
{
	public class UserService : IUser
	{
		private readonly AppDbContext _context;
		public UserService(AppDbContext context) => _context = context;
		public Task<ServiceResModel<List<UserModel>>> CreateUsers(UserModel newUser)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResModel<List<UserModel>>> DeletUsers(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ServiceResModel<List<UserModel>>> GetAllUsers()
		{
			ServiceResModel<List<UserModel>> serviceRes = new ServiceResModel<List<UserModel>>();
			try
			{
				serviceRes.Data = _context.Users.ToList();
				serviceRes.Error = false;
				serviceRes.Message = "Get all users.";
			}
			catch (Exception ex)
			{
				serviceRes.Error = true;
				serviceRes.Message = "Erros=>"+ex;
			}
			return serviceRes;
		}

		public Task<ServiceResModel<UserModel>> GetUsersById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResModel<UserModel>> UpdateUsers(UserModel upUser)
		{
			throw new NotImplementedException();
		}
	}
}
