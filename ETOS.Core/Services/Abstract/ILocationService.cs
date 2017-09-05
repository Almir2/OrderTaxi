using ETOS.Core.DTO;
using System.Collections.Generic;

namespace ETOS.Core.Services.Abstract
{
    public interface ILocationService
    {
        List<DtoPointOfInterest> GetPOIList();
        DtoPointOfInterest GetPOIById(int id);
    }
}
