using System;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущности типа "Сотрудник".
	/// </summary>
	public interface IEmployeeRepository : IRepository<Employee> { }
}
