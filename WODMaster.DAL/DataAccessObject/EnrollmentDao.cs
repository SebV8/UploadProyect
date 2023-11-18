using Microsoft.EntityFrameworkCore;
using WODMaster.DAL.Entities;
using WODMaster.DAL.Interface;

namespace WODMaster.DAL.DataAccessObject;
public class EnrollmentDao : IEnrollmentDao
{
    private readonly ApplicationDbContext _context;

    public EnrollmentDao(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Enrollment> GetAllEnrollment()
    {
        var enrollment = _context.Enrollment
            .Select(e => new Enrollment
            {
                Id = e.Id,
                UserId = e.UserId,
                MembershipId = e.MembershipId,
                StartDate = DateTime.Now,
                EndDate = e.StartDate.AddMonths(1),
            }).ToList();

        return enrollment;
    }

    public async Task<Enrollment> GetEnrollmentById(int MembershipId)
    {
        var enrollment = await _context.Enrollment.FirstOrDefaultAsync(e => e.Id == MembershipId);

        return enrollment;
    }

    public async Task CreateEnrollment(Enrollment enrollment)
    {
        _context.Enrollment.Add(enrollment);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnrollment(Enrollment enrollmentId)
    {
        _context.Enrollment.Update(enrollmentId);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEnrollment(int enrollmentId)
    {
        var enrollmentToDelete = await _context.Enrollment.FindAsync(enrollmentId);
        if (enrollmentToDelete != null)
        {
            _context.Remove(enrollmentToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
