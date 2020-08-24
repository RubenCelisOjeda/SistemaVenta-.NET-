using Business;
using Entidades.Dto.Empleado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Venta_.Net_.App.Mantenimiento
{
    public partial class FrmEmpleado : Form
    {
        private BusinessEmpleado oEmpleado = new BusinessEmpleado();
        private int IdEmpleado { get; set; }
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

            if (IdEmpleado == 0)
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

                if (IdEmpleado == 0)
                {
                    IdEmpleado = (int)this.dgvEmpleados.Rows[this.dgvEmpleados.CurrentRow.Index].Cells[0].Value;
                }

                DtoEmpleado dtoEmpleado = null;
                dtoEmpleado = this.oEmpleado.GetByEmpleado(IdEmpleado);

                //this.txtUsuarioId.Text = dtoEmpleado.Id.ToString();
                //this.cmbRol.SelectedValue = dtoEmpleado.RoId;
                //this.txtEmail.Text = dtoEmpleado.Email;
                //this.txtUsuario.Text = dtoEmpleado.UsuarioName;
                //this.txtPassword.Text = dtoEmpleado.Password;
                //this.txtConfirmarPasswrod.Text = dtoEmpleado.Password;
                //this.cmbEmpleado.SelectedValue = dtoEmpleado.IdEmpleado;
                //if (this.cmbEmpleado.SelectedValue == null) this.cmbEmpleado.SelectedIndex = 0;
                //this.txtFechaRegistro.Text = dtoUsuario.FechaRegistro.ToString();
                //this.chkEstado.Checked = dtoUsuario.Status == 1 ? true : false;
            }
        }

        private DataTable CreateDataTable<T>(IList<T> item)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            if (item != null)
            {
                foreach (T entity in item)
                {
                    object[] values = new object[properties.Length];

                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(entity);
                    }

                    dataTable.Rows.Add(values);
                }
            }
            return dataTable;
        }

        private void GetEmpleados()
        {
            DataTable dt = new DataTable();
            dt = CreateDataTable(this.oEmpleado.GetEmpleado());
            this.dgvEmpleados.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.BotoEliminar();
        }

        private void BotoEliminar()
        {
            if (IdEmpleado != 0)
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

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            this.GetEmpleados();
        }
    }
}
