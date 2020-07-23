using Datos;
using Entidades.Dto.Empleado;
using Entidades.Dto.Usuario;
using SistemaVenta_MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessUsuario
    {
        private DatosUsuario oUsuario = new DatosUsuario();

        public DtoLoginResponse Login (DtoLoginRequest pEntidad)
        {
            return this.oUsuario.Login(pEntidad);
        }

        public IList<DtoUsuarioGrilla> GetUsuario()
        {
            return this.oUsuario.GetUsuario();
        }

        public DtoUsuario GetByUsuario(int pId)
        {
            return this.oUsuario.GetByUsuario(pId);
        }

        public bool AddUsuario(DtoUsuarioInsert pEntidad)
        {
            return this.oUsuario.AddUsuario(pEntidad);
        }

        public bool UpdateUsuario(DtoUsuarioInsert pEntidad)
        {
            return this.oUsuario.UpdateUsuario(pEntidad);
        }

        public int DeleteUsuario(int pId)
        {
            return this.oUsuario.DeleteUsuario(pId);
        }

        public IList<DtoComboEmpleado> GetComboEmpleado(int pIdCombo = 0, int pIdUsuario = 0)
        {
            return this.oUsuario.GetComboEmpleado(pIdCombo, pIdUsuario);
        }

        public IList<DtoRolUsuario> GetComboRolUsuario()
        {
            return this.oUsuario.GetComboRolUsuario();
        }

       
    }
}
