using Microsoft.EntityFrameworkCore;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.DAL.DataAccessObject;
public class UserDao : IUserDao
{
    private readonly ApplicationDbContext _context;
    public UserDao(ApplicationDbContext context)
    {
        _context = context;
    }


    public List<User> GetAllUsers()
    {
        var users = _context.User
            .Select(i => new User
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Telephone = i.Telephone,
                Email = i.Email,
                //Dta
                //Memberships = i.Memberships
            }).ToList();
        return users;
    }

    public async Task<User> GetUserById(int userId)
    {
        var user = await _context.User.FirstOrDefaultAsync(i => i.Id == userId);

        return user;
    }

    public async Task CreateUser(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int userId)
    {
        var userToDelete = await _context.User.FindAsync(userId);
        if (userToDelete != null)
        {
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }
    }

}
