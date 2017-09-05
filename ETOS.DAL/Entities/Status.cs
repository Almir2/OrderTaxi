using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Статус".
	/// Данная сущность описывает общий или промежуточный статус выполнения заявки.
	/// </summary>
	public class Status : IEntity
	{
		#region Fields

		/// <summary>
		/// Код статуса.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Системное название статуса.
		/// </summary>
		public string Sysname { get; set; }

		/// <summary>
		/// Название статуса, выводимое на экран.
		/// </summary>
		public string Viewname { get; set; }

		#endregion
	}

	/// <summary>
	/// Обеспечивает настройку сущности-типа "Статус".
	/// </summary>
	internal class StatusEntityTypeConfiguration : EntityTypeConfiguration<Status>
	{
		public StatusEntityTypeConfiguration()
		{
			ToTable("Statuses");

			HasKey(s => s.Id);

			Property(s => s.Sysname).HasMaxLength(50);
			Property(s => s.Viewname).HasMaxLength(50);
		}
	}
}
