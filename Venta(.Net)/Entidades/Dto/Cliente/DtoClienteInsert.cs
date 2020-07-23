namespace Entidades.Dto.Cliente
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoClienteInsert
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoClienteInsert()
        {
            this.Id = 0;
            this.Nombres = string.Empty;
            this.ApellidoPaterno = string.Empty;
            this.ApellidoMaterno = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
    }
}
