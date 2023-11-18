using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.BLL.Services;
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentDao _enrollmentDao;
    private readonly IMembershipDao _membershipDao;
    private readonly IUserDao _userDao;

    public EnrollmentService(IEnrollmentDao enrollmentDao, IMembershipDao membershipDao)
    {
        _enrollmentDao = enrollmentDao;
        _membershipDao = membershipDao;
    }


    public List<EnrollmentModel> GetAllEnrollments()
    {
        List<Enrollment> enrollmentsDao = _enrollmentDao.GetAllEnrollment();
        List<EnrollmentModel> enrollmentModels = enrollmentsDao.Select(x => new EnrollmentModel
        {
            Id = x.Id,
            UserId = x.UserId,
            MembershipId = x.MembershipId,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToList();



        return enrollmentModels;
    }

    public async Task CreateEnrollment(int UserId, int MembershipId, DateTime StartDate, DateTime? EndDate)
    {
        Enrollment enrollmentDal = new Enrollment
        {
            UserId = UserId,
            MembershipId = MembershipId,
            StartDate = StartDate,
            EndDate = EndDate,
        };
        await _enrollmentDao.CreateEnrollment(enrollmentDal);
    }

}
