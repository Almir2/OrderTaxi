using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using ETOS.Core.DTO;
using ETOS.Core.Infrastructure;
using ETOS.DAL.Entities;

namespace ETOS.Core.Services.Abstract
{
	/// <summary>
	/// Описывает сервис, управляющий учетными записями пользователей на уровне бизнес-логики.
	/// </summary>
	public interface IApplicationUserService : IDisposable
	{
		Task<OperationResult> CreateAsync(DtoApplicationUser userDto);

		Task<ClaimsIdentity> Authenticate(DtoApplicationUser userDto);

        ApplicationUser GetUserByMail(string email);
    }
}
