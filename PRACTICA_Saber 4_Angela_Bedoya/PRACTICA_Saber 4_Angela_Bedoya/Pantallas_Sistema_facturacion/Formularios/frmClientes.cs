using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmClientes.
    /// FUNCIONALIDAD: Ingresa un cliente nuevo (IdCliente = 0) o modifica
    /// uno existente (IdCliente con valor). Se abre desde frmListaClientes.
    /// </summary>
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        public int IdCliente { get; set; }          // "buzon": 0 = nuevo, otro valor = modificar
        public string UsuarioActual { get; set; } = "admin";

        DataTable dt = new DataTable();
        Cls_Clientes cliente = new Cls_Clientes();

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    lblTitulo.Text = "Ingreso nuevo cliente";   // REGISTRO NUEVO
                }
                else
                {
                    lblTitulo.Text = "Modificar cliente";       // MODIFICAR EL ID QUE RECIBIMOS
                    llenar_campos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible cargar la informacion.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consultamos el cliente por su Id y pasamos los datos a los campos
        private void llenar_campos()
        {
            dt = cliente.Consulta_Cliente(IdCliente);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombre.Text = row[1].ToString().Trim();
                txtDocumento.Text = row[2].ToString();
                txtDireccion.Text = row[3].ToString().Trim();
                txtTelefono.Text = row[4].ToString().Trim();
                txtEmail.Text = row[5].ToString().Trim();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        // Ingresa o actualiza la informacion del cliente en la base de datos
        public void Guardar()
        {
            if (validar()) // primero revisamos los campos
            {
                cliente.C_IdCliente = IdCliente;
                cliente.C_StrNombre = txtNombre.Text.Trim();
                cliente.C_NumDocumento = long.Parse(txtDocumento.Text.Trim());
                cliente.C_StrDireccion = txtDireccion.Text.Trim();
                cliente.C_StrTelefono = txtTelefono.Text.Trim();
                cliente.C_StrEmail = txtEmail.Text.Trim();
                cliente.C_StrUsuarioModifica = UsuarioActual;

                string mensaje = cliente.ActualizarCliente(); // la capa de negocios hace el resto
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
                MensajeError.SetError(txtNombre, "Debe ingresar el nombre del cliente");
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
                MensajeError.SetError(txtDocumento, "El documento debe ser numerico y mayor que cero");
                camposOk = false;
            }
            else { MensajeError.SetError(txtDocumento, ""); }

            if (txtEmail.Text.Trim() != "" && !correoValido(txtEmail.Text.Trim()))
            {
                MensajeError.SetError(txtEmail, "Ingrese un correo valido (ej: nombre@dominio.com)");
                camposOk = false;
            }
            else { MensajeError.SetError(txtEmail, ""); }

            if (txtTelefono.Text.Trim() != "" && !telefonoValido(txtTelefono.Text.Trim()))
            {
                MensajeError.SetError(txtTelefono, "El telefono solo admite numeros, espacios, + - ( )");
                camposOk = false;
            }
            else { MensajeError.SetError(txtTelefono, ""); }

            return camposOk;
        }

        // Revisa si un texto es un numero entero valido y positivo
        private bool esNumerico(string num)
        {
            long x;
            return long.TryParse(num, out x) && x > 0;
        }

        private bool correoValido(string correo)
        {
            int arroba = correo.IndexOf('@');
            return arroba > 0 && arroba == correo.LastIndexOf('@')
                   && correo.IndexOf('.', arroba) > arroba + 1
                   && !correo.EndsWith(".") && !correo.Contains(" ");
        }

        private bool telefonoValido(string tel)
        {
            foreach (char c in tel)
                if (!char.IsDigit(c) && " +-()".IndexOf(c) < 0) return false;
            return true;
        }

        // Solo permite digitos en el campo (el documento)
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
