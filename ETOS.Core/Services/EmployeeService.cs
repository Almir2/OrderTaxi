using ETOS.Core.Services.Abstract;
using ETOS.DAL.Entities;
using ETOS.DAL.Interfaces;
using System.Linq;

namespace ETOS.Core.Services
{
    /// <summary>
    /// Сервис, реализующий функционал для работы с учетными данными пользователей системы на уровне бизнес-логики.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        #region Fields

        /// <summary>
        /// Экземпляр репозитория аккаунтов.
        /// </summary>
        private IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructor

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Methods
        public Employee GetUserLastName(string id)
        {
            var userName = _employeeRepository.Find(e => e.UserId == id).FirstOrDefault();

            return userName;
        }
        
    
        #endregion
    }
}
