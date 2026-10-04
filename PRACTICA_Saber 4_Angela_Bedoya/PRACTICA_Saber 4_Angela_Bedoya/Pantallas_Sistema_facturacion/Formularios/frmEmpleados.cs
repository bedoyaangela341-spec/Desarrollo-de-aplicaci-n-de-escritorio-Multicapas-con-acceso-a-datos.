using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmEmpleados.
    /// FUNCIONALIDAD: Ingresa un empleado nuevo (IdEmpleado = 0) o modifica
    /// uno existente (IdEmpleado con valor). Se abre desde frmListaEmpleados.
    /// </summary>
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        public int IdEmpleado { get; set; }        // "buzon": 0 = nuevo, otro valor = modificar
        public string UsuarioActual { get; set; } = "admin";

        DataTable dt = new DataTable();
        Cls_Empleados empleado = new Cls_Empleados();

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                llenar_combo(); // llenamos el combo de roles
                if (IdEmpleado == 0)
                {
                    // REGISTRO NUEVO
                    lblTitulo.Text = "Ingreso nuevo empleado";
                    dtpIngreso.Value = DateTime.Today;
                    cboRol.SelectedIndex = -1;
                }
                else
                {
                    // MODIFICAR EL REGISTRO DEL ID QUE RECIBIMOS
                    lblTitulo.Text = "Modificar empleado";
                    llenar_campos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible cargar la informacion.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llenamos el combo con la lista de roles
        private void llenar_combo()
        {
            cboRol.DataSource = empleado.ConsultarRol();
            cboRol.DisplayMember = "StrDescripcion"; // lo que ve el usuario
            cboRol.ValueMember = "IdRolEmpleado";    // lo que se guarda en la tabla
        }

        // Consultamos el empleado por su Id y pasamos los datos a los campos
        private void llenar_campos()
        {
            dt = empleado.Consulta_Empleado(IdEmpleado);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombre.Text = row[1].ToString().Trim();
                txtDocumento.Text = row[2].ToString();
                txtDireccion.Text = row[3].ToString().Trim();
                txtTelefono.Text = row[4].ToString().Trim();
                txtEmail.Text = row[5].ToString().Trim();
                if (row[6] != DBNull.Value) cboRol.SelectedValue = Convert.ToInt32(row[6]);
                if (row[7] != DBNull.Value) dtpIngreso.Value = Convert.ToDateTime(row[7]);

                if (row[8] == DBNull.Value)
                {
                    chkActivo.Checked = true;   // sin fecha de retiro = activo
                }
                else
                {
                    chkActivo.Checked = false;
                    dtpRetiro.Value = Convert.ToDateTime(row[8]);
                }
                txtDatosAdicionales.Text = row[9].ToString().Trim();
            }
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            dtpRetiro.Enabled = !chkActivo.Checked;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        // Ingresa o actualiza la informacion del empleado en la base de datos
        public void Guardar()
        {
            if (validar()) // primero revisamos los campos
            {
                empleado.C_IdEmpleado = IdEmpleado;
                empleado.C_StrNombre = txtNombre.Text.Trim();
                empleado.C_NumDocumento = long.Parse(txtDocumento.Text.Trim());
                empleado.C_StrDireccion = txtDireccion.Text.Trim();
                empleado.C_StrTelefono = txtTelefono.Text.Trim();
                empleado.C_StrEmail = txtEmail.Text.Trim();
                empleado.C_IdRolEmpleado = Convert.ToInt32(cboRol.SelectedValue);
                empleado.C_DtmIngreso = dtpIngreso.Value.Date;
                empleado.C_DtmRetiro = chkActivo.Checked ? (DateTime?)null : dtpRetiro.Value.Date;
                empleado.C_StrDatosAdicionales = txtDatosAdicionales.Text.Trim();
                empleado.C_StrUsuarioModifico = UsuarioActual;

                string mensaje = empleado.ActualizarEmpleado(); // la capa de negocios hace el resto
                MessageBox.Show(this, mensaje);

                if (mensaje == "Los datos fueron actualizados")
                    this.Close(); // volvemos a la lista
            }
        }

        // Valida los campos usando el ErrorProvider (MensajeError)
        private bool validar()
        {
            bool camposOk = true;

            if (txtNombre.Text.Trim() == string.Empty)
            {
                MensajeError.SetError(txtNombre, "Debe ingresar el nombre del empleado");
                camposOk = false;
            }
            else { MensajeError.SetError(txtNombre, ""); }

            if (txtDocumento.Text.Trim() == "")
            {
                MensajeError.SetError(txtDocumento, "Debe ingresar el documento");
                camposOk = false;
            }
            else if (!esNumerico(txtDocumento.Text.Trim()))
            {
                MensajeError.SetError(txtDocumento, "El documento debe ser numerico");
                camposOk = false;
            }
            else { MensajeError.SetError(txtDocumento, ""); }

            if (txtEmail.Text.Trim() != "" && !txtEmail.Text.Contains("@"))
            {
                MensajeError.SetError(txtEmail, "Ingrese un correo valido");
                camposOk = false;
            }
            else { MensajeError.SetError(txtEmail, ""); }

            if (cboRol.SelectedValue == null)
            {
                MensajeError.SetError(cboRol, "Debe seleccionar un rol");
                camposOk = false;
            }
            else { MensajeError.SetError(cboRol, ""); }

            return camposOk;
        }

        // Revisa si un texto es un numero entero valido
        private bool esNumerico(string num)
        {
            long x;
            return long.TryParse(num, out x) && x > 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult Rta = MessageBox.Show(this, "¿Desea salir de la edicion?", "MENSAJE DE ADVERTENCIA",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Rta == DialogResult.OK)
                this.Close();
        }
    }
}
