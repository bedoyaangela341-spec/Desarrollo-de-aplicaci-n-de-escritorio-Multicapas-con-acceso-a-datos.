using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmListaClientes.
    /// FUNCIONALIDAD: Muestra los clientes y permite buscar, crear (NUEVO),
    /// modificar (EDITAR) y eliminar (BORRAR). Es la primera pantalla del CRUD de clientes;
    /// desde aqui se abre frmClientes.
    /// </summary>
    public partial class frmListaClientes : Form
    {
        DataTable dt = new DataTable();               // datos que llegan de la consulta
        Cls_Clientes cliente = new Cls_Clientes();    // objeto de la capa de negocios
        private readonly string usuarioActual;

        public frmListaClientes() : this("admin")
        {
        }

        public frmListaClientes(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            llenar_grid();
        }

        // Consultamos todos los clientes y los mostramos en el grid
        private void llenar_grid()
        {
            try
            {
                dt = cliente.Consulta_Cliente();
                mostrar_en_grid(dt);
                if (dt.Rows.Count == 0)
                    MessageBox.Show(this, "No se encontraron registros");
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible consultar los clientes.", ex);
            }
        }

        // Pasa cada fila del DataTable al grid
        private void mostrar_en_grid(DataTable tabla)
        {
            dgvClientes.Rows.Clear(); // limpiamos los datos previos
            foreach (DataRow row in tabla.Rows)
            {
                // 0=Id, 1=Nombre, 2=Documento, 4=Telefono, 5=Email
                dgvClientes.Rows.Add(row[0].ToString(), row[1].ToString().Trim(), row[2].ToString(),
                                     row[4].ToString().Trim(), row[5].ToString().Trim());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "") // verificamos si escribieron algo
            {
                try
                {
                    dt = cliente.Filtrar_Cliente(txtBuscar.Text.Trim());
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
            using (frmClientes Cliente = new frmClientes())
            {
                Cliente.IdCliente = 0;              // cero = registro nuevo
                Cliente.UsuarioActual = usuarioActual;
                Cliente.ShowDialog(this);
            }
            llenar_grid(); // recargamos para ver los cambios
        }

        // Clic en las columnas de boton EDITAR y BORRAR
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clic en el encabezado

            int posActual = e.RowIndex;
            int idCliente = int.Parse(dgvClientes[0, posActual].Value.ToString());
            string nombre = dgvClientes[1, posActual].Value.ToString();

            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                using (frmClientes Cliente = new frmClientes())
                {
                    Cliente.IdCliente = idCliente; // con Id = modificar
                    Cliente.UsuarioActual = usuarioActual;
                    Cliente.ShowDialog(this);
                }
                llenar_grid();
            }

            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnBorrar")
            {
                if (MessageBox.Show(this, $"¿Esta seguro de borrar al cliente:\n{nombre}?", "CONFIRMACION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cliente.C_IdCliente = idCliente;
                    string mensaje = cliente.EliminaCliente();

                    if (mensaje.StartsWith("ERROR") || mensaje.StartsWith("FALLO"))
                        mensaje = "No fue posible borrar el cliente.\n\nDetalle: " + mensaje;

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
