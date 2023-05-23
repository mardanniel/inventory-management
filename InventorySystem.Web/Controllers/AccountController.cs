using InventorySystem.Web.Repositories.Accounts;
using InventorySystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return View(userViewModel);

            var userModel = new RegisterUserViewModel
            {
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Password = userViewModel.Password,
                ConfirmPassword = userViewModel.ConfirmPassword,
                Gender = userViewModel.Gender
            };

            var result = await this._accountRepository.SignUpUserAsync(userModel);

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if(!ModelState.IsValid) return View(userViewModel);

            var result = await this._accountRepository.LoginUserAsync(userViewModel);

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login credentials!");
                return View(userViewModel);
            }

            HttpContext.Session.SetString("token", result);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
    }
}