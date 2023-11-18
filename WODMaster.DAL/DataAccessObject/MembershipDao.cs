using Microsoft.EntityFrameworkCore;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.DAL.DataAccessObject;
public class MembershipDao : IMembershipDao
{
    private readonly ApplicationDbContext _context;

    public MembershipDao(ApplicationDbContext context)
    {
        _context = context;
    }


    public List<Membership> GetAllMemberships()
    {
        var memberships = _context.Membership
            .Select(m => new Membership
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Vigencia = m.Vigencia,
                TotalClassesAllowed = m.TotalClassesAllowed,
                //Users = m.Users,
            }).ToList();

        return memberships;
    }

    public async Task<Membership> GetMembershipById(int MembershipId)
    {
        var membership = await _context.Membership.FirstOrDefaultAsync(i => i.Id == MembershipId);

        return membership;
    }

    public async Task CreateMembership(Membership membership)
    {
        _context.Membership.Add(membership);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMembership(Membership membership)
    {
        _context.Membership.Update(membership);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMembership(int MembershipId)
    {
        var membershipToDelete = await _context.Membership.FindAsync(MembershipId);
        if (membershipToDelete != null)
        {
            _context.Remove(membershipToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
