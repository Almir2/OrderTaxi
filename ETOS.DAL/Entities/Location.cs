using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Локация".
	/// Данная сущность обозначает локацию, в которой может находиться сотрудник
	/// или место, непосредственно связанное с деятельностью фирмы, в которое сотрудник может заказать поездку.
	/// </summary>
	public class Location : IEntity
	{
		#region Fields

		/// <summary>
		/// Код локации.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название локации.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Адрес локации.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Код локации, являющейся родительской по отношению к данной.
		/// </summary>
		public int ? ParentLocationId { get; set; }

		/// <summary>
		/// Флаг, определяющий является ли локация точкой интереса
		/// </summary>
		public bool IsPOI { get; set; }

		/// <summary>
		/// Системный код культуры локации.
		/// </summary>
		public int CultureId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Локация, являющаяся родительской по отношению к данной.
		/// </summary>
		public virtual Location ParentLocation { get; set; }

		/// <summary>
		/// Список локаий, являющихся дочерними по отношению к данной.
		/// </summary>
		public ICollection<Location> ChildLocations { get; set; }

		/// <summary>
		/// Список подрядчиков, обслуживающих данную локацию.
		/// </summary>
		public virtual ICollection<Contractor> MaintainingContractors { get; set; }

		#endregion
	}

	/// <summary>
	/// Обеспечивает настройку модели сущности-типа "Локация".
	/// </summary>
	internal class LocationEntityTypeConfiguration : EntityTypeConfiguration<Location>
	{
		public LocationEntityTypeConfiguration()
		{
			ToTable("Locations");

			HasKey(l => l.Id);

			Property(l => l.Name).HasMaxLength(100);
			Property(l => l.Address).HasMaxLength(150);;

			// Связь "Один-ко-многим" с сущностью "Локация" (родительская локация-дочерние локации).
			HasOptional(l => l.ParentLocation)
				.WithMany(pl => pl.ChildLocations)
				.HasForeignKey(cl => cl.ParentLocationId);

			// Связь"Многие-ко-многим" с сущностью "Подрядчик".
			HasMany(l => l.MaintainingContractors)
				.WithMany(mc => mc.MaintainedLocations)
				.Map(m =>
				{
					m.ToTable("LocationsContractors");
					m.MapLeftKey("ContractorId");
					m.MapRightKey("LocationId");
				});
		}
	}
}
