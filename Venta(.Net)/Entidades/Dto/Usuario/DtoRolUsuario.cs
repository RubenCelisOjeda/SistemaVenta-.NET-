using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto.Usuario
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoRolUsuario
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoRolUsuario()
        {
            this.Id = 0;
            this.NroGrupo = 0;
            this.Nombre = string.Empty;
            this.Valor1 = string.Empty;
            this.Valor2 = string.Empty;
            this.Valor3 = string.Empty;
            this.Estado = false;
        }

        /// <summary>
        /// Atributos
        /// </summary>
        public int Id { get; set; }
        public int NroGrupo { get; set; }
        public string Nombre { get; set; }
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public bool Estado { get; set; }
    }
}
