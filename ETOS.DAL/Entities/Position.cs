using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Должность".
	/// Данная сущность описывает должность, занимаемую сотрудником в компании.
	/// </summary>
	public class Position : IEntity
	{
		#region Fields

		/// <summary>
		/// Код должности.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название должности.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Флаг, определяющий, является ли данная должность руководящей.
		/// </summary>
		public bool IsManager { get; set; }

		/// <summary>
		/// Код вида транспорта, необходимого для сотрудников, занимающих данную должность.
		/// </summary>
		public int TransportTypeId { get; set; }

		/// <summary>
		/// Код приоритета обслуживания сотрудников, занимающих данную должность.
		/// </summary>
		public int PriorityId { get; set; }


		#endregion

		#region Navigation properties

		/// <summary>
		/// Приоритет обслуживания сотрудников, занимающих данную должность.
		/// </summary>
		public virtual Priority Priority { get; set; }

		/// <summary>
		/// Вид транспорта, необходимый сотрудникам, занимающим данную должность.
		/// </summary>
		public virtual TransportType TransportType { get; set; }

		#endregion

	}

	/// <summary>
	/// Обеспечивает настройку сущности-типа "Должность".
	/// </summary>
	internal class PositionEntityTypeConfiguration : EntityTypeConfiguration<Position>
	{
		public PositionEntityTypeConfiguration()
		{
			ToTable("Positions");

			HasKey(p => p.Id);

			Property(p => p.Name).HasMaxLength(100);
		}
	}
}
