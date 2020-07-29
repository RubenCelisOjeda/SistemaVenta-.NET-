using Business;
using Entidades.Dto.Usuario;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Venta_.Net_.Properties;

namespace Venta_.Net_
{
    public partial class FrmLogin : Form
    {
        private BusinessUsuario oUsuario = new BusinessUsuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var check = Properties.Settings.Default.Check;

            if (check)
            {
                this.txtUsuario.Text = Properties.Settings.Default.Usuario;
                this.txtPassword.Focus();
                this.chkRecordarUsuario.Checked = true;
            }
            else
            {
                Properties.Settings.Default.Check = false;
                Properties.Settings.Default.Usuario = "";
                this.txtPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Login();
        }

        private void Login()
        {
            string user = string.Empty;
            string password = string.Empty;

            user = this.txtUsuario.Text.Trim();
            password = this.txtPassword.Text.Trim();

            try
            {
                var login = new DtoLoginRequest()
                {
                    Id = 0,
                    Usuario = user,
                    Password = password
                };

                var data = oUsuario.Login(login);

                if (string.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    MessageBox.Show(null, "Ingrese usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUsuario.Focus();
                }
                else if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show(null, "Ingrese contraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtPassword.Focus();
                }
                else if (data == null)
                {
                    MessageBox.Show(null, "Usuario y/o contraseña incorrecta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUsuario.Focus();
                }
                else if (data.Count == 0)
                {
                    MessageBox.Show(null, "Usuario y/o contraseña incorrecta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //codigo para guardar el nombre en el appconfig
                    Properties.Settings.Default.Usuario = this.txtUsuario.Text;
                    Properties.Settings.Default.Check = this.chkRecordarUsuario.Checked;
                    Properties.Settings.Default.Save();

                    //asigna el id del usuario a la variable global
                    VarGlo.Instance().CodUsuario = data.Id;

                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Ocurrio un error,Comuniquese con el administrador", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Dll que permite mover el formulario.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
