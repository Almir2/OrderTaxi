using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Core.DTO
{
	/// <summary>
	/// Представляет собой объект передачи данных ролей между уровнем представления и уровнем доступа к данным.
	/// </summary>
	public class DtoUserRole
	{
		/// <summary>
		/// Название роли.
		/// </summary>
		public string Name { get; set; }
	}
}
