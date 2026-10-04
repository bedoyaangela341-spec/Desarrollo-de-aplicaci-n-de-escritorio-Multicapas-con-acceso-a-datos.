using System;
using System.Windows.Forms;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - Menu principal.
    /// Se abre despues de un login exitoso y permite navegar a los modulos.
    /// </summary>
    public partial class frmMenuPrincipal : Form
    {
        private readonly string nombreEmpleado;   // se muestra en la bienvenida
        private readonly string usuarioActual;    // usuario de login: se guarda como "StrUsuarioModifico"
        private bool cerrandoPorLogin = false;

        public frmMenuPrincipal() : this("Administrador", string.Empty, "admin")
        {
        }

        public frmMenuPrincipal(string nombre, string rol, string usuario)
        {
            InitializeComponent();
            nombreEmpleado = string.IsNullOrWhiteSpace(nombre) ? "Administrador" : nombre;
            usuarioActual = string.IsNullOrWhiteSpace(usuario) ? "admin" : usuario;
            lblBienvenida.Text = $"Bienvenido, {nombreEmpleado}.";
            lblRol.Text = string.IsNullOrWhiteSpace(rol) ? string.Empty : $"Rol: {rol}";
        }

        // CRUD Clientes: primero se abre la LISTA; desde ella se abre frmClientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (frmListaClientes frm = new frmListaClientes(usuarioActual))
            {
                frm.ShowDialog(this);
            }
        }

        // CRUD Productos: primero se abre la LISTA; desde ella se abre frmProductos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            using (frmListaProductos frm = new frmListaProductos(usuarioActual))
            {
                frm.ShowDialog(this);
            }
        }

        // CRUD Empleados: primero se abre la LISTA; desde ella se abre frmEmpleados
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            using (frmListaEmpleados frm = new frmListaEmpleados(usuarioActual))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            using (frmSeguridad frm = new frmSeguridad(usuarioActual))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(this,
                "¿Desea cerrar la sesion actual y volver al inicio de sesion?",
                "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            cerrandoPorLogin = true;
            this.Close();
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrandoPorLogin)
            {
                using (frmLogin login = new frmLogin())
                {
                    login.ShowDialog();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
