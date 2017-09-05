using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ETOS.WSL.Abstract
{
	[ServiceContract]
	public interface IMileageCalculatingService
	{
		[OperationContract]
		int GetMileage(string addressFrom, string addressTo);
	}	
}
