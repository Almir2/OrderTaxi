using System;
using System.ServiceModel;

namespace ETOS.WSL.Abstract
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IRequestPriceCalculatingService" в коде и файле конфигурации.
	[ServiceContract]
	public interface IRequestPriceCalculatingService
	{
		[OperationContract]
		decimal CalculateRequestPrice(float distance, decimal tariff);
	}
}
