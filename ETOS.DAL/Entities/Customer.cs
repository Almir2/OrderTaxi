using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Клиент".
	/// </summary>
	public class Customer : IEntity
	{
		#region Fields
		
		/// <summary>
		/// Код клиента.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Фамилия клиента.
		/// </summary>
		public string Lastname { get; set; }

		/// <summary>
		/// Имя клиента.
		/// </summary>
		public string Firstname { get; set; }

		/// <summary>
		/// Отчество клиента.
		/// </summary>
		public string Patroymic { get; set; }

		/// <summary>
		/// Номер телефона клиента.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Email-адрес клиента.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Код учетной записи клиента.
		/// </summary>
		public string UserId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Учётная запись клиента.
		/// </summary>
		public ApplicationUser User { get; set; }

		/// <summary>
		/// Список заявок, совершенных клиентом.
		/// </summary>
		public ICollection<Request> Requests { get; set; }

		#endregion

	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Клиент".
	/// </summary>
	internal class CustomerEntityTypeConfiguration : EntityTypeConfiguration<Customer>
	{
		public CustomerEntityTypeConfiguration()
		{
			ToTable("Customers");

			HasKey(c => c.Id);

			Property(c => c.Lastname).HasMaxLength(50);
			Property(c => c.Firstname).HasMaxLength(50);
			Property(c => c.Patroymic).HasMaxLength(50);
			Property(c => c.Phone).HasMaxLength(16);
			Property(c => c.Email).HasMaxLength(50);

			// Связь "Один-к-одному" с сущностью "Учетная запись".
			HasOptional(c => c.User)
				.WithMany()
				.HasForeignKey(c => c.UserId);

			// Связь "Один-к-нулю-или-многим" с сущностью "Заявка".
			HasMany(c => c.Requests)
				.WithOptional(r => r.Customer)
				.HasForeignKey(r => r.CustomerId);

		}
	}
}