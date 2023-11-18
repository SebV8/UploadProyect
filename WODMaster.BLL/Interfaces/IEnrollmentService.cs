using WODMaster.BLL.DTO;

namespace WODMaster.BLL.Interfaces;
public interface IEnrollmentService
{
    List<EnrollmentModel> GetAllEnrollments();
    Task CreateEnrollment(int UserId, int MembershipId, DateTime StartDate, DateTime? EndDate);
}
