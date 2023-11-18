using WODMaster.DAL.Entities;

namespace WODMaster.DAL.Interface;
public interface IMembershipDao
{
    Task<Membership> GetMembershipById(int MembershipId);
    List<Membership> GetAllMemberships();
    Task CreateMembership(Membership membership);
    Task UpdateMembership(Membership membership);
    Task DeleteMembership(int MembershipId);
}
