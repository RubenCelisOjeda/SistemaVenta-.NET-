using Entidades.Dto.Empleado;
using SistemaVenta_MVC.Utils;
using System;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosEmpleado
    {
        /// <summary>
        /// Metodo que consulta todos los empleados.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoEmpleadoList> GetEmpleado()
        {
            IList<DtoEmpleadoList> lista = new List<DtoEmpleadoList>();

            var urlClient = string.Format("/Api/Empleados/");
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
        /// Metodo que consulta los datos de un empleado por Id.
        /// </summary>
        /// <param name="pIdEmpleado">Id del empleado a consultar</param>
        /// <returns>DtoUsuario</returns>
        public DtoEmpleado GetByEmpleado(int pIdEmpleado)
        {
            DtoEmpleado lista = new DtoEmpleado();

            var urlClient = string.Format("/Api/Empleados/{0}", pIdEmpleado);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoEmpleado>>(urlClient).Lista;

            if (responseClient.Count > 0)
            {
                foreach (var item in responseClient)
                {
                    var data = new DtoEmpleado()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        ApellidoPaterno = item.ApellidoPaterno,
                        ApellidoMaterno = item.ApellidoMaterno,
                        FechaNacimiento = item.FechaNacimiento,
                        EstadoCivil = item.EstadoCivil,
                        Direccion = item.Direccion
                    };
                    lista = data;
                }
            }
            return lista;
        }

        /// <summary>
        /// Metodo que filtra por nombre de empleado.
        /// </summary>
        /// <param name="pValor">Valor del empleado a consultar</param>
        /// <returns>IList</returns>
        public IList<DtoEmpleadoList> GetByEmpleado(string pValor)
        {
            IList<DtoEmpleadoList> lista = new List<DtoEmpleadoList>();

            var urlClient = string.Format("/Api/Empleados/Filtro/{0}", pValor);
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
        /// Metodo que registra un empleado.
        /// </summary>
        /// <param name="pEntidad">Entidad que tiene datos del empleado.</param>
        /// <returns>bool</returns>
        public bool AddEmpleado(DtoEmpleadoInsert pEntidad)
        {
            bool response = false;

            var urlClient = string.Format("/Api/Empleados");
            var restClient = new RestService();
            var responseClient = restClient.PostAsync<Respuesta<DtoEmpleadoInsert>>(urlClient, pEntidad);

            if (responseClient.CodigoError == 0)
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }

        /// <summary>
        /// Metodo que actualiza un empleado.
        /// </summary>
        /// <param name="pEntidad">Entidad que tiene datos del empleado.</param>
        /// <returns>bool</returns>
        public bool UpdateEmpleado(DtoEmpleadoInsert pEntidad)
        {
            bool response = false;

            var urlClient = string.Format("/Api/Empleados");
            var restClient = new RestService();
            var responseClient = restClient.PostAsync<Respuesta<DtoEmpleadoInsert>>(urlClient, pEntidad);

            if (responseClient.CodigoError == 0)
            {
                response = false;
            }
            else
            {
                response = true;
            }
            return response;
        }

        /// <summary>
        /// Metodo que obtiene por id del empleado.
        /// </summary>
        /// <param name="pIdEmpleado">Id del empleado</param>
        /// <returns>int</returns>
        public int DeleteEmpleado(int pIdEmpleado)
        {
            int response = 0;

            var urlClient = string.Format("/Api/Empleados/{0}", pIdEmpleado);
            var restClient = new RestService();
            var responseClient = restClient.DeleteAsync<Respuesta<DtoEmpleadoInsert>>(urlClient);

            if (responseClient.CodigoError == 0)
            {
                response = 1;
            }
            else
            {
                response = 0;
            }
            return response;
        }

        /// <summary>
        /// Metodo que obtiene en combo por empleado.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoComboEmpleado> GetComboEmpleado()
        {
            List<DtoComboEmpleado> lista = new List<DtoComboEmpleado>();

            var urlClient = string.Format("/Api/Parametros/{0}/{1}/{2}", 0, 2, true);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoComboEmpleado>>(urlClient);

            if (responseClient.CantidadElementos > 0)
            {
                foreach (var item in responseClient.Lista)
                {
                    if (item.Valor1 != null)
                    {
                        var data = new DtoComboEmpleado()
                        {
                            Id = Convert.ToInt32(item.Valor1),
                            Empleado = item.Nombre
                        };
                        lista.Add(data);
                    }
                }
            }
            return lista;
        }
    }
}
