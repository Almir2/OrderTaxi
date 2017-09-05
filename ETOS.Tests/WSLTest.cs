using Microsoft.VisualStudio.TestTools.UnitTesting;

using ETOS.DAL.EF;
using ETOS.WSL;

namespace ETOS.Tests
{
	[TestClass]
	public class WSLTests
	{
		/// <summary>
		/// Проверяет соответствует ли расчетное расстояние между Москвой и Самарой - заданному
		/// </summary>
		[TestMethod]
		public void CheckDistanceBtwMoscowAndSamara()
		{
			using (var dataWarehouseContext = new EFDataWarehouseContext())
			{
				// Arrange.
				const int realDistance = 854;
				var mileageService = new MileageCalculatingService();

				// Act.
				var calcDistance = mileageService.GetMileage("Москва", "Самара");

				// Assert.
				Assert.AreEqual(realDistance, calcDistance);
			}
		}
	}
}
