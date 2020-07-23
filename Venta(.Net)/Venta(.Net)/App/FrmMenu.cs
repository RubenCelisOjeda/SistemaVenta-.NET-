using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Venta_.Net_.App;
using Venta_.Net_.App.Mantenimiento;

namespace Venta_.Net_
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show(null, "¿Desea salir de la aplicación?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL",EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam,int lParam);

        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.AbrirFrm(new FrmInicio());
        }

        private void AbrirFrm(Control frmHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.RemoveAt(0);
            }

            Form form = frmHijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            this.pnlContenedor.Controls.Add(frmHijo);
            this.pnlContenedor.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.AbrirFrm(new FrmInicio());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.AbrirFrm(new FrmReportes());
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            this.AbrirFrm(new FrmInicio());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.AbrirFrm(new FrmUsuario());
        }
    }
}
