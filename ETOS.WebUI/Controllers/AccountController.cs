using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

using ETOS.Core.DTO;
using ETOS.WebUI.ViewModels;
using ETOS.Core.Services.Abstract;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ETOS.WebUI.Controllers
{
	/// <summary>
	/// Контроллер, обеспечивающий работу с пользовательскими данными на уровне представления.
	/// </summary>
	public class AccountController : Controller
	{
		#region Fields

		private IApplicationUserService _userService
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<IApplicationUserService>();
			}
		}

		private IAuthenticationManager _authenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Метод, возвращающий представление с данными пользователя.
		/// </summary>
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Get-версия метода, возвращающая представление входа в систему.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Login()
		{
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Request");
			}
			else
			{
				return View();
			}
		}

		/// <summary>
		/// Post-версия метода, реализующая авторизацию в системе (на уровне представления).
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login(LoginViewModel account, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				DtoApplicationUser user = new DtoApplicationUser { Email = account.Username, Password = account.Password };
				ClaimsIdentity claim = await _userService.Authenticate(user);

				if (claim == null)
				{
					ModelState.AddModelError("", "Неверный логин или пароль.");
				}
				else
				{
					_authenticationManager.SignOut();
					_authenticationManager.SignIn(new AuthenticationProperties
					{
						IsPersistent = account.Persistent,
					}, claim);
					return RedirectToAction("Index", "Request");
				}
			}
			return View(account);
		}

		/// <summary>
		/// Метод, реализующий выход пользователя из системы.
		/// </summary>
		[Authorize]
        public ActionResult LogOut()
        {
			_authenticationManager.SignOut();

            return RedirectToAction("Login", "Account");
        }

		public ActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> AddUser(ApplicationUserViewModel user)
		{
			await _userService.CreateAsync(new DtoApplicationUser
			{
				Email = user.Email,
				Password = user.Password
			});

			return RedirectToAction("Login", "Account");
		}

		#endregion
	}
}