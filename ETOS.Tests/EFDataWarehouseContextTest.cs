using System;
using System.Linq;
using System.Data.Entity;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ETOS.DAL.EF;
using ETOS.DAL.Entities;

namespace ETOS.Tests
{
	/// <summary>
	/// Тестирует корректность работы контекста хранилища данных.
	/// </summary>
	[TestClass]
	public class EFDataWarehouseContextTest
	{
		/// <summary>
		/// Тестирует корректность работы контекста хранилища данных с сущностью "Марка автомобиля".
		/// </summary>
		[TestClass]
		public class BrandEntityTypeTest
		{
			/// <summary>
			/// Тестовый метод, осуществляющий проверку корректности добавления новой марки автомобиля в базу данных.
			/// </summary>
			[TestMethod]
			public void CreatesNewBrandCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(brand));

						transaction.Rollback();
					}
				}
			}

			/// <summary>
			/// Тестовый метод, реализующий проверку корректности обновления данных марки автомобиля в базе данных.
			/// </summary>
			[TestMethod]
			public void UpdatesBrandCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(brand));

						var expectedResult = brand.Name = "Toyota";

						dataWarehouseContext.Entry(brand).State = EntityState.Modified;
						dataWarehouseContext.SaveChanges();

						Assert.AreEqual(expectedResult, dataWarehouseContext.Entry(brand).Entity.Name);

						transaction.Rollback();
					}
				}
			}

			/// <summary>
			/// Тестовый метод, реализующий проверку корректности удаления марки автомобиля из базы данных.
			/// </summary>
			[TestMethod]
			public void RemovesBrandCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(brand));

						dataWarehouseContext.Set<Brand>().Remove(brand);
						dataWarehouseContext.SaveChanges();

						Assert.IsNull(dataWarehouseContext.Set<Brand>()
							.FirstOrDefault(b => b.Id == brand.Id));

						transaction.Rollback();
					}
				}
			}
		}

		/// <summary>
		/// Тестирует корректность работы контекста хранилища данных с сущностью "Модель автомобиля".
		/// </summary>
		[TestClass]
		public class ModelEntityTypeTest
		{
			/// <summary>
			/// Тестовый метод, осуществляющий проверку корректности добавления новой модели автомобиля в базу данных.
			/// </summary>
			[TestMethod]
			public void CreatesNewModelCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						var model = new Model { Name = "Rio", Brand = brand };

						dataWarehouseContext.Set<Model>().Add(model);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(model));

						transaction.Rollback();
					}
				}
			}

			/// <summary>
			/// Тестовый метод, реализующий проверку корректности обновления данных модели автомобиля в базе данных.
			/// </summary>
			[TestMethod]
			public void UpdatesModelCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						var model = new Model { Name = "Rio", Brand = brand };

						dataWarehouseContext.Set<Model>().Add(model);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(model));

						var expectedResult = model.Name = "Sportage";

						dataWarehouseContext.Entry(model).State = EntityState.Modified;
						dataWarehouseContext.SaveChanges();

						Assert.AreEqual(expectedResult, dataWarehouseContext.Entry(model).Entity.Name);

						transaction.Rollback();
					}
				}
			}

			/// <summary>
			/// Тестовый метод, реализующий проверку корректности удаления модели автомобиля из базы данных.
			/// </summary>
			[TestMethod]
			public void RemovesBrandCorrect()
			{
				using (var dataWarehouseContext = new EFDataWarehouseContext())
				{
					using (var transaction = dataWarehouseContext.Database.BeginTransaction())
					{
						var brand = new Brand { Name = "KIA" };

						dataWarehouseContext.Set<Brand>().Add(brand);
						dataWarehouseContext.SaveChanges();

						var model = new Model { Name = "Rio", Brand = brand };

						dataWarehouseContext.Set<Model>().Add(model);
						dataWarehouseContext.SaveChanges();

						Assert.IsNotNull(dataWarehouseContext.Entry(model));

						dataWarehouseContext.Set<Model>().Remove(model);
						dataWarehouseContext.SaveChanges();

						Assert.IsNull(dataWarehouseContext.Set<Model>()
							.FirstOrDefault(m => m.Id == model.Id));

						transaction.Rollback();
					}
				}
			}
		}
	}
}
