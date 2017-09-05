using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETOS.Core.DTO
{
	public class DtoLocation
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public bool IsPOI { get; set; }

		public int CultureId { get; set; }
	}
}
