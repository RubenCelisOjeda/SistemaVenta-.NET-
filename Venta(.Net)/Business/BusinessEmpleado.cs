using Datos;
using Entidades.Dto.Empleado;
using System.Collections.Generic;

namespace Business
{
    public class BusinessEmpleado
    {
        private DatosEmpleado oEmpleado = new DatosEmpleado();

        public IList<DtoEmpleadoList> GetEmpleado()
        {
            return oEmpleado.GetEmpleado();
        }

        public DtoEmpleado GetByEmpleado(int pIdEmpleado)
        {
            return oEmpleado.GetByEmpleado(pIdEmpleado);
        }

        public IList<DtoEmpleadoList> GetByEmpleado(string pValor)
        {
            return oEmpleado.GetByEmpleado(pValor);
        }

        public bool AddEmpleado(DtoEmpleadoInsert pEntidad)
        {
            return oEmpleado.AddEmpleado(pEntidad);
        }

        public bool UpdateEmpleado(DtoEmpleadoInsert pEntidad)
        {
            return oEmpleado.UpdateEmpleado(pEntidad);
        }

        public int DeleteEmpleado(int pIdEmpleado)
        {
            return oEmpleado.DeleteEmpleado(pIdEmpleado);
        }

        public IList<DtoComboEmpleado> GetComboEmpleado()
        {
            return oEmpleado.GetComboEmpleado();
        }
    }
}
