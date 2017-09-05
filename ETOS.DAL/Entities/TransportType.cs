using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Вид транспорта".
	/// Данная сущность описывает категорию, класс транспортного средства, необходимого для сотрудников.
	/// </summary>
	public class TransportType : IEntity
	{
		#region Fields

		/// <summary>
		/// Код вида транспорта.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название вида транспорта.
		/// </summary>
		public string Name { get; set; }

		#endregion
	}

	/// <summary>
	/// Обеспечивает настройку модели сущности-типа "Вид транспорта."
	/// </summary>
	internal class TransportTypeEntityConfiguration : EntityTypeConfiguration<TransportType>
	{
		public TransportTypeEntityConfiguration()
		{
			ToTable("TransportTypes");

			HasKey(tt => tt.Id);

			Property(tt => tt.Name).HasMaxLength(50);
		}
	}
}
