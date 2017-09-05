using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ETOS.DAL.EF;
using ETOS.DAL.Repositories;

namespace ETOS.Tests
{
	[TestClass]
	public class DALTests
	{ 
		/// <summary>
		/// Тестовый метод, реализующий проверку корректности удаления заданного сотрудника репозиторием.
		/// </summary>
		[TestMethod]
		public void EmployeeRepositoryRemovesEmployeeCorrect()
		{
			// Arrange.
			var dataWarehouseContext = new EFDataWarehouseContext();

			EmployeeRepository employeeRepository = new EmployeeRepository(dataWarehouseContext);

			// Act.
			var newEmployee = employeeRepository.Find(emp => (emp.Firstname == "Егор")).FirstOrDefault();

			if (newEmployee != null)
			{
				int id = newEmployee.Id;
				employeeRepository.Delete(id);
				employeeRepository.Commit();
			}

			newEmployee = employeeRepository.Find(emp => (emp.Firstname == "Егор")).FirstOrDefault();

			// Assert.
			Assert.AreEqual(null, newEmployee);

		}
	}
}
