using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmListaProductos.
    /// FUNCIONALIDAD: Muestra los productos y permite buscar, crear (NUEVO),
    /// modificar (EDITAR) y eliminar (BORRAR). Desde aqui se abre frmProductos.
    /// </summary>
    public partial class frmListaProductos : Form
    {
        DataTable dt = new DataTable();                 // datos que llegan de la consulta
        Cls_Productos producto = new Cls_Productos();   // objeto de la capa de negocios
        private readonly string usuarioActual;

        public frmListaProductos() : this("admin")
        {
        }

        public frmListaProductos(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            llenar_grid();
        }

        // Consultamos todos los productos y los mostramos en el grid
        private void llenar_grid()
        {
            try
            {
                dt = producto.Consulta_Producto();
                mostrar_en_grid(dt);
                if (dt.Rows.Count == 0)
                    MessageBox.Show(this, "No se encontraron registros");
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible consultar los productos.", ex);
            }
        }

        // Pasa cada fila del DataTable al grid
        private void mostrar_en_grid(DataTable tabla)
        {
            dgvProductos.Rows.Clear(); // limpiamos los datos previos
            foreach (DataRow row in tabla.Rows)
            {
                // 0=Id, 1=Nombre, 2=Codigo, 3=P.compra, 4=P.venta, 8=Stock, 9=Categoria
                dgvProductos.Rows.Add(row[0].ToString(), row[2].ToString().Trim(), row[1].ToString().Trim(),
                                      row[9].ToString(),
                                      Convert.ToDouble(row[3]).ToString("C0"),
                                      Convert.ToDouble(row[4]).ToString("C0"),
                                      row[8] == DBNull.Value ? "0" : row[8].ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "") // verificamos si escribieron algo
            {
                try
                {
                    dt = producto.Filtrar_Producto(txtBuscar.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        mostrar_en_grid(dt);
                    }
                    else
                    {
                        MessageBox.Show(this, "No se encontraron registros para la busqueda solicitada");
                        llenar_grid();
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("No fue posible realizar la busqueda.", ex);
                }
            }
            else
            {
                llenar_grid(); // si no escribieron nada mostramos todos
            }
            txtBuscar.Text = "";
        }

        // Enter dentro del cuadro de busqueda equivale a pulsar Buscar
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar_Click(sender, EventArgs.Empty);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (frmProductos Producto = new frmProductos())
            {
                Producto.IdProducto = 0;              // cero = registro nuevo
                Producto.UsuarioActual = usuarioActual;
                Producto.ShowDialog(this);
            }
            llenar_grid(); // recargamos para ver los cambios
        }

        // Clic en las columnas de boton EDITAR y BORRAR
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clic en el encabezado

            int posActual = e.RowIndex;
            int idProducto = int.Parse(dgvProductos[0, posActual].Value.ToString());
            string nombre = dgvProductos[2, posActual].Value.ToString();

            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                using (frmProductos Producto = new frmProductos())
                {
                    Producto.IdProducto = idProducto; // con Id = modificar
                    Producto.UsuarioActual = usuarioActual;
                    Producto.ShowDialog(this);
                }
                llenar_grid();
            }

            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnBorrar")
            {
                if (MessageBox.Show(this, $"¿Esta seguro de borrar el producto:\n{nombre}?", "CONFIRMACION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    producto.C_IdProducto = idProducto;
                    string mensaje = producto.EliminaProducto();

                    if (mensaje.StartsWith("ERROR") || mensaje.StartsWith("FALLO"))
                        mensaje = "No fue posible borrar el producto.\n\nDetalle: " + mensaje;

                    MessageBox.Show(this, mensaje);
                    llenar_grid();
                }
            }
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
