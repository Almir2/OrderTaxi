namespace ETOS.Core.DTO
{
    /// <summary>
    /// Точка интереса , название и Id из БД
    /// нужна для того чтобы на UI закинуть список точек интереса
    /// </summary>
    public class DtoPointOfInterest
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
	/// Адрес POI
	/// </summary>
	public string Address { get; set; }
    }
}
