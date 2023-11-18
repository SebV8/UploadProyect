using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.BLL.Services;
public class UserService : IUserService
{
    private readonly IUserDao _userDao;

    public UserService(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public List<UserModel> GetAllUsers()
    {
        List<User> usersDAL = _userDao.GetAllUsers();

        List<UserModel> userBLL = usersDAL.Select(u => new UserModel
        {
            Id = u.Id,
            Nombre = u.FirstName,
            Apellido = u.LastName,
            Telefono = u.Telephone,
            Correo = u.Email
        }).ToList();

        return userBLL;
    }

    public async Task CreateUser(UserModel user)
    {
        User userDAL = new User
        {
            Id = user.Id,
            FirstName = user.Nombre,
            LastName = user.Apellido,
            Telephone = user.Telefono,
            Email = user.Correo
        };

        await _userDao.CreateUser(userDAL);

    }
}
