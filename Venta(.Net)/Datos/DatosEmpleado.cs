using Entidades.Dto.Empleado;
using SistemaVenta_MVC.Utils;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosEmpleado
    {
        /// <summary>
        /// Metodo que consulta los datos de un cliente por Id.
        /// </summary>
        /// <param name="pIdCliente">Id del cliente a consultar</param>
        /// <returns>IList</returns>
        public IList<DtoEmpleadoList> Get(int pIdCliente)
        {
            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoEmpleadoList>>(urlClient).Lista;

            return responseClient;
        }

        /// <summary>
        /// Metodo que consulta los datos de un empleado por Id.
        /// </summary>
        /// <param name="pId">Id del usuario a consultar</param>
        /// <returns>DtoUsuario</returns>
        public IList<DtoEmpleadoList> GetEmpleado(int pId)
        {
            IList<DtoEmpleadoList> lista = new List<DtoEmpleadoList>();

            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoEmpleadoList>>(urlClient).Lista;

            if (responseClient.Count > 0)
            {
                foreach (var item in responseClient)
                {
                    var data = new DtoEmpleadoList()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        ApellidoPaterno = item.ApellidoPaterno,
                        ApellidoMaterno = item.ApellidoMaterno,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Direccion = item.Direccion
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

        /// <summary>
        /// Metodo que consulta todos los empleados.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoEmpleadoList> GetEmpleado()
        {
            IList<DtoEmpleadoList> lista = new List<DtoEmpleadoList>();

            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoEmpleadoList>>(urlClient).Lista;

            if (responseClient.Count > 0)
            {
                foreach (var item in responseClient)
                {
                    var data = new DtoEmpleadoList()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        ApellidoPaterno = item.ApellidoPaterno,
                        ApellidoMaterno = item.ApellidoMaterno,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Direccion = item.Direccion
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

    }
}
