using Business;
using Entidades.Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Venta_.Net_.App.Mantenimiento
{
    public partial class FrmUsuario : Form
    {
        private BusinessUsuario oUsuario = new BusinessUsuario();
        private int IdUsuario { get; set; }
        private string Accion = "";

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.ControlesInicializar();
            this.HabilitarControles(false);
            this.GetUsuarios();
            this.GetComboEmpleados(1, 0);
            this.GetComboRolesUsuarios();
            this.dgvUsuarios.Columns[0].Visible = false;
            this.Accion = "Guardar";
        }

        /// <summary>
        /// Se inicializa los botones por defecto habilitado
        /// </summary>
        private void ControlesInicializar()
        {
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Obtiene  los usuarios del servicio
        /// </summary>
        private void GetUsuarios()
        {
            DataTable dt = new DataTable();
            dt = CreateDataTable(this.oUsuario.GetUsuario());
            this.dgvUsuarios.DataSource = dt;
        }

        private void GetComboEmpleados(int pTipo,int pIdUsuario)
        {
            DataTable dt = new DataTable();
            dt = CreateDataTable(this.oUsuario.GetComboEmpleado(pTipo, pIdUsuario));
            DataRow row = dt.NewRow();

            row["Empleado"] = "Seleccione un empleado";
            dt.Rows.InsertAt(row, 0);

            this.cmbEmpleado.DataSource = dt;
            this.cmbEmpleado.ValueMember = "Id";
            this.cmbEmpleado.DisplayMember = "Empleado";
            this.cmbEmpleado.SelectedIndex = 0;
        }

        private void GetComboRolesUsuarios()
        {
            DataTable dt = new DataTable();
            dt = CreateDataTable(oUsuario.GetComboRolUsuario());
            DataRow row = dt.NewRow();

            row["Nombre"] = "Seleccione un rol";
            dt.Rows.InsertAt(row, 0);

            this.cmbRol.DataSource = dt;
            this.cmbRol.ValueMember = "Valor1";
            this.cmbRol.DisplayMember = "Nombre";
            this.cmbRol.SelectedIndex = 0;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Accion = "Guardar";
            this.GetComboEmpleados(1, 0);
            this.GetComboRolesUsuarios();

            TabPage t = this.tbcUsuario.TabPages[1];
            this.tbcUsuario.SelectedTab = t;

            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.dgvUsuarios.Enabled = false;

            this.HabilitarControles(true);
        }

        private void HabilitarControles(bool enable)
        {
            this.cmbRol.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtUsuario.Enabled = enable;
            this.txtPassword.Enabled = enable;
            this.txtConfirmarPasswrod.Enabled = enable;
            this.cmbEmpleado.Enabled = enable;
            this.chkEstado.Enabled = enable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TabPage t = this.tbcUsuario.TabPages[0];
            this.tbcUsuario.SelectedTab = t;
            this.HabilitarControles(false);

            this.cmbEmpleado.SelectedIndex = 0;
            this.cmbRol.SelectedIndex = 0;

            this.btnNuevo.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;

            this.dgvUsuarios.Enabled = true;
        }

        private void GuardarUsuario()
        {
            try
            {
                if (this.cmbRol.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un rol.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cmbRol.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtEmail.Text))
                {
                    MessageBox.Show("Ingrese email.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtEmail.Focus();
                }
                else if (!this.IsValidEmail(this.txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email inválido", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    MessageBox.Show("Ingrese usuario.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUsuario.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Ingrese contraseña.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtConfirmarPasswrod.Text))
                {
                    MessageBox.Show("Ingrese contraseña.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtConfirmarPasswrod.Focus();
                }
                else if (this.txtPassword.Text.Trim() != this.txtConfirmarPasswrod.Text.Trim())
                {
                    MessageBox.Show("Contraseñas no coinciden", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                }
                else if (this.cmbEmpleado.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un empleado.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cmbRol.Focus();
                }
                else
                {
                    var data = new DtoUsuarioInsert()
                    {
                        Id = 0,
                        RoId = (int)this.cmbRol.SelectedValue,
                        Email = this.txtEmail.Text.Trim(),
                        UsuarioName = this.txtUsuario.Text.Trim(),
                        Password = this.txtPassword.Text.Trim(),
                        IdEmpleado = Convert.ToInt32(this.cmbEmpleado.SelectedValue),
                        FechaRegistro = DateTime.Now,
                        Estado = 1,
                        Status = this.chkEstado.Checked == true ? 1 : 0
                    };

                    if (this.oUsuario.AddUsuario(data))
                    {
                        this.GetComboEmpleados(1, IdUsuario);
                        MessageBox.Show("Se guardo correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error comuniquese con el administrador.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUsuario()
        {
            try
            {
                if (this.cmbRol.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un rol.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cmbRol.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtEmail.Text))
                {
                    MessageBox.Show("Ingrese email.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtEmail.Focus();
                }
                else if (!this.IsValidEmail(this.txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email inválido", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    MessageBox.Show("Ingrese usuario.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUsuario.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Ingrese contraseña.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtConfirmarPasswrod.Text))
                {
                    MessageBox.Show("Ingrese contraseña.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtConfirmarPasswrod.Focus();
                }
                else if (this.txtPassword.Text.Trim() != this.txtConfirmarPasswrod.Text.Trim())
                {
                    MessageBox.Show("Contraseñas no coinciden", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                }
                else if (this.cmbEmpleado.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un empleado.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cmbRol.Focus();
                }
                else
                {
                    var data = new DtoUsuarioInsert()
                    {
                        Id = Convert.ToInt32(this.txtUsuarioId.Text),
                        RoId = Convert.ToInt32(this.cmbRol.SelectedValue),
                        Email = this.txtEmail.Text.Trim(),
                        UsuarioName = this.txtUsuario.Text.Trim(),
                        Password = this.txtPassword.Text.Trim(),
                        IdEmpleado = 1,
                        FechaRegistro = DateTime.Now,
                        Estado = 1,
                        Status = this.chkEstado.Checked == true ? 1 : 0
                    };

                    if (this.oUsuario.UpdateUsuario(data))
                    {
                        this.GetUsuarios();
                        MessageBox.Show("Se actualizo correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error,no se puedo actualizar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error comuniquese con el administrador.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (Accion)
            {
                case "Guardar":
                    {
                        this.GuardarUsuario();
                    }
                    break;

                case "Actualizar":
                    {
                        this.UpdateUsuario();
                    }
                    break;
                default:
                    {
                        this.GuardarUsuario();
                    }
                    break;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TabPage t = this.tbcUsuario.TabPages[1];
            this.tbcUsuario.SelectedTab = t;

            DtoUsuario dtoUsuario = null;

            IdUsuario = (int)this.dgvUsuarios.Rows[e.RowIndex].Cells[0].Value;
            dtoUsuario = this.oUsuario.GetByUsuario(IdUsuario);

            this.GetComboEmpleados(0, IdUsuario);
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

        private void btnEditar_Click(object sender, EventArgs e)
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
                
                this.HabilitarControles(true);
                this.cmbEmpleado.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

                if (IdUsuario == 0)
                {
                    IdUsuario = (int)this.dgvUsuarios.Rows[this.dgvUsuarios.CurrentRow.Index].Cells[0].Value;
                }
                
                DtoUsuario dtoUsuario = null;
                dtoUsuario = this.oUsuario.GetByUsuario(IdUsuario);

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
            if (IdUsuario != 0)
            {
                DialogResult messgae = MessageBox.Show("¿Desea eliminar el registro?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (messgae == DialogResult.Yes)
                {   
                    int response = 0;
                    response = this.oUsuario.DeleteUsuario(IdUsuario);

                    if (response == 0)
                    {
                        MessageBox.Show("Ocurrio un error,comuniquese con el administrador", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se elimino correctamente.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.dgvUsuarios.Rows.RemoveAt(this.dgvUsuarios.CurrentRow.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdUsuario = (int)this.dgvUsuarios.Rows[e.RowIndex].Cells[0].Value;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataTable dt = null;
                dt = CreateDataTable(oUsuario.GetByUsuario(this.txtBuscar.Text == "" ? "%" : this.txtBuscar.Text));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.dgvUsuarios.DataSource = dt;
            }
        }
    }
}
