using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto.Empleado
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoComboEmpleado
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoComboEmpleado()
        {
            this.Id = 0;
            this.Empleado = string.Empty;
        }

        /// <summary>
        /// Atributos
        /// </summary>
        public int Id { get; set; }
        public string Empleado { get; set; }
    }
}
