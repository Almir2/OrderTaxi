namespace ETOS.Core.DTO
{
    /// <summary>
    /// Объект передачи данных между моделью уровня представления и уровнем доступа к данным.
    /// Представляет собой разрешения для пользователя
    /// </summary>
    public class DtoPermission
    {
        #region Fields

        /// <summary>
        /// Код разрешения.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Табельный номер сотрудника, которому устанавливаются разрешения.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Флаг, определяющий доступ обычного пользователя.
        /// </summary>
        public bool IsUser { get; set; }

        /// <summary>
        /// Флаг, определяющий доступ секретаря.
        /// </summary>
        public bool IsSecretary { get; set; }

        /// <summary>
        /// Флаг, определяющий доступ бухгалтера.
        /// </summary>
        public bool IsAccountant { get; set; }

        /// <summary>
        /// Флаг, определяющий доступ руководящего лица.
        /// </summary>
        public bool IsManager { get; set; }

        /// <summary>
        /// Флаг, определяющий доступ администратора системы.
        /// </summary>
        public bool IsAdministrator { get; set; }

        #endregion
    }
}
