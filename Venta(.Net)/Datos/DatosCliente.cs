using Entidades.Dto.Cliente;
using SistemaVenta_MVC.Utils;
using System;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosCliente 
    {
        /// <summary>
        /// Metodo que consulta los datos de un cliente por Id.
        /// </summary>
        /// <param name="pIdCliente">Id del cliente a consultar</param>
        /// <returns>IList</returns>
        public IList<DtoClienteList> Get(int pIdCliente)
        {
            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoClienteList>>(urlClient).Lista;

            return responseClient;
        }

        /// <summary>
        /// Metodo que consulta todos los clientes.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoClienteList> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que registra un cliente.
        /// </summary>
        /// <param name="pEntidad">Entidad que contiene todos los datos.</param>
        /// <returns>bool</returns>
        public bool Insert(DtoClienteInsert pEntidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que actualiza un cliente.
        /// </summary>
        /// <param name="pEntidad">Entidad que contiene todos los datos.</param>
        /// <returns>bool</returns>
        public bool Update(DtoClienteInsert pEntidad)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que eliminar un cliente de manera lógica.
        /// </summary>
        /// <param name="pIdCliente">Id del cliente a eliminar.</param>
        /// <returns>bool</returns>
        public bool Delete(int pIdCliente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que valida la existencia del usuario
        /// </summary>
        /// <param name="pIdCliente">Id del cliente a eliminar.</param>
        /// <returns>bool</returns>
        public bool Validate(int pIdCliente)
        {
            throw new NotImplementedException();
        }
    }
}
