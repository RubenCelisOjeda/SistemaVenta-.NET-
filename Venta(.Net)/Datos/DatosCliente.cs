using Entidades.Dto.Cliente;
using SistemaVenta_MVC.Utils;
using System;
using System.Collections.Generic;
using Utils;

namespace Datos
{
    public class DatosCliente 
    {
        public IList<DtoClienteList> Get(int pIdCliente)
        {
            var urlClient = string.Format("/Api/Usuarios/");
            var restClient = new RestService();
            var responseClient = restClient.GetAsync<Respuesta<DtoClienteList>>(urlClient).Lista;

            return responseClient;
        }

        public IList<DtoClienteList> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(DtoClienteInsert pEntidad)
        {
            throw new NotImplementedException();
        }

        public bool Update(DtoClienteInsert pEntidad)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int pIdCliente)
        {
            throw new NotImplementedException();
        }

        public bool Validate(int pIdCliente)
        {
            throw new NotImplementedException();
        }
    }
}
