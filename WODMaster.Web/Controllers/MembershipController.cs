using Microsoft.AspNetCore.Mvc;
using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;

namespace WODMaster.Web.Controllers;
public class MembershipController : Controller
{
    private readonly IMembershipService _membershipService;

    public MembershipController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    public IActionResult Index()
    {
        List<MembershipModel> memberships = _membershipService.GetAllMembership();
        return View(memberships);
    }

    public IActionResult CreateMembership()
    {
        MembershipModel model = new MembershipModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMembershipForm(MembershipModel membership)
    {
        if (ModelState.IsValid)
        {
            await _membershipService.CreateMembership(membership);
            return RedirectToAction("Index");
        }

        return View(membership);
    }
}
