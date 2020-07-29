using Entidades.Dto.Empleado;
using Entidades.Dto.Usuario;
using SistemaVenta_MVC.Utils;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosUsuario
    {
        /// <summary>
        /// Metodo que autentica el usuario.
        /// </summary>
        /// <param name="pEntidad">Entidad que contiene los datos</param>
        /// <returns>DtoLoginResponse</returns>
        public DtoLoginResponse Login(DtoLoginRequest pEntidad)
        {
            var urlClient = string.Format("api/Usuarios/Validar");
            var restClient = new RestService();
            var responseClient = restClient.PostAsync<RespuestaLogin<DtoLoginResponse>>(urlClient, pEntidad);

            DtoLoginResponse data = null;

            if (responseClient.Count != 0)
            {
                data = new DtoLoginResponse()
                {
                    Id = responseClient.Dto.Id,
                    Usuario = responseClient.Dto.Usuario,
                    Rol = responseClient.Dto.Rol,
                    Status = responseClient.Dto.Status,
                    Email = responseClient.Dto.Email,
                    Count = responseClient.Count == 0 ? 0 : 1
                };
            }
            return data;
        }

        /// <summary>
        /// Metodo que consulta todos los usuarios.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoUsuarioGrilla> GetUsuario()
        {
            IList<DtoUsuarioGrilla> lista = new List<DtoUsuarioGrilla>();

            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoUsuarioGrilla>>(urlClient).Lista;

            if (responseClient.Count > 0)
            {
                foreach (var item in responseClient)
                {
                    var data = new DtoUsuarioGrilla()
                    {
                        Id = item.Id,
                        UsuarioName = item.UsuarioName,
                        Password = item.Password,
                        Email = item.Email,
                        RolUsuario = item.RolUsuario,
                        Estado = item.Estado,
                        FechaRegistro = item.FechaRegistro,
                        Empleado = item.Empleado
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

        /// <summary>
        /// Metodo que consulta los datos de un usuario por Id.
        /// </summary>
        /// <param name="pId">Id del usuario a consultar</param>
        /// <returns>DtoUsuario</returns>
        public DtoUsuario GetByUsuario(int pId)
        {
            DtoUsuario dtoUsuario = null;

            var urlClient = string.Format("/Api/Usuarios/{0}", pId);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoUsuario>>(urlClient);

            foreach (var item in responseClient.Lista)
            {
                var data = new DtoUsuario()
                {
                    Id = item.Id,
                    UsuarioName = item.UsuarioName,
                    Password = item.Password,
                    Email = item.Email,
                    RoId = item.RoId,
                    Estado = item.Estado,
                    FechaRegistro = item.FechaRegistro,
                    IdEmpleado = item.IdEmpleado,
                    Status = item.Status
                };
                dtoUsuario = data;
            }
            return dtoUsuario;
        }

        /// <summary>
        /// Metodo que filtra por nombre de usuario.
        /// </summary>
        /// <param name="pValor">Valor del usuario a consultar</param>
        /// <returns>IList</returns>
        public IList<DtoUsuarioGrilla> GetByUsuario(string pValor)
        {
            List<DtoUsuarioGrilla> dtoUsuario = new List<DtoUsuarioGrilla>();

            var urlClient = string.Format("/Api/Usuarios/Filtro/{0}", pValor);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoUsuarioGrilla>>(urlClient);

            foreach (var item in responseClient.Lista)
            {
                var data = new DtoUsuarioGrilla()
                {
                    Id = item.Id,
                    UsuarioName = item.UsuarioName,
                    Password = item.Password,
                    Email = item.Email,
                    RolUsuario = item.RolUsuario,
                    Estado = item.Estado,
                    FechaRegistro = item.FechaRegistro,
                    Empleado = item.Empleado
                };
                dtoUsuario.Add(data);
            }
            return dtoUsuario;
        }

        /// <summary>
        /// Metodo que registra un usuario.
        /// </summary>
        /// <param name="pEntidad">Entidad que tiene datos del usuario.</param>
        /// <returns>bool</returns>
        public bool AddUsuario(DtoUsuarioInsert pEntidad)
        {
            bool response = false;

            var urlClient = string.Format("/Api/Usuarios");
            var restClient = new RestService();
            var responseClient = restClient.PostAsync<Respuesta<DtoUsuarioInsert>>(urlClient, pEntidad);

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
        /// Metodo que actualiza un usuario.
        /// </summary>
        /// <param name="pEntidad">Entidad que tiene datos del usuario.</param>
        /// <returns>bool</returns>
        public bool UpdateUsuario(DtoUsuarioInsert pEntidad)
        {
            bool response = false;

            var urlClient = string.Format("/Api/Usuarios");
            var restClient = new RestService();
            var responseClient = restClient.PostAsync<Respuesta<DtoUsuarioInsert>>(urlClient, pEntidad);

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
        /// Metodo que obtiene por id el usuario.
        /// </summary>
        /// <param name="pId">Id del usuario</param>
        /// <returns>int</returns>
        public int DeleteUsuario(int pId)
        {
            int response = 0;

            var urlClient = string.Format("/Api/Usuarios/{0}", pId);
            var restClient = new RestService();
            var responseClient = restClient.DeleteAsync<Respuesta<DtoUsuario>>(urlClient);

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
        /// Metodo que obtiene combo en empleado.
        /// </summary>
        /// <param name="pIdCombo">Tipo del firltro del combo</param>
        /// <param name="pIdUsuario">Id del usuario</param>
        /// <returns>IList</returns>
        public IList<DtoComboEmpleado> GetComboEmpleado(int pIdCombo = 0, int pIdUsuario = 0)
        {
            List<DtoComboEmpleado> lista = new List<DtoComboEmpleado>();

            var urlClient = string.Format("/Api/Empleados/Combo/{0}/{1}", pIdCombo, pIdUsuario);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoComboEmpleado>>(urlClient);

            if (responseClient.Lista != null)
            {
                foreach (var item in responseClient.Lista)
                {
                    var data = new DtoComboEmpleado()
                    {
                        Id = item.Id,
                        Empleado = item.Empleado
                    };
                    lista.Add(data);
                }
            }
            return lista;
        }

        /// <summary>
        /// Metodo que obtiene en combo por usuario.
        /// </summary>
        /// <returns>IList</returns>
        public IList<DtoRolUsuario> GetComboRolUsuario()
        {
            List<DtoRolUsuario> lista = new List<DtoRolUsuario>();

            var urlClient = string.Format("/Api/Parametros/{0}/{1}/{2}", 0, 1,true);
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoRolUsuario>>(urlClient);

            if (responseClient.CantidadElementos > 0)
            {
                foreach (var item in responseClient.Lista)
                {
                    if (item.Valor1 != null)
                    {
                        var data = new DtoRolUsuario()
                        {
                            Valor1 = item.Valor1,
                            Nombre = item.Nombre
                        };
                        lista.Add(data);
                    }
                }
            }
            return lista;
        }
    }
}
