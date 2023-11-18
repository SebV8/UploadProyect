using WODMaster.BLL.DTO;

namespace WODMaster.BLL.Interfaces;
public interface IUserService
{
    List<UserModel> GetAllUsers();
    Task CreateUser(UserModel user);

}
