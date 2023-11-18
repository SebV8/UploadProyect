using Microsoft.AspNetCore.Mvc;
using WODMaster.BLL.DTO;
using WODMaster.BLL.Interfaces;

namespace WODMaster.Web.Controllers;
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        List<UserModel> users = _userService.GetAllUsers();
        return View(users);
    }

    public IActionResult CreateUser()
    {
        UserModel userModel = new UserModel();

        return View(userModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserForm(UserModel newUser)
    {
        if (ModelState.IsValid)
        {

            // Llama al servicio de la capa de negocio para crear el usuario
            await _userService.CreateUser(newUser);

            // Redirige a una página de éxito o realiza otra acción
            return RedirectToAction("Index");
        }

        // Si el modelo no es válido, muestra errores al usuario
        return View(newUser);
    }
}
