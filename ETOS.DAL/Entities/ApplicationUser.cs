using System;
using System.Data.Entity.ModelConfiguration;

using Microsoft.AspNet.Identity.EntityFramework;


namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Представляет собой учётную запись пользователя.
	/// </summary>
	public class ApplicationUser : IdentityUser { }

	/// <summary>
	/// Обеспечивает настройку таблицы учетных записей пользователей.
	/// </summary>
	internal class IdentityUserEntityTypeConfiguration : EntityTypeConfiguration<IdentityUser>
	{
		public IdentityUserEntityTypeConfiguration()
		{
			ToTable("Users");
				
			HasKey(u => u.Id);

			Property(u => u.Id).HasMaxLength(128);
			Property(u => u.Email).IsOptional();
			Property(u => u.PasswordHash).IsOptional();
			Property(u => u.SecurityStamp).IsOptional();
			Property(u => u.PhoneNumber).IsOptional();
			Property(u => u.LockoutEndDateUtc).IsOptional();
			Property(u => u.UserName).IsOptional();

			HasMany(u => u.Logins)
				.WithOptional()
				.HasForeignKey(l => l.UserId);

			HasMany(u => u.Claims)
				.WithOptional()
				.HasForeignKey(c => c.UserId);

			HasMany(u => u.Roles)
				.WithRequired()
				.HasForeignKey(r => r.UserId);
		}
	}
	
	/// <summary>
	/// Обеспечивает настройку таблицы ролей пользователей.
	/// </summary>
	internal class IdentityRoleEntityTypeConfiguration : EntityTypeConfiguration<IdentityRole>
	{
		public IdentityRoleEntityTypeConfiguration()
		{
			ToTable("Roles");

			HasKey(r => r.Id);

			Property(r => r.Id).HasMaxLength(128);

			HasMany(r => r.Users)
				.WithRequired()
				.HasForeignKey(r => r.RoleId);

		}
	}

	internal class IdentityUserRoleEntityTypeConfiguration : EntityTypeConfiguration<IdentityUserRole>
	{
		public IdentityUserRoleEntityTypeConfiguration()
		{
			ToTable("UserRoles");

			HasKey(ur => new
				{
					ur.UserId,
					ur.RoleId
				});
		}
	}

	internal class IdentityUserLoginEntityTypeConfiguration : EntityTypeConfiguration<IdentityUserLogin>
	{
		public IdentityUserLoginEntityTypeConfiguration()
		{
			ToTable("UserLogins");

			HasKey(p => new
			{
				p.LoginProvider,
				p.ProviderKey,
				p.UserId
			});
		}
	}

	internal class IdentityUserClaimEntityTypeConfiguration : EntityTypeConfiguration<IdentityUserClaim>
	{
		public IdentityUserClaimEntityTypeConfiguration()
		{
			ToTable("UserClaims");

			HasKey(c => c.Id);
		}	
	}
}
