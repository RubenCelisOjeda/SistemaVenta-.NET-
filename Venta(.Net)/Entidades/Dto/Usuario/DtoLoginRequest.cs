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
    public class DtoLoginRequest
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoLoginRequest()
        {
            this.Id = 0;
            this.Usuario = string.Empty;
            this.Password = string.Empty;
        }

        /// <summary>
        /// Atributos
        /// </summary>
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
