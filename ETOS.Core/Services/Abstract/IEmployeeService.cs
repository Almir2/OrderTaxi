using ETOS.Core.DTO;
using ETOS.DAL.Entities;

namespace ETOS.Core.Services.Abstract
{
    /// <summary>
    /// Интерфейс сервиса по работе с работниками
    /// </summary>
    public interface IEmployeeService
    {
        Employee GetUserLastName(string id);
    }
}
