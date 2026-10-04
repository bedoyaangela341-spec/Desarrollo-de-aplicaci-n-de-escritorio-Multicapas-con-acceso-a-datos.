using System;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmLogin.
    /// FUNCIONALIDAD: Captura usuario y clave y le pide a la capa de negocios
    /// (clase Validar_usuario) que los verifique contra la tabla TBLSEGURIDAD.
    /// Si son correctos abre frmMenuPrincipal.
    /// </summary>
    public partial class frmLogin : Form
    {
        private int intentosFallidos = 0;
        private const int MaximoIntentos = 3;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IntentarIngresar();
        }

        // Permite ingresar con la tecla Enter desde la clave
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IntentarIngresar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IntentarIngresar()
        {
            lblMensaje.Text = string.Empty;

            // Validacion basica (responsabilidad de la capa de presentacion)
            if (txtUsuario.Text.Trim() == "" || txtClave.Text == string.Empty)
            {
                lblMensaje.Text = "Debe ingresar un usuario y una clave.";
                return;
            }

            try
            {
                // Creamos el objeto a partir de la clase Validar_usuario (capa de negocios)
                Validar_usuario Obj_validar = new Validar_usuario();

                // Asignamos valores a los atributos
                Obj_validar.C_StrUsuario = txtUsuario.Text.Trim();
                Obj_validar.C_StrClave = txtClave.Text;

                Obj_validar.ValidarUsuario(); // ejecutamos el metodo de validacion

                if (Obj_validar.C_IdEmpleado != 0)
                {
                    MessageBox.Show(this, "Datos de verificacion validos. Bienvenido(a) " + Obj_validar.C_StrNombreEmpleado,
                        "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // ocultamos el login
                    using (frmMenuPrincipal menu = new frmMenuPrincipal(
                        Obj_validar.C_StrNombreEmpleado, Obj_validar.C_StrRol, Obj_validar.C_StrUsuario))
                    {
                        menu.ShowDialog(); // mostramos el menu principal
                    }
                    this.Close();
                }
                else
                {
                    intentosFallidos++;
                    lblMensaje.Text = "USUARIO Y CLAVE NO ENCONTRADOS (intento " + intentosFallidos + " de " + MaximoIntentos + ")";
                    txtClave.Clear();
                    txtUsuario.Focus();

                    if (intentosFallidos >= MaximoIntentos)
                    {
                        MessageBox.Show(this, "Ha superado el numero maximo de intentos. El sistema se cerrara.",
                            "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible validar el acceso. Verifique la conexion a la base de datos."
                    + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
