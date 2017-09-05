using System;

namespace ETOS.Core.Infrastructure
{
	/// <summary>
	/// Представляет результат выполнения операции.
	/// </summary>
	public class OperationResult
	{
		/// <summary>
		/// Флаг, определяющий успешность проведения операции.
		/// </summary>
		public bool Succeeded { get; }

		/// <summary>
		/// Сообщение.
		/// </summary>
		public string Message { get; }

		/// <summary>
		/// Имя свойство, в котором имеется ошибка (при наличии).
		/// </summary>
		public string PropertyName { get; }

		public OperationResult(bool succeeded, string message, string propertyName)
		{
			Succeeded = succeeded;
			Message = message;
			PropertyName = propertyName;
		}
	}
}
