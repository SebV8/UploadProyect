using WODMaster.DAL.Entities;

namespace WODMaster.BLL.DTO;
public class EnrollmentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MembershipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<User> AvailableUsers { get; set; }
    public List<Membership> AvailableMemberships { get; set; }
}
