using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using ETOS.Core.Services.Abstract;
using ETOS.Core.DTO;
using ETOS.Core.Infrastructure;
using ETOS.DAL.Interfaces;
using ETOS.DAL.Entities;

namespace ETOS.Core.Services
{
	/// <summary>
	/// Реализует сервис, управляющий учетными записями пользователей на уровне бизнес-логики.
	/// </summary>
	public class ApplicationUserService : IApplicationUserService
	{
		/// <summary>
		/// Необходимый набор компонентов.
		/// </summary>
		private IUnitOfWork _toolset { get; }

		public ApplicationUserService(IUnitOfWork toolset)
		{
			_toolset = toolset;
		}

		/// <summary>
		/// Реализует асинхронное добавление новой учётной записи пользователя.
		/// </summary>
		public async Task<OperationResult> CreateAsync(DtoApplicationUser userDto)
		{
			ApplicationUser user = await _toolset.UserManager.FindByEmailAsync(userDto.Email);

			if (user == null)
			{
				user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };

				var result = await _toolset.UserManager.CreateAsync(user, userDto.Password);

				if (result.Errors.Count() > 0)
				{
					return new OperationResult(false, result.Errors.FirstOrDefault(), "");
				}

				await _toolset.SaveChangesAsync();

				return new OperationResult(true, "Учетная запись пользователя успешно добавлена.", "");
			}
			else
			{
				return new OperationResult(false, "Пользователь с таким E-mail уже существует!", "");
			}
		}

		/// <summary>
		/// Реализует асинхронную аутентификацию пользователя в системе.
		/// </summary>
		public async Task<ClaimsIdentity> Authenticate(DtoApplicationUser userDto)
		{
			ClaimsIdentity claim = null;

			ApplicationUser user = await _toolset.UserManager.FindAsync(userDto.Email, userDto.Password);

			if (user != null)
			{
				claim = await _toolset.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			}

			return claim;
		}

		public void Dispose()
		{
			_toolset.Dispose();
		}

        public ApplicationUser GetUserByMail(string email)
        {
            var user = _toolset.UserManager.FindByEmail(email);

            return user;
        }
    }
}
