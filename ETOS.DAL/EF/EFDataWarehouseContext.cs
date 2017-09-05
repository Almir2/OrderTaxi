using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNet.Identity.EntityFramework;

using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;

namespace ETOS.DAL.EF
{
	/// <summary>
	/// Реализует соединение с базой данных, а также обеспечивает работу с её контекстом и моделью.
	/// </summary>
	public class EFDataWarehouseContext : IdentityDbContext<ApplicationUser>, IDataWarehouseContext
	{
		#region Constructor

		public EFDataWarehouseContext() : base("name=ETOSDataWarehouse") { }

		#endregion

		#region Methods

		/// <summary>
		/// Осуществляет настройку базы данных при её создании.
		/// </summary>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Отключение каскадного удаления связанных данных EF.
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder.Configurations.Add(new IdentityUserEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new IdentityUserLoginEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new IdentityRoleEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new IdentityUserRoleEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new IdentityUserClaimEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new BrandEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new ModelEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new VehicleEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new LocationEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new OrgstructureEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new PositionEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new TransportTypeEntityConfiguration());
			modelBuilder.Configurations.Add(new StatusEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new PriorityEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new ContractorEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new EmployeeEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new CustomerEntityTypeConfiguration());
			modelBuilder.Configurations.Add(new RequestEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new LogEntityTypeConfiguration());
		}

		/// <summary>
		/// Возвращает набор экземпляров сущностей заданного типа.
		/// </summary>
		/// <typeparam name="TEntity">Необходимая сущность-тип.</typeparam>
		public new IDbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
		{
			return base.Set<TEntity>();
		}

		/// <summary>
		/// Реализует асинхронное сохранение изменений в хранилище.
		/// </summary>
		public new async Task SaveChangesAsync()
		{
			await base.SaveChangesAsync();
		}
		
		#endregion
	}
}

