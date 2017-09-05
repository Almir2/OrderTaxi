using System;

using ETOS.WSL.Abstract;

namespace ETOS.WSL
{
	public class RequestPriceCalculatingService : IRequestPriceCalculatingService
	{
		public decimal CalculateRequestPrice(float distance, decimal tariff)
		{
			return (decimal)distance * tariff;
		}
	}
}
