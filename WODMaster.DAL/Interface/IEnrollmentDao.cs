using WODMaster.DAL.Entities;

namespace WODMaster.DAL.Interface;
public interface IEnrollmentDao
{
    Task<Enrollment> GetEnrollmentById(int MembershipId);
    List<Enrollment> GetAllEnrollment();
    Task CreateEnrollment(Enrollment enrollment);
    Task UpdateEnrollment(Enrollment enrollmentId);
    Task DeleteEnrollment(int enrollmentId);
}
