using System;
using System.Data;
using System.Windows.Forms;
using Capa_LogicaDeNegocios;

namespace Pantallas_Sistema_facturacion.Formularios
{
    /// <summary>
    /// CAPA DE PRESENTACION - frmListaEmpleados.
    /// FUNCIONALIDAD: Muestra los empleados y permite buscar, crear (NUEVO),
    /// modificar (EDITAR) y retirar/eliminar (BORRAR).
    /// </summary>
    public partial class frmListaEmpleados : Form
    {
        DataTable dt = new DataTable();                // datos que llegan de la consulta
        Cls_Empleados empleado = new Cls_Empleados();  // objeto de la capa de negocios
        private readonly string usuarioActual;

        public frmListaEmpleados() : this("admin")
        {
        }

        public frmListaEmpleados(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmListaEmpleados_Load(object sender, EventArgs e)
        {
            llenar_grid();
        }

        // Consultamos todos los empleados y los mostramos en el grid
        private void llenar_grid()
        {
            try
            {
                dt = empleado.Consulta_Empleado();
                mostrar_en_grid(dt);
                if (dt.Rows.Count == 0)
                    MessageBox.Show(this, "No se encontraron registros");
            }
            catch (Exception ex)
            {
                MostrarError("No fue posible consultar los empleados.", ex);
            }
        }

        // Pasa cada fila del DataTable al grid
        private void mostrar_en_grid(DataTable tabla)
        {
            dgvEmpleados.Rows.Clear(); // limpiamos los datos previos
            foreach (DataRow row in tabla.Rows)
            {
                // 0=Id, 1=Nombre, 2=Documento, 4=Telefono, 10=Rol
                dgvEmpleados.Rows.Add(row[0].ToString(), row[1].ToString().Trim(), row[2].ToString(),
                                      row[4].ToString(), row[10].ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "") // verificamos si escribieron algo
            {
                try
                {
                    dt = empleado.Filtrar_Empleado(txtBuscar.Text.Trim());
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (frmEmpleados Empleado = new frmEmpleados())
            {
                Empleado.IdEmpleado = 0;              // cero = registro nuevo
                Empleado.UsuarioActual = usuarioActual;
                Empleado.ShowDialog(this);
            }
            llenar_grid(); // recargamos para ver los cambios
        }

        // Clic en las columnas de boton EDITAR y BORRAR
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clic en el encabezado

            int posActual = e.RowIndex;
            int idEmpleado = int.Parse(dgvEmpleados[0, posActual].Value.ToString());
            string nombre = dgvEmpleados[1, posActual].Value.ToString();

            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                using (frmEmpleados Empleado = new frmEmpleados())
                {
                    Empleado.IdEmpleado = idEmpleado; // con Id = modificar
                    Empleado.UsuarioActual = usuarioActual;
                    Empleado.ShowDialog(this);
                }
                llenar_grid();
            }

            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "btnBorrar")
            {
                if (MessageBox.Show(this, $"¿Esta seguro de borrar al empleado:\n{nombre}?", "CONFIRMACION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    empleado.C_IdEmpleado = idEmpleado;
                    string mensaje = empleado.EliminaEmpleado();

                    if (mensaje.StartsWith("ERROR") || mensaje.StartsWith("FALLO"))
                        mensaje = "No fue posible borrar el empleado. Verifique que no tenga facturas " +
                                  "o usuario de seguridad asociados.\n\nDetalle: " + mensaje;

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
