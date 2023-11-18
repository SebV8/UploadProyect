using WODMaster.DAL.Entities;

namespace WODMaster.BLL.DTO;
public class EnrollmentFormModel
{
    public List<User> AvailableUsers { get; set; }
    public List<Membership> AvailableMemberships { get; set; }

}
