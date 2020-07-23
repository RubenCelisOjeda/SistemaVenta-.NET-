using Entidades.Dto.Empleado;
using Entidades.Dto.Usuario;
using SistemaVenta_MVC.Utils;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosUsuario
    {
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
