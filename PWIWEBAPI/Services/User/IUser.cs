using PWIWEBAPI.Models;

namespace PWIWEBAPI.Services.User
{
	public interface IUser
	{
		Task<ServiceResModel<List<UserModel>>> GetAllUsers();
		Task<ServiceResModel<UserModel>> CreateUsers(UserModel newUser);
		Task<ServiceResModel<UserModel>> GetUsersById(int id);
		Task<ServiceResModel<UserModel>> UpdateUsers(UserModel upUser);
		Task<ServiceResModel<List<UserModel>>> DeletUsers(int id);

	}
}
