using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Сотрудник".
	/// Данная сущность представляет собой сотрудника компании.
	/// </summary>
	public class Employee : IEntity
	{
		#region Fields

		/// <summary>
		/// Табельный номер сотрудника.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Фамилия сотрудника.
		/// </summary>
		public string Lastname { get; set; }

		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		public string Firstname { get; set; }

		/// <summary>
		/// Отчество сотрудника.
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Номер телефона сотрудника.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Адрес электронной почты сотрудника.
		/// </summary>
		public string Email { get; set; }
		
		/// <summary>
		/// Код локации, в которой находится сотрудник.
		/// </summary>
		public int LocationId { get; set; }

		/// <summary>
		/// Код оргструктуры, за которой закреплен сотрудник.
		/// </summary>
		public int OrgstructureId { get; set; }

		/// <summary>
		/// Код должности, занимаемой сотрудником.
		/// </summary>
		public int PositionId { get; set; }

		/// <summary>
		/// Код учётной записи сотрудника в системе.
		/// </summary>
		public string UserId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Локация, в которой находится сотрудник.
		/// </summary>
		public virtual Location Location { get; set; }

		/// <summary>
		/// Оргструктура, к которой прикреплен сотрудник.
		/// </summary>
		public virtual Orgstructure Orgstructure { get; set; }

		/// <summary>
		/// Должность, занимаемая сотрудником.
		/// </summary>
		public virtual Position Position { get; set; }

		/// <summary>
		/// Учётная запись сотрудника в системе.
		/// </summary>
		public virtual ApplicationUser User { get; set; }

		/// <summary>
		/// Список заявок, отправленных сотрудником.
		/// </summary>
		public virtual ICollection<Request> Requests { get; set; }

		#endregion
	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Сотрудник".
	/// </summary>
	internal class EmployeeEntityTypeConfiguration : EntityTypeConfiguration<Employee>
	{
		public EmployeeEntityTypeConfiguration()
		{
			ToTable("Employees");

			HasKey(e => e.Id);

			Property(e => e.Lastname).HasMaxLength(50);
			Property(e => e.Firstname).HasMaxLength(50);
			Property(e => e.Patronymic).HasMaxLength(50);
			Property(e => e.Phone).HasMaxLength(16);
			Property(e => e.Email).HasMaxLength(50);
			Property(e => e.UserId).HasMaxLength(128);

			// Связь "Один-ко-многим" с сущностью "Локация".
			HasRequired(e => e.Location)
				.WithMany()
				.HasForeignKey(e => e.LocationId);

			// Связь "Один-ко-многим" с сущностью "Оргструктура".
			HasRequired(e => e.Orgstructure)
				.WithMany()
				.HasForeignKey(e => e.OrgstructureId);

			// Связь "Один-ко-многим" с сущностью "Должность".
			HasRequired(e => e.Position)
				.WithMany()
				.HasForeignKey(e => e.PositionId);

			// Связь "Один-ко-многим" с сущностью "Учётная запись".
			HasRequired(e => e.User)
				.WithMany()
				.HasForeignKey(e => e.UserId);

			// Связь "Один-ко-многим" с сущностью "Заявка".
			HasMany(e => e.Requests)
				.WithOptional(r => r.Employee)
				.HasForeignKey(r => r.EmployeeId);
		}
	}
}
