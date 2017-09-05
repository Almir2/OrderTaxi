namespace ETOS.Core.DTO
{
    /// <summary>
    /// Информация о подрядчике
    /// нужна для того чтобы на UI закинуть список подрядчиков и их информацию
    /// </summary>
    public class DtoContractorInfo
    {
        /// <summary>
        /// Содержимое локации - точки интереса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// id - точки интереса в БД
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Телефон подрядчика
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Стоимость за 1 км
        /// </summary>
        public decimal Tariff { get; set; }

        /// <summary>
        /// Стоимость данной поездки
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
