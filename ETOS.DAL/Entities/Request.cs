using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Заявка".
	/// Данная сущность представляет собой сформированную и отправленную сотрудником заявку на вызов транспорта.
	/// </summary>
	public class Request : IEntity
	{
		#region Fields

		/// <summary>
		/// Код заявки.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Табельный номер сотрудника-отправителя заявки.
		/// </summary>
		public int ? EmployeeId { get; set; }

		/// <summary>
		/// Код клиента-отправителя заявки.
		/// </summary>
		public int ? CustomerId { get; set; }

		/// <summary>
		/// Код локации, являющейся точкой отправки.
		/// Не указывается в том случае, если точка отправки не является точкой интереса (POI).
		/// </summary>
		public int? DeparturePointId { get; set; }

		/// <summary>
		/// Код локации, являющейся точкой прибытия.
		/// Не указывается в том случае, если точка прибытия не является точкой интереса (POI).
		/// </summary>
		public int? DestinationPointId { get; set; }

		/// <summary>
		/// Адрес места отправки.
		/// Указывается в том случае, если место отправки не является точкой интереса (POI).
		/// </summary>
		public string DepartureAddress { get; set; }

		/// <summary>
		/// Адрес места прибытия.
		/// Указывается в том случае, если место прибытия не является точкой интереса (POI).
		/// </summary>
		public string DestinationAddress { get; set; }

		/// <summary>
		/// Предполагаемые дата и время отправки.
		/// </summary>
		public DateTime DepartureDateTime { get; set; }

		/// <summary>
		/// Дата и время создания заявки.
		/// </summary>
		public DateTime CreationDateTime { get; set; }

		/// <summary>
		/// Флаг, определяющий наличие багажа.
		/// </summary>
		public bool HasBaggage { get; set; }

		/// <summary>
		/// Комментарий к заявке.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Код автомобиля, назначенный данной заявке.
		/// </summary>
		public int ? VehicleId { get; set; }

		/// <summary>
		/// Общий километраж заявки.
		/// </summary>
		public float Mileage { get; set; }

		/// <summary>
		/// Общая стоимость заявки.
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Код статуса выполнения заявки.
		/// </summary>
		public int StatusId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Текущий статус заявки.
		/// </summary>
		public virtual Status Status { get; set; }

		/// <summary>
		/// Сотрудник-отправитель заявки.
		/// </summary>
		public virtual Employee Employee { get; set; }

		/// <summary>
		/// Клиент-отправитель заявки.
		/// </summary>
		public virtual Customer Customer { get; set; }

		/// <summary>
		/// Локация, являющаяся точкой отправки.
		/// </summary>
		public virtual Location DeparturePoint { get; set; }

		/// <summary>
		/// Локация, являющаяся точкой прибытия.
		/// </summary>
		public virtual Location DestinationPoint { get; set; }

		/// <summary>
		/// Автомобиль, назначенный данной заявке.
		/// </summary>
		public virtual Vehicle Vehicle { get; set; }

		#endregion
	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Заявка".
	/// </summary>
	internal class RequestEntityTypeConfiguration : EntityTypeConfiguration<Request>
	{
		public RequestEntityTypeConfiguration()
		{
			ToTable("Requests");

			HasKey(r => r.Id);

			Property(r => r.DeparturePointId).IsOptional();
			Property(r => r.DepartureAddress)
				.IsOptional()
				.HasMaxLength(150);
			Property(r => r.DestinationPointId).IsOptional();
			Property(r => r.DestinationAddress)
				.IsOptional()
				.HasMaxLength(150);
			Property(r => r.CreationDateTime).IsOptional();
			Property(r => r.Comment)
				.IsOptional()
				.HasMaxLength(255);
			Property(r => r.Mileage).HasColumnType("float");
			Property(r => r.Price).HasPrecision(9, 2);
			Property(r => r.CustomerId).IsOptional();
			Property(r => r.EmployeeId).IsOptional();

			HasOptional(r => r.Employee)
				.WithMany()
				.HasForeignKey(r => r.EmployeeId);

			HasOptional(r => r.Customer)
				.WithMany()
				.HasForeignKey(r => r.CustomerId);

			HasOptional(r => r.Vehicle)
				.WithMany()
				.HasForeignKey(r => r.VehicleId);
		}
	}
}
