using System;
using System.Windows.Forms;
using Pantallas_Sistema_facturacion.Formularios;

namespace Pantallas_Sistema_facturacion
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Punto de entrada del sistema: primero se valida el acceso en
            // frmLogin. Si el usuario ingresa correctamente, frmLogin abre
            // frmMenuPrincipal, desde donde se accede a Clientes, Productos,
            // Empleados y Seguridad.
            Application.Run(new frmLogin());
        }
    }
}
