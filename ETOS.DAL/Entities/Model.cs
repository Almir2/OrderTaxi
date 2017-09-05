using System;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность-справочник "Модель автомобиля".
	/// </summary>
	public class Model : IEntity
	{
		#region  Fields

		/// <summary>
		/// Код модели автомобиля.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название модели автомобиля.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Код марки данной модели автомобиля.
		/// </summary>
		public int BrandId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Марка данной модели автомобиля.
		/// </summary>
		public virtual Brand Brand { get; set; }

		#endregion

	}

	/// <summary>
	/// Описывает конфигурацию модели сущности "Модель автомобиля".
	/// </summary>
	internal class ModelEntityTypeConfiguration : EntityTypeConfiguration<Model>
	{
		public ModelEntityTypeConfiguration()
		{
			ToTable("Models");

			HasKey(m => m.Id);

			Property(m => m.Name).HasMaxLength(50);

			HasRequired(m => m.Brand)
				.WithMany(b => b.Models)
				.HasForeignKey(m => m.BrandId);
		}
	}
}