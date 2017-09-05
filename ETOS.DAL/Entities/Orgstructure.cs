using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// Описывает сущность "Оргструктура".
	/// Данная сущность обозначает оргструктуру, входящую в состав компании.
	/// </summary>
	public class Orgstructure : IEntity
	{
		#region Fields

		/// <summary>
		/// Код оргструктуры.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название оргструктуры.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Код оргструктуры, являющейся родительской по отношению к данной.
		/// </summary>
		public int ? ParentOrgstructureId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// Оргструктура, являющаяся родительской по отношению к данной.
		/// </summary>
		public virtual Orgstructure ParentOrgstructure { get; set; }

		/// <summary>
		/// Список оргструктур, являющихся дочерними по отношению к данной.
		/// </summary>
		public virtual ICollection<Orgstructure> ChildOrgstructures { get; set; }

		#endregion

	}

	/// <summary>
	/// Обеспечивает настройку модели сущности-типа "Оргструктура".
	/// </summary>
	internal class OrgstructureEntityTypeConfiguration : EntityTypeConfiguration<Orgstructure>
	{
		public OrgstructureEntityTypeConfiguration()
		{
			ToTable("Orgstructures");

			HasKey(o => o.Id);

			Property(o => o.Name).HasMaxLength(100);
			Property(o => o.ParentOrgstructureId).IsOptional();

			// Связь "Ноль-или-один-к-нулю-или-многим" с сущностью "Оргструктура" (Родительская-дочерняя(ие)).ы
			HasOptional(o => o.ParentOrgstructure)
				.WithMany(po => po.ChildOrgstructures)
				.HasForeignKey(o => o.ParentOrgstructureId);
		}
	}
}
