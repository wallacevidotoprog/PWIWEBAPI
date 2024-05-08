using PWIWEBAPI.DataContext;
using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.User
{
	public class UserService : IUser
	{
		private readonly AppDbContext _context;
		public UserService(AppDbContext context) => _context = context;
		public async Task<ServiceResModel<UserModel>> CreateUsers(UserModel newUser)
		{
			ServiceResModel<UserModel> serviceRes = new ServiceResModel<UserModel>();
			try
			{
				if (newUser == null)
				{
					serviceRes.Error = true;
					serviceRes.Message = "Data null";
					return serviceRes;
				}

				_context.Add(newUser);
				await _context.SaveChangesAsync();
				serviceRes.Data = newUser;
			}
			catch (Exception ex)
			{
				serviceRes.Error = true;
				serviceRes.Message = "Erros=>" + ex;
			}
			return serviceRes;
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
				serviceRes.Message = "Erros=>" + ex;
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
