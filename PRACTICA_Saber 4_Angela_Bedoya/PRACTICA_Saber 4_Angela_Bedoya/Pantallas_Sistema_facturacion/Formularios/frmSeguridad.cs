using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmSeguridad.
    /// FUNCIONALIDAD: Consulta, asigna, modifica y elimina el usuario y la clave
    /// con los que cada empleado entra al sistema (tabla TBLSEGURIDAD).
    /// </summary>
    public partial class frmSeguridad : Form
    {
        DataTable dt = new DataTable();
        Cls_Seguridad SeguridadEmpleado = new Cls_Seguridad();
        private readonly string usuarioActual;

        public frmSeguridad() : this("admin")
        {
        }

        public frmSeguridad(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmSeguridad_Load(object sender, EventArgs e)
        {
            llenar_combo_Empleados();
            llenar_grid_usuarios();
        }

        // Llenamos el combo con la lista de empleados
        private void llenar_combo_Empleados()
        {
            try
            {
                cboEmpleado.DataSource = SeguridadEmpleado.ConsultarEmpleados();
                cboEmpleado.DisplayMember = "strNombre"; // lo que ve el usuario
                cboEmpleado.ValueMember = "IdEmpleado";  // codigo interno del empleado
                cboEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible cargar los empleados.", ex);
            }
        }

        // Tabla inferior: que empleados tienen usuario asignado
        private void llenar_grid_usuarios()
        {
            try
            {
                dgvUsuarios.DataSource = SeguridadEmpleado.ConsultarUsuariosAsignados();
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible cargar la lista de usuarios.", ex);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        // Consulta el usuario y la clave del empleado seleccionado en el combo
        public void Consultar()
        {
            if (cboEmpleado.SelectedValue == null)
            {
                MessageBox.Show(this, "Seleccione primero un empleado");
                return;
            }
            try
            {
                int IdEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);
                dt = SeguridadEmpleado.Consulta_SeguridadEmpleado(IdEmpleado);
                if (dt.Rows.Count > 0)
                {
                    txtUsuario.Text = dt.Rows[0][0].ToString().Trim();
                    txtClave.Text = dt.Rows[0][1].ToString().Trim();
                    lblAyuda.Text = "Este empleado ya tiene usuario. Puede cambiarlo y pulsar Actualizar.";
                }
                else
                {
                    txtUsuario.Text = "";
                    txtClave.Text = "";
                    lblAyuda.Text = "Este empleado no tiene usuario. Escriba uno y pulse Actualizar.";
                    MessageBox.Show(this, "No se le ha asignado usuario y clave a este empleado");
                }
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible consultar.", ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        // Guarda (ingresa o actualiza) el usuario y la clave del empleado
        public void Guardar()
        {
            if (validar())
            {
                SeguridadEmpleado.C_IdEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);
                SeguridadEmpleado.C_StrUsuario = txtUsuario.Text.Trim();
                SeguridadEmpleado.C_StrClave = txtClave.Text;
                SeguridadEmpleado.C_StrUsuarioModifico = usuarioActual;

                string mensaje = SeguridadEmpleado.ActualizarSeguridadEmpleado();
                MessageBox.Show(this, mensaje);
                if (mensaje == "Los datos fueron actualizados")
                    Limpiar();
                llenar_grid_usuarios();
            }
        }

        // Valida que haya empleado, usuario y clave
        private bool validar()
        {
            bool camposOk = true;

            if (cboEmpleado.SelectedValue == null)
            {
                MensajeError.SetError(cboEmpleado, "Debe seleccionar un empleado");
                camposOk = false;
            }
            else { MensajeError.SetError(cboEmpleado, ""); }

            if (txtUsuario.Text.Trim() == "")
            {
                MensajeError.SetError(txtUsuario, "Debe ingresar el usuario");
                camposOk = false;
            }
            else { MensajeError.SetError(txtUsuario, ""); }

            if (txtClave.Text.Trim().Length < 3)
            {
                MensajeError.SetError(txtClave, "La clave debe tener al menos 3 caracteres");
                camposOk = false;
            }
            else { MensajeError.SetError(txtClave, ""); }

            return camposOk;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        // Elimina el usuario y la clave del empleado seleccionado
        public void Eliminar()
        {
            if (cboEmpleado.SelectedValue == null)
            {
                MessageBox.Show(this, "Seleccione primero un empleado");
                return;
            }
            if (MessageBox.Show(this, $"ESTA SEGURO DE BORRAR EL USUARIO DE:\n{cboEmpleado.Text}", "CONFIRMACION",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SeguridadEmpleado.C_IdEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);
                string mensaje = SeguridadEmpleado.EliminarSeguridadEmpleado();
                MessageBox.Show(this, mensaje);
                Limpiar();
                llenar_grid_usuarios();
            }
        }

        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.PasswordChar = chkMostrarClave.Checked ? '\0' : '●';
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            MensajeError.Clear();
            lblAyuda.Text = "Seleccione un empleado y pulse Consultar para ver su usuario y clave.";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show(this, mensaje + Environment.NewLine + Environment.NewLine + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
