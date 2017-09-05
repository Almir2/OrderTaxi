using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Подрядчик".
	/// Данная сущность описывает фирму, непосредственно занимающуюся транспортировкой сотрудников компании.
	/// </summary>
	public class Contractor : IEntity
	{
		#region Fields

		/// <summary>
		/// Код подрядчика.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название подрядчика.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номер телефона подрядчика.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Стоимость, устанавливаемая подрядчиком за километр поездки.
		/// </summary>
		public decimal Tariff { get; set; }

		/// <summary>
		/// Код учётной записи подрядчика.
		/// </summary>
		public string UserId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Учётная запись подрядчика в системе.
		/// </summary>
		public virtual ApplicationUser User { get; set; }

		/// <summary>
		/// Список автомобилей, числящихся в автопарке подрядчика.
		/// </summary>
		public virtual ICollection<Vehicle> Vehicles { get; set; }

		// Список локаций, обслуживаемых подрядчиком.
		public virtual ICollection<Location> MaintainedLocations { get; set; }

		#endregion
	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Подрядчик".
	/// </summary>
	internal class ContractorEntityTypeConfiguration : EntityTypeConfiguration<Contractor>
	{
		public ContractorEntityTypeConfiguration()
		{
			ToTable("Contractors");

			HasKey(c => c.Id);

			Property(c => c.Name).HasMaxLength(100);
			Property(c => c.Phone).HasMaxLength(16);
			Property(c => c.Tariff).HasPrecision(7, 2);
			Property(c => c.UserId).HasMaxLength(128).IsOptional();

			// Связь "Многие-ко-многим" с сущностью "Локация".
			HasMany(c => c.MaintainedLocations)
				.WithMany(sl => sl.MaintainingContractors)
				.Map(m =>
				{
					m.ToTable("LocationsContractors");
					m.MapLeftKey("ContractorId");
					m.MapRightKey("LocationId");
				});

			// Связь "Один-ко-многим" с сущностью "Учётная запись".
			HasOptional(c => c.User)
				.WithMany()
				.HasForeignKey(c => c.UserId);

			// Связь "Один-ко-многим" с сущностью "Подрядчик".
			HasMany(c => c.Vehicles)
				.WithRequired(v => v.Contractor)
				.HasForeignKey(v => v.ContractorId);
		}
	}
}
