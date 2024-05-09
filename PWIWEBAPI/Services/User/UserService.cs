using Microsoft.EntityFrameworkCore;
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

		public async Task<ServiceResModel<UserModel>> DeletUsers(int id)
		{
			ServiceResModel<UserModel> serviceRes = new ServiceResModel<UserModel>();
			try
			{
				UserModel temp = _context.Users.FirstOrDefault(x => x.ID == id);

				if (temp == null)
				{
					serviceRes.Error = true;
					serviceRes.Message = "User not exist";
					return serviceRes;
				}

				temp.Live = false;
				temp.Updates = DateTime.Now.ToLocalTime();

				_context.Update(temp);
				await _context.SaveChangesAsync();

				serviceRes.Data = temp;
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

		public async Task<ServiceResModel<UserModel>> GetUsersById(int id)
		{
			ServiceResModel<UserModel> serviceRes = new ServiceResModel<UserModel>();
			try
			{
				UserModel temp =  _context.Users.FirstOrDefault(x => x.ID == id);

				if (temp==null)
				{
					serviceRes.Error = true;
					serviceRes.Message = "User not exist";
					return serviceRes;
				}

				serviceRes.Data = temp;
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

		public async Task<ServiceResModel<UserModel>> UpdateUsers(UserModel upUser)
		{

			ServiceResModel<UserModel> serviceRes = new ServiceResModel<UserModel>();
			try
			{
				UserModel temp = _context.Users.AsNoTracking().FirstOrDefault(x => x.ID == upUser.ID);

				if (temp == null)
				{
					serviceRes.Error = true;
					serviceRes.Message = "User not exist";
					return serviceRes;
				}

				temp.Updates = DateTime.Now.ToLocalTime();

				_context.Update(upUser);
				await _context.SaveChangesAsync();

				serviceRes.Data = _context.Users.FirstOrDefault(x => x.ID == upUser.ID);
				serviceRes.Error = false;
				serviceRes.Message = "Update users.";
			}
			catch (Exception ex)
			{
				serviceRes.Error = true;
				serviceRes.Message = "Erros=>" + ex;
			}
			return serviceRes;
		}
	}
}
