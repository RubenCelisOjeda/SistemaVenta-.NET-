using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta_.Net_.App.Mantenimiento
{
    public partial class FrmEmpleado : Form
    {
        private int IdUsuario { get; set; }
        private string Accion = "";

        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void BotonNuevo()
        {
            this.Accion = "Guardar";

            TabPage t = this.tbcUsuario.TabPages[1];
            this.tbcUsuario.SelectedTab = t;

            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.dgvEmpleados.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.BotonEditar();
        }

        private void BotonEditar()
        {
            this.Accion = "Actualizar";

            if (IdUsuario == 0)
            {
                MessageBox.Show("Seleccione un registro para editar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TabPage t = this.tbcUsuario.TabPages[1];
                this.tbcUsuario.SelectedTab = t;

                //this.HabilitarControles(true);
                this.cmbEmpleado.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

                if (IdUsuario == 0)
                {
                    IdUsuario = (int)this.dgvEmpleados.Rows[this.dgvEmpleados.CurrentRow.Index].Cells[0].Value;
                }

                //DtoUsuario dtoUsuario = null;
                //dtoUsuario = this.oUsuario.GetByUsuario(IdUsuario);

                this.txtUsuarioId.Text = dtoUsuario.Id.ToString();
                this.cmbRol.SelectedValue = dtoUsuario.RoId;
                this.txtEmail.Text = dtoUsuario.Email;
                this.txtUsuario.Text = dtoUsuario.UsuarioName;
                this.txtPassword.Text = dtoUsuario.Password;
                this.txtConfirmarPasswrod.Text = dtoUsuario.Password;
                this.cmbEmpleado.SelectedValue = dtoUsuario.IdEmpleado;
                if (this.cmbEmpleado.SelectedValue == null) this.cmbEmpleado.SelectedIndex = 0;
                this.txtFechaRegistro.Text = dtoUsuario.FechaRegistro.ToString();
                this.chkEstado.Checked = dtoUsuario.Status == 1 ? true : false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.BotoEliminar();
        }

        private void BotoEliminar()
        {
            if (IdUsuario != 0)
            {
                DialogResult messgae = MessageBox.Show("¿Desea eliminar el registro?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (messgae == DialogResult.Yes)
                {
                    int response = 0;
                    //response = this.oUsuario.DeleteUsuario(IdUsuario);

                    if (response == 0)
                    {
                        MessageBox.Show("Ocurrio un error,comuniquese con el administrador", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se elimino correctamente.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.dgvEmpleados.Rows.RemoveAt(this.dgvEmpleados.CurrentRow.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
