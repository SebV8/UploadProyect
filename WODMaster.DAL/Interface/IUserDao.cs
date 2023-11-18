using WODMaster.DAL.Entities;

namespace WODMaster.DAL.Interface;
public interface IUserDao
{
    Task<User> GetUserById(int userId);
    List<User> GetAllUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int userId);
}
