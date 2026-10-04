using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmProductos.
    /// FUNCIONALIDAD: Ingresa un producto nuevo (IdProducto = 0) o modifica
    /// uno existente (IdProducto con valor). Se abre desde frmListaProductos.
    /// </summary>
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        public int IdProducto { get; set; }         // "buzon": 0 = nuevo, otro valor = modificar
        public string UsuarioActual { get; set; } = "admin";

        DataTable dt = new DataTable();
        Cls_Productos producto = new Cls_Productos();

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                llenar_combo(); // llenamos el combo de categorias
                if (IdProducto == 0)
                {
                    // REGISTRO NUEVO
                    lblTitulo.Text = "Ingreso nuevo producto";
                    cboCategoria.SelectedIndex = -1;
                    txtStock.Text = "0";
                    txtFoto.Text = "ninguna";
                }
                else
                {
                    // MODIFICAR EL REGISTRO DEL ID QUE RECIBIMOS
                    lblTitulo.Text = "Modificar producto";
                    llenar_campos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No fue posible cargar la informacion.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llenamos el combo con la lista de categorias
        private void llenar_combo()
        {
            cboCategoria.DataSource = producto.ConsultarCategoria();
            cboCategoria.DisplayMember = "StrDescripcion"; // lo que ve el usuario
            cboCategoria.ValueMember = "IdCategoria";      // lo que se guarda en la tabla
        }

        // Consultamos el producto por su Id y pasamos los datos a los campos
        private void llenar_campos()
        {
            dt = producto.Consulta_Producto(IdProducto);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombre.Text = row[1].ToString().Trim();
                txtCodigo.Text = row[2].ToString().Trim();
                txtPrecioCompra.Text = Convert.ToDouble(row[3]).ToString(CultureInfo.CurrentCulture);
                txtPrecioVenta.Text = Convert.ToDouble(row[4]).ToString(CultureInfo.CurrentCulture);
                if (row[5] != DBNull.Value) cboCategoria.SelectedValue = Convert.ToInt32(row[5]);
                txtDetalle.Text = row[6].ToString().Trim();
                txtFoto.Text = row[7].ToString().Trim();
                txtStock.Text = row[8] == DBNull.Value ? "0" : row[8].ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        // Ingresa o actualiza la informacion del producto en la base de datos
        public void Guardar()
        {
            if (validar()) // primero revisamos los campos
            {
                producto.C_IdProducto = IdProducto;
                producto.C_StrNombre = txtNombre.Text.Trim();
                producto.C_StrCodigo = txtCodigo.Text.Trim();
                producto.C_NumPrecioCompra = double.Parse(txtPrecioCompra.Text.Trim(), CultureInfo.CurrentCulture);
                producto.C_NumPrecioVenta = double.Parse(txtPrecioVenta.Text.Trim(), CultureInfo.CurrentCulture);
                producto.C_IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                producto.C_StrDetalle = txtDetalle.Text.Trim();
                producto.C_StrFoto = txtFoto.Text.Trim();
                producto.C_NumStock = int.Parse(txtStock.Text.Trim());
                producto.C_StrUsuarioModifica = UsuarioActual;

                string mensaje = producto.ActualizarProducto(); // la capa de negocios hace el resto
                MessageBox.Show(this, mensaje);

                if (mensaje == "Los datos fueron actualizados")
                    this.Close(); // volvemos a la lista
            }
        }

        // Valida los campos usando el ErrorProvider (MensajeError)
        private bool validar()
        {
            bool camposOk = true;
            double compra = 0, venta = 0;
            int stock;

            if (txtNombre.Text.Trim() == string.Empty)
            {
                MensajeError.SetError(txtNombre, "Debe ingresar el nombre del producto");
                camposOk = false;
            }
            else { MensajeError.SetError(txtNombre, ""); }

            if (txtCodigo.Text.Trim() == string.Empty)
            {
                MensajeError.SetError(txtCodigo, "Debe ingresar el codigo del producto");
                camposOk = false;
            }
            else { MensajeError.SetError(txtCodigo, ""); }

            if (cboCategoria.SelectedValue == null)
            {
                MensajeError.SetError(cboCategoria, "Debe seleccionar una categoria");
                camposOk = false;
            }
            else { MensajeError.SetError(cboCategoria, ""); }

            bool compraOk = double.TryParse(txtPrecioCompra.Text.Trim(), NumberStyles.Number,
                                            CultureInfo.CurrentCulture, out compra) && compra >= 0;
            if (!compraOk)
            {
                MensajeError.SetError(txtPrecioCompra, "Ingrese un precio de compra valido (0 o mayor)");
                camposOk = false;
            }
            else { MensajeError.SetError(txtPrecioCompra, ""); }

            bool ventaOk = double.TryParse(txtPrecioVenta.Text.Trim(), NumberStyles.Number,
                                           CultureInfo.CurrentCulture, out venta) && venta >= 0;
            if (!ventaOk)
            {
                MensajeError.SetError(txtPrecioVenta, "Ingrese un precio de venta valido (0 o mayor)");
                camposOk = false;
            }
            else if (compraOk && venta < compra)
            {
                MensajeError.SetError(txtPrecioVenta, "El precio de venta no puede ser menor que el de compra");
                camposOk = false;
            }
            else { MensajeError.SetError(txtPrecioVenta, ""); }

            if (!int.TryParse(txtStock.Text.Trim(), out stock) || stock < 0)
            {
                MensajeError.SetError(txtStock, "Ingrese una cantidad de stock valida (0 o mayor)");
                camposOk = false;
            }
            else { MensajeError.SetError(txtStock, ""); }

            return camposOk;
        }

        // Solo permite digitos (stock)
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Permite digitos y un unico separador decimal (precios)
        private void soloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            TextBox caja = (TextBox)sender;
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar.ToString() == sep && !caja.Text.Contains(sep)) return;
            e.Handled = true;
        }

        // La tabla guarda el nombre del archivo de la foto (maximo 50 caracteres)
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccione la foto del producto";
                dialogo.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    string nombre = Path.GetFileName(dialogo.FileName);
                    if (nombre.Length > 50)
                        MessageBox.Show(this, "El nombre del archivo supera los 50 caracteres. Renombrelo e intente de nuevo.");
                    else
                        txtFoto.Text = nombre;
                }
            }
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
