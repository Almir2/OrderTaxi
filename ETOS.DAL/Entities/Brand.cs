using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает марку автомобиля.
	/// </summary>
	public class Brand : IEntity
	{
		#region Fields

		/// <summary>
		/// Код марки автомобиля.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название марки автомобиля.
		/// </summary>
		public string Name { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Список моделей данной марки автомобиля.
		/// </summary>
		public virtual ICollection<Model> Models { get; set; }

		#endregion
	}

	internal class BrandEntityTypeConfiguration : EntityTypeConfiguration<Brand>
	{
		public BrandEntityTypeConfiguration()
		{
			ToTable("Brands");

			HasKey(b => b.Id);

			Property(b => b.Name).HasMaxLength(50);

			HasMany(b => b.Models)
				.WithRequired(m => m.Brand)
				.HasForeignKey(m => m.BrandId);
		}
	}
}
