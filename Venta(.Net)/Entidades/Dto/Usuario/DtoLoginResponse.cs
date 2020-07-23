using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dto.Usuario
{
    public class DtoLoginResponse
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoLoginResponse()
        {
            this.Id = 0;
            this.Rol = string.Empty;
            this.Usuario = string.Empty;
            this.Status = string.Empty;
            this.Email = string.Empty;
            this.Count = 0;
        }

        /// <summary>
        /// Atributos
        /// </summary>
        public int Id { get; set; }
        public string Rol { get; set; }
        public string Usuario { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public int Count { get; set; }
    }
}
