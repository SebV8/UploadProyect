using Microsoft.AspNetCore.Mvc;
using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;

namespace WODMaster.Web.Controllers;
public class EnrollmentController : Controller
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IUserService _userService;
    private readonly IMembershipService _membershipService;

    public EnrollmentController(IEnrollmentService enrollmentService, IUserService userService, IMembershipService membershipService)
    {
        _enrollmentService = enrollmentService;
        _userService = userService;
        _membershipService = membershipService;
    }


    public IActionResult Index()
    {
        List<EnrollmentModel> enrollments = _enrollmentService.GetAllEnrollments();
        return View(enrollments);
    }

    [HttpGet]
    public IActionResult CreateEnrollment()
    {
        var availableUsers = _userService.GetAllUsers();
        var availableMemberships = _membershipService.GetAllMembership();

        var enrollmentModel = new EnrollmentModel
        {
            AvailableUsers = availableUsers.Select(m => new DAL.Entities.User
            {
                Id = m.Id,
                FirstName = m.Nombre,
                LastName = m.Apellido,
                Telephone = m.Telefono,
                Email = m.Correo
            }).ToList(),

            AvailableMemberships = availableMemberships.Select(m => new DAL.Entities.Membership
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                TotalClassesAllowed = m.TotalClassesAllowed,
                Vigencia = m.Vigencia,
            }).ToList(),
        };

        return View(enrollmentModel);

    }

    [HttpPost]
    public async Task<IActionResult> CreateEnrollmentForm(int UserId, int MembershipId, DateTime StartDate, DateTime? EndDate)
    {
        if (ModelState.IsValid)
        {
            int selectedUserId = UserId;
            int selectedMembershipId = MembershipId;

            await _enrollmentService.CreateEnrollment(UserId, MembershipId, StartDate, EndDate);
            return RedirectToAction("Index");
        }

        return View("Index");
    }
}



//EnrollmentModel model = new EnrollmentModel();
//return View(model);