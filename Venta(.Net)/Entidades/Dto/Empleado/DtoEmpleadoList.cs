using System;

namespace Entidades.Dto.Empleado
{
    public class DtoEmpleadoList
    {
        /// <summary>
        /// Contructor inicializa los atributos
        /// </summary>
        public DtoEmpleadoList()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.ApellidoPaterno = string.Empty;
            this.ApellidoMaterno = string.Empty;
            this.FechaNacimiento = DateTime.Now;
            this.EstadoCivil = string.Empty;
            this.Direccion = string.Empty;
        }

        /// <summary>
        /// Atributos
        /// </summary>
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
    }
}
