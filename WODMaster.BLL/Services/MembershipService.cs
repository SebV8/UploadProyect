using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.BLL.Services;
public class MembershipService : IMembershipService
{
    private readonly IMembershipDao _membershipDao;

    public MembershipService(IMembershipDao membershipDao)
    {
        _membershipDao = membershipDao;
    }


    public List<MembershipModel> GetAllMembership()
    {
        List<Membership> membershipsDal = _membershipDao.GetAllMemberships();

        List<MembershipModel> memberships = membershipsDal.Select(m => new MembershipModel
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            Price = m.Price,
            TotalClassesAllowed = m.TotalClassesAllowed,
            //Users = m.Users,
            Vigencia = m.Vigencia,
        }).ToList();

        return memberships;
    }
    public async Task CreateMembership(MembershipModel model)
    {
        Membership membershipDAL = new Membership
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            TotalClassesAllowed = model.TotalClassesAllowed,
            //Users = model.Users,
            Vigencia = model.Vigencia,
        };

        await _membershipDao.CreateMembership(membershipDAL);
    }
}
