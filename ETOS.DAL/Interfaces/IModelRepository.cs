using System;

using ETOS.DAL.Entities;

namespace ETOS.DAL.Interfaces
{
	/// <summary>
	/// Описывает функционал, необходимый для работы с экземплярами сущности типа "Модель автомобиля".
	/// </summary>
	public interface IModelRepository : IRepository<Model> { }
}
