using System;
using System.Collections.Generic;
using System.Data;
using Capa_AccesoDatos;

namespace Capa_LogicaDeNegocios
{
    /// <summary>
    /// CAPA DE LOGICA DE NEGOCIOS - Empleados.
    /// FUNCIONALIDAD: Todas las operaciones del CRUD de empleados (tabla TBLEMPLEADO):
    /// consultar todos, consultar uno, filtrar, consultar roles, guardar y eliminar.
    /// </summary>
    public class Cls_Empleados
    {
        // DEFINIMOS LOS ATRIBUTOS DE LA CLASE (uno por cada campo de la tabla)
        public int C_IdEmpleado { get; set; }
        public string C_StrNombre { get; set; }
        public long C_NumDocumento { get; set; }
        public string C_StrDireccion { get; set; }
        public string C_StrTelefono { get; set; }
        public string C_StrEmail { get; set; }
        public int C_IdRolEmpleado { get; set; }
        public DateTime C_DtmIngreso { get; set; }
        public DateTime? C_DtmRetiro { get; set; }   // null = empleado activo
        public string C_StrDatosAdicionales { get; set; }
        public string C_StrUsuarioModifico { get; set; }

        Cls_Acceso_Datos AccesoDatos = new Cls_Acceso_Datos();

        // Columnas que se consultan (siempre en este mismo orden)
        private const string CAMPOS = @"SELECT e.IdEmpleado, e.strNombre, e.NumDocumento, e.StrDireccion,
                                               e.StrTelefono, e.StrEmail, e.IdRolEmpleado, e.DtmIngreso,
                                               e.DtmRetiro, e.strDatosAdicionales, r.StrDescripcion AS Rol
                                        FROM TBLEMPLEADO e
                                        LEFT JOIN TBLROLES r ON e.IdRolEmpleado = r.IdRolEmpleado ";

        // ===== Consultamos todos los empleados =====
        public DataTable Consulta_Empleado()
        {
            return AccesoDatos.EjecutarConsulta(CAMPOS + "ORDER BY e.strNombre");
        }

        // ===== Sobrecarga: consultamos UN empleado por su Id =====
        public DataTable Consulta_Empleado(int IdEmpleado)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@IdEmpleado", IdEmpleado));
            return AccesoDatos.EjecutarConsulta(CAMPOS + "WHERE e.IdEmpleado = @IdEmpleado", lst);
        }

        // ===== Filtramos por nombre o documento =====
        public DataTable Filtrar_Empleado(string filtro)
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Filtro", "%" + filtro + "%"));
            return AccesoDatos.EjecutarConsulta(CAMPOS +
                "WHERE e.strNombre LIKE @Filtro OR CONVERT(varchar(20), e.NumDocumento) LIKE @Filtro ORDER BY e.strNombre", lst);
        }

        // ===== Consultamos los roles para llenar el combo =====
        public DataTable ConsultarRol()
        {
            return AccesoDatos.EjecutarConsulta("SELECT IdRolEmpleado, StrDescripcion FROM TBLROLES ORDER BY StrDescripcion");
        }

        // ===== REGLA DE NEGOCIO: no puede haber dos empleados con el mismo documento =====
        public bool ExisteDocumento()
        {
            List<Cls_parametros> lst = new List<Cls_parametros>();
            lst.Add(new Cls_parametros("@Documento", C_NumDocumento));
            lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
            DataTable dt = AccesoDatos.EjecutarConsulta(
                "SELECT COUNT(*) FROM TBLEMPLEADO WHERE NumDocumento = @Documento AND IdEmpleado <> @IdEmpleado", lst);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // ===== Eliminamos un empleado (procedimiento Eliminar_Empleado) =====
        public string EliminaEmpleado()
        {
            string mensaje = "";
            try
            {
                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
                mensaje = AccesoDatos.Ejecutar_procedimiento("Eliminar_Empleado", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO EL BORRADO DEL EMPLEADO. " + ex.Message;
            }
            return mensaje;
        }

        // ===== Insertamos (si IdEmpleado = 0) o actualizamos un empleado =====
        public string ActualizarEmpleado()
        {
            string mensaje = "";
            try
            {
                // REGLA DE NEGOCIO: la fecha de retiro no puede ser anterior al ingreso
                if (C_DtmRetiro.HasValue && C_DtmRetiro.Value.Date < C_DtmIngreso.Date)
                    return "La fecha de retiro no puede ser anterior a la fecha de ingreso";

                if (ExisteDocumento())
                    return "Ya existe otro empleado con ese numero de documento";

                List<Cls_parametros> lst = new List<Cls_parametros>();
                lst.Add(new Cls_parametros("@IdEmpleado", C_IdEmpleado));
                lst.Add(new Cls_parametros("@strNombre", C_StrNombre));
                lst.Add(new Cls_parametros("@NumDocumento", C_NumDocumento));
                lst.Add(new Cls_parametros("@StrDireccion", C_StrDireccion));
                lst.Add(new Cls_parametros("@StrTelefono", C_StrTelefono));
                lst.Add(new Cls_parametros("@StrEmail", C_StrEmail));
                lst.Add(new Cls_parametros("@IdRolEmpleado", C_IdRolEmpleado));
                lst.Add(new Cls_parametros("@DtmIngreso", C_DtmIngreso));
                lst.Add(new Cls_parametros("@DtmRetiro", C_DtmRetiro));
                lst.Add(new Cls_parametros("@strDatosAdicionales", C_StrDatosAdicionales));
                lst.Add(new Cls_parametros("@DtmFechaModifica", DateTime.Now));
                lst.Add(new Cls_parametros("@StrUsuarioModifico", C_StrUsuarioModifico));

                mensaje = AccesoDatos.Ejecutar_procedimiento("actualizar_Empleado", lst);
            }
            catch (Exception ex)
            {
                mensaje = "FALLO LA ACTUALIZACION DEL EMPLEADO. " + ex.Message;
            }
            return mensaje;
        }
    }
}
