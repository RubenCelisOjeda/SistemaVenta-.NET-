using Datos;
using Entidades.Dto.Cliente;
using System;
using System.Collections.Generic;

namespace Business
{
    public class BusinessCliente 
    {
        private DatosCliente datosCliente = new DatosCliente();

        public IList<DtoClienteList> GetAll()
        {
            return datosCliente.GetAll();
        }

        public bool Delete(int pIdCliente)
        {
            throw new NotImplementedException();
        }

        public IList<DtoClienteList> Get(int pIdCliente)
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

        public bool Validate(int pIdCliente)
        {
            throw new NotImplementedException();
        }
    }
}
