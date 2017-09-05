using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Транспортное средство".
	/// </summary>
	public class Vehicle : IEntity
	{
		#region Fields

		/// <summary>
		/// Код автомобиля.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название цвета автомобиля.
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Гоc/ номер автомобиля.
		/// </summary>
		public string LicensePlate { get; set; }

		/// <summary>
		/// Стоимость заказа автомобиля.
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Код модели автомобиля.
		/// </summary>
		public int ModelId { get; set; }

		/// <summary>
		/// Код подрядчика, в автопарке которого числится данный автомобиль.
		/// </summary>
		public int ContractorId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Модель данного автомобиля.
		/// </summary>
		public virtual Model Model { get; set; }

		/// <summary>
		/// Подрядчик, в автопарке которого числится данный автомобиль.
		/// </summary>
		public virtual Contractor Contractor { get; set; }

		#endregion
	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Транспортное средство".
	/// </summary>
	internal class VehicleEntityTypeConfiguration : EntityTypeConfiguration<Vehicle>
	{
		public VehicleEntityTypeConfiguration()
		{
			ToTable("Vehicles");

			HasKey(v => v.Id);

			Property(v => v.Color).HasMaxLength(50);
			Property(v => v.LicensePlate).HasMaxLength(20);
			Property(v => v.Price).HasPrecision(7, 2);

			HasRequired(v => v.Model)
				.WithMany()
				.HasForeignKey(v => v.ModelId);
		}

	}
}