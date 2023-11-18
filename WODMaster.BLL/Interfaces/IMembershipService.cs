using WODMaster.BLL.DTO;

namespace WODMaster.BLL.Interfaces;
public interface IMembershipService
{
    List<MembershipModel> GetAllMembership();
    Task CreateMembership(MembershipModel model);
}
