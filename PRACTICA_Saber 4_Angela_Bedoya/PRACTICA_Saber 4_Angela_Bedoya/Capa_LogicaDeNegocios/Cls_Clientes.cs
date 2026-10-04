using System;
using System.Collections.Generic;
using System.Data;
using Capa_AccesoDatos;

namespace Capa_LogicaDeNegocios
{
    /// <summary>
    /// CAPA DE LOGICA DE NEGOCIOS - Clientes.
    /// FUNCIONALIDAD: Todas las operaciones del CRUD de clientes (tabla TBLCLIENTES):
    /// consultar todos, consultar uno, filtrar, guardar (insertar/actualizar) y eliminar.
    /// Las reglas de negocio viven aqui; el formulario solo captura y muestra datos.
    /// </summary>
    public class Cls_Clientes
    {
        // DEFINIMOS LOS ATRIBUTOS DE LA CLASE (uno por cada campo de la tabla)
        public int C_IdCliente { get; set; }
        public string C_StrNombre { get; set; }
        public long C_NumDocumento { get; set; }
        public string C_StrDireccion { get; set; }
        public string C_StrTelefono { get; set; }
        public string C_StrEmail { get; set; }
        public string C_StrUsuarioModifica { get; set; }

        Cls_Acceso_Datos AccesoDatos = new Cls_Acceso_Datos();

        // Columnas que se consultan (siempre en este mismo orden)
        private const string CAMPOS = @"SELECT IdCliente, StrNombre, NumDocumento, StrDireccion,
                                               StrTelefono, StrEmail
                                        FROM TBLCLIENTES ";

        // ===== Consultamos todos los clientes =====
        public DataTable Consulta_Cliente()
        {
            return AccesoDatos.EjecutarConsulta(CAMPOS + "ORDER BY StrNombre");
        }

        // ===== Sobrecarga: consultamos UN cliente por su Id =====
        public DataTable Consulta_Cliente(int IdCliente)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdCliente", IdCliente));
            return AccesoDatos.EjecutarConsulta(CAMPOS + "WHERE IdCliente = @IdCliente", lst);
        }

        // ===== Filtramos por nombre o documento =====
        public DataTable Filtrar_Cliente(string filtro)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Filtro", "%" + filtro + "%"));
            return AccesoDatos.EjecutarConsulta(CAMPOS +
                "WHERE StrNombre LIKE @Filtro OR CONVERT(varchar(20), NumDocumento) LIKE @Filtro ORDER BY StrNombre", lst);
        }

        // ===== REGLA DE NEGOCIO: no puede haber dos clientes con el mismo documento =====
        public bool ExisteDocumento()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Documento", C_NumDocumento));
            lst.Add(new Cls_parametros("@IdCliente", C_IdCliente));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLCLIENTES WHERE NumDocumento = @Documento AND IdCliente <> @IdCliente", lst);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // ===== REGLA DE NEGOCIO: un cliente con facturas no se puede borrar =====
        public int ContarFacturas()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdCliente", C_IdCliente));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLFACTURA WHERE IdCliente = @IdCliente", lst);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        // ===== Eliminamos un cliente (procedimiento Eliminar_Cliente) =====
        public string EliminaCliente()
        {
            string mensaje = "";
            try
            {
                int facturas = ContarFacturas();
                if (facturas > 0)
                    return "No se puede borrar el cliente porque tiene " + facturas + " factura(s) asociada(s)";

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdCliente", C_IdCliente));
                mensaje = AccesoDatos.Ejecutar_procedimiento("Eliminar_Cliente", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO EL BORRADO DEL CLIENTE. " + ex.Message;
            }
            return mensaje;
        }

        // ===== Insertamos (si IdCliente = 0) o actualizamos un cliente =====
        public string ActualizarCliente()
        {
            string mensaje = "";
            try
            {
                // REGLAS DE NEGOCIO
                if (string.IsNullOrWhiteSpace(C_StrNombre))
                    return "Debe ingresar el nombre del cliente";
                if (C_NumDocumento <= 0)
                    return "El numero de documento debe ser mayor que cero";
                if (!string.IsNullOrWhiteSpace(C_StrEmail) && !C_StrEmail.Contains("@"))
                    return "El correo electronico no es valido";
                if (ExisteDocumento())
                    return "Ya existe otro cliente con ese numero de documento";

                // El procedimiento actualizar_Cliente recibe el usuario en un varchar(10)
                string usuario = C_StrUsuarioModifica ?? "";
                if (usuario.Length > 10) usuario = usuario.Substring(0, 10);

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdCliente", C_IdCliente));
                lst.Add(new Cls_parametros("@StrNombre", C_StrNombre));
                lst.Add(new Cls_parametros("@NumDocumento", C_NumDocumento));
                lst.Add(new Cls_parametros("@StrDireccion", C_StrDireccion));
                lst.Add(new Cls_parametros("@StrTelefono", C_StrTelefono));
                lst.Add(new Cls_parametros("@StrEmail", C_StrEmail));
                lst.Add(new Cls_parametros("@StrUsuarioModifica", usuario));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));

                mensaje = AccesoDatos.Ejecutar_procedimiento("actualizar_Cliente", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO LA ACTUALIZACION DEL CLIENTE. " + ex.Message;
            }
            return mensaje;
        }
    }
}
