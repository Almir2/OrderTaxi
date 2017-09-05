using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Приоритет".
	/// Данная сущность описывает приориет обслуживания сотрудника.
	/// </summary>
	public class Priority : IEntity
	{
		#region Fields

		/// <summary>
		/// Код приоритета.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Системное название приоритета.
		/// </summary>
		public string Sysname { get; set; }

		/// <summary>
		/// Название приоритета, выводимое на экран.
		/// </summary>
		public string Viewname { get; set; }

		#endregion
	}

	/// <summary>
	/// Обеспечивает настройку модели сущности-типа "Приоритет".
	/// </summary>
	internal class PriorityEntityTypeConfiguration : EntityTypeConfiguration<Priority>
	{
		public PriorityEntityTypeConfiguration()
		{
			ToTable("Priorities");

			HasKey(p => p.Id);

			Property(p => p.Sysname).HasMaxLength(50);
			Property(p => p.Viewname).HasMaxLength(50);
		}
	}
}
